using LoadSiteExcelToMongo.Model;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace LoadSiteExcelToMongo.Action
{
    public class ReadFileExcelAction
    {

        public List<DataExcelModel> ReadFileExcel(string path)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(path);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!

            List<DataExcelModel> list = new List<DataExcelModel>();

            Console.WriteLine("start convert");

            for (int i = 2; i <= rowCount; i++)
            {
                DataExcelModel el = null;
                bool isCreate = false;
                if(list.Count  ==  0)
                {
                    el = new DataExcelModel();
                    el.list = new List<Channel>();
                    isCreate = true;
                }
                else if (list[list.Count - 1].SiteId != xlRange.Cells[i, 3].Value2.ToString())
                {
                    el = new DataExcelModel();
                    el.list = new List<Channel>();
                    isCreate = true;
                }

                Channel elc = new Channel();

                if(isCreate == true)
                {
                    for (int j = 2; j <= colCount; j++)
                    {
                        //write the value to the console
                        if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                        {
                            if (j == 2)
                            {
                                el.SiteName = xlRange.Cells[i, j].Value2.ToString();
                            }
                            else if (j == 3)
                            {
                                el.SiteId = xlRange.Cells[i, j].Value2.ToString();
                            }
                            else if (j == 4)
                            {
                                elc.ChannelId = el.SiteId + "_0" + xlRange.Cells[i, j].Value2.ToString();
                            }
                            else if (j == 5)
                            {
                                elc.ChannelName = xlRange.Cells[i, j].Value2.ToString();
                            }
                            else if (j == 6)
                            {
                                elc.Unit = xlRange.Cells[i, j].Value2.ToString();
                            }
                            else if (j == 7)
                            {
                                el.Lat = double.Parse(xlRange.Cells[i, j].Value2.ToString());
                            }
                            else if (j == 8)
                            {
                                el.Long = double.Parse(xlRange.Cells[i, j].Value2.ToString());
                            }

                        }

                    }

                    el.list.Add(elc);
                    list.Add(el);
                }
                else
                {
                    for (int j = 4; j <= colCount - 2; j++)
                    {
                        if (j == 4)
                        {
                            elc.ChannelId = list[list.Count - 1].SiteId + "_0" + xlRange.Cells[i, j].Value2.ToString();
                        }
                        else if (j == 5)
                        {
                            elc.ChannelName = xlRange.Cells[i, j].Value2.ToString();
                        }
                        else if (j == 6)
                        {
                            elc.Unit = xlRange.Cells[i, j].Value2.ToString();
                        }
                    }

                    list[list.Count - 1].list.Add(elc);
                }
            }

            Console.WriteLine("end convert");

            return list;
        }
        
    }
}
