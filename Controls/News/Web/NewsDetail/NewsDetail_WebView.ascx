<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NewsDetail_WebView.ascx.cs"
    Inherits="Nexus.Controls.News.NewsDetail.WebView" ClassName="Nexus.Controls.News.NewsDetail.NewsDetail_WebView" %>
<asp:MultiView ID="MultiView_NewsDetail" runat="server">
    <asp:View ID="View_New" runat="server">
        <div align="center">
            The news is comming soon.</div>
    </asp:View>
    <asp:View ID="View_Detail" runat="server">
        <asp:HyperLink ID="hlink_Edit_News" runat="server">Edit News</asp:HyperLink>
        <asp:FormView ID="FormView_NewsDetail" runat="server" RenderOuterTable="False">
            <ItemTemplate>
            </ItemTemplate>
        </asp:FormView>
        <asp:Panel ID="Panel_Comment" runat="server">
            <asp:FormView ID="FormView_Comment" runat="server" RenderOuterTable="False">
                <ItemTemplate>
                </ItemTemplate>
            </asp:FormView>
            <asp:ListView ID="ListView_Comment" runat="server" OnPagePropertiesChanging="ListView_Comment_PagePropertiesChanging">
                <EmptyDataTemplate>
                </EmptyDataTemplate>
                <ItemTemplate>
                </ItemTemplate>
                <AlternatingItemTemplate>
                </AlternatingItemTemplate>
                <LayoutTemplate>
                    <div id="itemPlaceholderContainer" runat="server">
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
                Leave a Feedback</h2>
            <div>
                Name *
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_UserName" runat="server" ErrorMessage="Please enter your name."
                    ControlToValidate="tbx_Comment_UserName" ValidationGroup="Post_Add_Comment"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="tbx_Comment_UserName" runat="server" MaxLength="40" Width="200px"
                    ValidationGroup="Post_Add_Comment"></asp:TextBox>
            </div>
            <asp:Panel ID="Panel_Comment_Contact" runat="server">
            <div>
                Email (Optional)<br />
                <asp:TextBox ID="tbx_Comment_UserEmail" runat="server" MaxLength="150" Width="200px"
                    ValidationGroup="Post_Add_Comment"></asp:TextBox>
            </div>
            <div>
                Your URL (Optional)<br />
                <asp:TextBox ID="tbx_Comment_UserURL" runat="server" MaxLength="200" Width="400px"
                    ValidationGroup="Post_Add_Comment"></asp:TextBox>
            </div>

            </asp:Panel>

            <div>
                Comment *
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Comment" runat="server" ControlToValidate="RadEditor_Comment"
                    ErrorMessage="Please enter your comment." ValidationGroup="Post_Add_Comment"></asp:RequiredFieldValidator>
            </div>
            <telerik:RadEditor ID="RadEditor_Comment" runat="server" EnableResize="False" Width="600px">
            </telerik:RadEditor>
            <div class="UserControlBtns">
                <asp:Button ID="btn_PostComment" runat="server" OnClick="btn_PostComment_Click" Text="Post Comment"
                    ValidationGroup="Post_Add_Comment" />
            </div>
        </asp:Panel>
    </asp:View>
</asp:MultiView>