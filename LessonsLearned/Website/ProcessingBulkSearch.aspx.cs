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
using System.IO;
using Backend.Reporting;

namespace Website
{
    public partial class ProcessingBulkSearch : System.Web.UI.Page
    {
        protected TextBox txtTest;
        protected ReportUtilityBase _reportUtility = null;
        string relativePathFilename = string.Empty;
        string absolutePathFilename = string.Empty;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
           
        }

        protected override void OnInit(EventArgs e)
        {
            InitializeComponent();
            //base.OnInit(e);
        }

        private void InitializeComponent()
        {
            //this.Load += new System.EventHandler(this.Page_Load);
        }


        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {

            BulkSearchReportUtility _reportUtility = new BulkSearchReportUtility();

            _reportUtility.dtSearchResults = (DataTable)Session[Global.Parameters.SearchResults];
            _reportUtility.BrowserContentType = BrowserExportType.PDF;
            string fileName = string.Empty;
            string errorException = string.Empty;
            string contentType = string.Empty;
            string extension = string.Empty;

            string filePath = string.Empty;
            string pathFilename = string.Empty;

            try
            {
                if (_reportUtility != null)
                {
                    switch (_reportUtility.BrowserContentType)
                    {
                        case BrowserExportType.Excel:
                            FileNamingUtility.GetExcelFilename(Page.Session, ref absolutePathFilename, ref relativePathFilename);
                            contentType = "application/vnd.ms-excel";
                            extension = ".xls";
                            break;
                        case BrowserExportType.PDF:
                            FileNamingUtility.GetAcrobatFilename(Page.Session, ref absolutePathFilename, ref relativePathFilename);
                            contentType = "application/pdf";
                            extension = ".pdf";
                            break;
                        case BrowserExportType.CSV:
                            FileNamingUtility.GetCsvFileName(Page.Session, ref absolutePathFilename, ref relativePathFilename);
                            //contentType = "application/vnd.ms-excel";
                            contentType = "application/csv";
                            extension = ".csv";
                            break;
                        default:
                            throw new ApplicationException("Unknown Export Type selected for the the BrowserContentType on the ReportUtility.  Unable to run the report");
                    }

                    filePath = absolutePathFilename.Substring(0, absolutePathFilename.Length - 4);
                    pathFilename = filePath + extension;
                    File.Delete(absolutePathFilename); //Make sure we delete the 0 byte file created when we get the tmp file name
                    absolutePathFilename = filePath;
                    fileName = Path.GetFileName(pathFilename);

                    _reportUtility.ExportReport(absolutePathFilename);
                    //Don't buffer the response stream, we will send it to the client
                    //so ASP.Net does not get mistaken as being deadlocked.
                    Response.Buffer = false;

                    //only need file name in Header
                    Response.AddHeader("Content-Disposition", "inline; filename=\"" + fileName.Replace(@"files\", "") + "\"");
                    Response.ContentType = contentType;

                    //Stream the file.
                    Response.ClearContent();

                    //Ensure that we send the headers before we send the actual file.
                    Response.WriteFile(absolutePathFilename);
                    Response.Flush();

                    if (File.Exists(absolutePathFilename))
                        File.Delete(absolutePathFilename);

                    Response.Close();
                }
            }
            catch (Exception)
            {
                base.Render(writer);
            }
            finally
            {
                _reportUtility.Dispose();
                // Session.Remove(stringReportID);
            }



        }  
    
    }
}
