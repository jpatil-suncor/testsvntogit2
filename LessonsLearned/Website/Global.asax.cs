using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using Website;
//using Backend.Reference;
using Backend;


namespace Website
{
    /// <summary>
    /// Summary description for Global.
    /// </summary>
    public class Global : System.Web.HttpApplication
    {
        public Global()
        {
            InitializeComponent();

            // Enable Error Reporting
            //WebErrorNotifier notifier = new WebErrorNotifier(true);
            //Error += new EventHandler(notifier.ErrorHandler);
        }


        public const string DefaultPage = "Default.aspx";
        public const string ProcessingPage = "ProcessingPage.aspx";
        public const string ProcessingBulkSearch = "ProcessingBulkSearch.aspx";
        //Frame pages
        public const string StartPage = "BLANK.aspx";
        public const string NavigationMenuPage = "Navigation Banner.aspx";
        public const string ApplicationTitlePage = "LOC Main Banner.htm";
        public const string InvalidPermissionPage = "InvalidPermission.aspx";

        //Security Pages.
        public const string SecurityGroupPage   = "SecurityGroup.aspx";
        public const string UserAccountAddPage  = "UserAccountAdd.aspx";
        public const string UserAccountPage     = "UserAccounts.aspx";
        public const string UserLoggedOutPage   = "UserLoggedOut.aspx";
        public const string UserLoginPage       = "UserLogin.aspx";
        public const string SessionExpiredPage  = "SessionExpired.htm";

        public struct Parameters
        {
            public const string Message         = "MESSAGE";
            public const string User            = "USERNAME";
            public const string LL_Coordinator  = "LLCOORDINATOR";
            public const string LL_ID           = "LL_ID";
            public const string File3           = "FileUpload3";
            public const string File4           = "FileUpload4";
            public const string tempFile3       = "tempFileUpload3";
            public const string tempFile4       = "tempFileUpload4";
            public const string SubmittedFinal  = "SUBMITTEDFINAL";
            public const string Search          = "Search";
            public const string SearchResults   = "SearchResults";

           
        }

        #region Web Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        }
        #endregion

    }
}