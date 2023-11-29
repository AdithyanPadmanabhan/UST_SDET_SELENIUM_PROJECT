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
    internal class DeliveryLocationTest:CoreCodes
    {

        [Test, Order(0)]

        [Category("Regression Testing")]

        public void LocationTest()
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
                string? pinCode = excelData?.PinCode;

                jhp.LocationSelection(pinCode);
                try
                {

                    TakeScreenShot();
                    Assert.That(driver.Url.Contains("jiomart"));
                    LogTestResult("Delivery Location Test ", "Delivery Location success");


                }
                catch (AssertionException ex)
                {

                    LogTestResult("Delivery Location  Test",
                      "Delivery Location  failed", ex.Message);
                }

            }
        }


            }
        }
