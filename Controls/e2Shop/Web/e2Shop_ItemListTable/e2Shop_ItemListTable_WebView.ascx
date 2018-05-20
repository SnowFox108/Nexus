<%@ Control Language="C#" AutoEventWireup="true" CodeFile="e2Shop_ItemListTable_WebView.ascx.cs"
    Inherits="Nexus.Shop.ItemListTable_WebView" ClassName="Nexus.Shop.WebUI.ItemListTable_WebView" %>
<asp:Panel ID="Panel_PagerTop" runat="server">
</asp:Panel>
<asp:ListView ID="ListView_e2Shop_ItemList" runat="server" 
    onpagepropertieschanging="ListView_e2Shop_ItemList_PagePropertiesChanging">
    <LayoutTemplate>
        <table id="tblContacts" runat="server" class="e2Shop_ItemListTable">
            <tr runat="server" id="groupPlaceholder" />
        </table>
    </LayoutTemplate>
    <GroupTemplate>
        <tr runat="server" id="ContactsRow" class="eBayItemRow">
            <td runat="server" id="itemPlaceholder" />
        </tr>
    </GroupTemplate>
    <ItemTemplate></ItemTemplate>
    <AlternatingItemTemplate></AlternatingItemTemplate>
    <ItemSeparatorTemplate>
    </ItemSeparatorTemplate>
</asp:ListView>
<asp:Panel ID="Panel_PagerBottom" runat="server">
</asp:Panel>
<asp:DataPager ID="DataPager_e2Shop_ItemList" runat="server" 
    PagedControlID="ListView_e2Shop_ItemList">
    <Fields>
        <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False"
            ShowPreviousPageButton="False" />
        <asp:NumericPagerField />
        <asp:NextPreviousPagerField ShowLastPageButton="True" ShowNextPageButton="False"
            ShowPreviousPageButton="False" />
    </Fields>
</asp:DataPager>
