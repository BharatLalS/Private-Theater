using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BlogDetails
/// </summary>
public class BlogDetails
{
    public BlogDetails()
    {

    }

    #region Blog Details Properties
    public int Id { get; set; }
    public string ThumbImage { get; set; }
    public string BlogImage { get; set; }
    public string BlogTitle { get; set; }
    public string BlogUrl { get; set; }
    public string PageTitle { get; set; }
    public string MetaKeys { get; set; }
    public string MetaDesc { get; set; }
    public string FullDesc { get; set; }
    public string AddedBy { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedIP { get; set; }
    public string Status { get; set; }
    #endregion
    #region Blogs Methods
    public static List<BlogDetails> GetAllBlogDetailsWithId(SqlConnection conDT, int id)
    {
        List<BlogDetails> categories = new List<BlogDetails>();
        try
        {
            string query = "Select * from BlogDetails where Status=@Status and Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conDT))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new BlogDetails()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  BlogImage = Convert.ToString(dr["BlogImage"]),
                                  ThumbImage = Convert.ToString(dr["ThumbImage"]),
                                  BlogTitle = Convert.ToString(dr["BlogTitle"]),
                                  BlogUrl = Convert.ToString(dr["BlogUrl"]),
                                  PageTitle = Convert.ToString(dr["PageTitle"]),
                                  MetaKeys = Convert.ToString(dr["MetaKeys"]),
                                  MetaDesc = Convert.ToString(dr["MetaDesc"]),
                                  FullDesc = Convert.ToString(dr["FullDesc"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedBy = Convert.ToString(dr["AddedBy"]),
                                  AddedIP = Convert.ToString(dr["AddedIP"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllBlogDetailsWithId", ex.Message);
        }
        return categories;
    }
    public static List<BlogDetails> GetAllBlogDetailsWithUrl(SqlConnection conDT, string Url)
    {
        List<BlogDetails> categories = new List<BlogDetails>();
        try
        {
            string query = "Select * from BlogDetails where Status=@Status and BlogUrl=@BlogUrl ";
            using (SqlCommand cmd = new SqlCommand(query, conDT))
            {
                cmd.Parameters.AddWithValue("@BlogUrl", SqlDbType.Int).Value = Url;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new BlogDetails()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  BlogImage = Convert.ToString(dr["BlogImage"]),
                                  ThumbImage = Convert.ToString(dr["ThumbImage"]),
                                  BlogTitle = Convert.ToString(dr["BlogTitle"]),
                                  BlogUrl = Convert.ToString(dr["BlogUrl"]),
                                  PageTitle = Convert.ToString(dr["PageTitle"]),
                                  MetaKeys = Convert.ToString(dr["MetaKeys"]),
                                  MetaDesc = Convert.ToString(dr["MetaDesc"]),
                                  FullDesc = Convert.ToString(dr["FullDesc"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedBy = Convert.ToString(dr["AddedBy"]),
                                  AddedIP = Convert.ToString(dr["AddedIP"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllBlogDetailsWithId", ex.Message);
        }
        return categories;
    }
    public static List<BlogDetails> GetAllBlogDetails(SqlConnection conDT)
    {
        List<BlogDetails> categories = new List<BlogDetails>();
        try
        {
            string query = "Select *,(Select UserName from CreateUser Where UserGuid=BlogDetails.AddedBy) as UpdatedBy from BlogDetails where Status=@Status Order by Id ";
            using (SqlCommand cmd = new SqlCommand(query, conDT))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new BlogDetails()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  BlogImage = Convert.ToString(dr["BlogImage"]),
                                  ThumbImage = Convert.ToString(dr["ThumbImage"]),
                                  BlogTitle = Convert.ToString(dr["BlogTitle"]),
                                  BlogUrl = Convert.ToString(dr["BlogUrl"]),
                                  PageTitle = Convert.ToString(dr["PageTitle"]),
                                  MetaKeys = Convert.ToString(dr["MetaKeys"]),
                                  MetaDesc = Convert.ToString(dr["MetaDesc"]),
                                  FullDesc = Convert.ToString(dr["FullDesc"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedBy = Convert.ToString(dr["UpdatedBy"]),
                                  AddedIP = Convert.ToString(dr["AddedIP"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllJobBlogDetails", ex.Message);
        }
        return categories;
    }
    public static int InsertBlogDetails(SqlConnection conGV, BlogDetails cat)
    {
        int result = 0;

        try
        {
            string query = "Insert Into BlogDetails (ThumbImage,BlogImage,BlogTitle,BlogUrl,PageTitle,MetaKeys,MetaDesc,FullDesc,AddedOn,AddedBy,AddedIP,Status) values (@ThumbImage,@BlogImage,@BlogTitle,@BlogUrl,@PageTitle,@MetaKeys,@MetaDesc,@FullDesc,@AddedOn,@AddedBy,@AddedIP,@Status) ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@ThumbImage", SqlDbType.NVarChar).Value = cat.ThumbImage;
                cmd.Parameters.AddWithValue("@BlogImage", SqlDbType.NVarChar).Value = cat.BlogImage;
                cmd.Parameters.AddWithValue("@BlogTitle", SqlDbType.NVarChar).Value = cat.BlogTitle;
                cmd.Parameters.AddWithValue("@BlogUrl", SqlDbType.NVarChar).Value = cat.BlogUrl;
                cmd.Parameters.AddWithValue("@PageTitle", SqlDbType.NVarChar).Value = cat.PageTitle;
                cmd.Parameters.AddWithValue("@MetaKeys", SqlDbType.NVarChar).Value = cat.MetaKeys;
                cmd.Parameters.AddWithValue("@MetaDesc", SqlDbType.NVarChar).Value = cat.MetaDesc;
                cmd.Parameters.AddWithValue("@FullDesc", SqlDbType.NVarChar).Value = cat.FullDesc;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.DateTime).Value = cat.AddedOn;
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = cat.AddedBy;
                cmd.Parameters.AddWithValue("@AddedIP", SqlDbType.NVarChar).Value = cat.AddedIP;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertBlogDetails", ex.Message);
        }
        return result;
    }

    /// <summary>
    /// Update an specific Job BlogDetails 
    /// </summary>
    /// <param name="conGV">DB Connection</param>
    /// <param name="cat">Job BlogDetails  properties</param>
    /// <returns>No of rows executed</returns>
    public static int UpdateBlogDetails(SqlConnection conGV, BlogDetails cat)
    {
        int result = 0;
        try
        {
            string query = "Update BlogDetails Set ThumbImage=@ThumbImage,BlogImage=@BlogImage,BlogTitle=@BlogTitle,BlogUrl=@BlogUrl,PageTitle=@PageTitle,MetaKeys=@MetaKeys,MetaDesc=@MetaDesc,FullDesc=@FullDesc,AddedOn=@AddedOn,AddedBy=@AddedBy,AddedIP=@AddedIP Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = cat.Id;
                cmd.Parameters.AddWithValue("@ThumbImage", SqlDbType.NVarChar).Value = cat.ThumbImage;
                cmd.Parameters.AddWithValue("@BlogImage", SqlDbType.NVarChar).Value = cat.BlogImage;
                cmd.Parameters.AddWithValue("@BlogTitle", SqlDbType.NVarChar).Value = cat.BlogTitle;
                cmd.Parameters.AddWithValue("@BlogUrl", SqlDbType.NVarChar).Value = cat.BlogUrl;
                cmd.Parameters.AddWithValue("@PageTitle", SqlDbType.NVarChar).Value = cat.PageTitle;
                cmd.Parameters.AddWithValue("@MetaKeys", SqlDbType.NVarChar).Value = cat.MetaKeys;
                cmd.Parameters.AddWithValue("@MetaDesc", SqlDbType.NVarChar).Value = cat.MetaDesc;
                cmd.Parameters.AddWithValue("@FullDesc", SqlDbType.NVarChar).Value = cat.FullDesc;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.DateTime).Value = cat.AddedOn;
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = cat.AddedBy;
                cmd.Parameters.AddWithValue("@AddedIP", SqlDbType.NVarChar).Value = cat.AddedIP;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateBlogDetails", ex.Message);
        }
        return result;
    }

    /// <summary>
    /// Delete a specific Job BlogDetails  (Update status as delete)
    /// </summary>
    /// <param name="conGV">DB Connection</param>
    /// <param name="cat">Job BlogDetails  properties</param>
    /// <returns>No of rows executed</returns>
    public static int DeleteBlogDetails(SqlConnection conGV, BlogDetails cat)
    {
        int result = 0;
        try
        {
            string query = "Update BlogDetails Set Status=@Status, AddedOn=@AddedOn, AddedIP=@AddedIP Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = cat.Id;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = cat.AddedOn;
                cmd.Parameters.AddWithValue("@AddedIP", SqlDbType.NVarChar).Value = cat.AddedIP;
                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteBlogDetails", ex.Message);
        }
        return result;
    }
    #endregion

}