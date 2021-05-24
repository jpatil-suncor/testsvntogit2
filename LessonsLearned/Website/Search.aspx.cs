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
using System.Text;
using Backend.Maintenance;
using Backend.Business;

namespace Website
{
    public partial class Search : LLWebPageBase
    {

        protected DataView dvSBU;
        protected DataView dvBU;
        protected DataView dvProject;
        protected DataView dvProcess;
        protected DataView dvDiscipline;
        protected DataView dvStages;
        protected DataView dvSearch;
        protected DataView dvCategory;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDropDowns();
                Page.DataBind();
                PopulateName();
                this.panel1.Visible = false;
                this.btnPrint.Visible = false;
                this.lbldgTotal.Visible = false;
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
           // this.ddlSBU.SelectedIndexChanged += new EventHandler(ddlSBU_SelectedIndexChanged);
           // this.ddlBU.SelectedIndexChanged += new EventHandler(ddlBU_SelectedIndexChanged);
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.lnkFilter.Click += new EventHandler(lnkFilter_Click);
            this.lnkHideFilter.Click += new EventHandler(lnkHideFilter_Click);
            this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);

            this.lnkAdvanced.Click += new EventHandler(lnkAdvanced_Click);
            this.lnkAdvancedHide.Click += new EventHandler(lnkAdvancedHide_Click);
            this.lnkBUAll.Click += new EventHandler(lnkBUAll_Click);
            this.lnkBUReset.Click += new EventHandler(lnkBUReset_Click);

            this.lnkProjectAll.Click += new EventHandler(lnkProjectAll_Click);
            this.lnkProjectReset.Click += new EventHandler(lnkProjectReset_Click);

            this.imgSearch.Attributes.Add("onmouseover", "showPopup('search', event);");
            this.imgSearch.Attributes.Add("onmouseout", "hideCurrentPopup();");

