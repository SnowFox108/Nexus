<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CSS_Menu_Editor.ascx.cs"
    Inherits="Nexus.Controls.Navigation.CSS_Menu.Editor" ClassName="Nexus.Controls.Navigation.CSS_Menu.CSS_Menu_Editor" %>
    <table>
    <tr>
        <th>
            Menu Type
        </th>
        <td>
            <asp:RadioButtonList ID="rbtnlist_IsStatic" runat="server" 
                RepeatDirection="Horizontal">
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
        (Only works when Menu type is on static mode.The 
            home root ID is &quot;-1&quot;)<br />
            <asp:TextBox ID="tbx_RootPageID" runat="server" MaxLength="36" Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <th>
            Menu Level Display
        </th>
        <td>
            <asp:RadioButtonList ID="rbtnlist_DisplaySameLevel" runat="server" 
                RepeatDirection="Horizontal">
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
            <asp:RadioButtonList ID="rbtnlist_DisplayCategory" runat="server" 
                RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="True">With Page Category</asp:ListItem>
                <asp:ListItem Value="False">Without Page Category</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <th>
            Menu link css
        </th>
        <td>
            <asp:TextBox ID="tbx_CSS" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <th>
            Menu active link css
        </th>
        <td>
            <asp:TextBox ID="tbx_ActiveCSS" runat="server"></asp:TextBox>
        </td>
    </tr>

</table>
<div class="UserControlBtns">
    <asp:Button ID="btn_Update" runat="server" Text="Update" OnClick="btn_Update_Click" />
</div>
