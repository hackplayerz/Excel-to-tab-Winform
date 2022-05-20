using System;
using System.IO;
using System.Data;
using Excel;
using ExcelToTab;

namespace ExcelToTabText
{
	public class ExcelDataReader
	{
		public static DataRow[] GetExcelSheetDataRow (string path, string sheetName, out int rowCount, out int colCount)
		{
			DataTable dataTable = GetDataTable (path, sheetName);
            		if (dataTable == null)
            		{
                		rowCount = -1;
                		colCount = -1;
                		return null;
            		}
			DataRow[] dataRows = dataTable.Select ();

			rowCount = dataTable.Rows.Count;
			colCount = dataTable.Columns.Count;
			return dataRows;
		}

		public static string[] GetSheetNames(string path) 
		{
			using (FileStream stream = File.Open (path, FileMode.Open, FileAccess.Read)) 
			{
				IExcelDataReader reader = null;
				try
                		{
                    			if (path.EndsWith(".xls"))
                        		reader = ExcelReaderFactory.CreateBinaryReader(stream);
					else if (path.EndsWith (".xlsx"))
						reader = ExcelReaderFactory.CreateOpenXmlReader (stream);

					var workbook = reader.AsDataSet ();
					string[] sheets = new string[workbook.Tables.Count];
					for(int i = 0; i < workbook.Tables.Count; i++) 
					{
						sheets[i] = workbook.Tables[i].TableName;
					}
					return sheets;
				} 
				catch (Exception e) 
				{
					Console.WriteLine (e.ToString ());
					throw;
				} 
				finally 
				{
					reader.Close ();
				}
			}
		}

		private static DataTable GetDataTable (string path, string sheetName)
		{
			using (FileStream stream = File.Open (path, FileMode.Open, FileAccess.Read))
            		{
				IExcelDataReader reader = null;
				try
                		{
					if (path.EndsWith (".xls"))
						reader = ExcelReaderFactory.CreateBinaryReader (stream);
					else if (path.EndsWith (".xlsx"))
						reader = ExcelReaderFactory.CreateOpenXmlReader (stream);

					var workbook = reader.AsDataSet ();
					var sheet = workbook.Tables [sheetName];
					return sheet;
				}
                		catch (Exception e)
                		{
					var popUp  = new PopupOk();
                    			popUp.SetInfoText(e.ToString());
                    			popUp.Show();
					throw;
				}
                		finally
                		{
                    			reader.Close ();
				}
			}
		}
	}
}

