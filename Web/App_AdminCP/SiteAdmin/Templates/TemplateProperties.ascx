<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TemplateProperties.ascx.cs"
    Inherits="Nexus.Core.App_AdminCP_SiteAdmin_Templates_TemplateProperties" %>
<%@ Register Src="TemplateProperty.ascx" TagName="TemplateProperty" TagPrefix="nexus" %>
<%@ Register Src="TemplateMetaTag.ascx" TagName="TemplateMetaTag" TagPrefix="nexus" %>
<%@ Register Src="TemplateVersion.ascx" TagName="TemplateVersion" TagPrefix="nexus" %>
<asp:UpdatePanel ID="UpdatePanel_PageShow" runat="server">
    <ContentTemplate>
        <div class="nexusCore_pages_iframeButtons">
            <asp:Panel ID="Panel_PageMode" runat="server">
                <asp:Button ID="btn_PageShow" runat="server" Text="MasterPage View" OnCommand="btn_PageShow_Command"
                    SkinID="e2CMS_ImgButton" />
                <asp:Button ID="btn_Property" runat="server" Text="Property" OnClick="btn_Property_Click"
                    SkinID="e2CMS_ImgButton" />
                <asp:Button ID="btn_MetaTag" runat="server" Text="MetaTag" OnClick="btn_MetaTag_Click"
                    SkinID="e2CMS_ImgButton" />
                <asp:Button ID="btn_Version" runat="server" Text="Version" OnClick="btn_Version_Click"
                    SkinID="e2CMS_ImgButton" />
            </asp:Panel>
        </div>
        <telerik:RadMultiPage ID="RadMultiPage_Editor" runat="server" Width="100%" Height="100%">
            <telerik:RadPageView ID="RadPageView_Property" runat="server" Selected="True">
                <div class="nexusCore_templateProperty">
                    <nexus:TemplateProperty ID="TemplateProperty" runat="server" />
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView_MetaTag" runat="server">
                <nexus:TemplateMetatag ID="TemplateMetaTag_Show" runat="server" />
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView_Version" runat="server">
                <nexus:TemplateVersion ID="TemplateVersion_Show" runat="server" />
            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btn_PageShow" />
    </Triggers>
</asp:UpdatePanel>
