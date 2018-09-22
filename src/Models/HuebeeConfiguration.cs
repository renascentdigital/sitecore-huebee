using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Linq;

namespace Sitecore.Huebee.Models
{
    public class HuebeeConfiguration : IHuebeeConfiguration
    {
        private readonly List<CustomColor> _customColors = new List<CustomColor>();

        public string Hues { get; set; }
        public string Hue0 { get; set; }
        public string Shades { get; set; }
        public string Saturations { get; set; }
        public string Notation { get; set; }
        public IEnumerable<CustomColor> CustomColors => _customColors;

        public void AddOptions(XmlNode node)
        {
            if(node == null)
            {
                Sitecore.Diagnostics.Log.SingleWarn("sitecore Huebee configuration not is not defined", this);
            }
            Hues = (node.SelectSingleNode("hues") != null) ? node.SelectSingleNode("hues").Value : string.Empty;
            Hue0 = (node.SelectSingleNode("hue0") != null) ? node.SelectSingleNode("hue0").Value : string.Empty;
            Shades = (node.SelectSingleNode("shades") != null) ? node.SelectSingleNode("shades").Value : string.Empty;
            Saturations = (node.SelectSingleNode("saturations") != null) ? node.SelectSingleNode("saturations").Value : string.Empty;
            Notation = (node.SelectSingleNode("notation") != null) ? node.SelectSingleNode("notation").Value : string.Empty;
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
    }
}