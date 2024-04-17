using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class add_on : System.Web.UI.Page
{
    SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
    public string strBookUrl = "", StrSlotPrice = "", StrTax = "", StrExtPaxCost = "", StrTotal = "", StrAddOnCategory = "", StrAddOnProducts = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        strBookUrl = Convert.ToString(RouteData.Values["BUrl"]);
        if (strBookUrl != "")
        {
            BindBookingDetails();
            BindAddons();
        }
        else
        {
            Response.Redirect("/404", false);
        }
    }
    public void BindBookingDetails()
    {
        try
        {
            var booking = BookingDetails.GetBookingDetails(conSQ, strBookUrl);
            if (booking != null)
            {
                var slottotal = Convert.ToDecimal(booking.SlotTotal);
                var paxtotal = Convert.ToDecimal(booking.ExtPaxTotal);
                var taxper = Convert.ToDecimal(booking.TaxPercentage);
                var tax = (slottotal + paxtotal) * (taxper / 100);
                StrSlotPrice = slottotal.ToString("N2");
                StrExtPaxCost = paxtotal.ToString("N2");
                StrTax = tax.ToString("N2");
                StrTotal = (slottotal + paxtotal + tax).ToString("N2");
            }
            else
            {
                Response.Redirect("/404", false);
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindBookingDetails", ex.Message);
        }
    }
    public void BindAddons()
    {
        try
        {
            var addons = AddOnCategories.GetAllAddOnCategories(conSQ);
            if (addons != null && addons.Count > 0)
            {
                for (int i = 0; i < addons.Count; i++)
                {

                    var nextbtn = "";
                    var previousbtn = "";
                    var cakemessage = "";
                    if (i == 0)
                    {
                        StrAddOnCategory += @"<li>
                                    <a class='active' data-toggle='tab' href='#" + addons[i].CategoryUrl + @"'>" + addons[i].CategoryTitle + @"</a>
                                </li>";
                        nextbtn = @"<div class='col-lg-6 col-md-6 col-6 text-center'>
                                    <a href='javascript:void(0);' class='custom-btn btn-next' tabindex='-1'>Next<i class=' ms-2 mt-1 fas fa-angle-right fa-lg'></i></a>
                                </div>";
                        previousbtn = "";
                    }
                    else if (i + 1 == addons.Count)
                    {
                        StrAddOnCategory += @"<li>
                                    <a data-toggle='tab' href='#" + addons[i].CategoryUrl + @"'>" + addons[i].CategoryTitle + @"</a>
                                </li>";
                        nextbtn = @"";
                        previousbtn = @"<div class='col-lg-6 col-md-6 col-6  text-center '>
                                    <a href='javascript:void(0);' class='custom-btn btn-prev' tabindex='-1'><i class=' me-2 mt-1 fas fa-angle-left fa-lg'></i> Prev</a>
                                </div>";
                    }
                    else
                    {
                        StrAddOnCategory += @" <li>
                                    <a data-toggle='tab' href='#" + addons[i].CategoryUrl + @"'>" + addons[i].CategoryTitle + @"</a>
                                </li>";
                        nextbtn = @"<div class='col-lg-6 col-md-6 col-6 text-end'>
                                    <a href='javascript:void(0);'  class='custom-btn btn-next' tabindex='-1'>Next <i class=' ms-2 mt-1 fas fa-angle-right fa-lg'></i></a>
                                </div>";
                        previousbtn = @"<div class='col-lg-6 col-md-6 col-6 text-start'>
                                    <a href='javascript:void(0);' class='custom-btn btn-prev' tabindex='-1'><i class='me-2 mt-1 fas fa-angle-left fa-lg'></i> Prev</a>
                                </div>";
                    }
                    if (addons[i].CategoryUrl.ToLower().Trim() == "cakes")
                    {
                        cakemessage = @"<div class='col-lg-5 mt-4 mx-auto'>
                                    <div class='input-group_1'>
                                        <i class='far fa-user'></i>
                                        <input type='text' placeholder='Message on cake' id='nick_name' class='cake_message'>
                                    </div>
                                </div>";
                    }
                    //Product Type Binding
                    var producttypes = AddOnProductType.GetAllProductTypeDetailsWithCategory(conSQ, addons[i].Id.ToString());
                    if (producttypes.Count > 0)
                    {
                        var strProduct = "";
                        for (var a = 0; a < producttypes.Count; a++)
                        {
                            var products = AddOnProducts.GetAllAddOnProductsWithType(conSQ, addons[i].Id.ToString(), producttypes[a].ProductType.ToString());
                            if (products != null && products.Count > 0)
                            {
                                strProduct += "<h4 class='fw-semibold'>" + producttypes[a].ProductType.ToString() + @"</h4>";
                                for (int j = 0; j < products.Count; j++)
                                {
                                    var optSec = "";
                                    if (products[j].AllowMultiple == "Yes")
                                    {
                                        optSec = @"<div class='add'>
                                                    <a class='qtyminus' aria-hidden='true'>−</a>
                                                    <input type='text' name='qty' id='qty' min='1' max='10' step='1' value='1'>
                                                    <a class='qtyplus' aria-hidden='true'>+</a>
                                                </div>";
                                    }
                                    else
                                    {
                                        if (products[j].Description != "")
                                        {
                                            optSec = "<a class='btn btn-primary btnknowmoremodal' data-title='" + products[j].ProductName + @"' data-id='" + products[j].ProductGuid + "'>know more</a>";

                                        }
                                        else
                                        {
                                            optSec = "";
                                        }
                                    }
                                    strProduct += @"<div class='col-lg-4 col-md-6 col-6'>
                                                        <div class='tile product-box' data-id='" + products[j].ProductGuid + @"'>
                                                            <input type='checkbox' name='party' id='" + products[j].ProductUrl + products[j].Id + @"' />
                                                                <label for='" + products[j].ProductUrl + products[j].Id + @"' class='theme-sec'>
                                                                <img src='/" + products[j].ThumbImage + @"' alt='" + products[j].ProductUrl + products[j].Id + @"' />
                                                                    <div class='content'>
                                                                        <p>" + products[j].ProductName + @"</p>
                                                                        <p>₹ " + Convert.ToInt32(products[j].Price).ToString("N0") + @"</p>
                                                                        " + optSec + @"           
                                                                     </div>
                                                                 </label>
                                                          </div>
                                                     </div>";

                                }
                            }
                            else
                            {
                                strProduct += "<h4 class='fw-semibold'>" + producttypes[a].ProductType.ToString() + @"</h4>";

                                strProduct += @"<div class='text-center'>No Add Ons To Show.</div>";
                            }

                        }
                        StrAddOnProducts += @"<div id='" + addons[i].CategoryUrl + @"' class='tab-pane fade " + (i == 0 ? "show active" : "") + @"'>
                            <div class='row mt-0 gy-4'>
                               " + strProduct + @"
                            </div> " + cakemessage + @"
                            <div class='row justify-content-center mt-2'>
                                " + previousbtn + nextbtn + @"
                            </div>
                        </div>";


                    }
                    else
                    {
                        var strProduct = "";
                        var products = AddOnProducts.GetAllAddOnProductsWithCategory(conSQ, addons[i].Id.ToString());

                        if (products != null && products.Count > 0)
                        {
                            for (int j = 0; j < products.Count; j++)
                            {
                                var optSec = "";
                                if (products[j].AllowMultiple == "Yes")
                                {
                                    optSec = @"<div class='add'>
                                                    <a class='qtyminus' aria-hidden='true'>−</a>
                                                    <input type='text' name='qty' id='qty' min='1' max='10' step='1' value='1'>
                                                    <a class='qtyplus' aria-hidden='true'>+</a>
                                                </div>";
                                }
                                else
                                {
                                    if (products[j].Description != "")
                                    {
                                        optSec = "<a class='btn btn-primary btnknowmoremodal' data-title='" + products[j].ProductName + @"' data-id='" + products[j].ProductGuid + "'>know more</a>";

                                    }
                                    else
                                    {
                                        optSec = "";
                                    }
                                }
                                strProduct += @"<div class='col-lg-4 col-md-6 col-6'>
                                    <div class='tile product-box' data-id='" + products[j].ProductGuid + @"'>
                                        <input type='checkbox' name='party' id='" + products[j].ProductUrl + products[j].Id + @"' />
                                        <label for='" + products[j].ProductUrl + products[j].Id + @"' class='theme-sec '>
                                        <img src='/" + products[j].ThumbImage + @"' alt='" + products[j].ProductUrl + products[j].Id + @"' />
                                            <div class='content'>
                                                <p>" + products[j].ProductName + @"</p>
                                                <p>₹ " + products[j].Price + @"</p>
                                                " + optSec + @"                 
                                            </div>
                                        </label>
                                    </div>
                                    </div>";

                            }
                        }
                        else
                        {
                            strProduct += @"No Add Ons To Show.";
                        }
                        StrAddOnProducts += @"<div id='" + addons[i].CategoryUrl + @"' class='tab-pane fade " + (i == 0 ? "show active" : "") + @"'>
                            <div class='row mt-0 gy-4'>
                               " + strProduct + @"
                            </div> " + cakemessage + @"
                            <div class='row justify-content-center mt-2'>
                                " + previousbtn + nextbtn + @"
                            </div>
                        </div>";

                    }
                }
            }


        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindAddons", ex.Message);
        }

    }

    [WebMethod(EnableSession = true)]
    public static string KnowMoreModalDetails(string PGuid)
    {
        SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
        var x = "";
        try
        {
            var Product = AddOnProducts.GetAllProductDetailsWithGuid(conSQ, PGuid);
            if (Product != null)
            {
                x = Product.Description;
                return x;
            }
            else
            {
                return "Empty";
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "KnowMoreModalDetails", ex.Message);
            return "Error";
        }
    }

    [WebMethod(EnableSession = true)]
    public static string UpdateAddon(string PGuid, string BGuid, string Qty)
    {
        try
        {
            SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
            var addon = new BookingAddOns()
            {
                ProductGuid = PGuid,
                BookingGuid = BGuid,
                AddedIp = CommonModel.IPAddress(),
                AddedOn = TimeStamps.UTCTime(),
                Quantity = Qty,
                Status = "Active",

            };
            if (Qty == "0")
            {
                //Delete
                var exe = BookingAddOns.DeleteBookingAddOns(conSQ, addon);
                if (exe > 0)
                {
                    return "Success";
                }
            }
            else
            {
                var product = AddOnProducts.GetAllProductDetailsWithGuid(conSQ, PGuid);
                decimal total = Convert.ToInt32(Qty) * Convert.ToDecimal(product.Price);
                var taxper = 18;
                decimal tax = (total * taxper) / 100;
                addon.ItemPrice = product.Price;
                addon.ItemTotal = total.ToString("N2");
                addon.ProductName = product.ProductName;
                addon.TaxPercentage = taxper.ToString();
                addon.TaxAmount = tax.ToString("N2");
                addon.TotalPrice = (total + tax).ToString("N2");
                addon.Category = product.CategoryTitle;
                var check = BookingAddOns.CheckProductExist(conSQ, addon);
                if (check > 0)
                {
                    //Update
                    var exe = BookingAddOns.UpdateAddOnsQuantity(conSQ, addon);
                    if (exe > 0)
                    {
                        return "Success";
                    }
                }
                else
                {
                    //Add
                    var exe = BookingAddOns.AddBookingAddOns(conSQ, addon);
                    if (exe > 0)
                    {
                        return "Success";
                    }
                }
            }
            return "Error";
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "KnowMoreModalDetails", ex.Message);
            return "Error";
        }
    }

    [WebMethod(EnableSession = true)]
    public static List<BookingAddOns> BindCart(string BGuid)
    {
        try
        {
            SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
            var Products = BookingAddOns.GetAllBookingAddOnsDetailsWithBooking(conSQ, BGuid);
            if (Products.Count > 0)
            {
                return Products;
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "KnowMoreModalDetails", ex.Message);
            return null;
        }
    }
}