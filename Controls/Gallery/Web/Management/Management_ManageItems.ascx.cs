using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Nexus.Core;
using Nexus.Core.Categories;
using Nexus.Controls.Gallery.Lib;
using Telerik.Web.UI;

namespace Nexus.Controls.Gallery.Management
{

    public partial class ManageItems : System.Web.UI.UserControl
    {

        private string _category_selected;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                try
                {
                    _category_selected = ViewState["Category_Selected"].ToString();
                }
                catch
                {
                    // do nothing;
                }

                RadTabStrip_Commands.Visible = true;
            }
            else
            {
                Control_PreInit();
                Control_Init();
            }

        }

        private void Control_PreInit()
        {

            RadTabStrip_Commands.Visible = false;

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

        private void Control_Init()
        {
            ItemList_DataBind();
            CategoryTree_Menu.LoadCategoryRoot();
            CategoryTree_MoveTo.LoadCategoryRoot();
            CategoryTree_CopyTo.LoadCategoryRoot();

        }

        protected void CategoryTree_Menu_CategorySelected(object sender, RadTreeNodeEventArgs e)
        {
            if (CategoryTree_Menu.Selected_CategoryID != "-1")
            {
                _category_selected = CategoryTree_Menu.Selected_CategoryID;
                ViewState["Category_Selected"] = _category_selected;

                ItemList_DataBind();

                foreach (RadTab myRadTab in RadTabStrip_Commands.Tabs)
                {
                    myRadTab.Selected = false;
                }

                foreach (RadPageView myPageView in RadMultiPage_Actions.PageViews)
                {
                    myPageView.Selected = false;
                }
            }
        }

        #region Gallery Photo List

        protected void ListView_ItemList_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            HiddenField myItemID = (HiddenField)e.Item.FindControl("Hidden_ItemID");
            HyperLink myEditLink = (HyperLink)e.Item.FindControl("hlink_Edit");

            myEditLink.Attributes["href"] = "#";
            myEditLink.Attributes["onclick"] = string.Format("return Show_ControlManager('/App_AdminCP/SiteAdmin/PoP_ControlPanel.aspx?ControlID={0}&NexusPhotoID={1}');", "43D902AF-A0DC-4036-BC46-C98EC84B6698", myItemID.Value);
        }

        protected void ListView_ItemList_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager_ItemList.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            ItemList_DataBind();
        }

        private void ItemList_DataBind()
        {
            if (!DataEval.IsEmptyQuery(_category_selected))
            {
                RadTabStrip_Commands.Visible = true;

                PhotoMgr myPhotoMgr = new PhotoMgr();
                ListView_ItemList.DataSource = myPhotoMgr.Get_Photos(DataEval.QuoteText(_category_selected), "Photo_Title", "ASC");
                ListView_ItemList.DataKeyNames = new string[] { "PhotoID" };
                ListView_ItemList.DataBind();

                CheckBox chk_SelectAll = (CheckBox)ListView_ItemList.FindControl("chk_SelectAll");
                if (chk_SelectAll != null)
                    chk_SelectAll.Checked = false;
            }
        }

        protected void Chk_SelectAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk_SelectAll = (CheckBox)sender;

            for (int i = 0; i < ListView_ItemList.Items.Count; i++)
            {
                CheckBox chk_Selected = (CheckBox)ListView_ItemList.Items[i].FindControl("chk_Selected");
                chk_Selected.Checked = chk_SelectAll.Checked;
            }
        }

        protected void lbtn_Delete_Command(object sender, CommandEventArgs e)
        {
            string Item_MapID = e.CommandArgument.ToString();

            if (!DataEval.IsEmptyQuery(Item_MapID))
            {
                PhotoMgr myPhotoMgr = new PhotoMgr();

                // Delete item from Category
                Photo_Item_Map myPhoto_Item_Map = myPhotoMgr.Get_Photo_Map(Item_MapID);
                myPhotoMgr.Remove_Photo_Mapping(Item_MapID);

                CategoryMgr myCategoryMgr = new CategoryMgr();
                myCategoryMgr.Delete_ComponentInCategory_Item(myPhoto_Item_Map.CategoryID, "9473F482-CC30-4963-946A-28CA4AD44041");

                // Delete photo if this is last one
                if (myPhotoMgr.Count_Photo_Item_Mapping(myPhoto_Item_Map.PhotoID) < 1)
                {
                    myPhotoMgr.Remove_Photo(myPhoto_Item_Map.PhotoID);
                }

                Control_Init();
            }
        }

        #endregion

        #region Add Photo(s)

        // Add Single Photo
        protected void btn_AddSingle_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                PhotoMgr myPhotoMgr = new PhotoMgr();

                string PhotoID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();

                string phototitle;
                if (droplist_ImageType.SelectedValue == StringEnum.GetStringValue(Lib.ImageURL_Type.Internal))
                {
                    phototitle = Get_FileName(tbx_ImageURL.Text, true);
                }
                else
                {
                    phototitle = Get_FileName(tbx_ImageURL.Text, false);
                }

                // If photo exist, Create new record. 
                if (!DataEval.IsEmptyQuery(phototitle))
                {
                    DateTime nowTime = DateTime.Now;

                    e2Data[] UpdateData = {
                                              new e2Data("PhotoID", PhotoID),
                                              new e2Data("Photo_Title", phototitle),
                                              new e2Data("ImageURL", tbx_ImageURL.Text),
                                              new e2Data("ImageURL_Type", droplist_ImageType.SelectedValue),
                                              new e2Data("AlternateText", phototitle),
                                              new e2Data("View_Count", "0"),
                                              new e2Data("IsActive", true.ToString()),
                                              new e2Data("Create_Date", nowTime.ToString()),
                                              new e2Data("LastUpdate_Date", nowTime.ToString()),
                                              new e2Data("LastUpdate_UserID", Security.Users.UserStatus.Current_UserID(this.Page))
                                          };

                    myPhotoMgr.Add_Photo(UpdateData);

                    // Create Item Mapping
                    e2Data[] UpdateData_Mapping = {
                                                      new e2Data("PhotoID", PhotoID),
                                                      new e2Data("CategoryID", _category_selected),
                                                      new e2Data("SortOrder", "1")
                                                   };

                    myPhotoMgr.Add_Photo_Item_Mapping(UpdateData_Mapping);

                    // Add Item to Category
                    CategoryMgr myCategoryMgr = new CategoryMgr();
                    myCategoryMgr.Add_ComponentInCategory_Item(
                        _category_selected,
                        "9473F482-CC30-4963-946A-28CA4AD44041");

                }

                Control_Init();
            }
        }

        // Add Multi Photos
        protected void btn_RefreshFolder_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ImageFolder_DataBind();
            }
        }

        protected void btn_AddMulti_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {
                for (int i = 0; i < ListView_ImageFolder.Items.Count; i++)
                {
                    CheckBox chk_Selected = (CheckBox)ListView_ImageFolder.Items[i].FindControl("chk_Selected");
                    if (chk_Selected.Checked)
                    {
                        HiddenField hidden_PhotoTitle = (HiddenField)ListView_ImageFolder.Items[i].FindControl("Hidden_PhotoTitle");
                        HiddenField hidden_IamgeURL = (HiddenField)ListView_ImageFolder.Items[i].FindControl("Hidden_ImageURL");

                        PhotoMgr myPhotoMgr = new PhotoMgr();

                        string PhotoID = Nexus.Core.Tools.IDGenerator.Get_New_GUID();
                        DateTime nowTime = DateTime.Now;

                        e2Data[] UpdateData = {
                                                  new e2Data("PhotoID", PhotoID),
                                                  new e2Data("Photo_Title", hidden_PhotoTitle.Value),
                                                  new e2Data("ImageURL", hidden_IamgeURL.Value),
                                                  new e2Data("ImageURL_Type", StringEnum.GetStringValue(Lib.ImageURL_Type.Internal)),
                                                  new e2Data("AlternateText", hidden_PhotoTitle.Value),
                                                  new e2Data("View_Count", "0"),
                                                  new e2Data("IsActive", true.ToString()),
                                                  new e2Data("Create_Date", nowTime.ToString()),
                                                  new e2Data("LastUpdate_Date", nowTime.ToString()),
                                                  new e2Data("LastUpdate_UserID", Security.Users.UserStatus.Current_UserID(this.Page))
                                              };

                        myPhotoMgr.Add_Photo(UpdateData);

                        // Create Item Mapping
                        e2Data[] UpdateData_Mapping = {
                                                      new e2Data("PhotoID", PhotoID),
                                                      new e2Data("CategoryID", _category_selected),
                                                      new e2Data("SortOrder", "1")
                                                   };

                        myPhotoMgr.Add_Photo_Item_Mapping(UpdateData_Mapping);

                        // Add Item to Category
                        CategoryMgr myCategoryMgr = new CategoryMgr();
                        myCategoryMgr.Add_ComponentInCategory_Item(
                            _category_selected,
                            "9473F482-CC30-4963-946A-28CA4AD44041");

                    }
                }

                Control_Init();
            }
        }

        protected void ListView_ImageFolder_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager_ImageFolder.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            ImageFolder_DataBind();
        }

        protected void Chk_SelectAll_Folder_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk_SelectAll = (CheckBox)sender;

            for (int i = 0; i < ListView_ImageFolder.Items.Count; i++)
            {
                CheckBox chk_Selected = (CheckBox)ListView_ImageFolder.Items[i].FindControl("chk_Selected");
                chk_Selected.Checked = chk_SelectAll.Checked;
            }
        }


        private void ImageFolder_DataBind()
        {
            if (!DataEval.IsEmptyQuery(_category_selected))
            {
                ListView_ImageFolder.Visible = false;

                PhotoMgr myPhotoMgr = new PhotoMgr();

                List<Photo> myPhotos = new List<Photo>();

                // Get Image Files
                if (!DataEval.IsEmptyQuery(tbx_FolderURL.Text))
                {

                    ListView_ImageFolder.Visible = true;

                    string[] KnownExtensions = Nexus.Core.Phrases.PhraseMgr.Get_Phrase_Value("NexusCore_File_Image_Types").Split(',');

                    string physicalPath = Server.MapPath(tbx_FolderURL.Text);

                    string[] files = Directory.GetFiles(physicalPath);

                    foreach (string file in files)
                    {
                        string extension = "*" + Path.GetExtension(file).ToLower();

                        if (Array.IndexOf(KnownExtensions, extension) > -1)
                        {
                            Photo myPhoto = new Photo();
                            myPhoto.Photo_Title = Path.GetFileNameWithoutExtension(file);
                            myPhoto.ImageURL = tbx_FolderURL.Text + "/" + Path.GetFileName(file);

                            myPhotos.Add(myPhoto);

                        }

                    }
                }

                ListView_ImageFolder.DataSource = myPhotos;
                ListView_ImageFolder.DataBind();

                CheckBox chk_SelectAll = (CheckBox)ListView_ImageFolder.FindControl("chk_SelectAll");
                if (chk_SelectAll != null)
                    chk_SelectAll.Checked = false;
            }
        }

        // Common Function
        private string Get_FileName(string URL, bool isLocal)
        {

            if (isLocal)
            {
                if (File.Exists(Server.MapPath(URL)))
                {
                    return Path.GetFileNameWithoutExtension(URL);
                }
                else
                {
                    return null;
                }

            }
            else
            {
                string[] fields = tbx_ImageURL.Text.Split('/');
                string[] filename = fields[fields.Length - 1].Split('.');

                return filename[0];
            }

        }

        #endregion

        #region Move Photo

        protected void CustomValidator_Category_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (DataEval.IsEmptyQuery(CategoryTree_MoveTo.Selected_CategoryID))
                args.IsValid = false;
        }

        protected void btn_Move_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                for (int i = 0; i < ListView_ItemList.Items.Count; i++)
                {
                    CheckBox chk_Selected = (CheckBox)ListView_ItemList.Items[i].FindControl("chk_Selected");
                    if (chk_Selected.Checked)
                    {
                        HiddenField hidden_ItemID = (HiddenField)ListView_ItemList.Items[i].FindControl("Hidden_ItemID");
                        HiddenField hidden_Item_MapID = (HiddenField)ListView_ItemList.Items[i].FindControl("Hidden_Item_MapID");

                        PhotoMgr myPhotoMgr = new PhotoMgr();

                        Photo_Item_Map myPhoto_Item_Map = myPhotoMgr.Get_Photo_Map(hidden_Item_MapID.Value);

                        if (myPhoto_Item_Map.CategoryID != CategoryTree_MoveTo.Selected_CategoryID)
                        {

                            if (myPhotoMgr.Chk_Photo_Item_Mapping(hidden_ItemID.Value, CategoryTree_MoveTo.Selected_CategoryID))
                            {
                                myPhotoMgr.Remove_Photo_Mapping(hidden_Item_MapID.Value);

                                // Delete item from Category
                                CategoryMgr myCategoryMgr = new CategoryMgr();
                                myCategoryMgr.Delete_ComponentInCategory_Item(myPhoto_Item_Map.CategoryID, "9473F482-CC30-4963-946A-28CA4AD44041");

                            }
                            else
                            {
                                e2Data[] UpdateData = {
                                                          new e2Data("Item_MapID", myPhoto_Item_Map.Item_MapID),
                                                          new e2Data("CategoryID", CategoryTree_MoveTo.Selected_CategoryID)
                                                      };

                                myPhotoMgr.Edit_Photo_Item_Mapping(UpdateData);

                                // Switch Category
                                CategoryMgr myCategoryMgr = new CategoryMgr();
                                myCategoryMgr.Move_ComponentInCategory_Item(myPhoto_Item_Map.CategoryID, CategoryTree_MoveTo.Selected_CategoryID, "9473F482-CC30-4963-946A-28CA4AD44041");
                            }
                        }

                    }
                }

                Control_Init();
            }
        }

        #endregion

        #region Copy Photo

        protected void CustomValidator_Category_Copy_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (DataEval.IsEmptyQuery(CategoryTree_CopyTo.Selected_CategoryID))
                args.IsValid = false;
        }

        protected void btn_Copy_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                for (int i = 0; i < ListView_ItemList.Items.Count; i++)
                {
                    CheckBox chk_Selected = (CheckBox)ListView_ItemList.Items[i].FindControl("chk_Selected");
                    if (chk_Selected.Checked)
                    {
                        HiddenField hidden_ItemID = (HiddenField)ListView_ItemList.Items[i].FindControl("Hidden_ItemID");
                        HiddenField hidden_Item_MapID = (HiddenField)ListView_ItemList.Items[i].FindControl("Hidden_Item_MapID");

                        PhotoMgr myPhotoMgr = new PhotoMgr();
                        Photo_Item_Map myPhoto_Item_Map = myPhotoMgr.Get_Photo_Map(hidden_Item_MapID.Value);

                        if (myPhoto_Item_Map.CategoryID != CategoryTree_CopyTo.Selected_CategoryID)
                        {

                            e2Data[] UpdateData = {
                                                          new e2Data("PhotoID", myPhoto_Item_Map.PhotoID),
                                                          new e2Data("CategoryID", CategoryTree_CopyTo.Selected_CategoryID),
                                                          new e2Data("SortOrder", "1")
                                                      };

                            myPhotoMgr.Add_Photo_Item_Mapping(UpdateData);

                            // Switch Category
                            CategoryMgr myCategoryMgr = new CategoryMgr();
                            myCategoryMgr.Add_ComponentInCategory_Item(CategoryTree_CopyTo.Selected_CategoryID, "9473F482-CC30-4963-946A-28CA4AD44041");
                        }

                    }
                }

                Control_Init();
            }
        }

        #endregion

        #region Active Photo Status

        protected void btn_IsActive_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                for (int i = 0; i < ListView_ItemList.Items.Count; i++)
                {
                    CheckBox chk_Selected = (CheckBox)ListView_ItemList.Items[i].FindControl("chk_Selected");
                    if (chk_Selected.Checked)
                    {
                        HiddenField hidden_ItemID = (HiddenField)ListView_ItemList.Items[i].FindControl("Hidden_ItemID");

                        PhotoMgr myEbayMgr = new PhotoMgr();
                        Photo myPhoto = myEbayMgr.Get_Photo(hidden_ItemID.Value);

                        e2Data[] UpdateData = {
                                                      new e2Data("PhotoID", myPhoto.PhotoID),
                                                      new e2Data("IsActive", rbtn_IsActive.SelectedValue)
                                                   };

                        myEbayMgr.Edit_Photo(UpdateData);

                    }
                }

                Control_Init();
            }
        }

        #endregion

    }
}