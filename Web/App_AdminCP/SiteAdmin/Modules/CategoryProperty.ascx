<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CategoryProperty.ascx.cs"
    Inherits="Nexus.Core.App_AdminCP_SiteAdmin_Modules_CategoryProperty" %>
<div class="nexusCore_multiView_Modify">
    <asp:MultiView ID="MultiView_Modify" runat="server">
        <asp:View ID="View_Show" runat="server">
            <asp:LinkButton ID="lbl_Modify" runat="server" OnClick="lbl_Modify_Click" CssClass="nexusCore_link_btn">Modify</asp:LinkButton>
        </asp:View>
        <asp:View ID="View_Update" runat="server">
            <span class="nexusCore_label">Category Name * </span>
                <asp:TextBox ID="tbx_Category_Name" runat="server" MaxLength="100" ValidationGroup="Category_Update"
                    Width="200px"></asp:TextBox>&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="lbl_Update" runat="server" OnClick="lbl_Update_Click" ValidationGroup="Category_Update"
                    CssClass="nexusCore_link_btn">Update</asp:LinkButton>
                <asp:LinkButton ID="lbl_Cancel"
                        runat="server" CausesValidation="False" OnClick="lbl_Cancel_Click" CssClass="nexusCore_link_btn">Cancel</asp:LinkButton>
                            <asp:CustomValidator ID="CustomValidator_CategoryID" runat="server" 
                ErrorMessage="You can not change name for system cateogry." Display="Dynamic" 
                onservervalidate="CustomValidator_CategoryID_ServerValidate" ValidationGroup="Category_Update"></asp:CustomValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_CategoryName" runat="server"
                    ErrorMessage="You must give a name for your category." ControlToValidate="tbx_Category_Name"
                    ValidationGroup="Category_Update"></asp:RequiredFieldValidator>

        </asp:View>
    </asp:MultiView>
</div>
