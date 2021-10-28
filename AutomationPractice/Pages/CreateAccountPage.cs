using AutomationPractice.Utils.Action_Methods;
using AutomationPractice.Utils.Custom_Locators;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;

namespace AutomationPractice.Pages
{
    public class CreateAccountPage:MethodsCollection
    {
        private IWebDriver driver = null;
        private WebDriverWait wait = null;
        private SelectElement select = null;
        private Actions action = null;
        By _signIn = new ClassLoc("login");
        By _enterEmail = By.Id("email_create");
        By _createAccountBtn = By.Id("SubmitCreate");
        By _radioButtons = new ClassLoc("radio-inline");
        By _firstName = By.Id("customer_firstname");
        By _lastName = By.Id("customer_lastname");
        By _passwordPlaceholder = By.Id("passwd");
        By _daysPlaceHolder = By.Id("uniform-days");
        By _selectDaysDrop = By.Id("days");
        By _monthPlaceholder = By.Id("uniform-months");
        By _selectMonthDrop = By.Id("months");
        By _yearDropdown = By.Id("uniform-years");
        By _selectYear = By.Id("years");
        By _newsLettersCheckBx = new ClassLoc("checker");
        By _customerFirstName = By.Id("firstname");
        By _customerLastName = By.Id("lastname");
        By _customerCompany = By.Id("company");
        By _address1 = By.Id("address1");
        By _address2 = By.Id("address2");
        By _city = By.Id("city");
        By _state = By.Id("id_state");
        By _statePlaceHolder = By.Id("uniform-id_state");
        By _postalCode = By.Id("postcode");
        By _addInfo = By.Id("other");
        By _homePhone = By.Id("phone");
        By _mobilePhone = By.Id("phone_mobile");
        By _addressAlias = By.Id("alias");
        By _registerBtn = By.Id("submitAccount");
        By _infoAccountMessage = new ClassLoc("info-account");
        By _accountAlreadyExistMsg = new IDPath("create_account_error", "ol/li");

        private string[] _radioTitles = { "Mr.", "Mrs." };
        private string[] _monthsTitles = { "-","January ", "February", "March", "April", "May", "June", "July",
                                           "August", "September", "October", "November", "December" };
        private string[] _checkBoxTitles = { "Sign up for our newsletter!", "Receive special offers from our partners!" };
        private string[] _statesTitles = { "-", "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Delaware" };

        public CreateAccountPage(IWebDriver driver, WebDriverWait wait, SelectElement select, Actions action):base(driver, wait, action)
        {
            this.driver = driver;
            this.wait = wait;
            this.select = select;
            this.action = action;
        }


        public void ClickOnSingIn()
        {
            webElement(_signIn).Click();
        }

        public bool SignInIsPresent()
        {
            return ElementIsDisplayed(_signIn);
        }

        public void EnterEmailAddress(string _email)
        {
            webElement(_enterEmail).SendKeys(_email);
        }

        public string CheckEmailTextIsInserted(string _value)
        {
            return GetAttributeFromElement(_enterEmail, _value);
        }

        

        public void ClickCreateAccount()
        {
            webElement(_createAccountBtn).Click();
        }

        public bool VerifyCreateAccountBtn()
        {
            return ElementIsDisplayed(_createAccountBtn);
        }

        public void ChooseGender(string _gender)
        {
            int index = Array.IndexOf(_radioTitles, _gender);
            webElements(_radioButtons)[index].Click();
        }
       

        public void EnterFirstName(string _name)
        {
            webElement(_firstName).SendKeys(_name);
        }
        
        public string EnteredFirstNameCheck(string _value)
        {
            return GetAttributeFromElement(_firstName, _value);
        }

        public void EnterLastName(string _lastName)
        {
            webElement(this._lastName).SendKeys(_lastName);
        }
        public string EnteredLastNameCheck(string _value)
        {
            return GetAttributeFromElement(_lastName, _value);
        }

        public void EnterPassword(string _password)
        {
            webElement(_passwordPlaceholder).SendKeys(_password);
        }
        public string EnteredPasswordCheck(string _value)
        {
            return GetAttributeFromElement(_passwordPlaceholder, _value);
        }

