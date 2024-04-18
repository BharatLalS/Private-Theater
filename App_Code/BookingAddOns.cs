using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BookingAddons
/// </summary>
public class BookingAddOns
{

    #region Booking Addons Parameters
    public int Id { get; set; }
    public string BookingGuid { get; set; }
    public string ProductGuid { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }
    public string Quantity { get; set; }
    public string ItemPrice { get; set; }
    public string TotalPrice { get; set; }
    public string TaxPercentage { get; set; }
    public string TaxAmount { get; set; }
    public string ItemTotal { get; set; }
    public DateTime? AddedOn { get; set; }
    public string AddedIp { get; set; }
    public string Status { get; set; }
    public decimal TotalAddon { get; set; }

    #endregion

    #region Add On Product Type Methods

    /// <summary>
    /// Deletes a BookingAddOns from the database.
    /// </summary>
    /// <param name="conGV">The SQL connection object.</param>
    /// <param name="BookingAddOns">A BookingAddOns object containing details of the BookingAddOns to be deleted.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>

    public static int DeleteBookingAddOns(SqlConnection conGV, BookingAddOns BookingAddOns)
    {
        int result = 0;
        try
        {
            string query = "Delete from BookingAddOns where BookingGuid=@BookingGuid and ProductGuid=@ProductGuid";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@BookingGuid", SqlDbType.NVarChar).Value = BookingAddOns.BookingGuid;
                cmd.Parameters.AddWithValue("@ProductGuid", SqlDbType.NVarChar).Value = BookingAddOns.ProductGuid;
                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteBookingAddOns", ex.Message);
        }
        return result;
    }
    /// <summary>
    /// Retrieves all details of a BookingAddOns from the database based on the BookingAddOns's identifier.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="id">The identifier of the BookingAddOns.</param>
    /// <returns>A BookingAddOns object containing details of the specified BookingAddOns.</returns>

