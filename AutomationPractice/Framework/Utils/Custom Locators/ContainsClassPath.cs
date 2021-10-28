using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AutomationPractice.Utils.Custom_Locators
{
    public class ContainsClassPath : By
    {
        public ContainsClassPath(string _value, string _additionalPath)
        {
            FindElementMethod = (ISearchContext context) =>
            {
                IWebElement mockElement = context.FindElement(By.XPath("//*[contains(@class,'" + _value + "')]" + _additionalPath));
                return mockElement;

            };

            FindElementsMethod = (ISearchContext context) =>
            {
                ReadOnlyCollection<IWebElement> mockElements = context.FindElements(By.XPath("//*[contains(@class,'" + _value + "')]" + _additionalPath));
                return mockElements;
            };
        }
    }
}
