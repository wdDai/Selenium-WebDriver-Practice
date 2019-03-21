using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;

namespace ClassLibrary1
{
    public class Pages
    {              
        public static HomePage HomePage
        {
            get
            {
                var homePage = new HomePage();
                PageFactory.InitElements(Browsers.Driver, homePage);
                return homePage;
            }
        }

        public static LoginPage LoginPage
        {
            get
            {
                var loginPage = new LoginPage();
                PageFactory.InitElements(Browsers.Driver, loginPage);
                return loginPage;
            }
        }

        public static SettingsPage SettingsPage
        {
            get
            {
                var settingsPage = new SettingsPage();
                PageFactory.InitElements(Browsers.Driver, settingsPage);
                return settingsPage;
            }
        
        }

        public static SignupPage SignupPage
        {
            get
            {
                var signupPage = new SignupPage();
                PageFactory.InitElements(Browsers.Driver, signupPage);
                return signupPage;
            }
        }

        public static ResetPasswordPage ResetPasswordPage
        {
            get
            {
                var resetPassswordPage = new ResetPasswordPage();
                PageFactory.InitElements(Browsers.Driver, resetPassswordPage);
                return resetPassswordPage;
            }
        }

        public static AdminPage AdminPage
        {
            get
            {
                var adminPage = new AdminPage();
                PageFactory.InitElements(Browsers.Driver, adminPage);
                return adminPage;
            }
        }

        public static ArticleManagementPage ArticleManagementPage
        {
            get
            {
                var articleManagementPage = new ArticleManagementPage();
                PageFactory.InitElements(Browsers.Driver, articleManagementPage);
                return articleManagementPage;
            }
        }
    }
}
