<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsList_WebView.ascx.cs"
    Inherits="Nexus.Controls.News.NewsList.WebView" ClassName="Nexus.Controls.News.NewsList.NewsList_WebView" %>
<asp:DropDownList ID="droplist_NewsStatus_Show" runat="server">
</asp:DropDownList>
<asp:Button ID="btn_NewsStatus_Show" runat="server" Text="Display" OnClick="btn_NewsStatus_Show_Click" />
<asp:ListView ID="ListView_NewsList" runat="server" OnPagePropertiesChanging="ListView_NewsList_PagePropertiesChanging">
    <EmptyDataTemplate>
    </EmptyDataTemplate>
    <ItemTemplate></ItemTemplate>
    <LayoutTemplate>
        <div id="itemPlaceholderContainer" runat="server" style="">
            <span runat="server" id="itemPlaceholder" />
        </div>
    </LayoutTemplate>
</asp:ListView>
<asp:DataPager ID="DataPager_NewsList" runat="server" PagedControlID="ListView_NewsList">
    <Fields>
        <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False"
            ShowPreviousPageButton="False" />
        <asp:NumericPagerField />
        <asp:NextPreviousPagerField ShowLastPageButton="True" ShowNextPageButton="False"
            ShowPreviousPageButton="False" />
    </Fields>
</asp:DataPager>
