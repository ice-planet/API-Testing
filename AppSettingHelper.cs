using FluentAssertions.Common;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestingDemo2.Helper
{
   public class AppSettingHelper
    {
        public static string Get(string key)
        {
            var value = new ConfigurationBuilder().AddJsonFile("settings.json").Build().GetSection("settings")[key];
            return value;
        }
    }
}
