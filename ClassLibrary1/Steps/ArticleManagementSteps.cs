using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace ClassLibrary1.Steps
{
    [Binding]
    public class ArticleManagementSteps
    {
        [Given(@"I have logged in as an administrator")]
        public void GivenIHaveLoggedInAsAnAdministrator()
        {
            if (! Variables.IsLoggedIn)
            {
                Pages.HomePage.Goto();
                Pages.HomePage.Login("admin", "5EstafeyEtre");
            }
        }
        
        [Given(@"I have navigated to article management page")]
        public void GivenIHaveNavigatedToArticleManagementPage()
        {
            if (Pages.AdminPage.IsCurrent() == false)
            {
                Pages.HomePage.GotoAdminPage();
                Pages.AdminPage.GotoArticleManagementPage();
            }
        }
        
        [Given(@"I have set the filters as ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)""")]
        public void GivenIHaveSetTheFiltersAs(string category, string keywords, string property, string status)
        {
            Pages.ArticleManagementPage.GotoSubtabArticleManagement();
            Pages.ArticleManagementPage.SelectCategory(category);
            Pages.ArticleManagementPage.EnterKeywords(keywords);
            Pages.ArticleManagementPage.SelectProperty(property);
            Pages.ArticleManagementPage.SelectStatus(status);
        }
        
        [Given(@"I have navigated to category management page")]
        public void GivenIHaveNavigatedToCategoryManagementPage()
        {
            Pages.HomePage.GotoAdminPage();
            Pages.AdminPage.GotoArticleManagementPage();
            Pages.ArticleManagementPage.GotoSubtabCategoryManagement();
        }

        [Given(@"I have clicked add category button")]
        public void GivenIHaveClickedAddCategoryButton()
        {
            Pages.ArticleManagementPage.ClickAddCategory();
        }

        [Given(@"I have entered the following data as title, code, parent, SEO title, SEO keywords, SEO describtion, publish")]
        public void GivenIHaveEnteredTheFollowingDataAsTitleCodeParentSEOTitleSEOKeywordsSEODescribtionPublish(Table table)
        {
            Pages.ArticleManagementPage.EnterNewCategoryInfo(table.Rows[0][0], table.Rows[1][0], table.Rows[2][0], table.Rows[3][0], table.Rows[4][0], table.Rows[5][0], table.Rows[6][0]);
        }

        [Given(@"I have added a new category")]
        public void GivenIHaveAddedANewCategory()
        {
            Pages.ArticleManagementPage.ClickAddCategory();
            Pages.ArticleManagementPage.EnterNewCategoryInfo("WD" + DateTime.Now.ToString("mmss"), "Code"+DateTime.Now.ToString("yyMMddhhmmss"), "", "", "", "", "yes");
            Pages.ArticleManagementPage.SaveNewCategory();
        }

        [When(@"I press search")]
        public void WhenIPressSearch()
        {
            Pages.ArticleManagementPage.ClickSearch();
        }

        [When(@"I change the status of an article")]
        public void WhenIChangeTheStatusOfAnArticle()
        {
            Pages.ArticleManagementPage.ChangeStatusOfAnArticle();
        }

        [When(@"I click save button")]
        public void WhenIClickSaveButton()
        {
            Pages.ArticleManagementPage.SaveNewCategory();
        }


        [When(@"I change the name of the new category")]
        public void WhenIChangeTheNameOfTheNewCategory()
        {
            Pages.ArticleManagementPage.EditAExistingCategory(Variables.CategoryInfo[0], Variables.CategoryInfo[1], "Edited_WD" + DateTime.Now.ToString("mmss"));
        }

        [Then(@"Search result should match the expected result for ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)""")]
        public void ThenSearchResultShouldMatchTheExpectedResultFor(string category, string keywords, string property, string status)
        {
            Assert.IsTrue(Pages.ArticleManagementPage.ExpectedSearchResultIsDisplayed(category, keywords, property, status));
        }

        [Then(@"The status of the article should change accordingly")]
        public void ThenTheStatusOfTheArticleShouldChangeAccordingly()
        {
            Assert.IsTrue(Pages.ArticleManagementPage.ArticleStatusIsEdited());
        }

        [Then(@"The added category should show in the category list")]
        public void ThenTheAddedCategoryShouldShowInTheCategoryList()
        {
            Assert.IsTrue(Pages.ArticleManagementPage.NewCategoryIsDisplayed());
        }

        [Then(@"I shoude see the name changed accordingly")]
        public void ThenIShoudeSeeTheNameChangedAccordingly()
        {
            Assert.IsTrue(Pages.ArticleManagementPage.EditedCategoryIsDisplayed());
        }
    }
}
