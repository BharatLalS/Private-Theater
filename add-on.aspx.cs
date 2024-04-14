using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class add_on : System.Web.UI.Page
{
    SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
    public string strBookUrl = "", StrSlotPrice = "", StrExtPaxCost = "", StrTotal = "", StrAddOnCategory = "", StrAddOnProducts = "";
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
                StrSlotPrice = booking.SlotTotal;
                StrExtPaxCost = booking.ExtPaxTotal;
                StrTotal = booking.Subtotal;

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

                    var strProduct = "";
                    var nextbtn = "";
                    var previousbtn = "";

                    if (i == 0)
                    {
                        StrAddOnCategory += @"<li>
                                    <a class='active' data-toggle='tab' href='#" + addons[i].CategoryUrl + @"'>" + addons[i].CategoryTitle + @"</a>
                                </li>";
                        nextbtn = @"<div class='col-lg-4 col-md-6 col-6'>
                                    <a href='#" + addons[i + 1].CategoryUrl + @"' data-toggle='tab' class='custom-btn' tabindex='-1'>Next<i class=' ms-2 mt-1 fas fa-angle-right fa-lg'></i></a>
                                </div>";
                        previousbtn = "";
                    }
                    else if (i + 1 == addons.Count)
                    {
                        StrAddOnCategory += @"<li>
                                    <a data-toggle='tab' href='#" + addons[i].CategoryUrl + @"'>" + addons[i].CategoryTitle + @"</a>
                                </li>";
                        nextbtn = @"";
                        previousbtn = @"<div class='col-lg-4 col-md-6 col-6'>
                                    <a href='#" + addons[i - 1].CategoryUrl + @"'  data-toggle='tab' class='custom-btn' tabindex='-1'><i class=' ms-2 mt-1 fas fa-angle-left fa-lg'> Prev</i></a>
                                </div>";
                    }
                    else
                    {
                        StrAddOnCategory += @" <li>
                                    <a data-toggle='tab' href='#" + addons[i].CategoryUrl + @"'>" + addons[i].CategoryTitle + @"</a>
                                </li>";
                        nextbtn = @"<div class='col-lg-4 col-md-6 col-6'>
                                    <a href='#" + addons[i + 1].CategoryUrl + @"' data-toggle='tab' class='custom-btn' tabindex='-1'>Next <i class=' ms-2 mt-1 fas fa-angle-right fa-lg'></i></a>
                                </div>";
                        previousbtn = @"<div class='col-lg-4 col-md-6 col-6'>
                                    <a href='#" + addons[i - 1].CategoryUrl + @"'  data-toggle='tab' class='custom-btn' tabindex='-1'><i class='me-2 mt-1 fas fa-angle-left fa-lg'></i> Prev</a>
                                </div>";
                    }
                    var products = AddOnProducts.GetAllAddOnProductsWithCategory(conSQ, addons[i].Id.ToString());
                    if (products != null && products.Count > 0)
                    {
                        for (int j = 0; j < products.Count; j++)
                        {
                            strProduct += @"<div class='col-lg-4 col-md-6 col-6'>
                                    <div class='tile'>
                                        <input type='checkbox' name='party' id='" + products[j].ProductUrl + @"' />
                                        <label for='" + products[j].ProductUrl + @"' class='theme-sec'>
                                            <img src='/" + products[j].ThumbImage + @"' />
                                            <div class='content'>
                                                <p>" + products[j].ProductName + @"</p>
                                                <p>₹ " + products[j].Price + @"</p>
                                                <a class='btn btn-primary btnknowmoremodal' data-id='" + products[j].ProductGuid + @"'>know more</a>
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
                            </div>
                            <div class='row justify-content-center mt-2'>
                                " + previousbtn + nextbtn + @"
                            </div>
                        </div>";

                }
            }


        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindAddons", ex.Message);
        }

    }
}