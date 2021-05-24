using System;
using System.Collections;
using System.Configuration;
using System.Text;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using PetroCanada.CorpExec.Security;
using PetroCanada.CorpExec.WebControls;
using Website;
using Backend;
using Backend.Documentum;
using Backend.Maintenance;
//using Backend.Reference;
//using Backend.WebControls;

namespace Website
{
    /// <summary>
    /// Base code behind page for the fast application.  Handles basic such
    /// as getting the currently logged in username as well as enforces some
    /// basic security checks and provides common functionality amongst all 
    /// web forms.
    /// </summary>
    public class LLWebPageBase : System.Web.UI.Page
    {
        private PetroCanada.CorpExec.Security.Account m_customerSecurity = null;
        private DataView m_dataViewGridSource = null;
        private string m_previousSortExpression;
        private string m_previousDataGridRowCount;

        public LLWebPageBase()
        {
            //Add our own event handler for the page load event.
            this.Load += new System.EventHandler(PageLoaded);
            //Add our own event handler to the preRender event
            this.PreRender += new System.EventHandler(PreRendered);
            this.Unload += new System.EventHandler(OnUnLoad);
            m_previousSortExpression = Page.ToString() + "_PREVSORTEXP";
            m_previousDataGridRowCount = Page.ToString() + "_PREVROWCOUNT";
        }

        private void OnUnLoad(object sender, System.EventArgs e)
        {
            if (UserAccountSecurity != null)
            {
                UserAccountSecurity.Dispose();
            }
        }

        protected virtual void PageLoaded(object sender, EventArgs e)
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

        protected PetroCanada.CorpExec.Security.Account UserAccountSecurity
        {
            get
            {
                return new PetroCanada.CorpExec.Security.Account(Backend.DataAccess.DataAccessUtil.ConnectionString);
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
                //else if (ctrl.GetType() == typeof(ContractDropDownList))
                //{
                //    ((ContractDropDownList)ctrl).SelectedIndex = -1;
                //}
                else if (ctrl.GetType() == typeof(DataGrid))
                {
                    ((DataGrid)ctrl).DataSource = null;
                    ((DataGrid)ctrl).DataBind();
                }
                else if (ctrl.GetType() == typeof(HtmlInputHidden))
                {
                    ((HtmlInputHidden)ctrl).Value = string.Empty;
                }
                else if (ctrl.GetType() == typeof(ListBox))
                {
                    foreach (ListItem li in ((ListBox)ctrl).Items)
                    {
                        li.Selected = false;
                    }
                }
            }
        }

        /// <summary>
        /// Disables all the controls on the page and builds a string array that 
        /// lists the ones that were originally enabled.  It uses this string
        /// to add to any existing startup script javascript code that will re-enable these
        /// items on the page when it renders on the client.  
        /// NOTE:  This routine should only be called from the very last possible
        /// event in the sequence of events when the page loads.  This ensures that 
        /// we capture all of the appropriate enabled states of the controls and also
        /// prevents the possibility that the rendering engine (or any other
        /// routines) will overwrite our startup
        /// script inadvertantly.
        /// </summary>
        /// <param name="ctrl"></param>
        protected void DisableControlsWhilePageLoads(Control ctrl)
        {
            ArrayList enabledControls = new ArrayList();

            DisableAllControls(ctrl, ref enabledControls);

            if (!IsPostBack)
            {
                EmitScriptToEnableControls(enabledControls);
                ViewState.Add("ENABLED_CONTROLS", enabledControls);
            }
            else
            {
                EmitScriptToEnableControls((ArrayList)ViewState["ENABLED_CONTROLS"]);
            }
        }

