using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServiceHost.CorsConfiguration
{
    public class CustomSettings : ConfigurationSection
    {
        [ConfigurationProperty("CorsSupport", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(CorsSupport), AddItemName = "Domain")]
        public CorsSupport CorsSupport
        {
            get { return (CorsSupport)this["CorsSupport"]; }
            set { this["CorsSupport"] = value; }
        }
    }
}
