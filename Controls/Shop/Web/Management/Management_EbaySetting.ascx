<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Management_EbaySetting.ascx.cs"
    Inherits="Nexus.Controls.Ebay.Management.EbaySetting" ClassName="Nexus.Controls.Ebay.Management.Management_EbaySetting" %>
<asp:UpdatePanel ID="UpdatePanel_UserInfo" runat="server">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btn_ShowUserInfo" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btn_GetUserToken" EventName="Click" />
    </Triggers>
    <ContentTemplate>
<div>
    Ebay Server URL
    <br />
    <asp:TextBox ID="tbx_EbayServerURL" runat="server" Width="400px" Enabled="False"
        ReadOnly="True"></asp:TextBox>
</div>
<div>
    User Aip Token
    <br />
    <asp:TextBox ID="tbx_AipToken" runat="server" Rows="8" TextMode="MultiLine" Enabled="False"
        ReadOnly="True" Width="400px"></asp:TextBox>
</div>
<div>
    Ebay Site Default
    <br />
    <asp:DropDownList ID="drop_SiteCode" runat="server" Enabled="False">
    </asp:DropDownList>
</div>
<div>
    Choose Ebay List Type to Import
    <br />
    <asp:DropDownList ID="droplist_Ebay_ListType" runat="server">
    </asp:DropDownList>
</div>
        <asp:Button ID="btn_ShowUserInfo" runat="server" Text="Get User Ebay Info" OnClick="btn_ShowUserInfo_Click" />
        &nbsp;<asp:HyperLink ID="HyperLink_eBayLogin" runat="server" Target="_blank">eBay Login (step 2)</asp:HyperLink>
        &nbsp;<asp:Button ID="btn_GetUserToken" runat="server" Text="Get User Token (step 3)" OnClick="btn_GetUserToken_Click" />
        <asp:UpdateProgress ID="UpdateProgress_Updating" runat="server">
            <ProgressTemplate>
                <div style="float: left">
                    <img src="/App_Control_Style/Nexus_Ebay/Images/progressBar.gif" alt="updating..." />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:Panel ID="Panel_UserInfo" runat="server">
            <h3>
                User Info</h3>
            <div>
                <span style="width: 150px;">Token expired in</span> <span>
                    <asp:Label ID="lbl_TokenStatus" runat="server"></asp:Label></span>
            </div>
            <div>
                <span style="width: 150px;">User ID </span><span>
                    <asp:Label ID="lbl_UserID" runat="server"></asp:Label>
                </span>
            </div>
            <div>
                <span style="width: 150px;">User has good standing </span><span>
                    <asp:Label ID="lbl_GoodStanding" runat="server"></asp:Label>
                </span>
            </div>
            <div>
                <span style="width: 150px;">Feedback rating star </span><span>
                    <asp:Image ID="img_RatingStar" runat="server" />
                </span>
            </div>
            <div>
                <span style="width: 150px;">Feedback Score </span><span>
                    <asp:Label ID="lbl_FeedbackScore" runat="server"></asp:Label>
                </span>
            </div>
            <div>
                <span style="width: 150px;">Positive </span><span>
                    <asp:Label ID="lbl_FeedbackPositive" runat="server"></asp:Label>
                </span>
            </div>
            <div>
                <span style="width: 150px;">Neutral </span><span>
                    <asp:Label ID="lbl_FeedbackNeutral" runat="server"></asp:Label>
                </span>
            </div>
            <div>
                <span style="width: 150px;">Negative </span><span>
                    <asp:Label ID="lbl_FeedbackNegative" runat="server"></asp:Label>
                </span>
            </div>
            <div>
                <strong>You have total
                    <asp:Label ID="lbl_TotalNumber" runat="server"></asp:Label>
                    Items In
                    <asp:Label ID="lbl_EbayListType" runat="server"></asp:Label>
                </strong>
            </div>
            <asp:HyperLink ID="hlink_FetchSelling" runat="server">Import Ebay Selling into database</asp:HyperLink>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
