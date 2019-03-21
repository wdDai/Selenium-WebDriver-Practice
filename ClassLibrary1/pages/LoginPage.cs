using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;

namespace ClassLibrary1
{
    public class LoginPage
    {
        [FindsBy(How = How.Id, Using = "login_username")]
        private IWebElement usernameInput;

        [FindsBy(How = How.Id, Using = "login_password")]
        private IWebElement passwordInput;

        [FindsBy(How = How.ClassName, Using = "js-btn-login")]
        private IWebElement loginButton;

        [FindsBy(How = How.Name, Using = "_remember_me")]
        private IWebElement rememberMeCheckbox;

        [FindsBy(How = How.CssSelector, Using = ".alert")]
        private IWebElement alert;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div/div[1]/a[1]")]
        private IWebElement loginTab;

        [FindsBy(How = How.LinkText, Using = "找回密码")]
        private IWebElement resetPasswordLink;


        public void ClickSignup()
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div[1]/div/div[1]/a[2]")));
            IWebElement signupTab = Browsers.Driver2.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div[1]/a[2]"));

            signupTab.Click();
        }

        public void ClickResetPassword()
        {
            
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("找回密码")));

            resetPasswordLink.Click();
        }

        public void EnterUsername(string userName)
        {
            
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login_username")));

            usernameInput.Clear();
            usernameInput.SendKeys(userName);
        }

        public void EnterPassword(string password)
        {
            
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login_password")));

            passwordInput.Clear();
            passwordInput.SendKeys(password);
        }

        public void ClickLogin()
        {
            
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("js-btn-login")));

            loginButton.Click();
        }

        public void RememberMeUnselected()
        {
            
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.Name("_remember_me")));

            if(rememberMeCheckbox.Selected)
                {
                    rememberMeCheckbox.Click();
                }
        }

        public void RememberMeSelected()
        {
            
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.Name("_remember_me")));

            if (rememberMeCheckbox.Selected)
                {
                }
            else
                {
                rememberMeCheckbox.Click();
                }
        }
        
        public bool LoginIsFailed()
        {
            
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".alert")));

            return alert.Displayed;
        }

        public bool LogoutIsSuccessful()
        {
            
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div[1]/div/div[1]/a[1]")));

            return loginTab.Displayed;
        }
    }

}
