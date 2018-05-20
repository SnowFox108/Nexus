using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using Nexus.Core;

namespace Nexus.Controls.Gallery.Lib
{

    // List Type
    public enum ImageURL_Type
    {
        [StringValue("Internal")]
        Internal,
        [StringValue("External")]
        External
    }

    public enum Resize_Type
    {
        [StringValue("Fixed")]
        Fixed,
        [StringValue("MaxWidth")]
        MaxWidth,
        [StringValue("MaxHeight")]
        MaxHeight,
        [StringValue("MaxHeight and MaxWidth")]
        MaxHeight_and_MaxWidth,
        [StringValue("MinWidth")]
        MinWidth,
        [StringValue("MinHeight")]
        MinHeight,
        [StringValue("MinHeight and MinWidth")]
        MinHeight_and_MinWidth
    }

    public enum Overlay_Position
    {
        [StringValue("TopLeft")]
        TopLeft,
        [StringValue("TopRight")]
        TopRight,
        [StringValue("BottomLeft")]
        BottomLeft,
        [StringValue("BottomRight")]
        BottomRight,
        [StringValue("Center")]
        Center
    }

    public class Photo
    {

        private string _photoid;
        private string _photo_title;
        private string _description;
        private string _imageurl;
        private ImageURL_Type _imageurl_type;
        private string _alternatetext;
        private string _linkurl;
        private string _link_target;
        private int _view_count;        
        private bool _isactive;
        private DateTime _create_date;
        private DateTime _lastupdate_date;
        private string _lastupdate_userid;

        private string _item_mapid;
        private string _categoryid;
        private int _sortorder;

        public string PhotoID { get { return _photoid; } }
        public string Photo_Title { 
            get { return _photo_title; }
            set { _photo_title = value; }        
        }
        public string Description { get { return _description; } }
        public string ImageURL { 
            get { return _imageurl; }
            set { _imageurl = value; }        
        }
        public ImageURL_Type ImageURL_Type { get { return _imageurl_type; } }
        public string AlternateText { get { return _alternatetext; } }
        public string LinkURL { get { return _linkurl; } }
        public string Link_Target { get { return _link_target; } }
        public int View_Count { get { return _view_count; } }
        public bool IsActive { get { return _isactive; } }
        public DateTime Create_Date { get { return _create_date; } }
        public DateTime LastUpdate_Date { get { return _lastupdate_date; } }
        public string LastUpdate_UserID { get { return _lastupdate_userid; } }

        public string Item_MapID { get { return _item_mapid; } }
        public string CategoryID { get { return _categoryid; } }
        public int SortOrder { get { return _sortorder; } }

        #region Optional Parameter

        private string _photo_detailurl;
        private string _photo_detailurl_full;
        private string _photo_displayid;

        public string Photo_DetailURL
        {
            set { _photo_detailurl = value; }
            get { return _photo_detailurl; }
        }

        public string Photo_DetailURL_Full { get { return _photo_detailurl_full; } }
        public string Photo_DisplayID { get { return _photo_displayid; } }

        #endregion

        public Photo()
        {

        }

