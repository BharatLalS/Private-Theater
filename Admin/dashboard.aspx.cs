using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.Services;

public partial class Admin_dashboard : System.Web.UI.Page
{
    SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
    public string strTotalBlogs = "", StrTodayBooking = "", Strusername = "", StrTheaterCnt = "", StrRequestcall = "", strOrders = "", StrPresentdate = "";
    public string strTotalSales = "", strOpenTickets = "", StrTdyOrd = "", strTotalOrders = "", strLast10Sales = "", strUserName = "", strProfileImage = "", StrWish = "";

    protected void Page_Load(object sender, EventArgs e)
    {//check if admin login is valid
        if (Request.Cookies["nt_aid"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        DateTime date = TimeStamps.UTCTime();
        getTime();
        BindUserName();
        StrTheaterCnt = DashBoard.GetTheaterCount(conSQ).ToString();
        strTotalBlogs = DashBoard.GetBlogCount(conSQ).ToString();
        StrTodayBooking = DashBoard.TodaysBooking(conSQ, date.ToString("dd MMM yyyy")).ToString();
        StrTdyOrd = DashBoard.TodaysBookingRevenue(conSQ, date.ToString("dd MMM yyyy")).ToString();
        StrPresentdate = date.ToString("dd-MMM-yyyy");
    }


    public void getTime()
    {
        try
        {
            var myDate = TimeStamps.UTCTime();
            var hour = myDate.Hour; // Get the hour directly.

            int h = hour; // Store the hour in a variable.

            if (h < 12)
            {
                StrWish = "Good Morning";
            }
            else if (h < 15)
            {
                StrWish = "Good Afternoon";
            }
            else if (h < 23)
            {
                StrWish = "Good Evening";
            }
            else
            {
                StrWish = "Good Night";
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "getTime", ex.Message);
        }
    }

    public void BindUserName()
    {
        try
        {
            Strusername = CreateUser.GetLoggedUserName(conSQ, Request.Cookies["nt_aid"].Value);
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindUserName", ex.Message);
        }
    }
    [WebMethod(EnableSession = true)]
    public static string DashBoardChart()
    {
        try
        {
            SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);

            var data = DashBoard.GetDashboardWidgetValues(conSQ);
            if (data != null)
            {
                double total = Convert.ToInt32(data.Rows[0]["Total"].ToString());
                double created = Convert.ToInt32(data.Rows[0]["Created"].ToString());
                double cancle = Convert.ToInt32(data.Rows[0]["Cancle"].ToString());
                double complete = Convert.ToInt32(data.Rows[0]["Complete"].ToString());
                double percentage = (complete / total) * 100;
                double sales = Convert.ToDouble(data.Rows[0]["TotalSales"].ToString() == "" ? "0" : data.Rows[0]["TotalSales"].ToString());
                return JsonConvert.SerializeObject(new { Total = total, Created = created, ConvPercent = percentage, Cancle = cancle, Complete = complete, Sales = sales });
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DashBoardChart", ex.Message);
            return "Error";
        }
        return "Error";
    }

    [WebMethod(EnableSession = true)]
    public static string DashBoardRevenue()
    {
        try
        {
            SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);

            var data = DashBoard.GetDashboardMontlyRevnue(conSQ);
            if (data != null && data.Rows.Count > 0)
            {
                var month = new List<string>();
                var month_order = new List<string>();
                var month_payment = new List<string>();
                var month_completed = new List<string>();
                var month_completed_payment = new List<string>();
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    month.Add(Convert.ToDateTime(data.Rows[i]["completion_month"]).ToString("MMM-yyyy").ToString());
                    month_order.Add(data.Rows[i]["total_orders"].ToString());
                    month_payment.Add(data.Rows[i]["total_payments"].ToString());
                    month_completed.Add(data.Rows[i]["completed_orders"].ToString());
                    month_completed_payment.Add(data.Rows[i]["completed_payments"].ToString());
                }
                return JsonConvert.SerializeObject(new { Months = month, TotalOrders = month_order, TotalPayments = month_payment, CompletedOrders = month_completed, CompletedPayments = month_completed_payment });
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DashBoardRevenue", ex.Message);
            return "Error";
        }
        return "Error";
    }

    [WebMethod(EnableSession = true)]
    public static string GetBookings(int Days)
    {
        SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
        string x = "";
        try
        {
            var filter = new FilterOptions();
            filter.SearchKey =  "";
            if (Days != 0)
            {
                filter.StartDate = TimeStamps.UTCTime().ToString("dd/MMM/yyyy");
                filter.EndDate = TimeStamps.UTCTime().AddDays(Days).ToString("dd/MMM/yyyy");
            }
            else
            {
                filter.StartDate = TimeStamps.UTCTime().ToString("dd/MMM/yyyy");
                filter.EndDate = TimeStamps.UTCTime().AddYears(1).ToString("dd/MMM/yyyy");
            }
            filter.OrderStatus = "Completed";
            filter.PLenght = Convert.ToInt32(100);
            filter.PgNo = Convert.ToInt32(1);
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
                                            <td><a href='\receipt.aspx?o=" + bookings.Rows[i]["BookingGuid"] + @"' target='_blank' class='badge badge badge-gradient-secondary text-light fs-12'>" + bookings.Rows[i]["BookingID"] + @"</a></td>
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