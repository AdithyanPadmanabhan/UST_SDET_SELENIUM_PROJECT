using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_JioMart.PageObjects
{
    internal class ViewCartPage
    {
        IWebDriver driver;
        public ViewCartPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));


            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.XPath, Using = "(//div[contains(text(),' Place Order ')])[1]")]
        private IWebElement? PlaceOrder { get; set; }

        public void PlaceorderFunction()
        {
            PlaceOrder?.Click();
        }


        
    }
}
