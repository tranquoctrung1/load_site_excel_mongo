using LoadSiteExcelToMongo.ConnectDB;
using LoadSiteExcelToMongo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadSiteExcelToMongo.Action
{
    public class InsertChannelConfigAction
    {
        public void InsertChannelConfig(List<DataExcelModel> datas)
        {
            CreateDataChannelConfigAction createDataChannelConfigAction = new CreateDataChannelConfigAction();
            List<ChannelConfigModel> list = createDataChannelConfigAction.CreateDataChannelConfig(datas);

            Connect connect = new Connect();

            var collection = connect.db.GetCollection<ChannelConfigModel>("t_Channel_Configurations");
            
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
