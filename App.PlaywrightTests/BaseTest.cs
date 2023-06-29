using App.Page.Objects.PageObjects;
using App.Page.Objects.PageObjects.CreateAccountPages;
using MagentoFrameworkCore.Config;
using MagentoFrameworkCore.Driver;
using MagentoFrameworkCore.Helpers;
using MagentoFrameworkCore.PageObjects;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace PlayWrightNunit
{
    public class BaseTest:IDisposable
    {
        private PlayWrightDriverInitialize _driverInitializer;
        private  Task<IBrowser> _browser;
        private  Task<IPage> _page;

        private readonly string _url = TestSettings.ApplicationUrl;
        public HomePage homePage;
        public CreateAccountPage createAccountPage;
        public ProductPage productPage;

        

        public IPage Page => _page.Result;

        [SetUp]
        public async Task Setup()
        {
           
            _browser = Task.Run(InitiatePlaywright);
            _page = Task.Run(CreatePageAsync);
            await Task.Run(NavigateToUrl);
            homePage = new HomePage(Page);
            createAccountPage = new CreateAccountPage(Page);
            productPage = new ProductPage(Page);
            


        }

        private async Task<IBrowser> InitiatePlaywright()
        {
            _driverInitializer = new PlayWrightDriverInitialize();
            _browser =  _driverInitializer.InitiatePlaywright(BrowserTypes.Chromium);
            return await _browser;
        }

        private async Task<IPage> CreatePageAsync()
        {
            return await (await _browser).NewPageAsync();
        }

        private async Task NavigateToUrl()
        {
            await Page.GotoAsync(_url);
        }

        public void Dispose()
        {
            _browser?.Dispose();
        }
    }
}