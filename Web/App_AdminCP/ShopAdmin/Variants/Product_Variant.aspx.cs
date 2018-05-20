using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Telerik.Web.UI;
using Nexus.Core;
using Nexus.Shop.Product;
using Nexus.Shop.Product.Variant;

namespace Nexus.Shop
{

    public partial class App_AdminCP_ShopAdmin_Variants_Product_Variant : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Control_FillData();
                Control_Init();
            }

        }

        #region Control Window Event

        protected void RadAjaxManager_AjaxRequest(object sender, Telerik.Web.UI.AjaxRequestEventArgs e)
        {
            Control_Init();
        }

        #endregion

        private void Control_FillData()
        {

            string Product_VariantID = Request["Product_VariantID"];
            bool variantFound = false;

            if (!DataEval.IsEmptyQuery(Product_VariantID))
            {
                ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();

                if (myProductVariantMgr.Chk_Product_Variant(Product_VariantID))
                {
                    Variant myVariant = myProductVariantMgr.Get_Product_Variant(Product_VariantID);

                    lbl_Variant_Name.Text = myVariant.Variant_Name;
                    tbx_Variant_Name.Text = myVariant.Variant_Name;
                    lbl_Variant_Type.Text = StringEnum.GetStringValue(myVariant.Variant_Type);
                    tbx_Table_Name.Text = myVariant.Table_Name;

                    // Spliter
                    tbx_Spliter_Name.Text = "";

                    variantFound = true;
                }
            }

            if (!variantFound)
            {
                Response.Redirect("Default.aspx");
            }

        }

        private void Control_Init()
        {
            RadGrid_VariantSpliter.Rebind();
        }

        protected void btn_UpdateVariant_Click(object sender, EventArgs e)
        {

            string Product_VariantID = Request["Product_VariantID"];

            if (Page.IsValid && !DataEval.IsEmptyQuery(Product_VariantID))
            {

                ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();


                // Product Variant
                e2Data[] UpdateData = {
                                          new e2Data("Product_VariantID", Product_VariantID),
                                          new e2Data("Variant_Name", tbx_Variant_Name.Text),
                                          new e2Data("Table_Name", tbx_Table_Name.Text)
                                      };

                myProductVariantMgr.Edit_Product_Variant(UpdateData);

                Control_FillData();

            }
        }

        protected void btn_CreateSpliter_Click(object sender, EventArgs e)
        {
            string Product_VariantID = Request["Product_VariantID"];

            if (Page.IsValid && !DataEval.IsEmptyQuery(Product_VariantID))
            {

                string Variant_SpliterID = Nexus.Core.Tools.IDGenerator.Get_New_GUID_PlainText();

                ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();

                // Product Variant
                e2Data[] UpdateData = {
                                          new e2Data("Variant_SpliterID", Variant_SpliterID),
                                          new e2Data("Product_VariantID", Product_VariantID),
                                          new e2Data("Spliter_Name", tbx_Spliter_Name.Text),
                                          new e2Data("SortOrder", (myProductVariantMgr.Count_Variant_Spliter(Product_VariantID) + 1).ToString())
                                      };

                myProductVariantMgr.Add_Product_Variant_Spliter(UpdateData);

                Control_Init();
            }

        }

        #region Spliter Events

        protected void RadGrid_VariantSpliter_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();

            RadGrid_VariantSpliter.DataSource = myProductVariantMgr.Get_Product_Variant_Spliters(Request["Product_VariantID"]);
            //RadGrid_VariantSpliter.DataBind();

        }

        protected void RadGrid_VariantSpliter_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem myItem = (GridDataItem)e.Item;
                string myItemID = myItem.GetDataKeyValue("Variant_SpliterID").ToString();

                HyperLink myAddPropertyLink = (HyperLink)myItem["Variant_SpliterID"].FindControl("hlink_AddProperty");
                myAddPropertyLink.Attributes["href"] = "#";
                myAddPropertyLink.Attributes["onclick"] = string.Format("return Show_ControlManager('PoP_PropertyCreate.aspx?Variant_SpliterID={0}&Action=Create');", myItemID);

                HyperLink myEditLink = (HyperLink)myItem["Variant_SpliterID"].FindControl("hlink_EditSpliter");
                myEditLink.Attributes["href"] = "#";
                myEditLink.Attributes["onclick"] = string.Format("return Show_ControlManager('PoP_SpliterEditor.aspx?Variant_SpliterID={0}');", myItemID);

                LinkButton myDeleteLink = (LinkButton)myItem["Variant_SpliterID"].FindControl("lbtn_DeleteSpliter");
                myDeleteLink.OnClientClick = string.Format("return confirm('Are you sure you want to delete spliter \"{0}\" ?');", DataBinder.Eval(myItem.DataItem, "Spliter_Name"));

            }

            if (e.Item is GridNestedViewItem)
            {
                GridNestedViewItem myNestedItem = (GridNestedViewItem)e.Item;
                string myItemID = myNestedItem.ParentItem.GetDataKeyValue("Variant_SpliterID").ToString();

                RadGrid myRadGrid = (RadGrid)myNestedItem.FindControl("RadGrid_VariantProperties");

                ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();

                List<Variant_Property> myVariant_Properties = myProductVariantMgr.Get_Product_Variant_Properties_BySpliterID(myItemID);

                if (myVariant_Properties.Count < 1)
                {
                    myRadGrid.Visible = false;
                }
                else
                {
                    myRadGrid.DataSource = myVariant_Properties;
                    myRadGrid.DataBind();
                }

            }
        }

        protected void RadGrid_VariantSpliter_RowDrop(object sender, GridDragDropEventArgs e)
        {
            if (string.IsNullOrEmpty(e.HtmlElement) && e.DestDataItem.OwnerGridID == RadGrid_VariantSpliter.ClientID)
            {
                if (e.DraggedItems[0].OwnerGridID == RadGrid_VariantSpliter.ClientID)
                {
                    #region items are Spliter

                    if (e.DestDataItem != null)
                    {
                        ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();

                        Variant_Spliter myVariant_Spliter = myProductVariantMgr.Get_Product_Variant_Spliter(e.DestDataItem.GetDataKeyValue("Variant_SpliterID").ToString());

                        List<Variant_Spliter> myVariant_Spliters = myProductVariantMgr.Get_Product_Variant_Spliters(myVariant_Spliter.Product_VariantID, "SortOrder");

                        Variant_Spliter draggedVariant_Spliter = Get_Variant_Spliter_in_List(myVariant_Spliters, e.DraggedItems[0].GetDataKeyValue("Variant_SpliterID").ToString());
                        Variant_Spliter destVariant_Spliter = Get_Variant_Spliter_in_List(myVariant_Spliters, e.DestDataItem.GetDataKeyValue("Variant_SpliterID").ToString());

                        int destIndex = myVariant_Spliters.IndexOf(destVariant_Spliter);

                        if (e.DropPosition == GridItemDropPosition.Above && e.DestDataItem.ItemIndex > e.DraggedItems[0].ItemIndex)
                        {
                            destIndex -= 1;
                        }
                        if (e.DropPosition == GridItemDropPosition.Below && e.DestDataItem.ItemIndex < e.DraggedItems[0].ItemIndex)
                        {
                            destIndex += 1;
                        }

                        myVariant_Spliters.Remove(draggedVariant_Spliter);
                        myVariant_Spliters.Insert(destIndex, draggedVariant_Spliter);

                        foreach (Variant_Spliter Variant_Spliter in myVariant_Spliters)
                        {
                            // Product Variant
                            e2Data[] UpdateData = {
                                                      new e2Data("Variant_SpliterID", Variant_Spliter.Variant_SpliterID),
                                                      new e2Data("SortOrder", (myVariant_Spliters.IndexOf(Get_Variant_Spliter_in_List(myVariant_Spliters, Variant_Spliter.Variant_SpliterID)) + 1).ToString())
                                                  };

                            myProductVariantMgr.Edit_Product_Variant_Spliter(UpdateData);

                        }
                    }

                    #endregion

                    Control_Init();
                }

            }
        }

        private static Variant_Spliter Get_Variant_Spliter_in_List(IEnumerable<Variant_Spliter> list, string variant_spliterid)
        {
            foreach (Variant_Spliter myVariant_Spliter in list)
            {
                if (myVariant_Spliter.Variant_SpliterID == variant_spliterid)
                {
                    return myVariant_Spliter;
                }
            }

            return null;
        }

        private static Variant_Property Get_Variant_Property_in_List(IEnumerable<Variant_Property> list, string variant_propertyid)
        {
            foreach (Variant_Property myVariant_Property in list)
            {
                if (myVariant_Property.Variant_PropertyID == variant_propertyid)
                {
                    return myVariant_Property;
                }
            }

            return null;
        }

        protected void lbtn_DeleteSpliter_Command(object sender, CommandEventArgs e)
        {
            if (!DataEval.IsEmptyQuery(e.CommandArgument.ToString()))
            {
                ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();

                if (myProductVariantMgr.Chk_Variant_Spliter_usage(e.CommandArgument.ToString()))
                {
                    Nexus.Core.Tools.AlertMessage.Show_Alert(this.Page, "<h4>Selected spliter already have properties <br /> Please delete them before apply this action.</h4>", "Action failed!", 450, 150);

                }
                else
                {

                    myProductVariantMgr.Remove_Product_Variant_Spliter(e.CommandArgument.ToString());

                    Control_Init();
                }
            }
        }

        #endregion

        #region Properties Events

        protected void RadGrid_VariantProperties_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem myItem = (GridDataItem)e.Item;
                string myItemID = myItem.GetDataKeyValue("Variant_PropertyID").ToString();

                HyperLink myEditLink = (HyperLink)myItem["TemplateColumn_Actions"].FindControl("hlink_EditProperty");
                myEditLink.Attributes["href"] = "#";
                myEditLink.Attributes["onclick"] = string.Format("return Show_ControlManager('PoP_PropertyEditor.aspx?Variant_PropertyID={0}');", myItemID);

                LinkButton myDeleteLink = (LinkButton)myItem["TemplateColumn_Actions"].FindControl("lbtn_DeleteProperty");
                myDeleteLink.OnClientClick = string.Format("return confirm('Are you sure you want to delete property \"{0}\" and all its options?');", DataBinder.Eval(myItem.DataItem, "Property_Name"));

            }

        }

        protected void RadGrid_VariantProperties_RowDrop(object sender, GridDragDropEventArgs e)
        {
            if (string.IsNullOrEmpty(e.HtmlElement) && e.DestDataItem != null)
            {
                if (e.DestDataItem.OwnerGridID == RadGrid_VariantSpliter.ClientID)
                {

                    #region Dest drop is on Spliter

                    ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();

                    Variant_Property myVariant_Property = myProductVariantMgr.Get_Product_Variant_Property(e.DraggedItems[0].GetDataKeyValue("Variant_PropertyID").ToString());
                    Variant_Spliter myVariant_Spliter = myProductVariantMgr.Get_Product_Variant_Spliter(e.DestDataItem.GetDataKeyValue("Variant_SpliterID").ToString());

                    if (myVariant_Spliter.Variant_SpliterID != myVariant_Property.Variant_SpliterID)
                    {
                        List<Variant_Property> originVariant_Properties = myProductVariantMgr.Get_Product_Variant_Properties_BySpliterID(myVariant_Property.Variant_SpliterID);
                        List<Variant_Property> destVariant_Properties = myProductVariantMgr.Get_Product_Variant_Properties_BySpliterID(myVariant_Spliter.Variant_SpliterID);

                        Variant_Property draggedVariant_Property = Get_Variant_Property_in_List(originVariant_Properties, myVariant_Property.Variant_PropertyID);


                        originVariant_Properties.Remove(draggedVariant_Property);
                        destVariant_Properties.Add(draggedVariant_Property);

                        // Update Property to new Spliter
                        e2Data[] UpdateData_Property = {
                                                               new e2Data("Variant_PropertyID", draggedVariant_Property.Variant_PropertyID),
                                                               new e2Data("Variant_SpliterID", myVariant_Spliter.Variant_SpliterID)
                                                            };

                        myProductVariantMgr.Edit_Product_Variant_Property(UpdateData_Property);

                        // Sort Old list
                        foreach (Variant_Property Variant_Property in originVariant_Properties)
                        {
                            // Variant Property
                            e2Data[] UpdateData = {
                                                          new e2Data("Variant_PropertyID", Variant_Property.Variant_PropertyID),
                                                          new e2Data("SortOrder", (originVariant_Properties.IndexOf(Get_Variant_Property_in_List(originVariant_Properties, Variant_Property.Variant_PropertyID)) + 1).ToString())
                                                       };

                            myProductVariantMgr.Edit_Product_Variant_Property(UpdateData);

                        }

                        // Sort New list
                        foreach (Variant_Property Variant_Property in destVariant_Properties)
                        {
                            // Variant Property
                            e2Data[] UpdateData = {
                                                          new e2Data("Variant_PropertyID", Variant_Property.Variant_PropertyID),
                                                          new e2Data("SortOrder", (destVariant_Properties.IndexOf(Get_Variant_Property_in_List(destVariant_Properties, Variant_Property.Variant_PropertyID)) + 1).ToString())
                                                       };

                            myProductVariantMgr.Edit_Product_Variant_Property(UpdateData);

                        }
                    }

                    #endregion

                }
                else
                {

                    #region Dest drop is on Property

                    ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();

                    Variant_Property mydraggedVariant_Property = myProductVariantMgr.Get_Product_Variant_Property(e.DraggedItems[0].GetDataKeyValue("Variant_PropertyID").ToString());
                    Variant_Property mydestVariant_Property = myProductVariantMgr.Get_Product_Variant_Property(e.DestDataItem.GetDataKeyValue("Variant_PropertyID").ToString());

                    if (mydraggedVariant_Property.Variant_SpliterID == mydestVariant_Property.Variant_SpliterID)
                    {
                        // Under same spliter
                        List<Variant_Property> myVariant_Properties = myProductVariantMgr.Get_Product_Variant_Properties_BySpliterID(mydestVariant_Property.Variant_SpliterID);

                        Variant_Property draggedVariant_Property = Get_Variant_Property_in_List(myVariant_Properties, mydraggedVariant_Property.Variant_PropertyID);
                        Variant_Property destVariant_Property = Get_Variant_Property_in_List(myVariant_Properties, mydestVariant_Property.Variant_PropertyID);

                        int destIndex = myVariant_Properties.IndexOf(destVariant_Property);

                        if (e.DropPosition == GridItemDropPosition.Above && e.DestDataItem.ItemIndex > e.DraggedItems[0].ItemIndex)
                        {
                            destIndex -= 1;
                        }
                        if (e.DropPosition == GridItemDropPosition.Below && e.DestDataItem.ItemIndex < e.DraggedItems[0].ItemIndex)
                        {
                            destIndex += 1;
                        }

                        myVariant_Properties.Remove(draggedVariant_Property);
                        myVariant_Properties.Insert(destIndex, draggedVariant_Property);

                        foreach (Variant_Property myVariant_Property in myVariant_Properties)
                        {
                            // Product Variant
                            e2Data[] UpdateData = {
                                                          new e2Data("Variant_PropertyID", myVariant_Property.Variant_PropertyID),
                                                          new e2Data("SortOrder", (myVariant_Properties.IndexOf(Get_Variant_Property_in_List(myVariant_Properties, myVariant_Property.Variant_PropertyID)) + 1).ToString())
                                                       };

                            myProductVariantMgr.Edit_Product_Variant_Property(UpdateData);

                        }

                    }
                    else
                    {
                        // Different spliter
                        List<Variant_Property> originVariant_Properties = myProductVariantMgr.Get_Product_Variant_Properties_BySpliterID(mydraggedVariant_Property.Variant_SpliterID);
                        List<Variant_Property> destVariant_Properties = myProductVariantMgr.Get_Product_Variant_Properties_BySpliterID(mydestVariant_Property.Variant_SpliterID);

                        Variant_Property draggedVariant_Property = Get_Variant_Property_in_List(originVariant_Properties, mydraggedVariant_Property.Variant_PropertyID);
                        Variant_Property destVariant_Property = Get_Variant_Property_in_List(destVariant_Properties, mydestVariant_Property.Variant_PropertyID);

                        int destIndex = destVariant_Properties.IndexOf(destVariant_Property);

                        if (e.DropPosition == GridItemDropPosition.Below)
                        {
                            destIndex += 1;
                        }

                        originVariant_Properties.Remove(draggedVariant_Property);
                        destVariant_Properties.Insert(destIndex, draggedVariant_Property);

                        // Update Property to new Spliter
                        e2Data[] UpdateData_Property = {
                                                               new e2Data("Variant_PropertyID", draggedVariant_Property.Variant_PropertyID),
                                                               new e2Data("Variant_SpliterID", destVariant_Property.Variant_SpliterID)
                                                            };

                        myProductVariantMgr.Edit_Product_Variant_Property(UpdateData_Property);

                        // Sort Old list
                        foreach (Variant_Property myVariant_Property in originVariant_Properties)
                        {
                            // Variant Property
                            e2Data[] UpdateData = {
                                                          new e2Data("Variant_PropertyID", myVariant_Property.Variant_PropertyID),
                                                          new e2Data("SortOrder", (originVariant_Properties.IndexOf(Get_Variant_Property_in_List(originVariant_Properties, myVariant_Property.Variant_PropertyID)) + 1).ToString())
                                                       };

                            myProductVariantMgr.Edit_Product_Variant_Property(UpdateData);

                        }

                        // Sort New list
                        foreach (Variant_Property myVariant_Property in destVariant_Properties)
                        {
                            // Variant Property
                            e2Data[] UpdateData = {
                                                          new e2Data("Variant_PropertyID", myVariant_Property.Variant_PropertyID),
                                                          new e2Data("SortOrder", (destVariant_Properties.IndexOf(Get_Variant_Property_in_List(destVariant_Properties, myVariant_Property.Variant_PropertyID)) + 1).ToString())
                                                       };

                            myProductVariantMgr.Edit_Product_Variant_Property(UpdateData);

                        }
                    }

                    #endregion
                }

                Control_Init();
            }

        }

        protected void lbtn_Property_Delete_Command(object sender, CommandEventArgs e)
        {
            if (!DataEval.IsEmptyQuery(e.CommandArgument.ToString()))
            {
                ProductVariantMgr myProductVariantMgr = new ProductVariantMgr();

                // Remove Property and it's options
                myProductVariantMgr.Remove_Product_Variant_Property_Option_ByPropertyID(e.CommandArgument.ToString());
                myProductVariantMgr.Remove_Product_Variant_Property(e.CommandArgument.ToString());

                Control_Init();
            }

        }

        #endregion
    }
}