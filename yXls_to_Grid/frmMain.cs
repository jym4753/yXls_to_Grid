using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace yXls_to_Grid
{
	public partial class frmMain : Form
	{
		List<string> listFiles = null;
		List<string[]> listValues = null;

		Excel.Application xApp = null;
		Excel.Workbook xWorkbook = null;
		Excel.Worksheet xWorksheet = null;
		Excel.Range xRange = null;

		public frmMain()
		{
			InitializeComponent();
		}
		private void frmMain_Load(object sender, EventArgs e)
		{
			txtPath.Text = @"D:\programs\cs\doc";
		}
		private void btnRun_Click(object sender, EventArgs e)
		{
			xApp = new Excel.Application();

			//xls 파일 목록 가져오기
			string folderName = txtPath.Text;

			listFiles = new List<string>();
			System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(folderName);
			foreach (System.IO.FileInfo file in di.GetFiles())
			{
				if (file.Extension.ToLower().CompareTo(".xls") == 0)
				{
					listFiles.Add(file.FullName);
				}
			}

			//xls 파일목록에서 데이터 읽기
			listValues = new List<string[]>();
			foreach (string filepath in listFiles)
			{
				try
				{
					xWorkbook = xApp.Workbooks.Open(filepath, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
					xWorksheet = xWorkbook.Worksheets.get_Item("Sheet1") as Excel.Worksheet;
					xApp.Visible = false;

					xRange = xWorksheet.get_Range("C2:C7");
					object[,] data = xRange.Value;
					for (int r = 1; r <= data.GetLength(1); r++)
					{
						List<string> values = new List<string>();
						for (int c = 1; c <= data.GetLength(0); c++)
						{
							string item = string.Empty;

							if (data[c, r] != null)
							{
								item = data[c, r].ToString();
							}

							values.Add(item);
						}
						listValues.Add(values.ToArray());
					}
				}
				finally
				{
					xWorkbook.Close(true);
					xApp.Quit();

					ReleaseExcelObject(xWorksheet);
					ReleaseExcelObject(xWorkbook);
				}
			}

			//데이터 Table에 쓰기
			DataTable dt = ConvertListToDataTable(listValues);
			dtResult.DataSource = dt;

			ReleaseExcelObject(xApp);

		}
		private static void ReleaseExcelObject(object obj)
		{
			try
			{
				if (obj != null)
				{
					System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
					obj = null;
				}
			}
			catch (Exception ex)
			{
				obj = null;
				throw ex;
			}
			finally
			{
				GC.Collect();
			}
		}
		static DataTable ConvertListToDataTable(List<string[]> list)
		{
			// New table.
			DataTable table = new DataTable();

			// Get max columns.
			int columns = 0;
			foreach (var array in list)
			{
				if (array.Length > columns)
				{
					columns = array.Length;
				}
			}

			// Add columns.
			for (int i = 0; i < columns; i++)
			{
				table.Columns.Add();
			}

			// Add rows.
			foreach (var array in list)
			{
				table.Rows.Add(array);
			}

			return table;
		}

		
	}
}
