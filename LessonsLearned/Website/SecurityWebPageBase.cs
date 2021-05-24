using System;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using PetroCanada.CorpExec.Security;
using Website.EAuthWS;
using Website;

namespace Website
{
    /// <summary>
    /// Base code behind page for the security pages.  Handles basic such
    /// as getting the currently logged in username as well as enforces some
    /// basic security checks and provides common functionality amongst all 
    /// web forms.
    /// </summary>
    public class SecurityWebPageBase : System.Web.UI.Page
    {
        private PetroCanada.CorpExec.Security.Account m_customerSecurity = null;
        private DataView m_dataViewGridSource = null;
        private string m_previousSortExpression;
        private string m_previousDataGridRowCount;

        protected struct LogActions
        {
            public const string Logon = "Logon - Success";
            public const string LogonSuspended = "Logon - Account suspended";
            public const string InvalidLogon = "Logon - Failure";
            public const string Logoff = "Logoff";
            public const string NotAuthorized = "Logon - Not Authorized";
        }

        public SecurityWebPageBase()
        {
            //Add our own event handler for the page load event.
            this.Load += new System.EventHandler(PageLoaded);
            this.Unload += new System.EventHandler(OnUnLoad);
        }

        private void OnUnLoad(object sender, System.EventArgs e)
        {
            //Clear up the security object (so that it's connection gets closed)
            if (UserAccountSecurity != null)
            {
                UserAccountSecurity.Dispose();
            }
        }

        protected void PageLoaded(object sender, EventArgs e)
        {
            //Enforce pages to be non-cached by default.  This may slow
            //performance so where desirable simply re-enable the cache on
            //the appropriate ancestor.  Note cached pages will be cached
            //for a user over a period of time and not the session, and this
            //may affect security settings.
            //Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoServerCaching();
            Response.Cache.SetNoStore();

            EnforceSMARTSecurity();

            m_previousSortExpression = Page.UniqueID + "_PREVSORTEXP";
            m_previousDataGridRowCount = Page.UniqueID + "_PREVROWCOUNT";
        }

        #region Protected Properties
        protected string LoginName
        {
            get
            {
                if (Session[Global.Parameters.User] != null && Session[Global.Parameters.User].ToString() != string.Empty)
                {
                    return Session[Global.Parameters.User].ToString();
                }
                else
                {
                    return "NOT SET " + DateTime.Now.ToString("MM-dd-yyyy");
                }
            }
        }

        protected Website.EAuthWS.EnterpriseAuthenticationWebService AuthenticationWebService
        {
            get
            {
                EnterpriseAuthenticationWebService eaws = new EnterpriseAuthenticationWebService();
                //eaws.Url = System.Configuration.ConfigurationSettings.AppSettings["EAWSURL"];
                eaws.Url = System.Configuration.ConfigurationManager.AppSettings["EAWSURL"];

                return eaws;
            }
        }

        protected PetroCanada.CorpExec.Security.Account UserAccountSecurity
        {
            get
            {
                if (m_customerSecurity == null)
                {
                    m_customerSecurity = new PetroCanada.CorpExec.Security.Account(Backend.DataAccess.DataAccessUtil.ConnectionString);
                }

                return m_customerSecurity;
            }
        }
        #endregion

