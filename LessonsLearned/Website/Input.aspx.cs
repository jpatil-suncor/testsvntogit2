using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Backend.Maintenance;
using Backend.Business;


namespace Website
{
    public partial class Input : LLWebPageBase
    {
        //protected System.Web.UI.WebControls.DataGrid dgDiscipline;
        protected System.Web.UI.WebControls.DataGrid dgStages;
        protected System.Web.UI.WebControls.DataGrid dgSubjectMatter;
        protected System.Web.UI.WebControls.DataGrid dgCategory;

        protected System.Web.UI.WebControls.FileUpload FileUpload3;
        protected System.Web.UI.WebControls.FileUpload FileUpload4;


        protected DataView dvSBU;
        protected DataView dvBU;
        protected DataView dvFrequency;
        protected DataView dvImpact;
        protected DataView dvType;
        protected DataView dvProject;
        protected DataView dvFinancialImpact;
        protected object LL_ID;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDropDownsandCheckBoxes();
                FormatTextBoxes();
                Page.DataBind();
            
            }
            PopulateName();
            //only show this button if the user is a LL Coordinator. 
            this.exceltemplate.Visible = false;
            if ((String)Session[Global.Parameters.LL_Coordinator].ToString() != "")
            {
                this.exceltemplate.Visible = true;
            }
            
