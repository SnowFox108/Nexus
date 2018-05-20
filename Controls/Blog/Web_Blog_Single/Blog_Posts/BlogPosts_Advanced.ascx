<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BlogPosts_Advanced.ascx.cs"
    Inherits="Nexus.Controls.Blog.BlogPosts.Advanced" ClassName="Nexus.Controls.Blog.BlogPosts.BlogPosts_Advanced" %>
<asp:MultiView ID="MultiView_BlogPosts" runat="server">
    <asp:View ID="View_New" runat="server">
        <div align="center">
            Click "Edit" to modify Blog Posts options.</div>
    </asp:View>
    <asp:View ID="View_Posts" runat="server">
        <asp:LinkButton ID="lbtn_Add_Post" runat="server">Create New Post</asp:LinkButton>
        <asp:DropDownList ID="droplist_PostStatus_Show" runat="server">
        </asp:DropDownList>
        <asp:Button ID="btn_PostStatus_Show" runat="server" Text="Display" />
        <asp:ListView ID="ListView_BlogPosts" runat="server">
            <EmptyDataTemplate>
            </EmptyDataTemplate>
            <ItemTemplate></ItemTemplate>
            <AlternatingItemTemplate></AlternatingItemTemplate>
            <ItemSeparatorTemplate></ItemSeparatorTemplate>
            <LayoutTemplate>
                <div id="itemPlaceholderContainer" runat="server">
                    <span runat="server" id="itemPlaceholder" />
                </div>
            </LayoutTemplate>
        </asp:ListView>
        <asp:DataPager ID="DataPager_BlogPosts" runat="server" PagedControlID="ListView_BlogPosts">        
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