        public Photo(DataRow myDR, bool isView = false, string myPhoto_DetailURL = "", string myPhoto_DisplayID = "")
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
            if (myDR != null)
            {
                _photoid = myDR["PhotoID"].ToString();
                _imageurl_type = (ImageURL_Type)StringEnum.Parse(typeof(ImageURL_Type), myDR["ImageURL_Type"].ToString(), true);
                _photo_title = myDR["Photo_Title"].ToString();
                _imageurl = myDR["ImageURL"].ToString();
                _alternatetext = myDR["AlternateText"].ToString();
                _linkurl = myDR["LinkURL"].ToString();
                _description = myDR["Description"].ToString();
                _link_target = myDR["Link_Target"].ToString();
                _view_count = Convert.ToInt32(myDR["View_Count"]);
                _isactive = Convert.ToBoolean(myDR["IsActive"]);
                _create_date = Convert.ToDateTime(myDR["Create_Date"]);
                _lastupdate_date = Convert.ToDateTime(myDR["LastUpdate_Date"]);
                _lastupdate_userid = myDR["LastUpdate_UserID"].ToString();

                if (isView)
                {
                    _item_mapid = myDR["Item_MapID"].ToString();
                    _categoryid = myDR["CategoryID"].ToString();
                    _sortorder = Convert.ToInt32(myDR["SortOrder"]);
                }

                if (!DataEval.IsEmptyQuery(myPhoto_DetailURL))
                {
                    _photo_detailurl = myPhoto_DetailURL;
                    _photo_detailurl_full = Nexus.Core.Tools.URLParse.Combine_Arg(_photo_detailurl, string.Format("NexusPhotoID={0}", _photoid));
                }

                if (!DataEval.IsEmptyQuery(myPhoto_DisplayID))
                {
                    _photo_displayid = myPhoto_DisplayID;
                }
                
            }
        }
    }

    public class Photo_Item_Map
    {
        private string _item_mapid;
        private string _photoid;

        private string _categoryid;
        private int _sortorder;

        public string Item_MapID { get { return _item_mapid; } }
        public string PhotoID { get { return _photoid; } }

        public string CategoryID { get { return _categoryid; } }
        public int SortOrder { get { return _sortorder; } }

        public Photo_Item_Map(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
            if (myDR != null)
            {
                _item_mapid = myDR["Item_MapID"].ToString();
                _photoid = myDR["PhotoID"].ToString();
                _categoryid = myDR["CategoryID"].ToString();
                _sortorder = Convert.ToInt32(myDR["SortOrder"]);

            }

        }

    }

    public class Photo_Setting
    {

        private string _settingid;
        private string _displayid;
        private string _image_brokenurl;
        private bool _isresize;
        private Resize_Type _resize_type;
        private int _resize_height;
        private int _resize_width;
        private bool _isoverlay;
        private string _overlay_imageurl;
        private int _overlay_opacity;
        private Overlay_Position _overlay_position;
        private int _overlay_paddingx;
        private int _overlay_paddingy;

        public string SettingID { get { return _settingid; } }
        public string DisplayID { get { return _displayid; } }
        public string Image_BrokenURL { get { return _image_brokenurl; } }
        public bool IsResize { get { return _isresize; } }
        public Resize_Type Resize_Type { get { return _resize_type; } }
        public int Resize_Height { get { return _resize_height; } }
        public int Resize_Width { get { return _resize_width; } }
        public bool IsOverlay { get { return _isoverlay; } }
        public string Overlay_ImageURL { get { return _overlay_imageurl; } }
        public int Overlay_Opacity { get { return _overlay_opacity; } }
        public Overlay_Position Overlay_Position { get { return _overlay_position; } }
        public int Overlay_PaddingX { get { return _overlay_paddingx; } }
        public int Overlay_PaddingY { get { return _overlay_paddingy; } }

        public Photo_Setting(DataRow myDR)
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
            if (myDR != null)
            {
                _settingid = myDR["SettingID"].ToString();
                _displayid = myDR["DisplayID"].ToString();
                _image_brokenurl = myDR["Image_BrokenURL"].ToString();
                _isresize = Convert.ToBoolean(myDR["IsResize"]);
                _resize_type = (Resize_Type)StringEnum.Parse(typeof(Resize_Type), myDR["Resize_Type"].ToString(), true);
                _resize_height = Convert.ToInt32(myDR["Resize_Height"]);
                _resize_width = Convert.ToInt32(myDR["Resize_Width"]);
                _isoverlay = Convert.ToBoolean(myDR["IsOverlay"]);
                _overlay_imageurl = myDR["Overlay_ImageURL"].ToString();
                _overlay_opacity = Convert.ToInt32(myDR["Overlay_Opacity"]);
                _overlay_position = (Overlay_Position)StringEnum.Parse(typeof(Overlay_Position), myDR["Overlay_Position"].ToString(), true);
                _overlay_paddingx = Convert.ToInt32(myDR["Overlay_PaddingX"]);
                _overlay_paddingy = Convert.ToInt32(myDR["Overlay_PaddingY"]);

            }
        }
    }

}
