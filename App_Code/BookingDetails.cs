using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Security.Cryptography;
using System.IO;

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
    public string TaxPercentage { get; set; }
    public string TaxAmount { get; set; }
    public string SubTotalWithoutTax { get; set; }
    public string Discount { get; set; }
    public string PaymentMode { get; set; }
    public string PromoCode { get; set; }
    public string PaymentID { get; set; }
    public string TransactionID { get; set; }
    public string PaymentStatus { get; set; }
    public string ReceiptNo { get; set; }
    public string CakeMessage { get; set; }
    public string Notes { get; set; }
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
                (BookingID, BookingGuid, TheaterGuid, BookingDate, BookingStatus, UserGuid, UserName, 
                    UserEmail, UserPhoneNo, NoOfPax, SlotTotal, ExtPaxTotal,TaxPercentage, TaxAmount, SubTotalWithoutTax,
                    Discount, PaymentMode, PromoCode, PaymentID, PaymentStatus, ReceiptNo, CakeMessage,
                    Notes, Subtotal, AddedOn, AddedIP, Status) 
             VALUES 
                (@BookingID, @BookingGuid, @TheaterGuid, @BookingDate, @BookingStatus, @UserGuid, @UserName,
                    @UserEmail, @UserPhoneNo, @NoOfPax, @SlotTotal, @ExtPaxTotal,@TaxPercentage, @TaxAmount, @SubTotalWithoutTax,
                    @Discount, @PaymentMode, @PromoCode, @PaymentID, @PaymentStatus, @ReceiptNo, @CakeMessage,
                    @Notes, @Subtotal, @AddedOn, @AddedIP, @Status)";

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
                command.Parameters.AddWithValue("@TaxPercentage", booking.TaxPercentage);
                command.Parameters.AddWithValue("@TaxAmount", booking.TaxAmount);
                command.Parameters.AddWithValue("@SubTotalWithoutTax", booking.SubTotalWithoutTax);
                command.Parameters.AddWithValue("@Discount", booking.Discount);
                command.Parameters.AddWithValue("@PaymentMode", booking.PaymentMode);
                command.Parameters.AddWithValue("@PromoCode", booking.PromoCode);
                command.Parameters.AddWithValue("@PaymentID", booking.PaymentID);
                command.Parameters.AddWithValue("@PaymentStatus", booking.PaymentStatus);
                command.Parameters.AddWithValue("@ReceiptNo", booking.ReceiptNo);
                command.Parameters.AddWithValue("@CakeMessage", booking.CakeMessage);
                command.Parameters.AddWithValue("@Notes", booking.Notes);
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
            string query = "Select * from BookingDetails Where BookingGuid=@BookingGuid and BookingStatus !=@Status";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@BookingGuid", SqlDbType.NVarChar).Value = bookingGuid;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Completed";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                booking = (from DataRow dr in dt.Rows
                           select new BookingDetails()
                           {
                               Id = Convert.ToInt32(dr["Id"]),
                               BookingID = Convert.ToString(dr["BookingID"]),
                               BookingGuid = Convert.ToString(dr["BookingGuid"]),
                               TheaterGuid = Convert.ToString(dr["TheaterGuid"]),
                               BookingDate = Convert.ToDateTime(dr["BookingDate"]),
                               BookingStatus = Convert.ToString(dr["BookingStatus"]),
                               UserGuid = Convert.ToString(dr["UserGuid"]),
                               UserName = Convert.ToString(dr["UserName"]),
                               UserEmail = Convert.ToString(dr["UserEmail"]),
                               UserPhoneNo = Convert.ToString(dr["UserPhoneNo"]),
                               NoOfPax = Convert.ToString(dr["NoOfPax"]),
                               SlotTotal = Convert.ToString(dr["SlotTotal"]),
                               ExtPaxTotal = Convert.ToString(dr["ExtPaxTotal"]),
                               TaxPercentage = Convert.ToString(dr["TaxPercentage"]),
                               TaxAmount = Convert.ToString(dr["TaxAmount"]),
                               SubTotalWithoutTax = Convert.ToString(dr["SubTotalWithoutTax"]),
                               Discount = Convert.ToString(dr["Discount"]),
                               PaymentMode = Convert.ToString(dr["PaymentMode"]),
                               PromoCode = Convert.ToString(dr["PromoCode"]),
                               PaymentID = Convert.ToString(dr["PaymentID"]),
                               PaymentStatus = Convert.ToString(dr["PaymentStatus"]),
                               ReceiptNo = Convert.ToString(dr["ReceiptNo"]),
                               CakeMessage = Convert.ToString(dr["CakeMessage"]),
                               Notes = Convert.ToString(dr["Notes"]),
                               Subtotal = Convert.ToString(dr["Subtotal"]),
                               AddedOn = Convert.ToDateTime(dr["AddedOn"]),
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
    public static BookingDetails GetBookingDetailsWithBookingGuid(SqlConnection conGV, string bookingGuid)
    {
        var booking = new BookingDetails();
        try
        {
            string query = "Select * from BookingDetails Where BookingGuid=@BookingGuid and BookingStatus !=@Status";
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
                               Id = Convert.ToInt32(dr["Id"]),
                               BookingID = Convert.ToString(dr["BookingID"]),
                               BookingGuid = Convert.ToString(dr["BookingGuid"]),
                               TheaterGuid = Convert.ToString(dr["TheaterGuid"]),
                               BookingDate = Convert.ToDateTime(dr["BookingDate"]),
                               BookingStatus = Convert.ToString(dr["BookingStatus"]),
                               UserGuid = Convert.ToString(dr["UserGuid"]),
                               UserName = Convert.ToString(dr["UserName"]),
                               UserEmail = Convert.ToString(dr["UserEmail"]),
                               UserPhoneNo = Convert.ToString(dr["UserPhoneNo"]),
                               NoOfPax = Convert.ToString(dr["NoOfPax"]),
                               SlotTotal = Convert.ToString(dr["SlotTotal"]),
                               ExtPaxTotal = Convert.ToString(dr["ExtPaxTotal"]),
                               TaxPercentage = Convert.ToString(dr["TaxPercentage"]),
                               TaxAmount = Convert.ToString(dr["TaxAmount"]),
                               SubTotalWithoutTax = Convert.ToString(dr["SubTotalWithoutTax"]),
                               Discount = Convert.ToString(dr["Discount"]),
                               PaymentMode = Convert.ToString(dr["PaymentMode"]),
                               PromoCode = Convert.ToString(dr["PromoCode"]),
                               PaymentID = Convert.ToString(dr["PaymentID"]),
                               PaymentStatus = Convert.ToString(dr["PaymentStatus"]),
                               ReceiptNo = Convert.ToString(dr["ReceiptNo"]),
                               CakeMessage = Convert.ToString(dr["CakeMessage"]),
                               Notes = Convert.ToString(dr["Notes"]),
                               Subtotal = Convert.ToString(dr["Subtotal"]),
                               AddedOn = Convert.ToDateTime(dr["AddedOn"]),
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
    public static int UpdateBookingDetails(SqlConnection conGV, BookingDetails booking)
    {
        int result = 0;
        try
        {
            string query = "UPDATE BookingDetails " +
                           "SET CakeMessage = @CakeMessage, " +
                           "Notes = @Notes, " +
                           "PaymentID = @PaymentID, " +
                           "TransactionID = @TransactionID, " +
                           "PaymentMode = @PaymentMode, " +
                           "PaymentStatus = @PaymentStatus, " +
                           "PromoCode = @PromoCode, " +
                           "Discount = @Discount, " +
                           "SubTotalWithoutTax = @SubTotalWithoutTax, " +
                           "TaxAmount = @TaxAmount, " +
                           "Subtotal = @Subtotal, " +
                           "AddedOn = @AddedOn, " +
                           "AddedIp = @AddedIp " +
                           "WHERE BookingGuid = @BookingGuid";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@BookingGuid", booking.BookingGuid);
                cmd.Parameters.AddWithValue("@CakeMessage", booking.CakeMessage);
                cmd.Parameters.AddWithValue("@Notes", booking.Notes);
                cmd.Parameters.AddWithValue("@PaymentID", booking.PaymentID);
                cmd.Parameters.AddWithValue("@TransactionID", booking.TransactionID);
                cmd.Parameters.AddWithValue("@PaymentMode", booking.PaymentMode);
                cmd.Parameters.AddWithValue("@PaymentStatus", booking.PaymentStatus);
                cmd.Parameters.AddWithValue("@PromoCode", booking.PromoCode);
                cmd.Parameters.AddWithValue("@Discount", booking.Discount);
                cmd.Parameters.AddWithValue("@SubTotalWithoutTax", booking.SubTotalWithoutTax);
                cmd.Parameters.AddWithValue("@TaxAmount", booking.TaxAmount);
                cmd.Parameters.AddWithValue("@Subtotal", booking.Subtotal);
                cmd.Parameters.AddWithValue("@AddedOn", booking.AddedOn);
                cmd.Parameters.AddWithValue("@AddedIp", booking.AddedIP);
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

    public static int UpdatePaymentDetails(SqlConnection conSQ, BookingDetails booking)
    {
        int result = 0;
        try
        {
            string query = "UPDATE BookingDetails " +
                           "SET " +
                           "PaymentID = @PaymentID, " +
                           "PaymentMode = @PaymentMode, " +
                           "PaymentStatus = @PaymentStatus, " +
                           "BookingStatus = @BookingStatus " +
                           "WHERE BookingGuid = @BookingGuid";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@BookingGuid", booking.BookingGuid);
                cmd.Parameters.AddWithValue("@PaymentID", booking.PaymentID);
                cmd.Parameters.AddWithValue("@BookingStatus", booking.BookingStatus);
                cmd.Parameters.AddWithValue("@PaymentMode", booking.PaymentMode);
                cmd.Parameters.AddWithValue("@PaymentStatus", booking.PaymentStatus);

                conSQ.Open();
                result = cmd.ExecuteNonQuery();
                conSQ.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateAddOnsQuantity", ex.Message);
        }
        return result;
    }
    public static string GetBookingGuidWithTransID(SqlConnection con, string TransID)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("select BookingGuid from BookingDetails where TransactionID=@TransactionID", con);
            cmd.Parameters.AddWithValue("@TransactionID", TransID);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string cc = Convert.ToString(dt.Rows[0]["BookingGuid"]);
                if (cc.Length > 0)
                {
                    return cc;
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetBookingGuidWithTransID", ex.Message);

        }
        return "";
    }
    public static string GetBookingIDWithBookingGuid(SqlConnection con, string BGuid)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("select BookingID from BookingDetails where BookingGuid=@BookingGuid", con);
            cmd.Parameters.AddWithValue("@BookingGuid", BGuid);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string cc = Convert.ToString(dt.Rows[0]["BookingID"]);
                if (cc.Length > 0)
                {
                    return cc;
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetBookingIDWithBookingGuid", ex.Message);

        }
        return "";
    }
    public static void SendToUser(SqlConnection conGV, string Bguid)
    {
        try
        {
            string query = "Select *,(Select Sum(Try_Convert(decimal,ItemTotal)) from BookingAddons Where BookingGuid=@BookingGuid and Status !='Deleted') as AddonTotal  from BookingDetails Where BookingGuid=@BookingGuid";
            SqlCommand cmd = new SqlCommand(query, conGV);
            cmd.Parameters.AddWithValue("@BookingGuid", SqlDbType.NVarChar).Value = Bguid;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string pType = Convert.ToString(dt.Rows[0]["PaymentMode"]);
                string pTable = ProductDetails(conGV, Bguid);
                string theaterdetails = BindTheaterDetails(conGV, dt.Rows[0]["TheaterGuid"].ToString());

                string bookingdetails = BindBookingDetails(conGV, dt.Rows[0]["BookingGuid"].ToString());


                string Disc = "";
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["Discount"])))
                {
                    Disc = @"<tr style='padding-bottom:5px;border-top:1px solid #856869'><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;padding:1%;' class='flexibleContainerCell'> Discount </th><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;text-align:right;padding:1%;' class='flexibleContainerCell'>- ₹" + Convert.ToString(dt.Rows[0]["Discount"]) + "</th></tr>";
                }

                string AddDisc = "";
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["TaxAmount"])))
                {
                    AddDisc = @"<tr style='padding-bottom:5px;border-top:1px solid #856869'><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;padding:1%;' class='flexibleContainerCell'> Total Tax (Excluded from price) </th><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;text-align:right;padding:1%;' class='flexibleContainerCell'>₹" + Convert.ToString(dt.Rows[0]["TaxAmount"]) + "</th></tr>";
                }
                else
                {
                    AddDisc = @"<tr style='padding-bottom:5px;border-top:1px solid #856869'><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;padding:1%;' class='flexibleContainerCell'> Total Tax (included in price) </th><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;text-align:right;padding:1%;' class='flexibleContainerCell'>₹ 0</th></tr>";
                }
                //string ship = "";
                //if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ShippingPrice"])))
                //{
                //    ship = @"<tr style='padding-bottom:5px;border-top:1px solid #856869'><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;padding:1%;' class='flexibleContainerCell'> Shipping & Handling </th><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;text-align:right;padding:1%;' class='flexibleContainerCell'>₹" + Convert.ToString(dt.Rows[0]["ShippingPrice"]) + "</th></tr>";
                //}
                string adv = "";
                if (pType == "COD")
                {
                    adv += @"<tr style='padding-bottom:5px;border-top:1px solid #856869'><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;padding:1%;' class='flexibleContainerCell'> Advance Paid </th><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;text-align:right;padding:1%;' class='flexibleContainerCell'>₹" + Convert.ToString(dt.Rows[0]["AdvAmount"]) == "" ? "0" : Convert.ToString(dt.Rows[0]["AdvAmount"]) + "</th></tr>";
                    adv += @"<tr style='padding-bottom:5px;border-top:1px solid #856869'><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;padding:1%;' class='flexibleContainerCell'> Balance Amount </th><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;text-align:right;padding:1%;' class='flexibleContainerCell'>₹" + Convert.ToString(dt.Rows[0]["BalAmount"]) == "" ? "0" : Convert.ToString(dt.Rows[0]["BalAmount"]) + "</th></tr>";
                }
                string slots = "";
                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["SlotTotal"])) && Convert.ToString(dt.Rows[0]["ExtPaxTotal"]) != "0")
                {
                    slots += @"<tr style='padding-bottom:5px;border-top:1px solid #856869'><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;padding:1%;' class='flexibleContainerCell'> Time Slots Amount </th><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;text-align:right;padding:1%;' class='flexibleContainerCell'>₹" + (Convert.ToString(dt.Rows[0]["SlotTotal"]) == "" ? "0" : Convert.ToDecimal(Convert.ToString(dt.Rows[0]["SlotTotal"])).ToString("N2")) + "</th></tr>";

                }
                string pax = "";

                if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[0]["ExtPaxTotal"])) && Convert.ToString(dt.Rows[0]["ExtPaxTotal"]) != "0")
                {
                    pax += @"<tr style='padding-bottom:5px;border-top:1px solid #856869'><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;padding:1%;' class='flexibleContainerCell'> Extra Pax Amount (" + (Convert.ToString(dt.Rows[0]["NoofPax"]) == "" ? "0" : Convert.ToString(dt.Rows[0]["NoofPax"])) + " people) </th><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;text-align:right;padding:1%;' class='flexibleContainerCell'>₹" + (Convert.ToString(dt.Rows[0]["ExtPaxTotal"]) == "" ? "0" : Convert.ToDecimal(Convert.ToString(dt.Rows[0]["ExtPaxTotal"])).ToString("N2")) + "</th></tr>";

                }
                string table = pTable +
                    "<tr style='padding-bottom:5px;border-top:1px solid #856869'><th align='left' valign='top' style='border-top: 1px solid #573e40!important;float:left;width:46%;color:#856869;font-size:15px;padding:1%;' class='flexibleContainerCell'> Sub Total </th><th align='left' valign='top' style='border-top: 1px solid #573e40!important;float:left;width:46%;color:#856869;font-size:15px;text-align:right;padding:1%;' class='flexibleContainerCell'>₹" + Convert.ToDecimal(Convert.ToString(dt.Rows[0]["AddonTotal"])).ToString() + "</th></tr>" +
                     Disc + adv + slots + pax +
                    AddDisc +
                    "<tr style='padding-bottom:5px;border-top:1px solid #856869'><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;padding:1%;' class='flexibleContainerCell'>  Grand Total </th><th align='left' valign='top' style='float:left;width:46%;color:#856869;font-size:15px;text-align:right;padding:1%;' class='flexibleContainerCell'>₹" + Convert.ToString(dt.Rows[0]["SubTotal"]) + "</th></tr>";

                Emails.BookingConfirmed(Convert.ToString(dt.Rows[0]["BookingId"]), table + "", Convert.ToString(dt.Rows[0]["UserName"]), Convert.ToString(dt.Rows[0]["UserEmail"]), Convert.ToString(dt.Rows[0]["UserPhoneNo"]), Convert.ToString(dt.Rows[0]["SubTotal"]), pType, theaterdetails, bookingdetails);
                Emails.BookingConfirmedAdmin(Convert.ToString(dt.Rows[0]["BookingId"]), Convert.ToString(dt.Rows[0]["UserName"]), Convert.ToString(dt.Rows[0]["UserEmail"]), Convert.ToString(dt.Rows[0]["UserPhoneNo"]), table + "", theaterdetails, bookingdetails);

                //SMSServices.SendOrderSuccess(Convert.ToString(dt.Rows[0]["Mobile1"]).Replace("-", ""), Convert.ToString(dt.Rows[0]["OrderId"]));
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "SendToUser", ex.Message);
        }
    }
    public static string ProductDetails(SqlConnection conGV, string oGuid)
    {
        string pTable = "";
        try
        {
            //Addons
            string query = "Select * from BookingAddons where BookingGuid = @BookingGuid";
            SqlCommand cmd = new SqlCommand(query, conGV);
            cmd.Parameters.AddWithValue("@BookingGuid", SqlDbType.NVarChar).Value = oGuid;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    //decimal p1 = Convert.ToDecimal(Convert.ToString(dr["ItemPrice"]));
                    //decimal qty = Convert.ToDecimal(Convert.ToString(dr["Quantity"]));
                    //decimal price = (p1 * qty);
                    pTable += @"<tr valign='middle'>
                                    <td align='left' valign='middle' style='float:left;width:25%;margin-bottom:10px;margin-top:20px;padding:1%;' class='flexibleContainerCell'><span style='font-size:16px;'><b>" + dr["Category"] + @"</b></span><br /></td>
                                    <td align='left' valign='middle' style='float:left;width:20%;margin-bottom:10px;margin-top:20px;padding:1%;' class='flexibleContainerCell'><span style='font-size:16px;'><b>" + dr["ProductName"] + @" </b></span><br /></td>
                                    <td align='left' valign='middle' style='float:left;width:15%;margin-bottom:10px;margin-top:20px;padding:1%;text-align:center;' class='flexibleContainerCell'>" + dr["Quantity"] + @" </td>
                                    <td align='left' valign='middle' style='float:left;width:15%;margin-bottom:10px;margin-top:20px;text-align:right;padding:1%;' class='flexibleContainerCell'>₹" + dr["ItemPrice"] + @" </td>
                                    <td align='left' valign='middle' style='float:left;width:10%;margin-bottom:10px;margin-top:20px;text-align:right;padding:1%;' class='flexibleContainerCell'>₹" + dr["ItemTotal"] + @" </td>
                                </tr>";
                }
                pTable = @"<tr style='border-bottom:1px solid #573e40!important;margin-bottom:10px'>
                                                                <th align='left' valign='top' style='border-bottom:1px solid #573e40!important;float:left;width:30%;color:#573e40;margin-bottom:10px;font-size:18px;font-weight:500;text-align:center' class='flexibleContainerCell'>Item Category </th>
                                                                <th align='left' valign='top' style='border-bottom:1px solid #573e40!important;float:left;width:20%;color:#573e40;margin-bottom:10px;font-size:18px;font-weight:500;text-align:center' class='flexibleContainerCell'>Item Name </th>
                                                                <th align='left' valign='top' style='border-bottom:1px solid #573e40!important;float:left;width:15%;color:#573e40;margin-bottom:10px;font-size:18px;font-weight:500;text-align:center' class='flexibleContainerCell'> Quantity </th>
                                                                <th align='left' valign='top' style='border-bottom:1px solid #573e40!important;float:left;width:15%;color:#573e40;margin-bottom:10px;font-size:18px;font-weight:500;text-align:center' class='flexibleContainerCell'> Price </th>
                                                                <th align='left' valign='top' style='border-bottom:1px solid #573e40!important;float:left;width:20%;color:#573e40;margin-bottom:10px;font-size:18px;font-weight:500;text-align:center' class='flexibleContainerCell'> Total </th>
                                                            </tr>" + pTable + "";
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "ProductDetails", ex.Message);

        }
        return pTable;
    }
    public static string BindTheaterDetails(SqlConnection conGV, string TGuid)
    {
        string tTable = "";
        try
        {
            string query = "Select Top 1 * from TheaterDetails where TheaterGuid = @TheaterGuid";
            SqlCommand cmd = new SqlCommand(query, conGV);
            cmd.Parameters.AddWithValue("@TheaterGuid", SqlDbType.NVarChar).Value = TGuid;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                tTable += @"<span>" + dt.Rows[0]["TheaterTitle"] + "</span>" +
                    "<br/>" +
                    "<span>" + dt.Rows[0]["Address"] + @"</span>";

            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindTheaterDetails", ex.Message);

        }
        return tTable;
    }
    public static string BindBookingDetails(SqlConnection conGV, string BGuid)
    {
        string tTable = "";
        try
        {
            string query = "Select * from BookingSlots where BookingGuid = @BookingGuid";
            SqlCommand cmd = new SqlCommand(query, conGV);
            cmd.Parameters.AddWithValue("@BookingGuid", SqlDbType.NVarChar).Value = BGuid;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tTable += @"<span><strong>Time Slot " + (i + 1) + @"</strong> : " + Convert.ToString(dt.Rows[i]["StartTime"]) + @" - " + Convert.ToString(dt.Rows[i]["EndTime"]) + @"</span></br>";
                }
                tTable = @" <span><strong>Booking Date</strong> : " + Convert.ToDateTime(dt.Rows[0]["BookingDate"]).ToString("dd MMM yyyy") + @"</span></br> " + tTable;

            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindTheaterDetails", ex.Message);

        }
        return tTable;
    }


    /// <summary>
    /// Retrieves orders from the database based on specified filters.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="filter">A FilterOptions object containing filtering criteria.</param>
    /// <returns>A DataTable containing orders filtered based on the specified criteria.</returns>

    public static DataTable GetBookingWithFilter(SqlConnection conSQ, FilterOptions filter)
    {

        var dt = new DataTable();
        try
        {
            int page = (Convert.ToInt32(filter.PgNo) - 1) * Convert.ToInt32(filter.PLenght);
            string query = "FilteredBookingList @BookingStatus,@Key,@StartDate,@EndDate,@PLenght,@Pno";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@BookingStatus", SqlDbType.NVarChar).Value = filter.OrderStatus;
                cmd.Parameters.AddWithValue("@Key", SqlDbType.NVarChar).Value = filter.SearchKey;
                cmd.Parameters.AddWithValue("@StartDate", SqlDbType.NVarChar).Value = filter.StartDate;
                cmd.Parameters.AddWithValue("@EndDate", SqlDbType.NVarChar).Value = filter.EndDate;
                cmd.Parameters.AddWithValue("@Pno", SqlDbType.Int).Value = page;
                cmd.Parameters.AddWithValue("@PLenght", SqlDbType.Int).Value = filter.PLenght;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                return dt;
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetOrdersWithFilters", ex.Message);
        }
        return dt;
    }
    #endregion


}    
//Filters Class
public class FilterOptions
{
    public FilterOptions()
    {

    }
    #region FilterProperties
    public string SearchKey { get; set; }
    public string OrderStatus { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public int PgNo { get; set; }
    public int PLenght { get; set; }
    #endregion
}