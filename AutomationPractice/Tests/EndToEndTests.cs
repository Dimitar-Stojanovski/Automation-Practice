using AutomationPractice.Utils;
using AutomationPractice.Utils.Data_Providers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutomationPractice.Tests
{
    public class EndToEndTests:BaseTest
    {
        [TestCaseSource(typeof(CreateAnAccountData), nameof(CreateAnAccountData.TestDataForAccount))]
        public void EndToEndTestInAction(string _email, string _gender, string _firstName, string _lastName, string _password, int _days, string _month, int _year,
                                         string _checkBoxOffer, string _company, string _customerAddress1, string _customerAddress2, string _cityName,
                                         string _state, int _postalCode, string _additionalInfo, int _homePhone, int _mobileNum, string _alias)
        {
            Assert.Multiple(() =>
            {
                addProductPage.ChooseProductCategory("Dresses");
                addProductPage.ChooseDressCategory("Casual Dresses");
                Assert.AreEqual(addProductPage.GetTitleInDressCategory(), "CASUAL DRESSES ");
                addProductPage.SelectSize("S");
                addProductPage.SelectSize("M");
                js.ExecuteScript("window.scrollBy(0,500)");
                addProductPage.SelectCotton();
                addProductPage.SelectInStock();
                addProductPage.ModifyLeftSlider(90, 0);
                addProductPage.ModifyRightSlider(80, 0);
                Assert.True(addProductPage.IsAddToCartBtnPresent());
                addProductPage.ClickAddToCartBtn();
                Assert.IsTrue(addProductPage.IsProductCompleteTextDisplayed(StaticVariables._ProductSuccessfullyAddedMessage));
                Assert.AreEqual(addProductPage.VerifyProductDetails(0, "Product"), "Printed Dress");
                Assert.AreEqual(addProductPage.VerifyProductDetails(1, "Collour and Quantity"), "Orange, S");
                Assert.True(addProductPage.IsContinueShoppingBtnDisplayed());
                addProductPage.ClickOnContinueShoppingBtn();
                js.ExecuteScript("window.scrollBy(0, -500)");
                addProductPage.NavigateToCategories("Products");
                addProductPage.ChooseDressCategory("Evening Dresses");
                Assert.AreEqual(addProductPage.GetTitleInDressCategory(), "EVENING DRESSES ");
                addProductPage.SelectSortByDropDown("Product Name: A to Z");
                js.ExecuteScript("window.scrollBy(0,400)");
                addProductPage.MoveToProductImageLink();
                Assert.True(addProductPage.IsQuickViewDisplayed());
                addProductPage.ClickOnQuickViewSpan();
                addProductPage.SwitchToIframeProduct();
                addProductPage.ChoosePicture(0);
                addProductPage.ChoosePicture(1);
                addProductPage.EnterQuantity(15, "Increase");
                Thread.Sleep(500);
                addProductPage.EnterQuantity(7, "Decrease");
                addProductPage.ChooseColour(1);
                Assert.True(addProductPage.IsAddToCartIframeDisplayed());
                addProductPage.ClickAddToCartInIframe();
                addProductPage.SwitchToParentFrame();
                Assert.IsTrue(addProductPage.IsProductCompleteTextDisplayed(StaticVariables._ProductSuccessfullyAddedMessage));
                addProductPage.ClickOnContinueShoppingBtn();
                js.ExecuteScript("window.scrollBy(0, -500)");
                addProductPage.ClickOnShoppingCart();
                Assert.AreEqual(addProductPage.VerifySummaryTitles("Product"), "Product");
                Assert.AreEqual(addProductPage.VerifySummaryTitles("Description"), "Description");
                Assert.AreEqual(addProductPage.VerifySummaryTitles("Avail."), "Avail.");
                Assert.AreEqual(addProductPage.VerifySummaryTitles("Unit price"), "Unit price");
                Assert.AreEqual(addProductPage.VerifySummaryTitles("Qty"), "Qty");
                Assert.AreEqual(addProductPage.VerifySummaryTitles("Total"), "Total");
                js.ExecuteScript("window.scrollBy(0, 500)");
                addProductPage.ClickProceedToCheckout();
                //REGISTER USER
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
                Assert.AreEqual(createAccount.IsHomeNumberInserted("value"), "" + _homePhone);
                createAccount.EnterMobileNumber(_mobileNum);
                Assert.AreEqual(createAccount.IsMobileNUmberInserted("value"), "" + _mobileNum);
                createAccount.ClearAliasAddresField();
                createAccount.EnterAliasAddress(_alias);
                Assert.AreEqual(createAccount.IsAliasAddressInserted("value"), _alias);
                createAccount.ClickOnRegisterBtn();
                
                //Address Page
                Assert.AreEqual(addressPage.ReturnHeader(), StaticVariables._BILLING_HEADER_TITLE);
                js.ExecuteScript("window.scrollBy(0,400)");
                addressPage.ClickOnBillingDeliveryCheckBox();
                Assert.AreEqual(addressPage.GetDeliveryAddressDetails("Header"), StaticVariables._DELIVERY_HEADER);
                Assert.AreEqual(addressPage.GetDeliveryAddressDetails("First Name"), _firstName+" "+_lastName);
                Assert.AreEqual(addressPage.GetDeliveryAddressDetails("Company"), _company);
                Assert.AreEqual(addressPage.GetDeliveryAddressDetails("Adresses"), _customerAddress1+ " " + _customerAddress2);
                Assert.AreEqual(addressPage.GetDeliveryAddressDetails("City State and Postal Code"), _cityName+", "+_state+" "+_postalCode);
                Assert.AreEqual(addressPage.GetDeliveryAddressDetails("Country"), "United States");
                Assert.AreEqual(addressPage.GetDeliveryAddressDetails("Phone"), ""+_homePhone);
                Assert.AreEqual(addressPage.GetDeliveryAddressDetails("Mobile Phone"), ""+_mobileNum);
                Assert.AreEqual(addressPage.GetInvoiceDetails("Header"), StaticVariables._BILING_DETAILS_HEADER);
                Assert.AreEqual(addressPage.GetInvoiceDetails("First Name"), _firstName + " " + _lastName);
                Assert.AreEqual(addressPage.GetInvoiceDetails("Company"), _company);
                Assert.AreEqual(addressPage.GetInvoiceDetails("Adresses"), _customerAddress1 + " " + _customerAddress2);
                Assert.AreEqual(addressPage.GetInvoiceDetails("City State and Postal Code"), _cityName + ", " + _state + " " + _postalCode);
                Assert.AreEqual(addressPage.GetInvoiceDetails("Country"), "United States");
                Assert.AreEqual(addressPage.GetInvoiceDetails("Phone"),""+ _homePhone);
                Assert.AreEqual(addressPage.GetInvoiceDetails("Mobile Phone"),""+ _mobileNum);
                addressPage.EnterRandomTextInPlaceHolderArea("Random text is inserted");
                js.ExecuteScript("window.scrollBy(0,500)");
                addressPage.ClickProceedToCheckOutBtn();

                //SHIPPING PAGE
                Assert.AreEqual(shippingPage.GetShippingHeader(), StaticVariables._SHIPPING_HEADER);
                shippingPage.ClickOnTermsAndCondCheckbox();
                js.ExecuteScript("window.scrollBy(0,500)");
                Assert.True(shippingPage.IsProceedCheckoutBtnDisplayed());
                shippingPage.ClickOnProceedToCheckoutBtn();
                Thread.Sleep(2000);

                //PAYMENT PAGE
                Assert.AreEqual(paymentPage.GetPaymentMethodHeader(), StaticVariables._PAYMENT_PAGE_HEADER);
                js.ExecuteScript("window.scrollBy(0,500)");
                paymentPage.ChoosePaymentMethod("Pay by Bank Wire");
                Assert.AreEqual(paymentPage.GetPaymentMethodHeader(), StaticVariables._ORDER_SUMMARY_HEADER);
                Assert.AreEqual(paymentPage.GetPageSubHeader(), StaticVariables._PAGE_SUMMARY_SUB_HEADER);
                Assert.AreEqual(paymentPage.GetCheckDetails("Summary"), "You have chosen to pay by bank wire. Here is a short summary of your order:");
                Assert.AreEqual(paymentPage.GetCheckDetails("Total Amount"), "- The total amount of your order comes to: $506.39 (tax incl.)");
                Assert.AreEqual(paymentPage.GetCheckDetails("Currency"), "- We allow the following currency to be sent via bank wire: Dollar");
                Assert.AreEqual(paymentPage.GetCheckDetails("Confirm your order"), 
                "- Bank wire account information will be displayed on the next page.\r\n- Please confirm your order by clicking \"I confirm my order.\".");
                Assert.True(paymentPage.IsConfirmBtnDisplayed());
                paymentPage.ClickOnConfirmOrderBtn();
                Thread.Sleep(2000);




            });



        }
        
        [TestCaseSource(typeof(CreateAnAccountData), nameof(CreateAnAccountData.TestDataForAccount))]
        public void EndToEndWithLoggedInUser(string _email, string _gender, string _firstName, string _lastName, string _password, int _days, string _month, int _year,
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
                Assert.AreEqual(createAccount.IsHomeNumberInserted("value"), "" + _homePhone);
                createAccount.EnterMobileNumber(_mobileNum);
                Assert.AreEqual(createAccount.IsMobileNUmberInserted("value"), "" + _mobileNum);
                createAccount.ClearAliasAddresField();
                createAccount.EnterAliasAddress(_alias);
                Assert.AreEqual(createAccount.IsAliasAddressInserted("value"), _alias);
                createAccount.ClickOnRegisterBtn();
                Assert.AreEqual(createAccount.MessageForCreatingAccount(), StaticVariables._ACCOUNT_WELCOMING_MESSAGE);

                //ADDING PRODUCT
                addProductPage.ChooseProductCategory("Dresses");
                addProductPage.ChooseDressCategory("Casual Dresses");
                Assert.AreEqual(addProductPage.GetTitleInDressCategory(), "CASUAL DRESSES ");
                addProductPage.SelectSize("S");
                addProductPage.SelectSize("M");
                js.ExecuteScript("window.scrollBy(0,500)");
                addProductPage.SelectCotton();
                addProductPage.SelectInStock();
                addProductPage.ModifyLeftSlider(90, 0);
                addProductPage.ModifyRightSlider(80, 0);
                Assert.True(addProductPage.IsAddToCartBtnPresent());
                addProductPage.ClickAddToCartBtn();
                Assert.IsTrue(addProductPage.IsProductCompleteTextDisplayed(StaticVariables._ProductSuccessfullyAddedMessage));
                Assert.AreEqual(addProductPage.VerifyProductDetails(0, "Product"), "Printed Dress");
                Assert.AreEqual(addProductPage.VerifyProductDetails(1, "Collour and Quantity"), "Orange, S");
                Assert.True(addProductPage.IsContinueShoppingBtnDisplayed());
                addProductPage.ClickOnContinueShoppingBtn();
                js.ExecuteScript("window.scrollBy(0, -500)");
                addProductPage.NavigateToCategories("Products");
                addProductPage.ChooseDressCategory("Evening Dresses");
                Assert.AreEqual(addProductPage.GetTitleInDressCategory(), "EVENING DRESSES ");
                addProductPage.SelectSortByDropDown("Product Name: A to Z");
                js.ExecuteScript("window.scrollBy(0,500)");
                addProductPage.MoveToProductImageLink();
                Assert.True(addProductPage.IsQuickViewDisplayed());
                addProductPage.ClickOnQuickViewSpan();
                addProductPage.SwitchToIframeProduct();
                addProductPage.ChoosePicture(0);
                addProductPage.ChoosePicture(1);
                addProductPage.EnterQuantity(15, "Increase");
                Thread.Sleep(500);
                addProductPage.EnterQuantity(7, "Decrease");
                addProductPage.ChooseColour(1);
                Assert.True(addProductPage.IsAddToCartIframeDisplayed());
                addProductPage.ClickAddToCartInIframe();
                addProductPage.SwitchToParentFrame();
                Assert.IsTrue(addProductPage.IsProductCompleteTextDisplayed(StaticVariables._ProductSuccessfullyAddedMessage));
                addProductPage.ClickOnContinueShoppingBtn();
                js.ExecuteScript("window.scrollBy(0, -500)");
                addProductPage.ClickOnShoppingCart();
                Assert.AreEqual(addProductPage.VerifySummaryTitles("Product"), "Product");
                Assert.AreEqual(addProductPage.VerifySummaryTitles("Description"), "Description");
                Assert.AreEqual(addProductPage.VerifySummaryTitles("Avail."), "Avail.");
                Assert.AreEqual(addProductPage.VerifySummaryTitles("Unit price"), "Unit price");
                Assert.AreEqual(addProductPage.VerifySummaryTitles("Qty"), "Qty");
                Assert.AreEqual(addProductPage.VerifySummaryTitles("Total"), "Total");
                js.ExecuteScript("window.scrollBy(0, 500)");
                addProductPage.ClickProceedToCheckout();
                //Address Page
                Assert.AreEqual(addressPage.ReturnHeader(), StaticVariables._BILLING_HEADER_TITLE);
                js.ExecuteScript("window.scrollBy(0,400)");
                addressPage.ClickOnBillingDeliveryCheckBox();
                Assert.AreEqual(addressPage.GetDeliveryAddressDetails("Header"), StaticVariables._DELIVERY_HEADER);
                Assert.AreEqual(addressPage.GetDeliveryAddressDetails("First Name"), _firstName + " " + _lastName);
                Assert.AreEqual(addressPage.GetDeliveryAddressDetails("Company"), _company);
                Assert.AreEqual(addressPage.GetDeliveryAddressDetails("Adresses"), _customerAddress1 + " " + _customerAddress2);
                Assert.AreEqual(addressPage.GetDeliveryAddressDetails("City State and Postal Code"), _cityName + ", " + _state + " " + _postalCode);
                Assert.AreEqual(addressPage.GetDeliveryAddressDetails("Country"), "United States");
                Assert.AreEqual(addressPage.GetDeliveryAddressDetails("Phone"), "" + _homePhone);
                Assert.AreEqual(addressPage.GetDeliveryAddressDetails("Mobile Phone"), "" + _mobileNum);
                Assert.AreEqual(addressPage.GetInvoiceDetails("Header"), StaticVariables._BILING_DETAILS_HEADER);
                Assert.AreEqual(addressPage.GetInvoiceDetails("First Name"), _firstName + " " + _lastName);
                Assert.AreEqual(addressPage.GetInvoiceDetails("Company"), _company);
                Assert.AreEqual(addressPage.GetInvoiceDetails("Adresses"), _customerAddress1 + " " + _customerAddress2);
                Assert.AreEqual(addressPage.GetInvoiceDetails("City State and Postal Code"), _cityName + ", " + _state + " " + _postalCode);
                Assert.AreEqual(addressPage.GetInvoiceDetails("Country"), "United States");
                Assert.AreEqual(addressPage.GetInvoiceDetails("Phone"), "" + _homePhone);
                Assert.AreEqual(addressPage.GetInvoiceDetails("Mobile Phone"), "" + _mobileNum);
                addressPage.EnterRandomTextInPlaceHolderArea("Random text is inserted");
                js.ExecuteScript("window.scrollBy(0,500)");
                addressPage.ClickProceedToCheckOutBtn();

                //SHIPPING PAGE
                Assert.AreEqual(shippingPage.GetShippingHeader(), StaticVariables._SHIPPING_HEADER);
                shippingPage.ClickOnTermsAndCondCheckbox();
                js.ExecuteScript("window.scrollBy(0,500)");
                Assert.True(shippingPage.IsProceedCheckoutBtnDisplayed());
                shippingPage.ClickOnProceedToCheckoutBtn();
                Thread.Sleep(2000);

                //PAYMENT PAGE
                Assert.AreEqual(paymentPage.GetPaymentMethodHeader(), StaticVariables._PAYMENT_PAGE_HEADER);
                js.ExecuteScript("window.scrollBy(0,500)");
                paymentPage.ChoosePaymentMethod("Pay by Bank Wire");
                Assert.AreEqual(paymentPage.GetPaymentMethodHeader(), StaticVariables._ORDER_SUMMARY_HEADER);
                Assert.AreEqual(paymentPage.GetPageSubHeader(), StaticVariables._PAGE_SUMMARY_SUB_HEADER);
                Assert.AreEqual(paymentPage.GetCheckDetails("Summary"), "You have chosen to pay by bank wire. Here is a short summary of your order:");
                Assert.AreEqual(paymentPage.GetCheckDetails("Total Amount"), "- The total amount of your order comes to: $506.39 (tax incl.)");
                Assert.AreEqual(paymentPage.GetCheckDetails("Currency"), "- We allow the following currency to be sent via bank wire: Dollar");
                Assert.AreEqual(paymentPage.GetCheckDetails("Confirm your order"),
                "- Bank wire account information will be displayed on the next page.\r\n- Please confirm your order by clicking \"I confirm my order.\".");
                Assert.True(paymentPage.IsConfirmBtnDisplayed());
                paymentPage.ClickOnConfirmOrderBtn();
                


            });
        }

    }
}
