<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TemplateShow.ascx.cs" Inherits="Nexus.Core.App_AdminCP_SiteAdmin_Templates_TemplateShow" %>
<%@ Register src="TemplateProperty.ascx" tagname="TemplateProperty" tagprefix="uc" %>
<asp:UpdatePanel ID="UpdatePanel_PageShow" runat="server">
    <ContentTemplate>
        <telerik:RadTabStrip ID="RadTabStrip_Page" runat="server" SelectedIndex="0" MultiPageID="RadMultiPage_Editor"
            OnTabClick="RadTabStrip_Page_TabClick" Skin="Black" EnableEmbeddedSkins="False">
            <Tabs>
                <telerik:RadTab runat="server" Selected="True" Text="Basic">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="Advance">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="Properties">
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage ID="RadMultiPage_Editor" runat="server" Width="100%" Height="100%"
            SelectedIndex="0">
            <telerik:RadPageView ID="RadPageView_Basic" runat="server" Selected="True">
                <div class="iFrameWrapper">
                    <asp:Button ID="btn_DesignMode_Basic" runat="server" Text="Edit this template in designer mode"
                        OnCommand="btn_DesignMode_Click" Visible="False" SkinID="btn_edit_page" /><br/>
                    <iframe id="iframe_PageEditor_Basic" runat="server" frameborder="0">
                    </iframe>
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView_Advanced" runat="server">
                <div class="iFrameWrapper">
                    <asp:Button ID="btn_DesignMode_Advanced" runat="server" Text="Edit this template in designer mode"
                        OnCommand="btn_DesignMode_Click" Visible="False" SkinID="btn_edit_page" /><br />
                    <iframe id="iframe_PageEditor_Advanced" runat="server"   frameborder="0"></iframe>
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView_Property" runat="server">
                <div class="NexusCore_PageProperty">
                    <uc:TemplateProperty ID="TemplateProperty" runat="server" />
                </div>
            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btn_DesignMode_Basic" />
        <asp:PostBackTrigger ControlID="btn_DesignMode_Advanced" />
    </Triggers>
</asp:UpdatePanel>
