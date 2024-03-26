using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AddOnCategories
/// </summary>
public class AddOnCategories
{
    public int Id { get; set; }
    public string CategoryTitle { get; set; }
    public string CategoryUrl { get; set; }
    public string CategoryGuid { get; set; }
    public string CategoryOrder { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedIp { get; set; }
    public string AddedBy { get; set; }
    public string Status { get; set; }

    #region Category method
    /// <summary>
    /// Deletes a Category from the database.
    /// </summary>
    /// <param name="conGV">The SQL connection object.</param>
    /// <param name="AddOnCategories">A AddOnCategories object containing details of the Category to be deleted.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>
    public static int DeleteCategory(SqlConnection conGV, AddOnCategories AddOnCategories)
    {
        int result = 0;
        try
        {
            string query = "Update AddOnCategories Set Status=@Status, AddedOn=@AddedOn, AddedIp=@AddedIp Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = AddOnCategories.Id;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = AddOnCategories.AddedOn;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = AddOnCategories.AddedIp;
                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteCategory", ex.Message);
        }
        return result;
    }

    /// <summary>
    /// Retrieves all details of a Category from the database based on the Category's identifier.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="id">The identifier of the Category.</param>
    /// <returns>A AddOnCategories object containing details of the specified Category.</returns>

    public static AddOnCategories GetAllCategoryDetailsWithId(SqlConnection conSQ, int id)
    {
        var categories = new AddOnCategories();
        try
        {
            string query = "Select * from AddOnCategories where Status='Active' and Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new AddOnCategories()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  CategoryTitle = Convert.ToString(dr["CategoryTitle"]),
                                  CategoryUrl = Convert.ToString(dr["CategoryUrl"]),
                                  CategoryGuid = Convert.ToString(dr["CategoryGuid"]),
                                  CategoryOrder = Convert.ToString(dr["CategoryOrder"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedIp = Convert.ToString(dr["AddedIP"]),
                                  AddedBy = Convert.ToString(dr["AddedBy"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAlCategoryDetailsWithId", ex.Message);
        }
        return categories;
    }

    /// <summary>
    /// Retrieves all details of a Category from the database based on the Category's identifier.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="id">The identifier of the Category.</param>
    /// <returns>A AddOnCategories object containing details of the specified Category.</returns>

    public static AddOnCategories GetAllCategoryDetailsWithUrl(SqlConnection conSQ, string url)
    {
        var categories = new AddOnCategories();
        try
        {
            string query = "Select * from AddOnCategories where Status=@Status and CategoryUrl=@CategoryUrl";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                cmd.Parameters.AddWithValue("@CategoryUrl", SqlDbType.NVarChar).Value = url;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new AddOnCategories()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  CategoryTitle = Convert.ToString(dr["CategoryTitle"]),
                                  CategoryUrl = Convert.ToString(dr["CategoryUrl"]),
                                  CategoryGuid = Convert.ToString(dr["CategoryGuid"]),
                                  CategoryOrder = Convert.ToString(dr["CategoryOrder"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedIp = Convert.ToString(dr["AddedIP"]),
                                  AddedBy = Convert.ToString(dr["AddedBy"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAlCategoryDetailsWithId", ex.Message);
        }
        return categories;
    }
    /// <summary>
    /// Retrieves details of all AddOnCategories from the database.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <returns>A list of AddOnCategories objects containing details of all AddOnCategories in the database.</returns>

    public static List<AddOnCategories> GetAllAddOnCategories(SqlConnection conSQ)
    {
        var ListOfBolgs = new List<AddOnCategories>();
        try
        {
            string query = "Select * from AddOnCategories where Status=@Status Order by Id";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ListOfBolgs = (from DataRow dr in dt.Rows
                               select new AddOnCategories()
                               {
                                   Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                   CategoryTitle = Convert.ToString(dr["CategoryTitle"]),
                                   CategoryUrl = Convert.ToString(dr["CategoryUrl"]),
                                   CategoryGuid = Convert.ToString(dr["CategoryGuid"]),
                                   CategoryOrder = Convert.ToString(dr["CategoryOrder"]),
                                   AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                   AddedIp = Convert.ToString(dr["AddedIP"]),
                                   AddedBy = Convert.ToString(dr["AddedBy"]),
                                   Status = Convert.ToString(dr["Status"])
                               }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllAddOnCategories", ex.Message);
        }
        return ListOfBolgs;
    }
    /// <summary>
    /// Updates the details of a Category in the database.
    /// </summary>
    /// <param name="conGV">The SQL connection object.</param>
    /// <param name="Category">A AddOnCategories object containing updated details of the Category.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>

    public static int UpdateCategory(SqlConnection conGV, AddOnCategories Category)
    {
        int result = 0;
        try
        {
            string query = "Update AddOnCategories Set CategoryTitle=@CategoryTitle,CategoryUrl=@CategoryUrl,AddedOn=@AddedOn,AddedIp=@AddedIp, AddedBy=@AddedBy Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = Category.Id;
                cmd.Parameters.AddWithValue("@CategoryTitle", SqlDbType.NVarChar).Value = Category.CategoryTitle;
                cmd.Parameters.AddWithValue("@CategoryUrl", SqlDbType.NVarChar).Value = Category.CategoryUrl;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = DateTime.UtcNow;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = Category.AddedBy;

                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateCategory", ex.Message);
        }
        return result;
    }
    /// <summary>
    /// Adds a new Category to the database.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="Category">A AddOnCategories object containing details of the Category to be added.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>
    public static int AddCategory(SqlConnection conSQ, AddOnCategories Category)
    {
        int result = 0;
        try
        {
            string query = "Insert Into AddOnCategories (CategoryTitle,CategoryUrl,CategoryGuid,AddedOn,AddedIP,Status,AddedBy) values (@CategoryTitle,@CategoryUrl,@CategoryGuid,@AddedOn,@AddedIP,@Status,@AddedBy) select SCOPE_IDENTITY()";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@CategoryTitle", SqlDbType.NVarChar).Value = Category.CategoryTitle;
                cmd.Parameters.AddWithValue("@CategoryUrl", SqlDbType.NVarChar).Value = Category.CategoryUrl;
                cmd.Parameters.AddWithValue("@CategoryGuid", SqlDbType.NVarChar).Value = Category.CategoryGuid;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = Category.AddedBy;
                cmd.Parameters.AddWithValue("@CategoryOrder", SqlDbType.NVarChar).Value = Category.CategoryOrder;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = DateTime.UtcNow;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = Category.Status;
                conSQ.Open();
                result = Convert.ToInt32(cmd.ExecuteNonQuery());
                conSQ.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "AddCategory", ex.Message);
        }
        return result;
    }

    public static int UpdateCategoryOrder(SqlConnection conGV, AddOnCategories cat)
    {
        int result = 0;
        try
        {
            string query = "Update AddOnCategories Set AddedOn=@AddedOn,AddedIp=@AddedIp,CategoryOrder=@CategoryOrder Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = cat.Id;
                cmd.Parameters.AddWithValue("@CategoryOrder", SqlDbType.NVarChar).Value = cat.CategoryOrder;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = TimeStamps.UTCTime();
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateCategoryOrder", ex.Message);
        }
        return result;
    }

    #endregion
}