using System;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Configuration;
using PetroCanada.CorpExec.DataAccess;
using Backend.DataAccess;
using System.Diagnostics;
using System.IO;


namespace Backend.Reporting
{
    /// <summary>
    /// Summary description for AuditAccessUtility.
    /// </summary>
    [Serializable]
    public class LessonLearnedUtility : ReportUtilityBase
    {
        protected String m_ll_id    = string.Empty;
        ReportDocument Page1 = null;

        public LessonLearnedUtility()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        protected override bool SetReportParameters()
        {
            //SetFieldValue("LL_ID", m_ll_id.ToString());
            SetPage1FieldValue(ref Page1, "LL_ID", m_ll_id.ToString());

            return true;
        }

        protected void SetPage1FieldValue(ref ReportDocument doc, string fieldName, object value)
        {
            ParameterFieldDefinition paramField;
            ParameterValues values = new ParameterValues();
            paramField = doc.DataDefinition.ParameterFields[fieldName];
            ParameterDiscreteValue paramValue = new ParameterDiscreteValue();
            paramValue.Value = value;
            values.Add(paramValue);
            paramField.ApplyCurrentValues(values);

            try
            {
                if (doc.Subreports.Count > 0)
                {
                    ParameterFieldDefinition subParamField;
                    ParameterValues subValues = new ParameterValues();
                    subParamField = doc.Subreports[0].DataDefinition.ParameterFields[fieldName];
                    ParameterDiscreteValue subParamValue = new ParameterDiscreteValue();
                    subParamValue.Value = value;
                    subValues.Add(subParamValue);
                    subParamField.ApplyCurrentValues(subValues);
                }
            }
            catch { };
        }

        public override string ReportName
        {
            get
            {
                return "Lesson Learned";
            }
        }

        public override DataSet EmptyReportDataSet
        {
            get
            {
                //Call the stored proc
                return new TypedDataSets.SysDate();
            }
        }

        protected override ReportDocument NewCrystalReportDocument
        {
            get
            {
                return new LessonLearned();
                
            }
        }
        public object LL_ID
        {
            get
            {
                return m_ll_id;
            }
            set
            {
                m_ll_id = value.ToString();
            }
        }
        protected override IDbCommand ReportSelectCommand
        {
            get
            {
                IDbCommand cmd;
              
                cmd = DBConnection.CreateCommand();
                cmd.CommandText = "SELECT sysdate from dual";
                cmd.CommandType = CommandType.Text;
                return cmd;

            }
        }

        protected override void ExportReportUsingCrystal(string reportPath, ExportFormatType reportType)
        {
            string absolutePathFilename1 = string.Empty;
            //string absolutePathFilename2 = string.Empty;
            //string absolutePathFilename3 = string.Empty;
            //string absolutePathFilename4 = string.Empty;
            //string absolutePathFilename5 = string.Empty;

            absolutePathFilename1 = reportPath;
            //absolutePathFilename1 = System.IO.Path.GetTempFileName();
            //absolutePathFilename2 = System.IO.Path.GetTempFileName();
            //absolutePathFilename3 = System.IO.Path.GetTempFileName();
            //absolutePathFilename4 = System.IO.Path.GetTempFileName();
            //absolutePathFilename5 = System.IO.Path.GetTempFileName();

            Page1 = new LessonLearned();
            //Page2 = new OutstandingLCAnalysis2();
            //Page3 = new SyndicatedCreditFacilitiesStatus3();
            //Page4 = new DemandCreditFacilitiesStatus4();
            //Page5 = new SignoffPage5();

            DiskFileDestinationOptions destinationOptions = new DiskFileDestinationOptions();

            CrystalDecisions.Shared.TableLogOnInfo
            myLogin = new CrystalDecisions.Shared.TableLogOnInfo();
            myLogin.ConnectionInfo.UserID = ConfigurationManager.AppSettings["CrystalUser"];
            myLogin.ConnectionInfo.Password = ConfigurationManager.AppSettings["CrystalPassword"];
            myLogin.ConnectionInfo.DatabaseName = "";
            myLogin.ConnectionInfo.ServerName = ConfigurationManager.AppSettings["CrystalDB"];

           

            for (int i = 0; i < Page1.Database.Tables.Count; i++)
            {
                Page1.Database.Tables[i].ApplyLogOnInfo(myLogin);
            }

            SetReportParameters();

            Page1.ExportOptions.ExportFormatType = reportType;
            Page1.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            try
            {
                destinationOptions.DiskFileName = absolutePathFilename1;
                Page1.ExportOptions.DestinationOptions = destinationOptions;
                Page1.Export();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An unexpected error occurred trying to export the report: " + ex.ToString());
            }
            finally
            {
                //if (System.IO.File.Exists(absolutePathFilename1))
                //    System.IO.File.Delete(absolutePathFilename1);
            }
            //rpp CrystalReportDocument.SetDataSource(ReportData);
            //if (CrystalReportDocument.Subreports.Count > 0)
            //{
            //    PopulateSubreportData(CrystalReportDocument);
            //}

            //Set the datasource for the report
            //CrystalReportDocument.ExportOptions.DestinationOptions = destinationOptions;
            //CrystalReportDocument.ExportOptions.ExportFormatType = reportType;
            //CrystalReportDocument.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            //Assign the export options so we can export to pdf file
            //destinationOptions.DiskFileName = reportPath;

            //Export the report
            //try
            //{
            //    //CrystalReportDocument.SetDatabaseLogon
            //    //CrystalReportDocument.ExportToStream(CrystalReportDocument.ExportOptions.ExportFormatType);
            //    CrystalReportDocument.Export();
            //}
            //catch (Exception ex)
            //{
            //    throw new ApplicationException("An unexpected error occurred trying to export the report: " + ex.ToString());
            //}

        }

    }

}


