using BandR;
using Microsoft.SharePoint.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace SP5000ItemLimitThresholdHelper
{
    public partial class Form1 : System.Windows.Forms.Form
    {

        private AboutForm aboutForm = null;
        private BackgroundWorker bgw = null;
        private int statusWindowOutputBatchSize = GenUtil.SafeToInt(ConfigurationManager.AppSettings["statusWindowOutputBatchSize"]);
        private bool showFullErrMsgs = GenUtil.SafeToBool(ConfigurationManager.AppSettings["showFullErrMsgs"]);
        private bool ErrorOccurred = false;
        private string selAction;



        /// <summary>
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            toolStripStatusLabel1.Text = "";

            // #testing
            if (System.Environment.MachineName.IsEqual("PERSEUS"))
            {
            }

            this.FormClosed += Form1_FormClosed;

            ddlActions.SelectedItem = "Move Files";
            ddlActions_SelectedIndexChanged(null, null);

            LoadSettingsFromRegistry();

            imageBandR.Visible = true;
            imageBandRwait.Visible = false;

            lblNoErrorFound.Visible = lblErrorFound.Visible = false;
        }



        /// <summary>
        /// </summary>
        private void btnSwapSourceDest_Click(object sender, EventArgs e)
        {
            var source = tbSourceList.Text;
            var dest = tbDestList.Text;

            tbSourceList.Text = dest;
            tbDestList.Text = source;
        }




        /// <summary>
        /// </summary>
        private ICredentials BuildCreds()
        {
            var userName = tbUsername.Text.Trim();
            var passWord = tbPassword.Text.Trim();
            var domain = tbDomain.Text.Trim();

            if (!cbIsSPOnline.Checked)
            {
                return new NetworkCredential(userName, passWord, domain);
            }
            else
            {
                return new SharePointOnlineCredentials(userName, GenUtil.BuildSecureString(passWord));
            }
        }

        /// <summary>
        /// </summary>
        private void ctx_ExecutingWebRequest_FixForMixedMode(object sender, WebRequestEventArgs e)
        {
            // to support mixed mode auth
            e.WebRequestExecutor.RequestHeaders.Add("X-FORMS_BASED_AUTH_ACCEPTED", "f");
        }

        /// <summary>
        /// </summary>
        private void FixCtxForMixedMode(ClientContext ctx)
        {
            if (!cbIsSPOnline.Checked)
            {
                ctx.ExecutingWebRequest += new EventHandler<WebRequestEventArgs>(ctx_ExecutingWebRequest_FixForMixedMode);
            }
        }




        /// <summary>
        /// </summary>
        private void LoadSettingsFromRegistry()
        {
            var msg = "";
            var json = "";

            if (RegistryHelper.GetRegStuff(out json, out msg) && !json.IsNull())
            {
                var obj = JsonExtensionMethod.FromJson<CustomRegistrySettings>(json);

                tbSiteUrl.Text = obj.siteUrl;
                tbUsername.Text = obj.userName;
                tbPassword.Text = obj.passWord;
                tbDomain.Text = obj.domain;
                cbIsSPOnline.Checked = GenUtil.SafeToBool(obj.isSPOnline);
                tbSourceList.Text = obj.sourceListName;
                tbDestList.Text = obj.destListName;
                tbItemsToProcess.Text = GenUtil.SafeToInt(obj.numItemsToProcess).ToString();
            }
        }

        /// <summary>
        /// </summary>
        private void SaveSettingsToRegistry()
        {
            var msg = "";

            var obj = new CustomRegistrySettings
            {
                siteUrl = tbSiteUrl.Text.Trim(),
                userName = tbUsername.Text.Trim(),
                passWord = tbPassword.Text.Trim(),
                domain = tbDomain.Text.Trim(),
                isSPOnline = cbIsSPOnline.Checked ? "1" : "0",
                sourceListName = tbSourceList.Text.Trim(),
                destListName = tbDestList.Text.Trim(),
                numItemsToProcess = tbItemsToProcess.Text.Trim()
            };
            var json = JsonExtensionMethod.ToJson(obj);

            RegistryHelper.SaveRegStuff(json, out msg);
        }





        /// <summary>
        /// </summary>
        private List<int> ConvertToListOfInts(string s)
        {
            var lst = new List<int>();

            if (!s.IsNull())
            {
                lst = GenUtil.NormalizeEol(s)
                    .Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => Convert.ToInt32(x))
                    .Distinct().ToList();
            }

            return lst;
        }

        /// <summary>
        /// </summary>
        private List<string> ConvertToListOfStrings(string s)
        {
            var lst = new List<string>();

            if (!s.IsNull())
            {
                lst = GenUtil.NormalizeEol(s)
                    .Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                    .Distinct().ToList();
            }

            return lst;
        }





        /// <summary>
        /// </summary>
        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (aboutForm != null)
            {
                aboutForm.Dispose();
            }

            SaveSettingsToRegistry();
        }

        /// <summary>
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (aboutForm == null)
            {
                aboutForm = new AboutForm();
            }

            aboutForm.Show();
            aboutForm.Focus();
        }

        /// <summary>
        /// </summary>
        private void DisableFormControls()
        {
            toolStripStatusLabel1.Text = "Running...";

            imageBandR.Visible = false;
            imageBandRwait.Visible = true;

            btnTestConnection.Enabled = false;

            lnkClear.Enabled = false;
            lnkExport.Enabled = false;
        }

        /// <summary>
        /// </summary>
        private void EnableFormControls()
        {
            toolStripStatusLabel1.Text = "";

            imageBandR.Visible = true;
            imageBandRwait.Visible = false;

            btnTestConnection.Enabled = true;

            lnkClear.Enabled = true;
            lnkExport.Enabled = true;

            btnAbort.Enabled = true;
        }





        /// <summary>
        /// Combine function params as strings with separator, no line breaks.
        /// </summary>
        public string CombineFnParmsToString(params object[] objs)
        {
            string output = "";
            string delim = ": ";

            for (int i = 0; i < objs.Length; i++)
            {
                if (objs[i] == null) objs[i] = "";
                if (i == objs.Length - 1) delim = "";
                output += string.Concat(objs[i], delim);
            }

            return output;
        }

        /// <summary>
        /// Build message for status window, prepend datetime, append message (already combined with separator), append newline chars.
        /// </summary>
        public string BuildCoutMessage(string msg)
        {
            return string.Format("{0}: {1}\r\n", DateTime.Now.ToLongTimeString(), msg);
        }

        /// <summary>
        /// Standard status dumping function, immediately dumps to status window.
        /// </summary>
        public void cout(params object[] objs)
        {
            tbStatus.AppendText(BuildCoutMessage(CombineFnParmsToString(objs)));
        }

        string tcout_buffer;
        int tcout_counter;

        /// <summary>
        /// Threaded status dumping function, uses buffer to only dump to status window peridocially, batch size configured in app.config.
        /// </summary>
        public void tcout(params object[] objs)
        {
            tcout_counter++;
            tcout_buffer += BuildCoutMessage(CombineFnParmsToString(objs));

            var batchSize = statusWindowOutputBatchSize == 0 ? 1 : statusWindowOutputBatchSize;

            if (tcout_counter % batchSize == 0)
            {
                bgw.ReportProgress(0, tcout_buffer);
                InitCoutBuffer();
            }
        }

        /// <summary>
        /// Reset status buffer.
        /// </summary>
        private void InitCoutBuffer()
        {
            tcout_counter = 0;
            tcout_buffer = "";
        }

        /// <summary>
        /// Flush status buffer to status window (since using mod operator).
        /// </summary>
        private void FlushCoutBuffer()
        {
            if (!tcout_buffer.IsNull())
            {
                tbStatus.AppendText(tcout_buffer);
                InitCoutBuffer();
            }
        }

        /// <summary>
        /// Threaded callback function, dump input to status window, already formatted with datetime, combined params, and linebreaks.
        /// </summary>
        private void BgwReportProgress(object sender, ProgressChangedEventArgs e)
        {
            tbStatus.AppendText(e.UserState.ToString());
        }





        /// <summary>
        /// </summary>
        private void lnkClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbStatus.ResetText();
        }

        /// <summary>
        /// </summary>
        private void lnkExport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SaveLogToFile(null);
            MessageBox.Show("Log saved to EXE folder.");
        }

        /// <summary>
        /// </summary>
        void SaveLogToFile(string action)
        {
            if (!action.IsNull())
            {
                action = action.Trim().ToUpper() + "_";
            }

            var exportFilePath = AppDomain.CurrentDomain.BaseDirectory;
            if (!Directory.Exists(exportFilePath.CombineFS("data")))
                Directory.CreateDirectory(exportFilePath.CombineFS("data"));
            exportFilePath = exportFilePath.CombineFS("data\\log" + "_" + action.SafeTrim() + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".txt");

            System.IO.File.WriteAllText(exportFilePath, tbStatus.Text + "\r\n[EOF]");

            cout("Log saved to EXE folder.");
        }





        /// <summary>
        /// </summary>
        private string GetExcMsg(Exception ex)
        {
            if (showFullErrMsgs)
                return ex.ToString();
            else
                return ex.Message;
        }





        /// <summary>
        /// </summary>
        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            DisableFormControls();
            InitCoutBuffer();
            tbStatus.Text = "";
            lblNoErrorFound.Visible = lblErrorFound.Visible = ErrorOccurred = false;

            bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(bgw_TestConnection);
            bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_TestConnection_End);
            bgw.ProgressChanged += new ProgressChangedEventHandler(BgwReportProgress);
            bgw.WorkerReportsProgress = true;
            bgw.WorkerSupportsCancellation = true;
            bgw.RunWorkerAsync();
        }

        /// <summary>
        /// </summary>
        private void bgw_TestConnection(object sender, DoWorkEventArgs e)
        {
            try
            {
                var targetSite = new Uri(tbSiteUrl.Text.Trim());

                using (ClientContext ctx = new ClientContext(targetSite))
                {
                    ctx.Credentials = BuildCreds();
                    FixCtxForMixedMode(ctx);

                    Web web = ctx.Web;
                    ctx.Load(web, w => w.Title);
                    ctx.ExecuteQuery();
                    tcout("Site loaded", web.Title);
                }
            }
            catch (Exception ex)
            {
                tcout(" *** ERROR", GetExcMsg(ex));
                ErrorOccurred = true;
            }
        }

        /// <summary>
        /// </summary>
        private void bgw_TestConnection_End(object sender, RunWorkerCompletedEventArgs e)
        {
            FlushCoutBuffer();
            lblErrorFound.Visible = ErrorOccurred; lblNoErrorFound.Visible = !ErrorOccurred;
            EnableFormControls();
        }





        /// <summary>
        /// </summary>
        private void btnStartMain_Click(object sender, EventArgs e)
        {
            DisableFormControls();
            InitCoutBuffer();
            tbStatus.Text = "";
            lblNoErrorFound.Visible = lblErrorFound.Visible = ErrorOccurred = false;

            selAction = ddlActions.SelectedItem == null ? "" : ddlActions.SelectedItem.ToString();

            bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(bgw_StartMain);
            bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_StartMain_End);
            bgw.ProgressChanged += new ProgressChangedEventHandler(BgwReportProgress);
            bgw.WorkerReportsProgress = true;
            bgw.WorkerSupportsCancellation = true;
            bgw.RunWorkerAsync();
        }

        /// <summary>
        /// </summary>
        private void bgw_StartMain(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bwAsync = sender as BackgroundWorker;

            var rowLimit = Convert.ToInt32(ConfigurationManager.AppSettings["rowLimit"]);
            var numItemsToProc = GenUtil.SafeToInt(tbItemsToProcess.Text);

            // update rowlimit if # of items to process is less, no reason to get more items than needed
            if (numItemsToProc < rowLimit) rowLimit = numItemsToProc;

            var siteUrl = tbSiteUrl.Text.Trim();
            var sourceListName = tbSourceList.Text.Trim();
            var destListName = tbDestList.Text.Trim();
            var simulate = cbSimulate.Checked;
            var overwrite = cbMoveCopyOverwrite.Checked;

            var fileIdsInclusive = ConvertToListOfInts(tbItemIDsInclude.Text.Trim());
            var fileIdsExclusive = ConvertToListOfInts(tbItemIDsExclude.Text.Trim());

            var folderUrlIncl = tbFilterServerRelPathInc.Text.Trim().TrimEnd("/".ToCharArray());
            var folderUrlExcl = tbFilterServerRelPathExc.Text.Trim().TrimEnd("/".ToCharArray());

            tcout("Site URL", siteUrl);
            tcout("Username", tbUsername.Text.Trim());
            tcout("Action", selAction);
            tcout("Source List Name", sourceListName);
            if (!selAction.IsEqual("Delete Files"))
                tcout("Destination List Name", destListName);
            if (!selAction.IsEqual("Delete Files"))
                tcout("Overwrite", overwrite);
            tcout("Number of items to process", numItemsToProc);
            tcout("Query row limit batch size", rowLimit);
            tcout("Simulate", simulate.ToString().ToUpper());
            tcout("Filter Item IDs Inclusive", fileIdsInclusive.Any() ? "Yes" : "No");
            tcout("Filter Item IDs Exclusive", fileIdsExclusive.Any() ? "Yes" : "No");
            tcout("Server Relative Folder Path (Include)", folderUrlIncl);
            tcout("Server Relative Folder Path (Exclude)", folderUrlExcl);

            if (siteUrl.IsNull())
            {
                tcout("Site URL required.");
                return;
            }
            else if (sourceListName.IsNull())
            {
                tcout("Source List Name required.");
                return;
            }
            else if (!selAction.IsEqual("Delete Files") && destListName.IsNull())
            {
                tcout("Destination List Name required.");
                return;
            }
            else if (selAction.IsNull())
            {
                tcout("Action is required.");
                return;
            }

            try
            {
                var targetSite = new Uri(siteUrl);

                using (ClientContext ctx = new ClientContext(targetSite))
                {
                    ctx.Credentials = BuildCreds();
                    FixCtxForMixedMode(ctx);

                    Web web = ctx.Web;
                    ctx.Load(web, w => w.Title);
                    ctx.ExecuteQuery();
                    tcout("Site loaded", web.Title);

                    if (selAction.IsEqual("Move Files") || selAction.IsEqual("Copy Files"))
                    {
                        CopyMoveFiles(bwAsync, rowLimit, numItemsToProc, sourceListName, destListName, simulate, overwrite, fileIdsInclusive, fileIdsExclusive, folderUrlIncl, folderUrlExcl, ctx);
                    }
                    else if (selAction.IsEqual("Delete Files"))
                    {
                        DeleteFiles(bwAsync, rowLimit, numItemsToProc, sourceListName, destListName, simulate, overwrite, fileIdsInclusive, fileIdsExclusive, folderUrlIncl, folderUrlExcl, ctx);
                    }
                    else
                    {
                        tcout("Invalid Action Selected.");
                    }
                }
            }
            catch (Exception ex)
            {
                tcout(" *** ERROR", GetExcMsg(ex));
                ErrorOccurred = true;
            }
        }

        /// <summary>
        /// </summary>
        private void DeleteFiles(BackgroundWorker bwAsync, int rowLimit, int numItemsToProc, string sourceListName, string destListName, bool simulate, bool overwrite, List<int> fileIdsInclusive, List<int> fileIdsExclusive, string folderUrlIncl, string folderUrlExcl, ClientContext ctx)
        {
            int i = 0;

            // list source
            tcout("Loading Source List...");

            var list = ctx.Web.Lists.GetByTitle(sourceListName);

            var listRootFolder = list.RootFolder;
            ctx.Load(list, x => x.RootFolder, x => x.ItemCount);
            ctx.ExecuteQuery();

            var listServerRelUrl = listRootFolder.ServerRelativeUrl;
            ctx.Load(listRootFolder, y => y.ServerRelativeUrl);
            ctx.ExecuteQuery();

            listServerRelUrl = GenUtil.EnsureStartsWithForwardSlash(listServerRelUrl).TrimEnd("/".ToCharArray());

            tcout("Source List found", listServerRelUrl, "Item Count", list.ItemCount);

            // begin search
            tcout("Begin finding folders/files...");
            ListItemCollectionPosition pos = null;

            var lstFileObjs = new List<CustFileObj>();

            while (true)
            {
                tcout(string.Format("Execute paged query, pagesize={0}", rowLimit));
                CamlQuery cq = new CamlQuery();

                cq.ListItemCollectionPosition = pos;

                // get items in root of library only, delete folders individually, delete files individually
                cq.ViewXml = string.Format("<View Scope=\"RecursiveAll\"><ViewFields><FieldRef Name=\"ID\" /><FieldRef Name=\"FileLeafRef\" /><FieldRef Name=\"FileDirRef\" /><FieldRef Name=\"FileRef\" /></ViewFields><RowLimit>{0}</RowLimit></View>", rowLimit);

                ListItemCollection lic = list.GetItems(cq);

                ctx.Load(lic,
                    itms => itms.ListItemCollectionPosition,
                    itms => itms.Include(
                        itm => itm["ID"],
                        itm => itm["FileLeafRef"],
                        itm => itm["FileDirRef"],
                        itm => itm["FileRef"],
                        itm => itm.FileSystemObjectType));

                ctx.ExecuteQuery();

                pos = lic.ListItemCollectionPosition;

                foreach (ListItem l in lic)
                {
                    i++;

                    var fileId = Convert.ToInt32(l["ID"]);
                    var fileName = l["FileLeafRef"].SafeTrim();
                    var folderPath = GenUtil.EnsureStartsWithForwardSlash(GenUtil.SafeTrimLookupFieldValue(l["FileDirRef"])).TrimEnd("/".ToCharArray());
                    var fullPath = GenUtil.EnsureStartsWithForwardSlash(GenUtil.SafeTrimLookupFieldValue(l["FileRef"]));
                    var fso = l.FileSystemObjectType;

                    if (fileIdsInclusive.Any() && !fileIdsInclusive.Contains(fileId))
                    {
                        tcout(fileId, fullPath, "Skipping file, Id not found in inclusive list.");
                        continue;
                    }
                    else if (fileIdsExclusive.Any() && fileIdsExclusive.Contains(fileId))
                    {
                        tcout(fileId, fullPath, "Skipping file, Id found in exclusive list.");
                        continue;
                    }

                    if (fso.ToString().IsEqual("FILE"))
                    {
                        if (!folderUrlIncl.IsNull())
                        {
                            if (!folderPath.StartsWith(folderUrlIncl, StringComparison.CurrentCultureIgnoreCase))
                            {
                                tcout(fileId, fullPath, string.Format("Skipping {0}, not in folder path", fso.ToString()));
                                continue;
                            }
                        }
                        else if (!folderUrlExcl.IsNull())
                        {
                            if (folderPath.StartsWith(folderUrlExcl, StringComparison.CurrentCultureIgnoreCase))
                            {
                                tcout(fileId, fullPath, string.Format("Skipping {0}, excluded folder path", fso.ToString()));
                                continue;
                            }
                        }
                    }
                    else if (fso.ToString().IsEqual("FOLDER"))
                    {
                        if (!folderUrlIncl.IsNull())
                        {
                            if (!fullPath.StartsWith(folderUrlIncl, StringComparison.CurrentCultureIgnoreCase))
                            {
                                tcout(fileId, fullPath, string.Format("Skipping {0}, not in folder path", fso.ToString()));
                                continue;
                            }
                        }
                        else if (!folderUrlExcl.IsNull())
                        {
                            if (fullPath.StartsWith(folderUrlExcl, StringComparison.CurrentCultureIgnoreCase))
                            {
                                tcout(fileId, fullPath, string.Format("Skipping {0}, excluded folder path", fso.ToString()));
                                continue;
                            }
                        }
                    }

                    lstFileObjs.Add(new CustFileObj
                    {
                        fileId = fileId,
                        fileName = fileName,
                        folderPath = folderPath,
                        fullPath = fullPath,
                        relFolderPath = folderPath.Replace(listServerRelUrl, "").Trim("/".ToCharArray()),
                        relFullPath = fullPath.Replace(listServerRelUrl, "").Trim("/".ToCharArray()),
                        fileType = fso.ToString()
                    });

                    if (bwAsync.CancellationPending)
                    {
                        tcout("Operation Aborted!");
                        return;
                    }

                    if (numItemsToProc > 0 && i >= numItemsToProc)
                    {
                        tcout("Search aborted, reached number of items found limit.");
                        break;
                    }
                }

                if (pos == null || (numItemsToProc > 0 && i >= numItemsToProc))
                    break;
                else
                    tcout(string.Format("Objects found: {0}/{1}", lstFileObjs.Count, list.ItemCount));
            }

            var folderCount = lstFileObjs.Where(x => x.fileType == "Folder").Count();
            var fileCount = lstFileObjs.Where(x => x.fileType == "File").Count();

            tcout("Finished finding folders/files.");

            tcout("Total item count", lstFileObjs.Count);
            tcout("Folder count", folderCount);
            tcout("File count", fileCount);

            if (lstFileObjs.Count == 0)
            {
                tcout("No files/folders found, quitting.");
            }
            else
            {
                // delete files first, any order (everywhere)
                if (fileCount > 0)
                {
                    tcout(string.Format("Begin deleting files..."));
                    i = 0;

                    foreach (var curFile in lstFileObjs.Where(x => x.fileType == "File"))
                    {
                        i++;
                        var file = ctx.Web.GetFileByServerRelativeUrl(curFile.fullPath);

                        try
                        {
                            if (!simulate)
                            {
                                file.DeleteObject();
                                ctx.ExecuteQuery();
                            }
                            tcout(string.Format("{0}/{1}", i, fileCount), "file deleted", curFile.fullPath);
                        }
                        catch (Exception ex)
                        {
                            tcout(string.Format("{0}/{1}", i, fileCount), "*** ERROR deleting file", curFile.fullPath, ex.Message);
                        }

                        if (bwAsync.CancellationPending)
                        {
                            tcout("Operation Aborted!");
                            return;
                        }
                    }

                    tcout(string.Format("Finished deleting files."));
                }

                // delete folders, starting at lowest level, moving up (everywhere)
                if (folderCount > 0)
                {
                    tcout(string.Format("Begin deleting folders..."));
                    i = 0;

                    foreach (var curFolder in lstFileObjs.Where(x => x.fileType == "Folder").OrderByDescending(x => x.GetLevel()))
                    {
                        i++;
                        var folder = ctx.Web.GetFolderByServerRelativeUrl(curFolder.fullPath);

                        var skipDelete = false;

                        var localFolders = folder.Folders;
                        var localFiles = folder.Files;
                        ctx.Load(localFolders, f1 => f1.Include(f2 => f2.Name));
                        ctx.Load(localFiles, f1 => f1.Include(f2 => f2.Name));
                        ctx.ExecuteQuery();

                        var localFolderCount = localFolders.Count();
                        var localFileCount = localFiles.Count();

                        if (localFolderCount + localFileCount > 0)
                        {
                            skipDelete = true;
                            cout(string.Format("{0}/{1}", i, folderCount), "skipping delete, folder not empty", curFolder.fullPath, "foldercount", localFolderCount, "filecount", localFileCount);
                        }

                        if (!skipDelete)
                        {
                            try
                            {
                                if (!simulate)
                                {
                                    folder.DeleteObject();
                                    ctx.ExecuteQuery();
                                }
                                tcout(string.Format("{0}/{1}", i, folderCount), "folder deleted", curFolder.fullPath);
                            }
                            catch (Exception ex)
                            {
                                tcout(string.Format("{0}/{1}", i, folderCount), "*** ERROR deleting folder", curFolder.fullPath, ex.Message);
                            }
                        }

                        if (bwAsync.CancellationPending)
                        {
                            tcout("Operation Aborted!");
                            return;
                        }
                    }

                    tcout(string.Format("Finished deleting folders."));
                }
            }
        }

        /// <summary>
        /// </summary>
        private void CopyMoveFiles(BackgroundWorker bwAsync, int rowLimit, int numItemsToProc, string sourceListName, string destListName, bool simulate, bool overwrite, List<int> fileIdsInclusive, List<int> fileIdsExclusive, string folderUrlIncl, string folderUrlExcl, ClientContext ctx)
        {
            int i = 0;
            var isMove = selAction.IsEqual("Move Files");

            // list source
            tcout("Loading Source List...");
            var listSource = ctx.Web.Lists.GetByTitle(sourceListName);

            var listRootFolderSource = listSource.RootFolder;
            ctx.Load(listSource, x => x.RootFolder, x => x.ItemCount);
            ctx.ExecuteQuery();

            var listServerRelUrlSource = listRootFolderSource.ServerRelativeUrl;
            ctx.Load(listRootFolderSource, y => y.ServerRelativeUrl);
            ctx.ExecuteQuery();

            listServerRelUrlSource = GenUtil.EnsureStartsWithForwardSlash(listServerRelUrlSource).TrimEnd("/".ToCharArray());

            tcout("Source List found", listServerRelUrlSource, "Item Count", listSource.ItemCount);

            // list destination
            tcout("Loading Destination List...");
            var listDest = ctx.Web.Lists.GetByTitle(destListName);

            var listRootFolderDest = listDest.RootFolder;
            ctx.Load(listDest, x => x.RootFolder, x => x.ItemCount);
            ctx.ExecuteQuery();

            var listServerRelUrlDest = listRootFolderDest.ServerRelativeUrl;
            ctx.Load(listRootFolderDest, y => y.ServerRelativeUrl);
            ctx.ExecuteQuery();

            listServerRelUrlDest = GenUtil.EnsureStartsWithForwardSlash(listServerRelUrlDest).TrimEnd("/".ToCharArray());

            tcout("Destination List found", listServerRelUrlDest, "Item Count", listDest.ItemCount);

            // begin search
            tcout("Begin finding folders/files...");
            ListItemCollectionPosition pos = null;

            var lstFileObjs = new List<CustFileObj>();

            while (true)
            {
                tcout(string.Format("Execute paged query, pagesize={0}", rowLimit));
                CamlQuery cq = new CamlQuery();

                cq.ListItemCollectionPosition = pos;
                cq.ViewXml = string.Format("<View Scope=\"RecursiveAll\"><ViewFields><FieldRef Name=\"ID\" /><FieldRef Name=\"FileLeafRef\" /><FieldRef Name=\"FileDirRef\" /><FieldRef Name=\"FileRef\" /></ViewFields><RowLimit>{0}</RowLimit></View>", rowLimit);

                ListItemCollection lic = listSource.GetItems(cq);

                ctx.Load(lic,
                    itms => itms.ListItemCollectionPosition,
                    itms => itms.Include(
                        itm => itm["ID"],
                        itm => itm["FileLeafRef"],
                        itm => itm["FileDirRef"],
                        itm => itm["FileRef"],
                        itm => itm.FileSystemObjectType));

                ctx.ExecuteQuery();

                pos = lic.ListItemCollectionPosition;

                foreach (ListItem l in lic)
                {
                    i++;

                    var fileId = Convert.ToInt32(l["ID"]);
                    var fileName = l["FileLeafRef"].SafeTrim();
                    var folderPath = GenUtil.EnsureStartsWithForwardSlash(GenUtil.SafeTrimLookupFieldValue(l["FileDirRef"])).TrimEnd("/".ToCharArray());
                    var fullPath = GenUtil.EnsureStartsWithForwardSlash(GenUtil.SafeTrimLookupFieldValue(l["FileRef"]));
                    var fso = l.FileSystemObjectType;

                    if (fileIdsInclusive.Any() && !fileIdsInclusive.Contains(fileId))
                    {
                        tcout(fileId, fullPath, "Skipping file, Id not found in inclusive list.");
                        continue;
                    }
                    else if (fileIdsExclusive.Any() && fileIdsExclusive.Contains(fileId))
                    {
                        tcout(fileId, fullPath, "Skipping file, Id found in exclusive list.");
                        continue;
                    }

                    if (fso.ToString().IsEqual("FILE"))
                    {
                        if (!folderUrlIncl.IsNull())
                        {
                            if (!folderPath.StartsWith(folderUrlIncl, StringComparison.CurrentCultureIgnoreCase))
                            {
                                tcout(fileId, fullPath, string.Format("Skipping {0}, not in folder path", fso.ToString()));
                                continue;
                            }
                        }
                        else if (!folderUrlExcl.IsNull())
                        {
                            if (folderPath.StartsWith(folderUrlExcl, StringComparison.CurrentCultureIgnoreCase))
                            {
                                tcout(fileId, fullPath, string.Format("Skipping {0}, excluded folder path", fso.ToString()));
                                continue;
                            }
                        }
                    }
                    else if (fso.ToString().IsEqual("FOLDER"))
                    {
                        if (!folderUrlIncl.IsNull())
                        {
                            if (!fullPath.StartsWith(folderUrlIncl, StringComparison.CurrentCultureIgnoreCase))
                            {
                                tcout(fileId, fullPath, string.Format("Skipping {0}, not in folder path", fso.ToString()));
                                continue;
                            }
                        }
                        else if (!folderUrlExcl.IsNull())
                        {
                            if (fullPath.StartsWith(folderUrlExcl, StringComparison.CurrentCultureIgnoreCase))
                            {
                                tcout(fileId, fullPath, string.Format("Skipping {0}, excluded folder path", fso.ToString()));
                                continue;
                            }
                        }
                    }

                    lstFileObjs.Add(new CustFileObj
                    {
                        fileId = fileId,
                        fileName = fileName,
                        folderPath = folderPath,
                        fullPath = fullPath,
                        relFolderPath = folderPath.Replace(listServerRelUrlSource, "").Trim("/".ToCharArray()),
                        relFullPath = fullPath.Replace(listServerRelUrlSource, "").Trim("/".ToCharArray()),
                        fileType = fso.ToString()
                    });

                    if (bwAsync.CancellationPending)
                    {
                        tcout("Operation Aborted!");
                        return;
                    }

                    if (numItemsToProc > 0 && i >= numItemsToProc)
                    {
                        tcout("Search aborted, reached number of items found limit.");
                        break;
                    }
                }

                if (pos == null || (numItemsToProc > 0 && i >= numItemsToProc))
                    break;
                else
                    tcout(string.Format("Objects found: {0}/{1}", lstFileObjs.Count, listSource.ItemCount));
            }

            var folderCount = lstFileObjs.Where(x => x.fileType == "Folder").Count();
            var fileCount = lstFileObjs.Where(x => x.fileType == "File").Count();

            tcout("Finished finding folders/files.");

            tcout("Total item count", lstFileObjs.Count);
            tcout("Folder count", folderCount);
            tcout("File count", fileCount);

            if (lstFileObjs.Count == 0)
            {
                tcout("No files/folders found, quitting.");
            }
            else
            {
                // create folders in destination
                if (folderCount > 0)
                {
                    tcout("Begin creating folders in destination...");

                    if (simulate)
                    {
                        tcout("Simulation, skipping.");
                    }
                    else
                    {
                        i = 0;

                        foreach (var curFolder in lstFileObjs.Where(x => x.fileType == "Folder").Distinct().OrderBy(x => x.GetLevel()))
                        {
                            i++;

                            var newFolderUrl = curFolder.fullPath.Replace(listServerRelUrlSource, listServerRelUrlDest);
                            var newParentFolderUrl = newFolderUrl.Substring(0, newFolderUrl.LastIndexOf('/'));
                            var newFolderName = newFolderUrl.Substring(newFolderUrl.LastIndexOf('/') + 1);

                            tcout(string.Format("{0}/{1}", i, folderCount), "Checking Folder", newFolderUrl);

                            try
                            {
                                var newFolder = ctx.Web.GetFolderByServerRelativeUrl(newFolderUrl);
                                ctx.Load(newFolder, f => f.Name);
                                ctx.ExecuteQuery();

                                tcout(" -- Folder Exists");

                            }
                            catch (Exception ex)
                            {
                                if (ex.Message.Contains("File Not Found"))
                                {
                                    tcout(" -- Folder Not Found");

                                    try
                                    {
                                        var folder = ctx.Web.GetFolderByServerRelativeUrl(newParentFolderUrl);
                                        var newFolder = folder.Folders.Add(newFolderName);
                                        ctx.ExecuteQuery();
                                        tcout(" -- Folder Created!");

                                    }
                                    catch (Exception ex2)
                                    {
                                        tcout("*** ERROR creating new folder", GetExcMsg(ex2));
                                    }

                                }
                                else
                                {
                                    tcout("*** ERROR checking if folder exists", GetExcMsg(ex));
                                }
                            }

                            if (bwAsync.CancellationPending)
                            {
                                tcout("Operation Aborted!");
                                return;
                            }
                        }
                    }

                    tcout("Finished creating folders in destination.");
                }

                // move/copy files to destination
                if (fileCount > 0)
                {
                    tcout(string.Format("Begin {0} files to destination...", isMove ? "move" : "copy"));
                    i = 0;

                    foreach (var curFile in lstFileObjs.Where(x => x.fileType == "File"))
                    {
                        i++;

                        var oldFileServerRelUrl = curFile.fullPath;
                        var newFileServerRelUrl = curFile.fullPath.Replace(listServerRelUrlSource, listServerRelUrlDest);

                        tcout(string.Format("{0}/{1}", i, fileCount), isMove ? "Move" : "Copy" + " File", oldFileServerRelUrl);

                        if (!overwrite)
                        {
                            try
                            {
                                // before action check if file exists at destination
                                var newFile = ctx.Web.GetFileByServerRelativeUrl(newFileServerRelUrl);
                                ctx.Load(newFile, f => f.Exists);
                                ctx.ExecuteQuery();

                                if (newFile.Exists)
                                {
                                    tcout(" -- File already exists, skipped.");
                                }
                                else
                                {
                                    try
                                    {
                                        var sw = new System.Diagnostics.Stopwatch();
                                        sw.Start();

                                        if (!simulate)
                                        {
                                            var oldFile = ctx.Web.GetFileByServerRelativeUrl(oldFileServerRelUrl);

                                            if (isMove)
                                            {
                                                oldFile.MoveTo(newFileServerRelUrl, MoveOperations.None);
                                            }
                                            else
                                            {
                                                oldFile.CopyTo(newFileServerRelUrl, false);
                                            }

                                            ctx.ExecuteQuery();
                                        }

                                        sw.Stop();

                                        tcout(" -- File " + (isMove ? "moved" : "copied") + "!" + string.Format(" ({0}s)", sw.Elapsed.TotalSeconds.ToString("##0.0##")));
                                    }
                                    catch (Exception ex)
                                    {
                                        tcout(" *** ERROR " + (isMove ? "moving" : "copying") + " file to destination", GetExcMsg(ex));
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                tcout(" *** ERROR checking if file exists in destination", GetExcMsg(ex));
                            }
                        }
                        else
                        {
                            // always copy/move file, overwrite on
                            try
                            {
                                var sw = new System.Diagnostics.Stopwatch();
                                sw.Start();

                                if (!simulate)
                                {
                                    var oldFile = ctx.Web.GetFileByServerRelativeUrl(oldFileServerRelUrl);

                                    if (isMove)
                                    {
                                        oldFile.MoveTo(newFileServerRelUrl, MoveOperations.Overwrite);
                                    }
                                    else
                                    {
                                        oldFile.CopyTo(newFileServerRelUrl, true);
                                    }

                                    ctx.ExecuteQuery();
                                }

                                sw.Stop();

                                tcout(" -- File " + (isMove ? "moved" : "copied") + "!" + string.Format(" ({0}s)", sw.Elapsed.TotalSeconds.ToString("##0.0##")));
                            }
                            catch (Exception ex)
                            {
                                tcout(" *** ERROR " + (isMove ? "moving" : "copying") + " file to destination", GetExcMsg(ex));
                            }
                        }

                        if (bwAsync.CancellationPending)
                        {
                            tcout("Operation Aborted!");
                            return;
                        }
                    }

                    tcout(string.Format("Finished {0} files to destination.", isMove ? "move" : "copy"));
                }
            }
        }

        /// <summary>
        /// </summary>
        private void bgw_StartMain_End(object sender, RunWorkerCompletedEventArgs e)
        {
            FlushCoutBuffer();
            lblErrorFound.Visible = ErrorOccurred; lblNoErrorFound.Visible = !ErrorOccurred;

            SaveLogToFile(selAction.ToUpper());

            EnableFormControls();
        }

        /// <summary>
        /// </summary>
        private void ddlActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            selAction = ddlActions.SelectedItem == null ? "" : ddlActions.SelectedItem.ToString();

            if (selAction.IsEqual("Delete Files"))
            {
                cbMoveCopyOverwrite.Visible = false;
                tbDestList.Enabled = false;
                //tbItemIDsInclude.Enabled = false;
                //tbItemIDsExclude.Enabled = false;
            }
            else
            {
                cbMoveCopyOverwrite.Visible = true;
                tbDestList.Enabled = true;
                //tbItemIDsInclude.Enabled = true;
                //tbItemIDsExclude.Enabled = true;
            }
        }

        private void tbItemsToProcess_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter number of items to process, 0 to process all.";
        }

        private void tbItemsToProcess_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void tbItemIDsInclude_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter listitem IDs, one per line, to include. All other items will be skipped. Entering IDs here overrides the Exclude box below.";
        }

        private void tbItemIDsInclude_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void tbItemIDsExclude_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Enter listitem IDs, one per line, to exclude. These items will be skipped, all others will be processed.";
        }

        private void tbItemIDsExclude_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }

        private void cbMoveCopyOverwrite_MouseEnter(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "NOTE: When overwrite is unchecked an additional query is executed to check if file exists in destination.";
        }

        private void cbMoveCopyOverwrite_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
        }







        private void btnAbort_Click(object sender, EventArgs e)
        {
            if (bgw != null && bgw.IsBusy && !bgw.CancellationPending)
            {
                bgw.CancelAsync();
                btnAbort.Enabled = false;
            }
        }





        private void imageBandR_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.bandrsolutions.com/?utm_source=SP5000ItemLimitThresholdHelper&utm_medium=application&utm_campaign=SP5000ItemLimitThresholdHelper");
        }



    }
}
