<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PageMenu.ascx.cs" Inherits="Nexus.Core.App_AdminCP_SiteAdmin_Pages_PageMenu" %>
<telerik:RadTreeView ID="RadTreeView_WebSite" runat="server" EnableDragAndDrop="True"
    EnableDragAndDropBetweenNodes="True" OnNodeDrop="RadTreeView_WebSite_NodeDrop"
    OnNodeExpand="RadTreeView_WebSite_NodeExpand" Skin="Black" EnableEmbeddedSkins="False"
    OnNodeClick="RadTreeView_WebSite_NodeClick">
</telerik:RadTreeView>
