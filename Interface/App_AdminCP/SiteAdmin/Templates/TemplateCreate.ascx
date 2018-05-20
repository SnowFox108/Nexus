<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TemplateCreate.ascx.cs" Inherits="Nexus.Core.App_AdminCP_SiteAdmin_Templates_TemplateCreate" %>
<table>
    <tr>
        <th>
            MasterPage Name
        </th>
        <td>
            <asp:TextBox ID="tbx_MasterPage_Name" runat="server" MaxLength="100" CssClass="txt_input" ></asp:TextBox>
        </td>
    </tr>
    <tr>
        <th>
            MasterPage Description
        </th>
        <td>
            <asp:TextBox ID="tbx_MasterPage_Description" runat="server" MaxLength="250" TextMode="MultiLine"
                Rows="3" Width="300px" CssClass="txt_input"></asp:TextBox>
        </td>
    </tr>
</table>
<asp:UpdatePanel ID="UpdatePanel_Template" runat="server">
    <ContentTemplate>
        <table>
            <tr>
                <th>
                    Template
                </th>
                <td>
                    <asp:DropDownList ID="droplist_Template" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource_Template"
                        DataTextField="Template_Name" DataValueField="TemplateID" OnSelectedIndexChanged="droplist_Template_SelectedIndexChanged" CssClass="txt_input">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource_Template" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="Get_Templates" TypeName="Nexus.Core.Templates.TemplateMgr">
                        <SelectParameters>
                            <asp:Parameter Name="SortOrder" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <th>
                    Template Masterpage
                </th>
                <td>
                    <asp:DropDownList ID="droplist_Masterpage" runat="server" AutoPostBack="True" DataSourceID="ObjectDataSource_Masterpage"
                        DataTextField="MasterPage_Template_Name" DataValueField="MasterPageID" OnSelectedIndexChanged="droplist_Masterpage_SelectedIndexChanged" CssClass="txt_input">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource_Masterpage" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="Get_Template_MasterPages" TypeName="Nexus.Core.Templates.TemplateMgr">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="droplist_Template" Name="TemplateID" PropertyName="SelectedValue"
                                Type="String" />
                            <asp:Parameter Name="SortOrder" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
            <tr>
                <th>
                    Template Theme
                </th>
                <td>
                    <asp:DropDownList ID="droplist_Theme" runat="server" DataSourceID="ObjectDataSource_Theme"
                        DataTextField="Theme_Name" DataValueField="ThemeID" AutoPostBack="True" 
                        OnSelectedIndexChanged="droplist_Theme_SelectedIndexChanged" 
                        ondatabound="droplist_Theme_DataBound" CssClass="txt_input">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource_Theme" runat="server" OldValuesParameterFormatString="original_{0}"
                        SelectMethod="Get_Themes" TypeName="Nexus.Core.Templates.ThemeMgr">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="droplist_Template" Name="TemplateID" PropertyName="SelectedValue"
                                Type="String" />
                            <asp:Parameter Name="SortOrder" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
            <tr> 
                 <th></th>
                 <td><asp:Image ID="Image_Masterpage_Preview" runat="server" CssClass="txt_input"/></td>
            </tr>
        </table>

    </ContentTemplate>
</asp:UpdatePanel>
<div class="btn_Go_Right">
    <asp:Button ID="btn_AddMasterpage" runat="server" Text="Create a Masterpage" OnClick="btn_AddMasterpage_Click" SkinID="btn_long"  />
</div>
