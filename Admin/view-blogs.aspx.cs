using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_view_blogs : System.Web.UI.Page
{
    public string strBlogs = "";
    SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetAllDetails();

        }
    }
    public void GetAllDetails()
    {
        try
        {
            strBlogs = "";
            List<BlogDetails> BD = BlogDetails.GetAllBlogDetails(conSQ).ToList();
            for (int i = 0; i < BD.Count; i++)
            {
                strBlogs += @"<tr>
                                        <td>" + (i + 1) + @"</td>
                                        <td><a href='/" + BD[i].ThumbImage + @"'/><img src='/" + BD[i].ThumbImage + @"' style='height:60px;' /></td>
                                        <td><a href='/" + BD[i].BlogImage + @"'/><img src='/" + BD[i].BlogImage + @"' style='height:60px;' /></td>
                                        <td>" + BD[i].BlogTitle + @"</td>
                                        <td>" + BD[i].AddedBy + @"</td>
                                         <td>" + BD[i].AddedOn.ToString("dd/MMM/yyyy") + @"</td>
                                        <td class='text-center'> 
                                            <a href='add-blog.aspx?id=" + BD[i].Id + @"' class='bs-tooltip text-info fs-18' data-id='" + BD[i].Id + @"' data-toggle='tooltip' data-placement='top' title='Edit' data-original-title='Edit'>
                                               <i class='mdi mdi-pencil'></i></a>
                                            <a href='javascript:void(0);' class='bs-tooltip deleteItem warning confirm text-danger fs-18' data-id='" + BD[i].Id + @"' data-toggle='tooltip' data-placement='top' title='Delete' data-original-title='Delete'>
                                               <i class='mdi mdi-delete-forever'></i></a></a>    </td>
                                            </tr>";

            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllDetails", ex.Message);
        }
    }
    [WebMethod(EnableSession = true)]
    public static string Delete(string id)
    {
        string x = "";
        try
        {
            SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
            BlogDetails BD = new BlogDetails();
            BD.Id = Convert.ToInt32(id);
            BD.AddedOn = TimeStamps.UTCTime();
            BD.AddedIP = CommonModel.IPAddress();
            int exec = BlogDetails.DeleteBlogDetails(conSQ, BD);
            if (exec > 0)
            {
                x = "Success";
            }
            else
            {
                x = "W";
            }

        }
        catch (Exception ex)
        {
            x = "W";
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "Delete", ex.Message);
        }
        return x;
    }
}