using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_JioMart.PageObjects
{
    internal class ProductPage
    {
        IWebDriver driver;
        public ProductPage(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));


            PageFactory.InitElements(driver, this);

        }

        [FindsBy(How = How.XPath, Using = "(//button[contains(@class,'addtocartbtn')])[1]")]
        private IWebElement? AddToCart { get; set; }

        [FindsBy(How = How.Id, Using = "btn_minicart")]
        private IWebElement? ViewCart { get; set; }


        public ViewCartPage AddToCartFunction()
        {
            CoreCodes.ScrollIntoView(driver, driver.FindElement(By.XPath("(//div[contains(text(),'Return')])[2]")));
          //  Thread.Sleep(4000);
            AddToCart?.Click();
            ViewCart?.Click();

            return new ViewCartPage(driver);


          //  return new ViewCartPage(driver);
        }
    }
}
