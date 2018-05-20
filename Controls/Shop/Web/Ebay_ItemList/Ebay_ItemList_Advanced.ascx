<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Ebay_ItemList_Advanced.ascx.cs"
    Inherits="Nexus.Controls.Ebay.ItemList.Advanced" ClassName="Nexus.Controls.Ebay.ItemList.ItemList_Advanced" %>
<asp:MultiView ID="MultiView_ItemList" runat="server">
    <asp:View ID="View_New" runat="server">
        <div align="center">
            Click "Edit" to modify Ebay List options.</div>
    </asp:View>
    <asp:View ID="View_ItemList" runat="server">
        <asp:ListView ID="ListView_Ebay_ItemList" runat="server" OnPagePropertiesChanging="ListView_Ebay_ItemList_PagePropertiesChanging">
            <LayoutTemplate>
                <table id="tblContacts" runat="server" cellspacing="0" cellpadding="2">
                    <tr runat="server" id="groupPlaceholder" />
                </table>
            </LayoutTemplate>
            <GroupTemplate>
                <tr runat="server" id="ContactsRow" style="background-color: #FFFFFF">
                    <td runat="server" id="itemPlaceholder" />
                </tr>
            </GroupTemplate>
            <ItemTemplate>
            </ItemTemplate>
            <AlternatingItemTemplate>
            </AlternatingItemTemplate>
            <ItemSeparatorTemplate>
            </ItemSeparatorTemplate>
        </asp:ListView>
        <asp:DataPager ID="DataPager_Ebay_ItemList" runat="server" PagedControlID="ListView_Ebay_ItemList">
            <Fields>
                <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False"
                    ShowPreviousPageButton="False" />
                <asp:NumericPagerField />
                <asp:NextPreviousPagerField ShowLastPageButton="True" ShowNextPageButton="False"
                    ShowPreviousPageButton="False" />
            </Fields>
        </asp:DataPager>
    </asp:View>
</asp:MultiView>