        /// <summary>
        /// Returns TextBox, DropDownList and DataGrid controls to a "blank"
        /// state.  This is inted to serve as a reset operation on data entry
        /// controls.  Reset HTML buttons don't quite behave in the manner
        /// that one would expect, occasionally they do not clear the contents
        /// of the controls.  This may be a ASP.Net r1 bug. Aug 8, 2002 CJS
        /// </summary>
        /// <param name="ctrl">The control that is the top most
        /// container control, usually a reference to the page.</param>
        protected void ClearAllControls(Control ctrl)
        {
            if (ctrl.Controls.Count > 0)
            {
                //Control has children, so we need to recursivly reset our
                //children as well.			
                foreach (Control childCtrl in ctrl.Controls)
                {
                    ClearAllControls(childCtrl);
                }
            }
            else
            {
                //ctrl is not a container, thus its
                //datatype may be of a type we wish to reset, so
                //determine if we are interested in it.

                //Use a if statement as opposed to a switch statement as 
                //switch on works on integral type or strings.
                if (ctrl.GetType() == typeof(TextBox))
                {
                    ((TextBox)ctrl).Text = string.Empty;
                }
                else if (ctrl.GetType() == typeof(DropDownList))
                {
                    ((DropDownList)ctrl).SelectedIndex = -1;
                }
                else if (ctrl.GetType() == typeof(CheckBox))
                {
                    ((CheckBox)ctrl).Checked = false;
                }
                else if (ctrl.GetType() == typeof(RadioButtonList))
                {
                    ((RadioButtonList)ctrl).SelectedIndex = -1;
                }
                else if (ctrl.GetType() == typeof(DataGrid))
                {
                    ((DataGrid)ctrl).DataSource = null;
                    ((DataGrid)ctrl).DataBind();
                }
            }
        }

        /// <summary>
        /// Disables TextBox, DropDownList and Checkboxes cso they cant be edited.  
        /// Reset HTML buttons don't quite behave in the manner
        /// that one would expect, occasionally they do not clear the contents
        /// of the controls.  This may be a ASP.Net r1 bug. Aug 8, 2002 CJS
        /// </summary>
        /// <param name="ctrl">The control that is the top most
        /// container control, usually a reference to the page.</param>
        protected void DisableAllControls(Control ctrl)
        {
            if (ctrl.Controls.Count > 0)
            {
                //Control has children, so we need to recursivly reset our
                //children as well.			
                foreach (Control childCtrl in ctrl.Controls)
                {
                    DisableAllControls(childCtrl);
                }
            }
            else
            {
                //ctrl is not a container, thus its
                //datatype may be of a type we wish to reset, so
                //determine if we are interested in it.

                //Use a if statement as opposed to a switch statement as 
                //switch on works on integral type or strings.
                if (ctrl.GetType() == typeof(TextBox))
                {
                    ((TextBox)ctrl).Enabled = false;
                }
                else if (ctrl.GetType() == typeof(DropDownList))
                {
                    ((DropDownList)ctrl).Enabled = false;
                }
                else if (ctrl.GetType() == typeof(CheckBox))
                {
                    ((CheckBox)ctrl).Enabled = false;
                }
                else if (ctrl.GetType() == typeof(RadioButtonList))
                {
                    ((RadioButtonList)ctrl).Enabled = false;
                }
                else if (ctrl.GetType() == typeof(DataGrid))
                {
                    //At this time there seems to be nothing we can do
                    //to automatically set a grid for viewing only
                    // and still allow sorts - this will have 
                    //to be handled on the page as required by
                    //ensuring there are no edit buttons on the grid
                }
            }
        }

        protected virtual void EnforceSMARTSecurity()
        {

        }

        public override void Dispose()
        {
            if (m_customerSecurity != null)
            {
                m_customerSecurity.Dispose();
            }
        }

        public DataView DataViewGridSource
        {
            get
            {

                string sortExpression;

                if (m_dataViewGridSource == null)
                {
                    m_dataViewGridSource = GetDataViewGridSource();

                    //If there is a sort expression then sort the grid          
                    try
                    {
                        sortExpression = Session[m_previousSortExpression].ToString();
                    }
                    catch
                    {
                        sortExpression = "";
                    }
                    //Call the SortGrid routine every time so that the variables it stores
                    //in the session object get refreshed (this is especially important
                    //the first time through)
                    //But prevent infinite loop if GetDataViewGridSource returns null (this happens especially in design view)
                    if (m_dataViewGridSource != null)
                        SortGrid("");

                    return m_dataViewGridSource;
                }
                else
                {
                    return m_dataViewGridSource;
                }
            }
            set
            {
            }
        }

