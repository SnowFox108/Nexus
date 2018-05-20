<%@ Control Language="C#" AutoEventWireup="true" CodeFile="mPostView_Advanced.ascx.cs"
    Inherits="Nexus.Controls.Blog.mPostView.Advanced" ClassName="Nexus.Controls.Blog.mPostView.mPostView_Advanced" %>
<asp:MultiView ID="MultiView_PostView" runat="server">
    <asp:View ID="View_New" runat="server">
        <div align="center">
            Click "Edit" to modify Post View options.</div>
    </asp:View>
    <asp:View ID="View_Post" runat="server">
        <asp:LinkButton ID="lbtn_Edit_Post" runat="server">Edit Post</asp:LinkButton>
        <h1>
            <asp:Label ID="lbl_Title" runat="server"></asp:Label></h1>
        <div>
            Posted on
            <asp:Label ID="lbl_Post_Date" runat="server"></asp:Label>
            by
            <asp:Label ID="lbl_UserName" runat="server"></asp:Label>
        </div>
        <div>
            <asp:Literal ID="Literal_Content" runat="server"></asp:Literal></div>
        <div>
            Last updated at:
            <asp:Label ID="lbl_Post_ModifyDate" runat="server"></asp:Label></div>
        <div>
            <asp:PlaceHolder ID="PlaceHolder_SocialNetwork" runat="server"></asp:PlaceHolder>
        </div>
        <hr />
        <h2>
            Comments
            <asp:Label ID="lbl_Comment_Count" runat="server"></asp:Label>
        </h2>
        <asp:ListView ID="ListView_Comment" runat="server">
            <EmptyDataTemplate>
                <span>No comment yet.</span>
            </EmptyDataTemplate>
            <ItemTemplate>
                <div>
                    <%# Eval("UserName_URL") %>
                    <%# Eval("UserEmail") %>
                </div>
                <div>
                    <%# Eval("Post_Date") %>
                </div>
                <div>
                    <%# Eval("Post_Content") %>
                </div>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <div>
                    <%# Eval("UserName_URL") %>
                    <%# Eval("UserEmail") %>
                </div>
                <div>
                    <%# Eval("Post_Date") %>
                </div>
                <div>
                    <%# Eval("Post_Content") %>
                </div>
            </AlternatingItemTemplate>
            <LayoutTemplate>
                <div id="itemPlaceholderContainer" runat="server" style="">
                    <span runat="server" id="itemPlaceholder" />
                </div>
            </LayoutTemplate>
        </asp:ListView>
        <asp:DataPager ID="DataPager_PostView" runat="server" PagedControlID="ListView_Comment">
            <Fields>
                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False"
                    ShowPreviousPageButton="False" />
                <asp:NumericPagerField />
                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False"
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
        <p>
            Email (Optional)<br />
            <asp:TextBox ID="tbx_Comment_UserEmail" runat="server" MaxLength="150" Width="200px"
                ValidationGroup="Post_Add_Comment"></asp:TextBox></p>
        <p>
            Your URL (Optional)<br />
            <asp:TextBox ID="tbx_Comment_UserURL" runat="server" MaxLength="200" Width="400px"
                ValidationGroup="Post_Add_Comment"></asp:TextBox></p>
        <p>
            Comment *
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Comment" runat="server" ControlToValidate="RadEditor_Comment"
                ErrorMessage="Please enter your comment." ValidationGroup="Post_Add_Comment"></asp:RequiredFieldValidator>
        </p>
        <telerik:RadEditor ID="RadEditor_Comment" runat="server" EnableResize="False">
        </telerik:RadEditor>
        <div class="UserControlBtns">
            <asp:Button ID="btn_PostComment" runat="server" Text="Post Comment" ValidationGroup="Post_Add_Comment" />
        </div>
    </asp:View>
</asp:MultiView>
