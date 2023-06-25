using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace App.Page.Objects.PageObjects
{
    public class CreateAccountPage
    {
        private readonly IPage _page;
        private ILocator _firstNameField => _page.GetByLabel("First Name");
        private ILocator _lastNameField => _page.GetByLabel("Last Name");
        private ILocator _emailField => _page.GetByLabel("Email", new() { Exact=true});
        private ILocator _passwordField => _page.Locator("#password");
        private ILocator _confirmPasswordField => _page.GetByRole(AriaRole.Textbox, new() { Name= "Confirm Password" });
        private ILocator _createAccountBtn => _page.GetByRole(AriaRole.Button, new() { Name = "Create an Account" });
        public ILocator _successMsg => _page.Locator(".message-success");

        private ILocator _newsLetterCheckBox => _page.GetByRole(AriaRole.Checkbox, new() { NameString = "Newsletter" });
        public CreateAccountPage(IPage page)
        {
            _page = page;
        }

        public async Task EnterFirstName(string _text) 
            => await _firstNameField.FillAsync(_text);

        public async Task EnterLastName(string _text)
            => await _lastNameField.FillAsync(_text);

        public async Task ClickSignUpNewsLetterCheckbox()
            => await _newsLetterCheckBox.CheckAsync();

        public async Task<bool>IsNewsLetterChecked()
            => await _newsLetterCheckBox.IsCheckedAsync();

        public async Task EnterEmail(string _text)
            => await _emailField.FillAsync(_text);

        public async Task EnterPassword(string _text)
            => await _passwordField.FillAsync(_text);

        public async Task EnterConfirmPassword(string _text)
            => await _confirmPasswordField.FillAsync(_text);

        public async Task ClickCreateAccountBtn()
            => await _createAccountBtn.ClickAsync();

    }
}
