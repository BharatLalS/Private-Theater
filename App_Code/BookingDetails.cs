using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Drawing;

/// <summary>
/// Summary description for BookingDetails
/// </summary>
public class BookingDetails
{
    #region BookingDetails 
    public int Id { get; set; }
    public string BookingID { get; set; }
    public string BookingGuid { get; set; }
    public string TheaterGuid { get; set; }
    public DateTime BookingDate { get; set; }
    public string BookingStatus { get; set; }
    public string UserGuid { get; set; }
    public string UserName { get; set; }
    public string UserEmail { get; set; }
    public string UserPhoneNo { get; set; }
    public string NoOfPax { get; set; }
    public string SlotTotal { get; set; }
    public string ExtPaxTotal { get; set; }
    public string Subtotal { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedIP { get; set; }
    public string Status { get; set; }
    #endregion

    #region Booking Details Methods 
    public static string GetBMax(SqlConnection conGV)
    {
        string x = "";
        try
        {
            SqlCommand cmd3 = new SqlCommand("Select Max(try_convert(decimal, ID)) as mid from BookingDetails", conGV);
            SqlDataAdapter sda3 = new SqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            if (dt3.Rows.Count > 0)
            {
                string cc = Convert.ToString(dt3.Rows[0]["mid"]);
                if (cc == "")
                {
                    cc = "0000";
                }
                x = (Convert.ToInt32(cc) + 1).ToString();
                if (x.Length <= 4)
                {
                    x = Convert.ToInt32(x).ToString("0000");
                }
            }
        }
        catch (Exception ex)
        {
            x = "0001";
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetOMax", ex.Message);
        }
        return x;
    }

    public static int AddBookingDetails(SqlConnection conGV, BookingDetails booking)
    {
        int x = 0;
        try
        {
            string query = @"INSERT INTO BookingDetails 
                            (BookingID, BookingGuid,TheaterGuid, BookingDate, BookingStatus, UserGuid, UserName, 
                                UserEmail, UserPhoneNo,NoOfPax,SlotTotal,ExtPaxTotal, Subtotal, AddedOn, AddedIP, Status) 
                         VALUES 
                            (@BookingID, @BookingGuid,@TheaterGuid, @BookingDate, @BookingStatus,@UserGuid, @UserName,
                                @UserEmail, @UserPhoneNo,@NoOfPax,@SlotTotal,@ExtPaxTotal, @Subtotal, @AddedOn, @AddedIP, @Status)";


            using (SqlCommand command = new SqlCommand(query, conGV))
            {
                // Add parameters
                command.Parameters.AddWithValue("@BookingID", booking.BookingID);
                command.Parameters.AddWithValue("@BookingGuid", booking.BookingGuid);
                command.Parameters.AddWithValue("@TheaterGuid", booking.TheaterGuid);
                command.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
                command.Parameters.AddWithValue("@BookingStatus", booking.BookingStatus);
                command.Parameters.AddWithValue("@UserGuid", booking.UserGuid);
                command.Parameters.AddWithValue("@UserName", booking.UserName);
                command.Parameters.AddWithValue("@UserEmail", booking.UserEmail);
                command.Parameters.AddWithValue("@UserPhoneNo", booking.UserPhoneNo);
                command.Parameters.AddWithValue("@NoOfPax", booking.NoOfPax);
                command.Parameters.AddWithValue("@SlotTotal", booking.SlotTotal);
                command.Parameters.AddWithValue("@ExtPaxTotal", booking.ExtPaxTotal);
                command.Parameters.AddWithValue("@Subtotal", booking.Subtotal);
                command.Parameters.AddWithValue("@AddedOn", booking.AddedOn);
                command.Parameters.AddWithValue("@AddedIP", booking.AddedIP);
                command.Parameters.AddWithValue("@Status", booking.Status);

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

    public static BookingDetails GetBookingDetails(SqlConnection conGV, string bookingGuid)
    {
        var booking = new BookingDetails();
        try
        {
            string query = "Select * from BookingDetails Where BookingGuid=@BookingGuid and Status !=@Status";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@BookingGuid", SqlDbType.NVarChar).Value = bookingGuid;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                booking = (from DataRow dr in dt.Rows
                           select new BookingDetails()
                           {
                               Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                               BookingID = Convert.ToString(dr["BookingID"]),
                               BookingGuid = Convert.ToString(dr["BookingGuid"]),
                               TheaterGuid = Convert.ToString(dr["TheaterGuid"]),
                               BookingDate = Convert.ToDateTime(Convert.ToString(dr["BookingDate"])),
                               BookingStatus = Convert.ToString(dr["BookingStatus"]),
                               UserGuid = Convert.ToString(dr["UserGuid"]),
                               UserName = Convert.ToString(dr["UserName"]),
                               UserEmail = Convert.ToString(dr["UserEmail"]),
                               UserPhoneNo = Convert.ToString(dr["UserPhoneNo"]),
                               NoOfPax = Convert.ToString(dr["NoOfPax"]),
                               SlotTotal = Convert.ToString(dr["SlotTotal"]),
                               ExtPaxTotal = Convert.ToString(dr["ExtPaxTotal"]),
                               Subtotal = Convert.ToString(dr["Subtotal"]),
                               AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                               AddedIP = Convert.ToString(dr["AddedIP"]),
                               Status = Convert.ToString(dr["Status"])
                           }).FirstOrDefault();
            }
            return booking;
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetBookingDetails", ex.Message);

        }
        return null;
    }
    #endregion
}