using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class Admin_add_product_type : System.Web.UI.Page
{
    SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
    public string StrProducts = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            BindCategories();
            if (Request.QueryString["id"] != null)
            {
                GetProductTypeDetails();
            }
            BindTypeList();
        }
    }
    public void BindCategories()
    {
        try
        {
            List<AddOnCategories> sub = AddOnCategories.GetAllAddOnCategories(conSQ);
            ddlCategory.Items.Clear();
            if (sub.Count > 0)
            {
                ddlCategory.DataSource = sub;
                ddlCategory.DataValueField = "Id";
                ddlCategory.DataTextField = "CategoryTitle";
                ddlCategory.DataBind();

            }
            ddlCategory.Items.Insert(0, new ListItem("Select Category", "0"));
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindCategories", ex.Message);
        }
    }

    public void GetProductTypeDetails()
    {
        try
        {
            var product = AddOnProductType.GetAllProductTypeDetailsWithId(conSQ, Convert.ToInt32(Request.QueryString["id"].ToString()));
            if (product != null)
            {
                BtnSubmit.Text = "Update";
                ddlCategory.SelectedValue = product.CategoryID;
                txtProduct.Text = product.ProductType;
                txtProductOrder.Text = product.ProductOrder;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetProductTypeDetails", ex.Message);
        }
    }

    public void BindTypeList()
    {
        try
        {
            var pList = AddOnProductType.GetAllAddOnProductType(conSQ);
            if (pList != null && pList.Count > 0)
            {
                for (int i = 0; i < pList.Count; i++)
                {
                    StrProducts += @"<tr>
                                        <td>" + (i + 1) + @"</td>
                                        <td>" + pList[i].CategoryTitle + @"</td>
                                        <td>" + pList[i].ProductType + @"</td>
                                        <td>" + pList[i].ProductOrder + @"</td>
                                        <td>" + Convert.ToDateTime(pList[i].AddedOn).ToString("dd MMM yyyy") + @"</td>
                                        <td class='text-center'>
                                            <a href='manage-product-types.aspx?id=" + pList[i].Id + @"' class='bs-tooltip text-info fs-18' data-id='" + pList[i].Id + @"' data-toggle='tooltip' data-placement='top' title='Edit' data-original-title='Edit'>
                                               <i class='mdi mdi-pencil'></i></a>
                                            <a href='javascript:void(0);' class='bs-tooltip deleteItem warning confirm text-danger fs-18' data-id='" + pList[i].Id + @"' data-toggle='tooltip' data-placement='top' title='Delete' data-original-title='Delete'>
                                               <i class='mdi mdi-delete-forever'></i></a>
                                        </td>
                                    </tr>";
                }
            }
            else
            {
                StrProducts += "<tr><td colspan='6' class='text-center'>No data to show.</td></tr>";
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindTypeList", ex.Message);
        }
    }
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                string aid = Request.Cookies["nt_aid"].Value;
                AddOnProductType st = new AddOnProductType()
                {
                    ProductType = txtProduct.Text,
                    CategoryID = ddlCategory.SelectedValue,
                    ProductOrder = txtProductOrder.Text,
                    AddedBy = aid,
                    Status = "Active",
                    Id = Request.QueryString["id"] == null ? 0 : Convert.ToInt32(Request.QueryString["id"]),
                };
                if (BtnSubmit.Text == "Update")
                {
                    int result = AddOnProductType.UpdateProductType(conSQ, st);
                    if (result > 0)
                    {
                        GetProductTypeDetails();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Product Type details Updated successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops! Something went wrong. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    }

                }
                else
                {
                    int result = AddOnProductType.AddProductType(conSQ, st);
                    if (result > 0)
                    {
                        txtProduct.Text = txtProductOrder.Text = string.Empty;
                        ddlCategory.ClearSelection();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Product Type details added successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops! Something went wrong. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    }
                }
                BindTypeList();
            }
            catch (Exception ex)
            {
                ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BtnSubmit_Click", ex.Message);
            }
        }
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("manage-product-type.aspx", false);
    }


    [WebMethod(EnableSession = true)]
    public static string Delete(string id)
    {
        string x = "";
        try
        {
            SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
            AddOnProductType BD = new AddOnProductType();
            BD.Id = Convert.ToInt32(id);
            BD.AddedOn = DateTime.UtcNow;
            BD.AddedIp = CommonModel.IPAddress();
            int exec = AddOnProductType.DeleteProductType(conSQ, BD);
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