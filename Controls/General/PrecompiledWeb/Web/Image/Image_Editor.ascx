<%@ control language="C#" autoeventwireup="true" inherits="Nexus.Controls.General.Image.Editor, App_Web_d5dxhfe2" classname="Nexus.Controls.General.Image.Image_Editor" %>

<fieldset class="UserControlProperties">
<legend>Image Properties </legend>
<table cellpadding="0" cellspacing="0">
  <tr>
        <td>
            Height
        </td>
        <td>
            <telerik:RadNumericTextBox ID="RadNumericTbx_Height" runat="server" Value="0" Width="75px"
                DataType="System.Int16" MaxValue="2500" MinValue="0" ShowSpinButtons="True" CssClass="txt_area">
                <NumberFormat DecimalDigits="0" GroupSeparator="" />
            </telerik:RadNumericTextBox>
        </td>

        <td>
            Width
        </td>
        <td>
            <telerik:RadNumericTextBox ID="RadNumericTbx_Width" runat="server" Value="0" Width="75px"
                DataType="System.Int16" MaxValue="2500" MinValue="0" ShowSpinButtons="True" CssClass="txt_area">
                <NumberFormat DecimalDigits="0" GroupSeparator="" />
            </telerik:RadNumericTextBox>
        </td>

        <td>
            Border
        </td>
        <td>
            <telerik:RadNumericTextBox ID="RadNumericTbx_Border" runat="server" Value="0" Width="75px"
                DataType="System.Int16" MaxValue="100" MinValue="0" ShowSpinButtons="True" CssClass="txt_area">
                <NumberFormat DecimalDigits="0" GroupSeparator="" />
            </telerik:RadNumericTextBox>
        </td>
    </tr>
</table>
</fieldset>
<fieldset class="UserControlProperties">
<legend>
    Image Data &nbsp;</legend>
<p>
    Image URL &nbsp;<br />
</p>
<asp:TextBox ID="tbx_ImageURL" runat="server" Width="450" MaxLength="250"></asp:TextBox>
<p>
    Alternate Text &nbsp;<br />
    <asp:TextBox ID="tbx_AlternateText" runat="server" Width="450" MaxLength="150" CssClass="txt_area"></asp:TextBox>
</p>
</fieldset>
<fieldset class="UserControlProperties">
<legend>
    Optionial</legend>
<p>
  Link URL &nbsp;<br />
    <asp:TextBox ID="tbx_LinkURL" runat="server" Width="450" MaxLength="250" CssClass="txt_area"></asp:TextBox>
</p>
<p>
    Link Target &nbsp;<br />
    <telerik:RadComboBox ID="RadComboBox_LinkTarget" runat="server" 
    AllowCustomText="True">
        <Items>
            <telerik:RadComboBoxItem runat="server" Text="_blank" Value="_blank" />
            <telerik:RadComboBoxItem runat="server" Text="_parent" Value="_parent" />
            <telerik:RadComboBoxItem runat="server" Text="_self" Value="_self" />
            <telerik:RadComboBoxItem runat="server" Text="_top" Value="_top" />
        </Items>
    </telerik:RadComboBox>
</p>
</fieldset>
<div class="UserControlBtns">
    <asp:Button ID="btn_Update" runat="server" Text="Update" OnClick="btn_Update_Click"/>
</div>
