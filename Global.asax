<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>

<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        RegisterProducts(RouteTable.Routes);

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

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
    void RegisterProducts(RouteCollection routes)
    {
        routes.Clear();
        //routes.Ignore("{resource}.axd/{*pathInfo}");
        routes.MapPageRoute("/404", "404", "~/404.aspx");
        routes.MapPageRoute("Blogs", "blog/{BUrl}", "~/blog-details.aspx");
        routes.MapPageRoute("Booking Details", "booking/{AUrl}/{TUrl}", "~/details.aspx");
        routes.MapPageRoute("Theater Listing", "theaters/{AUrl}", "~/theater-list.aspx");
        routes.MapPageRoute("Add On", "add-on/{BUrl}", "~/add-on.aspx");
        //routes.MapPageRoute("Group", "destinations/{DType}", "~/destinations.aspx");
        //routes.MapPageRoute("Destination", "destination/{DUrl}", "~/destination-detail.aspx");
        //routes.MapPageRoute("ThemeDestination", "destination/{DUrl}/{TUrl}", "~/destination-detail.aspx");
        //routes.MapPageRoute("Cruise", "theme/cruise", "~/cruise-page.aspx");
        //routes.MapPageRoute("Theme", "theme/{TUrl}", "~/travel-theme.aspx");
        //routes.MapPageRoute("Tour", "tour/{TUrl}", "~/tour-detail.aspx");
        //routes.MapPageRoute("Products2", "Products/{CName}/{SCName}", "~/products2.aspx")
    }

</script>
