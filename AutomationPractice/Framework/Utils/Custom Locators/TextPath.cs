using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AutomationPractice.Utils.Custom_Locators
{
    public class TextPath : By
    {
        public TextPath(string _value, string _additionalPath)
        {
            FindElementMethod = (ISearchContext context) =>
            {
                IWebElement mockElement = context.FindElement(By.XPath("//*[text() ='" + _value + "']" + _additionalPath));
                return mockElement;


            };

            FindElementsMethod = (ISearchContext context) =>
            {
                ReadOnlyCollection<IWebElement> mockElements = context.FindElements(By.XPath("//*[text() ='" + _value + "']" + _additionalPath));
                return mockElements;

            };
        }
    }
}
