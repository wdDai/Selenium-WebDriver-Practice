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
    public class SettingsPage
    {
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div/div[1]/div/ul/li[3]/a")]
        private IWebElement avatarSetting;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div/div[2]/div/div[2]/form/div[3]/div[2]/a/div[2]/input")]
        private IWebElement uploadNewAvatar;

        [FindsBy(How = How.Id, Using = "upload-avatar-btn")]
        private IWebElement saveAvatar;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[1]/div/div[2]/div/div[2]/form/div[1]/div[2]/img")]
        private IWebElement image;

        public void EnterName(string name)
        {
            Browsers.Driver2.FindElement(By.Id("profile_truename")).Clear();
            Browsers.Driver2.FindElement(By.Id("profile_truename")).SendKeys(name);
        }

        public void SaveProfile()
        {
            Browsers.Driver2.FindElement(By.Id("profile-save-btn")).Click();
        }

       public void EnterIdcardNumber(string idCardNumber)
        {
            Browsers.Driver2.FindElement(By.Id("profile_idcard")).Clear();
            Browsers.Driver2.FindElement(By.Id("profile_idcard")).SendKeys(idCardNumber);
        }

        public void EnterMobileNPhoneNumber(string mobilePhoneNumber)
        {
            Browsers.Driver2.FindElement(By.Id("profile_mobile")).Clear();
            Browsers.Driver2.FindElement(By.Id("profile_mobile")).SendKeys(mobilePhoneNumber);
        }

        public void EnterTitle(string title)
        {
            Browsers.Driver2.FindElement(By.Id("profile_title")).Clear();
            Browsers.Driver2.FindElement(By.Id("profile_title")).SendKeys(title);
        }

        public void EnterPersonalSite(string personalSite)
        {
            Browsers.Driver2.FindElement(By.Id("profile_site")).Clear();
            Browsers.Driver2.FindElement(By.Id("profile_site")).SendKeys(personalSite);
        }

        public void EnterWeibo(string weibo)
        {
            Browsers.Driver2.FindElement(By.Id("weibo")).Clear();
            Browsers.Driver2.FindElement(By.Id("weibo")).SendKeys(weibo);
        }

        public void EnterQQNumber(string qqNumber)
        {
            Browsers.Driver2.FindElement(By.Id("profile_qq")).Clear();
            Browsers.Driver2.FindElement(By.Id("profile_qq")).SendKeys(qqNumber);
        }

        public void AvatarSetting()
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div[1]/div/div[1]/div/ul/li[3]/a")));

            avatarSetting.Click();
        }

        public void UploadNewAvatar()
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div[1]/div/div[2]/div/div[2]/form/div[3]/div[2]/a/div[2]/input")));

            uploadNewAvatar.SendKeys(@"C:\Users\dailex\Desktop\myAvatar.jpg");
            System.Threading.Thread.Sleep(3000);
        }

        public void SaveAvatar()
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("upload-avatar-btn")));

            saveAvatar.Click();
        }

        public bool AvatarIsDisplayed()
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div[1]/div/div[2]/div/div[2]/form/div[1]/div[2]/img")));
            return image.Displayed;
        }

        public bool ProfileSavedSuccessfullyIsDisplayed()
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[1]/div[1]/div/div[2]/div/div[2]/form/div[1]")));
            return Browsers.Driver2.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div[2]/div/div[2]/form/div[1]")).Text == "基础信息保存成功。";
        }

        public bool NameErrorIsDisplayed()
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("profile_truename-error")));
            return Browsers.Driver2.FindElement(By.Id("profile_truename-error")).Text == "最多只能输入 18 个字符";
        }

        public bool IdcardErrorIsDisplayed()
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("profile_idcard-error")));
            return Browsers.Driver2.FindElement(By.Id("profile_idcard-error")).Text == "请正确输入您的身份证号码";
        }

        public bool MobileErrorIsDisplayed()
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("profile_mobile-error")));
            return Browsers.Driver2.FindElement(By.Id("profile_mobile-error")).Text == "请输入正确的手机号";
        }

        public bool TitileErrorIsDisplayed()
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("profile_title-error")));
            return Browsers.Driver2.FindElement(By.Id("profile_title-error")).Text == "最多只能输入 24 个字符";
        }

        public bool SiteErrorIsDisplayed()
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("profile_site-error")));
            return Browsers.Driver2.FindElement(By.Id("profile_site-error")).Text == "地址不正确，须以http://或者https://开头。";
        }

        public bool WeiboErrorIsDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(Browsers.Driver2, new TimeSpan(0, 0, 10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("weibo-error")));
            return Browsers.Driver2.FindElement(By.Id("weibo-error")).Text == "地址不正确，须以http://或者https://开头。";
        }

        public bool QQErrorIsDisplayed()
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("profile_qq-error")));
            return Browsers.Driver2.FindElement(By.Id("profile_qq-error")).Text == "请输入正确的QQ号";
        }
    }
}
