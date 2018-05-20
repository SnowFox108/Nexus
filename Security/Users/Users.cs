using System;
using System.Data;
using Nexus.Core;

namespace Nexus.Security.Users
{

    // Post_Status Enum
    public enum UserGroup
    {
        [StringValue("2DF310C3-81C5-4087-9CEC-3F1803AB1213")]
        UserAwaitingModeration,
        [StringValue("30E245C7-9D7F-4649-911C-CC6313076830")]
        UserAwaitingEmailConfirmation,
        [StringValue("522BF6CC-7095-4e38-82F0-B21A0CD85255")]
        Guest,
        [StringValue("5DACAE1C-32B9-4c16-983B-13CD74B7EB64")]
        Moderator,
        [StringValue("70039070-F69E-431b-9B05-46756BC65636")]
        SuperModerator,
        [StringValue("8C361793-7A9E-4a6c-BEF8-ACCBDB6A1931")]
        SystemAI,
        [StringValue("9C3C4A1F-1F78-4946-9D79-F4D247072C54")]
        RegisteredUser,
        [StringValue("B117D66E-3A2F-45b9-8329-2119426F9311")]
        Administrator
    }


    // General User Class
    public class Login_Users
    {

        private string _userid;
        private string _username;
        private string _email;
        private string _userpass;
        private bool _islockedout;
        private bool _deletemark;

        public string UserID { get { return _userid; } }
        public string UserName { get { return _username; } }
        public string Email { get { return _email; } }
        public string UserPass { get { return _userpass; } }
        public bool IsLockedOut { get { return _islockedout; } }
        public bool DeleteMark { get { return _deletemark; } }

        public Login_Users(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            if (myDR != null)
            {
                _userid = myDR["UserID"].ToString();
                _username = myDR["UserName"].ToString();
                _email = myDR["Email"].ToString();
                _userpass = myDR["UserPass"].ToString();
                _islockedout = (bool)myDR["IsLockedOut"];
                _deletemark = (bool)myDR["DeleteMark"];
            }
        }
    }

    public class UserGroups
    {
        private string _usergroupid;
        private string _usergroup_name;
        private string _sortorder;
        private string _description;
        private bool _issystemgroup;

        public string UserGroupID { get { return _usergroupid; } }
        public string UserGroup_Name { get { return _usergroup_name; } }
        public string SortOrder { get { return _sortorder; } }
        public string Description { get { return _description; } }
        public bool IsSystemGroup { get { return _issystemgroup; } }

        public UserGroups(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            _usergroupid = myDR["UserGroupID"].ToString();
            _usergroup_name = myDR["UserGroup_Name"].ToString();
            _sortorder = myDR["SortOrder"].ToString();
            _description = myDR["Description"].ToString();
            _issystemgroup = (bool)myDR["IsSystemGroup"];

        }

    }

    public class UserInGroups
    {
        private string _relationid;
        private string _userid;
        private string _usergroupid;

        public string RelationID { get { return _relationid; } }
        public string UserID { get { return _userid; } }
        public string UserGroupID { get { return _usergroupid; } }

        public UserInGroups(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

            _relationid = myDR["RelationID"].ToString();
            _userid = myDR["UserID"].ToString();
            _usergroupid = myDR["UserGroupID"].ToString();

        }

    }

}
