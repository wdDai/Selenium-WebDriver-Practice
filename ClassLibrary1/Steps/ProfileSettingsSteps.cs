using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace ClassLibrary1
{
    [Binding]
    public class ProfileSettingsSteps
    {
        [Given(@"I have logged in")]
        public void GivenIHaveLoggedIn()
        {
            Pages.HomePage.Goto();
            Pages.HomePage.Login("test002","Test1234");          
        }
        
        [Given(@"I am in basic setting page")]
        public void GivenIAmInBasicSettingPage()
        {
            Pages.HomePage.GotoSettingsPage();
        }
        
        [Given(@"I have entered new valid information")]
        public void GivenIHaveEnteredNewValidInformation()
        {
            Pages.SettingsPage.EnterName("test0021");
        }
        
        [Given(@"I have entered invalid information")]
        public void GivenIHaveEnteredInvalidInformation()
        {
            Pages.SettingsPage.EnterName("test002155555555555555555");
            Pages.SettingsPage.EnterIdcardNumber("110105199901017437555");
            Pages.SettingsPage.EnterMobileNPhoneNumber("13800138000555");
            Pages.SettingsPage.EnterTitle("Lead55555555555555555555cccccccccccccccccc");
            Pages.SettingsPage.EnterPersonalSite("chttp://www.google.co.nz");
            Pages.SettingsPage.EnterWeibo("cchttp://test.co.nz");
            Pages.SettingsPage.EnterQQNumber("123456cccccccccccccccccccc");
        }
        
        [When(@"I press save button")]
        public void WhenIPressSaveButton()
        {
            Pages.SettingsPage.SaveProfile();
        }

        [Then(@"I should see the new information is saved")]
        public void ThenIShouldSeeTheNewInformationIsSaved()
        {
            Assert.IsTrue(Pages.SettingsPage.ProfileSavedSuccessfullyIsDisplayed());
        }
        
        [Then(@"I should see acording error massages")]
        public void ThenIShouldSeeAcordingErrorMassages()
        {
            Assert.IsTrue(Pages.SettingsPage.NameErrorIsDisplayed());
            Assert.IsTrue(Pages.SettingsPage.IdcardErrorIsDisplayed());
            Assert.IsTrue(Pages.SettingsPage.MobileErrorIsDisplayed());
            Assert.IsTrue(Pages.SettingsPage.TitileErrorIsDisplayed());
            Assert.IsTrue(Pages.SettingsPage.SiteErrorIsDisplayed());
            Assert.IsTrue(Pages.SettingsPage.WeiboErrorIsDisplayed());
            Assert.IsTrue(Pages.SettingsPage.QQErrorIsDisplayed());
        }
    }
}
