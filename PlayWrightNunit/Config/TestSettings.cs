using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagentoFrameworkCore.Config
{
    public static class TestSettings
    {
        public static string ApplicationUrl { get; set; } = "https://magento.softwaretestingboard.com/";
        public static bool? Headless { get; set; } = false;
        public static float? Slomo { get; set; } = 200;
    }
}
