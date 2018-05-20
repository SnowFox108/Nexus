<%@ Page Language="C#" MasterPageFile="~/App_AdminCP/SiteAdmin/MasterPage_AdminCP.master"
    AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="App_AdminCP_SiteAdmin_Default"
    StylesheetTheme="NexusCore" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_MainContent"
    runat="Server">
    <div id="singleMain">
        <!--这里放一个短信显示用于以后推送我们服务器给客户的信息.没有的时候为空白,不占空间.
<hr />
这里放一个DashBoard. 想做IPhone风格那样. 第一行4个固定图标. 往后为8-12个图标. 每装载一个模块这里就会显示一个图标, 点击图标进入该模块管理页面.
<hr />
最近的页面改动情况-->
        <div align="right">
            <img style="margin-right: 300px;" src="/App_Control_Style/NexusCore/Images/topArrow.png"
                alt="topArrow" /></div>
        <div align="center">
            <h1 style="margin-top: 20px;">
                Please use the menu above to manage your website!</h1>
        </div>
    </div>
</asp:Content>
