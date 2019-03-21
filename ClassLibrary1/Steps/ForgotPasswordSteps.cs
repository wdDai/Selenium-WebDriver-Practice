using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace ClassLibrary1
{
    [Binding]
    public class ForgotPasswordSteps
    {
        [Given(@"I'm in reset password page")]
        public void GivenIMInResetPasswordPage()
        {
            Pages.HomePage.Goto();
            Pages.HomePage.ClickLogin();
            Pages.LoginPage.ClickResetPassword();
        }
        
        [Given(@"I have entered an unregistered email address")]
        public void GivenIHaveEnteredAnUnregisteredEmailAddress()
        {
            Pages.ResetPasswordPage.EnterEmailAddress("111@111.com");
        }
        
        [Given(@"I have entered an invalid email address")]
        public void GivenIHaveEnteredAnInvalidEmailAddress()
        {
            Pages.ResetPasswordPage.EnterEmailAddress("asdf");
        }
        
        [When(@"I press reset password button")]
        public void WhenIPressResetPasswordButton()
        {
            Pages.ResetPasswordPage.ClickResetPassword();
        }

        [Then(@"I should see an unregistered email address message")]
        public void ThenIShouldSeeAnUnregisteredEmailAddressMessage()
        {
            Assert.IsTrue(Pages.ResetPasswordPage.UnregisteredAlertIsDisplayed());
        }

        [Then(@"I should see an invalid email address message")]
        public void ThenIShouldSeeAnInvalidEmailAddressMessage()
        {
            Assert.IsTrue(Pages.ResetPasswordPage.InvalidAlertIsDisplayed());
        }

    }
}
