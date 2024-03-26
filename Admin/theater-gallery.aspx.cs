using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_theater_galllery : System.Web.UI.Page
{
    SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
    public string StrTheater = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        BindTheaterName();
    }

    public void BindTheaterName()
    {
        try
        {
            if (Request.QueryString["tid"] != null)
            {
                var theater = TheaterDetails.GetAllTheaterDetailsWithGuid(conSQ, Request.QueryString["tid"].ToString());
                if (theater != null)
                {
                    StrTheater = theater.TheaterTitle.ToString();
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindTheaterName", ex.Message);

        }
    }

    [WebMethod(EnableSession = true)]
    public static List<TheaterImages> GetGalleryImage(string Tid)
    {
        try
        {
            SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
            var list = TheaterImages.GetAllTheaterImagesWithTheaterID(conSQ, Tid);
            if (list != null && list.Count > 0)
            {
                return list;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetGalleryImage", ex.Message);
        }

        return null;
    }

    [WebMethod(EnableSession = true)]
    public static string ImageOrderUpdate(string id)
    {
        string x = "";
        try
        {
            string[] str = id.Split('|');
            SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);

            for (int i = 0; i < str.Length; i++)
            {
                TheaterImages catG = new TheaterImages();
                catG.Id = str[i] == "" ? 0 : Convert.ToInt32(str[i]);
                catG.GalleryOrder = Convert.ToString(i);
                catG.AddedBy = HttpContext.Current.Request.Cookies["nt_aid"].Value;
                int res = TheaterImages.UpdateTheaterImagesOrder(conSQ, catG);
                if (res > 0)
                {
                    x = "Success";
                }
                else
                {
                    x = "W";

                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "ImageOrderUpdate", ex.Message);
            x = "W";
        }

        return x;
    }


    [WebMethod(EnableSession = true)]
    public static string DeleteImage(string id)
    {
        string x = "";
        try
        {
            SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
            TheaterImages img = new TheaterImages();
            img.Id = Convert.ToInt32(id);
            img.AddedOn = TimeStamps.UTCTime();
            img.AddedIp = CommonModel.IPAddress();
            img.AddedBy = HttpContext.Current.Request.Cookies["nt_aid"].Value;
            int exec = TheaterImages.DeleteImages(conSQ, img);
            if (exec > 0)
            {
                x = "Success";
            }


        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteImage", ex.Message);
        }
        return x;
    }
}