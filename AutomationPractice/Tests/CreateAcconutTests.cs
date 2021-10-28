using AutomationPractice.Utils;
using AutomationPractice.Utils.Data_Providers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutomationPractice.Tests
{
    public class CreateAcconutTests:BaseTest
    {
        
        private string _accountWelcomingMsg = "Welcome to your account. Here you can manage all of your personal information and orders.";


        [TestCaseSource(typeof(CreateAnAccountData), nameof(CreateAnAccountData.TestDataForAccount))]
        
        public void CreateAnAccount(string _email,string _gender, string _firstName, string _lastName, string _password, int _days, string _month, int _year,
                                    string _checkBoxOffer, string _company, string _customerAddress1, string _customerAddress2, string _cityName,
                                    string _state, int _postalCode, string _additionalInfo, int _homePhone, int _mobileNum, string _alias)
        {
            Assert.Multiple(() =>
            {
                Assert.IsTrue(createAccount.SignInIsPresent());
                createAccount.ClickOnSingIn();
                createAccount.EnterEmailAddress(_email);
                Assert.AreEqual(createAccount.CheckEmailTextIsInserted("value"), _email);
                createAccount.ClickCreateAccount();
                Assert.True(createAccount.VerifyCreateAccountBtn());
                createAccount.ChooseGender(_gender);
                createAccount.EnterFirstName(_firstName);
                Assert.AreEqual(createAccount.EnteredFirstNameCheck("value"), _firstName);
                createAccount.EnterLastName(_lastName);
                Assert.AreEqual(createAccount.EnteredLastNameCheck("value"), _lastName);
                createAccount.EnterPassword(_password);
                Assert.AreEqual(createAccount.EnteredPasswordCheck("value"), _password);
                createAccount.SelectDays(_days);
                createAccount.SelectMonth(_month);
                createAccount.SelectYear(_year);
                createAccount.SelectCheckBoxOffer(_checkBoxOffer);
                js.ExecuteScript("window.scrollBy(0,500)");

                //ADDRESS
                
                Assert.AreEqual(createAccount.CustomerFirstNameIsInserted("value"), _firstName);
                Assert.AreEqual(createAccount.CustomerLastNameIsInserted("value"), _lastName);
                createAccount.EnterCompany(_company);
                Assert.AreEqual(createAccount.CustomerCompanyisInserted("value"), _company);
                createAccount.EnterCustomerAddress(_customerAddress1);
                Assert.AreEqual(createAccount.CustomerAddressIsInserted("value"), _customerAddress1);
                createAccount.EnterCustomerAddress2(_customerAddress2);
                Assert.AreEqual(createAccount.CustomerAddress2Inserted("value"), _customerAddress2);
                js.ExecuteScript("window.scrollBy(0,500)");
                createAccount.EnterCity(_cityName);
                Assert.AreEqual(createAccount.IsCityInserted("value"), _cityName);
                createAccount.SelectState(_state);
                createAccount.EnterPostalCode(_postalCode);
                Assert.AreEqual(createAccount.IsPostalCodeInserted("value"), "" + _postalCode);
                createAccount.EnterAdditionalInfo(_additionalInfo);
                Assert.AreEqual(createAccount.IsAddInfoInserted("value"), _additionalInfo);
                createAccount.EnterHomeNumber(_homePhone);
                Assert.AreEqual(createAccount.IsHomeNumberInserted("value"),""+_homePhone);
                createAccount.EnterMobileNumber(_mobileNum);
                Assert.AreEqual(createAccount.IsMobileNUmberInserted("value"), "" + _mobileNum);
                createAccount.ClearAliasAddresField();
                createAccount.EnterAliasAddress(_alias);
                Assert.AreEqual(createAccount.IsAliasAddressInserted("value"), _alias);
                createAccount.ClickOnRegisterBtn();
                Assert.AreEqual(createAccount.MessageForCreatingAccount(), _accountWelcomingMsg);

                Thread.Sleep(2000);
            });


            
            
            
        }

        [Test]
        public void TestWithInvalidAccount()
        {
            Assert.IsTrue(createAccount.SignInIsPresent());
            createAccount.ClickOnSingIn();
            createAccount.EnterEmailAddress("Sample12344@mail.com");
            Assert.AreEqual(createAccount.CheckEmailTextIsInserted("value"), "Sample12344@mail.com");
            createAccount.ClickCreateAccount();
            Assert.True(createAccount.VerifyCreateAccountBtn());
            Assert.AreEqual(createAccount.GetUserAlreadyExistMessage(), StaticVariables._USER_ALREADY_REGISTERED_MSG);

        }
    }

          
         
}
