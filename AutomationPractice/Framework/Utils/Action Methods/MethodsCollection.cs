using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AutomationPractice.Utils.Action_Methods
{
    public class MethodsCollection
    {
        public IWebDriver driver = null;
        public WebDriverWait wait = null;
        private Actions action = null;

        public MethodsCollection(IWebDriver driver, WebDriverWait wait, Actions action)
        {
            this.driver = driver;
            this.wait = wait;
            this.action = action;
        }

        public IWebElement webElement(By _locator)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(_locator));
            
        }

        public IList<IWebElement> webElements(By _locator)
        {
            return wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(_locator));
        }

        public string GetTextFromElement(By _locator)
        {
            return wait.Until(ExpectedConditions.ElementExists(_locator)).Text;
        }

        public void switchToFrame(By _locator)
        {
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(_locator));
        }

        public bool ElementIsDisplayed(By _locator)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(_locator)).Displayed;
        }

        public bool TextInElement(By _locator, string _value)
        {
            return wait.Until(ExpectedConditions.TextToBePresentInElementLocated(_locator, _value));
            
        }

        public string GetAttributeFromElement(By _locator, string _value)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(_locator)).GetAttribute(_value);
        }

        
        public void ActionElement(By _locator)
        {
            action = new Actions(driver);
            action.MoveToElement(wait.Until(ExpectedConditions.ElementIsVisible(_locator))).Build().Perform();
        }

        public void ActionOnElements(By _locator, int index)
        {
            action.MoveToElement(wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(_locator))[index]).Build().Perform();
        }

        public bool ElementIsSelected(By _locator)
        {
            return wait.Until(ExpectedConditions.ElementIsVisible(_locator)).Selected;
        }

        public void ActionDragAndDrop(By _locator, int x, int y)
        {
            action = new Actions(driver);
            action.ClickAndHold(wait.Until(ExpectedConditions.ElementIsVisible(_locator))).DragAndDropToOffset
                (wait.Until(ExpectedConditions.ElementIsVisible(_locator)),x, y).Build().Perform();
        }

        public string GetTextFromElements(By _locator, int index)
        {
            
            return wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(_locator))[index].Text;
        }

        public void NavigateToTab(ArrayList tabs, int index)
        {
            driver.SwitchTo().Window((string)tabs[index]);
        }

        public ArrayList GetAllTabs()
        {
            return new ArrayList(driver.WindowHandles);
        }

        public void SwitchToParentFrame()
        {
            driver.SwitchTo().DefaultContent();
        }
    }
}
