using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Linq;
using Sitecore.Huebee.Factories;

namespace Sitecore.Huebee.Models
{
    public class HuebeeConfiguration : IHuebeeConfiguration
    {
        private List<CustomColor> _customColors = new List<CustomColor>();
        private List<HuebeeConfiguration> _sites = new List<HuebeeConfiguration>();

        public string Hues { get; set; }
        public string Hue0 { get; set; }
        public string Shades { get; set; }
        public string Saturations { get; set; }
        public string Notation { get; set; }
        public string SiteName { get; set; }
        public IEnumerable<CustomColor> CustomColors => _customColors;
        public IEnumerable<IHuebeeConfiguration> Sites => _sites;

        public void AddOptions(XmlNode node)
        {
            if(node == null)
            {
                Sitecore.Diagnostics.Log.SingleWarn("sitecore Huebee configuration not is not defined", this);
            }
            Hues = (node.SelectSingleNode("hues") != null) ? node.SelectSingleNode("hues").InnerText : string.Empty;
            Hue0 = (node.SelectSingleNode("hue0") != null) ? node.SelectSingleNode("hue0").InnerText : string.Empty;
            Shades = (node.SelectSingleNode("shades") != null) ? node.SelectSingleNode("shades").InnerText : string.Empty;
            Saturations = (node.SelectSingleNode("saturations") != null) ? node.SelectSingleNode("saturations").InnerText : string.Empty;
            Notation = (node.SelectSingleNode("notation") != null) ? node.SelectSingleNode("notation").InnerText : string.Empty;
        }

        protected void AddCustomColors(XmlNode node)
        {
            if (node == null)
                return;
            if (node.Attributes == null)
                return;
            if (node.Attributes["code"] == null)
                return;
            if (node.Attributes["code"].Value == null)
                return;

            _customColors.Add(new CustomColor()
            {
                Code = node.Attributes["code"].Value
            });
        }

        protected void AddSites(XmlNode node)
        {
            if (node == null)
                return;
            if (node.Attributes == null)
                return;
            if (node.Attributes["name"] == null)
                return;
            if (node.Attributes["name"].Value == null)
                return;
            if (!node.HasChildNodes)
                return;

            var siteConfiguration = new HuebeeConfiguration();
            siteConfiguration.AddOptions(node);
            siteConfiguration.SiteName = node.Attributes["name"].Value;
            if (node.SelectSingleNode("customColors") != null && node.SelectSingleNode("customColors").ChildNodes.Count > 0)
            {
                foreach (XmlNode child in node.SelectSingleNode("customColors").ChildNodes)
                {
                    siteConfiguration.AddCustomColors(child);
                }
            }
            _sites.Add(siteConfiguration);
        }
    }
}