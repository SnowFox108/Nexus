<%@ Control Language="C#" AutoEventWireup="true" CodeFile="mBlogPosts_WebView.ascx.cs"
    Inherits="Nexus.Controls.Blog.mBlogPosts.WebView" ClassName="Nexus.Controls.Blog.mBlogPosts.mBlogPosts_WebView" %>
<asp:MultiView ID="MultiView_BlogPosts" runat="server">
    <asp:View ID="View_New" runat="server">
        <div align="center">
            The blog is comming soon.</div>
    </asp:View>
    <asp:View ID="View_Posts" runat="server">
        <asp:LinkButton ID="lbtn_Add_Post" runat="server" OnClick="lbtn_Add_Post_Click">Create New Post</asp:LinkButton>
        <asp:DropDownList ID="droplist_PostStatus_Show" runat="server">
        </asp:DropDownList>
        <asp:Button ID="btn_PostStatus_Show" runat="server" Text="Display" OnClick="btn_PostStatus_Show_Click" />
        <asp:ListView ID="ListView_BlogPosts_List" runat="server" 
            onpagepropertieschanging="ListView_BlogPosts_List_PagePropertiesChanging">
            <EmptyDataTemplate>
                <div align="center">
                    The blog is comming soon.</div>
            </EmptyDataTemplate>
            <ItemTemplate>
                <h2>
                    <asp:HyperLink ID="hlink_PostTitle" NavigateUrl='<%# Get_PostViewURL(Eval("PostID").ToString()) %>'
                        runat="server"><%# Eval("Post_Title")%></asp:HyperLink>
                </h2>
                <div>
                    Posted on
                    <%# Eval("Post_Date_Short") %>by
                    <%# Eval("UserName") %>
                </div>
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
        <asp:ListView ID="ListView_BlogPosts" runat="server" 
            onpagepropertieschanging="ListView_BlogPosts_PagePropertiesChanging">
            <EmptyDataTemplate>
                <div align="center">
                    The blog is comming soon.</div>
            </EmptyDataTemplate>
            <ItemTemplate>
                <h2>
                    <asp:HyperLink ID="hlink_PostTitle" NavigateUrl='<%# Get_PostViewURL(Eval("PostID").ToString()) %>'
                        runat="server"><%# Eval("Post_Title")%></asp:HyperLink>
                </h2>
                <div>
                    Posted on
                    <%# Eval("Post_Date_Short") %>
                    by
                    <%# Eval("UserName") %></div>
                <div>
                    <%# Eval("Post_Content") %></div>
                <div>
                    <asp:HyperLink ID="hlink_Comment" NavigateUrl='<%# Get_PostViewURL(Eval("PostID").ToString()) %>'
                        runat="server">Comments (<%# Eval("Comment_Count") %>)</asp:HyperLink>
                <div>
                    Last updated at:
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
    <asp:View ID="View_Add_Post" runat="server">
        <p>
            Title *
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Title" runat="server" ErrorMessage="Please enter post title."
                ControlToValidate="tbx_Title" ValidationGroup="Blog_Add_Post"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="tbx_Title" runat="server" MaxLength="350" Width="550px" ValidationGroup="Blog_Add_Post"></asp:TextBox>
        </p>
        <p>
            Content *
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="RadEditor_BlogContent"
                ErrorMessage="Please enter post content." ValidationGroup="Blog_Add_Post"></asp:RequiredFieldValidator>
            <br />
            <telerik:RadEditor ID="RadEditor_BlogContent" runat="server" EnableResize="False">
            </telerik:RadEditor>
        </p>
        <p>
            Post Status
            <asp:DropDownList ID="droplist_PostStatus" runat="server">
            </asp:DropDownList>
        </p>
        <p>
            Password (Only works under Protected status)
            <br />
            <asp:TextBox ID="tbx_Password" runat="server" MaxLength="40" ValidationGroup="Blog_Add_Post"
                Width="150px"></asp:TextBox>
        </p>
        <p>
            Publication date
            <telerik:RadDateTimePicker ID="RadDateTimePicker_PostDate" runat="server">
            </telerik:RadDateTimePicker>
        </p>
        <div class="UserControlBtns">
            <asp:Button ID="btn_Update" runat="server" OnClick="btn_Update_Click" Text="Create this post"
                ValidationGroup="Blog_Add_Post" />
        </div>
    </asp:View>
</asp:MultiView>
