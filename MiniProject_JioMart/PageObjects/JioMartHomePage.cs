using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_JioMart.PageObjects
{
    internal class JioMartHomePage
    {
        IWebDriver driver;
        public JioMartHomePage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));


            PageFactory.InitElements(driver, this);

        }


        [FindsBy(How = How.XPath, Using = "//input[@id='autocomplete-0-input']")]
        private IWebElement? SearchInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@id=\"nav_link_4\" and text()='Electronics']")]
        private IWebElement? CategorySelection { get; set; }
        [FindsBy(How = How.XPath, Using = " //a[@id=\"nav_link_757\" and contains(text(),'Mobiles')]")]
        private IWebElement? SubCategorySelection { get; set; }

        //a[@id="nav_link_757" and contains(text(),'Mobiles')]




        public SearchResultPage SearchProduct(string product)
         {
             SearchInput?.SendKeys(product);
             SearchInput?.SendKeys(Keys.Enter);

            return new SearchResultPage(driver);

         } 
        public ElectronicsProductResultPage CategorySelectionFunction()
        {
            CategorySelection?.Click();

            return new ElectronicsProductResultPage(driver);
          
        }





}
}
