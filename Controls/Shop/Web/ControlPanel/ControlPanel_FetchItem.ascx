<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ControlPanel_FetchItem.ascx.cs"
    Inherits="Nexus.Controls.Ebay.ControlPanel.FetchItem" ClassName="Nexus.Controls.Ebay.ControlPanel.ControlPanel_FetchItem" %>
<asp:UpdatePanel ID="UpdatePanel_Progress" runat="server">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="Timer_UpdatePanel" EventName="Tick" />
    </Triggers>
    <ContentTemplate>
        <asp:Label ID="lbl_FetchInfo" runat="server"></asp:Label>
        <table border="1" width="500px">
            <tr>
                <td>
                    <asp:Panel ID="Panel_Progress" runat="server" BackColor="Lime" Height="15px" Width="1px">
                    <div style="text-align:right;"> <asp:Label ID="lbl_percent" runat="server"></asp:Label></div>
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <asp:UpdateProgress ID="UpdateProgress_Updating" runat="server">
            <ProgressTemplate>
                <div style="float: left">
                    <img src="/App_Control_Style/Nexus_Ebay/Images/progressBar.gif" alt="updating..." />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:LinkButton ID="lbtn_Submit" runat="server" OnClick="lbtn_Submit_Click">OK</asp:LinkButton>
        <asp:Timer ID="Timer_UpdatePanel" runat="server" Interval="100" OnTick="Timer_UpdatePanel_Tick">
        </asp:Timer>
    </ContentTemplate>
</asp:UpdatePanel>
