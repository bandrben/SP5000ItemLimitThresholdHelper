notes:

need info about 5k limit

-features:
	compatible with SharePoint 2010, SharePoint 2013, SharePoint Online (Office 365)
	supported bulk actions are copy, move, or delete
	can copy or move files from library to another library
	both libraries must be in same site
	can set the number of files to copy/move/delete, enter 0 to process all
	initial testing shows that bulk copy of 5000 files (each file 1K size) takes 37 minutes
	delete operation is much faster
	copying/moving files from source to destination library will preserve field info if both lists have same fields
	simulate option to test program before commiting to an action (copy/move/delete)
	form data saved to registry
	copy/move operation supports overwrite and also skipping existing files
	additional inclusive and exclusive filters added, supports entering listitem IDs to include/exclude from action
	inclusive filter overrides exclusive filter, only one filter can be used at a time


using sponline
moving small test files (each file is 877bytes)
copying using copy command, 5000 files, took 37 minutes


  <startup>
    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5" />
  </startup>
  <startup>
    <supportedRuntime version="2.0.50727" sku=".NETFramework,Version=v2.0.50727" />
  </startup>
