using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Nexus.Core;
using Nexus.Core.Categories;

namespace Nexus.Controls.Gallery.ControlPanel
{

    public partial class EditItem : System.Web.UI.UserControl
    {

        private string _itemid;
        //private string _source_categoryid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    _itemid = ViewState["PhotoID"].ToString();
                    //_source_categoryid = ViewState["Source_CategoryID"].ToString();
                }
                catch
                {
                    // nothing to do
                }
            }
            else
            {
                Init_Form();
                Reset_Form();
                Control_Init();
            }

        }

        private void Control_Init()
        {
            if (!DataEval.IsEmptyQuery(Request["NexusPhotoID"]))
            {
                Lib.PhotoMgr myPhotoMgr = new Lib.PhotoMgr();
                Lib.Photo myPhoto = myPhotoMgr.Get_Photo(Request["NexusPhotoID"]);

                tbx_Photo_Title.Text = myPhoto.Photo_Title;
                TextEditor_Description.Content = myPhoto.Description;
                droplist_ImageType.SelectedValue = StringEnum.GetStringValue(myPhoto.ImageURL_Type);
                tbx_ImageURL.Text = myPhoto.ImageURL;
                tbx_AlternateText.Text = myPhoto.AlternateText;
                rbtn_IsActive.SelectedValue = myPhoto.IsActive.ToString();

                _itemid = myPhoto.PhotoID;
                ViewState["PhotoID"] = _itemid;

            }
            else
            {
                btn_Update.Enabled = false;
            }
        }

        private void Init_Form()
        {

            #region Bind ImageURL Types

            //Gets your enum names and adds it to a string array
            Array enumNames = Enum.GetValues(typeof(Lib.ImageURL_Type));

            //Creates an ArrayList
            ArrayList myImageURL_Types = new ArrayList();

            //Loop through your string array and poppulates the ArrayList
            foreach (Lib.ImageURL_Type myImageURL_Type in enumNames)
            {
                myImageURL_Types.Add(new { Value = StringEnum.GetStringValue(myImageURL_Type), Name = StringEnum.GetStringValue(myImageURL_Type) });
            }


            //Bind the ArrayList to your DropDownList
            droplist_ImageType.DataSource = myImageURL_Types;
            droplist_ImageType.DataTextField = "Name";
            droplist_ImageType.DataValueField = "Value";
            droplist_ImageType.DataBind();

            #endregion

        }

        private void Reset_Form()
        {
            // Default Setting
            tbx_Photo_Title.Text = "";
            TextEditor_Description.Content = "";
            droplist_ImageType.SelectedIndex = 0;
            tbx_ImageURL.Text = "";
            tbx_AlternateText.Text = "";
            rbtn_IsActive.SelectedIndex = 0;

        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Lib.PhotoMgr myPhotoMgr = new Lib.PhotoMgr();

                e2Data[] UpdateData = {
                                              new e2Data("PhotoID", _itemid),
                                              new e2Data("Photo_Title", tbx_Photo_Title.Text),
                                              new e2Data("Description", TextEditor_Description.Content),
                                              new e2Data("ImageURL", tbx_ImageURL.Text),
                                              new e2Data("ImageURL_Type", droplist_ImageType.SelectedValue),
                                              new e2Data("AlternateText", tbx_AlternateText.Text),
                                              new e2Data("IsActive", rbtn_IsActive.SelectedValue),
                                              new e2Data("LastUpdate_Date", DateTime.Now.ToString()),
                                              new e2Data("LastUpdate_UserID", Security.Users.UserStatus.Current_UserID(this.Page))
                                          };

                myPhotoMgr.Edit_Photo(UpdateData);

                // Finish Update Close Window
                string _finishupdate_script = string.Format("CloseAndRebind({0});", DataEval.QuoteText("Module_ControlPanel"));
                ScriptManager.RegisterStartupScript(this.Page, typeof(Page), "myScript", _finishupdate_script, true);

            }
        }

    }
}