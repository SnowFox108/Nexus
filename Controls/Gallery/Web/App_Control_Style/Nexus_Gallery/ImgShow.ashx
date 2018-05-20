<%@ WebHandler Language="C#" Class="Nexus.Controls.Gallery.ImgShow" %>

using System;
using System.Web;

namespace Nexus.Controls.Gallery
{
    public class ImgShow : IHttpHandler
    {

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            string PhotoID = context.Request.QueryString["NexusPhotoID"];
            string DisplayID = context.Request.QueryString["DisplayID"];
            string ViewCount = context.Request.QueryString["ViewCount"];
            
            Lib.PhotoMgr myPhotoMgr = new Lib.PhotoMgr();
            
            // Set Photo Display Setting
            if (DataEval.IsEmptyQuery(DisplayID) || !myPhotoMgr.Chk_Photo_Setting(DisplayID))
            {
                DisplayID = "Default";
            }
            
            // View Counter
            if (ViewCount == "True")
            {
                View_Count(PhotoID);
            }
            
            // Display Image
            myPhotoMgr.InitImg(context, DisplayID, PhotoID);
        }

        private void View_Count(string PhotoID)
        {
            if (!DataEval.IsEmptyQuery(PhotoID))
            {
                // Add View Count
                Lib.PhotoMgr myPhotoMgr = new Lib.PhotoMgr();

                Lib.Photo myPhoto = myPhotoMgr.Get_Photo(PhotoID);

                int _view_count = Convert.ToInt32(myPhoto.View_Count) + 1;

                e2Data[] UpdateData_Item = {
                                               new e2Data("PhotoID", myPhoto.PhotoID),
                                               new e2Data("View_Count", _view_count.ToString())
                                           };

                myPhotoMgr.Edit_Photo(UpdateData_Item);
            }
            
        }

    }
}