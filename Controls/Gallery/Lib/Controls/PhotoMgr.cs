using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using System.Xml;
using System.IO;
using Nexus.Core;
using Nexus.Core.Categories;
using Nexus.Core.Phrases;

using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Nexus.Controls.Gallery.Lib
{
    [DataObject(true)]
    public class PhotoMgr
    {
        public PhotoMgr()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        #region Photo Item List

        public List<Photo> Get_Photos(string CategoryID, string SortOrder, string Orientation)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Photos(CategoryID, SortOrder, Orientation);

            List<Photo> list = new List<Photo>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Photo(myDR, true));
            }

            return list;
        }

        public List<Photo> Get_Photos(string CategoryID, string SortOrder, string Orientation, string IsActive, int TotalNumber)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Photos(CategoryID, SortOrder, Orientation, IsActive, TotalNumber);

            List<Photo> list = new List<Photo>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Photo(myDR, true));
            }

            return list;
        }

        public List<Photo> Get_Photos(string CategoryID, string SortOrder, string Orientation, string IsActive, int TotalNumber, string PhotoDetailURL, string DisplayID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Photos(CategoryID, SortOrder, Orientation, IsActive, TotalNumber);

            List<Photo> list = new List<Photo>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Photo(myDR, true, PhotoDetailURL, DisplayID));
            }

            return list;

        }

        public Photo Get_Photo(string PhotoID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Photo(myDP.Get_Photo(PhotoID), false);
        }

        public Photo Get_Photo(string PhotoID, string DisplayID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Photo(myDP.Get_Photo(PhotoID), false, null, DisplayID);
        }


        public List<Photo_Setting> Get_Photo_Settings(string SortOrder = "SettingID")
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            DataSet myDS = myDP.Get_Photo_Settings(SortOrder);

            List<Photo_Setting> list = new List<Photo_Setting>();

            foreach (DataRow myDR in myDS.Tables[0].Rows)
            {
                list.Add(new Photo_Setting(myDR));
            }

            return list;

        }

        public Photo_Setting Get_Photo_Setting(string DisplayID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Photo_Setting(myDP.Get_Photo_Setting(DisplayID));
        }

        public Photo_Setting Get_Photo_Setting_byID(string SettingID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Photo_Setting(myDP.Get_Photo_Setting_byID(SettingID));
        }

        public Photo_Item_Map Get_Photo_Map(string Item_MapID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return new Photo_Item_Map(myDP.Get_Photo_Item_Map(Item_MapID));
        }

        public bool Chk_Photo(string PhotoID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Chk_Photo(PhotoID);
        }

        public int Count_Photo_Item_Mapping(string PhotoID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Count_Photo_Item_Mapping(PhotoID);
        }

        public bool Chk_Photo_Item_Mapping(string PhotoID, string CategoryID)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Chk_Photo_Item_Mapping(PhotoID, CategoryID);
        }

        public bool Chk_Photo_Setting(string DisplayID)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            return myDP.Chk_Photo_Setting(DisplayID);
        }

        public void Add_Photo(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Photo(UpdateData);
        }

        public void Add_Photo_Item_Mapping(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Photo_Item_Mapping(UpdateData);
        }

        public void Add_Photo_Setting(e2Data[] UpdateData)
        {
            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Add_Photo_Setting(UpdateData);
        }

        public void Edit_Photo(e2Data[] UpdateData)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Photo(UpdateData);
        }

        public void Edit_Photo_Item_Mapping(e2Data[] UpdateData)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Photo_Item_Mapping(UpdateData);
        }

        public void Edit_Photo_Setting(e2Data[] UpdateData)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Edit_Photo_Setting(UpdateData);
        }


        public void Remove_Photo(string PhotoID)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Photo(PhotoID);
        }

        public void Remove_Photo_Items_Mapping(string PhotoID)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Photo_Items_Mapping(PhotoID);
        }

        public void Remove_Photo_Mapping(string Item_MapID)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Photo_Item_Mapping(Item_MapID);
        }

        public void Remove_Photo_Setting(string SettingID)
        {

            MySQL_DataConn myDP = new MySQL_DataConn(ConfigurationManager.ConnectionStrings["e2CMS"].ConnectionString);

            myDP.Remove_Photo_Setting(SettingID);
        }


        #endregion

        #region Show Img

        public void InitImg(HttpContext context, string DisplayID, string PhotoID)
        {
            Photo myPhoto = Get_Photo(PhotoID);
            Photo_Setting myPhoto_Setting = Get_Photo_Setting(DisplayID);

            Bitmap bitMapImage;

            // 检测文件是否存在
            if (myPhoto.ImageURL_Type == ImageURL_Type.Internal)
            {
                // 本地文件
                if (File.Exists(context.Server.MapPath(myPhoto.ImageURL)))
                {
                    bitMapImage = new Bitmap(context.Server.MapPath(myPhoto.ImageURL));
                }
                else
                {
                    bitMapImage = new Bitmap(context.Server.MapPath(myPhoto_Setting.Image_BrokenURL));
                }
            }
            else
            {
                // 远程文件
                try
                {
                    bitMapImage = ImgLib.GetBitmapFromUri(myPhoto.ImageURL);
                }
                catch
                {
                    bitMapImage = new Bitmap(context.Server.MapPath(myPhoto_Setting.Image_BrokenURL));
                }
            }

            // Photo Setting
            if (myPhoto_Setting.IsResize)
            {

                Point resizePoint = new Point();

                switch (myPhoto_Setting.Resize_Type)
                {
                    case Resize_Type.Fixed:
                        resizePoint = ResizeFixed(bitMapImage, myPhoto_Setting);
                        break;
                    case Resize_Type.MinHeight:
                        resizePoint = ResizeMinHeight(bitMapImage, myPhoto_Setting);
                        break;
                    case Resize_Type.MinWidth:
                        resizePoint = ResizeMinWidth(bitMapImage, myPhoto_Setting);
                        break;
                    case Resize_Type.MinHeight_and_MinWidth:
                        resizePoint = ResizeMinHeightMinWidth(bitMapImage, myPhoto_Setting);
                        break;
                    case Resize_Type.MaxHeight:
                        resizePoint = ResizeMaxHeight(bitMapImage, myPhoto_Setting);
                        break;
                    case Resize_Type.MaxWidth:
                        resizePoint = ResizeMaxWidth(bitMapImage, myPhoto_Setting);
                        break;
                    case Resize_Type.MaxHeight_and_MaxWidth:
                        resizePoint = ResizeMaxHeightMaxWidth(bitMapImage, myPhoto_Setting);
                        break;

                }

                bitMapImage = ImgLib.ResizeBitmap(bitMapImage, resizePoint.X, resizePoint.Y);

            }

            if (myPhoto_Setting.IsOverlay)
            {

                Bitmap overlayBitmap = new Bitmap(context.Server.MapPath(myPhoto_Setting.Overlay_ImageURL));
                Point overlayPoint = new Point();

                switch (myPhoto_Setting.Overlay_Position)
                {
                    case Overlay_Position.TopLeft:
                        overlayPoint = OverlayTopLeft(bitMapImage, overlayBitmap, myPhoto_Setting);
                        break;
                    case Overlay_Position.TopRight:
                        overlayPoint = OverlayTopRight(bitMapImage, overlayBitmap, myPhoto_Setting);
                        break;
                    case Overlay_Position.Center:
                        overlayPoint = OverlayCenter(bitMapImage, overlayBitmap, myPhoto_Setting);
                        break;
                    case Overlay_Position.BottomLeft:
                        overlayPoint = OverlayBottomLeft(bitMapImage, overlayBitmap, myPhoto_Setting);
                        break;
                    case Overlay_Position.BottomRight:
                        overlayPoint = OverlayBottomRight(bitMapImage, overlayBitmap, myPhoto_Setting);
                        break;
                }

                bitMapImage = ImgLib.OverlayBitmap(bitMapImage, overlayBitmap, myPhoto_Setting.Overlay_Opacity, overlayPoint);
            }

            ShowImg(context, bitMapImage);
        }

        public void ShowImg(HttpContext context, Bitmap image)
        {

            Graphics graphicImage;

            try
            {
                graphicImage = Graphics.FromImage(image);
            }
            catch
            {
                image = ImgLib.ConvertBitmapToJpeg(image, 100);
                graphicImage = Graphics.FromImage(image);

            }

            //Smooth graphics is nice.
            graphicImage.SmoothingMode = SmoothingMode.AntiAlias;


            //Set the content type
            context.Response.ContentType = "image/jpeg";

            //Save the new image to the response output stream.
            image.Save(context.Response.OutputStream, ImageFormat.Jpeg);

            //Clean house.
            graphicImage.Dispose();
            image.Dispose();

        }

        private Point ResizeFixed(Bitmap image, Photo_Setting myPhoto_Setting)
        {
            return new Point(myPhoto_Setting.Resize_Width, myPhoto_Setting.Resize_Height);
        }

        private Point ResizeMinHeight(Bitmap image, Photo_Setting myPhoto_Setting)
        {
            Point myPoint = new Point(image.Width, myPhoto_Setting.Resize_Height);

            if (image.Height < myPhoto_Setting.Resize_Height)
            {
                Single ratio = myPhoto_Setting.Resize_Height/Convert.ToSingle(image.Height);
                myPoint.X = Convert.ToInt32(image.Width * ratio);
                myPoint.Y = Convert.ToInt32(image.Height * ratio);

            }

            return myPoint;
        }

        private Point ResizeMinWidth(Bitmap image, Photo_Setting myPhoto_Setting)
        {
            Point myPoint = new Point(myPhoto_Setting.Resize_Width, image.Height);

            if (image.Width < myPhoto_Setting.Resize_Width)
            {
                Single ratio = myPhoto_Setting.Resize_Width / Convert.ToSingle(image.Width);
                myPoint.X = Convert.ToInt32(image.Width * ratio);
                myPoint.Y = Convert.ToInt32(image.Height * ratio);

            }

            return myPoint;
        }

        private Point ResizeMinHeightMinWidth(Bitmap image, Photo_Setting myPhoto_Setting)
        {
            Point myPoint = new Point(myPhoto_Setting.Resize_Width, myPhoto_Setting.Resize_Height);

            if (image.Height < myPhoto_Setting.Resize_Height)
            {
                Single ratio = myPhoto_Setting.Resize_Height / Convert.ToSingle(image.Height);
                myPoint.X = Convert.ToInt32(image.Width * ratio);
                myPoint.Y = Convert.ToInt32(image.Height * ratio);

            }

            if (myPoint.X < myPhoto_Setting.Resize_Width)
            {
                Single ratio = myPhoto_Setting.Resize_Width / Convert.ToSingle(myPoint.X);
                myPoint.X = Convert.ToInt32(myPoint.X * ratio);
                myPoint.Y = Convert.ToInt32(myPoint.Y * ratio);

            }

            return myPoint;
        }

        private Point ResizeMaxHeight(Bitmap image, Photo_Setting myPhoto_Setting)
        {
            Point myPoint = new Point(image.Width, myPhoto_Setting.Resize_Height);

            if (image.Height > myPhoto_Setting.Resize_Height)
            {
                Single ratio = myPhoto_Setting.Resize_Height / Convert.ToSingle(image.Height);
                myPoint.X = Convert.ToInt32(image.Width * ratio);
                myPoint.Y = Convert.ToInt32(image.Height * ratio);

            }

            return myPoint;
        }

        private Point ResizeMaxWidth(Bitmap image, Photo_Setting myPhoto_Setting)
        {
            Point myPoint = new Point(myPhoto_Setting.Resize_Width, image.Height);

            if (image.Width > myPhoto_Setting.Resize_Width)
            {
                Single ratio = myPhoto_Setting.Resize_Width / Convert.ToSingle(image.Width);
                myPoint.X = Convert.ToInt32(image.Width * ratio);
                myPoint.Y = Convert.ToInt32(image.Height * ratio);

            }

            return myPoint;
        }

        private Point ResizeMaxHeightMaxWidth(Bitmap image, Photo_Setting myPhoto_Setting)
        {
            Point myPoint = new Point(myPhoto_Setting.Resize_Width, myPhoto_Setting.Resize_Height);

            if (image.Height > myPhoto_Setting.Resize_Height)
            {
                Single ratio = myPhoto_Setting.Resize_Height / Convert.ToSingle(image.Height);
                myPoint.X = Convert.ToInt32(image.Width * ratio);
                myPoint.Y = Convert.ToInt32(image.Height * ratio);

            }

            if (myPoint.X > myPhoto_Setting.Resize_Width)
            {
                Single ratio = myPhoto_Setting.Resize_Width / Convert.ToSingle(myPoint.X);
                myPoint.X = Convert.ToInt32(myPoint.X * ratio);
                myPoint.Y = Convert.ToInt32(myPoint.Y * ratio);

            }

            return myPoint;
        }

        private Point OverlayTopLeft(Bitmap image, Bitmap overlay_image, Photo_Setting myPhoto_Setting)
        {
            return new Point(myPhoto_Setting.Overlay_PaddingX, myPhoto_Setting.Overlay_PaddingY);
        }

        private Point OverlayTopRight(Bitmap image, Bitmap overlay_image, Photo_Setting myPhoto_Setting)
        {
            return new Point(image.Size.Width - overlay_image.Size.Width - myPhoto_Setting.Overlay_PaddingX,
                myPhoto_Setting.Overlay_PaddingY);
        }

        private Point OverlayCenter(Bitmap image, Bitmap overlay_image, Photo_Setting myPhoto_Setting)
        {
            return new Point(image.Size.Width / 2 - overlay_image.Size.Width / 2 + myPhoto_Setting.Overlay_PaddingX,
                image.Size.Height / 2 - overlay_image.Size.Height / 2 + myPhoto_Setting.Overlay_PaddingY);
        }

        private Point OverlayBottomLeft(Bitmap image, Bitmap overlay_image, Photo_Setting myPhoto_Setting)
        {
            return new Point(myPhoto_Setting.Overlay_PaddingX, image.Size.Height - overlay_image.Size.Height - myPhoto_Setting.Overlay_PaddingY);
        }

        private Point OverlayBottomRight(Bitmap image, Bitmap overlay_image, Photo_Setting myPhoto_Setting)
        {
            return new Point(image.Size.Width - overlay_image.Size.Width - myPhoto_Setting.Overlay_PaddingX,
                image.Size.Height - overlay_image.Height - myPhoto_Setting.Overlay_PaddingY);
        }


        #endregion

    }
}
