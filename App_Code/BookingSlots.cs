using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BookingSlots
/// </summary>
public class BookingSlots
{
    #region Booking Slots Parameters
    public int Id { get; set; }
    public DateTime BookingDate { get; set; }
    public string BookingGuid { get; set; }
    public string TheaterGuid { get; set; }
    public string TimingGuid { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedIP { get; set; }
    public string Status { get; set; }
    public string ItemPrice { get; set; }
    public string TaxPercentage { get; set; }
    public string TaxAmount { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public string TotalPrice { get; set; }
    public string Quantity { get; set; }
    #endregion

    #region Booking Slots Methods
    public static int AddBookingSlots(SqlConnection conGV, BookingSlots booking)
    {
        int x = 0;
        try
        {
            string query = @"INSERT INTO BookingSlots (BookingDate, BookingGuid, TheaterGuid, TimingGuid, AddedOn, AddedIP, Status, Quantity, ItemPrice, TaxPercentage, TaxAmount, StartTime, EndTime, TotalPrice) 
             VALUES (@BookingDate, @BookingGuid, @TheaterGuid, @TimingGuid, @AddedOn, @AddedIP, @Status, @Quantity, @ItemPrice, @TaxPercentage, @TaxAmount, @StartTime, @EndTime, @TotalPrice)";

            using (SqlCommand command = new SqlCommand(query, conGV))
            {
                // Add parameters
                command.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
                command.Parameters.AddWithValue("@BookingGuid", booking.BookingGuid);
                command.Parameters.AddWithValue("@TheaterGuid", booking.TheaterGuid);
                command.Parameters.AddWithValue("@TimingGuid", booking.TimingGuid);
                command.Parameters.AddWithValue("@AddedOn", booking.AddedOn);
                command.Parameters.AddWithValue("@AddedIP", booking.AddedIP);
                command.Parameters.AddWithValue("@Status", booking.Status);
                command.Parameters.AddWithValue("@Quantity", booking.Quantity);
                command.Parameters.AddWithValue("@ItemPrice", booking.ItemPrice);
                command.Parameters.AddWithValue("@TaxPercentage", booking.TaxPercentage);
                command.Parameters.AddWithValue("@TaxAmount", booking.TaxAmount);
                command.Parameters.AddWithValue("@StartTime", booking.StartTime);
                command.Parameters.AddWithValue("@EndTime", booking.EndTime);
                command.Parameters.AddWithValue("@TotalPrice", booking.TotalPrice);

                conGV.Open();
                x = command.ExecuteNonQuery();
                conGV.Close();
            }


        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "AddBookingDetails", ex.Message);

            return 0;
        }
        return x;
    }

    public static int GetBookedSlotByDate(SqlConnection conGV, DateTime date, string Tid,string TheaterId)
    {
        int x = 0;
        try
        {
            string query = @"Select Count(ID) as Cnt From BookingSlots Where BookingDate=@BookingDate and TimingGuid=@TimingGuid and TheaterGuid=@TheaterGuid and Status = @Status";
            SqlCommand cmd = new SqlCommand(query, conGV);
            cmd.Parameters.AddWithValue("@BookingDate", SqlDbType.NVarChar).Value = date;
            cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Completed";
            cmd.Parameters.AddWithValue("@TimingGuid", SqlDbType.NVarChar).Value = Tid;
            cmd.Parameters.AddWithValue("@TheaterGuid", SqlDbType.NVarChar).Value = TheaterId;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                x = Convert.ToInt32(dt.Rows[0]["Cnt"].ToString());
                return x;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "AddBookingDetails", ex.Message);

            return 0;
        }
        return x;
    }

    public static List<BookingSlots> GetBookingSlotsByBGuid(SqlConnection conSQ, string bGuid)
    {
        var categories = new List<BookingSlots>();

        try
        {
            string query = "Select * from BookingSlots where Status != @Status and BookingGuid=@BookingGuid  Order By Id";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";
                cmd.Parameters.AddWithValue("@BookingGuid", SqlDbType.NVarChar).Value = bGuid;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new BookingSlots()
                              {
                                  Id = Convert.ToInt32(dr["Id"]),
                                  BookingGuid = Convert.ToString(dr["BookingGuid"]),
                                  BookingDate = Convert.ToDateTime(Convert.ToString(dr["BookingDate"])),
                                  TheaterGuid = Convert.ToString(dr["TheaterGuid"]),
                                  TimingGuid = Convert.ToString(dr["TimingGuid"]),
                                  Quantity = Convert.ToString(dr["Quantity"]),
                                  ItemPrice = Convert.ToString(dr["ItemPrice"]),
                                  TotalPrice = Convert.ToString(dr["TotalPrice"]),
                                  TaxPercentage = Convert.ToString(dr["TaxPercentage"]),
                                  TaxAmount = Convert.ToString(dr["TaxAmount"]),
                                  StartTime = Convert.ToString(dr["StartTime"]),
                                  EndTime = Convert.ToString(dr["EndTime"]),
                                  AddedOn = Convert.ToDateTime(dr["AddedOn"]),
                                  AddedIP = Convert.ToString(dr["AddedIp"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).ToList();
            }
            return categories;
        }
        catch(Exception ex) 
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetBookingSlotsByBGuid", ex.Message);

            return categories;

        }
    }

    public static int UpdateBookingComplete(SqlConnection conSQ,string bGuid)
    {
        var result = 0;
        try
        {
            string query = "Update BookingSlots Set Status=@Status Where BookingGuid=@BookingGuid and Status !='Deleted'";

            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@BookingGuid", bGuid);
                cmd.Parameters.AddWithValue("@Status", "Completed");
                conSQ.Open();
                result = cmd.ExecuteNonQuery();
                conSQ.Close();
            }
            return result;
        }
        catch(Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetBookingSlotsByBGuid", ex.Message);
            return 0;

        }
        return 0;

    }

    #endregion
}