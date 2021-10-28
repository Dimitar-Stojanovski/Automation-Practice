using AutomationPractice.Utils.Action_Methods;
using AutomationPractice.Utils.Custom_Locators;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPractice.Pages
{
    public class ShippingPage:MethodsCollection
    {
        private IWebDriver driver = null;
        private WebDriverWait wait = null;
        private Actions action = null;
        By _shippingHeader = new ClassLoc("page-heading");
        By _shippingOptionHeader = new ContainsText("Choose a shipping");
        By _termsAndServicesChbx = By.Id("uniform-cgv");
        By _proceedToCheckoutBtn = By.XPath("//*[@name ='processCarrier' and contains(@class, 'button-medium')]");

        public ShippingPage(IWebDriver driver, WebDriverWait wait, Actions action):base(driver, wait , action)
        {
            this.driver = driver;
            this.wait = wait;
            this.action = action;
        }

        public string GetShippingHeader()
        {
            return GetTextFromElement(_shippingHeader);
        }

        public string GetChooseShippingOptionsText()
        {
            return GetTextFromElement(_shippingOptionHeader);
        }

        public void ClickOnTermsAndCondCheckbox()
        {
            webElement(_termsAndServicesChbx).Click();
        }

        public void ClickOnProceedToCheckoutBtn()
        {
            webElement(_proceedToCheckoutBtn).Click();
        }
        public bool IsProceedCheckoutBtnDisplayed()
        {
            return ElementIsDisplayed(_proceedToCheckoutBtn);
        }

        public bool IsShippingOptionTextDisplayed(string _value)
        {
            return TextInElement(_shippingOptionHeader, _value);
        }
    }
}
