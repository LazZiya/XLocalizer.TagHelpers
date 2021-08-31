using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;
using System.Threading.Tasks;

namespace XLocalizer.TagHelpers
{
    /// <summary>
    /// Localize select items
    /// </summary>
    public class LocalizeSelectTagHelper : SelectTagHelper
    {
        private readonly IXStringLocalizerFactory _localizerFactory;

        /// <summary>
        /// Initialize a new instance of LocalizeSelectTagHelper
        /// </summary>
        /// <param name="localizerFactory"></param>
        /// <param name="htmlGenerator"></param>
        public LocalizeSelectTagHelper(IXStringLocalizerFactory localizerFactory, IHtmlGenerator htmlGenerator)
            : base(htmlGenerator)
        {
            _localizerFactory = localizerFactory;
        }

        /// <summary>
        /// process localize-select tag helper
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "select";

            if(Items != null && Items.Count() > 1)
            {
                var _loc = _localizerFactory.Create();

                foreach(var item in Items)
                {
                    item.Text = _loc[item.Text];
                }
            }

            await base.ProcessAsync(context, output);
        }
    }
}
