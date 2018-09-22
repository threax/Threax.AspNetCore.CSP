using System;
using System.Collections.Generic;
using System.Text;

namespace Threax.AspNetCore.CSP
{
    /// <summary>
    /// Options for CSP. Descriptions taken from https://developer.mozilla.org/en-US/docs/Web/HTTP/CSP.
    /// </summary>
    public class CSPOptions
    {
        public Dictionary<String, PolicyItem> Policies { get; set; } = new Dictionary<string, PolicyItem>();

        /// <summary>
        /// The HTTP Content-Security-Policy (CSP) default-src directive serves as a fallback for the other CSP fetch directives. 
        /// For each of the following directives that are absent, the user agent will look for the default-src directive and will use this value for it.
        /// Other policies are added with AddXSrc or by adding them manually to the dictionary.
        /// CSP Version 1.
        /// </summary>
        public PolicyItem AddDefault()
        {
            var item = new PolicyItem();
            Policies.Add("default-src", item);
            return item;
        }

        /// <summary>
        /// Restricts what can be loaded using script interfaces. The APIs that are restricted are: <a> ping, Fetch, XMLHttpRequest, WebSocket, and EventSource.
        /// CSP Version 1.
        /// </summary>
        public PolicyItem AddConnect()
        {
            var item = new PolicyItem();
            Policies.Add("connect-src", item);
            return item;
        }

        /// <summary>
        /// The HTTP Content-Security-Policy (CSP) font-src directive specifies valid sources for fonts loaded using @font-face.
        /// CSP Version 1.
        /// </summary>
        public PolicyItem AddFont()
        {
            var item = new PolicyItem();
            Policies.Add("font-src", item);
            return item;
        }

        /// <summary>
        /// The HTTP Content-Security-Policy (CSP) frame-src directive specifies valid sources for nested browsing contexts loading using elements such as <frame> and <iframe>.
        /// CSP Version 1.
        /// </summary>
        public PolicyItem AddFrame()
        {
            var item = new PolicyItem();
            Policies.Add("frame-src", item);
            return item;
        }

        /// <summary>
        /// The HTTP Content-Security-Policy img-src directive specifies valid sources of images and favicons.
        /// CSP Version 1.
        /// </summary>
        public PolicyItem AddImg()
        {
            var item = new PolicyItem();
            Policies.Add("img-src", item);
            return item;
        }

        /// <summary>
        /// The HTTP Content-Security-Policy: manifest-src directive specifies which manifest can be applied to the resource.
        /// CSP Version 1.
        /// </summary>
        public PolicyItem AddManifest()
        {
            var item = new PolicyItem();
            Policies.Add("manifest-src", item);
            return item;
        }

        /// <summary>
        /// The HTTP Content-Security-Policy (CSP) media-src directive specifies valid sources for loading media using the <audio> and <video> elements.
        /// CSP Version 1.
        /// </summary>
        public PolicyItem AddMedia()
        {
            var item = new PolicyItem();
            Policies.Add("media-src", item);
            return item;
        }

        /// <summary>
        /// The HTTP Content-Security-Policy object-src directive specifies valid sources for the <object>, <embed>, and <applet> elements. 
        /// To set allowed types for <object>, <embed>, and<applet> elements, use the plugin-types directive.
        /// CSP Version 1.
        /// </summary>
        public PolicyItem AddObject()
        {
            var item = new PolicyItem();
            Policies.Add("object-src", item);
            return item;
        }

        /// <summary>
        /// The HTTP Content-Security-Policy (CSP) script-src directive specifies valid sources for JavaScript. 
        /// This includes not only URLs loaded directly into <script> elements, but also things like inline script 
        /// event handlers (onclick) and XSLT stylesheets which can trigger script execution.
        /// CSP Version 1.
        /// </summary>
        public PolicyItem AddScript()
        {
            var item = new PolicyItem();
            Policies.Add("script-src", item);
            return item;
        }

        /// <summary>
        /// The HTTP Content-Security-Policy (CSP) style-src directive specifies valid sources for sources for stylesheets.
        /// CSP Version 1.
        /// </summary>
        public PolicyItem AddStyle()
        {
            var item = new PolicyItem();
            Policies.Add("style-src", item);
            return item;
        }

        /// <summary>
        /// The HTTP Content-Security-Policy (CSP) worker-src directive specifies valid sources for Worker, SharedWorker, or ServiceWorker scripts.
        /// CSP Version 1.
        /// </summary>
        public PolicyItem AddWorker()
        {
            var item = new PolicyItem();
            Policies.Add("worker-src", item);
            return item;
        }

        /// <summary>
        /// Set ReportTo, since it isn't widely supported yet also adds ReportUri. If null nothing is sent. Default: null.
        /// </summary>
        //public String ReportTo { get; set; } = null;

        /// <summary>
        /// Create the final CSP String to send to the client.
        /// </summary>
        /// <returns></returns>
        public CSPString Build()
        {
            var sb = new StringBuilder();

            if (Policies != null)
            {
                foreach (var item in Policies)
                {
                    sb.Append("; ");
                    sb.Append(item.Key);
                    sb.Append(" ");
                    sb.Append(item.Value);
                }
            }

            return new CSPString(sb.ToString());
        }
    }
}
