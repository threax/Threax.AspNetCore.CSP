using System;
using System.Collections.Generic;
using System.Text;

namespace Threax.AspNetCore.CSP
{
    /// <summary>
    /// This is the actual string for the csp, calculated on startup.
    /// </summary>
    public class CSPString
    {
        public CSPString(String value)
        {
            this.Value = value;
        }

        public String Value { get; private set; }
    }
}
