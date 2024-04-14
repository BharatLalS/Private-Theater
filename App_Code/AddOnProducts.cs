using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AddOnProducts
/// </summary>
public class AddOnProducts
{
    public int Id { get; set; }
    public string Category { get; set; }
    public string ProductName { get; set; }
    public string ProductType { get; set; }
    public string ProductUrl { get; set; }
    public string ProductGuid { get; set; }
    public string ProductOrder { get; set; }
    public string Price { get; set; }
    public string ThumbImage { get; set; }
    public string AllowMultiple { get; set; }
    public string Description { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedIp { get; set; }
    public string AddedBy { get; set; }
    public string Status { get; set; }


    //Extra 
    public string CategoryTitle { get; set; }

    #region Product method
    /// <summary>
    /// Deletes a Product from the database.
    /// </summary>
    /// <param name="conGV">The SQL connection object.</param>
    /// <param name="AddOnProducts">A AddOnProducts object containing details of the Product to be deleted.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>
    public static int DeleteProduct(SqlConnection conGV, AddOnProducts AddOnProducts)
    {
        int result = 0;
        try
        {
            string query = "Update AddOnProducts Set Status=@Status, AddedOn=@AddedOn, AddedIp=@AddedIp Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = AddOnProducts.Id;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = AddOnProducts.AddedOn;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = AddOnProducts.AddedIp;
                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteProduct", ex.Message);
        }
        return result;
    }

    /// <summary>
    /// Retrieves all details of a Product from the database based on the Product's identifier.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="id">The identifier of the Product.</param>
    /// <returns>A AddOnProducts object containing details of the specified Product.</returns>

    public static AddOnProducts GetAllProductDetailsWithId(SqlConnection conSQ, int id)
    {
        var Products = new AddOnProducts();
        try
        {
            string query = "Select *,(Select CategoryTitle from AddOnCategories Where AddOnCategories.ID=Category) as CategoryTitle from AddOnProducts where Status='Active' and Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Products = (from DataRow dr in dt.Rows
                            select new AddOnProducts()
                            {
                                Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                ProductName = Convert.ToString(dr["ProductName"]),
                                CategoryTitle = Convert.ToString(dr["CategoryTitle"]),
                                Category = Convert.ToString(dr["Category"]),
                                ProductUrl = Convert.ToString(dr["ProductUrl"]),
                                ProductGuid = Convert.ToString(dr["ProductGuid"]),
                                ProductOrder = Convert.ToString(dr["ProductOrder"]),
                                ProductType = Convert.ToString(dr["ProductType"]),
                                Price = Convert.ToString(dr["Price"]),
                                ThumbImage = Convert.ToString(dr["ThumbImage"]),
                                AllowMultiple = Convert.ToString(dr["AllowMultiple"]),
                                Description = Convert.ToString(dr["Description"]),
                                AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                AddedIp = Convert.ToString(dr["AddedIP"]),
                                AddedBy = Convert.ToString(dr["AddedBy"]),
                                Status = Convert.ToString(dr["Status"])
                            }).FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAlProductDetailsWithId", ex.Message);
        }
        return Products;
    }

    /// <summary>
    /// Retrieves all details of a Product from the database based on the Product's identifier.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="id">The identifier of the Product.</param>
    /// <returns>A AddOnProducts object containing details of the specified Product.</returns>

    public static AddOnProducts GetAllProductDetailsWithUrl(SqlConnection conSQ, string url)
    {
        var Products = new AddOnProducts();
        try
        {
            string query = "Select *,(Select CategoryTitle from AddOnCategories Where AddOnCategories.ID=Category) as CategoryTitle from AddOnProducts where Status=@Status and ProductUrl=@ProductUrl";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                cmd.Parameters.AddWithValue("@ProductUrl", SqlDbType.NVarChar).Value = url;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Products = (from DataRow dr in dt.Rows
                            select new AddOnProducts()
                            {
                                Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                ProductName = Convert.ToString(dr["ProductName"]),
                                CategoryTitle = Convert.ToString(dr["CategoryTitle"]),
                                Category = Convert.ToString(dr["CategoryTitle"]),
                                ProductUrl = Convert.ToString(dr["ProductUrl"]),
                                ProductGuid = Convert.ToString(dr["ProductGuid"]),
                                ProductOrder = Convert.ToString(dr["ProductOrder"]),
                                ProductType = Convert.ToString(dr["ProductType"]),
                                Price = Convert.ToString(dr["Price"]),
                                ThumbImage = Convert.ToString(dr["ThumbImage"]),
                                AllowMultiple = Convert.ToString(dr["AllowMultiple"]),
                                Description = Convert.ToString(dr["Description"]),
                                AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                AddedIp = Convert.ToString(dr["AddedIP"]),
                                AddedBy = Convert.ToString(dr["AddedBy"]),
                                Status = Convert.ToString(dr["Status"])
                            }).FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAlProductDetailsWithId", ex.Message);
        }
        return Products;
    }

