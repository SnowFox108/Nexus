<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Management_PhotoSetting.ascx.cs"
    Inherits="Nexus.Controls.Gallery.Management.PhotoSetting" ClassName="Nexus.Controls.Gallery.Management.Management_PhotoSetting" %>
<asp:MultiView ID="MultiView_PhotoSetting" runat="server">
    <asp:View ID="View_Edit" runat="server">
        <h2>
            Basic Information</h2>
        <div>
            <asp:HiddenField ID="HiddenField_DisplayID" runat="server" />
            Display ID:
            <asp:TextBox ID="tbx_DisplayID" runat="server" MaxLength="100" Width="200px" ValidationGroup="Photo_Setting"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_DisplayID" runat="server"
                ErrorMessage="Please enter a Display ID" ControlToValidate="tbx_Image_BrokenURL"
                Display="Dynamic" ValidationGroup="Photo_Setting"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator_DisplayID" runat="server"
                ControlToValidate="tbx_DisplayID" Display="Dynamic" ErrorMessage="Display ID can contain number and letters only"
                ValidationExpression="^[a-zA-Z0-9\-]+$" ValidationGroup="Photo_Setting"></asp:RegularExpressionValidator>
            <asp:CustomValidator ID="CustomValidator_DisplayID" runat="server" ErrorMessage="Display ID already exist, please choose another"
                ControlToValidate="tbx_DisplayID" OnServerValidate="CustomValidator_DisplayID_ServerValidate"
                ValidationGroup="Photo_Setting"></asp:CustomValidator>
        </div>
        <div>
            Broken Image URL:
            <asp:TextBox ID="tbx_Image_BrokenURL" runat="server" MaxLength="500" Width="400px"
                ValidationGroup="Photo_Setting"></asp:TextBox>
            <asp:Button ID="btn_BrokenImgSelector" runat="server" ToolTip="Select a image file" Text="Select Image"
                OnClientClick="Show_ControlManager('/App_AdminCP/SiteAdmin/Files/PoP_FileSelector.aspx?ControlID=tbx_Image_BrokenURL&FileTypes=Images'); return false;" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Image_BrokenURL" runat="server"
                ErrorMessage="Please enter URL" ControlToValidate="tbx_Image_BrokenURL" ValidationGroup="Photo_Setting"></asp:RequiredFieldValidator>
        </div>
        <div>
            Enable Resize:
            <asp:RadioButtonList ID="rbtn_IsResize" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                OnSelectedIndexChanged="rbtn_IsResize_SelectedIndexChanged" ValidationGroup="Photo_Setting">
                <asp:ListItem Selected="True" Value="False">No</asp:ListItem>
                <asp:ListItem Value="True">Yes</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <asp:Panel ID="Panel_IsResize" runat="server">
            <h2>
                Photo Resize</h2>
            <div>
                Resize Type:
                <asp:DropDownList ID="droplist_ResizeType" runat="server" ValidationGroup="Photo_Setting">
                </asp:DropDownList>
            </div>
            <div>
                Width:<telerik:RadNumericTextBox ID="RadNumericTbx_ResizeWidth" runat="server" Culture="en-GB"
                    MaxValue="2500" MinValue="1" Value="200" Width="125px" ValidationGroup="Photo_Setting">
                    <NumberFormat DecimalDigits="0" />
                </telerik:RadNumericTextBox>
            </div>
            <div>
                Height:
                <telerik:RadNumericTextBox ID="RadNumericTbx_ResizeHeight" runat="server" Culture="en-GB"
                    MaxValue="2500" MinValue="1" Value="200" Width="125px" ValidationGroup="Photo_Setting">
                    <NumberFormat DecimalDigits="0" />
                </telerik:RadNumericTextBox>
            </div>
            <br />
        </asp:Panel>
        <div>
            Enable Overlay:
            <asp:RadioButtonList ID="rbtn_IsOverlay" runat="server" AutoPostBack="True" RepeatDirection="Horizontal"
                OnSelectedIndexChanged="rbtn_IsOverlay_SelectedIndexChanged" ValidationGroup="Photo_Setting">
                <asp:ListItem Selected="True" Value="False">No</asp:ListItem>
                <asp:ListItem Value="True">Yes</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <asp:Panel ID="Panel_IsOverlay" runat="server">
            <h2>
                Photo Overlay</h2>
            <div>
                Overlay Image URL:
                <asp:TextBox ID="tbx_Overlay_ImageURL" runat="server" MaxLength="500" Width="400px"
                    ValidationGroup="Photo_Setting"></asp:TextBox>
            <asp:Button ID="btn_OverlayImgSelector" runat="server" ToolTip="Select a image file" Text="Select Image"
                OnClientClick="Show_ControlManager('/App_AdminCP/SiteAdmin/Files/PoP_FileSelector.aspx?ControlID=tbx_Overlay_ImageURL&FileTypes=Images'); return false;" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Overlay_ImageURL" runat="server"
                    ErrorMessage="Please enter URL" ControlToValidate="tbx_Overlay_ImageURL" ValidationGroup="Photo_Setting"></asp:RequiredFieldValidator>
            </div>
            <div>
                Opacity:
                <telerik:RadNumericTextBox ID="RadNumericTbx_Overlay_Opacity" runat="server" Culture="en-GB"
                    MaxValue="100" MinValue="0" Value="80" Width="125px" ValidationGroup="Photo_Setting">
                    <NumberFormat DecimalDigits="0" />
                </telerik:RadNumericTextBox>
            </div>
            <div>
                Position:
                <asp:DropDownList ID="droplist_Overlay_Position" runat="server" ValidationGroup="Photo_Setting">
                </asp:DropDownList>
            </div>
            <div>
                Padding X:
                <telerik:RadNumericTextBox ID="RadNumericTbx_Overlay_PaddingX" runat="server" Culture="en-GB"
                    MaxValue="500" MinValue="1" Value="10" Width="125px" ValidationGroup="Photo_Setting">
                    <NumberFormat DecimalDigits="0" />
                </telerik:RadNumericTextBox>
            </div>
            <div>
                Padding Y:
                <telerik:RadNumericTextBox ID="RadNumericTbx_Overlay_PaddingY" runat="server" Culture="en-GB"
                    MaxValue="500" MinValue="1" Value="10" Width="125px" ValidationGroup="Photo_Setting">
                    <NumberFormat DecimalDigits="0" />
                </telerik:RadNumericTextBox>
            </div>
            <br />
        </asp:Panel>
        <div>
            <asp:Button ID="btn_Add" runat="server" Text="Add" OnClick="btn_Add_Click" ValidationGroup="Photo_Setting" />
            <asp:Button ID="btn_Update" runat="server" Text="Update" OnCommand="btn_Update_Command"
                ValidationGroup="Photo_Setting" />
            &nbsp;<asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click"
                CausesValidation="False" ValidationGroup="Photo_Setting" />
        </div>
    </asp:View>
    <asp:View ID="View_List" runat="server">
        <h2>
            Photo Settings
            <asp:LinkButton ID="lbtn_AddNew" runat="server" OnClick="lbtn_AddNew_Click">Add New Setting</asp:LinkButton>
        </h2>
        <asp:ListView ID="ListView_PhotoSettings" runat="server">
            <ItemTemplate>
                <tr style="background-color: #DCDCDC; color: #000000;">
                    <td>
                        <%# Eval("DisplayID") %>
                    </td>
                    <td>
                        <img alt="" src='<%# Eval("Image_BrokenURL") %>' width="100px" />
                    </td>
                    <th>
                        <asp:CheckBox ID="chk_IsResize" runat="server" Checked='<%# Eval("IsResize") %>'
                            Enabled="false" />
                        <br />
                        <asp:Label ID="lbl_Resize" runat="server" Text='<%# string.Format("{0}*{1}", Eval("Resize_Width"), Eval("Resize_Height")) %>'
                            Visible='<%# Eval("IsResize") %>'></asp:Label>
                    </th>
                    <th>
                        <asp:CheckBox ID="chk_IsOverlay" runat="server" Checked='<%# Eval("IsOverlay") %>'
                            Enabled="false" />
                        <br />
                        <asp:Label ID="lbl_Overlay" runat="server" Text='<%# string.Format("{0}<br />X:{1} Y:{2}", Eval("Overlay_Position"), Eval("Overlay_PaddingX"), Eval("Overlay_PaddingY")) %>'
                            Visible='<%# Eval("IsOverlay") %>'></asp:Label>
                    </th>
                    <td>
                        <asp:Image ID="img_Overlay" runat="server" ImageUrl='<%# Eval("Overlay_ImageURL") %>'
                            Width="100px" Visible='<%# Eval("IsOverlay") %>' />
                    </td>
                    <td>
                        <asp:LinkButton ID="lbtn_Edit" runat="server" CommandArgument='<%# Eval("SettingID") %>'
                            ToolTip="Edit photo setting" OnCommand="lbtn_Edit_Command">Edit</asp:LinkButton>
                        <asp:LinkButton ID="lbtn_Delete" runat="server" CommandArgument='<%# Eval("SettingID") %>'
                            ToolTip="Delete photo setting" OnCommand="lbtn_Delete_Command">Delete</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr style="background-color: #FFF8DC;">
                    <td>
                        <%# Eval("DisplayID") %>
                    </td>
                    <td>
                        <img alt="" src='<%# Eval("Image_BrokenURL") %>' width="100px" />
                    </td>
                    <th>
                        <asp:CheckBox ID="chk_IsResize" runat="server" Checked='<%# Eval("IsResize") %>'
                            Enabled="false" />
                        <br />
                        <asp:Label ID="lbl_Resize" runat="server" Text='<%# string.Format("{0}*{1}", Eval("Resize_Width"), Eval("Resize_Height")) %>'
                            Visible='<%# Eval("IsResize") %>'></asp:Label>
                    </th>
                    <th>
                        <asp:CheckBox ID="chk_IsOverlay" runat="server" Checked='<%# Eval("IsOverlay") %>'
                            Enabled="false" />
                        <br />
                        <asp:Label ID="lbl_Overlay" runat="server" Text='<%# string.Format("{0}<br />X:{1} Y:{2}", Eval("Overlay_Position"), Eval("Overlay_PaddingX"), Eval("Overlay_PaddingY")) %>'
                            Visible='<%# Eval("IsOverlay") %>'></asp:Label>
                    </th>
                    <td>
                        <asp:Image ID="img_Overlay" runat="server" ImageUrl='<%# Eval("Overlay_ImageURL") %>'
                            Width="100px" Visible='<%# Eval("IsOverlay") %>' />
                    </td>
                    <td>
                        <asp:LinkButton ID="lbtn_Edit" runat="server" CommandArgument='<%# Eval("SettingID") %>'
                            ToolTip="Edit photo setting" OnCommand="lbtn_Edit_Command">Edit</asp:LinkButton>
                        <asp:LinkButton ID="lbtn_Delete" runat="server" CommandArgument='<%# Eval("SettingID") %>'
                            ToolTip="Delete photo setting" OnCommand="lbtn_Delete_Command">Delete</asp:LinkButton>
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <LayoutTemplate>
                <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;
                    border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;
                    font-family: Verdana, Arial, Helvetica, sans-serif;">
                    <tr id="Tr1" runat="server" style="background-color: #DCDCDC; color: #000000;">
                        <th id="Th1" runat="server">
                            Display ID
                        </th>
                        <th id="Th2" runat="server">
                            Broken Image
                        </th>
                        <th id="Th3" runat="server">
                            Enable Resize
                        </th>
                        <th id="Th4" runat="server">
                            Enable Overlay
                        </th>
                        <th id="Th5" runat="server">
                            Overlay Image
                        </th>
                        <th id="Th6" runat="server">
                            Actions
                        </th>
                    </tr>
                    <tr id="itemPlaceholder" runat="server">
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:ListView>
        <asp:DataPager ID="DataPager_PhotoSettings" runat="server" PagedControlID="ListView_PhotoSettings">
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
