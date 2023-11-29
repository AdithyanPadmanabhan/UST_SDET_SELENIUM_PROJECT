

using MiniProject_JioMart;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using MiniProject_JioMart.PageObjects;

using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniProject_JioMart.Utilities;
using OpenQA.Selenium.Support.UI;

namespace MiniProject_JioMart.TestScripts
{
    [TestFixture]
    internal class JioMartHomePageTest : CoreCodes
    {

        [Test, Order(0)]
       
        [Category("Regression Testing")]
       
        public void SearchProductTest()
        {

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Product not found";


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

                
                string? product = excelData?.Product;

                Console.WriteLine($"Product Name: {product}");




              var item = fluentWait.Until(d => jhp.SearchProduct(product));
             //   Thread.Sleep(4000);
                try
                {

                    TakeScreenShot();
                    Assert.That(driver.Url.Contains("search"));
                    LogTestResult("Product Search Test ", "Product Search success");


                }
                catch (AssertionException ex)
                {
                   
                    LogTestResult("Product Search  Test",
                      "Product Search  failed", ex.Message);
                }

                var productPage= fluentWait.Until(d => item.ItemSelectionFunction());
                Thread.Sleep(5000);

                try
                {

                    TakeScreenShot();
                    Assert.That(driver.Url.Contains("electronics"));
                    LogTestResult("Product List Test ", "Product List success");


                }
                catch (AssertionException ex)
                {

                    LogTestResult("Product List  Test",
                      "Product List  failed", ex.Message);
                }

                var addToCart= fluentWait.Until(d => productPage.AddToCartFunction());
               Thread.Sleep(5000);

                try
                {

                    TakeScreenShot();
                   
                    Assert.That(driver.Url.Contains("checkout"));
                    
                    LogTestResult("Add to cart  Test ", "Add to cart success");


                }
                catch (AssertionException ex)
                {

                    LogTestResult("Add to cart  Test",
                      "Add to cart  failed", ex.Message);
                }


                addToCart.PlaceorderFunction();
                Thread.Sleep(5000);
                try
                {

                    TakeScreenShot();
                  
                    Assert.That(driver.Url.Contains("customer"));

                    LogTestResult("Place order  Test ", "Place order success");


                }
                catch (AssertionException ex)
                {

                    LogTestResult("Place order",
                      "Place order  failed", ex.Message);
                }

            }

            
            }




    }
}
