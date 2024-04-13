using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class Admin_theater_timing : System.Web.UI.Page
{
    SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
    public string strTheaterList = "", StrTheaterName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["tid"] != null)
        {
            if (!IsPostBack)
            {
                BindTheaterList();
            }
        }
        else
        {
            Response.Redirect("/admin/view-theater.aspx", false);
        }

    }

    protected void BtnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                string aid = Request.Cookies["nt_aid"].Value;
                TheaterTiming st = new TheaterTiming()
                {
                    TimingGuid = Guid.NewGuid().ToString(),
                    StartTime = txtStart.Text,
                    EndTime = txtEnd.Text,
                    TheaterID = Request.QueryString["tid"],
                    AddedBy = aid,
                    AddedIp = CommonModel.IPAddress(),
                    AddedOn = TimeStamps.UTCTime(),
                    Status = "Active",
                };
                if (BtnSave.Text == "Update")
                {
                    int result = TheaterTiming.UpdateTiming(conSQ, st);
                    if (result > 0)
                    {
                        BindTheaterList();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Area details Updated successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops! Something went wrong. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    }

                }
                else
                {
                    int result = TheaterTiming.AddTiming(conSQ, st);
                    if (result > 0)
                    {
                        txtEnd.Text = txtStart.Text = string.Empty;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Area details added successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops! Something went wrong. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    }
                }
                BindTheaterList();
            }
            catch (Exception ex)
            {
                ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "btnSave_Click", ex.Message);
            }
        }

    }
    public void BindTheaterList()
    {
        try
        {
            var tid = Request.QueryString["tid"].ToString();
            if (tid != "")
            {
                var timing = TheaterTiming.GetAllTheaterTimingWithTheaterID(conSQ, tid);
                if (timing != null && timing.Count > 0)
                {
                    StrTheaterName = timing[0].TheaterTitle.ToString();
                    for (int i = 0; i < timing.Count; i++)
                    {
                        strTheaterList += @"<tr>
                                        <td>" + (i + 1) + @"</td>
                                        <td>" + timing[i].TheaterTitle + @"</td>
                                        <td>" + timing[i].StartTime + @"</td>
                                        <td>" + timing[i].EndTime + @"</td>
                                        <td>" + Convert.ToDateTime(timing[i].AddedOn).ToString("dd MMM yyyy") + @"</td>
                                        <td class='text-center'>
                                            <a href='javascript:void(0);' class='bs-tooltip deleteItem warning confirm text-danger fs-18' data-id='" + timing[i].Id + @"' data-tid='" + timing[i].TheaterID + @"' data-toggle='tooltip' data-placement='top' title='Delete' data-original-title='Delete'>
                                               <i class='mdi mdi-delete-forever'></i></a>
                                        </td>
                                    </tr>";
                    }
                }
                else
                {
                    strTheaterList = "<tr><td colspan='6' class='text-center'>No data to show</td></tr>";
                    var theater = TheaterDetails.GetAllTheaterDetailsWithGuid(conSQ, tid);
                    if (theater != null)
                    {
                        StrTheaterName = theater.TheaterTitle.ToString();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindTheaterList", ex.Message);
        }
    }


    [WebMethod(EnableSession = true)]
    public static string Delete(string id)
    {
        string x = "";
        try
        {
            SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
            TheaterTiming img = new TheaterTiming();
            img.Id = Convert.ToInt32(id);
            img.AddedOn = TimeStamps.UTCTime();
            img.AddedIp = CommonModel.IPAddress();
            img.AddedBy = HttpContext.Current.Request.Cookies["nt_aid"].Value;
            int exec = TheaterTiming.DeleteTiming(conSQ, img);
            if (exec > 0)
            {
                x = "Success";
            }


        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteImage", ex.Message);
        }
        return x;
    }
}