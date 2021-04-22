using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Threax.AspNetCore.CSP
{
    public class ThreaxCSPTagHelper : TagHelper
    {
        private readonly CSPOptions options;
        private readonly ICspHeaderWriter cspHeaderWriter;

        public ThreaxCSPTagHelper(CSPOptions options, ICspHeaderWriter cspHeaderWriter)
        {
            this.options = options;
            this.cspHeaderWriter = cspHeaderWriter;
        }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            cspHeaderWriter.AddContentSecurityPolicy(options);
            output.SuppressOutput();
        }
    }
}
