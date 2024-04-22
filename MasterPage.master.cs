using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
    public string StrLocations = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        BindLocation();
    }
    public void BindLocation()
    {
        try
        {
            var area = AreaMaster.GetAllAreaMaster(conSQ);
            if (area != null && area.Count > 0)
            {
                var cnt = 0;
                string link = "";
                for (int i = 0; i < area.Count; i++)
                {
                    var otherdetails = TheaterDetails.GetTheaterDetailsWithAreaId(conSQ, area[i].Id.ToString());
                    if (otherdetails != null && otherdetails.Rows.Count > 0)
                    {
                        cnt = Convert.ToInt32(otherdetails.Rows[0]["cnt"].ToString());
                        if (cnt > 0)
                        {

                            if (cnt > 1)
                            {
                                link = "/theaters/" + area[i].AreaUrl;
                            }
                            else
                            {
                                link = "/booking/" + area[i].AreaUrl + "/" + otherdetails.Rows[0]["TheaterUrl"];
                            }
                        }

                    }
                    StrLocations += "<li><a href='" + link + @"'>" + area[i].AreaTitle + @"</a></li>";
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
}
