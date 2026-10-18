using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ZooApp.TagHelpers
{

    [HtmlTargetElement("dieta")]
    public class DietaTagHelper : TagHelper
    {
        public string Valor { get; set; } = "";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Escolhe a cor de acordo com a dieta
            string cor = "cinza";
            if (Valor == "Carnívoro")
            {
                cor = "vermelho";
            }
            else if (Valor == "Herbívoro")
            {
                cor = "verde";
            }
            else if (Valor == "Onívoro")
            {
                cor = "laranja";
            }

            output.TagName = "span";
            output.Attributes.SetAttribute("class", "etiqueta " + cor);
            output.Content.SetContent(Valor);
        }
    }
}