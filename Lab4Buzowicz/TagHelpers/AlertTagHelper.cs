using Microsoft.AspNetCore.Razor.TagHelpers;
namespace Lab4Buzowicz.TagHelpers
{
    [HtmlTargetElement("alert")]
    public class AlertTagHelper : TagHelper
    {
        public string Type { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var className = "alert";
            if(Type==null)
            {
                className += " alert-primary";
            }
            else
            {
                className += $" alert-{Type}";
            }

            output.TagName = "div";
            output.Attributes.Add("class", className);
        }
    }
}
