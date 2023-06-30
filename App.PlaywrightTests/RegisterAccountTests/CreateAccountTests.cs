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
            Thread.Sleep(1000);
            Assert.True(await createAccountPage.VerifyTheMsgIsVisible());
            await Assertions.Expect(createAccountPage._successMsg).ToHaveTextAsync("Thank you for registering with Main Website Store.");
            Thread.Sleep(1000);


        }
    }
}
