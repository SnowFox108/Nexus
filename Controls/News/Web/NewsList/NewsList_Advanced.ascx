<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsList_Advanced.ascx.cs"
    Inherits="Nexus.Controls.News.NewsList.Advanced" ClassName="Nexus.Controls.News.NewsList.NewsList_Advanced" %>
<asp:MultiView ID="MultiView_NewsList" runat="server">
    <asp:View ID="View_New" runat="server">
        <div align="center">
            Click "Edit" to modify News List options.</div>
    </asp:View>
    <asp:View ID="View_NewsList" runat="server">
        <asp:DropDownList ID="droplist_NewsStatus_Show" runat="server">
        </asp:DropDownList>
        <asp:Button ID="btn_NewsStatus_Show" runat="server" Text="Display" />
        <asp:ListView ID="ListView_NewsList" runat="server">
            <EmptyDataTemplate>
                <div align="center">
                    More news is comming soon.</div>
            </EmptyDataTemplate>
            <ItemTemplate>
            </ItemTemplate>
            <LayoutTemplate>
                <div id="itemPlaceholderContainer" runat="server" style="">
                    <span runat="server" id="itemPlaceholder" />
                </div>
            </LayoutTemplate>
        </asp:ListView>
        <asp:DataPager ID="DataPager_NewsList" runat="server" PagedControlID="ListView_NewsList">
            <Fields>
                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False"
                    ShowPreviousPageButton="False" />
                <asp:NumericPagerField />
                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False"
                    ShowPreviousPageButton="False" />
            </Fields>
        </asp:DataPager>
    </asp:View>
</asp:MultiView>