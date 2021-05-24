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
    public class BulkSearchReportUtility : ReportUtilityBase
    {
      
        protected DataTable m_dt;

        ReportDocument Page1 = null;

        public BulkSearchReportUtility()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        protected override bool SetReportParameters()
        {
            ////SetFieldValue("LL_ID", m_ll_id.ToString());
            //SetPage1FieldValue(ref Page1, "LL_ID", m_ll_id.ToString());

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
                return new TypedDataSets.BulkSearch();
            }
        }

        protected override ReportDocument NewCrystalReportDocument
        {
            get
            {
                return new BulkSearch();
                
            }
        }
      
        public DataTable dtSearchResults
        {
            get
            {
                return m_dt;
            }
            set
            {
                m_dt = value;
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
          

            absolutePathFilename1 = reportPath;
          
            Page1 = NewCrystalReportDocument;
            DiskFileDestinationOptions destinationOptions = new DiskFileDestinationOptions();

            SetReportParameters();

            Page1.SetDataSource(dtSearchResults);
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
        }

    }

}


