<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CategoryCreate.ascx.cs"
    Inherits="Nexus.Core.App_AdminCP_SiteAdmin_Modules_CategoryCreate" %>
    

    <div class="nexusCore_create_categoryParent">
        <h5>
            Choose Category Parent</h5>
        <asp:Panel ID="Panel_Parent_CategoryID" runat="server" BorderStyle="Dashed" Height="400px"
            ScrollBars="Auto" Width="350px" BorderWidth="1px">
            <nexus:CategoryTree ID="CategoryTree_Parent_CategoryID" Root_CategoryID="-1" runat="server" />
        </asp:Panel>
    </div>
    <br class="clear" />
    <div class="nexusCore_create_categoryName">
         <asp:RequiredFieldValidator ID="RequiredFieldValidator_CategoryName" runat="server"
            ErrorMessage="You must give a name for your category." ControlToValidate="tbx_Category_Name"
            ValidationGroup="Category_Create"></asp:RequiredFieldValidator>
        <br />
       <h5>
            Category Name *       
        <asp:TextBox ID="tbx_Category_Name" runat="server" MaxLength="100" ValidationGroup="Category_Create"
            Width="200px"></asp:TextBox></h5>
            <br />
    </div>
<br class="clear" />
<div>
        <asp:Button ID="btn_Add_Category" runat="server" Text="Create a Category" OnClick="btn_Add_Category_Click"
            ValidationGroup="Category_Create"  SkinID="e2CMS_Button"/>
    </div>

