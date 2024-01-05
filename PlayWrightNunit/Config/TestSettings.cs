using MagentoFrameworkCore.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagentoFrameworkCore.Config
{
    public  class TestSettings
    {
        public BrowserTypes DriverType { get; set; }
        public  string ApplicationUrl { get; set; } = "https://magento.softwaretestingboard.com/";
        public  bool? Headless { get; set; } = true;
        public  float? Slomo { get; set; } = 200;
    }
}
