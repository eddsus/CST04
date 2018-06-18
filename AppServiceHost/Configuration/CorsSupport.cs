using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServiceHost.Configuration
{
    public class CorsSupport : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new CorsDomain();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            var service = (CorsDomain)element;

            return service.Name;
        }
    }
}
