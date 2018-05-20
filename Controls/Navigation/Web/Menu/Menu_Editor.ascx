<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Menu_Editor.ascx.cs" Inherits="Nexus.Controls.Navigation.Menu.Editor"
    ClassName="Nexus.Controls.Navigation.Menu.Menu_Editor" %>
<table>
    <tr>
        <th>
            Menu Type
        </th>
        <td>
            <asp:RadioButtonList ID="rbtnlist_IsStatic" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="True">Static</asp:ListItem>
                <asp:ListItem Value="False">Dynamic</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <th>
            Root Page ID
        </th>
        <td>
            (Only works when Menu type is on static mode.The home root ID is &quot;-1&quot;)<br />
            <asp:TextBox ID="tbx_RootPageID" runat="server" MaxLength="36" Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <th>
            Menu Level Display
        </th>
        <td>
            <asp:RadioButtonList ID="rbtnlist_DisplaySameLevel" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="True">Same Level</asp:ListItem>
                <asp:ListItem Selected="True" Value="False">Next Level</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <th>
            Display Page Type
        </th>
        <td>
            <asp:RadioButtonList ID="rbtnlist_DisplayCategory" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="True">With Page Category</asp:ListItem>
                <asp:ListItem Value="False">Without Page Category</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <th>
            Menu Orientation
        </th>
        <td>
            <asp:DropDownList ID="droplist_Orientation" runat="server">
                <asp:ListItem Selected="True" Value="HorizontalBottom">Horizontal Bottom</asp:ListItem>
                <asp:ListItem Value="HorizontalTop">Horizontal Top</asp:ListItem>
                <asp:ListItem Value="VerticalLeft">Vertical Left</asp:ListItem>
                <asp:ListItem Value="VerticalRight">Vertical Right</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <th>
            Menu Skin
        </th>
        <td>
            <asp:DropDownList ID="droplist_Skin" runat="server">
                <asp:ListItem Selected="True">Default</asp:ListItem>
                <asp:ListItem>Black</asp:ListItem>
                <asp:ListItem>Forest</asp:ListItem>
                <asp:ListItem>Hay</asp:ListItem>
                <asp:ListItem>Office2007</asp:ListItem>
                <asp:ListItem>Outlook</asp:ListItem>
                <asp:ListItem>Simple</asp:ListItem>
                <asp:ListItem>Sunset</asp:ListItem>
                <asp:ListItem>Vista</asp:ListItem>
                <asp:ListItem>Web20</asp:ListItem>
                <asp:ListItem>WebBlue</asp:ListItem>
                <asp:ListItem>Customer</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <th>
            Menu CssClass
        </th>
        <td>
            (Only work when Skin is in Customer)
            <br />
            <telerik:RadComboBox ID="RadComboBox_CssClass" runat="server" AllowCustomText="True">
                <Items>
                    <telerik:RadComboBoxItem runat="server" Text="Default" Value="Default" />
                </Items>
            </telerik:RadComboBox>
        </td>
    </tr>
</table>
<div class="UserControlBtns">
    <asp:Button ID="btn_Update" runat="server" Text="Update" OnClick="btn_Update_Click" />
</div>
