using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using Challenge.Helpers;
using Challenge.Hooks;

namespace Challenge.StepDefinitions
{
    public class Base
    {
        public static IWebDriver Driver;
        [BeforeScenario]
        public static void finishTest()
        {
            Driver.Quit();
        }
    }
}