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
        private CSPString cspString;
        private IHttpContextAccessor contextAccessor;

        public ThreaxCSPTagHelper(CSPString options, IHttpContextAccessor contextAccessor)
        {
            this.cspString = options;
            this.contextAccessor = contextAccessor;
        }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            contextAccessor.HttpContext.Response.Headers.Add("Content-Security-Policy", cspString.Value);
            output.SuppressOutput();
        }
    }
}
