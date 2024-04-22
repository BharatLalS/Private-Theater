using InstamojoAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default2 : System.Web.UI.Page
{
    SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod(EnableSession = true)]
    public static string GetBookings(int Days, string startDate, string EndDate, string Key, string PageNo, string PageLenght, string Ostatus)
    {
        SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
        string x = "";
        try
        {
            var filter = new FilterOptions();
            filter.SearchKey = Key == null ? "" : Key;
            if (Days != 0)
            {
                filter.StartDate = TimeStamps.UTCTime().ToString("dd/MMM/yyyy");
                filter.EndDate = TimeStamps.UTCTime().AddDays((Days-1)).ToString("dd/MMM/yyyy");
            }
            else if (startDate != "" && EndDate != "")
            {
                filter.StartDate = Convert.ToDateTime(startDate).ToString("dd/MMM/yyyy");
                filter.EndDate = Convert.ToDateTime(EndDate).ToString("dd/MMM/yyyy");
            }
            else
            {
                filter.StartDate = TimeStamps.UTCTime().ToString("dd/MMM/yyyy");
                filter.EndDate = TimeStamps.UTCTime().AddYears(1).ToString("dd/MMM/yyyy");
            }
            filter.OrderStatus = Ostatus == "0" ? "" : Ostatus;
            filter.PLenght = Convert.ToInt32(PageLenght);
            filter.PgNo = Convert.ToInt32(PageNo);
            var bookings = BookingDetails.GetBookingWithFilter(conSQ, filter);
            if (bookings != null)
            {

                if (bookings.Rows.Count > 0)
                {
                    string tableitems = "";
                    var deadlineclass = "";
                    for (int i = 0; i < bookings.Rows.Count; i++)
                    {
                        string sts = "";
                        string psts = "";
                        var Bookingstatus = bookings.Rows[i]["BookingStatus"].ToString().ToLower();
                        var PayStatus = bookings.Rows[i]["PaymentStatus"].ToString().ToLower();
                        switch (Bookingstatus)
                        {
                            case "initiated": sts = "<span id='sts_" + bookings.Rows[i]["Id"].ToString() + @"' class='badge badge-outline-warning shadow fs-13'>Initiated</span>"; break;
                            case "completed": sts = "<span id='sts_" + bookings.Rows[i]["Id"].ToString() + @"' class='badge badge-outline-success shadow fs-13'>Completed</span>"; break;
                            case "failed": sts = "<span id='sts_" + bookings.Rows[i]["Id"].ToString() + @"' class='badge badge-outline-danger shadow fs-13'>Failed</span>"; break;
                        }; switch (PayStatus)
                        {
                            case "": psts = "<span id='stsp_" + bookings.Rows[i]["Id"].ToString() + @"' class='badge badge-outline-primary shadow fs-13'>N/A</span>"; break;
                            case "initiated": psts = "<span id='stsp_" + bookings.Rows[i]["Id"].ToString() + @"' class='badge badge-outline-warning shadow fs-13'>Initiated</span>"; break;
                            case "paid": psts = "<span id='stsp_" + bookings.Rows[i]["Id"].ToString() + @"' class='badge badge-outline-success shadow fs-13'>Paid</span>"; break;
                            case "failed": psts = "<span id='stsp_" + bookings.Rows[i]["Id"].ToString() + @"' class='badge badge-outline-danger shadow fs-13'>Failed</span>"; break;
                        };
                        tableitems += @"<tr  class='" + deadlineclass + @"'>
                                            <td>" + bookings.Rows[i]["RN"] + @"</td>
                                            <td><a href='view-booking-details.aspx?o=" + bookings.Rows[i]["BookingGuid"] + @"' target='_blank' class='badge badge badge-gradient-secondary text-light fs-12'>" + bookings.Rows[i]["BookingID"] + @"</a></td>
                                            <td>" + Convert.ToDateTime(bookings.Rows[i]["BookingDate"]).ToString("dd MMM yyyy") + @"</td>
                                            <td>" + bookings.Rows[i]["TheaterName"] + @"</td>
                                            <td>" + bookings.Rows[i]["UserName"] + @"</td>
                                            <td>" + bookings.Rows[i]["UserEmail"] + @"</td>
                                            <td>" + bookings.Rows[i]["UserPhoneNo"] + @"</td>
                                            <td>" + sts + @"</td>
                                            <td>" + Convert.ToDateTime(bookings.Rows[i]["Addedon"]).ToString("dd MMM yyyy") + @"</td>
                                            <td>" + psts + @"</td>
                                            <td>" + bookings.Rows[i]["PaymentId"] + @"</td>
                                            <td> ₹ " + Convert.ToDecimal(bookings.Rows[i]["SubTotal"]).ToString("N2") + @"</td>
                                        </tr>";
                    }
                    return JsonConvert.SerializeObject(new { table = tableitems, count = bookings.Rows[0]["ProdCount"] });
                }
                else
                {
                    return "Empty";
                }
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetBookings", ex.Message);

        }
        return x;
    }
}