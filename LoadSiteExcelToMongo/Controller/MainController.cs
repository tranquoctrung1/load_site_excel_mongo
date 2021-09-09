using LoadSiteExcelToMongo.Action;
using LoadSiteExcelToMongo.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoadSiteExcelToMongo.Controller
{
    public class MainController
    {
        public void Main()
        {
            ReadFileExcelAction readFileExcelAction = new ReadFileExcelAction();
            CreateDataAndCollectionLoggerAction createDataAndCollectionLoggerAction = new CreateDataAndCollectionLoggerAction();
            InsertSiteAction insertSiteAction = new InsertSiteAction();
            InsertChannelConfigAction insertChannelConfigAction = new InsertChannelConfigAction();
            CreateIndexAction createIndexAction = new CreateIndexAction();

            string path = ConfigurationManager.ConnectionStrings["path"].ConnectionString;

            List<DataExcelModel> list = readFileExcelAction.ReadFileExcel(path);

            //List<Thread> threads = new List<Thread>();

            try
            {
                //Thread thread1 = new Thread(delegate ()
                //{
                //    insertSiteAction.InserSite(list);

                //});
                //thread1.IsBackground = true;
                //thread1.Start();
                //threads.Add(thread1);

                //Thread thread2 = new Thread(delegate ()
                //{
                //    insertChannelConfigAction.InsertChannelConfig(list);

                //});
                //thread2.IsBackground = true;
                //thread2.Start();
                //threads.Add(thread2);

                //Thread thread3 = new Thread(delegate ()
                //{
                //    createDataAndCollectionLoggerAction.CreateDataAndCollection(list);
                //    createIndexAction.CretaeIndex(list);

                //});
                //thread3.IsBackground = true;
                //thread3.Start();
                //threads.Add(thread3);

                insertSiteAction.InserSite(list);
                insertChannelConfigAction.InsertChannelConfig(list);
                createDataAndCollectionLoggerAction.CreateDataAndCollection(list);
                createIndexAction.CretaeIndex(list);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
