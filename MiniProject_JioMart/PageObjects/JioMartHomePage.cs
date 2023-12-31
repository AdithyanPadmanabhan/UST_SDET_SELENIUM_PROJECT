﻿using OpenQA.Selenium;
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

        [FindsBy(How = How.XPath, Using = "//button[@class='jm-btn primary small jm-border-none']")]
        private IWebElement? Location { get; set; }

        [FindsBy(How = How.Id, Using = "btn_enter_pincode")]
        private IWebElement? PinCode { get; set; }

        [FindsBy(How = How.Id, Using = "rel_pincode")]
        private IWebElement? PinCodeInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='btn_sign_in']")]
        private IWebElement? SignIn { get; set; }

        [FindsBy(How = How.XPath, Using = " //a[@id='nav_level3_8199']")]
        private IWebElement? GroceryList { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='btn_ham_menu']")]
        private IWebElement? OfferButton { get; set; }

        [FindsBy(How = How.XPath, Using = " //a[@class='d-flex' and @href='/offers']")]
        private IWebElement? OfferStore { get; set; }


        [FindsBy(How = How.Id, Using = "btn_search_list")]
        private IWebElement? MultiSearch { get; set; }



        [FindsBy(How = How.Id, Using = "rel_search_val")]
        private IWebElement? MultiSearchInput { get; set; }


       // (//button[@type='submit'])[1]


        [FindsBy(How = How.XPath, Using = "//button[normalize-space()='Search All']")]
        private IWebElement? MultiSearchButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//img[@alt='JioMart']")]
        private IWebElement? LogoButton { get; set; }


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
        public void LocationSelection(string pincode)
        {
            Location?.Click();
            PinCode?.Click();
            PinCodeInput?.SendKeys(pincode);
            PinCodeInput?.SendKeys(Keys.Enter);

        }

        public SignIn SignInClick()
        {
            SignIn?.Click();

            return new SignIn(driver);
           
        }

        public void GrocerySelection()
        {
            GroceryList?.Click();
        }

        public OfferPage OfferFunction()
        {
            OfferButton?.Click();

            OfferStore?.Click();

            return new OfferPage(driver);
        }

        public void MultiSearchFunction(string multiProduct)
        {
            MultiSearch?.Click();

            MultiSearchInput?.SendKeys(multiProduct);
          
            MultiSearchButton?.Click();
          

        }

        public void LogoButtonFunction()
        {
            LogoButton?.Click();
        }





}
}
