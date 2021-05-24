using System;
using System.Data;
using System.Data.OleDb;
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
    public partial class ExcelInput : LLWebPageBase
    {
        protected String counter = "N";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
            PopulateName();
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
            //this.btnInput.Click += new System.EventHandler(this.btnInput_Click);

            //this.dgSearch.SortCommand += new DataGridSortCommandEventHandler(this.dgSearch_SortCommand);
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


        protected void btnInput_Click(object sender, EventArgs e)
        {
            String documentumFilename = "";

            if (counter == "N")
            {

                if (ExcelFile.HasFile)
                {
                    try
                    {
                        
                        //copy file to webserver

                        String ExceltempFile = System.IO.Path.GetDirectoryName(System.IO.Path.GetTempFileName().ToString());
                       // String ExceltempFile2 = "\\webstore1\\tier1_web2_dev$\\ll\\Reports'";
                        ExceltempFile = ExceltempFile + "\\" + ExcelFile.FileName.ToString();
                        ExcelFile.SaveAs(ExceltempFile);

                        string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ExceltempFile.ToString() + ";Extended Properties=\"Excel 8.0;HDR=YES\"";
                        OleDbConnection dbConn = new OleDbConnection(connectionString);

                        dbConn.Open();
                        //String sql = "Select * FROM " + ConfigurationManager.AppSettings["Upload"];
                        String sql = "Select * FROM [Upload$] ";
                        OleDbCommand cmd = new OleDbCommand(sql, dbConn);
                        DataSet ds = new DataSet();
                        OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                        da.Fill(ds);
                        dbConn.Close();
                        String Final_ll = "";
                        decimal row_counter = 0;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            DataRow x = dr;
                            PotentialLesson ll = new PotentialLesson();
                            ll.CurrentUser = LoginName;
                            ll.StatusId = 2; //This is to be in 'pending' mode.
                            ll.UserName = LoginName;

                            if ((dr["Lesson Learned Title"].ToString() != "") && (dr["LESSON LEARNED STATEMENT"].ToString() != ""))
                            {
                                try
                                {
                                    ll.Title = dr["LESSON LEARNED TITLE"].ToString();
                                    ll.Statement = dr["LESSON LEARNED STATEMENT"].ToString();
                                    ll.Background = dr["ADDITIONAL BACKGROUND"].ToString();
                                    ll.Response = dr["RECOMMENDATIONS"].ToString();
                                    ll.Reference = dr["REFERENCES"].ToString();
                                    ll.TypeId = 1;
                                    if (dr["CATEGORY"].ToString() != "")
                                    {
                                        ll.CategoryId = System.Decimal.Parse(dr["CATEGORY"].ToString());
                                    }
                                    if (dr["PRIORITY"].ToString() != "")
                                    {
                                        ll.ImpactId = System.Decimal.Parse(dr["PRIORITY"].ToString());
                                    } // Priority on the Input Screen }
                                    if (dr["IMPACT"].ToString() != "")
                                    {
                                        ll.FinancialImpactId = System.Decimal.Parse(dr["IMPACT"].ToString());
                                    }//Impact on the Input Screen }
                                    if (dr["FREQUENCY"].ToString() != "")
                                    {
                                        ll.FrequencyId = System.Decimal.Parse(dr["FREQUENCY"].ToString());
                                    }
                                    if (dr["SBU"].ToString() != "")
                                    {
                                        ll.SBUId = System.Decimal.Parse(dr["SBU"].ToString());
                                    }
                                    if (dr["BU"].ToString() != "")
                                    {
                                        ll.BUId = System.Decimal.Parse(dr["BU"].ToString());
                                    }
                                    if (dr["Project"].ToString() != "")
                                    {
                                        ll.ProjectId = System.Decimal.Parse(dr["Project"].ToString());
                                    }

                                    //RPP April 8, 2009
                                    //Making this Y will imput the data to table LL_POTENTIAL_INPUT, 
                                    //While setting it to N will input the data to table LL_POTENTIAL
                                    ll.ImportfromExcel = "N"; 

                                    ll.Save();
                                    Final_ll = ll.LLId.ToString();
                                    char[] separator = new char[] { ',' };

                                    if (dr["Phases"].ToString() != "")
                                    {
                                        String phases = dr["Phases"].ToString().TrimEnd(',');
                                        string[] aPhases = phases.Split(separator);

                                        foreach (string s in aPhases)
                                        {
                                            ll.StageId = System.Decimal.Parse(s.ToString());
                                            ll.SaveStageInfo();
                                        }
                                    }

                                    if (dr["Processes"].ToString() != "")
                                    {
                                        String processes = dr["Processes"].ToString().TrimEnd(',');
                                        String[] aProcesses = processes.Split(separator);

                                        foreach (string s in aProcesses)
                                        {
                                            ll.SubjectMatterId = decimal.Parse(s.ToString());
                                            ll.SaveSubjectMatterInfo();
                                        }
                                    }
                                    row_counter += 1;

                                }

                                catch (SystemException ex)
                                {
                                    throw new Backend.LLException("Failed to save document.", ex);
                                }

                            }
                        }

                        if (row_counter > 0)
                        {
                            //save document to the database
                            //RPP Oct 15, 2009 commented out due to Documentum being de-commissioned
                            //UploadtoDocumentum("Excel Input file", ExceltempFile.ToString(), ExcelFile.FileName.ToString(), Final_ll.ToString());
                            documentumFilename = ConfigurationManager.AppSettings["DocumentumCabinet"] + "/" + Final_ll.ToString() + "/" + ExcelFile.FileName.ToString();
                            //documentumFilename = ExceltempFile.ToString(); //rpp

                            //RPP Oct 15, 2009 commented out due to Documentum being de-commissioned
                            //this.lblMsg.Text = "You have successfully imported the Excel file. You have imported " + row_counter.ToString() + " rows. Your file has been saved in Documentum in the folder " + documentumFilename.ToString() + ".";
                            this.lblMsg.Text = "You have successfully imported the Excel file. You have imported " + row_counter.ToString() + " rows.";

                            if (this.cbGrid.Checked)
                            {
                                dgExcel.DataSource = ds;
                                dgExcel.DataBind();
                                dgExcel.Visible = true;
                                Page.DataBind();
                            }
                        }
                        else
                        {
                            this.lblMsg.Text = "There was a problem with your upload, 0 rows were imported into the database. Please ensure the template has not been modified.";
                        }
                        counter = "Y";
                    }
                    catch (SystemException ex)
                    {
                        throw new Backend.LLException("Failed to save document.", ex);
                    }
                }
            }
        }
    }
}
