using System;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using PetroCanada.CorpExec.DataAccess;
using Backend.DataAccess;
//using Website;
using System.IO;
using System.Web;
using System.Text;
using System.Collections;
using System.Configuration;

namespace Backend.Reporting
{
	/// <summary>
	/// Summary description for ReportUtilityBase.
	/// </summary>
	/// 
	[Serializable]
	public abstract class ReportUtilityBase
	{
		[System.NonSerialized]
		private DataAccessConnection m_dataAccessConnection = null;
		[System.NonSerialized]
		private ReportDocument m_crystalReportDocument = null;
		private BrowserExportType m_contentType;
		/// <summary>
		/// The number of miliseconds that the visual processing report
		/// report page will "sleep" waiting on the report to complete 
		/// processing.  The default is 500 miliseconds.
		/// </summary>
		protected int _processingWaitDelay = 500;

		protected Hashtable m_reportParameters = new Hashtable();

		public virtual int ProcessingWaitDelay
		{
			get
			{
				return _processingWaitDelay;
			}
		}

		/// <summary>
		/// This property must be overriden to return an empty typed dataset 
		/// of the type used to create the report.
		/// </summary>
		public abstract DataSet EmptyReportDataSet
		{
			get;
		}

		/// <summary>
		/// Returns a new instance of the appropriate crystal report document.
		/// </summary>
		protected abstract ReportDocument NewCrystalReportDocument
		{
			get;
		}

		public ReportUtilityBase()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		
		public abstract string ReportName
		{
			get;
		}

		/// <summary>
		/// Returns an arraylist of all assigned report parameters.  This
		/// routine is intended to be used by visual objects to display a list
		/// all report parameters that have been set.
		/// </summary>
		/// <returns></returns>
		public virtual ArrayList GetReportParameters()
		{
			ArrayList values = new ArrayList();
			string value = string.Empty;
			foreach(string key in m_reportParameters.Keys)
			{
				if(m_reportParameters[key].GetType().IsInstanceOfType(typeof(DateTime)))
				{
					value = ((DateTime)m_reportParameters[key]).ToString("{0:mm/dd/yyyy}");
				}
				else
				{
					value = m_reportParameters[key].ToString();
				}

				values.Add(key + ": " + value);
			}
			return values;
		}

		protected abstract bool SetReportParameters();

		protected DataAccessConnection DataAccess
		{
			get
			{
				if (m_dataAccessConnection == null)
				{
					m_dataAccessConnection = DataAccessUtil.GetDataAccessObject();
				}
				return m_dataAccessConnection;
			}
			set
			{
				m_dataAccessConnection = value;
			}
		}
		/// <summary>
		/// Returns a connected database connection.  The database
		/// connection will be of the correct instanciated connection
		/// i.e. OleDbConnection if using OLEDB Dataproviders.
		/// cjs July 2002
		/// </summary>
		protected IDbConnection DBConnection
		{
			get
			{
				//The DataAccessConnection takes care of all of the house
				//keeping to create and establish a connection.
				return DataAccess.Connection;
			}
		}

		public virtual void Dispose()
		{
			if (m_dataAccessConnection != null)
				m_dataAccessConnection.Dispose();

			if(m_crystalReportDocument != null)
			{
				m_crystalReportDocument.Dispose();
			}

			GC.SuppressFinalize(this);

		}

		/// <summary>
		/// This property must be overriden to return a valid select command
		/// that will be used to fill the typed dataset for the report
		/// </summary>
		protected abstract IDbCommand ReportSelectCommand
		{
			get;
		}
		
		public BrowserExportType BrowserContentType
		{
			get
			{
				return m_contentType;
			}
			set
			{
				m_contentType = value;
			}
		}

		public ReportDocument CrystalReportDocument
		{
			get
			{
				if (m_crystalReportDocument == null)
				{
					m_crystalReportDocument = NewCrystalReportDocument;
				}
				return m_crystalReportDocument;
			}
		}

        protected virtual ReportDocument PopulateSubreportData(ReportDocument mainreport)
        {

                return mainreport;
          
        }


		protected virtual DataSet ReportData
		{
			get
			{
				ICustomDataAdapter customDataAdapter = null;
				customDataAdapter = DataAccess.GetCustomDataAdapter();
				DataSet ds = EmptyReportDataSet;
				try
				{
					System.Diagnostics.Trace.WriteLine(this.ReportName + " Report aquire data for report started at: " + DateTime.Now.ToLongTimeString());
					customDataAdapter.SelectCommand = ReportSelectCommand;
					customDataAdapter.Fill(ds.Tables[0]);
                    //customDataAdapter.Fill(ds);
					System.Diagnostics.Trace.WriteLine(this.ReportName + " Report aquire data for report completed at: " + DateTime.Now.ToLongTimeString());
				}
				catch(Exception ex)
				{
					//Just throw the exception up the stack
					throw ex;
				}
				finally
				{
					//Clean up the connection provider so that connection is 
					//always cleaned up
					if (customDataAdapter != null)
						customDataAdapter.Dispose();

					if (m_dataAccessConnection != null)
					{
						m_dataAccessConnection.Dispose();
						m_dataAccessConnection = null;
					}
						
				}
				return ds;
			}
		}

		/// <summary>
		/// Exports the report data to a comma seperated value file (csv)
		/// </summary>
		/// <param name="reportPath">The folder and file name complete path to where the report data
		/// is to be exported to</param>
		protected virtual void ExportCSVReport(string reportPath)
		{
			ExportUtility exp = new ExportUtility();
			try
			{
				SetReportParameters();
				exp.ExportDataSetToCSV(ReportData, reportPath);
			}
			catch(Exception ex)
			{
				throw new ApplicationException("An unexpected error occurred trying to export the report: " + ex.ToString(), ex);
			}
		}