        /// <summary>
        /// Disables all of the controls on the page and builds a list of
        /// the names of the controls that were originally enabled
        /// NOTE: Currently not disabling radio buttons as the uniqueId has
        /// a problem with it - we can't use it to re-enable the controls
        /// in javascript.
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="enabledControls">The list of controls originally enabled</param>
        /// <returns></returns>
        private void DisableAllControls(Control ctrl, ref ArrayList enabledControls)
        {

            if (ctrl.Controls.Count > 0)
            {
                //Control has children, so we need to recursivly reset our
                //children as well.			
                foreach (Control childCtrl in ctrl.Controls)
                {
                    DisableAllControls(childCtrl, ref enabledControls);
                }
                //Check if it is a dropdownCalendar and if so disable it here
                //(since it has child controls it this logic can not be moved 
                //down to the lower half of this method)
                if (ctrl.GetType() == typeof(PetroCanada.CorpExec.WebControls.DropDownCalendar))
                {
                    //					if 	(((PetroCanada.CorpExec.WebControls.DropDownCalendar)ctrl).Enabled)
                    //						enabledControls.Add(ctrl.UniqueID);
                    //					((PetroCanada.CorpExec.WebControls.DropDownCalendar)ctrl).Enabled = false;
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
                    if (((TextBox)ctrl).Enabled)
                        enabledControls.Add(ctrl.UniqueID);
                    ((TextBox)ctrl).Enabled = false;
                }
                else if (ctrl.GetType() == typeof(DropDownList))
                {
                    if (((DropDownList)ctrl).Enabled)
                        enabledControls.Add(ctrl.UniqueID);
                    ((DropDownList)ctrl).Enabled = false;
                }

                //Not disabling these as we can't reliably enable (the containing
                //span gets disabled and not re-enabled)
                //				else if (ctrl.GetType() == typeof(CheckBox))
                //				{
                //					if (((CheckBox)ctrl).Enabled)
                //						enabledControls.Add(ctrl.UniqueID);
                //					((CheckBox)ctrl).Enabled = false;
                //				}

                // Not disabling radio button lists as the uniqueId cannot
                // be reliably used to re-enable them
                //				else if (ctrl.GetType() == typeof(RadioButtonList))
                //				{
                //					if (((RadioButtonList)ctrl).Enabled)
                //						enabledControls.Add(ctrl.UniqueID);
                //					((RadioButtonList)ctrl).Enabled = false;
                //				}
                //else if (ctrl.GetType() == typeof(ContractDropDownList))
                //{
                //    if (((ContractDropDownList)ctrl).Enabled)
                //        enabledControls.Add(ctrl.UniqueID);
                //    ((ContractDropDownList)ctrl).Enabled = false;
                //}
                else if (ctrl.GetType() == typeof(Button))
                {
                    if (((Button)ctrl).Enabled)
                        enabledControls.Add(ctrl.UniqueID);
                    ((Button)ctrl).Enabled = false;
                }
                else if (ctrl.GetType() == typeof(DataGrid))
                {
                    //At this time there seems to be nothign we can do
                    //to automatically set a grid for viewing only
                    // and still allow sorts - this will have 
                    //to be handled on the page as required by
                    //ensuring there are no edit buttons on the grid
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
        protected void DisableAllControlsExceptButtons(Control ctrl)
        {

            if (ctrl.Controls.Count > 0)
            {
                //Control has children, so we need to recursivly reset our
                //children as well.			
                foreach (Control childCtrl in ctrl.Controls)
                {
                    DisableAllControlsExceptButtons(childCtrl);
                }
                //Check if it is a dropdownCalendar and if so disable it here
                //(since it has child controls it this logic can not be moved 
                //down to the lower half of this method)
                if (ctrl.GetType() == typeof(PetroCanada.CorpExec.WebControls.DropDownCalendar))
                {
                    ((PetroCanada.CorpExec.WebControls.DropDownCalendar)ctrl).Enabled = false;
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
                //else if (ctrl.GetType() == typeof(ContractDropDownList))
                //{
                //    ((ContractDropDownList)ctrl).Enabled = false;
                //}
                else if (ctrl.GetType() == typeof(DataGrid))
                {
                    //At this time there seems to be nothign we can do
                    //to automatically set a grid for viewing only
                    // and still allow sorts - this will have 
                    //to be handled on the page as required by
                    //ensuring there are no edit buttons on the grid
                }
            }
        }

        /// <summary>
        /// Emits javascript (client side) that will run on startup when the page is loaded
        /// and enable all of the controls passed in by name in the arraylist
        /// </summary>
        /// <param name="enabledControls"></param>
        private void EmitScriptToEnableControls(ArrayList enabledControls)
        {
            StringBuilder script = new StringBuilder();
            IEnumerator ctrls = enabledControls.GetEnumerator();

            script.Append("<script language=\"javascript\" >  ");
            script.Append("");
            script.Append("function emittedScript_EnableIfExists(obj)");
            script.Append("{");
            script.Append("	if (obj != null)");
            script.Append("		obj.disabled = false;");
            script.Append("}");
            while (ctrls.MoveNext())
            {
                script.Append("emittedScript_EnableIfExists(document.forms[0].item('" + ctrls.Current.ToString() + "')); ");
            }

            script.Append("  </script>");

            //Page.RegisterStartupScript("EnableControlsOnceLoaded", script.ToString());
            this.ClientScript.RegisterStartupScript(this.GetType(), "EnableControlsOnceLoaded", script.ToString());
        }

        /// <summary>
        /// We have added code in the constructor
        /// to call this method when the PreRender event fires
        /// for the page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PreRendered(object sender, EventArgs e)
        {
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

        /// <summary>
        /// The function returns the index of the row in the dataview that contains
        /// the record with the given primary key.
        /// As the contents of the dataview can change between postbacks (e.g.
        /// another user deletes or adds rows) this function is necessary
        /// in order to ensure we are dealing with the row that contains the
        /// record of interest 
        /// </summary>
        /// <param name="primaryKeyAsString"></param>
        /// <returns></returns>
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
                    message = "Another user has modified data which has impacted the data you are viewing.";
                    //For now we comment out this block, with effective dating, if another
                    //user makes a change all of the rows essential disapear on a sort
                    //					diff = diff * -1;
                    //					if (diff > 1)
                    //						message = "Another user has deleted " + diff.ToString() + " records since your last action.";
                    //					else
                    //						message = "Another user has deleted 1 record since your last action.";
                }
                else if (diff > 0)
                {
                    message = "Another user has modified data which has impacted the data you are viewing.";
                    //For now we comment out this block, with effective dating, if another
                    //user makes a change all of the rows essential disapear on a sort
                    //					if (diff > 1)
                    //						message = "Another user has added " + diff.ToString() + " records since your last action.";
                    //					else
                    //						message = "Another user has added 1 record since your last action.";
                    //
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
        protected void EnableControls(Control ctrl, bool enable)
        {
            if (ctrl.Controls.Count > 0)
            {
                //Control has children, so we need to recursivly reset our
                //children as well.			
                foreach (Control childCtrl in ctrl.Controls)
                {
                    EnableControls(childCtrl, enable);
                }
                //Check if it is a dropdownCalendar and if so disable it here
                //(since it has child controls it this logic can not be moved 
                //down to the lower half of this method)
                if (ctrl.GetType() == typeof(PetroCanada.CorpExec.WebControls.DropDownCalendar))
                {
                    ((PetroCanada.CorpExec.WebControls.DropDownCalendar)ctrl).Enabled = enable;
                }
            }
            else
            {
                //ctrl is not a container, thus its
                //datatype may be of a type we wish to reset, so
                //determine if we are interested in it.
                if (ctrl.GetType() == typeof(WebControl) || ctrl.GetType().IsSubclassOf(typeof(WebControl)) &&
                    ctrl.GetType() != typeof(Label))
                {
                    ((WebControl)ctrl).Enabled = enable;
                }
            }

        }
        protected void RedirectToInvalidPermissionPage(string message)
        {
            StringBuilder str = new StringBuilder(Website.Global.InvalidPermissionPage);
            str.Append("?");
            str.Append(Website.Global.Parameters.Message);
            str.Append("=");
            str.Append(message);
            try
            {
                Response.Redirect(str.ToString(),false);
            }
            catch { };

        }

        public void RegisterExportFileWindow(string relativePathFilename)
        {
            StringBuilder startScript = null;

            startScript = new StringBuilder();
            startScript.Append("<script>");
            startScript.Append("window.open(\"" + relativePathFilename + "\", ");
            startScript.Append("\"\",\"\")");
            startScript.Append("</script>");
            //Page.RegisterStartupScript("StartUp", startScript.ToString());
            this.ClientScript.RegisterStartupScript(this.GetType(), "START", startScript.ToString());

        }

        protected void ExportDataSet(DataSet ds)
        {
            ExportUtility exp = new ExportUtility();
            string relativePathFilename = string.Empty;
            string absoluteFilename = string.Empty;

            try
            {
                FileNamingUtility.GetCsvFileName(Page.Session, ref absoluteFilename, ref relativePathFilename);
                exp.ExportDataSetToCSV(ds, absoluteFilename);

                //On the Page load we will open a new window so that the user may choose
                //to save or open the export.
                //RegisterExportFileWindow(relativePathFilename);

                //Commented out the line above, because the window would not work on the First Tier
                //The First Tier is where the application sits
                //This will prompt the user to save the file to there own machine.
                //we know that the file will be opened in Excel. So we replace the 
                DownloadFile(absoluteFilename);

            }
            catch (Exception ex)
            {
                throw ex; //Allow the exception to flow up the call stack.
            }
        }

        private void DownloadFile(string fileNameWithPath)
        {
            try
            {
                string fileName = System.IO.Path.GetFileName(fileNameWithPath);
                fileName = fileName.Replace(".tmp", ".xls");
                string ext = System.IO.Path.GetExtension(fileName);
                string contentType = "";

                if (ext != null)
                {
                    switch (ext.ToLower())
                    {
                        case ".htm":
                            contentType = "text/HTML";
                            break;
                        case ".html":
                            contentType = "text/HTML";
                            break;
                        case ".txt":
                            contentType = "application/msword";
                            break;
                        case ".csv":
                            contentType = "application/vnd.ms-excel";
                            break;
                        case ".xls":
                            contentType = "application/vnd.ms-excel";
                            break;
                        case ".rtf":
                            contentType = "application/msword";
                            break;
                        case ".doc":
                            contentType = "application/msword";
                            break;
                        case ".pdf":
                            contentType = "application/pdf";
                            break;
                        default:
                            contentType = "text/plain";
                            break;
                    }
                }
                if (contentType != "")
                {
                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.ContentType = contentType;

                    Response.AppendHeader("content-disposition", "attachment; filename=" + fileName);
                    Response.WriteFile(fileNameWithPath);
                }
                Response.Flush();
                Response.Close();
                //delete file is it exists. it's important to have this check at this point.
                //if the check is moved up it will delete the file before it has a chance to up load it
                if (System.IO.File.Exists(fileNameWithPath))
                    System.IO.File.Delete(fileNameWithPath);
                Response.End();
            }
            catch (Exception ex)
            {
                throw ex; //Allow the exception to flow up the call stack.
            }
        }

        public void UploadtoDocumentum(string description, string filewithpath, string title, string llID)
        {
            ProactDocumentum doc = new ProactDocumentum();
            try
            {
                if (ConfigurationManager.AppSettings["Documentum6_5"].ToString() == "False")
                {
                    doc.Domain = ConfigurationManager.AppSettings["UserDomain"];
                    doc.UserName = ConfigurationManager.AppSettings["DocumentumUser"];
                    doc.Password = ConfigurationManager.AppSettings["DocumentumUserPassword"];
                    doc.Documentum6_5 = false;
                }
                else { doc.Documentum6_5 = true; }
                
                doc.SetLogin();

                doc.FileDescription = description;
                doc.FileNameWithPath = filewithpath;
                doc.FileTitle = title;
                doc.ClassificationCode = llID;
                doc.FolderName = llID;

                string sURL = doc.AddFile();


                if (sURL.Length > 1)
                {
                    Attachment file = new Attachment();

                    String documentumFilename = ConfigurationManager.AppSettings["DocumentumCabinet"] + "/" + llID + "/" + title;
                    file.CurrentUser = LoginName;
                    file.URL = sURL.ToString();
                    file.LLId = llID;
                    file.Description = doc.FileDescription.ToString();
                    file.FileWithPath = documentumFilename;
                    file.Filetitle = doc.FileTitle.ToString();
                    file.FolderName = doc.FolderName.ToString();
                    file.Save();

                    System.IO.File.Delete(filewithpath);
                }
            }
            catch (System.Exception ex)
            {

                throw new Backend.LLException("Failed to save document.", ex);
            }

        }
               
    }


        

}
