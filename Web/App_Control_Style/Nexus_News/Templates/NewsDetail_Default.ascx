<%@ Control Language="C#" %>
<div>
    Posted on
    <%# Eval("News_Date")%><asp:Label ID="lbl_News_Date" runat="server"></asp:Label>
    by
    <%# Eval("UserName")%><asp:Label ID="lbl_UserName" runat="server"></asp:Label>
</div>
<h1>
    <%# Eval("News_Title")%><asp:Label ID="lbl_Title" runat="server"></asp:Label></h1>
<div>
    <%# Eval("News_Content")%><asp:Literal ID="Literal_Content" runat="server"></asp:Literal></div>
<div>
    Last updated at:
    <%# Eval("News_ModifyDate")%><asp:Label ID="lbl_Post_ModifyDate" runat="server"></asp:Label></div>
<asp:Panel ID="Panel_Original_Source" Visible='<%# Eval("Show_Originality") %>' runat="server">
    <asp:Label ID="lbl_Author" Visible='<%# !DataEval.IsEmptyQuery(Eval("Author").ToString()) %>'
        Text='<%# "Author: " + Eval("Author")%>' runat="server"></asp:Label>
    <asp:Label ID="lbl_Source_Name" Visible='<%# !DataEval.IsEmptyQuery(Eval("Source_Name").ToString()) %>'
        Text=' <%# "Source: " + Eval("Source_Name_URL")%>' runat="server"></asp:Label>
</asp:Panel>
<hr />
