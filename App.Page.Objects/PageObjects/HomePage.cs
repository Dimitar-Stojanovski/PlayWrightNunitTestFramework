using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagentoFrameworkCore.PageObjects
{
    public class HomePage
    {
        private readonly IPage page;
        private ILocator createAccountLink => page.GetByRole(AriaRole.Link, new() { Name = "Create an Account"});

        public HomePage(IPage page)=>this.page = page;

        public async Task ClickCreateAccountLink()=> await createAccountLink.ClickAsync();


        
    }
}
