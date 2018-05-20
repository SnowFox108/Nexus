<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs
        if (IsMaxRequestExceededEexception(this.Server.GetLastError())) 
        { 
            this.Server.ClearError();
            this.Server.Transfer("~/App_AdminCP/Error_MaxUploadLength.aspx"); 
        } 
    }
        
    const int TimedOutExceptionCode = -2147467259;
    public static bool IsMaxRequestExceededEexception(Exception e) 
    {     
        // unhandeled errors = caught at global.ascx level     
        // http exception = caught at page level     
        Exception main;     
        var unhandeled = e as HttpUnhandledException;     
        if (unhandeled != null && unhandeled.ErrorCode == TimedOutExceptionCode)     
        {     
            main = unhandeled.InnerException;     
        }     
        else     
        {     
            main = e;     
        }      
        var http = main as HttpException;     
        if (http != null && http.ErrorCode == TimedOutExceptionCode)     
        {     
            // hack: no real method of identifing if the error is max request exceeded as      
            // it is treated as a timeout exception     
            if (http.StackTrace.Contains("GetEntireRawContent"))     
            {     
                // MAX REQUEST HAS BEEN EXCEEDED     
                return true;     
            }     
        }      
        return false; 
    } 
    
    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>
