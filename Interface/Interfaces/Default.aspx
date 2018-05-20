<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Interfaces_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <!--Interface Start-->
    <div class="nexusCore_Editor_popControlPanel_wrapper">
        <asp:Image ID="img_ControlIcon" runat="server" Height="64px" Width="64px" CssClass="nexusCore_Editor_popControlPanel_ControlIcon" />
        <div class="nexusCore_Editor_popControlPanel_ControlDescription">
            <asp:Label ID="lbl_ControlName" runat="server" Text="Control Name"></asp:Label>
            (ver1.0.0)<br />
            Author: e2Tech Ltd<br />
            Release Date: 3/4/2011
        </div>
        <hr />
        <h2>
            普通元素</h2>
        需要讨论
        <h2>
            列表元素</h2>
        <p>
            Option 1
            <br />
            <asp:CheckBox ID="CheckBox2" runat="server" CssClass="nexusCore_Editor_popControlPanel_CheckBox"
                Text="Check Box" />
        </p>
        <p>
            Option 1
            <br />
            <asp:CheckBoxList ID="CheckBoxList2" runat="server" CssClass="nexusCore_Editor_popControlPanel_CheckBoxList"
                RepeatDirection="Horizontal">
                <asp:ListItem>List Items</asp:ListItem>
                <asp:ListItem>List Items</asp:ListItem>
            </asp:CheckBoxList>
        </p>
        <p>
            Option 1
            <br />
            <asp:DropDownList ID="DropDownList2" runat="server" CssClass="nexusCore_Editor_popControlPanel_DropDownList">
                <asp:ListItem>List Items</asp:ListItem>
                <asp:ListItem>List Items</asp:ListItem>
                <asp:ListItem>List Items</asp:ListItem>
                <asp:ListItem>List Items</asp:ListItem>
                <asp:ListItem>List Items</asp:ListItem>
                <asp:ListItem>List Items</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p>
            Option 1
            <br />
            <asp:FileUpload ID="FileUpload2" runat="server" CssClass="nexusCore_Editor_popControlPanel_FileUpload" />
        </p>
        <p>
            Option 1
            <br />
            <asp:HyperLink ID="HyperLink2" runat="server" CssClass="nexusCore_Editor_popControlPanel_HyperLink">HyperLink</asp:HyperLink>
        </p>
        <p>
            Option 1
            <br />
            <asp:Image ID="Image2" runat="server" CssClass="nexusCore_Editor_popControlPanel_Image" />
        </p>
        <p>
            Option 1
            <br />
            <asp:ImageButton ID="ImageButton2" runat="server" CssClass="nexusCore_Editor_popControlPanel_ImageButton" />
        </p>
        <p>
            Option 1
            <br />
            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="nexusCore_Editor_popControlPanel_LinkButton">LinkButton</asp:LinkButton>
        </p>
        <p>
            Option 1
            <br />
            <asp:ListBox ID="ListBox2" runat="server" CssClass="nexusCore_Editor_popControlPanel_ListBox">
                <asp:ListItem>List Items</asp:ListItem>
                <asp:ListItem>List Items</asp:ListItem>
                <asp:ListItem>List Items</asp:ListItem>
                <asp:ListItem>List Items</asp:ListItem>
                <asp:ListItem>List Items</asp:ListItem>
                <asp:ListItem>List Items</asp:ListItem>
            </asp:ListBox>
        </p>
        <p>
            Option 1
            <br />
            <asp:RadioButton ID="RadioButton2" runat="server" CssClass="nexusCore_Editor_popControlPanel_RadioButton"
                Text="Radio Button" />
        </p>
        <p>
            Option 1
            <br />
            <asp:RadioButtonList ID="RadioButtonList2" runat="server" CssClass="nexusCore_Editor_popControlPanel_RadioButtonList"
                RepeatDirection="Horizontal">
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem>No</asp:ListItem>
            </asp:RadioButtonList>
        </p>
        <p>
            Option 1
            <br />
            <asp:TextBox ID="TextBox3" runat="server" CssClass="nexusCore_Editor_popControlPanel_TextBox"></asp:TextBox>
        </p>
        <p>
            Option 1
            <br />
            <asp:TextBox ID="TextBox4" runat="server" CssClass="nexusCore_Editor_popControlPanel_TextBoxMultiLine"
                Rows="3" TextMode="MultiLine" Width="500px"></asp:TextBox>
        </p>
        <h2>
            表格元素</h2>
        <table class="nexusCore_Editor_popControlPanel_Table">
            <tr>
                <th>
                    Option 1
                </th>
                <td>
                    <asp:CheckBox ID="CheckBox1" runat="server" CssClass="nexusCore_Editor_popControlPanel_CheckBox"
                        Text="Check Box" />
                </td>
            </tr>
            <tr>
                <th>
                    Option 1
                </th>
                <td>
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" CssClass="nexusCore_Editor_popControlPanel_CheckBoxList"
                        RepeatDirection="Horizontal">
                        <asp:ListItem>List Items</asp:ListItem>
                        <asp:ListItem>List Items</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <th>
                    Option 1
                </th>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="nexusCore_Editor_popControlPanel_DropDownList">
                        <asp:ListItem>List Items</asp:ListItem>
                        <asp:ListItem>List Items</asp:ListItem>
                        <asp:ListItem>List Items</asp:ListItem>
                        <asp:ListItem>List Items</asp:ListItem>
                        <asp:ListItem>List Items</asp:ListItem>
                        <asp:ListItem>List Items</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>
                    Option 1
                </th>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="nexusCore_Editor_popControlPanel_FileUpload" />
                </td>
            </tr>
            <tr>
                <th>
                    Option 1
                </th>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="nexusCore_Editor_popControlPanel_HyperLink">HyperLink</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <th>
                    Option 1
                </th>
                <td>
                    <asp:Image ID="Image1" runat="server" CssClass="nexusCore_Editor_popControlPanel_Image" />
                </td>
            </tr>
            <tr>
                <th>
                    Option 1
                </th>
                <td>
                    <asp:ImageButton ID="ImageButton1" runat="server" CssClass="nexusCore_Editor_popControlPanel_ImageButton" />
                </td>
            </tr>
            <tr>
                <th>
                    Option 1
                </th>
                <td>
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="nexusCore_Editor_popControlPanel_LinkButton">LinkButton</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <th>
                    Option 1
                </th>
                <td>
                    <asp:ListBox ID="ListBox1" runat="server" CssClass="nexusCore_Editor_popControlPanel_ListBox">
                        <asp:ListItem>List Items</asp:ListItem>
                        <asp:ListItem>List Items</asp:ListItem>
                        <asp:ListItem>List Items</asp:ListItem>
                        <asp:ListItem>List Items</asp:ListItem>
                        <asp:ListItem>List Items</asp:ListItem>
                        <asp:ListItem>List Items</asp:ListItem>
                    </asp:ListBox>
                </td>
            </tr>
            <tr>
                <th>
                    Option 1
                </th>
                <td>
                    <asp:RadioButton ID="RadioButton1" runat="server" CssClass="nexusCore_Editor_popControlPanel_RadioButton"
                        Text="Radio Button" />
                </td>
            </tr>
            <tr>
                <th>
                    Option 1
                </th>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="nexusCore_Editor_popControlPanel_RadioButtonList"
                        RepeatDirection="Horizontal">
                        <asp:ListItem>Yes</asp:ListItem>
                        <asp:ListItem>No</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <th>
                    Option 1
                </th>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="nexusCore_Editor_popControlPanel_TextBox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>
                    Option 1
                </th>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" CssClass="nexusCore_Editor_popControlPanel_TextBoxMultiLine"
                        Rows="3" TextMode="MultiLine" Width="500px"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <!--Interface End-->
    </form>
</body>
</html>
