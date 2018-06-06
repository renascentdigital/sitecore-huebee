using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.Huebee.Models
{
    public interface IHuebeeConfiguration
    {
        string Hues { get; set; }
        string Hue0 { get; set; }
        string Shades { get; set; }
        string Saturations { get; set; }
        string Notation { get; set; }
        IEnumerable<CustomColor> CustomColors { get; }
    }
}
