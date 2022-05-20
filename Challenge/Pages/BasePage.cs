using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TechTalk.SpecFlow;

namespace Challenge.Pages
{
    [Binding]
    public class BasePage
    {
        protected IWebDriver Driver;
        public IWebElement findElement(By element)
        {
            return waitForElement(element);
        }

        public ReadOnlyCollection<IWebElement> findElements(By element)
        {
            waitForElement(element);
            return Driver.FindElements(element);
        }

        public void sendKeys(By element, string text)
        {
            findElement(element).SendKeys(text);
        }

        public void clear(IWebElement element)
        {
            element.Clear();
        }

        public void click(By element)
        {
            findElement(element).Click();
        }
        public void click(IWebElement element)
        {
            element.Click();
        }

        public bool isEnabled(IWebElement element)
        {
            return element.Enabled;
        }
        public string getText(IWebElement element)
        {
            return element.Text;
        }

        public IWebElement waitForElement(By element)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(element));
            }
            catch
            {
                return null;
            }
        }
    }
}

