using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AutoPriceMobile
{
    public class Shared
    {
        public static string name = "AutoPrice";
        public static string SqlConnString = ConfigurationManager.ConnectionStrings["AutoPriceDB"].ConnectionString;
    }
}