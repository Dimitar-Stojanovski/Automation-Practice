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
    public class AddressPage:MethodsCollection
    {
        private IWebDriver driver = null;
        private WebDriverWait wait = null;
        private Actions action = null;
        By _addressHeader = new ClassLoc("page-heading");
        By _deliveryCheckbox = new ContainsClassPath("checkbox", "/div");
        By _deliveryAddressDetails = new IDPath("address_delivery", "/li");
        By _invoceDetails = new IDPath("address_invoice", "/li");
        By _textArea = By.XPath("//*[@class = 'form-control'][@name = 'message']");
        By _proceedToCheckOutBtn = new TextLoc("Proceed to checkout");

        private string[] _deliveryAddressTitles = {"Header", "First Name",  "Company","Adresses", "City State and Postal Code",
                                                    "Country","Phone", "Mobile Phone", "Update"};
        /*private string[] _InvoiceAddressTitles = {"Header", "First Name", "Last Name", "Company", "City State and Postal Code",
                                                    "Country","Phone", "Mobile Phone", "Update"};
*/
        public AddressPage(IWebDriver driver, WebDriverWait wait, Actions action):base(driver, wait , action)
        {
            this.driver = driver;
            this.wait = wait;
            this.action = action;
        }

        public string ReturnHeader()
        {
            return GetTextFromElement(_addressHeader);
        }

        public void ClickOnBillingDeliveryCheckBox()
        {
            webElement(_deliveryCheckbox).Click();
        }

        public string GetDeliveryAddressDetails(string _titles)
        {
            int index = Array.IndexOf(_deliveryAddressTitles, _titles);
            return GetTextFromElements(_deliveryAddressDetails, index);
        }

        public string GetInvoiceDetails(string _titles)
        {
            int index = Array.IndexOf(_deliveryAddressTitles, _titles);
            return GetTextFromElements(_invoceDetails, index);
        }

        public void EnterRandomTextInPlaceHolderArea(string _text)
        {
            webElement(_textArea).SendKeys(_text);
        }

        public void ClickProceedToCheckOutBtn()
        {
            webElement(_proceedToCheckOutBtn).Click();
        }
    }
}
