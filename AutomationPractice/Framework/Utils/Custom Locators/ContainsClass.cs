using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AutomationPractice.Utils.Custom_Locators
{
    public class ContainsClass : By
    {
        public ContainsClass(string _value)
        {
            FindElementMethod = (ISearchContext context) =>
            {
                IWebElement mockElement = context.FindElement(By.XPath("//*[contains(@class,'" + _value + "')]"));
                return mockElement;
            };

            FindElementsMethod = (ISearchContext context) =>
            {
                ReadOnlyCollection<IWebElement> mockElements = context.FindElements(By.XPath("//*[contains(@class,'" + _value + "')]"));
                return mockElements;
            };
        }
    }
}
