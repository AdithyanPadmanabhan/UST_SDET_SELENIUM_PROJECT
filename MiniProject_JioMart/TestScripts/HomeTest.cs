using MiniProject_JioMart.PageObjects;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using SeleniumExtras.WaitHelpers;
using MiniProject_JioMart.Utilities;

namespace MiniProject_JioMart.TestScripts
{
    internal class HomeTest:CoreCodes
    {

        [Test,Order(1)]
        [Category("SmokeTest")]
        public void Groceries()
        {
            if (!driver.Url.Equals("https://www.jiomart.com/"))
            {
                driver.Navigate().GoToUrl("https://www.jiomart.com/");

            }



            var fluentWait = Waits(driver);


            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string filePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();
            JioMartHomePage jhp = new(driver);

            IWebElement grocery = driver.FindElement(By.XPath("//a[@id='nav_link_2']"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(grocery).Build().Perform();
          

            IWebElement fruits = driver.FindElement(By.XPath("//a[@id='nav_link_219']"));
            actions.MoveToElement(fruits).Build().Perform();

            fluentWait.Until(d => jhp);

          //  jhp.GrocerySelection();

            try
            {
                jhp.GrocerySelection();

                TakeScreenShot();
                Assert.That(driver.Url.Contains("groceries"));
                LogTestResult(" Groceries Search Test ", "Groceries Search success");


            }
            catch (AssertionException ex)
            {

                LogTestResult("Groceries Search  Test",
                  "Groceries Search  failed", ex.Message);
            }
        }

        [Test, Order(2)]
        [Category("SmokeTest")]

        public void OffersTest()
        {
            if (!driver.Url.Equals("https://www.jiomart.com/"))
            {
                driver.Navigate().GoToUrl("https://www.jiomart.com/");

            }
            var fluentWait = Waits(driver);


            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string filePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();
            JioMartHomePage jhp = new(driver);

         
        var item = fluentWait.Until(d => jhp.OfferFunction());

            

            try
            {

                TakeScreenShot();
                Assert.That(driver.Url.Contains("jiomart"));
                LogTestResult(" Offer button Test ", "Offer button success");


            }
            catch (AssertionException ex)
            {

                LogTestResult("Offer button Test",
                  "Offer button failed", ex.Message);
            }

            fluentWait.Until(d => item);

           item?.OfferSelection();


          

            try
            {

                TakeScreenShot();
                Assert.That(driver.Url.Contains("offers"));
                LogTestResult(" Offer store Test ", "Offer store success");


            }
            catch (AssertionException ex)
            {

                LogTestResult("Offer store Test",
                  "Offer store failed", ex.Message);
            }

        }

        [Test, Order(3)]
        [Category("SmokeTest")]
       

        public void InvalidPinCodeTest()

        {

            if (!driver.Url.Equals("https://www.jiomart.com/"))
            {
                driver.Navigate().GoToUrl("https://www.jiomart.com/");

            }
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string filePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();
            JioMartHomePage jhp = new(driver);
            jhp.LocationSelection("1234567");

            IWebElement msg = driver.FindElement(By.Id("delivery_pin_msg"));
            string? Errormsg = msg.Text;
            try
            {
                Assert.That(Errormsg, Does.Contain("not delivering"));

               
                LogTestResult(" Delivery Invalid Test ", "Delivery Invalid Test success");
                
            }
            catch (AssertionException ex)
            {

                LogTestResult("Delivery Invalid Test",
                  "Delivery Invalid Test", ex.Message);


            }
        }


        [Test, Order(4)]
        [Category("SmokeTest")]


        public void InvalidSearchTest()
        {
            if (!driver.Url.Equals("https://www.jiomart.com/"))
            {
                driver.Navigate().GoToUrl("https://www.jiomart.com/");

            }
            var fluentWait = Waits(driver);
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string filePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();
            JioMartHomePage jhp = new(driver);
            var item = fluentWait.Until(d => jhp.SearchProduct("asdfghjklll"));

            fluentWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='dplp-coming-soon-title jm-heading-xs jm-mb-s']")));

           // Thread.Sleep(3000);


            IWebElement msg = driver.FindElement(By.XPath("//div[@class='dplp-coming-soon-title jm-heading-xs jm-mb-s']"));
            string? Errormsg = msg.Text;
            try
            {
                Assert.That(Errormsg, Does.Contain("Sorry"));


                LogTestResult("  Invalid search Test ", "Invalid search Test success");

            }
            catch (AssertionException ex)
            {

                LogTestResult("Invalid search Test",
                  "Invalid search Test", ex.Message);


            }
        }




        [Test, Order(5)]
        [Category("SmokeTest")]


        public void MultipleProductSearchTest()
        {
            if (!driver.Url.Equals("https://www.jiomart.com/"))
            {
                driver.Navigate().GoToUrl("https://www.jiomart.com/");

            }
            var fluentWait = Waits(driver);
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string filePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();
            JioMartHomePage jhp = new(driver);
            string? excelFilePath = currDir + "/TestData/JioMart-InputData.xlsx";
            string? sheetName = "JioMart";

            List<SearchData> excelDataList = ExcelUtils.ReadSearchDataExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {


                string? multiProduct = excelData?.MultiProduct;

               


                fluentWait.Until(d => jhp);
                jhp.MultiSearchFunction(multiProduct);

              
            }
        }

        [Test, Order(6)]
        [Category("SmokeTest")]
        public void LogoTest()
        {
            if (!driver.Url.Equals("https://www.jiomart.com/"))
            {
                driver.Navigate().GoToUrl("https://www.jiomart.com/");

            }
            var fluentWait = Waits(driver);
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string filePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();
            JioMartHomePage jhp = new(driver);
            jhp.LogoButtonFunction();
            try
            {
                Assert.That(driver.Url.Contains("jiomart"));
                LogTestResult("  Logo Test ", " Logo Test success");

            }
            catch (AssertionException ex)
            {

                LogTestResult(" Logo Test",
                  " Logo Test", ex.Message);


            }


        }
        [Test, Order(7)]
        [Category("SmokeTest")]
        public void CheckAllLinksStatusTest()
        {

            if (!driver.Url.Equals("https://www.jiomart.com/"))
            {
                driver.Navigate().GoToUrl("https://www.jiomart.com/");

            }
            var fluentWait = Waits(driver);
            string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string filePath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyy-mm-dd_HH.mm.ss") + ".txt";
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Console()
               .WriteTo.File(filePath, rollingInterval: RollingInterval.Day).CreateLogger();
            List<IWebElement> allLinks = driver.FindElements(By.TagName("a")).ToList();

            try

            {
                foreach (var link in allLinks)
                {
                    string url = link.GetAttribute("href");

                    if (url == null)
                    {


                        Log.Information("URL is null");

                        continue;
                    }
                    else
                    {
                        bool isWorking = CheckLinkStatus(url);

                        if (isWorking)
                            Log.Information(url + "  is working");
                        else
                            Log.Information(url + "  is not working");
                    }
                }

                LogTestResult("  All link Test ", "All link success");
            }

            catch (AssertionException ex)
            {

                LogTestResult(" All link",
                  " All link", ex.Message);


            }


        }
    }
    }


