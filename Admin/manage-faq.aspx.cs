using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_manage_faq : System.Web.UI.Page
{
    SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);

    public string strFAQs = "<tr><td colspan='5' class='text-center'>No data to show</td></tr>";
    protected void Page_Load(object sender, EventArgs e)
    {
        btnSave.Attributes.Add("onclick", " this.disabled = 'true';this.value='Please Wait...'; " + ClientScript.GetPostBackEventReference(btnSave, null) + ";");
        GetAllFAQ();
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                GetFAQ();
            }
        }
    }
    public void GetAllFAQ()
    {
        try
        {
            List<FAQDetails> FAQDetailss = FAQDetails.GetAllFAQDetails(conSQ).OrderByDescending(s => Convert.ToDateTime(s.AddedOn)).ToList();
            if (FAQDetailss.Count > 0)
            {
                strFAQs = "";
                int i = 0;
                foreach (FAQDetails FAQ in FAQDetailss)
                {
                    var FAQDesc = "";
                    if (FAQ.FAQDesc.Length > 80)
                    {
                        FAQDesc = FAQ.FAQDesc.Substring(0, 80) + " ....";
                    }
                    else
                    {
                        FAQDesc = FAQ.FAQDesc;
                    }
                    strFAQs += @"<tr>
                                                <td>" + (i + 1) + @"</td>
                                                <td>" + FAQ.FAQQuestion + @"</td>
                                                <td><a href='javascript:void:(0);' data-bs-toggle='tooltip' data-placement='top' title='Added By : " + FAQ.AddedBy + @"' >" + FAQ.AddedOn.ToString("dd/MMM/yyyy") + @"</a></td>  
                                                <td class='text-center'>
                                                    <a href='manage-FAQs.aspx?id=" + FAQ.Id + @"' class='bs-tooltip text-info fs-18' data-id='" + FAQ.Id + @"' data-toggle='tooltip' data-placement='top' title='Edit' data-original-title='Edit'>
                                                       <i class='mdi mdi-pencil'></i></a>
                                                    <a href='javascript:void(0);' class='bs-tooltip deleteItem warning confirm text-danger fs-18' data-id='" + FAQ.Id + @"' data-toggle='tooltip' data-placement='top' title='Delete' data-original-title='Delete'>
                                                       <i class='mdi mdi-delete-forever'></i></a>
                                                </td>
                                            </tr>";
                    i++;
                }
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllFAQ", ex.Message);
        }
    }
    public void GetFAQ()
    {
        try
        {
            FAQDetails FAQ = FAQDetails.GetAllFAQDetails(conSQ).Where(s => s.Id == Convert.ToInt32(Request.QueryString["id"])).FirstOrDefault();
            if (FAQ != null)
            {
                btnSave.Text = "Update";
                addFAQ.Visible = true;
                txtPosted.Text = FAQ.FAQQuestion;
                txtDesc.Text = FAQ.FAQDesc;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetFAQ", ex.Message);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {


                string pageName = Path.GetFileName(Request.Path);
                FAQDetails FAQ = new FAQDetails();
                FAQ.FAQQuestion = txtPosted.Text;
                FAQ.FAQDesc = txtDesc.Text;
                FAQ.Status = "Active";
                FAQ.AddedBy = Request.Cookies["nt_aid"].Value;
                if (btnSave.Text == "Update")
                {
                    FAQ.Id = Convert.ToInt32(Request.QueryString["id"]);
                    int result = FAQDetails.UpdateFAQ(conSQ, FAQ);
                    if (result > 0)
                    {
                        GetAllFAQ();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'FAQ  Updated Successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops! Something went wrong. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    }
                }
                else
                {
                    FAQ.AddedBy = Request.Cookies["nt_aid"].Value;

                    int result = FAQDetails.AddFAQ(conSQ, FAQ);
                    if (result > 0)
                    {
                        GetAllFAQ();
                        txtPosted.Text = txtDesc.Text = "";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'FAQ  Added Successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops! Something went wrong. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    }

                }

            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops! Something went wrong. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "btnSave_Click", ex.Message);
        }
    }

    [WebMethod(EnableSession = true)]
    public static string Delete(string id)
    {
        string x = "";
        try
        {
            SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
           
                FAQDetails cat = new FAQDetails();
                cat.Id = Convert.ToInt32(id);
                cat.AddedOn = TimeStamps.UTCTime();
                cat.AddedIp = CommonModel.IPAddress();
                cat.AddedBy = HttpContext.Current.Request.Cookies["nt_aid"].Value;
                int exec = FAQDetails.DeleteFAQ(conSQ, cat);
                if (exec > 0)
                {
                    x = "Success";
                }
                else
                {
                    x = "W";
                }
           
        }
        catch (Exception ex)
        {
            x = "W";
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "Delete", ex.Message);
        }
        return x;
    }

    protected void addFAQ_Click(object sender, EventArgs e)
    {
        Response.Redirect("manage-faq.aspx");
    }

}