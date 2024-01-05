using MagentoFrameworkCore.Config;
using MagentoFrameworkCore.Helpers;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagentoFrameworkCore.Driver
{
    public class PlayWrightDriverInitialize
    {
        public IBrowser Browser { get; protected set; }

       

        public async Task<IBrowser> InitiatePlaywright(TestSettings testSettings)
        {
            return testSettings.DriverType switch
            {
                BrowserTypes.Chromium=> await CreateChromiumBrowser(testSettings),
                BrowserTypes.Firefox=>await CreateFireFoxBrowser(testSettings),
                _=> await CreateWebkitBrowser(testSettings),

            };
        }

        private async Task<IBrowser> CreateChromiumBrowser(TestSettings testSettings)
        {
            var options = BrowserParameters(testSettings.Headless,testSettings.Slomo);
            options.Channel = "chromium";
            var playwright = await Playwright.CreateAsync();
            Browser = await playwright.Chromium.LaunchAsync(options);

            return Browser;
        }

        private async Task<IBrowser> CreateFireFoxBrowser(TestSettings testSettings)
        {
            var options = BrowserParameters(testSettings.Headless, testSettings.Slomo);
            options.Channel = "firefox";
            var playwright = await Playwright.CreateAsync();
            Browser = await playwright.Firefox.LaunchAsync(options);


            return Browser;
        }

        private async Task<IBrowser> CreateWebkitBrowser(TestSettings testSettings)
        {
            var options = BrowserParameters(testSettings.Headless, testSettings.Slomo);
            options.Channel = "webkit";
            var playwright = await Playwright.CreateAsync();
            Browser = await playwright.Webkit.LaunchAsync(options);
            


            return Browser;
        }

        private BrowserTypeLaunchOptions BrowserParameters(bool?headless, float? slowmo)
              => new()
              {
                  Headless = headless,
                  SlowMo = slowmo,
                  
              };
        


    }
    } 
