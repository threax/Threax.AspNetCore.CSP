using System;
using System.Collections.Generic;
using System.Linq;
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
        /// The size of the generated nonces in bytes. Default: 32.
        /// </summary>
        public int NonceSizeBytes { get; set; } = 32;

        /// <summary>
        /// This will be true if any of the policy items has a nonce.
        /// </summary>
        internal bool HasNonce
        {
            get
            {
                return Policies.Values.Any(i => i.HasNonce);
            }
        }

        /// <summary>
        /// Add a named policy. You should use the policy specific functions, but if you need to create a policy
        /// this library does not support you can do it here.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public PolicyItem GetOrCreatePolicy(String name)
        {
            PolicyItem policy;
            if(!Policies.TryGetValue(name, out policy))
            {
                policy = new PolicyItem();
                Policies.Add(name, policy);
            }
            return policy;
        }

        /// <summary>
        /// The HTTP Content-Security-Policy (CSP) default-src directive serves as a fallback for the other CSP fetch directives. 
        /// For each of the following directives that are absent, the user agent will look for the default-src directive and will use this value for it.
        /// Other policies are added with AddXSrc or by adding them manually to the dictionary.
        /// CSP Version 1.
        /// </summary>
        public PolicyItem AddDefault()
        {
            return GetOrCreatePolicy("default-src");
        }

        /// <summary>
        /// Restricts what can be loaded using script interfaces. The APIs that are restricted are: a ping, Fetch, XMLHttpRequest, WebSocket, and EventSource.
        /// CSP Version 1.
        /// </summary>
        public PolicyItem AddConnect()
        {
            return GetOrCreatePolicy("connect-src");
        }

        /// <summary>
        /// The HTTP Content-Security-Policy (CSP) font-src directive specifies valid sources for fonts loaded using @font-face.
        /// CSP Version 1.
        /// </summary>
        public PolicyItem AddFont()
        {
            return GetOrCreatePolicy("font-src");
        }

        /// <summary>
        /// The HTTP Content-Security-Policy (CSP) frame-src directive specifies valid sources for nested browsing contexts loading using elements such as frame and iframe.
        /// CSP Version 1.
        /// </summary>
        public PolicyItem AddFrame()
        {
            return GetOrCreatePolicy("frame-src");
        }

        /// <summary>
        /// The HTTP Content-Security-Policy img-src directive specifies valid sources of images and favicons.
        /// CSP Version 1.
        /// </summary>
        public PolicyItem AddImg()
        {
            return GetOrCreatePolicy("img-src");
        }

        /// <summary>
        /// The HTTP Content-Security-Policy: manifest-src directive specifies which manifest can be applied to the resource.
        /// CSP Version 1.
        /// </summary>
        public PolicyItem AddManifest()
        {
            return GetOrCreatePolicy("manifest-src");
        }

        /// <summary>
        /// The HTTP Content-Security-Policy (CSP) media-src directive specifies valid sources for loading media using the audio and video elements.
        /// CSP Version 1.
        /// </summary>
        public PolicyItem AddMedia()
        {
            return GetOrCreatePolicy("media-src");
        }

        /// <summary>
        /// The HTTP Content-Security-Policy object-src directive specifies valid sources for the object, embed, and applet elements. 
        /// To set allowed types for object, embed, and applet elements, use the plugin-types directive.
        /// CSP Version 1.
        /// </summary>
        public PolicyItem AddObject()
        {
            return GetOrCreatePolicy("object-src");
        }

        /// <summary>
        /// The HTTP Content-Security-Policy (CSP) script-src directive specifies valid sources for JavaScript. 
        /// This includes not only URLs loaded directly into script elements, but also things like inline script 
        /// event handlers (onclick) and XSLT stylesheets which can trigger script execution.
        /// CSP Version 1.
        /// </summary>
        public PolicyItem AddScript()
        {
            return GetOrCreatePolicy("script-src");
        }

        /// <summary>
        /// The HTTP Content-Security-Policy (CSP) style-src directive specifies valid sources for sources for stylesheets.
        /// CSP Version 1.
        /// </summary>
        public PolicyItem AddStyle()
        {
            return GetOrCreatePolicy("style-src");
        }

        /// <summary>
        /// The HTTP Content-Security-Policy (CSP) worker-src directive specifies valid sources for Worker, SharedWorker, or ServiceWorker scripts.
        /// CSP Version 1.
        /// </summary>
        public PolicyItem AddWorker()
        {
            return GetOrCreatePolicy("worker-src");
        }

        /// <summary>
        /// The HTTP Content-Security-Policy (CSP) frame-ancestors directive specifies valid parents that may embed a page using frame, iframe, object, embed, or applet.
        /// </summary>
        /// <returns></returns>
        public PolicyItem AddFrameAncestors()
        {
            return GetOrCreatePolicy("frame-ancestors");
        }

        // <summary>
        // Set ReportTo, since it isn't widely supported yet also adds ReportUri. If null nothing is sent. Default: null.
        // </summary>
        //public String ReportTo { get; set; } = null;

        public override String ToString()
        {
            var sb = new StringBuilder();

            if (Policies != null)
            {
                foreach (var item in Policies)
                {
                    sb.Append(item.Key);
                    sb.Append(" ");
                    sb.Append(item.Value);
                    sb.Append("; ");
                }
            }

            return sb.ToString(0, sb.Length > 0 ? sb.Length - 2 : 0);
        }
    }
}
