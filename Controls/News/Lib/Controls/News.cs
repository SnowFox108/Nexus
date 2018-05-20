using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using Nexus.Core;

namespace Nexus.Controls.News.Lib
{
    // Image Enum
    public enum News_Status
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
    public class News_Post
    {
        private string _newsid;
        private string _categoryid;
        private string _userid;
        private string _username;
        private string _news_date;
        private string _news_modifydate;
        private string _news_title;
        private string _news_brief;
        private string _news_content;
        private News_Status _news_status;
        private string _news_password;
        private string _view_count;
        private string _comment_count;

        private string _author;
        private string _source_name;
        private string _source_url;

        private string _news_date_short;
        private string _source_name_url;

        private bool _show_originality;
        private string _newsdetail_url;
        private string _newsdetail_url_full;

        public string NewsID { get { return _newsid; } }
        public string UserID { get { return _userid; } }
        public string CategoryID { get { return _categoryid; } }
        public string UserName { get { return _username; } }
        public string News_Date { get { return _news_date; } }
        public string News_ModifyDate { get { return _news_modifydate; } }
        public string News_Title { get { return _news_title; } }
        public string News_Brief { get { return _news_brief; } }
        public string News_Content { get { return _news_content; } }
        public News_Status News_Status { get { return _news_status; } }
        public string News_Password { get { return _news_password; } }
        public string View_Count { get { return _view_count; } }
        public string Comment_Count { get { return _comment_count; } }

        public string Author { get { return _author; } }
        public string Source_Name { get { return _source_name; } }
        public string Source_URL { get { return _source_url; } }

        public string News_Date_Short { get { return _news_date_short; } }
        public string Source_Name_URL { get { return _source_name_url; } }

        public bool Show_Originality { get { return _show_originality; } }

        public string NewsDetail_URL
        {
            set { _newsdetail_url = value; }
            get { return _newsdetail_url; }
        }

        public string NewsDetail_URL_Full { get { return _newsdetail_url_full; } }

        public News_Post(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
            if (myDR != null)
            {
                _newsid = myDR["NewsID"].ToString();
                _categoryid = myDR["CategoryID"].ToString();
                _userid = myDR["UserID"].ToString();
                _username = myDR["UserName"].ToString();
                _news_date = myDR["News_Date"].ToString();
                _news_modifydate = myDR["News_ModifyDate"].ToString();
                _news_title = myDR["News_Title"].ToString();
                _news_brief = myDR["News_Brief"].ToString();
                _news_content = myDR["News_Content"].ToString();
                _news_status = (News_Status)StringEnum.Parse(typeof(News_Status), myDR["News_Status"].ToString(), true);
                _news_password = myDR["News_Password"].ToString();
                _view_count = myDR["View_Count"].ToString();
                _comment_count = myDR["Comment_Count"].ToString();

                _author = myDR["Author"].ToString();
                _source_name = myDR["Source_Name"].ToString();
                _source_url = myDR["Source_URL"].ToString();

                _news_date_short = Convert.ToDateTime(_news_date).ToShortDateString();

                if (!DataEval.IsEmptyQuery(_source_url))
                {
                    _source_name_url = string.Format("<A href='{0}' target='_blank'>{1}</A>", _source_url, _source_name);
                }
                else
                {
                    _source_name_url = _source_name;
                }

                if (DataEval.IsEmptyQuery(_author) && DataEval.IsEmptyQuery(_source_name))
                {
                    _show_originality = false;
                }
                else
                {
                    _show_originality = true;
                }

            }

        }

        public News_Post(DataRow myDR, string myNewsDetail_URL)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
            if (myDR != null)
            {
                _newsid = myDR["NewsID"].ToString();
                _categoryid = myDR["CategoryID"].ToString();
                _userid = myDR["UserID"].ToString();
                _username = myDR["UserName"].ToString();
                _news_date = myDR["News_Date"].ToString();
                _news_modifydate = myDR["News_ModifyDate"].ToString();
                _news_title = myDR["News_Title"].ToString();
                _news_brief = myDR["News_Brief"].ToString();
                _news_content = myDR["News_Content"].ToString();
                _news_status = (News_Status)StringEnum.Parse(typeof(News_Status), myDR["News_Status"].ToString(), true);
                _news_password = myDR["News_Password"].ToString();
                _view_count = myDR["View_Count"].ToString();
                _comment_count = myDR["Comment_Count"].ToString();

                _author = myDR["Author"].ToString();
                _source_name = myDR["Source_Name"].ToString();
                _source_url = myDR["Source_URL"].ToString();

                _news_date_short = Convert.ToDateTime(_news_date).ToShortDateString();

                if (!DataEval.IsEmptyQuery(_source_url))
                {
                    _source_name_url = string.Format("<a href='{0}' target='_blank'>{1}</a>", _source_url, _source_name);
                }
                else
                {
                    _source_name_url = _source_name;
                }

                if (DataEval.IsEmptyQuery(_author) && DataEval.IsEmptyQuery(_source_name))
                {
                    _show_originality = false;
                }
                else
                {
                    _show_originality = true;
                }

                _newsdetail_url = myNewsDetail_URL;
                _newsdetail_url_full = Nexus.Core.Tools.URLParse.Combine_Arg(_newsdetail_url, string.Format("NexusNewsPostID={0}", _newsid));


            }

        }


    }

    // Blog Comment base class
    public class News_Comment
    {
        private string _commentid;
        private string _parent_commentid;
        private string _newsid;
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
        public string NewsID { get { return _newsid; } }
        public string UserID { get { return _userid; } }
        public string UserName { get { return _username; } }
        public string UserEmail { get { return _useremail; } }
        public string UserURL { get { return _userurl; } }
        public string UserIPaddress { get { return _useripaddress; } }
        public string Post_Date { get { return _post_date; } }
        public string Post_Content { get { return _post_content; } }
        public string Comment_Approved { get { return _comment_approved; } }

        public string UserName_URL { get { return _username_url; } }

        public News_Comment(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
            if (myDR != null)
            {
                _commentid = myDR["CommentID"].ToString();
                _parent_commentid = myDR["Parent_CommentID"].ToString();
                _newsid = myDR["NewsID"].ToString();
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
                    _username_url = string.Format("<a href='{0}' target='_blank'>{1}</a>", _userurl, _username);
                }
                else
                {
                    _username_url = _username;
                }
            }

        }
    }
}
