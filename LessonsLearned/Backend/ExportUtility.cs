using System;
using System.IO;
using System.Data;
using System.Text;
namespace Backend
{
	/// <summary>
	/// Provides the ability to export system data to files for 
	/// use in software that does not understand XML.
	/// </summary>
	public class ExportUtility
	{
		public ExportUtility()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/// <summary>
		/// Exports a DataSet to a Comma Seperated Value file (csv) for user in 
		/// older version of Microsoft Office.  All DataTables in the dataset are 
		/// exported to a single file.
		/// </summary>
		/// <param name="ds">The DataSet to perform the export on</param>
		/// <param name="destPath">The folder path and filename for the exported file.</param>
		public void ExportDataSetToCSV(DataSet ds, string destPath)
		{
			//Validate our arguments.
			StreamWriter outCSV = null;
			StringBuilder line = null;
			int maxColumns = 0;
			
			if(ds == null)
			{
				throw new ArgumentException("Invalid DataSet provided, cannot be null", "ds");
			}

			if(ds.Tables.Count < 0)
			{
				throw new ArgumentException("Invalid DataSet.  DataSet must contain at least one DataTable", "ds");
			}

			if(destPath == string.Empty || !System.IO.Directory.Exists(Path.GetDirectoryName(destPath)))
			{
				throw new ArgumentException("Invalid folder specified", "destPath");
			}
			try
			{
				outCSV = new StreamWriter(destPath, false);
				
				foreach(DataTable dt in ds.Tables)
				{
					//Export the Header
					line = new StringBuilder();
					maxColumns = dt.Columns.Count;
					line.Append("\"");
					foreach(DataColumn col in dt.Columns)
					{
						line.Append(col.ColumnName);
						if(dt.Columns.IndexOf(col.ColumnName) < maxColumns - 1)
						{
							line.Append("\",\"");
						}
					}
					line.Append("\"");
					outCSV.WriteLine(line.ToString());
					
					//Export The Data, row by row column by column...
					foreach(DataRow dr in dt.Rows)
					{
						line = new StringBuilder();
						line.Append("\"");
						for(int counter = 0;counter < maxColumns;counter++)
						{
							line.Append(dr[counter].ToString().Replace(System.Environment.NewLine, " "));
							if(counter != maxColumns - 1)
							{
								line.Append("\",\"");
							}
						}
						line.Append("\"");
						outCSV.WriteLine(line);
					}
				}
			}
			catch(IOException ex)
			{
				//Perculate the error up the call stack....
				throw ex;
			}
			catch(Exception ex)
			{
				//Perculate the error up the call stack....
				throw ex;
			}
			finally
			{
				if(outCSV != null)
				{
					outCSV.Close();
					outCSV = null; //Just return to known state.
				}
			}
		}
	}
}