    public static BookingAddOns GetAllBookingAddOnsDetailsWithId(SqlConnection conSQ, int id)
    {
        var categories = new BookingAddOns();
        try
        {
            string query = "Select * from BookingAddOns where Status=@Status and Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new BookingAddOns()
                              {
                                  Id = Convert.ToInt32(dr["Id"]),
                                  BookingGuid = Convert.ToString(dr["BookingGuid"]),
                                  ProductGuid = Convert.ToString(dr["ProductGuid"]),
                                  ProductName = Convert.ToString(dr["ProductName"]),
                                  Category = Convert.ToString(dr["Category"]),
                                  Quantity = Convert.ToString(dr["Quantity"]),
                                  ItemPrice = Convert.ToString(dr["ItemPrice"]),
                                  TotalPrice = Convert.ToString(dr["TotalPrice"]),
                                  TaxPercentage = Convert.ToString(dr["TaxPercentage"]),
                                  TaxAmount = Convert.ToString(dr["TaxAmount"]),
                                  ItemTotal = Convert.ToString(dr["ItemTotal"]),
                                  AddedOn = Convert.ToDateTime(dr["AddedOn"]),
                                  AddedIp = Convert.ToString(dr["AddedIp"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAlBookingAddOnsDetailsWithId", ex.Message);
        }
        return categories;
    }

    /// <summary>
    /// Retrieves all details of a BookingAddOns from the database based on the BookingAddOns's identifier.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="id">The identifier of the BookingAddOns.</param>
    /// <returns>A BookingAddOns object containing details of the specified BookingAddOns.</returns>

    public static List<BookingAddOns> GetAllBookingAddOnsDetailsWithBooking(SqlConnection conSQ, string Booking)
    {
        var categories = new List<BookingAddOns>();
        try
        {
            string query = "Select *,(Select Sum(Try_Convert(decimal,TotalPrice)) from BookingAddOns where Status=@Status and BookingGuid=@BookingGuid ) as AddonTotal from BookingAddOns where Status=@Status and BookingGuid=@BookingGuid  Order By Id";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                cmd.Parameters.AddWithValue("@BookingGuid", SqlDbType.NVarChar).Value = Booking;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new BookingAddOns()
                              {
                                  Id = Convert.ToInt32(dr["Id"]),
                                  BookingGuid = Convert.ToString(dr["BookingGuid"]),
                                  ProductGuid = Convert.ToString(dr["ProductGuid"]),
                                  ProductName = Convert.ToString(dr["ProductName"]),
                                  Quantity = Convert.ToString(dr["Quantity"]),
                                  ItemPrice = Convert.ToString(dr["ItemPrice"]),
                                  TotalPrice = Convert.ToString(dr["TotalPrice"]),
                                  TaxPercentage = Convert.ToString(dr["TaxPercentage"]),
                                  TaxAmount = Convert.ToString(dr["TaxAmount"]),
                                  TotalAddon = Convert.ToDecimal(dr["AddonTotal"]),
                                  ItemTotal = Convert.ToString(dr["ItemTotal"]),
                                  Category = Convert.ToString(dr["Category"]),
                                  AddedOn = Convert.ToDateTime(dr["AddedOn"]),
                                  AddedIp = Convert.ToString(dr["AddedIp"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAlBookingAddOnsDetailsWithCategoryID", ex.Message);
        }
        return categories;
    }

    /// <summary>
    /// Updates the details of a BookingAddOns in the database.
    /// </summary>
    /// <param name="conGV">The SQL connection object.</param>
    /// <param name="BookingAddOns">A BookingAddOns object containing updated details of the BookingAddOns.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>

    public static int UpdateAddOnsQuantity(SqlConnection conGV, BookingAddOns BookingAddOns)
    {
        int result = 0;
        try
        {
            string query = "UPDATE BookingAddOns " +
                           "SET Quantity = @Quantity, " +
                           "TotalPrice = @TotalPrice, " +
                           "AddedOn = @AddedOn, " +
                           "AddedIp = @AddedIp " +
                           "WHERE BookingGuid = @BookingGuid and ProductGuid=@ProductGuid";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Id", BookingAddOns.Id);
                cmd.Parameters.AddWithValue("@BookingGuid", BookingAddOns.BookingGuid);
                cmd.Parameters.AddWithValue("@ProductGuid", BookingAddOns.ProductGuid);
                cmd.Parameters.AddWithValue("@Quantity", BookingAddOns.Quantity);
                cmd.Parameters.AddWithValue("@TotalPrice", BookingAddOns.TotalPrice);
                cmd.Parameters.AddWithValue("@AddedOn", BookingAddOns.AddedOn);
                cmd.Parameters.AddWithValue("@AddedIp", BookingAddOns.AddedIp);
                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateAddOnsQuantity", ex.Message);
        }
        return result;
    }

    /// <summary>
    /// Adds a new BookingAddOns to the database.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="BookingAddOns">A BookingAddOns object containing details of the BookingAddOns to be added.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>
    public static int AddBookingAddOns(SqlConnection conSQ, BookingAddOns bookingAddOns)
    {
        int result = 0;
        try
        {
            string query = "INSERT INTO BookingAddOns (BookingGuid, ProductGuid, Category, ProductName, " +
                               "Quantity, ItemPrice,TaxPercentage,TaxAmount,ItemTotal,TotalPrice, AddedOn, AddedIp, Status) " +
                               "VALUES (@BookingGuid,@ProductGuid, @Category, @ProductName, " +
                               "@Quantity, @ItemPrice,@TaxPercentage,@TaxAmount,@ItemTotal, @TotalPrice, @AddedOn, @AddedIp, @Status)";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@BookingGuid", bookingAddOns.BookingGuid);
                cmd.Parameters.AddWithValue("@ProductGuid", bookingAddOns.ProductGuid);
                cmd.Parameters.AddWithValue("@Category", bookingAddOns.Category);
                cmd.Parameters.AddWithValue("@ProductName", bookingAddOns.ProductName);
                cmd.Parameters.AddWithValue("@Quantity", bookingAddOns.Quantity);
                cmd.Parameters.AddWithValue("@TaxPercentage", bookingAddOns.TaxPercentage);
                cmd.Parameters.AddWithValue("@TaxAmount", bookingAddOns.TaxAmount);
                cmd.Parameters.AddWithValue("@ItemTotal", bookingAddOns.ItemTotal);
                cmd.Parameters.AddWithValue("@ItemPrice", bookingAddOns.ItemPrice);
                cmd.Parameters.AddWithValue("@TotalPrice", bookingAddOns.TotalPrice);
                cmd.Parameters.AddWithValue("@AddedOn", bookingAddOns.AddedOn);
                cmd.Parameters.AddWithValue("@AddedIp", bookingAddOns.AddedIp);
                cmd.Parameters.AddWithValue("@Status", bookingAddOns.Status);
                conSQ.Open();
                result = Convert.ToInt32(cmd.ExecuteNonQuery());
                conSQ.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "AddBookingAddOns", ex.Message);
        }
        return result;
    }

    /// <summary>
    /// Check BookingAddOns Exist in database.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="BookingAddOns">A BookingAddOns object containing details of the BookingAddOns to be checked.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>

    public static int CheckProductExist(SqlConnection conSQ, BookingAddOns AddOns)
    {
        int result = 0;
        try
        {
            string query = "Select Count(ID) as cnt from BookingAddOns Where BookingGuid =@BookingGuid and ProductGuid=@ProductGuid and Status !=@Status ";
            SqlCommand cmd = new SqlCommand(query, conSQ);
            cmd.Parameters.AddWithValue("@BookingGuid", SqlDbType.NVarChar).Value = AddOns.BookingGuid;
            cmd.Parameters.AddWithValue("@ProductGuid", SqlDbType.NVarChar).Value = AddOns.ProductGuid;
            cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            result = Convert.ToInt32(dt.Rows[0]["cnt"]);
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteBookingAddOns", ex.Message);
        }
        return result;
    }


    public static DataTable AddonPrices(SqlConnection conSQ, string BGuid)
    {
        var dt = new DataTable();
        try
        {
            string query = @"SELECT 
                            SUM(Try_Convert(decimal,TaxAmount)) AS TotalTax,
                            SUM(Try_Convert(decimal,ItemTotal)) AS TotalPrice,
                            SUM(Try_Convert(decimal,TotalPrice)) AS TotalPriceWithTax
                            FROM BookingAddons Where BookingGuid=@BookingGuid and Status !=@Status;";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@BookingGuid", SqlDbType.NVarChar).Value = BGuid;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                return dt;
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "AddonPrices", ex.Message);
        }
        return dt;
    }

    #endregion

}