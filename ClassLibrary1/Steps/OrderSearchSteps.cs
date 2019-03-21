using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace ClassLibrary1
{
    [Binding]
    public class OrderSearchSteps
    {
        [Given(@"I am logged in as administrator")]
        public void GivenIAmLoggedInAsAdministrator()
        {
            Pages.HomePage.Goto();
            Pages.HomePage.Login("admin", "5EstafeyEtre");
        }

        [Given(@"I am in admin page")]
        public void GivenIAmInAdminPage()
        {
            Pages.HomePage.GotoAdminPage();
        }

        [Given(@"I have clicked orders manage then course order manage")]
        public void GivenIHaveClickedOrdersManageThenCourseOrderManage()
        {
            Pages.AdminPage.OrderManageTab();
            Pages.AdminPage.CoursOrderManage();
        }

        [Given(@"I have clicked orders manage then class order manage")]
        public void GivenIHaveClickedOrdersManageThenClassOrderManage()
        {
            Pages.AdminPage.OrderManageTab();
            Pages.AdminPage.ClassOrderManage();
        }

        [Given(@"I have chosen start date ""(.*)""")]
        public void GivenIHaveChosenStartDate(string start_date)
        {
            Pages.AdminPage.EnterStartDate(start_date);
        }
        
        [Given(@"I have chosen status ""(.*)""")]
        public void GivenIHaveChosenStatus(string status)
        {
            Pages.AdminPage.SelectStatus(status);
        }
        
        [Given(@"I have chosen payment method ""(.*)""")]
        public void GivenIHaveChosenPaymentMethod(string payment_method)
        {
            Pages.AdminPage.SelectPaymentMethod(payment_method);
        }
        
        [Given(@"I have chosen keyword type ""(.*)""")]
        public void GivenIHaveChosenKeywordType(string keyword_type)
        {
            Pages.AdminPage.SelectKeywordType(keyword_type);
        }

        [When(@"I press search button")]
        public void WhenIPressSearchButton()
        {
            Pages.AdminPage.PressSearchButton();
        }

        [Then(@"I should see some results")]
        public void ThenIShouldSeeSomeResults()
        {
            Assert.IsTrue(Pages.AdminPage.SomeResultsIsDisplayed());
        }

        [Then(@"I should see expected result according to ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)""")]
        public void ThenIShouldSeeExpectedResultAccordingTo(string start_date, string status, string payment_method, string keyword_type)
        {
            Assert.IsTrue(Pages.AdminPage.ExpectedSearchResultsAreDisplayed(start_date, status, payment_method, keyword_type));
        }
    }
}
