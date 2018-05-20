using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web;


namespace Nexus.Security.Users
{

    [DataObject(true)]
    public class UserMgr
    {

        public UserMgr()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        #region 站点用户管理

        public static string Get_UserNameByID (string UserID)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            Login_Users myLogin_User = new Login_Users(myDP.Get_UserDetail_ByUserID(UserID, "ALL", "ALL"));

            return myLogin_User.UserName;
        }

        public bool Chk_UserID_Exist(string UserID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            // check all users
            return myDP.chk_UserByID(UserID, "0", "0");
        }

        public bool Chk_UserName_Exist(string UserName)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            // check all users
            return myDP.chk_UserByUserName(UserName, "0", "0");
        }

        public bool Chk_UserName_Exist_ALL(string UserName)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            // check all users
            return myDP.chk_UserByUserName(UserName, "ALL", "ALL");
        }

        public bool Chk_Email_Exist(string Email)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            // check all users
            return myDP.chk_UserByEmail(Email, "0", "0");
        }

        public bool Chk_Email_Exist_ALL(string Email)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            // check all users
            return myDP.chk_UserByEmail(Email, "ALL", "ALL");
        }

        public bool Chk_User_Login(string Email, string UserPass)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            // IsLockOut=0, IsDelete=0
            return myDP.chk_UserLogin(Email, UserPass, "0", "0");
        }

        public string Add_Users(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Add_Users(UpdateData);
        }

        public void Add_UserInGroup(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_UserInGroups(UpdateData);

        }

        #endregion

        #region 站点用户Cookie管理

        public HttpCookie Get_UserCookie(Page myPage)
        {
            return myPage.Request.Cookies["UserInfo"];
        }

        public Login_Users Get_Login_Users(Page myPage)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            HttpCookie cookieUserInfo = myPage.Request.Cookies["UserInfo"];

            if (cookieUserInfo == null)
            {
                return null;
            }

            if (cookieUserInfo["Email"] == null || cookieUserInfo["Password"] == null)
            {
                return null;
            }

            if (myDP.chk_UserLogin(cookieUserInfo["Email"].ToString(), cookieUserInfo["Password"].ToString(), "0", "0"))
            {
                if (Convert.ToBoolean(cookieUserInfo["RememberMe"]))
                {
                    cookieUserInfo.Expires = DateTime.Now.AddDays(30);
                }
                else
                {
                    cookieUserInfo.Expires = DateTime.Now.AddDays(1);
                }

                DataRow myDR = myDP.Get_UserDetail_ByEmail(cookieUserInfo["Email"].ToString(), "0", "0");

                if (myDR != null)
                {
                    return new Login_Users(myDR);
                }
                else
                {
                    Remove_UserCookie(myPage);
                    return null;
                }

            }
            else
            {
                return null;
            }

        }

        // User Login on Site
        public void Add_UserCookie(Page myPage, string Email, string Password, bool RememberMe)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            HttpCookie cookieUserInfo = new HttpCookie("UserInfo");

            // Add Value
            cookieUserInfo["Email"] = Email;
            cookieUserInfo["Password"] = Password;
            cookieUserInfo["RememberMe"] = RememberMe.ToString();

            Login_Users myLogin_User = new Login_Users(myDP.Get_UserDetail_ByEmail(Email, "0", "0"));

            // Add UserInfo to Coookie
            cookieUserInfo["UserID"] = myLogin_User.UserID;
            cookieUserInfo["Username"] = myLogin_User.UserName;

            // Add Misc
            cookieUserInfo.Domain = ConfigurationManager.AppSettings["Cookie_Domain"];
            //cookieUserInfo.Path = "/";

            if (RememberMe)
            {
                cookieUserInfo.Expires = DateTime.Now.AddDays(30);
            }
            else
            {
                cookieUserInfo.Expires = DateTime.Now.AddDays(1);
            }

            myPage.Response.Cookies.Add(cookieUserInfo);

        }

        public void Remove_UserCookie(System.Web.UI.Page myPage)
        {

            HttpCookie cookieUserInfo = new HttpCookie("UserInfo");
            cookieUserInfo.Domain = ConfigurationManager.AppSettings["Cookie_Domain"];
            cookieUserInfo.Expires = DateTime.Now.AddDays(-1d);

            myPage.Response.Cookies.Add(cookieUserInfo);


            foreach (string key in myPage.Request.Cookies)
            {
                //myPage.Request.Cookies[key].Value = "";
                myPage.Request.Cookies[key].Expires = DateTime.Now.AddDays(-1);

            }

        }

        #endregion

        #region 用户组管理

        public static List<UserGroups> sGet_Usergroups()
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_UserGroups(null);

            List<UserGroups> list = new List<UserGroups>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new UserGroups(myDR));
            }

            return list;

        }

        public List<UserInGroups> Get_UserIngroups_ByUserID(string UserID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_UserInGroups_ByUserID(UserID);

            List<UserInGroups> list = new List<UserInGroups>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new UserInGroups(myDR));
            }

            return list;

        }

        #endregion

    }
}
