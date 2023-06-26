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
            await homePage.SelectProductJacket();
            Thread.Sleep(3000);
        }
    }
}
