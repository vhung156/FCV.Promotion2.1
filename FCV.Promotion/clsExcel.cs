using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace FCV.Promotion
{
    public class clsExcel
    {
        public static DataTable ReadExcel(string strFilePath,bool IsUpperCase = false)
        {
            if (File.Exists(strFilePath))
            {
                DataTable dtImport = null;
                if (System.IO.File.Exists(strFilePath))
                {
                    Workbook wb = new Workbook(strFilePath);
                    Worksheet worksheet = wb.Worksheets[0];

                    int iRowEnd = worksheet.Cells.MaxDataRow < 0 ? 1 : worksheet.Cells.MaxDataRow;
                    int iColEnd = worksheet.Cells.MaxDataColumn < 0 ? 1 : worksheet.Cells.MaxDataColumn;
                    int iRowHeader = worksheet.Cells.MinDataRow < 0 ? 1 : worksheet.Cells.MinDataRow;
                    int iColStart = worksheet.Cells.MinColumn;

                    DataTable dtImportCell = worksheet.Cells.ExportDataTable(iRowHeader, iColStart, iRowEnd, iColEnd);

                    dtImport = new DataTable();

                    //Tao cau truc bang
                    for (int i = 0; i <= iColEnd; i++)
                    {
                        string strColName = "Column" + i.ToString();

                        if (worksheet.Cells[iRowHeader, i].Value != null)
                        {
                            strColName = worksheet.Cells[iRowHeader, i].Value.ToString();
                        }

                        if (strColName.StartsWith("Ngay") || strColName.EndsWith("Ngay"))
                            dtImport.Columns.Add(strColName, typeof(DateTime));
                        
                            dtImport.Columns.Add(strColName, typeof(string));
                    }

                    //Dua du lieu vao: Duyet dong
                    for (int i = Convert.ToInt32(iRowHeader + 1); i <= iRowEnd; i++)
                    {
                        bool bRowNull = true;
                        DataRow drNew = dtImport.NewRow();

                        //Duyet Cot
                        for (int j = 0; j <= iColEnd; j++)
                        {
                            if (worksheet.Cells[i, j].Value != null)
                            {
                                string strColName = drNew.Table.Columns[j].ColumnName;

								try
								{
									if (strColName.StartsWith("NGAY") || strColName.EndsWith("NGAY"))
									{
										if (worksheet.Cells[i, j].Type == CellValueType.IsString)
											drNew[j] = worksheet.Cells[i, j].Value;
										else
											drNew[j] = worksheet.Cells[i, j].DateTimeValue;
									}
									else
									{
										drNew[j] = IsUpperCase == true ? worksheet.Cells[i, j].StringValue.ToUpper(): worksheet.Cells[i, j].StringValue;
									}
									bRowNull = false;
								}
								catch (Exception ex)
								{
									throw new Exception("Không nhận được dữ liệu [" + strColName + "] = " + worksheet.Cells[i, j].Value);
									//continue;
								}
                            }
                        }

                        if (!bRowNull)
                        {
                            dtImport.Rows.Add(drNew);
                        }
                    }
                }

                return dtImport;
            }

            return null;
        }

        public static DataTable ReadExcel(string strFilePath, int iSheet)
        {
            if (File.Exists(strFilePath))
            {
                DataTable dtImport = null;
                if (System.IO.File.Exists(strFilePath))
                {
                    Workbook wb = new Workbook(strFilePath);
                    Worksheet worksheet = wb.Worksheets[iSheet];

                    int iRowEnd = worksheet.Cells.MaxDataRow < 0 ? 1 : worksheet.Cells.MaxDataRow;
                    int iColEnd = worksheet.Cells.MaxDataColumn < 0 ? 1 : worksheet.Cells.MaxDataColumn;
                    int iRowHeader = worksheet.Cells.MinDataRow < 0 ? 1 : worksheet.Cells.MinDataRow;
                    int iColStart = worksheet.Cells.MinColumn;

                    DataTable dtImportCell = worksheet.Cells.ExportDataTable(iRowHeader, iColStart, iRowEnd, iColEnd);

                    dtImport = new DataTable();

                    //Tao cau truc bang
                    for (int i = 0; i <= iColEnd; i++)
                    {
                        string strColName = "Column" + i.ToString();

						

                        if (worksheet.Cells[iRowHeader, i].Value != null)
                        {
                            strColName = worksheet.Cells[iRowHeader, i].Value.ToString();
							if (dtImport.Columns.Contains(strColName))
								strColName += "0";
						}

                        if (strColName.StartsWith("Ngay") || strColName.EndsWith("Ngay"))
                            dtImport.Columns.Add(strColName, typeof(DateTime));
                        
                            dtImport.Columns.Add(strColName, typeof(string));
                    }

                    //Dua du lieu vao: Duyet dong
                    for (int i = Convert.ToInt32(iRowHeader + 1); i <= iRowEnd; i++)
                    {
                        bool bRowNull = true;
                        DataRow drNew = dtImport.NewRow();

                        //Duyet Cot
                        for (int j = 0; j <= iColEnd; j++)
                        {
                            if (worksheet.Cells[i, j].Value != null)
                            {
                                string strColName = drNew.Table.Columns[j].ColumnName;

                                try
                                {
                                    if (strColName.StartsWith("NGAY") || strColName.EndsWith("NGAY"))
                                    {
                                        if (worksheet.Cells[i, j].Type == CellValueType.IsString)
                                            drNew[j] = worksheet.Cells[i, j].Value;
                                        else
                                            drNew[j] = worksheet.Cells[i, j].DateTimeValue;
                                    }                                    
                                       drNew[j] = worksheet.Cells[i, j].StringValue;

                                    bRowNull = false;
                                }
                                catch (Exception ex)
                                {
                                    throw new Exception("Không nhận được dữ liệu [" + strColName + "] = " + worksheet.Cells[i, j].Value);
                                    continue;
                                }
                            }
                        }

                        if (!bRowNull)
                        {
                            dtImport.Rows.Add(drNew);
                        }
                    }
                }

                return dtImport;
            }

            return null;
        }

        public static DataSet ReadExcelToDataSet(string strFilePath)
        {
            DataSet dsOutPut= new DataSet();

            if (File.Exists(strFilePath))
            {
                DataTable dtImport = null;
                if (System.IO.File.Exists(strFilePath))
                {


                    Workbook wb = new Workbook(strFilePath);

                    for (int iSheet = 0; iSheet < wb.Worksheets.Count; iSheet++)
                    {
                        Worksheet worksheet = wb.Worksheets[iSheet];
                        string tbName = wb.Worksheets[iSheet].Name;
                        int iRowEnd = worksheet.Cells.MaxDataRow < 0 ? 1 : worksheet.Cells.MaxDataRow;
                        int iColEnd = worksheet.Cells.MaxDataColumn < 0 ? 1 : worksheet.Cells.MaxDataColumn;
                        int iRowHeader = worksheet.Cells.MinDataRow < 0 ? 1 : worksheet.Cells.MinDataRow;
                        int iColStart = worksheet.Cells.MinColumn;

                        DataTable dtImportCell = worksheet.Cells.ExportDataTable(iRowHeader, iColStart, iRowEnd, iColEnd);

                        dtImport = dsOutPut.Tables.Add(tbName);
                        dtImport.Namespace = tbName;

                        //Tao cau truc bang
                        for (int iC = 0; iC <= iColEnd; iC++)
                        {
                            string strColName = "Column" + iC.ToString();

                            if (worksheet.Cells[iRowHeader, iC].Value != null)
                            {
                                strColName = worksheet.Cells[iRowHeader, iC].Value.ToString();
                            }
							if(strColName.ToUpper().Contains("SUM"))
								dtImport.Columns.Add(strColName, typeof(double));
							else
							dtImport.Columns.Add(strColName, typeof(string));
                        }

                        //Dua du lieu vao: Duyet dong
                        for (int i = Convert.ToInt32(iRowHeader + 1); i <= iRowEnd; i++)
                        {
                            bool bRowNull = true;
                            DataRow drNew = dtImport.NewRow();

                            //Duyet Cot
                            for (int j = 0; j <= iColEnd; j++)
                            {
								if (worksheet.Cells[i, j].Value != null)
								{
									string strColName = drNew.Table.Columns[j].ColumnName;

									try
									{
										//if (strColName.StartsWith("NGAY") || strColName.EndsWith("NGAY"))
										//{
										//	if (worksheet.Cells[i, j].Type == CellValueType.IsString)
										//		drNew[j] = worksheet.Cells[i, j].Value;
										//	else
										//		drNew[j] = worksheet.Cells[i, j].DateTimeValue;
										//}
										if (strColName.ToUpper().Contains("SUM"))
										{
											if (worksheet.Cells[i, j].Type == CellValueType.IsString)
												drNew[j] = worksheet.Cells[i, j].Value;
											else
												drNew[j] = worksheet.Cells[i, j].DoubleValue;
										}
										else
											drNew[j] = worksheet.Cells[i, j].StringValue;
										bRowNull = false;
									}
									catch (Exception ex)
									{
										throw new Exception("Không nhận được dữ liệu [" + strColName + "] = " + worksheet.Cells[i, j].Value);
									}
								}
							}

                            if (!bRowNull)
                            {
                                dtImport.Rows.Add(drNew);
                            }
                        }

                        //dsOutPut.Tables.Add(dtImport);

                    }


                }

                return dsOutPut;
            }

            return null;
        }

        /// <summary>
        /// Export Excel from Datatable
        /// </summary>
        /// <param name="ExportControl"></param>
        /// <param name="strTitle"></param>
        /// <param name="strSubTitle"></param>
        /// <param name="strFileName"></param>
        /// <param name="strDestFont"></param>

        public static void ExportExcel(DataTable dtExport,string strFileName)
		{
			Workbook workbook = new Workbook();
			Worksheet wSheet = workbook.Worksheets[0];
			wSheet.Name =  dtExport.TableName;
			ImportTableOptions importOptions = new ImportTableOptions();
			importOptions.IsFieldNameShown = false;
			
			Range range = null;
			Style style = null;
			StyleFlag styleFlag = null;

			bool bOverwrite = true;
			if (System.IO.File.Exists(strFileName))
			{
				try
				{
					if (true)
					{
						System.IO.File.Delete(strFileName);
					}
					else
						bOverwrite = false;
				}
				catch (Exception ex)
				{					
					return;
				}
			}

			//DataTable dtExport;

			string[] lstColumnsID = null;
			string[] lstColumnsName = null;

			int iColLength, iRowLength, iNextRow = 0;
			int iBold = -1;
			int iCongThuc = -1;
			int iFore_Color = -1;
			int iBack_Color = -1;
			int iColor = -1;

			string strAddr1, strAddr2;
			iColLength = dtExport.Columns.Count;
			iRowLength = dtExport.Rows.Count;

			lstColumnsID = new string[iColLength];
			lstColumnsName = new string[iColLength];
			//Điền dữ liệu vào objColNames
			for (int i = 0; i < iColLength; i++)
			{
				
				lstColumnsID[i] = dtExport.Columns[i].ColumnName;
				lstColumnsName[i] = dtExport.Columns[i].ColumnName;
			}
			#region Create column header
			wSheet.Cells.ImportArray(lstColumnsName, iNextRow, 0, false);

			strAddr1 = wSheet.Cells[iNextRow, 0].Name;	
			strAddr2 = wSheet.Cells[iNextRow, iColLength - 1].Name;
			//strAddr2 = wSheet.Cells[dtExport.Rows.Count+1, iColLength - 1].Name;

			range = wSheet.Cells.CreateRange(strAddr1 + ":" + strAddr2);
			style = workbook.Styles[workbook.Styles.Add()];
			styleFlag = new StyleFlag();
			styleFlag.All = true;
			style.IsTextWrapped = true;
			style.Number = 49;
			//styleFlag.NumberFormat = true;
		
            #region ColumnName Bold and Center.
   //         style.VerticalAlignment = TextAlignmentType.Center;
			//style.HorizontalAlignment = TextAlignmentType.Center;
			//style.Font.IsBold = true;
            #endregion
   //       			
			range.ApplyStyle(style, styleFlag);			
			//End column header

			#endregion

			#region Formating the columns before polulating the data

			//style = workbook.Styles[workbook.Styles.Add()];
			styleFlag = new StyleFlag();
			styleFlag.All = true;
			

			iNextRow += 1;
			
			//End Format
			#endregion
			//workbook.Save(strFileName);
			//return;
			#region Polulating the data
			try
			{
				//style = workbook.Styles[workbook.Styles.Add()];
				strAddr1 = wSheet.Cells[iNextRow, 0].Name;
				strAddr2 = wSheet.Cells[dtExport.Rows.Count, iColLength - 1].Name;
				
				range = wSheet.Cells.CreateRange(strAddr1 + ":" + strAddr2);
				style.IsTextWrapped = false;
				style.Number = 49;
				range.ApplyStyle(style, styleFlag);

				DataView dvExport = dtExport.DefaultView;
				DataTable dtTemp = dvExport.ToTable(false, lstColumnsID);
				
				wSheet.Cells.ImportData(dtTemp, iNextRow, 0, importOptions);

				//Creating a range of cells starting from "A1" cell to 3rd column in a row				
			}

			catch (Exception ex)
			{
				throw new Exception("Có lỗi xảy ra: " + ex.Message);
			}

			#endregion

			wSheet.AutoFitRows();
			wSheet.AutoFitColumns();
			
			//Ghi file lên đĩa
			if (bOverwrite)
			{
				try
				{
					if (System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(strFileName)))
					{
						workbook.Save(strFileName);
					}
				}
				catch (Exception ex)
				{
					throw new Exception("Không thể kết xuất được dữ liệu!" + ex.ToString());
				}
			}
			
		}

		public static void ExportExcel(DataSet dsExport, string strFileName)
		{
			Workbook workbook = new Workbook();
			int isheet = 0;

			bool bOverwrite = true;
			if (System.IO.File.Exists(strFileName))
			{
				try
				{
					if (true)
					{
						System.IO.File.Delete(strFileName);
					}
					else
						bOverwrite = false;
				}
				catch (Exception ex)
				{
					return;
				}
			}
			foreach (DataTable dtExport in dsExport.Tables)
			{
				Worksheet wSheet;
				if (isheet == 0)
					wSheet = workbook.Worksheets[0];
				else
					wSheet = workbook.Worksheets[workbook.Worksheets.Add()];

				wSheet.Name = dtExport.TableName;

				ImportTableOptions importOptions = new ImportTableOptions();
				importOptions.IsFieldNameShown = false;

				Range range = null;
				Style style = null;
				StyleFlag styleFlag = null;

				

				//DataTable dtExport;

				string[] lstColumnsID = null;
				string[] lstColumnsName = null;

				int iColLength, iRowLength, iNextRow = 0;
				int iBold = -1;
				int iCongThuc = -1;
				int iFore_Color = -1;
				int iBack_Color = -1;
				int iColor = -1;

				string strAddr1, strAddr2;
				iColLength = dtExport.Columns.Count;
				iRowLength = dtExport.Rows.Count;

				lstColumnsID = new string[iColLength];
				lstColumnsName = new string[iColLength];
				//Điền dữ liệu vào objColNames
				for (int i = 0; i < iColLength; i++)
				{

					lstColumnsID[i] = dtExport.Columns[i].ColumnName;
					lstColumnsName[i] = dtExport.Columns[i].ColumnName;

				}
				#region Create column header
				wSheet.Cells.ImportArray(lstColumnsName, iNextRow, 0, false);

				strAddr1 = wSheet.Cells[iNextRow, 0].Name;
				strAddr2 = wSheet.Cells[iNextRow, iColLength - 1].Name;

				range = wSheet.Cells.CreateRange(strAddr1 + ":" + strAddr2);
				style = workbook.Styles[workbook.Styles.Add()];
				styleFlag = new StyleFlag();
				styleFlag.All = true;				
				//style.VerticalAlignment = TextAlignmentType.Center;
				//style.HorizontalAlignment = TextAlignmentType.Center;
				//style.Font.IsBold = true;

				style.IsTextWrapped = true;
				style.Number = 49;
				style.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
				style.Borders[BorderType.TopBorder].Color = Color.Black;
				style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
				style.Borders[BorderType.LeftBorder].Color = Color.Black;
				style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
				style.Borders[BorderType.BottomBorder].Color = Color.Black;
				style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
				style.Borders[BorderType.RightBorder].Color = Color.Black;

				range.ApplyStyle(style, styleFlag);
				//End column header

				#endregion

				#region Formating the columns before polulating the data

				style = workbook.Styles[workbook.Styles.Add()];
				styleFlag = new StyleFlag();
				styleFlag.All = true;
				iNextRow += 1;

				//End Format
				#endregion
				//workbook.Save(strFileName);
				//return;
				#region Polulating the data
				try
				{
					strAddr1 = wSheet.Cells[iNextRow, 0].Name;
					strAddr2 = wSheet.Cells[dtExport.Rows.Count, iColLength - 1].Name;

					range = wSheet.Cells.CreateRange(strAddr1 + ":" + strAddr2);
					style.IsTextWrapped = false;
					style.Number = 49;
					range.ApplyStyle(style, styleFlag);

					DataView dvExport = dtExport.DefaultView;
					DataTable dtTemp = dvExport.ToTable(false, lstColumnsID);
					wSheet.Cells.ImportData(dtTemp, iNextRow, 0, importOptions);

					//Creating a range of cells starting from "A1" cell to 3rd column in a row

					//range = wSheet.Cells.CreateRange(strAddr1 + ":" + strAddr2);
					//style = workbook.Styles[workbook.Styles.Add()];
					//styleFlag = new StyleFlag();
					//styleFlag.Borders = true;
					//style.Number = 49;
					//style.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
					//style.Borders[BorderType.TopBorder].Color = Color.Black;
					//style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
					//style.Borders[BorderType.LeftBorder].Color = Color.Black;
					//style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
					//style.Borders[BorderType.BottomBorder].Color = Color.Black;
					//style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
					//style.Borders[BorderType.RightBorder].Color = Color.Black;

					//range.ApplyStyle(style, styleFlag);

					//Format Bold
					if (dtExport.Columns.Contains("BOLD"))
					{
						DataRow[] arrFotmat = dtExport.Select("BOLD=TRUE");
						if (arrFotmat.Length != 0)
						{
							style = workbook.Styles[workbook.Styles.Add()];
							style.Font.IsBold = true;
							styleFlag = new StyleFlag();
							styleFlag.FontBold = true;
						}
					}
				}

				catch (Exception ex)
				{
					throw new Exception("Có lỗi xảy ra: " + ex.Message);
				}

				#endregion

				wSheet.AutoFitRows();
				wSheet.AutoFitColumns();
				isheet++;
			}
			//Ghi file lên đĩa
			if (bOverwrite)
			{
				try
				{
					if (System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(strFileName)))
					{
						//workbook.Settings.Password = "123";
						workbook.Save(strFileName);
					}
				}
				catch (Exception ex)
				{
					throw new Exception("Không thể kết xuất được dữ liệu!" + ex.ToString());
				}
			}

		}


		public static void ExportToCsvFile(DataTable dataTable, string filePath)
		{
			StringBuilder fileContent = new StringBuilder();

			foreach (var col in dataTable.Columns)
			{
				string sColumnName = col.ToString();

				if (sColumnName.Contains("\n"))
					fileContent.Append("\"" + col.ToString() + "\",");
				else
					fileContent.Append("" + col.ToString() + ",");
			}

			fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);

			foreach (DataRow dr in dataTable.Rows)
			{
				foreach (var column in dr.ItemArray)
				{
					//fileContent.Append("\"" + column.ToString() + "\",");
					fileContent.Append("" + column.ToString() + ",");
				}

				fileContent.Replace(",", System.Environment.NewLine, fileContent.Length - 1, 1);
			}

			System.IO.File.WriteAllText(filePath, fileContent.ToString());
		}
	}
	public class LicenseKeyAsposeCells
	{
		public const string Key =
			"PExpY2Vuc2U+DQogIDxEYXRhPg0KICAgIDxMaWNlbnNlZFRvPkFzcG9zZSBTY290bGFuZCB" +
			"UZWFtPC9MaWNlbnNlZFRvPg0KICAgIDxFbWFpbFRvPmJpbGx5Lmx1bmRpZUBhc3Bvc2UuY2" +
			"9tPC9FbWFpbFRvPg0KICAgIDxMaWNlbnNlVHlwZT5EZXZlbG9wZXIgT0VNPC9MaWNlbnNlV" +
			"HlwZT4NCiAgICA8TGljZW5zZU5vdGU+TGltaXRlZCB0byAxIGRldmVsb3BlciwgdW5saW1p" +
			"dGVkIHBoeXNpY2FsIGxvY2F0aW9uczwvTGljZW5zZU5vdGU+DQogICAgPE9yZGVySUQ+MTQ" +
			"wNDA4MDUyMzI0PC9PcmRlcklEPg0KICAgIDxVc2VySUQ+OTQyMzY8L1VzZXJJRD4NCiAgIC" +
			"A8T0VNPlRoaXMgaXMgYSByZWRpc3RyaWJ1dGFibGUgbGljZW5zZTwvT0VNPg0KICAgIDxQc" +
			"m9kdWN0cz4NCiAgICAgIDxQcm9kdWN0PkFzcG9zZS5Ub3RhbCBmb3IgLk5FVDwvUHJvZHVj" +
			"dD4NCiAgICA8L1Byb2R1Y3RzPg0KICAgIDxFZGl0aW9uVHlwZT5FbnRlcnByaXNlPC9FZGl" +
			"0aW9uVHlwZT4NCiAgICA8U2VyaWFsTnVtYmVyPjlhNTk1NDdjLTQxZjAtNDI4Yi1iYTcyLT" +
			"djNDM2OGYxNTFkNzwvU2VyaWFsTnVtYmVyPg0KICAgIDxTdWJzY3JpcHRpb25FeHBpcnk+M" +
			"jAxNTEyMzE8L1N1YnNjcmlwdGlvbkV4cGlyeT4NCiAgICA8TGljZW5zZVZlcnNpb24+My4w" +
			"PC9MaWNlbnNlVmVyc2lvbj4NCiAgICA8TGljZW5zZUluc3RydWN0aW9ucz5odHRwOi8vd3d" +
			"3LmFzcG9zZS5jb20vY29ycG9yYXRlL3B1cmNoYXNlL2xpY2Vuc2UtaW5zdHJ1Y3Rpb25zLm" +
			"FzcHg8L0xpY2Vuc2VJbnN0cnVjdGlvbnM+DQogIDwvRGF0YT4NCiAgPFNpZ25hdHVyZT5GT" +
			"zNQSHNibGdEdDhGNTlzTVQxbDFhbXlpOXFrMlY2RThkUWtJUDdMZFRKU3hEaWJORUZ1MXpP" +
			"aW5RYnFGZkt2L3J1dHR2Y3hvUk9rYzF0VWUwRHRPNmNQMVpmNkowVmVtZ1NZOGkvTFpFQ1R" +
			"Hc3pScUpWUVJaME1vVm5CaHVQQUprNWVsaTdmaFZjRjhoV2QzRTRYUTNMemZtSkN1YWoyTk" +
			"V0ZVJpNUhyZmc9PC9TaWduYXR1cmU+DQo8L0xpY2Vuc2U+";

		public static Stream LStream = (Stream)new MemoryStream(Convert.FromBase64String(Key));
	}
}
