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
    internal class SignInTest :CoreCodes
    {
        [Test, Order(0)]

        [Category("Regression Testing")]

        public void SignUpTest()
        {

            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(20);
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
                string? phoneNumber = excelData?.PhoneNumber;
                string? firstName = excelData?.FirstName;
                string? lastName = excelData?.LastName;
                string? email = excelData?.Email;

                var sigIn = fluentWait.Until(d => jhp.SignInClick());

                Thread.Sleep(5000);

                try
                {

                    TakeScreenShot();
                    Assert.That(driver.Url.Contains("customer"));
                    LogTestResult("Sign in Click ", "Sign in success");


                }
                catch (AssertionException ex)
                {

                    LogTestResult("Sign in Click",
                      "Signin Click  failed", ex.Message);
                }

                sigIn.SignInFunction(phoneNumber, firstName, lastName, email);
                Thread.Sleep(3000);

                try
                {

                    TakeScreenShot();
                    Assert.That(driver.Url.Contains("customer"));
                    LogTestResult("Sign in Test ", "Sign in success");


                }
                catch (AssertionException ex)
                {

                    LogTestResult("Sign in Test",
                      "Signin Click  failed", ex.Message);
                }

            }
        }
    }
}
