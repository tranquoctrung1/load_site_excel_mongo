using LoadSiteExcelToMongo.ConnectDB;
using LoadSiteExcelToMongo.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadSiteExcelToMongo.Action
{
    public class CreateDataAndCollectionLoggerAction
    {
        public void CreateDataAndCollection(List<DataExcelModel> datas)
        {
            Connect connect = new Connect();

            foreach(DataExcelModel item in datas)
            {
                foreach(Channel c in item.list)
                {
                    string nameCollection = "t_Data_Logger_" + c.ChannelId;
                    string nameCollectionIndex = "t_Index_Logger_" + c.ChannelId;

                    connect.db.CreateCollection(nameCollection);
                    connect.db.CreateCollection(nameCollectionIndex);
                }
            }
        }
    }
}
