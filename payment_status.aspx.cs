using InstamojoAPI;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class payment_status : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConSQ"].ConnectionString);
    //productInfo pi = new productInfo();
    public string payStatus, strpayStatus = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            #region   4. Get details of this payment order Using TransactionId

            try
            {
                string payStatus = "";
                string bookingid = Request.QueryString["booking_id"];
                var paymentStatus = InstamojoAPIs.GetPaymentRequesDetailst1_1(Request.QueryString["payment_request_id"]);
                if (paymentStatus != null)
                {
                    payStatus = paymentStatus.payment_request == null ? "" : paymentStatus.payment_request.status;
                }

                //Response.Write(sts);
                BookingDetails booking = new BookingDetails();

                if (payStatus.ToLower() == "completed")
                {
                    //string Oid = UserCheckout.GetOrderId(conn, orderId);
                    // string rId = UserCheckout.GetRMax(conn);
                    booking.BookingGuid = bookingid;
                    booking.PaymentStatus = "Paid";
                    booking.BookingStatus = "Completed";
                    booking.PaymentID = paymentStatus.payment_request.id;
                    //orders.hostedCheckoutId = "";
                    //orders.RMax = rId;
                    //orders.ReceiptNo = "MBKP" + rId;
                    int x = BookingDetails.UpdateBookingDetails(conn, booking);
                    if (x > 0)
                    {
                        //Update BookingSlots to Completed
                        var exe = BookingSlots.UpdateBookingComplete(conn, bookingid);
                        //SendConfirmMail(bookingid);
                        Response.Redirect("PaymentSuccess.aspx?o=" + bookingid);
                    }


                }
                else
                {

                    strpayStatus = @"<div class='col-lg-3'></div>
                               <div class='col-md-6' style='height:200px;display:table-cell; vertical-align:middle;'>
                           <center> <p>Transcation failed ! Kindly try again<a href='" + ConfigurationManager.AppSettings["domain"] + "'>Home</a></p></center></div>";
                    booking.BookingGuid = bookingid;
                    booking.PaymentStatus = "Failed";
                    booking.BookingStatus = "Failed";
                    booking.PaymentID = "";
                    int x = BookingDetails.UpdateBookingDetails(conn, booking);
                    if(x>0)
                    {
                        Response.Redirect("PayError.aspx?o=" + bookingid);
                    }
                }

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Transaction Id = '+'" + objPaymentRequestDetailsResponse.status + "');", true);
                // MessageBox.Show("Transaction Id = " + objPaymentRequestDetailsResponse.transaction_id);
            }
            catch (ArgumentNullException ex)
            {

                Response.Write(ex.Message);
                payStatus = @"There is some problem now. Please try again later ";
            }
            catch (WebException ex)
            {
                Response.Write(ex.Message);
                payStatus = @"There is some problem now. Please try again later ";
            }
            catch (Exception ex)
            {
                Response.Write("Error:" + ex.Message);
                payStatus = @"There is some problem now. Please try again later ";
            }
            #endregion

        }
    }

    //public void SendConfirmMail(string ctguid)
    //{
    //    string query = "SELECT Orders.*, UserBillingAddress.FirstName,UserBillingAddress.LastName,UserBillingAddress.Mobile,UserBillingAddress.Address1,UserBillingAddress.Address2,UserBillingAddress.EmailId FROM UserBillingAddress INNER JOIN Orders ON UserBillingAddress.OrderGuid=Orders.OrderGuid where Orders.OrderGuid=@OrderGuid";
    //    SqlCommand cmd = new SqlCommand(query, conn);
    //    cmd.Parameters.AddWithValue("@OrderGuid", SqlDbType.NVarChar).Value = ctguid;
    //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
    //    DataTable dt = new DataTable();
    //    sda.Fill(dt);
    //    if (dt.Rows.Count > 0)
    //    {
    //        string title = "";
    //        string queryBattery = "Select * from battery_details where battery_guid=@battery_guid";
    //        SqlCommand cmdBattery = new SqlCommand(queryBattery, conn);
    //        cmdBattery.Parameters.AddWithValue("@battery_guid", SqlDbType.NVarChar).Value = dt.Rows[0]["BatteryGuid"];
    //        SqlDataAdapter sdaBattery = new SqlDataAdapter(cmdBattery);
    //        DataTable dtBattery = new DataTable();
    //        sdaBattery.Fill(dtBattery);
    //        if (dtBattery.Rows.Count > 0)
    //        {
    //            title = dtBattery.Rows[0]["title"].ToString();
    //        }
    //        string deliveryDate = Convert.ToDateTime(dt.Rows[0]["OrderOn"].ToString()).AddDays(5).ToString("dd/MMM/yyyy");

    //        string AdminmailBody = @"<div>
    //                                        <div class='container' style='width:1024px;margin:0px auto;font-family:'calibri';'>
    //                                        <center><h2> Hi Admin, You have received on order, Below are the details</h2></center>
    //                                         <table style='width:100%;margin-bottom:20px;'>
    //                                      <tr>
    //                                            <td style='width:25%;'>Customer Name : " + dt.Rows[0]["FirstName"] + @" " + dt.Rows[0]["LastName"] + @"</td>
    //                                            <td style='width:25%;'>Contact No. : +91 " + dt.Rows[0]["Mobile"] + @"</td>
    //                                       <td style='width:25%;'>Email : " + dt.Rows[0]["EmailId"] + @"</td>
    //                                        <td style='width:25%;'>Address : " + dt.Rows[0]["Address1"] + @" " + dt.Rows[0]["Address2"] + @"</td>
    //                                      </tr>

    //                                    </table> 
    //                                        <table style='width:100%;border:1px solid #dcdcdc;'>
    //                                      <tr style='background-color:#0C54A0;color:#fff;padding:5px;'>
    //                                        <th style='padding:5px 0px;'>Product Name</th>
    //                                        <th style='padding:5px 0px;'>Amount</th>
    //                                       <th style='padding:5px 0px;'>Payment Mode</th>
    //                                        <th style='padding:5px 0px;'>Order No</th>
    //                                        <th style='padding:5px 0px;'>Expected Delivery</th>
    //                                      </tr>
    //                                      <tr>
    //                                        <td style='border:1px solid #dcdcdc;text-align:center;'>" + title + @"</td>
    //                                         <td style='border:1px solid #dcdcdc;text-align:center;'>" + dt.Rows[0]["TotalPrice"] + @" INR</td>
    //                                    <td style='border:1px solid #dcdcdc;text-align:center;'>" + dt.Rows[0]["PaymentMode"] + @"</td>
    //                                         <td style='border:1px solid #dcdcdc;text-align:center;'>" + dt.Rows[0]["OrderId"] + @"</td>
    //                                         <td style='border:1px solid #dcdcdc;text-align:center;'>3 Hrs to 24 Hrs</td>
    //                                      </tr>

    //                                    </table></div></div>";
    //        string mailBody = @"<div>
    //                                        <div class='container' style='width:1024px;margin:0px auto;font-family:'calibri';'>
    //                                        <center><h2>Your Order Has been Placed Successfully</h2></center>
    //                                         <table style='width:100%;margin-bottom:20px;'>
    //                                      <tr>
    //                                        <td style='width:25%;'>Customer Name : " + dt.Rows[0]["FirstName"] + @" " + dt.Rows[0]["LastName"] + @"</td>
    //                                        <td style='width:25%;'>Contact No. : +91 " + dt.Rows[0]["Mobile"] + @"</td>
    //                                       <td style='width:25%;'>Email : " + dt.Rows[0]["EmailId"] + @"</td>
    //                                        <td style='width:25%;'>Address : " + dt.Rows[0]["Address1"] + @" " + dt.Rows[0]["Address2"] + @"</td>
    //                                      </tr>

    //                                    </table> 
    //                                        <table style='width:100%;border:1px solid #dcdcdc;'>
    //                                      <tr style='background-color:#0C54A0;color:#fff;padding:5px;'>
    //                                        <th style='padding:5px 0px;'>Product Name</th>
    //                                        <th style='padding:5px 0px;'>Amount</th>
    //                                       <th style='padding:5px 0px;'>Payment Mode</th>
    //                                        <th style='padding:5px 0px;'>Order No</th>
    //                                        <th style='padding:5px 0px;'>Expected Delivery</th>
    //                                      </tr>
    //                                      <tr>
    //                                        <td style='border:1px solid #dcdcdc;text-align:center;'>" + title + @"</td>
    //                                         <td style='border:1px solid #dcdcdc;text-align:center;'>" + dt.Rows[0]["TotalPrice"] + @" INR</td>
    //                                    <td style='border:1px solid #dcdcdc;text-align:center;'>" + dt.Rows[0]["PaymentMode"] + @"</td>
    //                                         <td style='border:1px solid #dcdcdc;text-align:center;'>" + dt.Rows[0]["OrderId"] + @"</td>
    //                                         <td style='border:1px solid #dcdcdc;text-align:center;'>3 Hrs to 24 Hrs</td>
    //                                      </tr>

    //                                    </table><center><h2>For any queries Reach us " + ConfigurationManager.AppSettings["from"] + " or Call Us +91 9620246862</h2></center></div></div>";

    //        if (dt.Rows[0]["EmailId"].ToString() != "")
    //        {
    //            pi.sendemail(dt.Rows[0]["EmailId"].ToString(), mailBody);
    //        }
    //        pi.sendemailtoAdmin(ConfigurationManager.AppSettings["from"], AdminmailBody);
    //    }
    //}

}