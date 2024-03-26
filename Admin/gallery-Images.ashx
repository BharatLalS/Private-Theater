<%@ WebHandler Language="C#" Class="Gallery_Images" %>

using System;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public class Gallery_Images : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        if (context.Request.Files.Count > 0)
        {
            SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);

            string strtid = context.Request["tid"];

            HttpFileCollection files = context.Request.Files;
            int x = 0;
            for (int i = 0; i < files.Count; i++)
            {
                HttpPostedFile file = files[i];
                string fileExtension = Path.GetExtension(file.FileName.ToLower()), ImageGuid1 = Guid.NewGuid().ToString();
                string iconPath = context.Server.MapPath(".") + "\\../UploadImages\\" + ImageGuid1 + "_gallery" + fileExtension;
                if ((fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png" || fileExtension == ".webp" || fileExtension == ".gif"))
                {
                    if (fileExtension == ".webp")
                    {
                        file.SaveAs(iconPath);
                    }
                    else
                    {
                        System.Drawing.Bitmap bmpPostedImageBig = new System.Drawing.Bitmap(file.InputStream);
                        System.Drawing.Image objImagesmallBig = CommonModel.ScaleImageBig(bmpPostedImageBig, bmpPostedImageBig.Height, bmpPostedImageBig.Width);

                        if (fileExtension == ".png")
                        {
                            CommonModel.SavePNG(iconPath, objImagesmallBig, 80);

                        }
                        else if (fileExtension == ".gif")
                        {
                            file.SaveAs(iconPath);
                        }

                        else
                        {
                            CommonModel.SaveJpeg(iconPath, objImagesmallBig, 80);

                        }


                    }

                    string bImage = "UploadImages/" + ImageGuid1 + "_gallery" + fileExtension;
                    TheaterImages pi = new TheaterImages();
                    pi.AddedBy = HttpContext.Current.Request.Cookies["nt_aid"].Value;
                    pi.TheaterID = Convert.ToString(strtid);
                    pi.GalleryOrder = "1000";
                    pi.ImageUrl = bImage;
                    pi.Status = "Active";
                    x += TheaterImages.AddImages(conSQ, pi);


                }
            }
            if (x > 0)
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("Success|" + x);
            }
            else
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("Error|");
            }

        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}