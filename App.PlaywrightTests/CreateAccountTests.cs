using PlayWrightNunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.PlaywrightTests
{
    public class CreateAccountTests:BaseTest
    { 
        [Test]
        public async Task RegisterAnAccount()
        {
            await homePage.ClickCreateAccountLink();
        }
    }
}
