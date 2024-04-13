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
    public string Quantity { get; set; }
    #endregion

    #region Booking Slots Methods
    public static int AddBookingSlots(SqlConnection conGV, BookingSlots booking)
    {
        int x = 0;
        try
        {
            string query = @"INSERT INTO BookingSlots (BookingDate, BookingGuid, TheaterGuid, TimingGuid,AddedOn, AddedIP, Status, Quantity) 
                         VALUES (@BookingDate, @BookingGuid, @TheaterGuid, @TimingGuid,@AddedOn, @AddedIP, @Status, @Quantity)";


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

    public static int GetBookedSlotByDate(SqlConnection conGV, DateTime date, string Tid)
    {
        int x = 0;
        try
        {
            string query = @"Select Count(ID) as Cnt From BookingSlots Where BookingDate=@BookingDate and TimingGuid=@TimingGuid";
            SqlCommand cmd = new SqlCommand(query, conGV);
            cmd.Parameters.AddWithValue("@BookingDate", SqlDbType.NVarChar).Value = date;
            cmd.Parameters.AddWithValue("@TimingGuid", SqlDbType.NVarChar).Value = Tid;
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
    #endregion
}