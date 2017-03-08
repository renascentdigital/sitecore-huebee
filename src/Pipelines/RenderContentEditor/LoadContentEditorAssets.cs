namespace Sitecore.Huebee.Pipelines.RenderContentEditor
{
    using Sitecore.Diagnostics;
    using Sitecore.Pipelines;
    using System.Web;
    using System.Web.UI;

    public class LoadContentEditorAssets
    {
        public void Process(PipelineArgs args)
        {
            if(Context.ClientPage.IsEvent)
                return;            

            HttpContext current = HttpContext.Current;
            if (current == null)
                return;

            Page handler = current.Handler as Page;
            if (handler == null)
                return;

            Assert.IsNotNull(handler.Header, "Content Editor <head> tag is missing runat='value'");
            
            handler.Header.Controls.Add(new LiteralControl("<script src=\"/sitecore modules/shell/SitecoreHuebee/picker.js\"></script>\n"));
        }
    }
}