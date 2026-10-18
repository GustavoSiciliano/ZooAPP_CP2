using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ZooApp.TagHelpers
{

    [HtmlTargetElement("alerta")]
    public class AlertaTagHelper : TagHelper
    {
        public string? Mensagem { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Se não tem mensagem, não mostra nada
            if (string.IsNullOrWhiteSpace(Mensagem))
            {
                output.SuppressOutput();
                return;
            }

            output.TagName = "div";
            output.Attributes.SetAttribute("class", "alerta");
            output.Content.SetContent(Mensagem);
        }
    }
}