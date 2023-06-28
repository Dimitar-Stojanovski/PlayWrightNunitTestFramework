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
        private ILocator createAccountLink => 
            page.GetByRole(AriaRole.Link, new() { Name = "Create an Account"});
        private ILocator _mensTabList => 
            page.GetByRole(AriaRole.Menuitem, new() { Name = " Men", Exact = true });
           

        private ILocator _mensTabListTops => 
            page.GetByRole(AriaRole.Menuitem, new() { Name= " Tops", Exact=true});
        private ILocator _mensTabListTopsJacket => 
            page.GetByRole(AriaRole.Menuitem, new(){Name= "Jackets", Exact = true });
        private ILocator _firstJacket => 
            page.GetByRole(AriaRole.Link, new() { Name = "Proteus Fitness Jackshirt", Exact = true });

        public HomePage(IPage page)=>this.page = page;

        public async Task ClickCreateAccountLink()
            => await createAccountLink.ClickAsync();

        public async Task NavigateToProductCategoryJacketsAndSelectTops()
        {
            await _mensTabList.HoverAsync();
            await _mensTabListTops.HoverAsync();
            await _mensTabListTopsJacket.ClickAsync();
        }

        public async Task SelectProductJacket() => await _firstJacket.ClickAsync();


        
    }
}
