using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class Admin_add_testimonial : System.Web.UI.Page
{
    SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                GetTestimonials();
            }
        }
    }
    public void GetTestimonials()
    {
        try
        {
            TestimonialDetails BD = TestimonialDetails.GetAllTestimonialDetailsWithId(conSQ, Convert.ToInt32(Request.QueryString["id"]));
            if (BD != null)
            {
                btnSave.Text = "Update";
                btnNew.Visible = true;
                txtPosted.Text = BD.PostedBy;
                //txtDesignation.Text = BD.Designation;
                txtMessage.Text = BD.Message;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetTestimonials", ex.Message);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {

                var aid = Request.Cookies["nt_aid"].Value;
                TestimonialDetails BD = new TestimonialDetails();
                BD.PostedBy = txtPosted.Text;
                BD.Message = txtMessage.Text;
                BD.Designation = ""; // txtDesignation.Text;

                BD.AddedIp = CommonModel.IPAddress();
                BD.AddedOn = TimeStamps.UTCTime();
                BD.AddedBy = aid;


                if (btnSave.Text == "Update")
                {
                    BD.Id = Convert.ToInt32(Request.QueryString["id"]);
                    int result = TestimonialDetails.UpdateTestimonialDetails(conSQ, BD);
                    if (result > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Testimonial Updated successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'There is some problem now.please try again after some time. ',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    }
                }
                else
                {
                    int result = TestimonialDetails.InsertTestimonial(conSQ, BD);
                    if (result > 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Testimonial Added successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                        txtPosted.Text = txtMessage.Text = "";
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'There is some problem now.please try again after some time. ',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);

                    }
                }


            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "btnSave_Click", ex.Message);
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("add-testimonial.aspx");
    }
}