            this.dgSearch.SortCommand += new DataGridSortCommandEventHandler(this.dgSearch_SortCommand);
            //this.dgSearch.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgSearch_ItemDataBound);
           
        }

       

     
        private void PopulateDropDowns()
        {
            DataTable tbl;
            try
            {
                //SBU sbu = new SBU();
                //tbl = sbu.GetAllActiveRecords().Tables[0];
                //tbl.Rows.InsertAt(tbl.NewRow(), 0);
                //dvSBU = tbl.DefaultView;

                BusinessUnit bu = new BusinessUnit();
                bu.CurrentUser = LoginName;
                tbl = bu.GetAllRecords().Tables[0];
                dvBU = tbl.DefaultView;

                Project prj = new Project();
                prj.CurrentUser = LoginName;
                tbl = prj.GetAllActiveRecords().Tables[0];
                dvProject = tbl.DefaultView;
               

                //Populate list box
                SubjectMatter sm = new SubjectMatter();
                sm.CurrentUser = LoginName;
                tbl = sm.GetAllActiveRecords().Tables[0];
                dvProcess = tbl.DefaultView;

                Discipline disc = new Discipline();
                disc.CurrentUser = LoginName;
                tbl = disc.GetAllActiveRecords().Tables[0];
                dvDiscipline = tbl.DefaultView;

                Category cat = new Category();
                cat.CurrentUser = LoginName;
                tbl = cat.GetAllActiveRecords().Tables[0];
                dvCategory = tbl.DefaultView;

                Stages stage = new Stages();
                stage.CurrentUser = LoginName;
                tbl = stage.GetAllActiveRecords().Tables[0];
                dvStages = tbl.DefaultView;

                
            }
            catch (System.Exception ex)
            {
                throw new Backend.LLException("Failed to load list boxes and drop down lists.", ex);
            }

        }

        private void lnkFilter_Click(object sender, System.EventArgs e)
        {

            this.panel1.Visible = true;
            this.panel2.Visible = false;
            this.lnkHideFilter.Visible = true;
            this.lnkFilter.Visible = false;
        }

        private void lnkHideFilter_Click(object sender, System.EventArgs e)
        {

            this.lnkHideFilter.Visible = false;
            this.panel1.Visible = false;
            this.panel2.Visible = false;
            this.lnkFilter.Visible = true;
            this.lnkAdvanced.Visible = true;
            this.lnkAdvancedHide.Visible = false;
        }

        private void lnkAdvanced_Click(object sender, System.EventArgs e)
        {
            this.panel2.Visible = true;
            this.lnkAdvanced.Visible = false;
            this.lnkAdvancedHide.Visible = true;
        }

        private void lnkAdvancedHide_Click(object sender, System.EventArgs e)
        {
            this.panel2.Visible = false;
            this.lnkAdvanced.Visible = true;
            this.lnkAdvancedHide.Visible = false;
           
        }

        private void ButtonReset_Click
            (object sender, System.EventArgs e)
        {
            ClearAllControls(this);
            this.dgSearch.Visible = false;
            this.btnPrint.Visible = false;
            this.lbldgTotal.Visible = false;
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {

            //object runBlankSearch = ((HtmlInputHidden)Page.FindControl("hdnConfirmRunSearch")).Value;

            ////If the search criteria are blank and the user does not confirm to search anyway
            ////exit the sub with no action
            //if (runBlankSearch.ToString().ToLower() == "false") return;
            Session.Add(Global.Parameters.Search, "FALSE");
            ClearDataViewGridSource();
            try
            {
                int dgcount = DataViewGridSource.Table.Rows.Count;
                if (DataViewGridSource.Table.Rows.Count > 0)
                {

                    //dvSearch = DataViewGridSource;
                    dgSearch.Visible = true;
                    this.btnPrint.Visible = true;
                    this.lbldgTotal.Visible = true;
                    lblSearch.Visible = false;
                    dgSearch.DataSource = DataViewGridSource;
                    dgSearch.DataBind();

                    Session.Add(Global.Parameters.Search, "TRUE");
                    Session.Add(Global.Parameters.SearchResults, DataViewGridSource.Table);
                    this.lbldgTotal.Text = "Your search returned " + dgcount.ToString() + " rows";
                }
                else
                { 
                    //show msg as no rows were returned.
                    this.lblSearch.Visible = true;
                    this.lblSearch.Text = "Sorry no records were found for your search";
                    //make the Data grid invisible as they might of has a previous search run before    
                    dgSearch.Visible = false;
                    this.btnPrint.Visible = false;
                    this.lbldgTotal.Visible = false;
                }
            }
            catch (System.Exception ex)
            {
                    throw new Backend.LLException("Search.aspx.ca:ButtonFind_Click[" + ex.Message + "]", ex);
            }
            
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
                    lblWelcome.Text = "Welcome " + user.FirstName.ToString() + " " + user.LastName.ToString();
                }
                else
                {
                    lblWelcome.Text = "Welcome " + LoginName.ToString();
                }
            }
        }

        protected override DataView GetDataViewGridSource()
        {
            FinalLesson lesson = new FinalLesson();

            if (txtSearch.Text.Length > 0)
            {
                //if (!txtSearch.Text.Contains(" "))
                //{
                //    //this Search string has only 1 entry and we need to add a space to the end of it
                //    //for the SQL to work.
                //    //txtSearch.Text = txtSearch.Text.ToString() + " ";
                //    lesson.KeyWords = txtSearch.Text.ToString() + " ";
                //}
                //else 
                //{
                lesson.KeyWords = txtSearch.Text.ToString() + " ";
                //}
            }

            //lesson.KeyWords = txtSearch.Text.ToString();
            lesson.CurrentUser = LoginName;

            String buids = "";
            foreach (ListItem bu in lbBU.Items)
            {
                if (bu.Selected)
                {
                    buids += bu.Value.ToString() + ",";
                }
            }

            String projectids = "";
            foreach (ListItem projectid in lbProject.Items)
            {
                if (projectid.Selected)
                {
                    projectids += projectid.Value.ToString() + ",";
                }
            }

            
            lesson.SBUIds       = "";
            if (buids.Length > 0)
            {
                lesson.BUIds = buids.Substring(0, buids.Length - 1).ToString();
            }
            else
            {
                lesson.BUIds = "";
            }
            if (projectids.Length > 0)
            {
                lesson.ProjectIds = projectids.Substring(0, projectids.Length - 1).ToString();
            }
            else
            {
                lesson.ProjectIds = "";
            }
            

            String processids = "";
            foreach (ListItem process in lbProcess.Items)
            {
                if (process.Selected)
                {
                    processids += process.Value.ToString() + ",";
                }
            }

            String stageids = "";
            foreach (ListItem stages in lbStages.Items)
            {
                if (stages.Selected)
                {
                    stageids += stages.Value.ToString() + ",";
                }
            }

            String disciplinids = "";
            foreach (ListItem disciplines in lbDiscipline.Items)
            {
                if (disciplines.Selected)
                {
                    disciplinids += disciplines.Value.ToString() + ",";
                }
            }

            String categoryids = "";
            foreach (ListItem categories in lbCatagory.Items)
            {
                if (categories.Selected)
                {
                    categoryids += categories.Value.ToString() + ",";
                }
            }


            if (processids.Length > 0)
            {
                lesson.ProcessIds = processids.Substring(0, processids.Length - 1).ToString();
            }
            else
            {
                lesson.ProcessIds = "";
            }

            if (disciplinids.Length > 0)
            {
                lesson.DisciplineIds = disciplinids.Substring(0, disciplinids.Length - 1).ToString();
            }
            else
            {
                lesson.DisciplineIds = "";
            }

            if (stageids.Length > 0)
            {
                lesson.StageIds = stageids.Substring(0, stageids.Length - 1).ToString();
            }
            else
            {
                lesson.StageIds = "";
            }

            if (categoryids.Length > 0)
            {
                lesson.CategoryIds = categoryids.Substring(0, categoryids.Length - 1).ToString();
            }
            else
            {
                lesson.CategoryIds = "";
            }

            DataSet ds = lesson.SearchLessonsLearned();
            return ds.Tables[0].DefaultView;
        }

        public void OncmdViewClick(Object sender, EventArgs e)
        {
            LinkButton viewBtn = (LinkButton)(sender);
            DataGridItem dgi = (DataGridItem)(viewBtn.Parent.Parent);

            String sPathReport;
            String sScript;
            if (dgi.Cells[2].Text.ToString() == "Published")
            {
                Session.Add(Global.Parameters.SubmittedFinal, "FINAL");
                sPathReport = "window.open('" + Global.ProcessingPage.ToString() + "?" + Global.Parameters.LL_ID + "=" + dgi.Cells[1].Text.ToString() + "');";
                sScript = "<script> " + sPathReport + "</script>";
                //this.RegisterStartupScript("START", sScript);
                this.ClientScript.RegisterStartupScript(this.GetType(), "START", sScript);
            }
            if (dgi.Cells[2].Text.ToString() == "Unpublished")
            {
                Session.Add(Global.Parameters.SubmittedFinal, "SUBMITTEDSEARCH");
                sPathReport = "window.open('" + Global.ProcessingPage.ToString() + "?" + Global.Parameters.LL_ID + "=" + dgi.Cells[1].Text.ToString() + "');";
                sScript = "<script> " + sPathReport + "</script>";
                //this.RegisterStartupScript("START", sScript);
                this.ClientScript.RegisterStartupScript(this.GetType(), "START", sScript);
            }
            
        }


        private void dgSearch_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
            SortGrid(e.SortExpression);
            dvSearch = DataViewGridSource;
            dgSearch.DataSource = DataViewGridSource;
            dgSearch.DataBind();
            dgSearch.Visible = true;
        }
        protected void lnkBUAll_Click(object sender, EventArgs e)
        {
            foreach (ListItem bu in lbBU.Items)
            {
                bu.Selected = true;
            }
        }
        protected void lnkBUReset_Click(object sender, EventArgs e)
        {
            foreach (ListItem bu in lbBU.Items)
            {
                bu.Selected = false;
            }
        }
        protected void lnkProjectAll_Click(object sender, EventArgs e)
        {
            foreach (ListItem proj in lbProject.Items)
            {
                proj.Selected = true;
            }
        }
        protected void lnkProjectReset_Click(object sender, EventArgs e)
        {
            foreach (ListItem proj in lbProject.Items)
            {
                proj.Selected = false;
            }
        }

        public string ShowFromFilter()
        {
            if (this.panel1.Visible)
                return "DISPLAY: \"\";";
            else
                return "DISPLAY: none;";
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            if (Session[Global.Parameters.Search].ToString() == "TRUE")
            {
                String sPathReport;
                String sScript;

                sPathReport = "window.open('" + Global.ProcessingBulkSearch.ToString() + "');";
                sScript = "<script> " + sPathReport + "</script>";
                //this.RegisterStartupScript("START", sScript);
                this.ClientScript.RegisterStartupScript(this.GetType(), "START", sScript);
            }
            
        }

        string Truncate(string input, int characterLimit)
        {
            string output = input;

            // Check if the string is longer than the allowed amount
            // otherwise do nothing
            if (output.Length > characterLimit && characterLimit > 0)
            {

                // cut the string down to the maximum number of characters
                output = output.Substring(0, characterLimit);

                // Check if the character right after the truncate point was a space
                // if not, we are in the middle of a word and need to remove the rest of it
                if (input.Substring(output.Length, 1) != " ")
                {
                    int LastSpace = output.LastIndexOf(" ");

                    // if we found a space then, cut back to that space
                    if (LastSpace != -1)
                    {
                        output = output.Substring(0, LastSpace);
                    }
                }
                // Finally, add the "..."
                output += "...";
            }
            return output;
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //this.btnSearch_Click(sender, e);
         
        }
      
    }
}
