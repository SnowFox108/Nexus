<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TemplateProperty.ascx.cs" Inherits="Nexus.Core.App_AdminCP_SiteAdmin_Templates_TemplateProperty" %>
<asp:Panel ID="Panel_Updated" runat="server">
    <div class="nexusCore_error_message">
        Master properties have been updated!</div>
</asp:Panel>
<table>
    <tr>
        <th>
            MasterPage Name
        </th>
        <td>
            <asp:TextBox ID="tbx_MasterPage_Name" runat="server" MaxLength="100" ></asp:TextBox>
        </td>
    </tr>
    <tr>
        <th>
            MasterPage Description
        </th>
        <td>
            <asp:TextBox ID="tbx_MasterPage_Description" runat="server" MaxLength="250" TextMode="MultiLine"
                Rows="3" Width="300px" ></asp:TextBox>
        </td>
    </tr>
</table>
<asp:UpdatePanel ID="UpdatePanel_Template" runat="server">
    <ContentTemplate>
<table>
    <tr>
        <th>
            Template Name
        </th>
        <td>
            <asp:HiddenField ID="Hidden_TemplateID" runat="server" />
            <asp:Label ID="lbl_Template" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <th>
            Template Masterpage
        </th>
        <td>
            <asp:Label ID="lbl_Masterpage" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <th>
            Template Theme
        </th>
        <td>
            <asp:DropDownList ID="droplist_Theme" runat="server" DataSourceID="ObjectDataSource_Theme"
                DataTextField="Theme_Name" DataValueField="ThemeID" AutoPostBack="True" 
                onselectedindexchanged="droplist_Theme_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="ObjectDataSource_Theme" runat="server" OldValuesParameterFormatString="original_{0}"
                SelectMethod="Get_Themes" TypeName="Nexus.Core.Templates.ThemeMgr">
                <SelectParameters>
                    <asp:ControlParameter ControlID="Hidden_TemplateID" Name="TemplateID" PropertyName="Value"
                        Type="String" />
                    <asp:Parameter Name="SortOrder" Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
            <tr> 
                 <th></th>
                 <td><asp:Image ID="Image_Masterpage_Preview" runat="server"/></td>
                 </tr>
</table>

    </ContentTemplate>
</asp:UpdatePanel>

<div class="nexusCore_btn_goRight">
    <asp:Button ID="btn_Update" runat="server" Text="Update" OnClick="btn_Update_Click" SkinID="e2CMS_Button" />
</div>
