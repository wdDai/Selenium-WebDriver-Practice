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
    public class SignupPage
    {
        [FindsBy(How = How.Id, Using = "register_email")]
        private IWebElement emailInput;

        [FindsBy(How = How.Id, Using = "register_nickname")]
        private IWebElement usernameInput;

        [FindsBy(How = How.Id, Using = "register_password")]
        private IWebElement passwordInput;

        [FindsBy(How = How.Id, Using = "captcha_code")]
        private IWebElement captchaCodeInput;

        [FindsBy(How = How.Id, Using = "register-btn")]
        private IWebElement registerButton;

        public void EnterEmail(string emailAddress)
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("register_email")));
            emailInput.SendKeys(emailAddress);
        }

        public void EnterUsername(string username)
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("register_nickname")));
            usernameInput.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("register_password")));
            passwordInput.SendKeys(password);
        }

        public void EnterCaptchaCode(string captchaCode)
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("captcha_code")));
            captchaCodeInput.SendKeys(captchaCode);
        }

        public bool ProperEmailErrorIsDisplayed()
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("register_email-error")));
            return Browsers.Driver2.FindElement(By.Id("register_email-error")).Text == "请输入有效的电子邮件地址";
        }

        public bool ProperUsernameErrorIsDisplayed()
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("register_nickname-error")));
            return Browsers.Driver2.FindElement(By.Id("register_nickname-error")).Text == "字符长度必须小于等于18，一个中文字算2个字符";
        }

        public bool ProperPasswordErrorIsDisplayed()
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("register_password-error")));
            return Browsers.Driver2.FindElement(By.Id("register_password-error")).Text == "最少需要输入 5 个字符";
        }

        public bool ProperCaptchaErrorIsDisplayed()
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("captcha_code-error")));
            return Browsers.Driver2.FindElement(By.Id("captcha_code-error")).Text == "验证码错误";
        }

        public void ClickRegister()
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("register-btn")));
            registerButton.Click();
        }
    }
}
