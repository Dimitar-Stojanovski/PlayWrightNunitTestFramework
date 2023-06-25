using MagentoFrameworkCore.PageObjects;
using Microsoft.Playwright;
using PlayWrightNunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace App.PlaywrightTests
{
    [TestFixture]
    public class CreateAccountTests:BaseTest
    {
       
        [Test]
        public async Task RegisterAnAccount()
        {
            await homePage.ClickCreateAccountLink();
            await createAccountPage.EnterFirstName("Dimitar1");
            await createAccountPage.EnterLastName("Stojanovski1");
            await createAccountPage.ClickSignUpNewsLetterCheckbox();
            Assert.True(await createAccountPage.IsNewsLetterChecked());
            await createAccountPage.EnterEmail("mai5l@mail.com");
            await createAccountPage.EnterPassword("Password456&");
            await createAccountPage.EnterConfirmPassword("Password456&");
            await createAccountPage.ClickCreateAccountBtn();
            await Assertions.Expect(createAccountPage._successMsg).ToHaveTextAsync(new Regex("Thank you for registering"));
            await Assertions.Expect(createAccountPage._successMsg).ToHaveTextAsync("Thank you for registering with Main Website Store.");
            Thread.Sleep(1000);
            
            
        }
    }
}
