using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace ClassLibrary1.Steps
{
    [Binding]
    public class NewAvatarSteps
    {
        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            Pages.HomePage.Goto();
            Pages.HomePage.Login("test002","Test1234");
        }
        
        [Given(@"I chosed 个人设置")]
        public void GivenIChosed个人设置()
        {
            Pages.HomePage.GotoSettingsPage();
        }
        
        [Given(@"I pressed 头像设置")]
        public void GivenIPressed个人头像()
        {
            Pages.SettingsPage.AvatarSetting();
        }
        
        [When(@"I upload a new avatar")]
        public void GivenIPressed上传新头像()
        {
            Pages.SettingsPage.UploadNewAvatar();
        }     
        
        [Then(@"I should be able to save my new avatar.")]
        public void ThenIShouldBeAbleToSaveIt()
        {
            Pages.SettingsPage.SaveAvatar();
            Assert.IsTrue(Pages.SettingsPage.AvatarIsDisplayed());
        }
    }
}
