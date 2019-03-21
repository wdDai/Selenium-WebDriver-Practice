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
using System.Globalization;

namespace ClassLibrary1
{
    public class AdminPage
    {
        public bool IsCurrent()
        {
            try
            {
                IWebElement articaleManageTabDisplayed = Browsers.Driver2.FindElement(By.XPath("/html/body/div[2]/div/div[1]/div[1]/a[1]"));
                return true;
            }
            catch
            {
                return false;
            }
        }

        [FindsBy(How = How.CssSelector, Using = "ul.nav:nth-child(1) > li:nth-child(4) > a:nth-child(1)")]
        private IWebElement orderManageTab;

        [FindsBy(How = How.CssSelector, Using = "a.list-group-item:nth-child(1)")]
        private IWebElement courseOrderManage;

        [FindsBy(How = How.CssSelector, Using = "a.list-group-item:nth-child(2)")]
        private IWebElement classOrderManage;

        //[FindsBy(How = How.Id, Using = "startDate")]
        //private IWebElement startDateInput;

        //[FindsBy(How = How.CssSelector, Using = "div.mbm:nth-child(2) > div:nth-child(1) > select:nth-child(2)")]
        //private SelectElement statusInput;

        //[FindsBy(How = How.CssSelector, Using = "select.form-control:nth-child(3)")]
        //private SelectElement pamentMethodInput;

        //[FindsBy(How = How.CssSelector, Using = "div.form-group:nth-child(3) > select:nth-child(2)")]
        //private SelectElement keywordTypeInput;

        //[FindsBy(How = How.CssSelector, Using = "button.btn")]
        //private IWebElement searchButton;

        public void GotoArticleManagementPage()
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("ul.nav:nth-child(1) > li:nth-child(3) > a:nth-child(1)")));
            IWebElement managementTab = Browsers.Driver2.FindElement(By.CssSelector("ul.nav:nth-child(1) > li:nth-child(3) > a:nth-child(1)"));
            managementTab.Click();

            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a.active")));
            IWebElement articleManagementTab = Browsers.Driver2.FindElement(By.CssSelector("a.active"));
            articleManagementTab.Click();
        }

        public void OrderManageTab()
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("ul.nav:nth-child(1) > li:nth-child(4) > a:nth-child(1)")));

            orderManageTab.Click();
        }

        public void CoursOrderManage()
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a.list-group-item:nth-child(1)")));

            courseOrderManage.Click();
        }

        public void ClassOrderManage()
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("a.list-group-item:nth-child(2)")));

            classOrderManage.Click();
        }

        public void EnterStartDate(string startDate)
        {
            if (startDate != "")
            {
                Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("startDate")));

                IWebElement startDateInput = Browsers.Driver2.FindElement(By.Id("startDate"));
                startDateInput.SendKeys(startDate);
            }
        }

        public void SelectStatus(string status)
        {   
            if (status != "")
            {
                Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.mbm:nth-child(2) > div:nth-child(1) > select:nth-child(2)")));

                SelectElement statusInput = new SelectElement(Browsers.Driver2.FindElement(By.CssSelector("div.mbm:nth-child(2) > div:nth-child(1) > select:nth-child(2)")));
                statusInput.SelectByText(status);
            }   
        }

        public void SelectPaymentMethod(string paymentMethod)
        {
            if (paymentMethod != "")
            {
                Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("select.form-control:nth-child(3)")));

                SelectElement paymentMethodInput = new SelectElement(Browsers.Driver2.FindElement(By.CssSelector("select.form-control:nth-child(3)")));
                paymentMethodInput.SelectByText(paymentMethod);
            }
        }

        public void SelectKeywordType(string keywordType)
        {
            if (keywordType != "")
            {
                Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.form-group:nth-child(3) > select:nth-child(2)")));

                SelectElement keywordTypeInput = new SelectElement(Browsers.Driver2.FindElement(By.CssSelector("div.form-group:nth-child(3) > select:nth-child(2)")));
                keywordTypeInput.SelectByText(keywordType);
            }
        }

        public void PressSearchButton()
        {
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("button.btn")));

            IWebElement searchButton = Browsers.Driver2.FindElement(By.CssSelector("button.btn"));
            searchButton.Click();
        }

        public bool SomeResultsIsDisplayed()
        {
            System.Threading.Thread.Sleep(2000);
            IWebElement tableOfSearchResults = Browsers.Driver2.FindElement(By.XPath("/html/body/div[2]/div/div[2]/table/tbody"));
            return tableOfSearchResults.Displayed;
        }

        public bool ExpectedSearchResultsAreDisplayed(string startDate, string status, string paymentMethod, string keywordType)
        {
            //explict wait for search results
            Browsers.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div/div[2]/table/tbody")));

            try
            {
                Browsers.Driver2.FindElement(By.ClassName("empty"));
                return true;
            }
            catch
            {
                //get the list of the search results by using XPath
                IList<IWebElement> searchResults = Browsers.Driver2.FindElements(By.XPath("/html/body/div[2]/div/div[2]/table/tbody/tr"));

                //vaerify the results meet the search filter criteria
                int sizeOfSearchResults = searchResults.Count;

                for (int i = 0; i < sizeOfSearchResults; i++)
                {
                    //verify date
                    if (startDate != "")
                    {
                        CultureInfo provider = CultureInfo.InvariantCulture;
                        string dateFormat = "yyyy-M-dd HH:mm:ss";
                        string dateFormat2 = "yyyy-M-dd HH:mm";
                        string actualDate = searchResults.ElementAt(i).FindElements(By.ClassName("text-sm")).ElementAt(1).Text;
                        DateTime actualDate_inTimeFormat = DateTime.ParseExact(actualDate, dateFormat, provider);
                        DateTime startDate_inTimeFormat = DateTime.ParseExact(startDate, dateFormat2, provider);

                        if (actualDate_inTimeFormat.CompareTo(startDate_inTimeFormat) < 0)
                        {
                            return false;
                        }
                    }
                    else


                    //varify status
                    if (status != "")
                    {
                        string actualStatus = searchResults.ElementAt(i).FindElements(By.ClassName("label-success")).ElementAt(0).Text;

                        if (actualStatus != status)
                        {
                            return false;
                        }
                    }
                    else


                    //varify payment method
                    if (paymentMethod != "")
                    {
                        string actualPaymentMethod = searchResults.ElementAt(i).FindElement(By.XPath("./td[6]")).Text;

                        if (actualPaymentMethod != paymentMethod)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }



    }
}
