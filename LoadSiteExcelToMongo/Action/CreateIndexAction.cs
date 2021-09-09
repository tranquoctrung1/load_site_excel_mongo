using LoadSiteExcelToMongo.ConnectDB;
using LoadSiteExcelToMongo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadSiteExcelToMongo.Action
{
    public class CreateIndexAction
    {
        public void CretaeIndex(List<DataExcelModel> datas)
        {
            Connect connect = new Connect();

            foreach (DataExcelModel item in datas)
            {
                foreach (Channel c in item.list)
                {
                    string nameCollection = "t_Data_Logger_" + c.ChannelId;
                    string nameCollectionIndex = "t_Index_Logger_" + c.ChannelId;

                    var collection =  connect.db.GetCollection<DataLoggerModel>(nameCollection);
                    var collectionIndex =  connect.db.GetCollection<DataLoggerModel>(nameCollectionIndex);

                    try
                    {
                        collection.Indexes.CreateOne("{TimeStamp: 1}");
                        collectionIndex.Indexes.CreateOne("{TimeStamp: 1}");
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                   
                }
            }
        }
    }
}
