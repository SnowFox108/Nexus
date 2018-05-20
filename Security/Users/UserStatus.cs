using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Web.UI;
using System.Web;
using Nexus.Core;

namespace Nexus.Security.Users
{
    public static class UserStatus
    {
        public static string Current_UserID(Page myPage)
        {
            UserMgr myUserMgr = new UserMgr();

            Login_Users myUsers = myUserMgr.Get_Login_Users(myPage);

            if (myUsers != null)
            {
                return myUsers.UserID;
            }
            else
            {
                return "0";
            }
        }

        public static string Current_UserName(Page myPage)
        {
            UserMgr myUserMgr = new UserMgr();

            Login_Users myUsers = myUserMgr.Get_Login_Users(myPage);

            if (myUsers != null)
            {
                return myUsers.UserName;
            }
            else
            {
                return "Guest";
            }
        }

        public static bool Validate_UserGroup(Page myPage, UserGroup myUserGroup)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            UserMgr myUserMgr = new UserMgr();

            Login_Users myUsers = myUserMgr.Get_Login_Users(myPage);

            return myDP.Chk_UserInGroup(myUsers.UserID, StringEnum.GetStringValue(myUserGroup));
        }

        public static bool Validate_Ownership(Page myPage, string Ownership_UserID)
        {
            UserMgr myUserMgr = new UserMgr();

            Login_Users myUsers = myUserMgr.Get_Login_Users(myPage);

            if (myUsers != null)
            {
                if (myUsers.UserID == Ownership_UserID)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool Validate_PageAuth_View(Page myPage)
        {
            return Validate_PageAuth_View(myPage, myPage.Request["PageIndexID"]);
        }

        public static bool Validate_PageAuth_View(Page myPage, string PageIndexID)
        {

            Pages.PrivacyMgr myPrivacyMgr = new Pages.PrivacyMgr();

            string _pageindexid = myPrivacyMgr.Get_Inherited_Privacy_PageIndexID(PageIndexID);

            // Check Guest User first
            Pages.Page_Privacy Guest_Privacy = myPrivacyMgr.Get_Page_Privacy(_pageindexid, StringEnum.GetStringValue(UserGroup.Guest));

            if (Guest_Privacy == null)
            {
                // If Guest permission didn't set permission is allowed.
                return true;
            }
            else
            {
                if (Guest_Privacy.Allow_View)
                    return true;
            }

            // Check logged in user.
            UserMgr myUserMgr = new UserMgr();
            Login_Users myUsers = myUserMgr.Get_Login_Users(myPage);

            if (myUsers != null)
            {
                // User has logged in
                List<UserInGroups> myUserInGroups = myUserMgr.Get_UserIngroups_ByUserID(myUsers.UserID);

                foreach (UserInGroups myUserInGroup in myUserInGroups)
                {
                    Pages.Page_Privacy myPage_Privacy = myPrivacyMgr.Get_Page_Privacy(_pageindexid, myUserInGroup.UserGroupID);

                    if (myPage_Privacy != null)
                    {
                        if (myPage_Privacy.Allow_View)
                        {
                            return true;
                        }
                    }

                }
            }

            return false;
        }

        public static bool Validate_PageAuth_Modify(Page myPage)
        {
            Pages.PrivacyMgr myPrivacyMgr = new Pages.PrivacyMgr();

            string _pageindexid = myPrivacyMgr.Get_Inherited_Privacy_PageIndexID(myPage.Request["PageIndexID"]);

            // Check Guest User first
            Pages.Page_Privacy Guest_Privacy = myPrivacyMgr.Get_Page_Privacy(_pageindexid, StringEnum.GetStringValue(UserGroup.Guest));

            if (Guest_Privacy != null)
            {
                if (Guest_Privacy.Allow_Modify)
                    return true;
            }

            // Check logged in user.
            UserMgr myUserMgr = new UserMgr();
            Login_Users myUsers = myUserMgr.Get_Login_Users(myPage);

            if (myUsers != null)
            {
                // User has logged in
                List<UserInGroups> myUserInGroups = myUserMgr.Get_UserIngroups_ByUserID(myUsers.UserID);

                foreach (UserInGroups myUserInGroup in myUserInGroups)
                {
                    Pages.Page_Privacy myPage_Privacy = myPrivacyMgr.Get_Page_Privacy(_pageindexid, myUserInGroup.UserGroupID);

                    if (myPage_Privacy != null)
                    {
                        if (myPage_Privacy.Allow_Modify)
                        {
                            return true;
                        }
                    }

                }
            }

            return false;
        }


    }

}
