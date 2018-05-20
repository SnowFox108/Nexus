<%@ Control Language="C#" %>
    <div class="box post">
        <div class="content">
            <div class="post-title">
                <h2>
                    <%# Eval("News_Title")%>
                </h2>
            </div>
            <!--/post-title -->
            <div>
                <div class="post-date">
                    On <%# Eval("News_Date")%> by <%# Eval("UserName")%>
                </div>
                <!--/post-date -->
            </div>
            <div class="bg">
            </div>
            <div class="post-excerpt" style="text-align:justify;">
                <%# Eval("News_Content")%>
            </div>
            <!--/post-excerpt -->
            <div class="post_leave">
<asp:Panel ID="Panel_Original_Source" Visible='<%# Eval("Show_Originality") %>' runat="server">
    <asp:Label ID="lbl_Author" Visible='<%# !DataEval.IsEmptyQuery(Eval("Author").ToString()) %>'
        Text='<%# "Author: " + Eval("Author")%>' runat="server"></asp:Label>
    <asp:Label ID="lbl_Source_Name" Visible='<%# !DataEval.IsEmptyQuery(Eval("Source_Name").ToString()) %>'
        Text=' <%# "Source: " + Eval("Source_Name_URL")%>' runat="server"></asp:Label>
</asp:Panel>
            </div>
            <div class="clr">
            </div>
        </div>
        <!--/content -->
    </div>