﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageMenuList.ascx.cs" Inherits="Nexus.Core.App_AdminCP_SiteAdmin_Pages_PageMenuList" %>
<asp:DataList ID="DataList_PageMenuList" runat="server" 
    onselectedindexchanged="DataList_PageMenuList_SelectedIndexChanged">
    <ItemTemplate>
        <img src='<%# Eval("IconUrl") %>' alt='<%# Eval("Menu_Title")%>' />
        <asp:LinkButton ID="lbtn_PageIndex" runat="server" CommandArgument='<%# Eval("PageIndexID") %>' 
            CommandName="Select"><%# Eval("Menu_Title")%></asp:LinkButton>
    </ItemTemplate>
</asp:DataList>