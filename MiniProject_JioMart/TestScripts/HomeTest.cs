using MiniProject_JioMart.PageObjects;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_JioMart.TestScripts
{
    internal class HomeTest:CoreCodes
    {

        [Test]
        public void Groceries()
        {
            JioMartHomePage jhp = new(driver);

            IWebElement grocery = driver.FindElement(By.XPath("//a[@id='nav_link_2']"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(grocery).Build().Perform();
            Thread.Sleep(3000);

            IWebElement fruits = driver.FindElement(By.XPath("//a[@id='nav_link_219']"));
            actions.MoveToElement(fruits).Build().Perform();
            Thread.Sleep(3000);
            jhp.GrocerySelection();
        }
    }
}
