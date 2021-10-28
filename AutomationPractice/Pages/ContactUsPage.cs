using AutomationPractice.Utils.Action_Methods;
using AutomationPractice.Utils.Custom_Locators;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using AutoItX3Lib;

namespace AutomationPractice.Pages
{
    public class ContactUsPage:MethodsCollection
    {
       
        private IWebDriver driver = null;
        private WebDriverWait wait = null;
        private SelectElement select= null;
        private Actions action = null;
        private AutoItX3 autoIt;
        
        By _contactUs = By.XPath("//*[@title='Contact Us']");
        By _subjectHeading = By.Id("uniform-id_contact");
        By _subjectHeadingValues = By.Id("id_contact");
        By _emailInput = By.Id("email");
        By _orderReference = By.Id("id_order");
        By _fileUpload = By.Id("fileUpload");
        By _messageTextArea = By.Id("message");
        By _sendButton = By.Id("submitMessage");
        By _sendAMessageHeader = new TextLoc("send a message");
        By _webmasterTextValue = By.XPath("desc_contact2");
        By _upploadFile = By.Id("uniform-fileUpload");
        By _chooseFile = new TextLoc("Choose File");
        By _successMessageAlert = new ClassLoc("alert alert-success");
        private string[] _dropDownValues = { "-- Choose --", "Customer service", "Webmaster" };
        

        public ContactUsPage(IWebDriver driver, WebDriverWait wait, SelectElement select, Actions action):base(driver, wait, action)
        {
            this.driver = driver;
            this.wait = wait;
            this.select = select;
            this.action = action;
            
        }

        public void NavigateToContactUs()
        {
            webElement(_contactUs).Click();
        }

        public void SelectSubjectHeading(string _text)
        {
            /* webElement(_subjectHeading).Click();
             int index = Array.IndexOf(_dropDownValues, _text);
             webElements(_subjectHeadingValues)[index].Click();*/
            select = new SelectElement(driver.FindElement(_subjectHeadingValues));
            select.SelectByText(_text);



        }

        public void PopulateEmailAddress(string _text)
        {
            webElement(_emailInput).SendKeys(_text);
        }

        public void PopulateOrderReference(string _text)
        {
            webElement(_orderReference).SendKeys(_text);
        }

        public void PopulateMessageTextArea(string _text)
        {
            webElement(_messageTextArea).SendKeys(_text);
        }

        public void AttachFile(string _pathfile)
        {
            webElement(_upploadFile).Click();
            Thread.Sleep(2000);
            autoIt = new AutoItX3();

            autoIt.WinActivate("Open");
            autoIt.Send(_pathfile);
            autoIt.Send("{ENTER}");

        }

        public void ClickOnSendBtn()
        {
            webElement(_sendButton).Click();
        }

        public string GetSendAMessageHeaderText()
        {
           return GetTextFromElement(_sendAMessageHeader);
        }

        public bool VerifyTextAfterSelectingWebMaster(string _value)
        {
            return TextInElement(_webmasterTextValue, _value);
        }

        public string VerifyTextInEmail(string _value)
        {
            return GetAttributeFromElement(_emailInput, _value);
        }

        public string VerifyTextInOrderReference(string _value)
        {
            return GetAttributeFromElement(_orderReference, _value);
        }

        public string VerifyTextInMessageBar(string _value)
        {
            return GetAttributeFromElement(_messageTextArea, _value);
        }

        public string VerifySuccessAlert()
        {
            return GetTextFromElement(_successMessageAlert);
        }
    }
}
