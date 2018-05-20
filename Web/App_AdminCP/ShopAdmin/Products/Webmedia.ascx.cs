using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Nexus.Core;
using Nexus.Core.Categories;
using Nexus.Shop.Product;
using Nexus.Shop.Product.Variant;

namespace Nexus.Shop
{

    public partial class App_AdminCP_ShopAdmin_Products_Webmedia : System.Web.UI.UserControl
    {
        #region properties

        private string _productid;

        [Bindable(true)]
        [Category("Data")]
        [DefaultValue("")]
        [Localizable(true)]
        public string ProductID
        {
            get
            {
                if (_productid == null)
                {
                    return "";
                }
                return _productid;
            }
            set
            {
                _productid = value;
                ViewState["ProductID"] = _productid;
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

                try
                {

                    _productid = ViewState["ProductID"].ToString();

                }
                catch
                {
                    // Do nothing
                }

            }
            else
            {
                Control_FillData();
                Control_Init();
            }

        }

        public void Control_FillData()
        {

            ProductSearchMgr myProductSearchMgr = new ProductSearchMgr();

            Product_Search myProduct_Search = myProductSearchMgr.Get_Product_Search(_productid);

            Img_Default_Photo.ImageUrl = myProduct_Search.Default_PhotoURL;

            #region Media Type

            //Gets your enum names and adds it to a string array
            Array enumNames = Enum.GetValues(typeof(Media_Type));

            //Creates an ArrayList
            ArrayList myVariantTypes = new ArrayList();

            //Loop through your string array and poppulates the ArrayList
            foreach (Media_Type myVariant_Type in enumNames)
            {
                myVariantTypes.Add(new
                {
                    Value = StringEnum.GetStringValue(myVariant_Type),
                    Name = myVariant_Type.ToString()
                });
            }

            //Bind the ArrayList to your DropDownList   
            droplist_Media_Type.Items.Clear();

            droplist_Media_Type.DataSource = myVariantTypes;
            droplist_Media_Type.DataTextField = "Name";
            droplist_Media_Type.DataValueField = "Value";
            droplist_Media_Type.DataBind();

            // Set Default value
            droplist_Media_Type.SelectedIndex = 0;

            #endregion

            tbx_Media_Title.Text = "";
            tbx_ImageURL.Text = "";
            tbx_Description.Text = "";

        }

        private void Control_Init()
        {
            RadGrid_WebMedia.Rebind();

            MultiView_WebMediaForm.SetActiveView(View_Button);
        }

        #region Create & Update Form

        protected void btn_Show_AddForm_Click(object sender, EventArgs e)
        {
            // Reset Form
            Control_FillData();

            // Reset Buttons
            btn_Add_WebMedia.Visible = true;
            btn_Update_WebMedia.Visible = false;
            btn_Cancel.Visible = true;

            MultiView_WebMediaForm.SetActiveView(View_Form);
        }

        protected void btn_Add_WebMedia_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                ProductMgr myProductMgr = new ProductMgr();

                string WebMediaID = Nexus.Core.Tools.IDGenerator.Get_New_GUID_PlainText();

                e2Data[] UpdateData = {
                                          new e2Data("WebMediaID", WebMediaID),
                                          new e2Data("ProductID", _productid),
                                          new e2Data("Media_Type", droplist_Media_Type.SelectedValue),
                                          new e2Data("Media_Title", tbx_Media_Title.Text),
                                          new e2Data("Media_Value", tbx_ImageURL.Text),
                                          new e2Data("Media_Description", tbx_Description.Text),
                                          new e2Data("SortOrder", "0")
                                      };

                myProductMgr.Add_WebMedia(UpdateData);

                Control_Init();

