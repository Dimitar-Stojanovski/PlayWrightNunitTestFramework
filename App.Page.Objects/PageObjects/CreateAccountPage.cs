using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Page.Objects.PageObjects
{
    public class CreateAccountPage
    {
        private readonly IPage page;

        public CreateAccountPage(IPage page)
        {
            this.page = page;
        }
    }
}