            //this.lblTitle.Text = ConfigurationManager.AppSettings["TitleMSG"].ToString();
            

           
        }

        protected override void OnInit(EventArgs e)
        {
            InitializeComponent();
            //base.OnInit(e);
        }

        private void InitializeComponent()
        {
            this.btnCancel.Click += new EventHandler(btnCancel_Click);
            this.btnBack.Click += new EventHandler(btnBack_Click);
            this.btnNext.Click += new EventHandler(btnNext_Click);
            this.btnSave.Click += new EventHandler(btnSave_Click);

            this.imgTitle.Attributes.Add("onmouseover", "showPopup('title', event);");
            this.imgTitle.Attributes.Add("onmouseout", "hideCurrentPopup();");
            this.imgStatement.Attributes.Add("onmouseover", "showPopup('statement', event);");
            this.imgStatement.Attributes.Add("onmouseout", "hideCurrentPopup();");
            this.imgBackground.Attributes.Add("onmouseover", "showPopup('background', event);");
            this.imgBackground.Attributes.Add("onmouseout", "hideCurrentPopup();");
            this.imgRecommendations.Attributes.Add("onmouseover", "showPopup('recommendation', event);");
            this.imgRecommendations.Attributes.Add("onmouseout", "hideCurrentPopup();");
            this.imgReference.Attributes.Add("onmouseover", "showPopup('reference', event);");
            this.imgReference.Attributes.Add("onmouseout", "hideCurrentPopup();");

            //this.imgHelp.Attributes.Add("onmouseover", "showPopup('help', event);");
            //this.imgHelp.Attributes.Add("onmouseout", "hideCurrentPopup();");

            this.imgFileUpload.Attributes.Add("onmouseover", "showPopup('fileupload', event);");
            this.imgFileUpload.Attributes.Add("onmouseout", "hideCurrentPopup();");

            this.imgType.Attributes.Add("onmouseover", "showPopup('type', event);");
            this.imgType.Attributes.Add("onmouseout", "hideCurrentPopup();");
            this.imgImpact.Attributes.Add("onmouseover", "showPopup('impact', event);");
            this.imgImpact.Attributes.Add("onmouseout", "hideCurrentPopup();");
            this.imgFinImpact.Attributes.Add("onmouseover", "showPopup('Kimpact', event);");
            this.imgFinImpact.Attributes.Add("onmouseout", "hideCurrentPopup();");
            this.imgFrequency.Attributes.Add("onmouseover", "showPopup('frequency', event);");
            this.imgFrequency.Attributes.Add("onmouseout", "hideCurrentPopup();");
            


            this.ddlSBU.SelectedIndexChanged += new EventHandler(ddlSBU_SelectedIndexChanged);
            this.ddlSBU.AutoPostBack = true;
         //   this.ddlBU.SelectedIndexChanged += new EventHandler(ddlBU_SelectedIndexChanged);

        }

        protected void ddlSBU_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSBU.SelectedItem.Value.ToString() != "")
            {
                DataTable tbl;
                BusinessUnit bu = new BusinessUnit();
                bu.CurrentUser = LoginName;
                bu.SBUId = decimal.Parse(ddlSBU.SelectedItem.Value.ToString());
                tbl = bu.GetRecordsbySBU().Tables[0];
                tbl.Rows.InsertAt(tbl.NewRow(), 0);
                dvBU = tbl.DefaultView;
                ddlBU.Enabled = true;
                ddlBU.DataBind();
                ddlProject.Enabled = false;
                ddlProject.ClearSelection();
                ddlProject.DataBind();
            }
            else
            {
                ddlBU.Enabled = false;
                ddlBU.ClearSelection();
                ddlProject.Enabled = false;
                ddlProject.ClearSelection();                
            }

        }

        protected void ddlBU_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBU.SelectedItem.Value.ToString() != "")
            {
                DataTable tbl;
                Project prj = new Project();
                prj.CurrentUser = LoginName;
                prj.BUId = decimal.Parse(ddlBU.SelectedItem.Value.ToString());
                tbl = prj.GetRecordsbyBU().Tables[0];
                tbl.Rows.InsertAt(tbl.NewRow(), 0);
                dvProject = tbl.DefaultView;
                ddlProject.Enabled = true;
                ddlProject.DataBind();
            }
            else
            {
                ddlProject.Enabled = false;
                ddlProject.ClearSelection();
            }
        }

        protected void txtAmount_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void FormatTextBoxes()
        {
            //this will allow them to hit return in the text box.
            this.txtBackground.Attributes.Add("onkeydown", "NotesKeyDown();");
            this.txtRecommendations.Attributes.Add("onkeydown", "NotesKeyDown();");
            this.txtStatement.Attributes.Add("onkeydown", "NotesKeyDown();");
            this.txtTitle.Attributes.Add("onkeydown", "NotesKeyDown();");
        }

        private void PopulateName()
        {

            string ntUser = string.Empty;
            string LANID = string.Empty;
            ntUser = this.Request.LogonUserIdentity.Name;

            LANID = ntUser.Substring(ntUser.IndexOf("\\") + 1);

            

            if (LANID != "")
            {
                Session.Add(Global.Parameters.User, LANID);
                // Retrieve First and Last name of user
                User user = new User();
                user.GetByPk(LANID);

                if (user.FirstName.ToString() != "")
                {
                    this.txtFirstName.Text = user.FirstName.ToString();
                    this.txtLastName.Text = user.LastName.ToString();
                    //this.txtPhone.Text = user.Phone.ToString();
                    if (user.Phone.ToString() != "")
                    { this.txtPhone.Text = user.Phone.ToString().Substring(user.Phone.ToString().IndexOf("+1") + 3); }
                    lblWelcome.Text = "Welcome " + user.FirstName.ToString() + " " + user.LastName.ToString();
                }
                else 
                {
                    lblWelcome.Text = "Welcome " + LoginName.ToString();
                }

                if (user.LLCoordinator.ToString() != "")
                {
                    Session.Add(Global.Parameters.LL_Coordinator, user.LLCoordinator.ToString());
                }
                else
                {
                    Session.Add(Global.Parameters.LL_Coordinator, "");
                }
            }

        }
        private void PopulateDropDownsandCheckBoxes()
        { 
        
            //Check boxes
            //PopulateDiscipline();
            PopulateStages();
            PopulateSubjectMatter();
            PopulateCategory();

            //Drop Downs
            PopulateDropDowns();
        }
        private void PopulateCategory()
        {
            Category cat = new Category();
            cat.CurrentUser = LoginName;
            DataSet ds;

            ds = cat.GetAllActiveRecords();
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgCategory.DataSource = ds.Tables[0];
                dgCategory.DataBind();
            }
        }
        private void PopulateDropDowns()
        {
            DataTable tbl;

            SBU sbu = new SBU();
            tbl = sbu.GetAllActiveRecords().Tables[0];
            tbl.Rows.InsertAt(tbl.NewRow(), 0);
            dvSBU = tbl.DefaultView;

            this.ddlBU.Enabled = false;
            this.ddlProject.Enabled = false;

            //BusinessUnit bu = new BusinessUnit();
            //tbl = bu.GetAllActiveRecords().Tables[0];
            //tbl.Rows.InsertAt(tbl.NewRow(), 0);
            //dvBU = tbl.DefaultView;

            //Project prj = new Project();
            //tbl = prj.GetAllActiveRecords().Tables[0];
            //tbl.Rows.InsertAt(tbl.NewRow(), 0);
            //dvProject = tbl.DefaultView;

            Frequency freq = new Frequency();
            tbl = freq.GetAllActiveRecords().Tables[0];
            tbl.Rows.InsertAt(tbl.NewRow(), 0);
            dvFrequency = tbl.DefaultView;

            Impact imp = new Impact();
            tbl = imp.GetAllActiveRecords().Tables[0];
            tbl.Rows.InsertAt(tbl.NewRow(), 0);
            dvImpact = tbl.DefaultView;

            Backend.Maintenance.Type type = new Backend.Maintenance.Type();
            tbl = type.GetAllActiveRecords().Tables[0];
            tbl.Rows.InsertAt(tbl.NewRow(), 0);
            dvType = tbl.DefaultView;

            FinancialImpact fi = new FinancialImpact();
            tbl = fi.GetAllActiveRecords().Tables[0];
            tbl.Rows.InsertAt(tbl.NewRow(), 0);
            dvFinancialImpact = tbl.DefaultView;          

        }
        private void PopulateStages()
        {
            Stages stage = new Stages();
            stage.CurrentUser = LoginName;
            DataSet ds;

            ds = stage.GetAllActiveRecords();
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgStages.DataSource = ds.Tables[0];
                dgStages.DataBind();
            }

        }
        private void PopulateSubjectMatter()
        {
            SubjectMatter sm = new SubjectMatter();
            sm.CurrentUser = LoginName;
            DataSet ds;

            ds = sm.GetAllActiveRecords();
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgSubjectMatter.DataSource = ds.Tables[0];
                dgSubjectMatter.DataBind();
            }

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = true;
            this.btnNext.Enabled = true;
            this.btnBack.Enabled = false;
            this.btnSave.Enabled = false;

            this.panel2.Visible = false;
            ClearAllControls(this);
            PopulateName();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (this.panel1.Visible)
            {
                //shouldnt happen
            }
            else if (this.panel2.Visible)
            {
                this.panel2.Visible = false;
                this.panel1.Visible = true;
                this.btnBack.Enabled = false;
                this.btnNext.Enabled = true;
                this.panelNav.Style.Value = "z-index: 101; position:absolute; top: 850px; ";
                //if (Session[Global.Parameters.File3].ToString() != "")
                //{
                //    FileUpload3 = (FileUpload)Session[Global.Parameters.File3];
                //}


            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (this.panel1.Visible)
            {
                this.panel1.Visible = false;
                this.panel2.Visible = true;
                this.btnBack.Enabled = true;
                this.btnNext.Enabled = false;
                this.btnSave.Enabled = false;
                

                this.panelNav.Style.Value = "z-index: 101; position:absolute; top: 1450px; ";

 
                //if (FileUpload3.HasFile)
                //{
                //    //store this file in session as we lose it going from page to page
                //    Session.Add(Global.Parameters.File3, FileUpload3);
                //    String tempFile3 = System.IO.Path.GetDirectoryName(System.IO.Path.GetTempFileName().ToString());
                //    tempFile3 = tempFile3 + "\\" + FileUpload3.FileName.ToString();
                //    Session.Add(Global.Parameters.tempFile3, tempFile3.ToString());
                //    FileUpload3.SaveAs(tempFile3);                    
                //}
                //else
                //{
                //    Session.Add(Global.Parameters.File3, "");
                //}
                //if (FileUpload4.HasFile)
                //{
                //    //store this file in session as we lose it going from page to page
                //    Session.Add(Global.Parameters.File4, FileUpload4);
                //    String tempFile4 = System.IO.Path.GetDirectoryName(System.IO.Path.GetTempFileName().ToString());
                //    tempFile4 = tempFile4 + "\\" + FileUpload4.FileName.ToString();
                //    Session.Add(Global.Parameters.tempFile4, tempFile4.ToString());
                //    FileUpload4.SaveAs(tempFile4);
                //}
                //else
                //{
                //    Session.Add(Global.Parameters.File4, "");
                //}
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
                CheckBox chkSelected = new CheckBox();
                PotentialLesson LL = new PotentialLesson();
                bool panel1controlsAreValid = true;
                bool panel2controlsAreValid = true;
                bool subjectMatterValid = false;
                bool stagesValid = false;

                LL.CurrentUser = LoginName;
                LL.StatusId = 1; //This is to be in 'submitted' mode.
                LL.UserName = LoginName;

                try
                {
                    if (txtFirstName.Text.ToString() != "")
                    {
                        LL.FirstName = txtFirstName.Text.ToString();
                    }
                    else
                    {
                        ValidationSummary1.AddErrorMessage("Please enter First Name .");
                        panel1controlsAreValid = false;
                    }

                    if (txtLastName.Text.ToString() != "")
                    {
                        LL.LastName = txtLastName.Text.ToString();
                    }
                    else
                    {
                        ValidationSummary1.AddErrorMessage("Please enter Last Name .");
                        panel1controlsAreValid = false;
                    }

                    if (txtPhone.Text.ToString() != "")
                    {
                        LL.Phone = txtPhone.Text.ToString();
                    }
                    else
                    {
                        ValidationSummary1.AddErrorMessage("Please enter Phone # .");
                        panel1controlsAreValid = false;
                    }

                    if (txtLocation.Text.ToString() != "" && txtLocation.Text.Length < 50)
                    {
                        LL.Location = txtLocation.Text.ToString();
                    }
                    else
                    {
                        if (txtLocation.Text.Length > 50)
                        {
                            ValidationSummary1.AddErrorMessage("Location must be less then 50 characters.");
                            panel1controlsAreValid = false;
                        
                        }
                    }
                    

                    if (ddlSBU.SelectedIndex != 0)
                    {
                        try
                        {
                            LL.SBUId = decimal.Parse(ddlSBU.SelectedItem.Value.ToString());
                        }
                        catch (SystemException ex)
                        {
                            throw new Backend.LLException("SBU ID is not numeric.", ex);
                        }

                    }
                    else
                    {
                        ValidationSummary1.AddErrorMessage("Please choose a SBU. ");
                        panel1controlsAreValid = false;
                    }

                    if (ddlBU.SelectedIndex != -1 && ddlBU.SelectedIndex != 0)
                    {
                        try
                        {
                            LL.BUId = decimal.Parse(ddlBU.SelectedItem.Value.ToString());
                        }
                        catch (SystemException ex)
                        {
                            throw new Backend.LLException("BU ID is not numeric.", ex);
                        }
                    }
                    else
                    {
                        ValidationSummary1.AddErrorMessage("Please choose a Business Unit. ");
                        panel1controlsAreValid = false;
                    }

                    if ((ddlProject.SelectedIndex != -1 && ddlProject.SelectedIndex != 0) || txtOther.Text.ToString() != "")
                    {
                        if (txtOther.Text.ToString() != "")
                        {
                            if (txtOther.Text.Length < 81)
                            {
                                LL.ProjectOther = txtOther.Text.ToString();
                            }
                            else
                            {
                                ValidationSummary1.AddErrorMessage("Project Other must be 80 Characters or less. ");
                                panel1controlsAreValid = false;
                            }
                        }

                        if (ddlProject.SelectedIndex != -1 && ddlProject.SelectedIndex != 0)
                        {
                            try
                            {
                                LL.ProjectId = decimal.Parse(ddlProject.SelectedItem.Value.ToString());
                            }
                            catch (SystemException ex)
                            {
                                throw new Backend.LLException("Project ID is not numeric.", ex);
                            }
                        }
                    }
                    else
                    {
                        ValidationSummary1.AddErrorMessage("Please choose a Project Name or if not there, enter a value in the 'other' box. ");
                        panel1controlsAreValid = false;
                    }

                    if (txtTitle.Text.ToString() != "")
                    {
                        LL.Title = txtTitle.Text.ToString();
                    }
                    else
                    {
                        ValidationSummary1.AddErrorMessage("Please enter a Title less then 100 characters. ");
                        panel1controlsAreValid = false;
                    }

                    if (txtStatement.Text.ToString() != "")
                    {
                        LL.Statement = txtStatement.Text.ToString();
                    }
                    else
                    {
                        ValidationSummary1.AddErrorMessage("Please enter a Statement less then 300 characters. ");
                        panel1controlsAreValid = false;
                    }
                    
                    if (txtRecommendations.Text.ToString() != "")
                    {
                        LL.Background = txtBackground.Text.ToString();
                    }

                    if (ddlFinancialImpact.SelectedIndex > 0)
                    {
                        try
                        {
                            LL.FinancialImpactId = decimal.Parse(ddlFinancialImpact.SelectedItem.Value.ToString());
                        }
                        catch (SystemException ex)
                        {
                            throw new Backend.LLException("Financial Impact ID is not numeric.", ex);
                        }
                    }    

                    if (ddlType.SelectedIndex != 0 || txtTypeOther.Text.ToString() != "")
                    {
                        if (txtTypeOther.Text.ToString() != "")
                        {
                            if (txtTypeOther.Text.Length < 51)
                            {
                                LL.TypeOther = txtTypeOther.Text.ToString();
                            }
                            else
                            {
                                ValidationSummary1.AddErrorMessage("Type Other must be 50 Characters or less. ");
                                panel1controlsAreValid = false;
                            }
                        }
                        if (ddlType.SelectedIndex != 0)
                        {
                            try
                            {
                                LL.TypeId = decimal.Parse(ddlType.SelectedItem.Value.ToString());
                            }
                            catch (SystemException ex)
                            {
                                throw new Backend.LLException("Type ID is not numeric.", ex);
                            }

                        }
                    }
                    else
                    {
                        //Christian asked to make these fields NOT mandatory, Oct 10, 2008
                        //ValidationSummary1.AddErrorMessage("Please choose a Type or if not there, enter a value in the 'other' box.");
                        //panel1controlsAreValid = false;
                    }

                    if (ddlImpact.SelectedIndex != 0)
                    {
                        try
                        {
                            LL.ImpactId = decimal.Parse(ddlImpact.SelectedItem.Value.ToString());
                        }
                        catch (SystemException ex)
                        {
                            throw new Backend.LLException("Impact ID is not numeric.", ex);
                        }

                    }
                    else
                    {
                        //Christian asked to make these fields NOT mandatory, Oct 10, 2008
                        //ValidationSummary1.AddErrorMessage("Please choose a Impact. ");
                        //panel1controlsAreValid = false;
                    }

                    if (ddlFrequency.SelectedIndex != 0)
                    {
                        try
                        {
                            LL.FrequencyId = decimal.Parse(ddlFrequency.SelectedItem.Value.ToString());
                        }
                        catch (SystemException ex)
                        {
                            throw new Backend.LLException("Frequency Id is not numeric.", ex);
                        }
                    }
                    else
                    {
                        //Christian asked to make these fields NOT mandatory, Oct 10, 2008
                       // ValidationSummary1.AddErrorMessage("Please choose a Frequency. ");
                       // panel1controlsAreValid = false;
                    }

                    if (txtRecommendations.Text.ToString() != "")
                    {
                        LL.Response = txtRecommendations.Text.ToString();
                    }
                    else
                    {
                        ValidationSummary1.AddErrorMessage("Please enter a Recommendations less then 500 characters. ");
                        panel1controlsAreValid = false;
                    }

                    if (txtReference.Text.ToString() != "")
                    {
                        LL.Reference = txtReference.Text.ToString();
                    }

                    LL.Comments = "";

                    // check to see if they picked at least one Subject Matter
                    foreach (DataGridItem dgItem in dgSubjectMatter.Items)
                    {
                        chkSelected = (CheckBox)dgItem.FindControl("chkSelection");
                        if (chkSelected.Checked)
                        {
                            subjectMatterValid = true;
                        }
                    }
                    if (!subjectMatterValid)
                    {
                        ValidationSummary1.AddErrorMessage("Must pick at least one Process. ");
                        panel2controlsAreValid = false;
                    }

                    foreach (DataGridItem dgItem in dgStages.Items)
                    {
                        chkSelected = (CheckBox)dgItem.FindControl("chkSelection");
                        if (chkSelected.Checked)
                        {
                            stagesValid = true;
                        }
                    }

                    if (!stagesValid)
                    {
                        ValidationSummary1.AddErrorMessage("Must pick at least one Project Phase. ");
                        panel2controlsAreValid = false;
                    }


                    if (panel1controlsAreValid)
                    {
                        if (panel2controlsAreValid)
                        {
                            try
                            {
                                //This is a screen import not a Excel Import
                                LL.ImportfromExcel = "N";
                                LL.Save();
                            }
                            catch (SystemException ex)
                            {
                                throw new Backend.LLException("Failed to save document.", ex);
                            }

                            // Get the LL_ID to save any of the checkboxes picked to the xref table.
                            LL_ID = LL.LLId;

                            foreach (DataGridItem dgItem in dgSubjectMatter.Items)
                            {
                                chkSelected = (CheckBox)dgItem.FindControl("chkSelection");
                                if (chkSelected.Checked)
                                {
                                    LL.SubjectMatterId = decimal.Parse(dgItem.Cells[0].Text.ToString());
                                    try
                                    {
                                        //Make sure some data was returned if not throw an exception
                                        LL.SaveSubjectMatterInfo();
                                    }
                                    catch (ApplicationException)
                                    {
                                        throw new ApplicationException(string.Format("Subject Matter information Save error: ", LL_ID));
                                    }
                                }
                            }

                            foreach (DataGridItem dgItem in dgCategory.Items)
                            {
                                chkSelected = (CheckBox)dgItem.FindControl("chkSelection");
                                if (chkSelected.Checked)
                                {
                                    
                                    LL.CategoryId = decimal.Parse(dgItem.Cells[0].Text.ToString());
                                    try
                                    {
                                        //Make sure some data was returned if not throw an exception
                                        LL.SaveCategoryInfo();
                                    }
                                    catch (ApplicationException)
                                    {
                                        throw new ApplicationException(string.Format("Discipline information Save error: ", LL_ID));
                                    }
                                }
                            }

                            foreach (DataGridItem dgItem in dgStages.Items)
                            {
                                chkSelected = (CheckBox)dgItem.FindControl("chkSelection");
                                if (chkSelected.Checked)
                                {
                                    LL.StageId = decimal.Parse(dgItem.Cells[0].Text.ToString());
                                    try
                                    {
                                        //Make sure some data was returned if not throw an exception
                                        LL.SaveStageInfo();
                                    }
                                    catch (ApplicationException)
                                    {
                                        throw new ApplicationException(string.Format("Project Stage information Save error: ", LL_ID));
                                    }
                                }
                            }
                           //Session[Global.Parameters.AmendViewEdit].ToString()
                            //if (Session[Global.Parameters.File3].ToString() != "")
                            if (txtFile1.Text.ToString() != "")
                            {
                                FileUpload3 = (FileUpload)Session[Global.Parameters.File3];
                                Session.Remove(Global.Parameters.File3);

                                if (FileUpload3.HasFile)
                                {
                                    String fileName = (String)Session[Global.Parameters.tempFile3];
                                    UploadtoDocumentum("Save From the WEB", fileName, FileUpload3.FileName, LL_ID.ToString());
                                    Session.Remove(Global.Parameters.tempFile3);
                                }
                            }
                            

                            //if (Session[Global.Parameters.File4].ToString() != "")
                            if (txtFile2.Text.ToString() != "")
                            {
                                FileUpload4 = (FileUpload)Session[Global.Parameters.File4];
                                Session.Remove(Global.Parameters.File4);

                                if (FileUpload4.HasFile)
                                {
                                    String fileName = (String)Session[Global.Parameters.tempFile4];
                                    UploadtoDocumentum("Save From the WEB", fileName, FileUpload4.FileName, LL_ID.ToString());
                                    Session.Remove(Global.Parameters.tempFile4);
                                }
                            }

                           
                            //using the Error msg to confirm the Save.
                            ValidationSummary1.AddErrorMessage("Thank you, your info has been successfully submitted to the Lesson Learned Coordinator. ");
                            //Cleare all fields and return to first page.
                            this.panel1.Visible = true;
                            this.btnNext.Enabled = true;
                            this.btnBack.Enabled = false;
                            this.btnSave.Enabled = false;

                            this.panel2.Visible = false;
                            ClearAllControls(this);
                            PopulateName();

                            String sPathReport;
                            String sScript;

                            //call report window with their data.
                            Session.Add(Global.Parameters.SubmittedFinal, "SUBMITTED");
                            sPathReport = "window.open('" + Global.ProcessingPage.ToString() + "?" + Global.Parameters.LL_ID + "=" + LL_ID.ToString() + "');";
                            sScript = "<script> " + sPathReport + "</script>";
                            this.ClientScript.RegisterStartupScript(this.GetType(), "START", sScript);
                                                          
                            //this.RegisterStartupScript("START", sScript);

                        }
                        else
                        {
                            this.panel1.Visible = false;
                            this.panel2.Visible = true;
                        }
                    }
                    else
                    {
                        this.panel1.Visible = true;
                        this.btnNext.Enabled = true;
                        this.btnBack.Enabled = false;
                        this.btnSave.Enabled = false;
                        this.panel2.Visible = false;
                    }
                }
                catch (System.Exception ex)
                {
                    throw new Backend.LLException("Failed to save document.", ex);
                }
        }

       

        private static String GuessFormat(String fileName)
        {
            String ext = System.IO.Path.GetExtension(fileName).ToLower();
            if (ext == ".pdf")
            {
                return "pdf";
            }
            else if (ext == ".htm")
            {
                return "html";
            }
            else if (ext == ".html")
            {
                return "html";
            }
            else if (ext == ".xml")
            {
                return "xml";
            }
            else if (ext == ".doc")
            {
                return "msw8";
            }
            else if (ext == ".txt")
            {
                return "crtext";
            }
            else if (ext == ".rtf")
            {
                return "msw8";
            }
            else if (ext == ".msg")
            {
                return "msw8";
            }

            else if (ext == ".tif" || ext == ".tiff")
            {
                return "tiff";
            }
            else if (ext == ".xls")
            {
                return "excel8book";
            }
            else
            {
                return "unknown";
            }

        }

        protected void exceltemplate_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExcelInput.aspx");
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (FileUpload3.HasFile)
            {
                if (txtFile1.Text.ToString() == "")
                {
                    //Add file to text box 1 and session
                    Session.Add(Global.Parameters.File3, FileUpload3);
                    String tempFile3 = System.IO.Path.GetDirectoryName(System.IO.Path.GetTempFileName().ToString());
                    tempFile3 = tempFile3 + "\\" + FileUpload3.FileName.ToString();
                    Session.Add(Global.Parameters.tempFile3, tempFile3.ToString());
                    FileUpload3.SaveAs(tempFile3);
                    txtFile1.Text = FileUpload3.FileName.ToString();
                }
                else
                {
                    if (txtFile2.Text.ToString() == "")
                    {
                        //Add file to text box 2 and session
                        Session.Add(Global.Parameters.File4, FileUpload3);
                        String tempFile4 = System.IO.Path.GetDirectoryName(System.IO.Path.GetTempFileName().ToString());
                        tempFile4 = tempFile4 + "\\" + FileUpload3.FileName.ToString();
                        Session.Add(Global.Parameters.tempFile4, tempFile4.ToString());
                        FileUpload3.SaveAs(tempFile4);
                        txtFile2.Text = FileUpload3.FileName.ToString();
                    }
                    else
                    {
                        //both files are full display error msg
                        ValidationSummary1.AddErrorMessage("You file limit of 2 has been reached, please delete a file before uploading another. ");
                    }
                }
            }
            else
            {
                ValidationSummary1.AddErrorMessage("You must Browse to your file before uploading. ");                            
            }
        }

        protected void btnFile1_Click(object sender, EventArgs e)
        {
            if (txtFile1.Text.ToString() != "")
            { 
                //delete file name from text box and session
                Session.Remove(Global.Parameters.File3);
                System.IO.File.Delete(Session[Global.Parameters.tempFile3].ToString());
                Session.Remove(Global.Parameters.tempFile3);
                txtFile1.Text = "";
            }
        }

        protected void btnFile2_Click(object sender, EventArgs e)
        {
            if (txtFile2.Text.ToString() != "")
            {
                //delete file name from text box and session
                Session.Remove(Global.Parameters.File4);
                System.IO.File.Delete(Session[Global.Parameters.tempFile4].ToString());
                Session.Remove(Global.Parameters.tempFile4);
                txtFile2.Text = "";
            }
        }

       
       
    }
}
