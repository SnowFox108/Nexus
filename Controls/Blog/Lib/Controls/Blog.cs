using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using Nexus.Core;

namespace Nexus.Controls.Blog.Lib
{

    // Image Enum
    public enum Post_Status
    {
        [StringValue("Publish")]
        Publish,
        [StringValue("Draft")]
        Draft,
        [StringValue("Hidden")]
        Hidden,
        [StringValue("Protected")]
        Protected
    }

    // Blog Post base class
    public class Blog_Post
    {
        private string _postid;
        private string _ownership_userid;
        private string _userid;
        private string _username;
        private string _bloggroupid;
        private string _post_date;
        private string _post_modifydate;
        private string _post_title;
        private string _post_content;
        private Post_Status _post_status;
        private string _post_password;
        private string _view_count;
        private string _comment_count;

        private string _post_date_short;
        private string _post_view_url;
        private string _post_view_url_full;

        public string PostID { get { return _postid; } }
        public string UserID { get { return _userid; } }
        public string Ownership_UserID { get { return _ownership_userid; } }
        public string UserName { get { return _username; } }
        public string BlogGroupID { get { return _bloggroupid; } }
        public string Post_Date { get { return _post_date; } }
        public string Post_ModifyDate { get { return _post_modifydate; } }
        public string Post_Title { get { return _post_title; } }
        public string Post_Content { get { return _post_content; } }
        public Post_Status Post_Status { get { return _post_status; } }
        public string Post_Password { get { return _post_password; } }
        public string View_Count { get { return _view_count; } }
        public string Comment_Count { get { return _comment_count; } }

        public string Post_Date_Short { get { return _post_date_short; } }
        public string Post_View_URL {
            set { _post_view_url = value; }
            get { return _post_view_url; } 
        }

        public string Post_View_URL_Full { get { return _post_view_url_full; } }


        public Blog_Post(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
            if (myDR != null)
            {
                _postid = myDR["PostID"].ToString();
                _userid = myDR["UserID"].ToString();
                _ownership_userid = myDR["Ownership_UserID"].ToString();
                _username = myDR["UserName"].ToString();
                _bloggroupid = myDR["BlogGroupID"].ToString();
                _post_date = myDR["Post_Date"].ToString();
                _post_modifydate = myDR["Post_ModifyDate"].ToString();
                _post_title = myDR["Post_Title"].ToString();
                _post_content = myDR["Post_Content"].ToString();
                _post_status = (Post_Status)StringEnum.Parse(typeof(Post_Status), myDR["Post_Status"].ToString(), true);
                _post_password = myDR["Post_Password"].ToString();
                _view_count = myDR["View_Count"].ToString();
                _comment_count = myDR["Comment_Count"].ToString();

                _post_date_short = Convert.ToDateTime(_post_date).ToShortDateString();

            }

        }

        public Blog_Post(DataRow myDR, string myPost_View_URL)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
            if (myDR != null)
            {
                _postid = myDR["PostID"].ToString();
                _userid = myDR["UserID"].ToString();
                _ownership_userid = myDR["Ownership_UserID"].ToString();
                _username = myDR["UserName"].ToString();
                _bloggroupid = myDR["BlogGroupID"].ToString();
                _post_date = myDR["Post_Date"].ToString();
                _post_modifydate = myDR["Post_ModifyDate"].ToString();
                _post_title = myDR["Post_Title"].ToString();
                _post_content = myDR["Post_Content"].ToString();
                _post_status = (Post_Status)StringEnum.Parse(typeof(Post_Status), myDR["Post_Status"].ToString(), true);
                _post_password = myDR["Post_Password"].ToString();
                _view_count = myDR["View_Count"].ToString();
                _comment_count = myDR["Comment_Count"].ToString();

                _post_date_short = Convert.ToDateTime(_post_date).ToShortDateString();
                _post_view_url = myPost_View_URL;
                _post_view_url_full = Nexus.Core.Tools.URLParse.Combine_Arg(_post_view_url, string.Format("NexusBlogPostID={0}", _postid));

            }

        }

    }

    // Blog Comment base class
    public class Blog_Comment
    {
        private string _commentid;
        private string _parent_commentid;
        private string _postid;
        private string _userid;
        private string _username;
        private string _useremail;
        private string _userurl;
        private string _useripaddress;
        private string _post_date;
        private string _post_content;
        private string _comment_approved;

        private string _username_url;

        public string CommentID { get { return _commentid; } }
        public string Parent_CommentID { get { return _parent_commentid; } }
        public string PostID { get { return _postid; } }
        public string UserID { get { return _userid; } }
        public string UserName { get { return _username; } }
        public string UserEmail { get { return _useremail; } }
        public string UserURL { get { return _userurl; } }
        public string UserIPaddress { get { return _useripaddress; } }
        public string Post_Date { get { return _post_date; } }
        public string Post_Content { get { return _post_content; } }
        public string Comment_Approved { get { return _comment_approved; } }

        public string UserName_URL { get { return _username_url; } }

        public Blog_Comment(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
            if (myDR != null)
            {
                _commentid = myDR["CommentID"].ToString();
                _parent_commentid = myDR["Parent_CommentID"].ToString();
                _postid = myDR["PostID"].ToString();
                _userid = myDR["UserID"].ToString();
                _username = myDR["UserName"].ToString();
                _useremail = myDR["UserEmail"].ToString();
                _userurl = myDR["UserURL"].ToString();
                _useripaddress = myDR["UserIPaddress"].ToString();
                _post_date = myDR["Post_Date"].ToString();
                _post_content = myDR["Post_Content"].ToString();
                _comment_approved = myDR["Comment_Approved"].ToString();

                if (!DataEval.IsEmptyQuery(_userurl))
                {
                    _username_url = string.Format("<A href='{0}' target='_blank'>{1}</A>", _userurl, _username);
                }
                else
                {
                    _username_url = _username;
                }
            }

        }

    }

}