                MultiView_WebMediaForm.SetActiveView(View_Button);

            }
        }

        protected void btn_Update_WebMedia_Command(object sender, CommandEventArgs e)
        {
            if (Page.IsValid && !DataEval.IsEmptyQuery(e.CommandArgument.ToString()))
            {
                ProductMgr myProductMgr = new ProductMgr();

                e2Data[] UpdateData = {
                                          new e2Data("WebMediaID", e.CommandArgument.ToString()),
                                          new e2Data("Media_Type", droplist_Media_Type.SelectedValue),
                                          new e2Data("Media_Title", tbx_Media_Title.Text),
                                          new e2Data("Media_Value", tbx_ImageURL.Text),
                                          new e2Data("Media_Description", tbx_Description.Text)
                                      };

                myProductMgr.Edit_WebMedia(UpdateData);

                Control_Init();

                MultiView_WebMediaForm.SetActiveView(View_Button);

            }

        }

        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            MultiView_WebMediaForm.SetActiveView(View_Button);
        }

        #endregion

        #region RadGrid Actions

        protected void RadGrid_WebMedia_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            ProductMgr myProductMgr = new ProductMgr();

            RadGrid_WebMedia.DataSource = myProductMgr.Get_WebMedia(_productid);

        }

        protected void RadGrid_WebMedia_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem myItem = (GridDataItem)e.Item;
                string myItemID = myItem.GetDataKeyValue("WebMediaID").ToString();

                LinkButton myDeleteLink = (LinkButton)myItem["TemplateColumn_Actions"].FindControl("lbtn_Delete_Media");
                myDeleteLink.OnClientClick = string.Format("return confirm('Are you sure you want to delete \"{0}\" ?');", DataBinder.Eval(myItem.DataItem, "Media_Title"));


            }
        }

        protected void RadGrid_WebMedia_RowDrop(object sender, GridDragDropEventArgs e)
        {
            if (e.DestDataItem != null
                && string.IsNullOrEmpty(e.HtmlElement)
                && e.DestDataItem.OwnerGridID == RadGrid_WebMedia.ClientID)
            {
                ProductMgr myProductMgr = new ProductMgr();

                List<WebMedia> myWebMedia = myProductMgr.Get_WebMedia(_productid);

                WebMedia draggedAttributeIndex = Get_WebMedia_in_List(myWebMedia, e.DraggedItems[0].GetDataKeyValue("WebMediaID").ToString());
                WebMedia destAttributeIndex = Get_WebMedia_in_List(myWebMedia, e.DestDataItem.GetDataKeyValue("WebMediaID").ToString());

                int destIndex = myWebMedia.IndexOf(destAttributeIndex);

                if (e.DropPosition == GridItemDropPosition.Above && e.DestDataItem.ItemIndex > e.DraggedItems[0].ItemIndex)
                {
                    destIndex -= 1;
                }
                if (e.DropPosition == GridItemDropPosition.Below && e.DestDataItem.ItemIndex < e.DraggedItems[0].ItemIndex)
                {
                    destIndex += 1;
                }

                myWebMedia.Remove(draggedAttributeIndex);
                myWebMedia.Insert(destIndex, draggedAttributeIndex);

                foreach (WebMedia WebMedium in myWebMedia)
                {
                    // Product Variant
                    e2Data[] UpdateData = {
                                                      new e2Data("WebMediaID", WebMedium.WebMediaID),
                                                      new e2Data("SortOrder", (myWebMedia.IndexOf(Get_WebMedia_in_List(myWebMedia, WebMedium.WebMediaID)) + 1).ToString())
                                                  };

                    myProductMgr.Edit_WebMedia(UpdateData);

                }

                RadGrid_WebMedia.Rebind();

            }

        }

        private static WebMedia Get_WebMedia_in_List(IEnumerable<WebMedia> list, string webmediaid)
        {
            foreach (WebMedia myWebMedia in list)
            {
                if (myWebMedia.WebMediaID == webmediaid)
                {
                    return myWebMedia;
                }
            }

            return null;
        }

        protected void lbtn_Edit_Media_Command(object sender, CommandEventArgs e)
        {
            if (!DataEval.IsEmptyQuery(e.CommandArgument.ToString()))
            {

                ProductMgr myProductMgr = new ProductMgr();

                WebMedia myWebMedia = myProductMgr.Get_WebMedium(e.CommandArgument.ToString());

                droplist_Media_Type.SelectedValue = StringEnum.GetStringValue(myWebMedia.Media_Type);
                tbx_Media_Title.Text = myWebMedia.Media_Title;
                tbx_ImageURL.Text = myWebMedia.Media_Value;
                tbx_Description.Text = myWebMedia.Media_Description;

                btn_Add_WebMedia.Visible = false;
                btn_Update_WebMedia.Visible = true;
                btn_Update_WebMedia.CommandArgument = myWebMedia.WebMediaID;
                btn_Cancel.Visible = true;

                MultiView_WebMediaForm.SetActiveView(View_Form);

            }
        }

        protected void lbtn_SetDefault_Media_Command(object sender, CommandEventArgs e)
        {
            if (!DataEval.IsEmptyQuery(e.CommandArgument.ToString()))
            {
                ProductMgr myProductMgr = new ProductMgr();

                WebMedia myWebMedia = myProductMgr.Get_WebMedium(e.CommandArgument.ToString());

                if (myWebMedia.Media_Type == Media_Type.Picture)
                {

                    e2Data[] UpdateData = {
                                              new e2Data("ProductID", _productid),
                                              new e2Data("WebMediaID", e.CommandArgument.ToString())
                                          };

                    myProductMgr.Edit_Product(UpdateData);

                    Img_Default_Photo.ImageUrl = myWebMedia.Media_Value;
                }
                else
                {
                    Nexus.Core.Tools.AlertMessage.Show_Alert(this.Page, "<h4>You can only set a picture type as product default photo. </h4>", "Action failed!");
                }

            }
        }

        protected void lbtn_Delete_Media_Command(object sender, CommandEventArgs e)
        {
            if (!DataEval.IsEmptyQuery(e.CommandArgument.ToString()))
            {

                ProductMgr myProductMgr = new ProductMgr();

                Product.Product myProduct = myProductMgr.Get_Product(_productid);

                if (e.CommandArgument.ToString() == myProduct.WebMediaID)
                {
                    e2Data[] UpdateData = {
                                          new e2Data("ProductID", _productid),
                                          new e2Data("WebMediaID", "")
                                      };

                    myProductMgr.Edit_Product(UpdateData);

                    Img_Default_Photo.ImageUrl = "/App_Control_Style/Nexus_Shop/Images/NoImg.png";

                }

                myProductMgr.Remove_WebMedia(e.CommandArgument.ToString());
                Control_Init();
            }
        }

        #endregion


    }
}