        public void SelectDays(int _days)
        {
            select = new SelectElement(driver.FindElement(_selectDaysDrop));
            select.SelectByValue(""+_days);
            
        }
        public void SelectMonth(string _months)
        {
            int index = Array.IndexOf(_monthsTitles, _months);
            select = new SelectElement(driver.FindElement(_selectMonthDrop));
            select.SelectByIndex(index);
        } 
        public void SelectYear(int year)
        {
            select = new SelectElement(driver.FindElement(_selectYear));
            select.SelectByValue("" + year);
          
        }
        
        public void SelectCheckBoxOffer(string _titles)
        {
            int index = Array.IndexOf(_checkBoxTitles, _titles);
            webElements(_newsLettersCheckBx)[index].Click();
        }

       
        public string CustomerFirstNameIsInserted(string _value)
        {
            return GetAttributeFromElement(_customerFirstName, _value);
        }

       
        public string CustomerLastNameIsInserted(string _value)
        {
            return GetAttributeFromElement(_customerLastName, _value);
        }

        public void EnterCustomerAddress(string _address)
        {
            webElement(_address1).SendKeys(_address);
        }
        public string CustomerAddressIsInserted(string _value)
        {
            return GetAttributeFromElement(_address1, _value);
        }

        public void EnterCustomerAddress2(string _address2)
        {
            webElement(this._address2).SendKeys(_address2);
        }
        public string CustomerAddress2Inserted(string _value)
        {
            return GetAttributeFromElement(_address2, _value);
        }
        public void EnterCompany(string _company)
        {
            webElement(_customerCompany).SendKeys(_company);
        }

        public string CustomerCompanyisInserted(string _value)
        {
            return GetAttributeFromElement(_customerCompany, _value);
        }

        public void EnterCity(string _cityName)
        {
            webElement(_city).SendKeys(_cityName);
        }

        public string IsCityInserted(string _value)
        {
            return GetAttributeFromElement(_city, _value);
        }

        public void SelectState(string _states)
        {
            /* int index = Array.IndexOf(_statesTitles, _states);
             webElement(_statePlaceHolder).Click();
             Thread.Sleep(500);
             webElements(_state)[index].Click();
             Thread.Sleep(500);
             webElement(_statePlaceHolder).Click();*/
            select = new SelectElement(driver.FindElement(_state));
            select.SelectByText(_states);
        }
        public void EnterPostalCode(int _postalCodeNumber)
        {
            webElement(_postalCode).SendKeys(""+_postalCodeNumber);
        }
       
        public string IsPostalCodeInserted(string _value)
        {
            return GetAttributeFromElement(_postalCode, _value);
        }

        public void EnterAdditionalInfo(string _text)
        {
            webElement(_addInfo).SendKeys(_text);
        }
        public string IsAddInfoInserted(string _value)
        {
            return GetAttributeFromElement(_addInfo, _value);
        }

        public void EnterHomeNumber(int _number)
        {
            webElement(_homePhone).SendKeys(""+_number);
        }
        public string IsHomeNumberInserted(string _value)
        {
            return GetAttributeFromElement(_homePhone, _value);
        }

        public void EnterMobileNumber(int _number)
        {
            webElement(_mobilePhone).SendKeys("" + _number);
        }
        public string IsMobileNUmberInserted(string _value)
        {
            return GetAttributeFromElement(_mobilePhone,_value);
        }

        public void EnterAliasAddress(string _address)
        {
            webElement(_addressAlias).SendKeys("" + _address);
        }

        public void ClearAliasAddresField()
        {
            webElement(_addressAlias).Clear();
        }

        public string IsAliasAddressInserted(string _value)
        {
            return GetAttributeFromElement(_addressAlias, _value);
        }

        public void ClickOnRegisterBtn()
        {
            webElement(_registerBtn).Click();
        }

        public string MessageForCreatingAccount()
        {
            return GetTextFromElement(_infoAccountMessage);
        }

        public string GetUserAlreadyExistMessage()
        {
            return GetTextFromElement(_accountAlreadyExistMsg);
        }
    }
}
