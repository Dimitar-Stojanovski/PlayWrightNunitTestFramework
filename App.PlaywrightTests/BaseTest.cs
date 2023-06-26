using App.Page.Objects.PageObjects.CreateAccountPages;
using MagentoFrameworkCore.Driver;
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
        
        private readonly string _url = "https://magento.softwaretestingboard.com/";
        public HomePage homePage;
        public CreateAccountPage createAccountPage;

        

        public IPage Page => _page.Result;

        [SetUp]
        public async Task Setup()
        {
            /* _driverInitializer = new PlayWrightDriverInitialize();
             _browser = await _driverInitializer.InitiatePlaywright("Chromium");*/
            _browser = Task.Run(InitiatePlaywright);
            _page = Task.Run(CreatePageAsync);
            await Task.Run(NavigateToUrl);
            homePage = new HomePage(Page);
            createAccountPage = new CreateAccountPage(Page);
            


        }

        private async Task<IBrowser> InitiatePlaywright()
        {
            _driverInitializer = new PlayWrightDriverInitialize();
            _browser =  _driverInitializer.InitiatePlaywright("Chromium");
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