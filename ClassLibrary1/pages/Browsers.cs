using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Firefox;

namespace ClassLibrary1
{
    public class Browsers
    {
        static IWebDriver webDriver = new FirefoxDriver();

        public static WebDriverWait Wait
        {
            get
            {
                WebDriverWait wait = new WebDriverWait(Browsers.Driver2, new TimeSpan(0, 0, 10));
                return wait;
            }
            
        }

        public static string Title
        {
            get
            {
                return webDriver.Title;
            }
        }

        public static ISearchContext Driver
        {
            get
            {
                return webDriver;
            }
        }

        public static IWebDriver Driver2
        {
            get
            {
                return webDriver;
            }
        }

        public static void Goto(string url)
        {
            webDriver.Url = url;
        }

        public static void CleanUp()
        {
            Variables.CleanUP();
            webDriver.Quit();
        }

    }
}
