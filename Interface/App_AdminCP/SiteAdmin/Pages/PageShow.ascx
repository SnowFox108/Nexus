<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageShow.ascx.cs" Inherits="Nexus.Core.App_AdminCP_SiteAdmin_Pages_PageShow" %>
<%@ Register Src="PageProperty.ascx" TagName="PageProperty" TagPrefix="uc1" %>
<asp:UpdatePanel ID="UpdatePanel_PageShow" runat="server">
    <ContentTemplate>
        <telerik:RadTabStrip ID="RadTabStrip_Page" runat="server" SelectedIndex="3" MultiPageID="RadMultiPage_Editor"
            OnTabClick="RadTabStrip_Page_TabClick" Skin="Black" 
            EnableEmbeddedSkins="False" >
            <Tabs>
                <telerik:RadTab runat="server" Text="Basic">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="Advance">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="Properties">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="Permissions" Selected="True">
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage ID="RadMultiPage_Editor" runat="server" Width="100%" Height="100%"
            SelectedIndex="3">
            <telerik:RadPageView ID="RadPageView_Basic" runat="server" Selected="True">
                <div class="iFrameWrapper">
                    <asp:Button ID="btn_DesignMode_Basic" runat="server" Text="Edit this page in designer mode"
                        OnCommand="btn_DesignMode_Click" Visible="False" SkinID="btn_edit_page" /><br />
                    <iframe id="iframe_PageEditor_Basic"  runat="server" frameborder="0">
                    </iframe>
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView_Advanced" runat="server">
                <div class="iFrameWrapper">
                    <asp:Button ID="btn_DesignMode_Advanced" runat="server" Text="Edit this page in designer mode"
                        OnCommand="btn_DesignMode_Click" Visible="False" SkinID="btn_edit_page"/> <br />
                    <iframe id="iframe_PageEditor_Advanced" runat="server" frameborder="0"></iframe>
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView_Property" runat="server">
                <div class="NexusCore_PageProperty">
                    <uc1:PageProperty ID="PageProperty_Show" runat="server" />
                </div>
            </telerik:RadPageView>
            <telerik:RadPageView ID="RadPageView_Privacy" runat="server">
                RadPageView
            </telerik:RadPageView>
        </telerik:RadMultiPage>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btn_DesignMode_Basic" />
        <asp:PostBackTrigger ControlID="btn_DesignMode_Advanced" />
    </Triggers>
</asp:UpdatePanel>
