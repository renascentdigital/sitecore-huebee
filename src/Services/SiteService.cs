using Sitecore.Data.Items;
using Sitecore.Web;
using System.Collections.Generic;
using System.Linq;

namespace Sitecore.Huebee.Services
{
    public class SiteService : ISiteService
    {
        public IEnumerable<SiteInfo> DetermineSite(Item contextItem)
        {
            var sites = Sitecore.Configuration.Factory.GetSiteInfoList();
            var database = Sitecore.Context.ContentDatabase;

            foreach (var site in sites)
            {
                var homeItemPath = $"{site.RootPath}{site.StartItem}";
                var homeItem = database.GetItem(homeItemPath);

                if (homeItem == null)
                    continue;

                if (homeItem.ID.Equals(contextItem.ID))
                {
                    yield return site;
                }
                else
                {
                    var filterItem = database.SelectItems($"fast:{homeItemPath}//*[@@ID = '{contextItem.ID}']");
                    if (filterItem.Any())
                        yield return site;
                }
            }
        }
    }
}