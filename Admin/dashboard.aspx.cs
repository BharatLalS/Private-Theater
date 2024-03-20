using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

public partial class Admin_dashboard : System.Web.UI.Page
{
    SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
    public string strTotalArct = "", StrTotalOrders="", Strusername="", StrCustomerCnt="", StrRequestcall="", strOrders="", StrPresentdate="";
    public string strTotalSales = "", strOpenTickets = "", StrTdyOrd = "", strTotalOrders = "", strLast10Sales = "", strUserName = "", strProfileImage = "",StrWish="";

    protected void Page_Load(object sender, EventArgs e)
    {//check if admin login is valid
        if (Request.Cookies["nt_aid"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        getTime();
        BindUserName();
        StrCustomerCnt = DashBoard.GetCustomerCount(conSQ).ToString();
        strTotalArct = DashBoard.GetArchitectCount(conSQ).ToString();
        DateTime date = TimeStamps.UTCTime();
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
}