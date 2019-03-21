using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;

namespace ClassLibrary1
{
    public class ArticleManagementPage
    {
        public void GotoSubtabArticleManagement()
        {
            IWebElement subtabArticleManagement = Browsers.Driver2.FindElement(By.XPath("/html/body/div[2]/div/div[2]/ul/li[1]"));
            subtabArticleManagement.Click();
        }

        public void GotoSubtabCategoryManagement()
        {
            IWebElement subtabCategoryManagement = Browsers.Driver2.FindElement(By.XPath("/html/body/div[2]/div/div[2]/ul/li[2]"));
            subtabCategoryManagement.Click();
        }

        public void ClickSearch()
        {
            IWebElement searchButton = Browsers.Driver2.FindElement(By.CssSelector("button.btn:nth-child(5)"));
            searchButton.Click();
        }

        public void ClickAddCategory()
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("添加栏目")));
            IWebElement addCategoryBtn = Browsers.Driver2.FindElement(By.LinkText("添加栏目"));
            addCategoryBtn.Click();
        }

        public void EnterNewCategoryInfo(string title, string code, string parent, string seoTitle, string seoKeywords, string seoDesc, string publish)
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("category-name-field")));
            IWebElement titleInput = Browsers.Driver2.FindElement(By.Id("category-name-field"));
            IWebElement codeInput = Browsers.Driver2.FindElement(By.Id("category-code-field"));
            IWebElement selectParentEntry = Browsers.Driver2.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/form/div[3]/div"));
            IWebElement seoTitleInput = Browsers.Driver2.FindElement(By.Id("category-seoTitle-field"));
            IWebElement seoKeywordsInput = Browsers.Driver2.FindElement(By.Id("category-seoKeyword-field"));
            IWebElement seoDescInput = Browsers.Driver2.FindElement(By.Id("category-seoDesc-field"));
            IList<IWebElement> publishInput = Browsers.Driver2.FindElements(By.XPath("/html/body/div[3]/div/div/div[2]/form/div[8]/div/label"));

            if (title != "")
            {
                titleInput.Clear();
                titleInput.SendKeys(title);
            }

            if(code != "")
            {   
                codeInput.Clear();
                codeInput.SendKeys(code);
            }
            
            if (parent != "")
            {
                selectParentEntry.Click();
                Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("select2-search")));
                IWebElement parentInputContainer = Browsers.Driver2.FindElement(By.ClassName("select2-search"));
                parentInputContainer.Click();
                Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("select2-input")));
                IWebElement parentInput = Browsers.Driver2.FindElement(By.ClassName("select2-input"));
                parentInput.SendKeys(parent + Keys.Enter);
            }
            seoTitleInput.SendKeys(seoTitle);
            seoKeywordsInput.SendKeys(seoKeywords);
            seoDescInput.SendKeys(seoDesc);
            //publish
            if (publish == "yes")
            {
                publishInput.ElementAt(1).Click();
            }
            else
            if (publish == "no")
            {
                publishInput.ElementAt(0).Click();
            }
            else{ }

            Variables.CategoryInfo = new string[] { title, code };
        }

        public void SaveNewCategory()
        {
            IWebElement saveNewCategoryBtn = Browsers.Driver2.FindElement(By.Id("category-save-btn"));
            saveNewCategoryBtn.Click();
            System.Threading.Thread.Sleep(3000);
        }

        //public IWebElement SpecificCategory(string title, string code, string parent)
        //{
        //    Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("category-table-body")));

        //    IList<IWebElement> allCategories = Browsers.Driver2.FindElements(By.XPath("/html/body/div[2]/div/div[2]/ul[2]/li[2]/ul/li"));
        //    int size = allCategories.Count;

        //    //when parent is empty, check the first level of the list
        //    if (parent == "")
        //    {
        //        for (int i = 0; i < size; i++)
        //        {
        //            string actualTitle = allCategories.ElementAt(i).FindElement(By.XPath("./div/div[1]")).Text;
        //            if (actualTitle == title)  //name has been found
        //            {
        //                //check if according code matches
        //                String actrualCode = allCategories.ElementAt(i).FindElement(By.XPath("./div[1]/div[3]")).Text;
        //                if (actrualCode == code)
        //                {
        //                    return allCategories.ElementAt(i);
        //                }
        //                else
        //                {
        //                    return null;
        //                }
        //            }
        //        }
        //        return null;
        //    }
        //    else
        //    //if parent is not empty, find parent in first level, then find new catgr in sublevel
        //    {
        //        for (int i = 0; i < size; i++)
        //        {
        //            string actualTitle = allCategories.ElementAt(i).FindElement(By.XPath("./div/div[1]")).Text;
        //            if (actualTitle == parent)  //parent has been found
        //            {
        //                IList<IWebElement> allSubCatgrs = allCategories.ElementAt(i).FindElements(By.XPath("./ul[1]/li"));
        //                int subSize = allSubCatgrs.Count;

        //                //check all subcategories under parent
        //                for (int j = 0; j < subSize; j++)
        //                {
        //                    string actualSubTitle = allSubCatgrs.ElementAt(j).FindElement(By.XPath("./div[1]/div[1]")).Text;
        //                    if (actualSubTitle == title) //subcategory has been found
        //                    {
        //                        //check if accoding code matches
        //                        string actualCode = allSubCatgrs.ElementAt(j).FindElement(By.XPath("./div[1]/div[3]")).Text;
        //                        if (actualCode == code)
        //                        {
        //                            return allSubCatgrs.ElementAt(j);
        //                        }
        //                        else
        //                        {
        //                            return null;
        //                        }
        //                    }
        //                }
        //                return null;
        //            }
        //        }
        //        return null;
        //    }
        //}

        private IWebElement SpecificCategory(string title, string code)
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("category-table-body")));

            IList<IWebElement> allCategories = Browsers.Driver2.FindElements(By.XPath("/html/body/div[2]/div/div[2]/ul[2]/li[2]/ul/li"));
            int size = allCategories.Count;

            for (int i = 0; i < size; i++)
            {
                string actualTitle = allCategories.ElementAt(i).FindElement(By.XPath("./div/div[1]")).Text;
                if (actualTitle == title)  //title has been found in first level
                {
                    //check if according code matches
                    String actrualCode = allCategories.ElementAt(i).FindElement(By.XPath("./div[1]/div[3]")).Text;
                    if (actrualCode == code)
                    {
                        return allCategories.ElementAt(i); //target found (in first level)
                    }
                }
                else //check sublevel
                {
                    try //there could be no sublevel
                    {
                        Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div/div[2]/ul[2]/li[2]/ul/li["+(i+1).ToString()+"]/div")));
                        IList<IWebElement> allSubCatgrs = allCategories.ElementAt(i).FindElements(By.XPath("./ul[1]/li"));
                        int subSize = allSubCatgrs.Count;

                        //check all subcategories under parent
                        for (int j = 0; j < subSize; j++)
                        {
                            string actualSubTitle = allSubCatgrs.ElementAt(j).FindElement(By.XPath("./div[1]/div[1]")).Text;
                            if (actualSubTitle == title) //subcategory has been found
                            {
                                //check if accoding code matches
                                string actualCode = allSubCatgrs.ElementAt(j).FindElement(By.XPath("./div[1]/div[3]")).Text;
                                if (actualCode == code)
                                {
                                    return allSubCatgrs.ElementAt(j); //target found (in sublevel)
                                }
                            }
                        }
                    }
                    catch { }
                }
            }
            return null;
        }

        public void EditAExistingCategory(string title, string code, string newtile)
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div/div[2]/ul[2]/li[2]/ul/li[1]/div/div[4]/a[1]")));
            CtgrSubPageEdtBn(SpecificCategory(title, code)).Click();
            EnterNewCategoryInfo(newtile, code, "", "", "", "", "");
            Variables.CategoryInfo[0] = newtile;
            SaveNewCategory();
        }

        private IWebElement CtgrSubPageEdtBn(IWebElement catgr)
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div/div[2]/ul[2]/li[2]/ul/li[1]/div/div[4]/a[1]"))); //wait util the edit buttong of the first article is displayed
            return catgr.FindElement(By.XPath("./div[1]/div[4]/a[1]"));
        }

        public bool EditedCategoryIsDisplayed()
        {
            return SpecificCategory(Variables.CategoryInfo[0], Variables.CategoryInfo[1]).Displayed;
        }

        private string CatgrTitle(IWebElement catgr)
        {
            return catgr.FindElement(By.XPath("./div[1]/div[1]/i")).Text;
        }

        private string CategrCode(IWebElement catgr)
        {
            return catgr.FindElement(By.XPath("./div[1]/div[3]")).Text;
        }

        public bool NewCategoryIsDisplayed()
        {
            return SpecificCategory(Variables.CategoryInfo[0], Variables.CategoryInfo[1]).Displayed;
        }

        //************obsolete method*******************
        //public bool AddedCategoryIsDisplayed(string title, string code, string parent)
        //{
        //    WebDriverWait wait = new WebDriverWait(Browsers.Driver2, new TimeSpan(0, 0, 10));
        //    wait.Until(ExpectedConditions.ElementIsVisible(By.Id("category-table-body")));

        //    IList<IWebElement> allCategories = Browsers.Driver2.FindElements(By.XPath("/html/body/div[2]/div/div[2]/ul[2]/li[2]/ul/li"));
        //    int size = allCategories.Count;

        //    //when parent is empty, check the first level list
        //    if (parent == "")
        //    {
        //        for (int i = 0; i < size; i++)
        //        {
        //            string actualTitle = allCategories.ElementAt(i).FindElement(By.XPath("./div/div[1]")).Text;
        //            if (actualTitle == title)  //name has been found
        //            {
        //                //check if according code matches
        //                String actrualCode = allCategories.ElementAt(i).FindElement(By.XPath("./div[1]/div[3]")).Text;
        //                if (actrualCode == code)
        //                {
        //                    return true;
        //                }
        //                else
        //                {
        //                    return false;
        //                }
        //            }
        //        }
        //        return false;
        //    }
        //    else

        //    //when there is a parent, find parent in first level, then find new catgr in sublevel
        //    {
        //        for (int i = 0; i < size; i++)
        //        {
        //            string actualTitle = allCategories.ElementAt(i).FindElement(By.XPath("./div/div[1]")).Text;
        //            if (actualTitle == parent)  //parent has been found
        //            {
        //                IList<IWebElement> allSubCatgrs = allCategories.ElementAt(i).FindElements(By.XPath("./ul"));
        //                int subSize = allSubCatgrs.Count;

        //                //check all subcategories under parent
        //                for (int j = 0; j < subSize; j++)
        //                {
        //                    string actualSubTitle = allSubCatgrs.ElementAt(j).FindElement(By.XPath("./li[1]/div[1]")).Text;
        //                    if (actualSubTitle == title) //new category has been found
        //                    {
        //                        //check if accoding code matches
        //                        string actualCode = allSubCatgrs.ElementAt(j).FindElement(By.XPath("./li[1]/div[1]/div[3]")).Text;
        //                        if (actualCode == code)
        //                        {
        //                            return true;
        //                        }
        //                        else
        //                        {
        //                            return false;
        //                        }
        //                    }
        //                }
        //                return false;
        //            }
        //        }
        //        return false;
        //    }
        //}

        public void SelectCategory(string category)
        {
            if (category != "")
            {
                IWebElement categoryDropMenu = Browsers.Driver2.FindElement(By.XPath("/html/body/div[2]/div/div[2]/form/div[1]"));
                categoryDropMenu.Click();

                IWebElement categoryInput = Browsers.Driver2.FindElement(By.XPath("/html/body/div[7]/div/input"));
                categoryInput.SendKeys(category + Keys.Enter);


                ////get a list of all options
                //IList<IWebElement> allCategoryOptions = Browsers.Driver2.FindElements(By.XPath("/html/body/div[7]/ul/li"));
                ////check single if option contains text that matches input category
                //foreach (IWebElement option in allCategoryOptions)
                //{
                //    string text = option.FindElement(By.XPath("./div/div/span")).GetAttribute("textContent");
                //    if (text == category)
                //    {
                //        option.Click();
                //        break;
                //    }
                //}


            }
        }

        public void EnterKeywords(string keywords)
        {
            if (keywords != "")
            {
                IWebElement keywordsInput = Browsers.Driver2.FindElement(By.CssSelector("html body div.container div.row div.col-md-10 form.well.well-sm.form-inline div.form-group input.form-control"));
                keywordsInput.SendKeys(keywords);
            }

        }

        public void SelectProperty(string property)
        {
            if (property != "")
            {
                SelectElement propertySelect = new SelectElement(Browsers.Driver2.FindElement(By.CssSelector("div.form-group:nth-child(3) > select:nth-child(1)")));
                propertySelect.SelectByText(property);
            }
        }

        public void SelectStatus(string status)
        {
            if (status != "")
            {
                SelectElement propertySelect = new SelectElement(Browsers.Driver2.FindElement(By.CssSelector("div.form-group:nth-child(4) > select:nth-child(1)")));
                propertySelect.SelectByText(status);
            }
        }

        public bool ExpectedSearchResultIsDisplayed(string category, string keywords, string property, string status)
        {
            //explict wait for search results
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div/div[2]/div[2]/table/tbody")));

            try
            {
                //get the list of the search results by using XPath
                IList<IWebElement> searchResults = Browsers.Driver2.FindElements(By.XPath("/html/body/div[2]/div/div[2]/div[2]/table/tbody/tr"));

                //vaerify the results meet the search filter criteria
                int sizeOfSearchResults = searchResults.Count;

                for (int i = 0; i < sizeOfSearchResults; i++)
                {
                    //verify category
                    if (category != "")
                    {
                        string actualCategory = searchResults.ElementAt(i).FindElement(By.XPath("./td[3]")).Text;
                        if (actualCategory != category)
                        {
                            return false;
                        }
                    }
                    else


                    //varify keywords
                    if (keywords != "")
                    {
                        string actualText = searchResults.ElementAt(i).FindElement(By.XPath("./td[2]")).Text;

                        if (!actualText.Contains(keywords))
                        {
                            return false;
                        }
                    }
                    else


                    //varify property
                    if (property != "")
                    {
                        int n;
                        if (property == "头条")
                        {
                            n = 1;
                        }
                        else
                            if
                             (property == "推荐")
                        {
                            n = 2;
                        }
                        else
                            n = 3;

                        //find out the status of the entered property (it has to be either hilighed or not)
                        string h = searchResults.ElementAt(i).FindElement(By.XPath("./td[5]/a[" + n + "]/span")).GetAttribute("class");

                        if (h != "label label-success")
                        {
                            return false;
                        }
                    }

                    //verify status
                    if (status != "")
                    {
                        string actualStatus = searchResults.ElementAt(i).FindElement(By.XPath("./td[6]/span")).Text;

                        if (actualStatus != status)
                        {
                            return false;
                        }
                    }

                }
                return true;
            }
            catch
            {
                Browsers.Driver2.FindElement(By.ClassName("empty"));
                return true;
            }

        }

        public void ChangeStatusOfAnArticle()
        {
            //if the list is empty, click ArticleManegement to refresh
            try
            {
                if (Browsers.Driver2.FindElement(By.ClassName("empty")).Displayed)
                {
                    Pages.AdminPage.GotoArticleManagementPage();
                }
            }
            catch
            {
                IWebElement changeStatusButton = Browsers.Driver2.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/table/tbody/tr[1]/td[7]/div/a[2]"));
                changeStatusButton.Click();
                IWebElement switchStatus = Browsers.Driver2.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/table/tbody/tr[1]/td[7]/div/ul/li[1]/a"));
                //get the status of the first article that it should be changed to, set to statusOfTheFirstArticle for later comparision in ArticleStatusIsChanged()
                if (switchStatus.Text == "发布")
                {
                    Variables.ExpectedStatus = "已发布";
                }
                else
                    Variables.ExpectedStatus = "未发布";
                switchStatus.Click();
                System.Threading.Thread.Sleep(3000);
            }
        }

        public bool ArticleStatusIsEdited()
        {
            try
            {
                IWebElement articleStatus = Browsers.Driver2.FindElement(By.XPath("/html/body/div[2]/div/div[2]/div[2]/table/tbody/tr[1]/td[6]/span"));
                Browsers.Wait.Until(ExpectedConditions.TextToBePresentInElement(articleStatus, Variables.ExpectedStatus));
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
