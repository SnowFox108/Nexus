<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TextEditor.ascx.cs" Inherits="Nexus.Core.UI.Modules_TextEditor"
    ClassName="Nexus.Core.UI.TextEditor" %>
<telerik:RadTabStrip ID="RadTabStrip_EditorBar" runat="server" OnTabClick="RadTabStrip_EditorBar_TabClick"
    SelectedIndex="0" CausesValidation="False">
    <Tabs>
        <telerik:RadTab runat="server" Selected="True" Text="Basic" Value="Basic">
        </telerik:RadTab>
        <telerik:RadTab runat="server" Text="Advanced" Value="Default">
        </telerik:RadTab>
    </Tabs>
</telerik:RadTabStrip>
<telerik:RadEditor ID="RadEditor_TextContent" runat="server">
</telerik:RadEditor>
