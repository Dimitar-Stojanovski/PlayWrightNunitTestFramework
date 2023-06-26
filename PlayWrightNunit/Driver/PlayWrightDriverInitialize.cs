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
        public  IBrowser Browser { get; protected set; }
        
        public async Task<IBrowser> InitiatePlaywright(string _browserName)
        {
            switch (_browserName)
            {
                case"Chromium":
                    await CreateChromiumBrowser();
                    break;
                case"Firefox":
                    await CreateFireFoxBrowser();
                    break;
                default:
                    await Console.Out.WriteLineAsync("Invalid browser");
                    break;
            }

            return Browser;
        }

        private async Task<IBrowser> CreateChromiumBrowser()
        {
            var playwright = await Playwright.CreateAsync();
            Browser = await playwright.Chromium.LaunchAsync(new()
            {
                Headless = false,
                SlowMo = 200
            }) ;

            
            return Browser;
        }

        private async Task<IBrowser> CreateFireFoxBrowser()
        {
            var playwright = await Playwright.CreateAsync();
            Browser = await playwright.Firefox.LaunchAsync(new()
            {
                Headless = false
            });

            
            return Browser;
        }
    }
}
