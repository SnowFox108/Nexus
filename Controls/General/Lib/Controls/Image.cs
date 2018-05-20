using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using Nexus.Core;
using System.ComponentModel;

namespace  Nexus.Controls.General.Lib
{

    // Image base class
    public class Image
    {
        private string _imageid;
        private string _categoryid;
        private string _display_name;
        private string _imageurl;
        private string _alternatetext;
        private string _linkurl;
        private string _link_target;
        private string _create_date;
        private string _lastupdate_date;
        private string _lastupdate_userid;

        public string ImageID { get { return _imageid; } }
        public string CategoryID { get { return _categoryid; } }
        public string Display_Name { get { return _display_name; } }
        public string ImageURL { get { return _imageurl; } }
        public string AlternateText { get { return _alternatetext; } }
        public string LinkURL { get { return _linkurl; } }
        public string Link_Target { get { return _link_target; } }
        public string Create_Date { get { return _create_date; } }
        public string LastUpdate_Date { get { return _lastupdate_date; } }
        public string LastUpdate_UserID { get { return _lastupdate_userid; } }

        public Image(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
            if (myDR != null)
            {
                _imageid = myDR["ImageID"].ToString();
                _categoryid = myDR["CategoryID"].ToString();
                _display_name = myDR["Display_Name"].ToString();
                _imageurl = myDR["ImageURL"].ToString();
                _alternatetext = myDR["AlternateText"].ToString();
                _linkurl = myDR["LinkURL"].ToString();
                _link_target = myDR["Link_Target"].ToString();
                _create_date = myDR["Create_Date"].ToString();
                _lastupdate_date = myDR["LastUpdate_Date"].ToString();
                _lastupdate_userid = myDR["LastUpdate_UserID"].ToString();
            }

        }


    }

    public class ImageMgr
    {
        public ImageMgr()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //

        }

        public Image Get_Image_Content(string ImageID)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Image(myDP.Get_Image_Content(ImageID));
        }

        public void Add_Image_Content(e2Data[] UpdateData)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Image_Content(UpdateData);
        }

        public void Edit_Image_Content(e2Data[] UpdateData)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Image_Content(UpdateData);

        }

        public void Remove_Image_Content(string ImageID)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Image_Content(ImageID);
        }
    }


}
