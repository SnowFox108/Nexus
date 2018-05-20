<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Navigator_Editor.ascx.cs" Inherits="Nexus.Controls.Navigation.Navigator.Editor" ClassName="Nexus.Controls.Navigation.Navigator.Navigator_Editor" %>
<table>
    <tr>
        <th>
            Root Page ID
        </th>
        <td>(The home root ID is "-1")<br />
            <asp:TextBox ID="tbx_RootPageID" runat="server" MaxLength="36" Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <th>
            Navigator Type
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
            Navigator Sign
        </th>
        <td>
            <asp:TextBox ID="tbx_Sign" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <th>
            Navigator CssClass
        </th>
        <td>
            <telerik:RadComboBox ID="RadComboBox_CssClass" runat="server" AllowCustomText="True">
                <Items>
                    <telerik:RadComboBoxItem runat="server" Text="Disable" Value="Disable" />
                </Items>
            </telerik:RadComboBox>
        </td>
    </tr>

</table>
<div class="UserControlBtns">
    <asp:Button ID="btn_Update" runat="server" Text="Update" OnClick="btn_Update_Click" />
</div>