		/// <summary>
		/// Export the report in PDF format
		/// </summary>
		/// <param name="reportPath"></param>
		public virtual void ExportReport(string reportPath)
		{
			switch (m_contentType)
			{
				case BrowserExportType.CSV:
					ExportCSVReport(reportPath);
					break;
				case BrowserExportType.Excel:
					ExportExcelReport(reportPath);
					break;
				case BrowserExportType.PDF:
					ExportPDFReport(reportPath);
					break;
			}
		}

		/// <summary>
		/// Export the report in Excel Format
		/// </summary>
		/// <param name="reportPath"></param>
		protected virtual void ExportExcelReport(string reportPath)
		{
			//SetReportParameters();
			ExportReportUsingCrystal(reportPath, ExportFormatType.Excel);
		}
		
		protected virtual void ExportPDFReport(string reportPath)
		{
//			SetReportParameters();
			ExportReportUsingCrystal(reportPath, ExportFormatType.PortableDocFormat);
		}

        protected virtual void ExportReportUsingCrystal(string reportPath, ExportFormatType reportType)
		{
		
			DiskFileDestinationOptions destinationOptions = new DiskFileDestinationOptions();
			destinationOptions.DiskFileName = reportPath;

           //CrystalReportDocument.set
           //CrystalReportDocument.SetDatabaseLogon("loc", "winter08", "CTS_DEVL", null,true);
           

			CrystalReportDocument.SetDataSource(ReportData);
            if (CrystalReportDocument.Subreports.Count > 0)
            {
                PopulateSubreportData(CrystalReportDocument);
            }
            
            SetReportParameters();

            //Set the datasource for the report
            CrystalReportDocument.ExportOptions.DestinationOptions = destinationOptions;
            CrystalReportDocument.ExportOptions.ExportFormatType = reportType;
            CrystalReportDocument.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
			//Assign the export options so we can export to pdf file
			//destinationOptions.DiskFileName = reportPath;
			
			//Export the report
			try
			{ 
                //CrystalReportDocument.SetDatabaseLogon
                //CrystalReportDocument.ExportToStream(CrystalReportDocument.ExportOptions.ExportFormatType);
				CrystalReportDocument.Export();
			}
			catch(Exception ex)
			{
				throw new ApplicationException("An unexpected error occurred trying to export the report: " + ex.ToString());
			}
		}

		/// <summary>
		/// Sets a parameter (field value) on the report.  This allows us to pass
		/// parameters in to the report (to be displayed or used to make display
		/// decisions or calculations...etc...). 
		/// </summary>
		/// <param name="fieldName"></param>
		/// <param name="value"></param>
		protected void SetFieldValue(string fieldName, object value)
		{
			ParameterFieldDefinition paramField;
			ParameterValues values = new ParameterValues();
			paramField = CrystalReportDocument.DataDefinition.ParameterFields[fieldName];
			ParameterDiscreteValue paramValue = new ParameterDiscreteValue();
			paramValue.Value = value;
			values.Add(paramValue);
			paramField.ApplyCurrentValues(values);
		}

		/// <summary>
		/// Parses a user entered set of numbers that are separated by commas and 
		/// that may include ranges (e.g. 5,7,10-15, 18) and returns a comma
		/// separated string that includes all of the numbers in all of the ranges etc.
		/// (i.e. for the previous example: 5,7,10,11,12,13,14,15,18)
		/// NOTE: if a range has multiple "-" symbols in it just the first an last
		/// numbers specified are used to build the range, and the middle values
		/// will be ignored (e.g. 5-7-9 will return: 5,6,7,8,9 
		///					  and 5-9-7 will return: 5,6,7)
		/// </summary>
		/// <param name="numbers"></param>
		/// <returns></returns>
		protected string ParseNumbersAndRangesToCommaSeparatedList(string numbers) 
		{
			string[] commaSeparated = null;
			string[] range = null;
			StringBuilder finalList = new StringBuilder();
			string returnString = string.Empty;
			int startRange = 0;
			int endRange = 0;

			commaSeparated = numbers.Split(',');
			 
			for (int i=0; i<commaSeparated.Length; i++)
			{
				range = commaSeparated[i].Split('-');
				//check if there are multiple values
				if (range.Length > 1 )
				{
					//There are multiple values, so just take the first and last
					//values in the array and build the range
					startRange = int.Parse(range[range.GetLowerBound(0)]);
					endRange = int.Parse(range[range.GetUpperBound(0)]);

					//If the range is regressive, swap the two numbers
					if (startRange>endRange)
					{
						int temp = startRange;
						startRange = endRange;
						endRange = startRange;
					}

					//Add each number in the range to the finalList
					for (int k = startRange; k <= endRange; k++)
					{
						finalList.Append(k.ToString() + ",");
					}
				}
				else
				{
					//There is only one value so there is no range, just a number
					//so add it to the finalList 
					finalList.Append(range[0] + ",");
				}
			}

			//If the list has more than one value then trim the last comma
			if (finalList.ToString().Trim().Length > 1)
			{
				finalList.Remove(finalList.Length - 1, 1);
			}

			return finalList.ToString();

		}

		public DateTime GetPreviousWeekday(DateTime inputDate)
		{
			//Get the previous day
			inputDate = inputDate.AddDays(-1);

			//if the day is a sunday or saturday we keep subtracting days
			while (inputDate.DayOfWeek == DayOfWeek.Sunday || inputDate.DayOfWeek == DayOfWeek.Saturday)
			{
				inputDate = inputDate.AddDays(-1);
			}

			return inputDate;
		}

		
	}
}
