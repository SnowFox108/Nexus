<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Photo_ItemList_WebView.ascx.cs"
    Inherits="Nexus.Controls.Gallery.ItemList.WebView" ClassName="Nexus.Controls.Gallery.ItemList.ItemList_WebView" %>
<asp:HyperLink ID="hlink_Edit_Item" runat="server">Upload Photos</asp:HyperLink>
<asp:ListView ID="ListView_ItemList" runat="server" OnPagePropertiesChanging="ListView_ItemList_PagePropertiesChanging">
    <EmptyDataTemplate>
    </EmptyDataTemplate>
    <ItemTemplate>
    </ItemTemplate>
    <LayoutTemplate>
        <div id="itemPlaceholderContainer" runat="server" class="NexusPhotoList">
            <ul id="NexusPhotoList_ul" class="NexusPhotoList_ul">
                <span runat="server" id="itemPlaceholder" />
            </ul>
        </div>
    </LayoutTemplate>
</asp:ListView>
<asp:DataPager ID="DataPager_ItemList" runat="server" PagedControlID="ListView_ItemList">
    <Fields>
        <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False"
            ShowPreviousPageButton="False" />
        <asp:NumericPagerField />
        <asp:NextPreviousPagerField ShowLastPageButton="True" ShowNextPageButton="False"
            ShowPreviousPageButton="False" />
    </Fields>
</asp:DataPager>
