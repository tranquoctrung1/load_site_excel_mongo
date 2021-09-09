using LoadSiteExcelToMongo.ConnectDB;
using LoadSiteExcelToMongo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadSiteExcelToMongo.Action
{
    public class InsertSiteAction
    {
        public void InserSite(List<DataExcelModel> datas)
        {
            CreateDataSiteAction createDataSiteAction = new CreateDataSiteAction();
            List<SiteModel> list = createDataSiteAction.CreateDataSite(datas);

            Connect connect = new Connect();

            var collection = connect.db.GetCollection<SiteModel>("t_Sites");

            try
            {
                collection.InsertMany(list);

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
