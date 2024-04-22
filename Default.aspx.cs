using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
    public string StrTestimonial = "", StrFAQ = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindTestimonials();
            BindFaq();
        }
    }
    public void BindTestimonials()
    {
        try
        {
            var test = TestimonialDetails.GetTestimonialDetails(conSQ);
            if (test != null)
            {
                for (int i = 0; i < test.Count; i++)
                {
                    StrTestimonial += @"<div class='owl-item'>
                            <div class='item text-center'>
                                <span class='quote-icon'>
                                    <i class='fas fa-quote-right'></i>
                                </span>
                                <div class='clients-comment'>
                                " + test[i].Message + @"
                                </div>
                                <div class='client-info'>
                                    <h3 class='client-name'>" + test[i].PostedBy + @"</h3>
                                </div>
                            </div>
                        </div>";
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindTestimonials", ex.Message);
        }
    }
    public void BindFaq()
    {
        try
        {
            var faq = FAQDetails.GetAllFAQDetails(conSQ).ToList();
            if (faq != null)
            {
                for (int i = 0; i < faq.Take(10).ToList().Count; i++)
                {
                    StrFAQ += @"<div class='card'>
                            <div class='card-header' id='heading" + i + @"'>
                                <a href='javascript:void(0);' class='btn collapsed' data-toggle='collapse' data-target='#collapse" + i + @"' aria-expanded='false' aria-controls='collapse" + i + @"'>
                                    <span>" + (i + 1).ToString().PadLeft(2, '0') + @".</span>" + faq[i].FAQQuestion + @"										
                                </a>
                            </div>

                            <div id='collapse" + i + @"' class='collapse " + (i == 0 ? "show" : "") + @"' aria-labelledby='heading" + i + @"' data-parent='#faq-accordion'>
                                <div class='card-body'>
                                    " + faq[i].FAQDesc + @"
                                </div>
                            </div>
                        </div>";
                }
                if (faq.Count > 10)
                {
                    faqviewmore.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindFaq", ex.Message);
        }
    }
}