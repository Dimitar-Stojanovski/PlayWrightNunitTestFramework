using MagentoFrameworkCore.Helpers;
using Microsoft.Playwright;
using PlayWrightNunit;
using System.Text.RegularExpressions;

namespace App.PlaywrightTests.RegisterAccountTests
{
    [TestFixture]
    public class CreateAccountTests : BaseTest
    {
        private readonly string genericMail = RandomStringGenerator.GenerateRandomString(7);

        [TestCase("John","Doe","Password1234")]
        public async Task RegisterAnAccount(string firstName,string lastName,string password)
        {
            await homePage.ClickCreateAccountLink();
            await createAccountPage.EnterFirstName(firstName);
            await createAccountPage.EnterLastName(lastName);
            await createAccountPage.ClickSignUpNewsLetterCheckbox();
            Assert.True(await createAccountPage.IsNewsLetterChecked());
            await createAccountPage.EnterEmail(genericMail);
            await createAccountPage.EnterPassword(password);
            await createAccountPage.EnterConfirmPassword(password);
            await createAccountPage.ClickCreateAccountBtn();
            Thread.Sleep(TimeSpan.FromSeconds(4));
            await Assertions.Expect(createAccountPage._successMsg).ToHaveTextAsync(new Regex("Thank you for registering"));
            await Assertions.Expect(createAccountPage._successMsg).ToHaveTextAsync("Thank you for registering with Main Website Store.");
            Thread.Sleep(1000);


        }
    }
}
