using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServiceHost.Configuration
{
    public class CorsDomain : ConfigurationElement
    {
        [ConfigurationProperty("Name", IsRequired = true)]
        public string Name
        {
            //get { return Convert.ToString(this["Name"]); }
            //set { this["Name"] = value; }

            get { return "http://localhost:4200"; }
            set { this["Name"] = value; }
        }

        [ConfigurationProperty("AllowMethods", IsRequired = true)]
        public string AllowMethods
        {
            //get { return Convert.ToString(this["AllowMethods"]); }
            //set { this["AllowMethods"] = value; }

            get { return "POST"; }
            set { this["AllowMethods"] = value; }
        }

        [ConfigurationProperty("AllowHeaders")]
        public string AllowHeaders
        {
            //get { return Convert.ToString(this["AllowHeaders"]); }
            //set { this["AllowHeaders"] = value; }

            get { return "Content-Type"; }
            set { this["AllowHeaders"] = value; }
        }

        [ConfigurationProperty("AllowCredentials")]
        public bool AllowCredentials
        {
            //get { return Convert.ToBoolean(this["AllowCredentials"]); }
            //set { this["AllowCredentials"] = value; }

            get { return true; }
            set { this["AllowCredentials"] = value; }
        }
    }
}
