using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TheaterImages
/// </summary>
public class TheaterImages
{
    public int Id { get; set; }
    public string TheaterID { get; set; }
    public string ImageUrl { get; set; }
    public string GalleryOrder { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedIp { get; set; }
    public string AddedBy { get; set; }
    public string Status { get; set; }

    //Extra 
    public string TheaterTitle { get; set; }


    #region Images method

    /// <summary>
    /// Deletes a Images from the database.
    /// </summary>
    /// <param name="conGV">The SQL connection object.</param>
    /// <param name="TheaterImages">A TheaterImages object containing details of the Images to be deleted.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>
    public static int DeleteImages(SqlConnection conGV, TheaterImages TheaterImages)
    {
        int result = 0;
        try
        {
            string query = "Update TheaterImages Set Status=@Status, AddedOn=@AddedOn,AddedBy=@AddedBy, AddedIp=@AddedIp Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = TheaterImages.Id;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = TheaterImages.AddedOn;
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = TheaterImages.AddedBy;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = TheaterImages.AddedIp;
                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteImages", ex.Message);
        }
        return result;
    }

    /// <summary>
    /// Retrieves all details of a Images from the database based on the Images's identifier.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="id">The identifier of the Images.</param>
    /// <returns>A TheaterImages object containing details of the specified Images.</returns>
    public static TheaterImages GetAllTheaterImagessWithId(SqlConnection conSQ, int id)
    {
        var categories = new TheaterImages();
        try
        {
            string query = "Select *,(Select TheaterTitle from TheaterDetails where TheaterID=TheaterDetails.TheaterGuid) as TheaterTitle from TheaterImages where Status='Active' and Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new TheaterImages()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  ImageUrl = Convert.ToString(dr["ImageUrl"]),
                                  TheaterID = Convert.ToString(dr["TheaterID"]),
                                  TheaterTitle = Convert.ToString(dr["TheaterTitle"]),
                                  GalleryOrder = Convert.ToString(dr["GalleryOrder"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedIp = Convert.ToString(dr["AddedIP"]),
                                  AddedBy = Convert.ToString(dr["AddedBy"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAlTheaterImagessWithId", ex.Message);
        }
        return categories;
    }

    /// <summary>
    /// Retrieves details of all TheaterImages from the database.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <returns>A list of TheaterImages objects containing details of all TheaterImages in the database.</returns>
    public static List<TheaterImages> GetAllTheaterImagesWithTheaterID(SqlConnection conSQ, string TheaterID)
    {
        var ListOfBolgs = new List<TheaterImages>();
        try
        {
            string query = "Select *,(Select TheaterTitle from TheaterDetails where TheaterID=TheaterDetails.TheaterGuid) as TheaterTitle from TheaterImages where Status=@Status and TheaterID=@TheaterID Order by GalleryOrder";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                cmd.Parameters.AddWithValue("@TheaterID", SqlDbType.NVarChar).Value = TheaterID;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ListOfBolgs = (from DataRow dr in dt.Rows
                               select new TheaterImages()
                               {
                                   Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                   ImageUrl = Convert.ToString(dr["ImageUrl"]),
                                   TheaterTitle = Convert.ToString(dr["TheaterTitle"]),
                                   TheaterID = Convert.ToString(dr["TheaterID"]),
                                   GalleryOrder = Convert.ToString(dr["GalleryOrder"]),
                                   AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                   AddedIp = Convert.ToString(dr["AddedIP"]),
                                   AddedBy = Convert.ToString(dr["AddedBy"]),
                                   Status = Convert.ToString(dr["Status"])
                               }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllTheaterImagesWithTheaterID", ex.Message);
        }
        return ListOfBolgs;
    }

    /// <summary>
    /// Updates the details of a Images in the database.
    /// </summary>
    /// <param name="conGV">The SQL connection object.</param>
    /// <param name="Images">A TheaterImages object containing updated details of the Images.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>
    public static int UpdateImages(SqlConnection conGV, TheaterImages Images)
    {
        int result = 0;
        try
        {
            string query = "Update TheaterImages Set ImageUrl=@ImageUrl,GalleryOrder=@GalleryOrder,AddedOn=@AddedOn,AddedIp=@AddedIp, AddedBy=@AddedBy Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = Images.Id;
                cmd.Parameters.AddWithValue("@ImageUrl", SqlDbType.NVarChar).Value = Images.ImageUrl;
                cmd.Parameters.AddWithValue("@GalleryOrder", SqlDbType.NVarChar).Value = Images.GalleryOrder;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = DateTime.UtcNow;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = Images.AddedBy;

                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateImages", ex.Message);
        }
        return result;
    }


    public static int UpdateTheaterImagesOrder(SqlConnection conGV, TheaterImages cat)
    {
        int result = 0;
        try
        {
            string query = "Update TheaterImages Set GalleryOrder=@GalleryOrder,AddedOn=@AddedOn,AddedIP=@AddedIP,AddedBy=@AddedBy Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = cat.Id;
                cmd.Parameters.AddWithValue("@GalleryOrder", SqlDbType.NVarChar).Value = cat.GalleryOrder;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = TimeStamps.UTCTime();
                cmd.Parameters.AddWithValue("@AddedIP", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = cat.AddedBy;
                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteTheaterImages", ex.Message);
        }
        return result;
    }


    /// <summary>
    /// Adds a new Images to the database.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="Images">A TheaterImages object containing details of the Images to be added.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>
    public static int AddImages(SqlConnection conSQ, TheaterImages Images)
    {
        int result = 0;
        try
        {
            string query = "Insert Into TheaterImages (ImageUrl,GalleryOrder,TheaterID,AddedOn,AddedIP,Status,AddedBy) values (@ImageUrl,@GalleryOrder,@TheaterID,@AddedOn,@AddedIP,@Status,@AddedBy)";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@ImageUrl", SqlDbType.NVarChar).Value = Images.ImageUrl;
                cmd.Parameters.AddWithValue("@GalleryOrder", SqlDbType.NVarChar).Value = Images.GalleryOrder;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = Images.AddedBy;
                cmd.Parameters.AddWithValue("@TheaterID", SqlDbType.NVarChar).Value = Images.TheaterID;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = TimeStamps.UTCTime();
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = Images.Status;
                conSQ.Open();
                result = Convert.ToInt32(cmd.ExecuteNonQuery());
                conSQ.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "AddImages", ex.Message);
        }
        return result;
    }

    #endregion
}