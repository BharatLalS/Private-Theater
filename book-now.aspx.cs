﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class book_now : System.Web.UI.Page
{
    SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
    public string StrArea = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        BindAreas();
    }
    public void BindAreas()
    {
        try
        {
            var area = AreaMaster.GetAllAreaMaster(conSQ);
            if (area != null && area.Count > 0)
            {

                for (int i = 0; i < area.Count; i++)
                {
                    var startprice = "NA";
                    var maxpeople = "NA";
                    var link = "javascript:void(0);";
                    var cnt = 0;

                    var otherdetails = TheaterDetails.GetTheaterDetailsWithAreaId(conSQ, area[i].Id.ToString());
                    if (otherdetails != null && otherdetails.Rows.Count > 0)
                    {
                        cnt = Convert.ToInt32(otherdetails.Rows[0]["cnt"].ToString());
                        if (cnt > 0)
                        {
                            startprice = "₹" + otherdetails.Rows[0]["minprice"].ToString();
                            maxpeople = otherdetails.Rows[0]["maxcap"].ToString() + " people";
                            if (cnt > 1)
                            {
                                link = "/theaters/" + area[i].AreaUrl;
                            }
                            else
                            {
                                link = "/booking/" + otherdetails.Rows[0]["TheaterUrl"];
                            }
                        }

                    }
                    StrArea += @"<div class='col-lg-3 col-md-6 col-sm-12'>
                                    <div class='event-grid-item'>
                                        <div class='event-image'>
                                            <img src='" + area[i].ImageUrl + @"' alt='" + area[i].AreaTitle + @"'>
                                        </div>
                                         <div class='event-content'>
                                            <div class='event-title mb-20'>
                                                <h3 class='title'>" + area[i].AreaTitle + @"
                                                </h3>
                                            </div>
                                            <div class='row'>
                                                <div class='col-lg-6 col-5'>
                                                    <span class='new-start'>Starting From</span>
                                                    <p class='slot_price'>
                                                         " + startprice + @" 
                                                                                               
                                                    </p>
                                                </div>
                                                <div class='col-lg-6 col-7 my-auto'>
                                                    <p class='capacity text-dark'>
                                                        <i class='fas fa-users'></i>" + maxpeople + @"</p>
                                                </div>
                                            </div>
                                            <a href='" + link + @"' class='tickets-details-btn'>Book Slot <i class='fas fa-angle-right fa-lg'></i>
                                            </a>
                                        </div>
                                    </div>
                                </div>";
                }

            }
        }
        catch (Exception ex)
        {

        }
    }
}