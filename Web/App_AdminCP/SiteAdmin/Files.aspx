<%@ Page Language="C#" MasterPageFile="~/App_AdminCP/SiteAdmin/MasterPage_AdminCP_Rad.master"
    AutoEventWireup="true" CodeFile="Files.aspx.cs" Inherits="Nexus.Core.App_AdminCP_SiteAdmin_Files"
    Title="Website Control Panel - Files" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/App_Themes/NexusCore/Global.css" type="text/css" rel="stylesheet" />
    <link href="/App_Themes/NexusCore/Header.css" type="text/css" rel="stylesheet" />
    <link href="/App_Themes/NexusCore/Default.css" type="text/css" rel="stylesheet" />
    <link href="/App_Themes/NexusCore/Files.css" type="text/css" rel="stylesheet" />
    <link href="/App_Themes/NexusCore/Menu/Menu.SiteAdmin.css" type="text/css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MainContent"
    runat="Server">
    <div id="singleMain">
        <telerik:RadTabStrip ID="RadTabStrip_Files" runat="server" OnTabClick="RadTabStrip_Files_TabClick"
            Skin="WebBlue">
            <Tabs>
                <telerik:RadTab runat="server" Text="Images" Value="Images">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="Media" Value="Media">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="Documents" Value="Documents">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="Templates" Value="Templates">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="Module Templates" Value="ModuleTemplates">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="All Files" Value="AllFiles">
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>
        <div class="fileExplorer">
            <div class="inner">
                <telerik:RadFileExplorer ID="RadFileExplorer_Files" runat="server" Width="100%" Skin="WebBlue"
                    BorderWidth="0">
                </telerik:RadFileExplorer>
            </div>
        </div>
    </div>
</asp:Content>
