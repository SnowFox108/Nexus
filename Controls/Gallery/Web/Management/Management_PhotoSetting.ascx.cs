using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;
using Nexus.Core.Categories;
using Nexus.Core.Phrases;

namespace Nexus.Controls.Gallery.Management
{
    public partial class PhotoSetting : System.Web.UI.UserControl
    {

        private bool _isedit;
        private bool _isnew; // false = addnew, true = edit

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Init_Form();
                Reset_Form();
            }

            Control_Init();

        }

        private void Control_Init()
        {
            //if (_isedit)
            //{
            //    MultiView_PhotoSetting.SetActiveView(View_Edit);
            //}
            //else
            //{
            //    MultiView_PhotoSetting.SetActiveView(View_List);
            //}

            Lib.PhotoMgr myPhotoMgr = new Lib.PhotoMgr();

            ListView_PhotoSettings.DataSource = myPhotoMgr.Get_Photo_Settings();
            ListView_PhotoSettings.DataKeyNames = new string[] { "SettingID" };
            ListView_PhotoSettings.DataBind();
        }

        private void Init_Form()
        {
            _isedit = false;
            MultiView_PhotoSetting.SetActiveView(View_List);

            #region Bind Data to droplist
            droplist_Resize_Type_Fill();
            droplist_Overlay_Position_Fill();
            #endregion

        }

        private void droplist_Resize_Type_Fill()
        {
            //Gets your enum names and adds it to a string array
            Array enumNames = Enum.GetValues(typeof(Lib.Resize_Type));

            //Creates an ArrayList
            ArrayList myResize_Types = new ArrayList();

            //Loop through your string array and poppulates the ArrayList
            foreach (Lib.Resize_Type myResize_Type in enumNames)
            {
                myResize_Types.Add(new { Value = StringEnum.GetStringValue(myResize_Type), Name = StringEnum.GetStringValue(myResize_Type) });
            }


            //Bind the ArrayList to your DropDownList
            droplist_ResizeType.DataSource = myResize_Types;
            droplist_ResizeType.DataTextField = "Name";
            droplist_ResizeType.DataValueField = "Value";
            droplist_ResizeType.DataBind();

        }

        private void droplist_Overlay_Position_Fill()
        {
            //Gets your enum names and adds it to a string array
            Array enumNames = Enum.GetValues(typeof(Lib.Overlay_Position));

            //Creates an ArrayList
            ArrayList myOverlay_Positions = new ArrayList();

            //Loop through your string array and poppulates the ArrayList
            foreach (Lib.Overlay_Position myOverlay_Position in enumNames)
            {
                myOverlay_Positions.Add(new { Value = StringEnum.GetStringValue(myOverlay_Position), Name = myOverlay_Position.ToString() });
            }


            //Bind the ArrayList to your DropDownList
            droplist_Overlay_Position.DataSource = myOverlay_Positions;
            droplist_Overlay_Position.DataTextField = "Name";
            droplist_Overlay_Position.DataValueField = "Value";
            droplist_Overlay_Position.DataBind();

        }

        private void Reset_Form()
        {
            HiddenField_DisplayID.Value = "";
            tbx_DisplayID.Text = "";
            tbx_Image_BrokenURL.Text = "";

            rbtn_IsResize.SelectedValue = "False";
            droplist_ResizeType.SelectedIndex = 0;
            RadNumericTbx_ResizeHeight.Value = 200;
            RadNumericTbx_ResizeWidth.Value = 200;
            Panel_IsResize.Visible = false;

            rbtn_IsOverlay.SelectedValue = "False";
            tbx_Overlay_ImageURL.Text = "";
            RadNumericTbx_Overlay_Opacity.Value = 80;
            droplist_Overlay_Position.SelectedIndex = 0;
            RadNumericTbx_Overlay_PaddingX.Value = 10;
            RadNumericTbx_Overlay_PaddingY.Value = 10;
            Panel_IsOverlay.Visible = false;
        }

        protected void btn_Add_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Lib.PhotoMgr myPhotoMgr = new Lib.PhotoMgr();

                e2Data[] UpdateData = {
                                          new e2Data("DisplayID", tbx_DisplayID.Text),
                                          new e2Data("Image_BrokenURL", tbx_Image_BrokenURL.Text),
                                          new e2Data("IsResize", rbtn_IsResize.SelectedValue),
                                          new e2Data("Resize_Type", droplist_ResizeType.SelectedValue),
                                          new e2Data("Resize_Height", RadNumericTbx_ResizeHeight.Text),
                                          new e2Data("Resize_Width", RadNumericTbx_ResizeWidth.Text),
                                          new e2Data("IsOverlay", rbtn_IsOverlay.SelectedValue),
                                          new e2Data("Overlay_ImageURL", tbx_Overlay_ImageURL.Text),
                                          new e2Data("Overlay_Opacity", RadNumericTbx_Overlay_Opacity.Text),
                                          new e2Data("Overlay_Position", droplist_Overlay_Position.SelectedValue),
                                          new e2Data("Overlay_PaddingX", RadNumericTbx_Overlay_PaddingX.Text),
                                          new e2Data("Overlay_PaddingY", RadNumericTbx_Overlay_PaddingY.Text)
                                      };

                myPhotoMgr.Add_Photo_Setting(UpdateData);

                _isedit = false;
                MultiView_PhotoSetting.SetActiveView(View_List);

                Control_Init();
            }
        }

        protected void btn_Update_Command(object sender, CommandEventArgs e)
        {
            if (Page.IsValid)
            {
                Lib.PhotoMgr myPhotoMgr = new Lib.PhotoMgr();

                e2Data[] UpdateData = {
                                          new e2Data("SettingID", e.CommandArgument.ToString()),
                                          new e2Data("DisplayID", tbx_DisplayID.Text),
                                          new e2Data("Image_BrokenURL", tbx_Image_BrokenURL.Text),
                                          new e2Data("IsResize", rbtn_IsResize.SelectedValue),
                                          new e2Data("Resize_Type", droplist_ResizeType.SelectedValue),
                                          new e2Data("Resize_Height", RadNumericTbx_ResizeHeight.Text),
                                          new e2Data("Resize_Width", RadNumericTbx_ResizeWidth.Text),
                                          new e2Data("IsOverlay", rbtn_IsOverlay.SelectedValue),
                                          new e2Data("Overlay_ImageURL", tbx_Overlay_ImageURL.Text),
                                          new e2Data("Overlay_Opacity", RadNumericTbx_Overlay_Opacity.Text),
                                          new e2Data("Overlay_Position", droplist_Overlay_Position.SelectedValue),
                                          new e2Data("Overlay_PaddingX", RadNumericTbx_Overlay_PaddingX.Text),
                                          new e2Data("Overlay_PaddingY", RadNumericTbx_Overlay_PaddingY.Text)
                                      };

                myPhotoMgr.Edit_Photo_Setting(UpdateData);

                _isedit = false;
                MultiView_PhotoSetting.SetActiveView(View_List);

                Control_Init();

            }
        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            _isedit = false;
            MultiView_PhotoSetting.SetActiveView(View_List);
        }

        protected void lbtn_AddNew_Click(object sender, EventArgs e)
        {
            btn_Add.Visible = true;
            btn_Update.Visible = false;

            _isedit = true;
            _isnew = true;

            Reset_Form();

            tbx_DisplayID.Enabled = true;

            MultiView_PhotoSetting.SetActiveView(View_Edit);
        }

        protected void lbtn_Edit_Command(object sender, CommandEventArgs e)
        {
            btn_Add.Visible = false;
            btn_Update.Visible = true;

            _isedit = true;
            _isnew = false;

            Reset_Form();

            // Load Data
            Lib.PhotoMgr myPhotoMgr = new Lib.PhotoMgr();
            Lib.Photo_Setting myPhoto_Setting = myPhotoMgr.Get_Photo_Setting_byID(e.CommandArgument.ToString());

            if (e.CommandArgument.ToString() == "1")
            {
                tbx_DisplayID.Enabled = false;
            }
            else
            {
                tbx_DisplayID.Enabled = true;
            }

            btn_Update.CommandArgument = myPhoto_Setting.SettingID;
            HiddenField_DisplayID.Value = myPhoto_Setting.DisplayID;
            tbx_DisplayID.Text = myPhoto_Setting.DisplayID;
            tbx_Image_BrokenURL.Text = myPhoto_Setting.Image_BrokenURL;

            rbtn_IsResize.SelectedValue = myPhoto_Setting.IsResize.ToString();

            if (myPhoto_Setting.IsResize)
            {
                Panel_IsResize.Visible = true;
                droplist_ResizeType.SelectedValue = StringEnum.GetStringValue(myPhoto_Setting.Resize_Type);
                RadNumericTbx_ResizeHeight.Value = myPhoto_Setting.Resize_Height;
                RadNumericTbx_ResizeWidth.Value = myPhoto_Setting.Resize_Width;
            }

            rbtn_IsOverlay.SelectedValue = myPhoto_Setting.IsOverlay.ToString();

            if (myPhoto_Setting.IsOverlay)
            {
                Panel_IsOverlay.Visible = true;
                tbx_Overlay_ImageURL.Text = myPhoto_Setting.Overlay_ImageURL;
                RadNumericTbx_Overlay_Opacity.Value = myPhoto_Setting.Overlay_Opacity;
                droplist_Overlay_Position.SelectedValue = StringEnum.GetStringValue(myPhoto_Setting.Overlay_Position);
                RadNumericTbx_Overlay_PaddingX.Value = myPhoto_Setting.Overlay_PaddingX;
                RadNumericTbx_Overlay_PaddingY.Value = myPhoto_Setting.Overlay_PaddingY;
            }

            MultiView_PhotoSetting.SetActiveView(View_Edit);
        }

        protected void lbtn_Delete_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandArgument.ToString() == "1")
            {
                Nexus.Core.Tools.AlertMessage.Show_Alert(
                    this.Page,
                    "<h4>Default photo setting cannot be deleted.</h4>", "Warning!");

            }
            else
            {
                Lib.PhotoMgr myPhotoMgr = new Lib.PhotoMgr();
                myPhotoMgr.Remove_Photo_Setting(e.CommandArgument.ToString());

                Control_Init();
            }
        }

        protected void rbtn_IsResize_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel_IsResize.Visible = Convert.ToBoolean(rbtn_IsResize.SelectedValue);
        }
        protected void rbtn_IsOverlay_SelectedIndexChanged(object sender, EventArgs e)
        {
            Panel_IsOverlay.Visible = Convert.ToBoolean(rbtn_IsOverlay.SelectedValue);
        }

        protected void CustomValidator_DisplayID_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Lib.PhotoMgr myPhotoMgr = new Lib.PhotoMgr();

            if (_isnew)
            {
                // Add New
                if (myPhotoMgr.Chk_Photo_Setting(tbx_DisplayID.Text))
                {
                    args.IsValid = false;
                }
                else
                {
                    args.IsValid = true;
                }
            }
            else
            {
                // Edit
                if (HiddenField_DisplayID.Value == tbx_DisplayID.Text)
                {
                    args.IsValid = true;
                }
                else
                {
                    if (myPhotoMgr.Chk_Photo_Setting(tbx_DisplayID.Text))
                    {
                        args.IsValid = false;
                    }
                    else
                    {
                        args.IsValid = true;
                    }
                }
            }
        }
    }
}