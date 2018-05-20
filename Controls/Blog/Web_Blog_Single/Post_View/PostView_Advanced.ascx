<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PostView_Advanced.ascx.cs" Inherits="Nexus.Controls.Blog.PostView.Advanced" ClassName="Nexus.Controls.Blog.PostView.PostView_Advanced" %>
<asp:MultiView ID="MultiView_PostView" runat="server">
    <asp:View ID="View_New" runat="server">
        <div align="center">
            Click "Edit" to modify Post View options.</div>
    </asp:View>
    <asp:View ID="View_Post" runat="server">
        <asp:LinkButton ID="lbtn_Edit_Post" runat="server">Edit Post</asp:LinkButton>
        <asp:FormView ID="FormView_PostView" runat="server">
            <ItemTemplate>
            </ItemTemplate>
        </asp:FormView>
        <asp:ListView ID="ListView_Comment" runat="server">
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
            <asp:Button ID="btn_PostComment" runat="server" Text="Post Comment"
                ValidationGroup="Post_Add_Comment" />
        </div>
    </asp:View>
</asp:MultiView>
