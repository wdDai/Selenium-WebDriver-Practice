using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace ClassLibrary1.Steps
{
    [Binding]
    public class SignupSteps
    {
        [Given(@"I am in signup page")]
        public void IAmInSignupPage()
        {
            Pages.HomePage.Goto();
            Pages.HomePage.ClickLogin();
            Pages.LoginPage.ClickSignup();
        }

        [Given(@"I have entered the following data as my emailaddress, username, password, captha code:")]
        public void GivenIHaveEnteredTheFollowingDataAsMyEmailaddressUsernamePasswordCapthaCode(Table table)
        {
            Pages.SignupPage.EnterEmail(table.Rows[0][0]);
            Pages.SignupPage.EnterUsername(table.Rows[1][0]);
            Pages.SignupPage.EnterPassword(table.Rows[2][0]);
            Pages.SignupPage.EnterCaptchaCode(table.Rows[3][0]);
        }

        [When(@"I click register")]
        public void WhenIClickRegister()
        {
            Pages.SignupPage.ClickRegister();
        }

        [Then(@"I should see alerts for the above entering")]
        public void IShouldSeeAlertsForTheAboveEntering()
        {
            Assert.IsTrue(Pages.SignupPage.ProperEmailErrorIsDisplayed());
            Assert.IsTrue(Pages.SignupPage.ProperUsernameErrorIsDisplayed());
            Assert.IsTrue(Pages.SignupPage.ProperPasswordErrorIsDisplayed());
            Assert.IsTrue(Pages.SignupPage.ProperCaptchaErrorIsDisplayed());
        }
    }
}
