using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace ClassLibrary1
{
    [Binding]
    public class LogoutSteps
    {
        [Given(@"I'm in homepage and logged in")]
        public void GivenIMInHomepageAndLoggedIn()
        {
            Pages.HomePage.Goto();
            Pages.HomePage.Login("test002","Test1234");
        }
        
        [When(@"I choose logout")]
        public void WhenIChooseLogout()
        {
            Pages.HomePage.Logout();
        }
        
        [Then(@"I should be logged out")]
        public void ThenIShouldBeLoggedOut()
        {
            Assert.IsTrue(Pages.LoginPage.LogoutIsSuccessful());
        }
    }
}
