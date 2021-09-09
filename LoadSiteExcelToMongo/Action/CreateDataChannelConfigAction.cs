using LoadSiteExcelToMongo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadSiteExcelToMongo.Action
{
    public class CreateDataChannelConfigAction
    {
        public List<ChannelConfigModel> CreateDataChannelConfig(List<DataExcelModel> datas)
        {
            List<ChannelConfigModel> list = new List<ChannelConfigModel>();

            foreach(DataExcelModel item in datas)
            {
                foreach(Channel c in item.list)
                {
                    ChannelConfigModel el = new ChannelConfigModel();

                    el.ChannelId = c.ChannelId;
                    el.ChannelName = c.ChannelName;
                    el.LoggerId = item.SiteId;
                    el.Unit = c.Unit;
                    el.TimeStamp = null;
                    el.LastValue = null;
                    el.IndexTimeStamp = null;
                    el.LastIndex = null;
                    el.BaseLine = null;
                    el.BaseMax = null;
                    el.BaseMin = null;
                    el.DisplayOnLable = true;

                    if(el.ChannelName.ToLower().Contains("bat"))
                    {
                        el.OtherChannel = true;
                        el.Pressure1 = false;
                        el.Pressure2 = false;
                        el.ForwardFlow = false;
                        el.ReverseFlow = false;
                    }
                    else if(el.ChannelName.ToLower().Contains("p"))
                    {
                        if(el.ChannelName.ToLower().Contains("1"))
                        {
                            el.OtherChannel = false;
                            el.Pressure1 = true;
                            el.Pressure2 = false;
                            el.ForwardFlow = false;
                            el.ReverseFlow = false;
                        }
                        else if(el.ChannelName.ToLower().Contains("2"))
                        {
                            el.OtherChannel = false;
                            el.Pressure1 = false;
                            el.Pressure2 = true;
                            el.ForwardFlow = false;
                            el.ReverseFlow = false;
                        }
                    }
                    else if(el.ChannelName.ToLower().Contains("f"))
                    {
                        if (el.ChannelName.ToLower().Contains("1"))
                        {
                            el.OtherChannel = false;
                            el.Pressure1 = false;
                            el.Pressure2 = false;
                            el.ForwardFlow = true;
                            el.ReverseFlow = false;
                        }
                        else if (el.ChannelName.ToLower().Contains("2"))
                        {
                            el.OtherChannel = false;
                            el.Pressure1 = false;
                            el.Pressure2 = false;
                            el.ForwardFlow = false;
                            el.ReverseFlow = true;
                        }
                    }

                    list.Add(el);
                }
            }

            return list;
        }
    }
}
