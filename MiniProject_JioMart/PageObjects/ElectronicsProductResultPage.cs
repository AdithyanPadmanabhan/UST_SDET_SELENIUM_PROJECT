using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_JioMart.PageObjects
{
    internal class ElectronicsProductResultPage
    {

        IWebDriver driver;
        public ElectronicsProductResultPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));


            PageFactory.InitElements(driver, this);

        }
        [FindsBy(How = How.XPath, Using = "(//div[@class='jm-list-prefix']//following::button[@class='jm-btn tertiary small jm-icon'])[1]")]
        private IWebElement? DownArrowSelection { get; set; }

        [FindsBy(How = How.XPath, Using = " //a[@class='sub_cat_nav text-truncate' and contains(@title,'Wearable')]")]
        private IWebElement? ProductSelection { get; set; }

       
        public ElectronicProductPage ProductSelectionFunction()
        {
            DownArrowSelection?.Click();
            ProductSelection?.Click();

            return new ElectronicProductPage(driver);

        }
    }
}
