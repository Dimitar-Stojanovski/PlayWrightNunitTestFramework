using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace App.Page.Objects.PageObjects
{
    public class ProductPage
    {
        private readonly IPage page;
        public ILocator _productText
            => page.GetByRole(AriaRole.Heading, new() { NameRegex= new Regex("Jackshirt")});

        private ILocator _sizeListBox
            => page.Locator("//*[text()='Size']/../div/div");
        private ILocator _colorListBox
            => page.Locator("//*[text()='Color']/../div/div");
        private ILocator _quantityInput =>
            page.GetByLabel("Qty");
        public ProductPage(IPage page)
        {
            this.page = page;
        }

        public async Task SelectSize(int index)=>await _sizeListBox.Nth(index).ClickAsync();
        public async Task SelectColour(int index)=>await _colorListBox.Nth(index).ClickAsync();
        public async Task EnterQuantity(string number)
        {
            await _quantityInput.ClearAsync();
            await _quantityInput.FillAsync(number);
        }
    }
}
