using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_view_addon_products : System.Web.UI.Page
{
    SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
    public string strProduct = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetProductList();
        }
    }


    public void GetProductList()
    {
        try
        {
            var sub = AddOnProducts.GetAllAddOnProducts(conSQ);
            if (sub != null)
            {
                for (int i = 0; i < sub.Count; i++)
                {
                    strProduct += @"<tr>
                                        <td>" + (i + 1) + @"</td>
                                        <td ><a href='/" + sub[i].ThumbImage + @"' target='_blank'><img src='/" + sub[i].ThumbImage + @"' width='60px' /></a></td>
                                        <td>" + sub[i].CategoryTitle + @"</td>
                                        <td>" + sub[i].ProductName + @"</td>
                                        <td>" + sub[i].Price + @"</td>
                                        <td>" + Convert.ToDateTime(sub[i].AddedOn).ToString("dd MMM yyyy") + @"</td>
                                        <td class='text-center'>
                                            <a href='add-addon-products.aspx?id=" + sub[i].Id + @"' class='bs-tooltip text-info fs-18' data-id='" + sub[i].Id + @"' data-toggle='tooltip' data-placement='top' title='Edit' data-original-title='Edit'>
                                               <i class='mdi mdi-pencil'></i></a>
                                            <a href='javascript:void(0);' class='bs-tooltip deleteItem warning confirm text-danger fs-18' data-id='" + sub[i].Id + @"' data-toggle='tooltip' data-placement='top' title='Delete' data-original-title='Delete'>
                                               <i class='mdi mdi-delete-forever'></i></a>
                                        </td>
                                    </tr>";
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetProductList", ex.Message);

        }
    }




    [WebMethod(EnableSession = true)]
    public static string Delete(string id)
    {
        string x = "";
        try
        {
            SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
            AddOnProducts BD = new AddOnProducts();
            BD.Id = Convert.ToInt32(id);
            BD.AddedOn = DateTime.UtcNow;
            BD.AddedIp = CommonModel.IPAddress();
            int exec = AddOnProducts.DeleteProduct(conSQ, BD);
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
}