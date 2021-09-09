using LoadSiteExcelToMongo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadSiteExcelToMongo.Action
{
    public class CreateDataSiteAction
    {
        public List<SiteModel> CreateDataSite(List<DataExcelModel> datas)
        {
            List<SiteModel> list = new List<SiteModel>();

            foreach(DataExcelModel item in datas)
            {
                SiteModel el = new SiteModel();

                el.SiteId = item.SiteName;
                el.Location = item.SiteName;
                el.Latitude = item.Lat.ToString();
                el.Longitude = item.Long.ToString();
                el.DisplayGroup = "XNTD";
                el.LoggerId = item.SiteId;
                el.StartDay = 1;
                el.StartHour = 0;
                el.PipeSize = "";
                el.InterVal = 15;
                el.Available = "";
                el.TimeDelay = 60;
                el.Note = "";
                el.ConsumerId = "";
                el.Status = "";
                el.IsPrimayer = false;

                list.Add(el);
            }

            return list;
        }
    }
}
