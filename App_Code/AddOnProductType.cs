using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AddOnProductType
/// </summary>
public class AddOnProductType
{
    public AddOnProductType()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region Add On Product Type Parameters
    public int Id { get; set; }
    public string CategoryID { get; set; }
    public string CategoryTitle { get; set; }
    public string ProductType { get; set; }
    public string ProductOrder { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedIp { get; set; }
    public string AddedBy { get; set; }
    public string Status { get; set; }
    #endregion

    #region Add On Product Type Methods

    /// <summary>
    /// Deletes a ProductType from the database.
    /// </summary>
    /// <param name="conGV">The SQL connection object.</param>
    /// <param name="AddOnProductType">A AddOnProductType object containing details of the ProductType to be deleted.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>

    public static int DeleteProductType(SqlConnection conGV, AddOnProductType AddOnProductType)
    {
        int result = 0;
        try
        {
            string query = "Update AddOnProductType Set Status=@Status, AddedOn=@AddedOn, AddedIp=@AddedIp Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = AddOnProductType.Id;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = AddOnProductType.AddedOn;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = AddOnProductType.AddedIp;
                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteProductType", ex.Message);
        }
        return result;
    }
    /// <summary>
    /// Retrieves all details of a ProductType from the database based on the ProductType's identifier.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="id">The identifier of the ProductType.</param>
    /// <returns>A AddOnProductType object containing details of the specified ProductType.</returns>

    public static AddOnProductType GetAllProductTypeDetailsWithId(SqlConnection conSQ, int id)
    {
        var categories = new AddOnProductType();
        try
        {
            string query = "Select * from AddOnProductType where Status='Active' and Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new AddOnProductType()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  ProductType = Convert.ToString(dr["ProductType"]),
                                  CategoryID = Convert.ToString(dr["CategoryID"]),
                                  ProductOrder = Convert.ToString(dr["ProductOrder"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedIp = Convert.ToString(dr["AddedIP"]),
                                  AddedBy = Convert.ToString(dr["AddedBy"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAlProductTypeDetailsWithId", ex.Message);
        }
        return categories;
    }

    /// <summary>
    /// Retrieves all details of a ProductType from the database based on the ProductType's identifier.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="id">The identifier of the ProductType.</param>
    /// <returns>A AddOnProductType object containing details of the specified ProductType.</returns>

    public static List<AddOnProductType> GetAllProductTypeDetailsWithCategory(SqlConnection conSQ, string Cat)
    {
        var categories = new List<AddOnProductType>();
        try
        {
            string query = "Select * from AddOnProductType where Status=@Status and CategoryID=@CategoryID Order By ProductOrder";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                cmd.Parameters.AddWithValue("@CategoryID", SqlDbType.NVarChar).Value = Cat;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new AddOnProductType()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  ProductType = Convert.ToString(dr["ProductType"]),
                                  CategoryID = Convert.ToString(dr["CategoryID"]),
                                  ProductOrder = Convert.ToString(dr["ProductOrder"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedIp = Convert.ToString(dr["AddedIP"]),
                                  AddedBy = Convert.ToString(dr["AddedBy"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAlProductTypeDetailsWithCategoryID", ex.Message);
        }
        return categories;
    }
    /// <summary>
    /// Retrieves details of all AddOnProductType from the database.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <returns>A list of AddOnProductType objects containing details of all AddOnProductType in the database.</returns>

    public static List<AddOnProductType> GetAllAddOnProductType(SqlConnection conSQ)
    {
        var ListOfBolgs = new List<AddOnProductType>();
        try
        {
            string query = "Select *,(Select Top 1 CategoryTitle from AddOnCategories Where AddOncategories.Id= CategoryID) as CategoryTitle from AddOnProductType where Status=@Status Order by Id";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ListOfBolgs = (from DataRow dr in dt.Rows
                               select new AddOnProductType()
                               {
                                   Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                   ProductType = Convert.ToString(dr["ProductType"]),
                                   CategoryTitle = Convert.ToString(dr["CategoryTitle"]),
                                   CategoryID = Convert.ToString(dr["CategoryID"]),
                                   ProductOrder = Convert.ToString(dr["ProductOrder"]),
                                   AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                   AddedIp = Convert.ToString(dr["AddedIP"]),
                                   AddedBy = Convert.ToString(dr["AddedBy"]),
                                   Status = Convert.ToString(dr["Status"])
                               }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllAddOnProductType", ex.Message);
        }
        return ListOfBolgs;
    }
    /// <summary>
    /// Updates the details of a ProductType in the database.
    /// </summary>
    /// <param name="conGV">The SQL connection object.</param>
    /// <param name="ProductType">A AddOnProductType object containing updated details of the ProductType.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>

    public static int UpdateProductType(SqlConnection conGV, AddOnProductType ProductType)
    {
        int result = 0;
        try
        {
            string query = "Update AddOnProductType Set ProductType=@ProductType,ProductOrder=@ProductOrder,CategoryID=@CategoryID,AddedOn=@AddedOn,AddedIp=@AddedIp, AddedBy=@AddedBy Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = ProductType.Id;
                cmd.Parameters.AddWithValue("@ProductType", SqlDbType.NVarChar).Value = ProductType.ProductType;
                cmd.Parameters.AddWithValue("@ProductOrder", SqlDbType.NVarChar).Value = ProductType.ProductOrder;
                cmd.Parameters.AddWithValue("@CategoryID", SqlDbType.NVarChar).Value = ProductType.CategoryID;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = TimeStamps.UTCTime();
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = ProductType.AddedBy;

                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateProductType", ex.Message);
        }
        return result;
    }

    /// <summary>
    /// Adds a new ProductType to the database.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="ProductType">A AddOnProductType object containing details of the ProductType to be added.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>
    public static int AddProductType(SqlConnection conSQ, AddOnProductType ProductType)
    {
        int result = 0;
        try
        {
            string query = "Insert Into AddOnProductType (ProductType,CategoryID,ProductOrder,AddedOn,AddedIP,Status,AddedBy) values (@ProductType,@CategoryID,@ProductOrder,@AddedOn,@AddedIP,@Status,@AddedBy) select SCOPE_IDENTITY()";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@ProductType", SqlDbType.NVarChar).Value = ProductType.ProductType;
                cmd.Parameters.AddWithValue("@CategoryID", SqlDbType.NVarChar).Value = ProductType.CategoryID;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = ProductType.AddedBy;
                cmd.Parameters.AddWithValue("@ProductOrder", SqlDbType.NVarChar).Value = ProductType.ProductOrder;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = DateTime.UtcNow;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = ProductType.Status;
                conSQ.Open();
                result = Convert.ToInt32(cmd.ExecuteNonQuery());
                conSQ.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "AddProductType", ex.Message);
        }
        return result;
    }

    #endregion
}