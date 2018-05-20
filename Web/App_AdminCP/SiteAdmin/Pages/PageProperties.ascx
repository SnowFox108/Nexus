<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageProperties.ascx.cs"
    Inherits="Nexus.Core.App_AdminCP_SiteAdmin_Pages_PageProperties" %>
<%@ Register Src="PageProperty.ascx" TagName="PageProperty" TagPrefix="nexus" %>
<%@ Register Src="PageMetaTag.ascx" TagName="PageMetaTag" TagPrefix="nexus" %>
<%@ Register Src="PagePrivacy.ascx" TagName="PagePrivacy" TagPrefix="nexus" %>
<%@ Register src="PageVersion.ascx" tagname="PageVersion" tagprefix="nexus" %>
<asp:UpdatePanel ID="UpdatePanel_PageShow" runat="server">
    <ContentTemplate>
        <div class="nexusCore_pages_iframeButtons">
            <asp:Panel ID="Panel_PageMode" runat="server">
                <asp:Button ID="btn_PageShow" runat="server" Text="Page View" OnCommand="btn_PageShow_Command"
                    SkinID="e2CMS_ImgButton" />
                <asp:Button ID="btn_Property" runat="server" Text="Property" OnClick="btn_Property_Click"
                    SkinID="e2CMS_ImgButton" />
                <asp:Button ID="btn_MetaTag" runat="server" Text="MetaTags" Onclick="btn_MetaTag_Click" 
                    SkinID="e2CMS_ImgButton" />
                <asp:Button ID="btn_Privacy" runat="server" Text="Privacy" OnClick="btn_Privacy_Click"
                    SkinID="e2CMS_ImgButton" />
                <asp:Button ID="btn_Version" runat="server" Text="Version" OnClick="btn_Version_Click"
                    SkinID="e2CMS_ImgButton" />
            </asp:Panel>
        </div>
        <telerik:RadMultiPage ID="RadMultiPage_Editor" runat="server" Width="100%" Height="100%">
            <telerik:RadPageView ID="RadPageView_Property" runat="server" Selected="True">
                <nexus:PageProperty ID="PageProperty_Show" runat="server" />
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView_MetaTag" runat="server">
                <nexus:PageMetaTag ID="PageMetaTag_Show" runat="server" />
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView_Privacy" runat="server">
                <nexus:PagePrivacy ID="PagePrivacy_Show" runat="server" />
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView_Version" runat="server">
                <nexus:PageVersion ID="PageVersion_Show" runat="server" />
            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btn_PageShow" />
    </Triggers>
</asp:UpdatePanel>
