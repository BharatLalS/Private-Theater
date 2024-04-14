using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class details : System.Web.UI.Page
{
    SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
    public string StrTheaterGallery = "", StrTiming = "", strAreaUrl, strTheaterUrl, StrTheaterTitle = "", StrTheaterDesc = "", StrTheaterLocation = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        strAreaUrl = Convert.ToString(RouteData.Values["AUrl"]);
        strTheaterUrl = Convert.ToString(RouteData.Values["TUrl"]);
        if (strAreaUrl != "" && strTheaterUrl != "")
        {
            BindTheater();
        }
        else
        {
            Response.Redirect("/404", false); return;
        }
    }
    public void BindTheater()
    {
        try
        {
            var areaurl = Convert.ToString(RouteData.Values["AUrl"]);
            var theaterurl = Convert.ToString(RouteData.Values["TUrl"]);

            var theater = TheaterDetails.GetAllTheaterDetailsWithUrlAndAreaUrl(conSQ, theaterurl, areaurl);
            if (theater != null)
            {
                lblhidden.Text = theater.TheaterGuid;
                StrTheaterTitle = theater.TheaterTitle;
                Page.Title = theater.PageTitle;
                Page.MetaDescription = theater.MetaDesc;
                Page.MetaKeywords = theater.MetaKeys;
                StrTheaterDesc = theater.FullDesc;
                StrTheaterLocation = theater.LocationLink;
                BindGallery(theater.TheaterGuid);

                //  BindTiming(theater.TheaterGuid, theater.Price);
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindTheater", ex.Message);
        }
    }

    public void BindGallery(string TGuid)
    {
        try
        {
            var images = TheaterImages.GetAllTheaterImagesWithTheaterID(conSQ, TGuid);
            if (images != null && images.Count > 0)
            {
                StrTheaterGallery = "";
                for (int i = 0; i < images.Count; i++)
                {
                    StrTheaterGallery += @"<div class='owl-item'>
                                        <div class='item'>
                                            <img src='/" + images[i].ImageUrl + @"' class='img-fluid' alt='image" + i + @"'>
                                        </div>
                                    </div>";
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindGallery", ex.Message);

        }
    }
    [WebMethod(EnableSession = true)]
    public static string BindTiming(string date, string month, string year, string theater)
    {
        SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
        string x = "";
        try
        {
            if (date != "" && month != "" && year != "" && theater != "")
            {

                DateTime Currdate = Convert.ToDateTime(date + "/" + month + "/" + year);
                var theaterdetails = TheaterDetails.GetAllTheaterDetailsWithGuid(conSQ, theater);
                var timings = TheaterTiming.GetAllTheaterTimingWithTheaterID(conSQ, theater);
                if (timings != null && timings.Count > 0)
                {
                    for (int i = 0; i < timings.Count; i++)
                    {
                        var timingexist = BookingSlots.GetBookedSlotByDate(conSQ, Currdate, timings[i].TimingGuid);
                        if (timingexist > 0)
                        {
                            x += @"<div class='reason-box col-lg-12 col-md-12 col-6 text-center timeslots disable'>
                                                <input type='checkbox' class='timeSlot-btn time-selected' disabled data-id='" + timings[i].TimingGuid + @"' id='time" + i + @"' name='time'>
                                                <label for='time" + i + @"'>" + timings[i].StartTime + @" - " + timings[i].EndTime + @" </label>
                                                <p>₹ " + theaterdetails.Price + @"</p>
                                            </div>";
                        }
                        else
                        {
                            x += @"<div class='reason-box col-lg-12 col-md-12 col-6 text-center timeslots'>
                                                <input type='checkbox' class='timeSlot-btn time-selected' data-id='" + timings[i].TimingGuid + @"' id='time" + i + @"' name='time'>
                                                <label for='time" + i + @"'>" + timings[i].StartTime + @" - " + timings[i].EndTime + @" </label>
                                                <p>₹ " + theaterdetails.Price + @"</p>
                                            </div>";

                        }

                    }
                    return x;

                }
                return "Empty";

            }
            else
            {
                return "Error";
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindTiming", ex.Message);
            return "Error";
        }
    }
    [WebMethod(EnableSession = true)]
    public static string BindPax(string theater)
    {
        SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
        string x = "";
        try
        {
            if (theater != null)
            {
                var theaterdetails = TheaterDetails.GetAllTheaterDetailsWithGuid(conSQ, theater);
                if (theaterdetails != null)
                {
                    var count = Convert.ToInt32(theaterdetails.MaxAllowed);
                    for (int i = 0; i < count; i++)
                    {
                        x += @"<option value='" + (i + 1) + @"'>" + (i + 1) + " people</option>";
                    }
                    return x;

                }
            }
            return "Empty";

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindPax", ex.Message);
            return "Error";
        }
    }

    [WebMethod(EnableSession = true)]
    public static string BindPayDetails(string theater)
    {
        SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
        try
        {
            if (theater != null)
            {
                var theaterdetails = TheaterDetails.GetAllTheaterDetailsWithGuid(conSQ, theater);
                if (theaterdetails != null)
                {
                    var price = theaterdetails.Price;
                    var extprice = theaterdetails.ExtraPrice;
                    var allowedlimit = theaterdetails.MaxCapacity;

                    return JsonConvert.SerializeObject(new { price, extprice, allowedlimit });

                }
            }
            return "Empty";

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindPayDetails", ex.Message);
            return "Error";
        }

    }

    [WebMethod(EnableSession = true)]
    public static string BookNow(string date, string theater, List<string> timeslots, string name, string Email, string Phone, string Pax)
    {
        SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);

        try
        {
            var bookingdate = Convert.ToDateTime(date);
            var maxid = BookingDetails.GetBMax(conSQ);
            var theaterdetails = TheaterDetails.GetAllTheaterDetailsWithGuid(conSQ, theater);
            int pax = 0;
            int.TryParse(Pax, out pax);
            int cnt = 0;
            int.TryParse(timeslots.Count().ToString(), out cnt);
            int limit = 0;
            int.TryParse(theaterdetails.MaxCapacity, out limit);
            decimal price = 0;
            decimal.TryParse(theaterdetails.Price, out price);
            decimal extprice1 = 0;
            decimal.TryParse(theaterdetails.ExtraPrice, out extprice1);
            int extra1 = (pax - limit) > 0 ? pax - limit : 0;
            decimal slottotal = cnt * price;
            decimal extpaxtotal = extra1 * extprice1;
            decimal totalPrice = slottotal + extpaxtotal;

            var booking = new BookingDetails()
            {
                BookingID = "BPO" + maxid,
                BookingGuid = Guid.NewGuid().ToString(),
                TheaterGuid = theater,
                BookingDate = bookingdate,
                BookingStatus = "Initiated",
                UserGuid = Guid.NewGuid().ToString(),
                UserName = name,
                UserEmail = Email,
                UserPhoneNo = Phone,
                SlotTotal = slottotal.ToString(),
                ExtPaxTotal = extpaxtotal.ToString(),
                NoOfPax = Pax,
                Subtotal = totalPrice.ToString(),
                AddedOn = TimeStamps.UTCTime(),
                AddedIP = CommonModel.IPAddress(),
                Status = "Active"
            };
            var exe = BookingDetails.AddBookingDetails(conSQ, booking);
            if (exe > 0)
            {
                if (timeslots.Count > 0)
                {
                    for (int i = 0; i < timeslots.Count(); i++)
                    {
                        var timeslot = new BookingSlots()
                        {
                            BookingDate = bookingdate,
                            BookingGuid = booking.BookingGuid,
                            TheaterGuid = theater,
                            TimingGuid = timeslots[i],
                            AddedIP = CommonModel.IPAddress(),
                            AddedOn = TimeStamps.UTCTime(),
                            Status = "Active",
                            Quantity = "1"
                        };
                        var exe1 = BookingSlots.AddBookingSlots(conSQ, timeslot);
                    }
                    return "Success|" + booking.BookingGuid;
                }

            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BookNow", ex.Message);
            return "Error";

        }
        return "Error";
    }
    //public void BindTiming(string TGuid, string price)
    //{
    //    try
    //    {
    //        var timing = TheaterTiming.GetAllTheaterTimingWithTheaterID(conSQ, TGuid);

    //        if (timing != null && timing.Count > 0)
    //        {
    //            for (int i = 0; i < timing.Count; i++)
    //            {
    //                StrTiming += @"<div class='reason-box col-lg-12 col-md-12 col-6 text-center'>
    //                                            <input type='checkbox' class='timeSlot-btn time-selected' id='time" + i + @"'>
    //                                            <label for='time" + i + "'>" + timing[i].StartTime + " - " + timing[i].EndTime + @"</label>
    //                                            <p>₹ " + price + @"</p>
    //                                        </div>";
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindTiming", ex.Message);

    //    }
    //}
}