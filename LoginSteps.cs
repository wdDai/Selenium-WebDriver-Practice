using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace ClassLibrary1
{
    [Binding]
    public class LoginSteps
    {
        [Given(@"I'm in the homepage")]
        public void GivenIMInTheHomepage()
        {
            Pages.HomePage.Goto();
        }
        
        [Given(@"I can select login")]
        public void GivenICanSelectLogin()
        {
            Pages.HomePage.ClickLogin();
        }

        [When(@"I enter user name and password without rememberme selected")]
        public void WhenIEnterUserNameAndPasswordWithoutRemembermeSelected()
        {
            Pages.LoginPage.EnterUsername("test002");
            Pages.LoginPage.EnterPassword("Test1234");
            Pages.LoginPage.RememberMeUnselected();
        }

        [When(@"I enter user name and password with rememberme selected")]
        public void WhenIEnterUserNameAndPasswordWithRemembermeSelected()
        {
            Pages.LoginPage.EnterUsername("test002");
            Pages.LoginPage.EnterPassword("Test1234");
            Pages.LoginPage.RememberMeSelected();
        }

        
        [When(@"I enter invalid user name and password")]
        public void WhenIEnterInvalidUserNameAndPassword()
        {
            Pages.LoginPage.EnterUsername("abcd");
            Pages.LoginPage.EnterPassword("zxcv");
        }
        
        [Then(@"I should be able to login and see avatar")]
        public void ThenIShouldBeAbleToLoginAndSeeAvatar()
        {
            Pages.LoginPage.ClickLogin();
            Assert.IsTrue(Pages.HomePage.AvatarIsVisible());
            Pages.HomePage.Logout();
        }
        
        [Then(@"I should not be able to login and see avatar")]
        public void ThenIShouldNotBeAbleToLoginAndSeeAvatar()
        {
            Pages.LoginPage.ClickLogin();
            Assert.IsTrue(Pages.LoginPage.LoginIsFailed());
            Pages.HomePage.Logout();
        }
    }
}
