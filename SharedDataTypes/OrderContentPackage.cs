﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDataTypes
{
    class OrderContentPackage: OrderContent
    {
        public Package Package { get; set; }
    }
}
