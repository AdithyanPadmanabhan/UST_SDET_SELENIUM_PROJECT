using MiniProject_JioMart.PageObjects;
using MiniProject_JioMart.Utilities;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_JioMart.TestScripts
{
    internal class FilterAndSearchTest :CoreCodes
    {

        [Test, Order(0)]

        [Category("Regression Testing")]

        public void FilterSearchTest()
        {

           /* DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Product not found";*/

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


                string? product = excelData?.Product;

               




                 var item = fluentWait.Until(d => jhp.CategorySelectionFunction());
            //    Thread.Sleep(4000);
                try
                {

                    TakeScreenShot();
                    Assert.That(driver.Url.Contains("electronics"));
                    LogTestResult("Product Search Test ", "Product Search success");


                }
                catch (AssertionException ex)
                {

                    LogTestResult("Product Search  Test",
                      "Product Search  failed", ex.Message);
                }

            var productSelect = fluentWait.Until(d => item.ProductSelectionFunction());
                try
                {

                    TakeScreenShot();
                    Assert.That(driver.Url.Contains("electronics"));
                    LogTestResult("Category selection Test ", "Category selection success");


                }
                catch (AssertionException ex)
                {

                    LogTestResult("Category selection Test",
                      "Category selection", ex.Message);
                }

                fluentWait.Until(d => productSelect);
                productSelect.ItemSelectionFunction();
               // Thread.Sleep(3000);

                try
                {

                    TakeScreenShot();
                    Assert.That(driver.Url.Contains("electronics"));
                    LogTestResult("Product selection Test ", "Product selection success");
                    test = extent.CreateTest("Product selection Test - Pass");

                }
                catch (AssertionException ex)
                {

                    LogTestResult("Product selection Test",
                      "Product selection", ex.Message);
                }

            }
        }
    }
}
