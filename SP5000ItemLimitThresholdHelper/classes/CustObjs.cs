using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BandR
{

    public class ExportObject
    {
        public int fileId { get; set; }
        public string fileName { get; set; }
        public string fieldType { get; set; }
        public string fieldName { get; set; }
        public string fieldValue { get; set; }

        public bool fieldIsMultiVal { get; set; }
    }

    public class CustomRegistrySettings
    {
        public string siteUrl { get; set; }
        public string userName { get; set; }
        public string passWord { get; set; }
        public string domain { get; set; }
        public string isSPOnline { get; set; }

        public string sourceListName { get; set; }
        public string destListName { get; set; }
        public string numItemsToProcess { get;set; }

    }

    public class CustFileObj
    {
        public int fileId { get; set; }

        public string fileName { get; set; }
        public string folderPath { get; set; }
        public string fullPath { get; set; }

        public string relFolderPath { get; set; }
        public string relFullPath { get; set; }

        public string fileType { get; set; }

        public int GetLevel()
        {
            return relFullPath.ToCharArray().Count(x => x == '/');
        }
    }

}
