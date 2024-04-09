using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class blog_details : System.Web.UI.Page
{
    SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
    public string StrBlogTitle = "", strBlogUrl, StrPostedOn, StrCategory, StrPrev, StrNext, StrPostedBy, StrBlogImage, StrBlogDesc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        strBlogUrl = Convert.ToString(RouteData.Values["BUrl"]);
        if (strBlogUrl != "")
        {
            BindBlogDetails();

        }
    }
    public void BindBlogDetails()
    {
        try
        {
            BlogDetails lst = BlogDetails.GetAllBlogDetailsWithUrl(conSQ, strBlogUrl).FirstOrDefault();
            if (lst != null)
            {
                StrBlogDesc = lst.FullDesc;
                StrBlogTitle = lst.BlogTitle;
                StrPostedOn = lst.PostedOn.ToString("MMMM dd, yyyy");
                StrCategory = lst.Category;
                StrBlogImage = "<img src='/" + lst.BlogImage + @"' alt='" + lst.BlogTitle + @"' class='img-fluid' />";
                Page.Title = lst.PageTitle;
                Page.MetaDescription = lst.MetaDesc;
                Page.MetaKeywords = lst.MetaKeys;
                //OtherBlogs(lst.Id);
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindBlogDetails", ex.Message);
        }
    }

}