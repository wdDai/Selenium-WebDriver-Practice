using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Variables
    {
        public static void CleanUP()
        {
            ExpectedStatus = null;
            IsLoggedIn = false;
            CategoryInfo = null;
        }

        //private static string expectedStatus;
        //public static string ExpectedStatus
        //{
        //    get
        //    {
        //        return expectedStatus;
        //    }
        //    set
        //    {
        //        expectedStatus = value;
        //    }
        //}
        //can be simplified as following--Auto Property:
        public static string ExpectedStatus { set; get; }

        //*****HomePage.Login() method is not able to differentiate Admin and User yet*************
        //public static bool IsLoggedIn_Admin
        //{
        //    set
        //    {
        //        IsLoggedIn_Admin = value; //Whenever log in, it has to be either an Admin or an user
        //    }

        //    get
        //    {
        //        return IsLoggedIn; //Whenever logout, IsLoggedIn will be set to false.
        //    }
        //}

        //public static bool IsLoggedIn_User
        //{
        //    set
        //    {
        //        IsLoggedIn_User = value; //Whenever log in, it has to be either an Admin or an user
        //    }

        //    get
        //    {
        //        return IsLoggedIn;  //Whenever logout, IsLoggedIn will be set to false.
        //    }
        //}

        //public static bool IsLoggedIn
        //{
        //    set
        //    {
        //        IsLoggedIn = value;  //Whenever logout, IsLoggedIn will be set to false.
        //    }
        //    get
        //    {
        //        return (IsLoggedIn_Admin || IsLoggedIn_User); //Whenever log in, it has to be either an Admin or an user. IsLoggedIn property will be read from those two property.
        //    }
        //}
        public static bool IsLoggedIn { set; get; }

        public static string[] CategoryInfo { set; get; }
    }
}
