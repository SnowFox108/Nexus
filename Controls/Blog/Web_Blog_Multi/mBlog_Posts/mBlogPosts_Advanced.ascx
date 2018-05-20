<%@ Control Language="C#" AutoEventWireup="true" CodeFile="mBlogPosts_Advanced.ascx.cs"
    Inherits="Nexus.Controls.Blog.mBlogPosts.Advanced" ClassName="Nexus.Controls.Blog.mBlogPosts.mBlogPosts_Advanced" %>
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
        <asp:ListView ID="ListView_BlogPosts_List" runat="server">
            <EmptyDataTemplate>
                <div align="center">
                    The blog is comming soon.</div>
            </EmptyDataTemplate>
            <ItemTemplate>
                <h2>
                    <asp:LinkButton ID="lbtn_PostTitle" CommandArgument='<%# Eval("PostID") %>' runat="server"><%# Eval("Post_Title") %></asp:LinkButton>
                </h2>
                <div>
                    Posted on
                    <%# Eval("Post_Date_Short") %>
                    by
                    <%# Eval("UserName") %></div>
            </ItemTemplate>
            <LayoutTemplate>
                <div id="itemPlaceholderContainer" runat="server" style="">
                    <span runat="server" id="itemPlaceholder" />
                </div>
            </LayoutTemplate>
        </asp:ListView>
        <asp:DataPager ID="DataPager_BlogPosts_List" runat="server" PagedControlID="ListView_BlogPosts_List">
            <Fields>
                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False"
                    ShowPreviousPageButton="False" />
                <asp:NumericPagerField />
                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False"
                    ShowPreviousPageButton="False" />
            </Fields>
        </asp:DataPager>
        <asp:ListView ID="ListView_BlogPosts" runat="server">
            <EmptyDataTemplate>
                <div align="center">
                    The blog is comming soon.</div>
            </EmptyDataTemplate>
            <ItemTemplate>
                <h2>
                    <asp:LinkButton ID="lbtn_PostTitle" CommandArgument='<%# Eval("PostID") %>' runat="server"><%# Eval("Post_Title") %></asp:LinkButton>
                </h2>
                <div>
                    Posted on
                    <%# Eval("Post_Date_Short") %>
                    by
                    <%# Eval("UserName") %></div>
                <div>
                    <%# Eval("Post_Content") %></div>
                <div>
                    <asp:LinkButton ID="lbtn_Comment" CommandArgument='<%# Eval("PostID") %>' runat="server">Comments (<%# Eval("Comment_Count") %>)</asp:LinkButton></div>
                <div>
                    last updated at:
                    <%# Eval("Post_ModifyDate") %></div>
            </ItemTemplate>
            <LayoutTemplate>
                <div id="itemPlaceholderContainer" runat="server" style="">
                    <span runat="server" id="itemPlaceholder" />
                </div>
            </LayoutTemplate>
        </asp:ListView>
        <asp:DataPager ID="DataPager_BlogPosts" runat="server" PagedControlID="ListView_BlogPosts">
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