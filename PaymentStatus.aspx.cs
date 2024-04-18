using InstamojoAPI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PaymentStatus : System.Web.UI.Page
{
    SqlConnection conGV = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
    public string payStatus = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckTsAsync();
    }
    public void CheckTsAsync()
    {
        try
        {
            string Insta_client_id = ConfigurationManager.AppSettings["InstaClient"];
            string Insta_client_secret = ConfigurationManager.AppSettings["InstaSecret"];
            string Insta_Endpoint = ConfigurationManager.AppSettings["InstaEndPoint"];
            string Insta_Auth_Endpoint = ConfigurationManager.AppSettings["InstaAuthEndPoint"];
            Instamojo objClass = InstamojoImplementation.getApi(Insta_client_id, Insta_client_secret, Insta_Endpoint, Insta_Auth_Endpoint);​
            
            #region   4. Get details of this payment order Using TransactionId
            //  Get details of this payment order Using TransactionId
            try
            {
                string tr_id = Request.QueryString["transaction_id"];
                BookingDetails booking = new BookingDetails();
                PaymentOrderDetailsResponse objPaymentRequestDetailsResponse = objClass.getPaymentOrderDetailsByTransactionId(tr_id);
                var bookingGuid = BookingDetails.GetBookingGuidWithTransID(conGV, tr_id);

                string pStatus = objPaymentRequestDetailsResponse.status;
                if (pStatus == "completed")
                {
                    booking.BookingGuid = bookingGuid;
                    booking.BookingStatus = "Completed";
                    booking.PaymentStatus = "Paid";
                    booking.PaymentMode = "Payment Gateway";
                    booking.PaymentID = Request.QueryString["payment_id"] != null ? Request.QueryString["payment_id"] : "";
                    int x = BookingDetails.UpdatePaymentDetails(conGV, booking);
                    if (x > 0)
                    {
                        //Update BookingSlots to Completed
                        var exe = BookingSlots.UpdateBookingComplete(conGV, bookingGuid);
                        BookingDetails.SendToUser(conGV, bookingGuid);
                        Response.Redirect("PaymentSuccess.aspx?o=" + bookingGuid);
                    }
                }
                else
                {
                    booking.BookingGuid = bookingGuid;
                    booking.PaymentStatus = "Failed";
                    booking.BookingStatus = "Failed";
                    booking.PaymentMode = "";
                    booking.PaymentID = "";
                    int x = BookingDetails.UpdatePaymentDetails(conGV, booking);
                    if (x > 0)
                    {
                        Response.Redirect("PayError.aspx?e=error");
                    }
                }
            }
            catch (ArgumentNullException ex1)
            {
                Response.Redirect("PayError.aspx?e=error");
                ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CheckTsAsync", ex1.Message);
            }
            catch (WebException ex14)
            {
                Response.Redirect("PayError.aspx?e=error");
                ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CheckTsAsync", ex14.Message);
            }
            catch (Exception ex56)
            {
                ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CheckTsAsync", ex56.Message);
            }
            #endregion
​
        }
        catch (Exception exb)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CheckTsAsync", exb.Message);
        }
    }


}