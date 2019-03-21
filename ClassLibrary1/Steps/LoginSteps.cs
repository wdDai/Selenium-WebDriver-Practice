using System;
using TechTalk.SpecFlow;

namespace ClassLibrary1
{
    [Binding]
    public class LoginSteps
    {
        [When(@"I enter user name and password without rememberme selected")]
        public void WhenIEnterUserNameAndPasswordWithoutRemembermeSelected()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I enter user name and password with rememberme selected")]
        public void WhenIEnterUserNameAndPasswordWithRemembermeSelected()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