    /// <summary>
    /// Retrieves details of all AddOnProducts from the database.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <returns>A list of AddOnProducts objects containing details of all AddOnProducts in the database.</returns>

    public static List<AddOnProducts> GetAllAddOnProducts(SqlConnection conSQ)
    {
        var ListOfBolgs = new List<AddOnProducts>();
        try
        {
            string query = "Select *,(Select CategoryTitle from AddOnCategories Where AddOnCategories.ID=Category) as CategoryTitle from AddOnProducts where Status=@Status Order by Id";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ListOfBolgs = (from DataRow dr in dt.Rows
                               select new AddOnProducts()
                               {
                                   Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                   ProductName = Convert.ToString(dr["ProductName"]),
                                   CategoryTitle = Convert.ToString(dr["CategoryTitle"]),
                                   Category = Convert.ToString(dr["CategoryTitle"]),
                                   ProductUrl = Convert.ToString(dr["ProductUrl"]),
                                   ProductGuid = Convert.ToString(dr["ProductGuid"]),
                                   ProductOrder = Convert.ToString(dr["ProductOrder"]),
                                   ProductType = Convert.ToString(dr["ProductType"]),
                                   Price = Convert.ToString(dr["Price"]),
                                   ThumbImage = Convert.ToString(dr["ThumbImage"]),
                                   AllowMultiple = Convert.ToString(dr["AllowMultiple"]),
                                   Description = Convert.ToString(dr["Description"]),
                                   AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                   AddedIp = Convert.ToString(dr["AddedIP"]),
                                   AddedBy = Convert.ToString(dr["AddedBy"]),
                                   Status = Convert.ToString(dr["Status"])
                               }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllAddOnProducts", ex.Message);
        }
        return ListOfBolgs;
    }
    /// <summary>
    /// Retrieves details of all AddOnProducts from the database With Category.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <returns>A list of AddOnProducts objects containing details of all AddOnProducts in the database.</returns>

    public static List<AddOnProducts> GetAllAddOnProductsWithCategory(SqlConnection conSQ, string Cat)
    {
        var ListOfBolgs = new List<AddOnProducts>();
        try
        {
            string query = "Select *,(Select CategoryTitle from AddOnCategories Where AddOnCategories.ID=Category) as CategoryTitle from AddOnProducts where Status=@Status and Category=@Category Order by Id";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                cmd.Parameters.AddWithValue("@Category", SqlDbType.NVarChar).Value = Cat;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ListOfBolgs = (from DataRow dr in dt.Rows
                               select new AddOnProducts()
                               {
                                   Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                   ProductName = Convert.ToString(dr["ProductName"]),
                                   CategoryTitle = Convert.ToString(dr["CategoryTitle"]),
                                   Category = Convert.ToString(dr["CategoryTitle"]),
                                   ProductUrl = Convert.ToString(dr["ProductUrl"]),
                                   ProductGuid = Convert.ToString(dr["ProductGuid"]),
                                   ProductOrder = Convert.ToString(dr["ProductOrder"]),
                                   ProductType = Convert.ToString(dr["ProductType"]),
                                   Price = Convert.ToString(dr["Price"]),
                                   ThumbImage = Convert.ToString(dr["ThumbImage"]),
                                   AllowMultiple = Convert.ToString(dr["AllowMultiple"]),
                                   Description = Convert.ToString(dr["Description"]),
                                   AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                   AddedIp = Convert.ToString(dr["AddedIP"]),
                                   AddedBy = Convert.ToString(dr["AddedBy"]),
                                   Status = Convert.ToString(dr["Status"])
                               }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllAddOnProducts", ex.Message);
        }
        return ListOfBolgs;
    }

    /// <summary>
    /// Updates the details of a Product in the database.
    /// </summary>
    /// <param name="conGV">The SQL connection object.</param>
    /// <param name="Product">A AddOnProducts object containing updated details of the Product.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>

    public static int UpdateProduct(SqlConnection conGV, AddOnProducts Product)
    {
        int result = 0;
        try
        {
            string query = "Update AddOnProducts Set ProductName=@ProductName,ProductUrl=@ProductUrl,ProductType=@ProductType,Category=@Category,Price=@Price,ThumbImage=@ThumbImage," +
                           "AllowMultiple=@AllowMultiple,Description=@Description,AddedOn=@AddedOn,AddedIp=@AddedIp, AddedBy=@AddedBy Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = Product.Id;
                cmd.Parameters.AddWithValue("@ProductName", SqlDbType.NVarChar).Value = Product.ProductName;
                cmd.Parameters.AddWithValue("@ProductUrl", SqlDbType.NVarChar).Value = Product.ProductUrl;
                cmd.Parameters.AddWithValue("@ProductType", SqlDbType.NVarChar).Value = Product.ProductType;
                cmd.Parameters.AddWithValue("@Category", SqlDbType.NVarChar).Value = Product.Category;
                cmd.Parameters.AddWithValue("@Price", SqlDbType.NVarChar).Value = Product.Price;
                cmd.Parameters.AddWithValue("@ThumbImage", SqlDbType.NVarChar).Value = Product.ThumbImage;
                cmd.Parameters.AddWithValue("@AllowMultiple", SqlDbType.NVarChar).Value = Product.AllowMultiple;
                cmd.Parameters.AddWithValue("@Description", SqlDbType.NVarChar).Value = Product.Description;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = TimeStamps.UTCTime();
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = Product.AddedBy;

                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateProduct", ex.Message);
        }
        return result;
    }

    /// <summary>
    /// Adds a new Product to the database.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="Product">A AddOnProducts object containing details of the Product to be added.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>
    public static int AddProduct(SqlConnection conSQ, AddOnProducts Product)
    {
        int result = 0;
        try
        {
            string query = "Insert Into AddOnProducts (ProductName,ProductUrl,ProductGuid,ProductType,Category,ThumbImage,Description,AllowMultiple,Price,ProductOrder,AddedOn,AddedIP,Status,AddedBy) " +
                           "values (@ProductName,@ProductUrl,@ProductGuid,@ProductType,@Category,@ThumbImage,@Description,@AllowMultiple,@Price,@ProductOrder,@AddedOn,@AddedIP,@Status,@AddedBy) ";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@ProductName", SqlDbType.NVarChar).Value = Product.ProductName;
                cmd.Parameters.AddWithValue("@ProductUrl", SqlDbType.NVarChar).Value = Product.ProductUrl;
                cmd.Parameters.AddWithValue("@ProductGuid", SqlDbType.NVarChar).Value = Product.ProductGuid;
                cmd.Parameters.AddWithValue("@ProductType", SqlDbType.NVarChar).Value = Product.ProductType;
                cmd.Parameters.AddWithValue("@Category", SqlDbType.NVarChar).Value = Product.Category;
                cmd.Parameters.AddWithValue("@ThumbImage", SqlDbType.NVarChar).Value = Product.ThumbImage;
                cmd.Parameters.AddWithValue("@Description", SqlDbType.NVarChar).Value = Product.Description;
                cmd.Parameters.AddWithValue("@AllowMultiple", SqlDbType.NVarChar).Value = Product.AllowMultiple;
                cmd.Parameters.AddWithValue("@Price", SqlDbType.NVarChar).Value = Product.Price;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = Product.AddedBy;
                cmd.Parameters.AddWithValue("@ProductOrder", SqlDbType.NVarChar).Value = Product.ProductOrder;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = TimeStamps.UTCTime();
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = Product.Status;
                conSQ.Open();
                result = Convert.ToInt32(cmd.ExecuteNonQuery());
                conSQ.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "AddProduct", ex.Message);
        }
        return result;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="conGV"></param>
    /// <param name="cat"></param>
    /// <returns></returns>
    public static int UpdateProductOrder(SqlConnection conGV, AddOnProducts cat)
    {
        int result = 0;
        try
        {
            string query = "Update AddOnProducts Set AddedOn=@AddedOn,AddedIp=@AddedIp,ProductOrder=@ProductOrder Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = cat.Id;
                cmd.Parameters.AddWithValue("@ProductOrder", SqlDbType.NVarChar).Value = cat.ProductOrder;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = TimeStamps.UTCTime();
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateProductOrder", ex.Message);
        }
        return result;
    }

    #endregion
}