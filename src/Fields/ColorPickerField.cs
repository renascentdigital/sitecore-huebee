using Sitecore.Huebee.Factories;
using Sitecore.Huebee.Models;
using Sitecore.Huebee.Services;
using Sitecore.Shell.Applications.ContentEditor;
using Sitecore.Web.UI.Sheer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace Sitecore.Huebee.Fields
{
    public class ColorPickerField : Sitecore.Shell.Applications.ContentEditor.Text, IContentField
    {
        private bool PerSiteConfiguration => Configuration.Settings.GetBoolSetting("Huebee.EnablePerSiteConfiguration", false);
        private readonly IHuebeeConfiguration _configuration;

        public ColorPickerField() : this(HuebeeConfigurationFactory.Build())
        { }

        public ColorPickerField(IHuebeeConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Func<ISiteService> SiteService = () => { return new SiteService(); };

        public void SetValue(string value)
        {
            Value = value;
        }

        public string GetValue()
        {
            return Value;
        }

        protected override void Render(HtmlTextWriter output)
        {
            IHuebeeConfiguration siteConfiguration = GetSiteConfiguration(_configuration.Sites);
            
            string options = (siteConfiguration != null) ? CompileConfiguration(siteConfiguration) : CompileConfiguration(_configuration);
            output.Write("<div class=\"o-colorpicker\">");
            base.Render(output);
            output.Write("</div>");
            output.Write("<script>var huebeeColorInput = document.querySelector('.o-colorpicker'); if(huebeeColorInput && huebeeColorInput.firstChild) { var huebeePicker = new SitecoreHuebee.Picker(huebeeColorInput.firstChild, { " + options + ", \"staticOpen\": true }); }</script>");
        }

        public override void HandleMessage(Message message)
        {           
            base.HandleMessage(message);

            switch(message.Name)
            {
                case "colorpicker:clear":
                    Sitecore.Context.ClientPage.Start(this, "ClearColor");
                    return;
            }
        }

        protected void ClearColor(ClientPipelineArgs args)
        {
            SetValue(string.Empty);
            SheerResponse.Eval("huebeePicker.clear('" + this.ClientID + "');");
        }

        private string CompileConfiguration(IHuebeeConfiguration configuration)
        {
            string options = string.Empty;
            if(!string.IsNullOrWhiteSpace(configuration.Notation))
            {
                options += $"\"notation\": '{configuration.Notation}',";
            }
            if(!string.IsNullOrWhiteSpace(configuration.Hue0))
            {
                options += $"\"hue0\": {configuration.Hue0},";
            }
            if(!string.IsNullOrWhiteSpace(configuration.Hues))
            {
                options += $"\"hues\": {configuration.Hues},";
            }
            if(!string.IsNullOrWhiteSpace(configuration.Saturations))
            {
                options += $"\"saturations\": {configuration.Saturations},";
            }
            if(!string.IsNullOrWhiteSpace(configuration.Shades))
            {
                options += $"\"shades\": {configuration.Shades},";
            }

            string customColors = string.Empty;
            if(configuration.CustomColors != null && configuration.CustomColors.Any())
            {
                foreach (CustomColor color in configuration.CustomColors)
                {
                    customColors += $"'{color.Code}',";
                }
                if(customColors.Length > 0)
                    options += $"\"customColors\": [{customColors.Substring(0,customColors.Count() - 1)}],";
            }
            if (!string.IsNullOrEmpty(options))
            {
                options = options.Substring(0, options.Count() - 1);
            }
            return options;
        }

        private IHuebeeConfiguration GetSiteConfiguration(IEnumerable<IHuebeeConfiguration> sites)
        {
            if (PerSiteConfiguration && sites.Any())
            {
                ISiteService siteService = SiteService.Invoke();
                foreach (var site in sites)
                {
                    var siteContext = siteService.DetermineSite(GetContentItemFromQueryString());
                    if (siteContext != null && siteContext.Any(x => x.Name.Equals(site.SiteName, StringComparison.OrdinalIgnoreCase)))
                    {
                        return site;
                    }
                }
            }
            return null;
        }
    }
}