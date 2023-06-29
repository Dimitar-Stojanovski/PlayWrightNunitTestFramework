using Microsoft.Playwright;
using PlayWrightNunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.PlaywrightTests.AddProductTests
{
    public class AddProductToCartTest:BaseTest
    {
        [Test]
        public async Task AddProductToCart()
        {
            await homePage.NavigateToProductCategoryJacketsAndSelectTops();
            await homePage.SelectProduct(0);
            await Assertions.Expect( productPage._productText).ToHaveTextAsync("Proteus Fitness Jackshirt");
            await productPage.SelectSize(1);
            await productPage.SelectColour(2);
            await productPage.EnterQuantity("2");
            Thread.Sleep(3000);
        }
    }
}
