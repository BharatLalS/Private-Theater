using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class theater_list : System.Web.UI.Page
{
    SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
    public string StrTheater = "", strAreaUrl;
    protected void Page_Load(object sender, EventArgs e)
    {
        strAreaUrl = Convert.ToString(RouteData.Values["AUrl"]);
        if (strAreaUrl != "")
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
            var area = Convert.ToString(RouteData.Values["AUrl"]);
            var areadetail = AreaMaster.GetAllAreaDetailsWithUrl(conSQ, area);
            if (areadetail != null)
            {
                var theater = TheaterDetails.GetAllTheaterDetailsWithAreaID(conSQ, areadetail.Id.ToString());
                if (theater != null && theater.Count > 0)
                {
                    for (int i = 0; theater.Count > 0; i++)
                    {
                        StrTheater += @"<div class='col-lg-3 col-md-6 col-sm-12'>
                                    <div class='event-grid-item'>
                                        <div class='event-image'>
                                            <img src='/" + theater[i].ThumbImage + @"' alt='" + theater[i].AreaTitle + @"'>
                                        </div>
                                         <div class='event-content'>
                                            <div class='event-title mb-20'>
                                                <h3 class='title'>" + theater[i].TheaterTitle + @"
                                                </h3>
                                            </div>
                                            <div class='row'>
                                                <div class='col-lg-6 col-5'>
                                                    <span class='new-start'>Starting From</span>
                                                    <p class='slot_price'>
                                                         ₹ " + theater[i].Price + @" 
                                                    </p>
                                                </div>
                                                <div class='col-lg-6 col-7 my-auto'>
                                                    <p class='capacity text-dark'>
                                                        <i class='fas fa-users'></i> " + theater[i].MaxCapacity + @" people</p>
                                                </div>
                                            </div>
                                            <a href='/booking/" + areadetail.AreaUrl + "/" + theater[i].TheaterUrl + @"' class='tickets-details-btn'>Book Slot <i class='fas fa-angle-right fa-lg'></i>
                                            </a>
                                        </div>
                                    </div>
                                </div>";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindTheater", ex.Message);
        }
    }
}