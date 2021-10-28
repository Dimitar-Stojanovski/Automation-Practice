using AutomationPractice.Framework;
using AutomationPractice.Pages;
using AutomationPractice.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using AutoItX3Lib;

namespace AutomationPractice.Tests
{
   public class BaseTest
    {
        public IWebDriver driver;
        public WebDriverWait wait;
        public Actions action;
        public IAlert alert;
        public IJavaScriptExecutor js;
        public SelectElement select;
        
        
        Browser browser;
        public  string ChromeBrs = "CHROME";
        public  string FirefoxBrs = "gecko";
        public  string IExplorBrs = "explorer";
        public  string _URL = "http://automationpractice.com/index.php";
        public ContactUsPage contactUsPage;
        public CreateAccountPage createAccount;
        public AddProductPage addProductPage;
        public AddressPage addressPage;
        public ShippingPage shippingPage;
        public PaymentPage paymentPage;


        [SetUp]
        public void InitiateBrowser()
        {
            browser = new Browser();
            driver = browser.SetUp(this.ChromeBrs);
            action = new Actions(driver);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(_URL);
            js = (IJavaScriptExecutor)driver;
            contactUsPage = new ContactUsPage(driver, wait, select, action);
            createAccount = new CreateAccountPage(driver, wait, select, action);
            addProductPage = new AddProductPage(driver, wait, action);
            addressPage = new AddressPage(driver, wait, action);
            shippingPage = new ShippingPage(driver, wait, action);
            paymentPage = new PaymentPage(driver, wait, action);
        }


        [TearDown]
        public void Terminate()
        {
            driver.Quit();
        }
    }
}
