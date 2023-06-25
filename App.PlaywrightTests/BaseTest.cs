using MagentoFrameworkCore.Driver;
using MagentoFrameworkCore.PageObjects;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlayWrightNunit
{
    public class BaseTest:IDisposable
    {
        private PlayWrightDriverInitialize _driverInitializer;
        public IBrowser _browser;
        private readonly string _url = "https://magento.softwaretestingboard.com/";
        public HomePage homePage;
       
        [SetUp]
        public async Task Setup()
        {
            _driverInitializer = new PlayWrightDriverInitialize();
            _browser = await _driverInitializer.InitiatePlaywright("Chromium");
            var page = await _browser.NewPageAsync();
            homePage = new HomePage(page);
            await page.GotoAsync(_url);
            await homePage.ClickCreateAccountLink();
            Thread.Sleep(3000);


        }

        

        public void Dispose()
        {
            _browser.DisposeAsync();
        }
    }
}