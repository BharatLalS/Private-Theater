using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PaymentSuccess : System.Web.UI.Page
{
    SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);

    public string StrOrderID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["o"] != null)
        {
            StrOrderID = BookingDetails.GetBookingIDWithBookingGuid(conSQ, Request.QueryString["o"]);
           // BookingDetails.SendToUser(conSQ, Request.QueryString["o"]);
        }
        else
        {
            Response.Redirect("/");
        }
    }
}