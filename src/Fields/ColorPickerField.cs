using Sitecore.Data;
using Sitecore.Huebee.Factories;
using Sitecore.Huebee.Models;
using Sitecore.Shell.Applications.ContentEditor;
using Sitecore.Web.UI.HtmlControls;
using Sitecore.Web.UI.Sheer;
using System;
using System.Linq;
using System.Web.UI;

namespace Sitecore.Huebee.Fields
{
    public class ColorPickerField : Sitecore.Shell.Applications.ContentEditor.Text, IContentField
    {
        private readonly IHuebeeConfiguration _configuration;

        public ColorPickerField() : this(HuebeeConfigurationFactory.Build())
        { }

        public ColorPickerField(IHuebeeConfiguration configuration)
        {
            _configuration = configuration;
        }

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
            string options = CompileConfiguration();
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

        private string CompileConfiguration()
        {
            string options = string.Empty;
            if(!string.IsNullOrWhiteSpace(_configuration.Notation))
            {
                options += $"\"notation\": '{_configuration.Notation}',";
            }
            if(!string.IsNullOrWhiteSpace(_configuration.Hue0))
            {
                options += $"\"hue0\": {_configuration.Hue0},";
            }
            if(!string.IsNullOrWhiteSpace(_configuration.Hues))
            {
                options += $"\"hues\": {_configuration.Hues},";
            }
            if(!string.IsNullOrWhiteSpace(_configuration.Saturations))
            {
                options += $"\"saturations\": {_configuration.Saturations},";
            }
            if(!string.IsNullOrWhiteSpace(_configuration.Shades))
            {
                options += $"\"shades\": {_configuration.Shades},";
            }

            string customColors = string.Empty;
            if(_configuration.CustomColors != null && _configuration.CustomColors.Any())
            {
                foreach (CustomColor color in _configuration.CustomColors)
                {
                    customColors += $"'{color.Code}',";
                }
                if(customColors.Length > 0)
                    options += $"\"customColors\": [{customColors.Substring(0,customColors.Count() - 1)}],";
            }
            options = options.Substring(0, options.Count() - 1);
            return options;
        }
    }
}