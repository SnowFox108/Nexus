<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Ebay_ItemList_WebView.ascx.cs"
    Inherits="Nexus.Controls.Ebay.ItemList.WebView" ClassName="Nexus.Controls.Ebay.ItemList.ItemList_WebView" %>
<asp:ListView ID="ListView_Ebay_ItemList" runat="server" 
    onpagepropertieschanging="ListView_Ebay_ItemList_PagePropertiesChanging">
    <LayoutTemplate>
        <table id="tblContacts" runat="server" class="eBayItemList">
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
<asp:DataPager ID="DataPager_Ebay_ItemList" runat="server" 
    PagedControlID="ListView_Ebay_ItemList">
    <Fields>
        <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False"
            ShowPreviousPageButton="False" />
        <asp:NumericPagerField />
        <asp:NextPreviousPagerField ShowLastPageButton="True" ShowNextPageButton="False"
            ShowPreviousPageButton="False" />
    </Fields>
</asp:DataPager>
