using InstamojoAPI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class receipt : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);

    public string productDetails = "", strTo = "", strDelAddress = "", subTotal = "", strDiscount = "", delCharge = "", FinalPrice = "", payMode = "", Bookingon = "", ShipMethod = "", strTax = "", strDeliveryDate = "", strTimeSlot = "", strDeliveryNote = "";
    public string finalDiscount = "", strBookingDetail,StrCoupon = "", AddOnFinalPrice = "", PaxFinalPrice, StrNoofPAx = "", TimeFinalPrice, strTheater = "", strTransactional = "", strReceiptNo = "", strBookingId = "", strCODCharge = "", subTotalWithoutTax = "", strPaymentStaus = "", strTaxableAmount = "", strTaxPercentage = "", strAddDiscount = "", strDeliveryType = "", strssts = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["o"] != null)
        {
            ProductDetails();
        }
        else
        {
            Response.Redirect(ConfigurationManager.AppSettings["domain"]);
        }
    }

    public void ProductDetails()
    {
        try
        {
            BookingDetails report = BookingDetails.GetBookingDetailsWithBookingGuid(con, Request.QueryString["o"]);
            if (report != null)
            {
                decimal taxAmount = 0;
                strBookingId = Convert.ToString(report.BookingID);
                payMode = Convert.ToString(report.PaymentMode);
                Bookingon = Convert.ToDateTime(report.AddedOn).ToString("dd-MMM-yyyy hh:mm tt");
                strReceiptNo = Convert.ToString(report.ReceiptNo);

                //Theater Details
                var theater = TheaterDetails.GetAllTheaterDetailsWithGuid(con, report.TheaterGuid);
                strTheater = "<h3>" + theater.TheaterTitle + @"</h3><p>" + theater.Address + @"</p>";

                //Booking Details
                strBookingDetail = BookingDetails.BindBookingDetails(con, Request.QueryString["o"]);

                StrNoofPAx = (Convert.ToInt32(report.NoOfPax) - Convert.ToInt32(theater.MaxCapacity)).ToString() + " people";
                strssts = report.BookingStatus;
                strPaymentStaus = report.PaymentStatus.ToLower() == "initiated" || report.PaymentStatus.ToLower() == "" ? "Not Paid" : report.PaymentStatus;
                if (Convert.ToInt32(report.NoOfPax) > 0)
                {
                    trExtpaxtotal.Visible = true;
                    PaxFinalPrice = report.ExtPaxTotal;
                }
              
                trTimetotal.Visible = true;
                TimeFinalPrice = report.SlotTotal;
                decimal tax = 0;

                if (report.TaxAmount != "")
                {
                    tax = Convert.ToDecimal(report.TaxAmount) / Convert.ToDecimal(2);
                }
                if (report.Subtotal == "0" || report.Subtotal == "" || report.Subtotal == null)
                {
                    trsub.Visible = false;
                }
                else
                {
                    trsub.Visible = true;
                    decimal sub = 0;
                    decimal.TryParse(report.Subtotal, out sub);
                    subTotal = sub.ToString(".00");
                }

                if (report.SubTotalWithoutTax == "0" || report.SubTotalWithoutTax == "" || report.SubTotalWithoutTax == null)
                {
                    trwithoutTax.Visible = false;
                }
                else
                {
                    trwithoutTax.Visible = false;
                    decimal sub = 0;
                    decimal.TryParse(report.SubTotalWithoutTax, out sub);
                    subTotalWithoutTax = sub.ToString(".00");
                }
                if (report.Discount == "0" || report.Discount == "" || report.Discount == null)
                {
                    trdis.Visible = false;
                }
                else
                {
                    trdis.Visible = true;
                    decimal sub = 0;
                    decimal.TryParse(report.Discount, out sub);
                    strDiscount = sub.ToString(".00");
                }
                if (report.PromoCode != "")
                {
                    StrCoupon = "(" + report.PromoCode + ")";
                }
                if (tax == 0)
                {
                    trcgst.Visible = false;
                    trsgst.Visible = false;
                }
                else
                {
                    trcgst.Visible = true; trsgst.Visible = true;

                    strTax = tax.ToString(".00");

                }
                List<BookingAddOns> items = BookingAddOns.GetAllBookingAddOnsDetailsWithBooking(con, Request.QueryString["o"]);
                if (items.Count > 0)
                {
                    decimal fPrice = 0;
                    decimal addontotal = 0;
                    for (int i = 0; i < items.Count; i++)
                    {
                        decimal tax_ = 0, fTax = 0;

                        decimal price = 0, qty = 0;
                        decimal.TryParse(items[i].Quantity, out qty);


                        decimal.TryParse(items[i].ItemPrice, out price);
                        fPrice += (qty * price);

                        decimal.TryParse(items[i].TaxPercentage, out tax_);


                        //fTax = ((Convert.ToDecimal(0) + tax_) / Convert.ToDecimal(0));
                        //  fTax = 0; ;
                        //taxAmount += ((Convert.ToDecimal(price) * qty) - ((Convert.ToDecimal(price) * qty) / fTax));
                        //taxAmount += 0;





                        productDetails += @"<tr>
                                              <td>" + (i + 1) + @"</td>
                                              <td><b>" + items[i].Category + @"</b><br></td>
                                              <td><b>" + items[i].ProductName + @"</b><br></td>
                                              <td align='right'>" + items[i].Quantity + @"</td> 
                                              <td align='right'>₹ " + (price.ToString() == "0" ? "0" : (price).ToString(".##")) + @"</td>                                              
                                              <td align='right' colspan='2'>₹ " + ((price) * qty) + @"</td>
                                            </tr>";
                        addontotal += Convert.ToDecimal(items[i].ItemTotal);
                    }
                    traddontotal.Visible = true;
                    AddOnFinalPrice += addontotal.ToString(".##");
                }


                //trsgst.Visible = trcgst.Visible = false;
                // trigst.Visible = true;
                //strTax = taxAmount.ToString(".00");
                //trdis.Visible = false;
            }
        }
        catch (Exception ex)
        {
            //Response.Write(ex.Message);
        }
    }
}