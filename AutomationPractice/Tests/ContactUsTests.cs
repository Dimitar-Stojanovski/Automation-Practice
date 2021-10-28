using AutomationPractice.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutomationPractice.Tests
{
    public class ContactUsTests:BaseTest
    {
        private string _headerText = "SEND A MESSAGE";
        private string _webmasterText = "If a technical problem occurs on this website";
        private string _successAlertMessage = "Your message has been successfully sent to our team.";
        private string _filePath = @"C:\Users\Dimitar.Stojanovski\Desktop\Screenshot";

        [Test]
        public void PopulateContactUsForm()
        {   
            Assert.Multiple(() =>
            {
                contactUsPage.NavigateToContactUs();
                Assert.AreEqual(contactUsPage.GetSendAMessageHeaderText(), _headerText);
                js.ExecuteScript("window.scrollBy(0, 500)");
                Thread.Sleep(1000);
                contactUsPage.SelectSubjectHeading("Webmaster");
                Thread.Sleep(1000);
                contactUsPage.PopulateEmailAddress("john@gmail.com");
                Assert.AreEqual(contactUsPage.VerifyTextInEmail("value"), "john@gmail.com");
                contactUsPage.PopulateOrderReference("text for order reference");
                Assert.AreEqual(contactUsPage.VerifyTextInOrderReference("value"), "text for order reference");
                contactUsPage.AttachFile(_filePath);
                contactUsPage.PopulateMessageTextArea("This is a simple message shown on the screen");
                Assert.AreEqual(contactUsPage.VerifyTextInMessageBar("value"), "This is a simple message shown on the screen");
                contactUsPage.ClickOnSendBtn();
                Assert.AreEqual(contactUsPage.VerifySuccessAlert(), _successAlertMessage);
                Thread.Sleep(2000);



            });
        }
    }
}
