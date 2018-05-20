<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Management_CreateNews.ascx.cs"
    Inherits="Nexus.Controls.News.Management.CreateNews" ClassName="Nexus.Controls.News.Management.Management_CreateNews" %>
<asp:MultiView ID="MultiView_CreateNews" runat="server">
    <asp:View ID="View_Add_News" runat="server">
        <div>
            Title *
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Title" runat="server" ErrorMessage="Please enter news title."
                ControlToValidate="tbx_Title" ValidationGroup="News_Add_Post"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="tbx_Title" runat="server" MaxLength="350" Width="550px" ValidationGroup="News_Add_Post"></asp:TextBox>
        </div>
        <div>
            Content *
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_TextContent" runat="server"
                ControlToValidate="TextEditor_NewsContent" ErrorMessage="Please enter news content."
                ValidationGroup="News_Add_Post"></asp:RequiredFieldValidator>
            <br />
            <nexus:TextEditor ID="TextEditor_NewsContent" runat="server" Toolbar_Status="Basic"
                EnableResize="false" />
        </div>
        <div>
            Select Category * 
            <asp:CustomValidator ID="CustomValidator_Category" runat="server" ControlToValidate="tbx_Title"
                ErrorMessage="You must select a category." OnServerValidate="CustomValidator_Category_ServerValidate"
                ValidationGroup="News_Add_Post"></asp:CustomValidator>
            <br />
            <asp:Panel ID="Panel_Parent_CategoryID" runat="server" BorderStyle="Dashed" Height="150px"
                ScrollBars="Auto" Width="350px" BorderWidth="1px">
                <nexus:CategoryTree ID="CategoryTree_Menu" runat="server" Module_ItemID="3A79BF21-D0DF-4825-BFB2-7F6738C12BA7"
                    Enable_CheckBox="false" Enable_DragAndDrop="false" Enable_HomeRoot="false" Root_CategoryID="-1" />
            </asp:Panel>
        </div>
        <div>
            News Status
            <asp:DropDownList ID="droplist_NewsStatus" runat="server">
            </asp:DropDownList>
        </div>
        <div>
            Password (Only works under Protected status)
            <br />
            <asp:TextBox ID="tbx_Password" runat="server" MaxLength="40" ValidationGroup="News_Add_Post"
                Width="150px"></asp:TextBox>
        </div>
        <div>
            Publication date
            <telerik:RadDateTimePicker ID="RadDateTimePicker_NewsDate" runat="server">
            </telerik:RadDateTimePicker>
        </div>
        <div>
            Content Brief<br />
            Take
            <telerik:RadNumericTextBox ID="RadNumericTbx_NumWords" runat="server" Value="200"
                Width="75px" DataType="System.Int16" MaxValue="500" MinValue="1" ShowSpinButtons="True"
                CssClass="txt_area">
                <NumberFormat DecimalDigits="0" GroupSeparator="" />
            </telerik:RadNumericTextBox>
            letters from News Content
            <asp:LinkButton ID="lbtn_CopyBrief" runat="server" OnClick="lbtn_CopyBrief_Click">Copy</asp:LinkButton>
            <nexus:TextEditor ID="TextEditor_ContentBrief" runat="server" Toolbar_Status="Basic" EnableResize="false" />
        </div>
        <div>News Source (Optional)</div>
        <div>
        Author: 
            <asp:TextBox ID="tbx_Author" runat="server" MaxLength="200" Width="200px"></asp:TextBox>
        </div>
        <div>
        Source Name: 
            <asp:TextBox ID="tbx_SourceName" runat="server" MaxLength="200" Width="200px"></asp:TextBox>
        </div>
        <div>
        Source URL: 
            <asp:TextBox ID="tbx_SourceURL" runat="server" MaxLength="400" Width="400px"></asp:TextBox>
        </div>
        <div class="UserControlBtns">
            <asp:Button ID="btn_Update" runat="server" OnClick="btn_Update_Click" Text="Create this news"
                ValidationGroup="News_Add_Post" />
        </div>
    </asp:View>
    <asp:View ID="View_Created_News" runat="server">
        <div style="min-height: 400px; min-width: 400px; width: 100%; text-align:center;">
            <h1>
                News has been created.</h1>
                <p></p>
                <p></p>
                <p></p>
            <asp:LinkButton ID="lbtn_CreateOtherNews" runat="server" OnClick="lbtn_CreateOtherNews_Click"><h3>Create another news</h3></asp:LinkButton>
        </div>
    </asp:View>
</asp:MultiView>