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

namespace ClassLibrary1
{
    public class HomePage
    {
        static readonly string Url = "http://lyratesting2.co.nz/";

        [FindsBy(How = How.LinkText, Using = "登录")]
        private IWebElement loginLink;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/header/nav/div/ul/li[1]/a/img")]
        private IWebElement avatar;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/header/nav/div/ul/li[1]/ul/li[9]/a")]
        private IWebElement logoutButton;

        //[FindsBy(How = How.ClassName, Using = "dropdown-menu")]
        //private IWebElement dropdownMenu;

        //public class AvatarDropdownMenuOption
        //{
        //    string OptionXpath;
        //    public void SetOptionXpath(string Xpath)
        //    {
        //        OptionXpath = Xpath;
        //    }
        //}

        // AvatarDropdownMenuOption optionLogout = new AvatarDropdownMenuOption();



        //public void ChooseAvatarDropdownMenu (AvatarDropdownMenuOption Option)
        //{
        //    WebDriverWait wait = new WebDriverWait(Browsers.Driver2, new TimeSpan(0, 0, 10));
        //    wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("dropdown-menu")));

        //    dropdownMenu.FindElement(By.XPath("{0}", Option.OptionXpath)).Click();
        //}
 

        public void ClickLogin()
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("登录")));

            loginLink.Click();
        }

        public void Login(string userName, string password)
        {
            if (! Variables.IsLoggedIn)
            {
                ClickLogin();
                Pages.LoginPage.EnterUsername(userName);
                Pages.LoginPage.EnterPassword(password);
                Pages.LoginPage.ClickLogin();
                Variables.IsLoggedIn = true;
            }
        }

        public void Goto()
        {
            Browsers.Goto(Url);
        }

        public bool AvatarIsVisible()
        {
            try
            {

                Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("avatar-xs")));
                Variables.IsLoggedIn = true;
                return avatar.Displayed;  
            }
            catch
            {
                Variables.IsLoggedIn = false;
                return false;
            }
            
        }

        public void Logout()
        {
            if (Variables.IsLoggedIn)
            {
                Actions action = new Actions(Browsers.Driver2);
                action.MoveToElement(avatar).Perform();

                IWebElement avatarDropdownMenu = Browsers.Driver2.FindElement(By.ClassName("dropdown-menu"));
                avatarDropdownMenu.FindElement(By.XPath("/html/body/div[1]/header/nav/div/ul/li[1]/ul/li[9]/a")).Click();
                Variables.IsLoggedIn = false;
            }           
        }

        public void GotoSettingsPage()
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("avatar-xs")));

            Actions action = new Actions(Browsers.Driver2);
            action.MoveToElement(avatar).Perform();
            System.Threading.Thread.Sleep(2000);

            IWebElement avatarDropdownMenu = Browsers.Driver2.FindElement(By.ClassName("dropdown-menu"));
            avatarDropdownMenu.FindElement(By.XPath("/html/body/div[1]/header/nav/div/ul/li[1]/ul/li[3]/a")).Click();
        }

        public void GotoAdminPage()
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("avatar-xs")));

            Actions action = new Actions(Browsers.Driver2);
            action.MoveToElement(avatar).Perform();
            System.Threading.Thread.Sleep(2000);

            IWebElement avatarDropdownMenu = Browsers.Driver2.FindElement(By.ClassName("dropdown-menu"));
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/header/nav/div/ul/li[1]/ul/li[6]/a")));
            avatarDropdownMenu.FindElement(By.XPath("/html/body/div[1]/header/nav/div/ul/li[1]/ul/li[6]/a")).Click(); 
        }
    }
}
