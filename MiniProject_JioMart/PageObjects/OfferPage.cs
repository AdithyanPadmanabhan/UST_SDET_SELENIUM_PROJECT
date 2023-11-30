using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_JioMart.PageObjects
{
    internal class OfferPage
    {

        IWebDriver driver;
        public OfferPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));


            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.Id, Using = "offer_2372")]
        private IWebElement? offerItem { get; set; }

        public void OfferSelection()
        {
            offerItem?.Click();
        }
    }
}
