using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject_JioMart.PageObjects
{
    internal class SignIn
    {

        IWebDriver driver;
        public SignIn(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));


            PageFactory.InitElements(driver, this);

        }


       
        
        [FindsBy(How = How.XPath, Using = "//input[@id='loginfirst_mobileno' and @name='undefined']")]
       
        private IWebElement? SignInInput { get; set; }



        [FindsBy(How = How.XPath, Using = "//input[@id='fname_input']")]
        private IWebElement? FirstNameInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='lastname_input']")]
        private IWebElement? LastNameInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='name_input']")]
        private IWebElement? EmailInput { get; set; }


        public void SignInFunction(string number, string firstname,string lastname,string email)
        {
            
            SignInInput?.SendKeys(number);
            SignInInput?.SendKeys(Keys.Enter);

            Thread.Sleep(3000);
            FirstNameInput?.SendKeys(firstname);
            LastNameInput?.SendKeys(lastname);
            EmailInput?.SendKeys(email);


        }

    }
}
