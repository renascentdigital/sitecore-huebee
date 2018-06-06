using Sitecore.Huebee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace Sitecore.Huebee.Factories
{
    public static class HuebeeConfigurationFactory
    {
        public static IHuebeeConfiguration Build()
        {
            XmlNode xmlNode = Sitecore.Configuration.Factory.GetConfigNode("huebee");
            return Sitecore.Configuration.Factory.CreateObject<IHuebeeConfiguration>(xmlNode);
        }
    }
}