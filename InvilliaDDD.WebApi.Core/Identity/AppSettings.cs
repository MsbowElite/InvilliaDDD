using System;
using System.Collections.Generic;
using System.Text;

namespace InvilliaDDD.WebApi.Core.Identity
{
    public class AppSettings
    {
        public string Secret { get; set; }

        public int ExpireInHours { get; set; }
    }
}
