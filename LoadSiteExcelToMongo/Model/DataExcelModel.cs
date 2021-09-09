using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadSiteExcelToMongo.Model
{
    public class DataExcelModel
    {
        public string SiteId { get; set; }
        public string SiteName { get; set; }

        public double Lat { get; set; }

        public double Long { get; set; }

        public List<Channel> list { get; set; }
    }

    public class Channel
    {
        public string ChannelId { get; set; }
        public string ChannelName { get; set; }
        public string Unit { get; set; }
    }
}
