using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class blog : System.Web.UI.Page
{
    SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
    public string StrBlogs = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindBlogs();
        }

    }
    public void BindBlogs()
    {
        try
        {
            var Blog = BlogDetails.GetAllBlogDetails(conSQ);
            if (Blog != null)
            {
                for (int i = 0; i < Blog.Count; i++)
                {
                    StrBlogs += @"<div class='col-lg-4 col-md-6 col-sm-12'>
                    <div class='blog-grid-item'>
                        <div class='blog-image'>
                            <img src='/" + Blog[i].ThumbImage + @"' alt='" + Blog[i].BlogTitle + @"'>
                            <a href='/blog/" + Blog[i].BlogUrl + @"'></a>
                        </div>
                        <div class='blog-content'>

                            <h4 class='blog-title'>" + Blog[i].BlogTitle + @"</h4>
                            <a href='/blog/" + Blog[i].BlogUrl + @"' class='custom-btn'>Read More
                            </a>
                        </div>

                    </div>
                </div>";
                }
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindBlogs", ex.Message);

        }
    }
}