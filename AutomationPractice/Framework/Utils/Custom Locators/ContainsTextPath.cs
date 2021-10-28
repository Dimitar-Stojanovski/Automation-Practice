using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AutomationPractice.Utils.Custom_Locators
{
    public class ContainsTextPath : By
    {
        public ContainsTextPath(string _value, string _additionalPath)
        {
            FindElementMethod = (ISearchContext context) =>
            {
                IWebElement mockElement = context.FindElement(By.XPath("//*[contains(text(),'" + _value + "')]" + _additionalPath));
                return mockElement;

            };

            FindElementsMethod = (ISearchContext context) =>
            {
                ReadOnlyCollection<IWebElement> mockElements = context.FindElements(By.XPath("//*[contains(text(),'" + _value + "')]" + _additionalPath));
                return mockElements;
            };
        }
    }
}
