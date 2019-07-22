/*
 * Code by : Dev.alter0
 * github.com/hackplayerz
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelToTabText;

namespace ExcelToTab
{
    public partial class Form1 : Form
    {
        private string _fileName = string.Empty; // xlsx file name with path
        private bool _isLoadAllSheet = true; // Option radio button data
        public Form1()
        {
            InitializeComponent();
        }


        private void Button_loadExcelFile_Click(object sender, EventArgs e)
        {
            // Set File dialog
            var openFile = new OpenFileDialog
            {
                InitialDirectory = Application.StartupPath,
                FileName = "*.xlsx",
                Filter = @"xlsx files (*.xlsx)|*.xlsx|All files (*.*)|*.*"
            };
            // If get all data Radio button checked, true
            _isLoadAllSheet = radioButton_allData.Checked;
            // if export sheet data is empty, open popup and return
            if (!_isLoadAllSheet && string.IsNullOrEmpty(textBox_exportSheet.Text))
            {
                var popup = new PopupOk();
                popup.SetInfoText("Sheet name is null");
                popup.Show();
                return;
            }

            var isReady = openFile.ShowDialog();

            // Load Finish
            if (isReady == DialogResult.OK)
            {
                _fileName = openFile.FileName;
                // Save All Sheet
                if (_isLoadAllSheet)
                {
                    string[] sheetNames = ExcelDataReader.GetSheetNames(_fileName);
                    foreach (string str in sheetNames)
                    {
                        string[] tokens = str.Split('_');
                        // Skip comment
                        if (tokens[0].Equals("#"))
                        {
                            continue;
                        }
                        // Create txt file
                        ExportExcelToTabText(_fileName, str);
                        // Open complete information
                        var popup = new PopupOk();
                        popup.SetInfoText(@"Export Complete : " + str);
                        popup.Show();
                    }
                }

                // Save Selected sheet
                else
                {
                    var sheetName = textBox_exportSheet.Text; // Exported file name,will be sheet name
                    var result = ExportExcelToTabText(_fileName, sheetName); // Export Complete : result is true
                    if (result)
                    {
                        var popup = new PopupOk();
                        popup.SetInfoText(@"Export Complete : <Sheet> " + sheetName);
                        popup.Show();
                    }
                }

            }
            openFile.Dispose();
        }

        /// <summary>
        /// Export to txt file 
        /// </summary>
        /// <param name="file">File name with path</param>
        /// <param name="sheetName">To export sheet name</param>
        /// <returns>Export Complete,return true</returns>
        private static bool ExportExcelToTabText(string file, string sheetName)
        {
            var output = sheetName + ".txt"; // Export file name
            /*StreamWriter sw = null;
			try
			{
				path = "./" + Path.GetFileNameWithoutExtension(file) + "/text";
				DirectoryInfo directory = new DirectoryInfo(path);
				if (!directory.Exists)
				{
					directory.Create();
				}

				sw = new StreamWriter(path + "/" + output);
			}
			catch (Exception execption)
			{
				System.Console.WriteLine(execption.ToString());
				return;
			}*/

            DataRow[] dataRow = ExcelDataReader.GetExcelSheetDataRow(file, sheetName, out var rowCount, out var colCount);

            // Can't read file exception
            if (dataRow == null || rowCount < 0 || colCount < 0) 
            {
                var popup = new PopupOk();
                popup.SetInfoText("Can't find Sheet : " + sheetName);
                popup.Show();
                return false;
            }

            var sb = new StringBuilder();

            BinaryWriter binaryWriter = null;
            FileStream fileStream = null;

            try
            {
                var path = "./" + Path.GetFileNameWithoutExtension(file) + "/text";
                var directory = new DirectoryInfo(path);

                // If already directory exist, delete and recreate directory
                if (!directory.Exists)
                {
                    directory.Create();
                }

                fileStream = new FileStream(path + "/" + output, FileMode.Create);
                binaryWriter = new BinaryWriter(fileStream);
            }
            catch (Exception execption)
            {
                System.Console.WriteLine(execption.ToString());
                return false;
            }

            binaryWriter.Write(rowCount);
            binaryWriter.Write(colCount);

            for (int i = 0; i < rowCount; i++)
            {
                string[] rowData = ObjectArrayToStringArray(dataRow[i].ItemArray);

                for (int j = 0; j < colCount; j++)
                {
                    sb.Append("\t");

                    if (rowData[j].Length == 0)
                    {
                        rowData[j] = " ";
                    }

                    sb.Append(rowData[j]);
                }
                sb.AppendLine();
            }

            //sw.Write(sb.ToString());
            //sw.Close();
            binaryWriter.Write(sb.ToString());
            binaryWriter.Close();
            fileStream.Close();

            return true;
        }

        private static string[] ObjectArrayToStringArray(object[] objectArray)
        {
            var stringArray = new string[objectArray.Length];
            for (int i = 0; i < objectArray.Length; i++)
            {
                stringArray[i] = objectArray[i].ToString();
            }
            return stringArray;
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }
}
