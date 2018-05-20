<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TemplateShow.ascx.cs"
    Inherits="Nexus.Core.App_AdminCP_SiteAdmin_Templates_TemplateShow" %>
<%@ Register src="TemplateProperty.ascx" tagname="templateproperty" tagprefix="uc" %>
<asp:UpdatePanel ID="UpdatePanel_PageShow" runat="server">
    <ContentTemplate>
        <div class="nexusCore_pages_iframeButtons">
            <asp:Panel ID="Panel_PageMode" runat="server">
                <asp:Button ID="btn_Preview" runat="server" Text="Preview" OnClick="btn_Preview_Click"
                    SkinID="e2CMS_ImgButton" />
                <asp:Button ID="btn_Modify" runat="server" Text="Modify" OnClick="btn_Modify_Click"
                    SkinID="e2CMS_ImgButton" />
                <asp:Button ID="btn_DesignMode" runat="server" Text="Designer Mode" OnCommand="btn_DesignMode_Click"
                    SkinID="e2CMS_ImgButton" />
                <asp:Button ID="btn_Property" runat="server" Text="Properties" OnCommand="btn_Property_Command"
                    SkinID="e2CMS_ImgButton" />
            </asp:Panel>
        </div>
        <telerik:RadMultiPage ID="RadMultiPage_Editor" runat="server" Width="100%" Height="100%"
            SelectedIndex="0">
            <telerik:RadPageView ID="RadPageView_Basic" runat="server" Selected="True">
                <div class="nexusCore_designMode_iframeWrapper">
                    <iframe id="iframe_PageEditor_Basic" runat="server" frameborder="0"></iframe>
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView_Advanced" runat="server">
                <div class="nexusCore_designMode_iframeWrapper">
                    <iframe id="iframe_PageEditor_Advanced" runat="server" frameborder="0"></iframe>
                </div>
            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btn_DesignMode" />
        <asp:PostBackTrigger ControlID="btn_Property" />
    </Triggers>
</asp:UpdatePanel>
