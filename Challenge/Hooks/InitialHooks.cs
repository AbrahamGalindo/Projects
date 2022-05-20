using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using TechTalk.SpecFlow;
using System.Configuration;
using Challenge.StepDefinitions;
using Challenge.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Hooks
{
    [Binding]
    public sealed class InitialHooks
    {

        [BeforeScenario]
        public static void BeforeScenario()
        {
            CreateWebDriver();
        }

        public static void CreateWebDriver()
        {
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;

            IConfiguration configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();
            string host = configuration["URL:test"];

            //Browser properties
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--no-sandbox");
            options.AddArguments("--enable-automation");
            options.AddArguments("--disable-infobars");
            options.AddArguments("--incognito");
            options.AddArguments("--test-type");
            Base.Driver = new ChromeDriver(baseDir, options);
            Base.Driver.Manage().Window.Maximize();
            Base.Driver.Navigate().GoToUrl(host);
        }

        [AfterScenario]
        public void AfterTest()
        {
            Base.finishTest();
        }
    }
}