        public void ClearDataViewGridSource()
        {
            m_dataViewGridSource = null;
        }

        /// <summary>
        /// Override this function in the child page and add code to return a dataview
        /// populated from the database which is used as the datasource for the main
        /// grid on the page.
        /// </summary>
        /// <returns></returns>
        protected virtual DataView GetDataViewGridSource()
        {
            return null;
        }

        protected virtual PetroCanada.CorpExec.WebControls.ValidationSummary ValidationSummaryControl
        {
            get
            {
                return null;
            }
        }

        private void DisplayInValidationSummary(string message)
        {
            //Only try to display the message if there is a control to display it in.
            if (ValidationSummaryControl != null)
            {
                ValidationSummaryControl.AddErrorMessage(message);
            }
        }

        protected int GetItemIndex(string primaryKeyAsString)
        {
            int row;
            for (row = 0; row < DataViewGridSource.Count; row++)
            {
                if (DataViewGridSource[row]["PRIMARY_KEY_AS_STRING"].ToString() == primaryKeyAsString)
                    return row;
            }
            return -1;
        }

        protected void SortGrid(string sortExpression)
        {
            int rowCount;
            int prevRowCount;
            string message;
            string prevSortExp;
            string sortExp;
            bool userTriggeredSort = true;

            //If a sort expression is passed in then decide whether to 
            //sort ascending or descending
            if (sortExpression.Length > 0)
            {
                //Create the default sort expression
                sortExp = sortExpression + " ASC";

                //Get the previous sort expression 
                try
                {
                    prevSortExp = Session[m_previousSortExpression].ToString();
                }
                catch
                {
                    prevSortExp = "";
                }

                //Decide whether to sort ascending or descending based on prev sort expression if it exists
                if (prevSortExp.Length > 0)
                {
                    if (prevSortExp == sortExp)
                    {
                        sortExp = sortExpression + " DESC";
                    }
                    else
                    {
                        sortExp = sortExpression + " ASC";
                    }
                }
            }
            else
            {
                //If no sort expression is passed in the use the previous expression  
                try
                {
                    sortExp = Session[m_previousSortExpression].ToString();
                }
                catch
                {
                    //No previous sort expression exisits so set to blank
                    sortExp = "";
                }
                //Since the sort was not triggered by the user set the flag
                userTriggeredSort = false;
            }

            //Get the row count and message = message if it has changed
            try
            {
                prevRowCount = int.Parse(Session[m_previousDataGridRowCount].ToString());
            }
            catch
            {
                prevRowCount = -1;
            }
            rowCount = DataViewGridSource.Table.Rows.Count;
            if (prevRowCount != -1)
            {
                int diff = rowCount - prevRowCount;
                if (diff < 0)
                {
                    diff = diff * -1;
                    if (diff > 1)
                        message = "Another user has deleted " + diff.ToString() + " records since your last action.";
                    else
                        message = "Another user has deleted 1 record since your last action.";
                }
                else if (diff > 0)
                {
                    if (diff > 1)
                        message = "Another user has added " + diff.ToString() + " records since your last action.";
                    else
                        message = "Another user has added 1 record since your last action.";

                }
                else message = "";
            }
            else
            {
                message = "";
            }

            //Sort the dataview
            DataViewGridSource.Sort = sortExp;

            //Store previous sort info so we can compare next time
            Session[m_previousSortExpression] = sortExp;
            Session[m_previousDataGridRowCount] = rowCount;

            //Display the message to the user if they initiated the sort (otherwise suppress
            //it as the sort was just triggered by a repopulation of the grid which
            //likely is the result of this user making changes and therefore no
            //explanation of changes is required
            if (userTriggeredSort)
            {
                DisplayInValidationSummary(message);
            }
        }
    }

}