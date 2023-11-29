using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_JioMart.PageObjects
{
    internal class SearchResultPage
    {
        IWebDriver driver;
        public SearchResultPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));


            PageFactory.InitElements(driver, this);

        }


        [FindsBy(How = How.XPath, Using = "(//div[contains(@class,'plp-card-container')])[1]")]
        private IWebElement? ItemSelection { get; set; }

        [FindsBy(How = How.XPath, Using = "(//div[@class='jm-list-prefix']//following::button[@class='jm-btn tertiary small jm-icon'])[1]")]
        private IWebElement? DownArrowSelection { get; set; }

        public  ProductPage ItemSelectionFunction()
        {
            ItemSelection?.Click();
            return new ProductPage(driver);
        }

        public void DownArrowSelectionFunction()
        {
            DownArrowSelection?.Click();
        }
        
    }
}
