using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

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