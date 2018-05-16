using Sitecore.Data;
using Sitecore.Shell.Applications.ContentEditor;
using Sitecore.Web.UI.HtmlControls;
using Sitecore.Web.UI.Sheer;
using System;
using System.Web.UI;

namespace Sitecore.Huebee.Fields
{
    public class ColorPickerField : Sitecore.Shell.Applications.ContentEditor.Text, IContentField
    {
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
            output.Write("<div class=\"o-colorpicker\">");
            base.Render(output);
            output.Write("</div>");
            output.Write("<script>var huebeeColorInput = document.querySelector('.o-colorpicker'); if(huebeeColorInput && huebeeColorInput.firstChild) { var huebeePicker = new SitecoreHuebee.Picker(huebeeColorInput.firstChild, { staticOpen: true }); }</script>");
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
    }
}