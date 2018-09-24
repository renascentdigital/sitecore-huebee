using Sitecore.Data.Items;
using Sitecore.Web;
using System.Collections.Generic;

namespace Sitecore.Huebee.Services
{
    public interface ISiteService
    {
        IEnumerable<SiteInfo> DetermineSite(Item contextItem);
    }
}
