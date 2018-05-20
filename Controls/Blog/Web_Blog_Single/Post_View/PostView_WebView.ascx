<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PostView_WebView.ascx.cs"
    Inherits="Nexus.Controls.Blog.PostView.WebView" ClassName="Nexus.Controls.Blog.PostView.PostView_WebView" %>
<asp:MultiView ID="MultiView_PostView" runat="server">
    <asp:View ID="View_New" runat="server">
        <div align="center">
            The blog is comming soon.</div>
    </asp:View>
    <asp:View ID="View_Post" runat="server">
        <asp:LinkButton ID="lbtn_Edit_Post" runat="server" OnClick="lbtn_Edit_Post_Click">Edit Post</asp:LinkButton>
        <asp:FormView ID="FormView_PostView" runat="server">
        <ItemTemplate></ItemTemplate>
        </asp:FormView>
        <asp:ListView ID="ListView_Comment" runat="server" 
            onpagepropertieschanging="ListView_Comment_PagePropertiesChanging">
            <EmptyDataTemplate>
            </EmptyDataTemplate>
            <ItemTemplate>
            </ItemTemplate>
            <AlternatingItemTemplate>
            </AlternatingItemTemplate>
            <LayoutTemplate>
                <div id="itemPlaceholderContainer" runat="server" style="">
                    <span runat="server" id="itemPlaceholder" />
                </div>
            </LayoutTemplate>
        </asp:ListView>
        <asp:DataPager ID="DataPager_PostView" runat="server" PagedControlID="ListView_Comment">
            <Fields>
                <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False"
                    ShowPreviousPageButton="False" />
                <asp:NumericPagerField />
                <asp:NextPreviousPagerField ShowLastPageButton="True" ShowNextPageButton="False"
                    ShowPreviousPageButton="False" />
            </Fields>
        </asp:DataPager>
        <h2>
            Leave a Reply</h2>
        <p>
            Name *
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_UserName" runat="server" ErrorMessage="Please enter your name."
                ControlToValidate="tbx_Comment_UserName" ValidationGroup="Post_Add_Comment"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="tbx_Comment_UserName" runat="server" MaxLength="40" Width="200px"
                ValidationGroup="Post_Add_Comment"></asp:TextBox></p>
        <asp:Panel ID="Panel_Comment_Contact" runat="server">
        <p>
            Email (Optional)<br />
            <asp:TextBox ID="tbx_Comment_UserEmail" runat="server" MaxLength="150" Width="200px"
                ValidationGroup="Post_Add_Comment"></asp:TextBox></p>
        <p>
            Your URL (Optional)<br />
            <asp:TextBox ID="tbx_Comment_UserURL" runat="server" MaxLength="200" Width="400px"
                ValidationGroup="Post_Add_Comment"></asp:TextBox></p>
        </asp:Panel>

        <p>
            Comment *
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Comment" runat="server" ControlToValidate="RadEditor_Comment"
                ErrorMessage="Please enter your comment." ValidationGroup="Post_Add_Comment"></asp:RequiredFieldValidator>
        </p>
        <telerik:RadEditor ID="RadEditor_Comment" runat="server" EnableResize="False">
        </telerik:RadEditor>
        <div class="UserControlBtns">
            <asp:Button ID="btn_PostComment" runat="server" OnClick="btn_PostComment_Click" Text="Post Comment"
                ValidationGroup="Post_Add_Comment" />
        </div>
    </asp:View>
    <asp:View ID="View_Edit" runat="server">
        <p>
            Title *
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Title" runat="server" ErrorMessage="Please enter post title."
                ControlToValidate="tbx_Title" ValidationGroup="Blog_Edit_Post"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="tbx_Title" runat="server" MaxLength="350" Width="550px" ValidationGroup="Blog_Edit_Post"></asp:TextBox>
        </p>
        <p>
            Content *
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_TextContent" runat="server" ControlToValidate="TextEditor_BlogContent"
                ErrorMessage="Please enter post content." ValidationGroup="Blog_Edit_Post"></asp:RequiredFieldValidator>
                <br />
            <nexus:TextEditor ID="TextEditor_BlogContent" runat="server" Toolbar_Status="Basic" EnableResize="false" />
        </p>
        <p>
            Post Status
            <asp:DropDownList ID="droplist_PostStatus" runat="server" ValidationGroup="Blog_Edit_Post">
            </asp:DropDownList>
        </p>
        <p>
            Password (Only works under Protected status)
            <br />
            <asp:TextBox ID="tbx_Password" runat="server" MaxLength="40" ValidationGroup="Blog_Edit_Post"
                Width="150px"></asp:TextBox>
        </p>
        <p>
            Publication date
            <telerik:RadDateTimePicker ID="RadDateTimePicker_PostDate" runat="server">
            </telerik:RadDateTimePicker>
        </p>
        <div class="UserControlBtns">
            <asp:Button ID="btn_Update" runat="server" OnClick="btn_Update_Click" Text="Update this post"
                ValidationGroup="Blog_Edit_Post" />
        </div>
    </asp:View>
</asp:MultiView>
