using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_JioMart.PageObjects
{
    internal class ElectronicProductPage
    {

        IWebDriver driver;
        public ElectronicProductPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));


            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.XPath, Using = "(//div[contains(@class,'plp-card-container')])[1]")]
        private IWebElement? ItemSelection { get; set; }

        public void ItemSelectionFunction()
        {
            ItemSelection?.Click();
        }
    }
}
