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
    public class ResetPasswordPage
    {
        [FindsBy(How = How.Id, Using = "form_email")]
        private IWebElement emailInput;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div/div/div/form[1]/div[2]/div/button")]
        private IWebElement resetPasswordButton;

        [FindsBy(How = How.Id, Using = "alertxx")]
        private IWebElement unregisteredAlert;

        [FindsBy(How = How.Id, Using = "form_email-error")]
        private IWebElement invalidAlert;
     
        public void EnterEmailAddress(string emailaddress)
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("form_email")));

            emailInput.SendKeys(emailaddress);
        }

        public void ClickResetPassword()
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div[1]/div/div/div/form[1]/div[2]/div/button")));

            resetPasswordButton.Click();
        }

        public bool UnregisteredAlertIsDisplayed()
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("alertxx")));
            return unregisteredAlert.Displayed;
        }

        public bool InvalidAlertIsDisplayed()
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("form_email-error")));
            return invalidAlert.Displayed;
        }
    }
}
