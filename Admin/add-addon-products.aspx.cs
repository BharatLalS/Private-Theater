using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_add_addon_products : System.Web.UI.Page
{
    SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
    public string StrThumbImage = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            BindCategories();
            if (Request.QueryString["id"] != null)
            {
                GetProductDetails();
            }
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

    public void GetProductDetails()
    {
        try
        {
            var Product = AddOnProducts.GetAllProductDetailsWithId(conSQ, Convert.ToInt32(Request.QueryString["id"]));
            if (Product != null)
            {
                BtnSubmit.Text = "Update";
                ddlCategory.SelectedValue = Product.Category;
                ddlProductType.SelectedValue = Product.ProductType == "" ? "0" : Product.ProductType;
                txtProduct.Text = Product.ProductName;
                txtPrice.Text = Product.Price;
                txtUrl.Text = Product.ProductUrl;
                txtDesc.Text = Product.Description;
                ChkMultiple.Checked = Product.AllowMultiple == "Yes";
                BindProductType();
                ddlProductType.Text = Product.ProductType;
                if (Product.ThumbImage != null)
                {
                    StrThumbImage = "<img src='/" + Product.ThumbImage + "' style='max-height:60px;' />";
                    lblThumb.Text = Product.ThumbImage;
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetProductDetails", ex.Message);
        }
    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Page.IsValid)
            {
                var thumbimg = CheckThumbFormat();

                if (thumbimg == "Format")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Invalid image format. Please upload .png, .jpeg, .jpg, .webp, .gif for thumb image',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    return;
                }
                if (thumbimg == "Size")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Invalid image size.Please upload correct resolution image for thumb image',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    return;
                }

                var aid = Request.Cookies["nt_aid"].Value;
                AddOnProducts BD = new AddOnProducts();
                BD.ProductGuid = Guid.NewGuid().ToString();
                BD.Category = ddlCategory.SelectedValue;
                BD.ProductName = txtProduct.Text;
                BD.ProductType = ddlProductType.SelectedValue == "0" ? "" : ddlProductType.SelectedValue;
                BD.ProductUrl = txtUrl.Text;
                BD.ProductOrder = "1000";
                BD.Description = txtDesc.Text;
                BD.AllowMultiple = ChkMultiple.Checked ? "Yes" : "No";
                BD.Price = txtPrice.Text;
                BD.ThumbImage = UploadThumbImage();
                BD.AddedIp = CommonModel.IPAddress();
                BD.AddedOn = TimeStamps.UTCTime();
                BD.AddedBy = aid;
                BD.Status = "Active";

                if (BD.ThumbImage != "")
                {
                    if (BtnSubmit.Text == "Update")
                    {
                        BD.Id = Convert.ToInt32(Request.QueryString["id"]);
                        int result = AddOnProducts.UpdateProduct(conSQ, BD);
                        if (result > 0)
                        {
                            GetProductDetails();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Product Updated successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops...! There is some problem right now.please try again after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);

                        }
                    }
                    else
                    {
                        int result = AddOnProducts.AddProduct(conSQ, BD);
                        if (result > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Product Added successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                            txtDesc.Text = txtPrice.Text = txtUrl.Text = txtProduct.Text = "";
                            ddlProductType.ClearSelection();
                            ddlCategory.ClearSelection();
                            StrThumbImage = "";
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops...! There is some problem right now.please try again after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Please upload all the required images.',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                }

            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BtnSubmit_Click", ex.Message);

        }

    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("/admin/add-addon-products.aspx", false);
    }

    private string CheckThumbFormat()
    {
        #region ThumbImage
        string thumbImg = "";
        if (FileUpload1.HasFile)
        {
            try
            {
                string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName.ToLower()), ImageGuid1 = Guid.NewGuid().ToString();
                if ((fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png" || fileExtension == ".gif" || fileExtension == ".webp"))
                {
                    System.Drawing.Bitmap bitimg = new System.Drawing.Bitmap(FileUpload1.PostedFile.InputStream);

                }
                else
                {

                    return "Format";
                }
            }
            catch (Exception ex)
            {
                ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CheckThumbFormat", ex.Message);

            }
        }
        #endregion
        return thumbImg;
    }
    public string UploadThumbImage()
    {
        #region upload file
        string thumbfile = "";
        try
        {
            if (FileUpload1.HasFile)
            {
                string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName.ToLower()), ImageGuid1 = Guid.NewGuid().ToString() + "-addon".Replace(" ", "-").Replace(".", "");
                string iconPath = Server.MapPath(".") + "\\../UploadImages\\" + ImageGuid1 + "" + fileExtension;
                try
                {
                    if (File.Exists(Server.MapPath("~/" + Convert.ToString(lblThumb.Text))))
                    {
                        File.Delete(Server.MapPath("~/" + Convert.ToString(lblThumb.Text)));
                    }
                }
                catch (Exception eeex)
                {
                    ExceptionCapture.CaptureException(Request.Url.PathAndQuery, "UploadThumbImage", eeex.Message);
                    return lblThumb.Text;
                }
                FileUpload1.SaveAs(iconPath);
                thumbfile = "UploadImages/" + ImageGuid1 + "" + fileExtension;
            }
            else
            {
                thumbfile = lblThumb.Text;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UploadThumbImage", ex.Message);

        }

        #endregion
        return thumbfile;
    }


    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindProductType();
    }
    public void BindProductType()
    {
        try
        {
            var types = AddOnProductType.GetAllProductTypeDetailsWithCategory(conSQ, ddlCategory.SelectedValue);
            if (types != null && types.Count > 0)
            {
                ddlProductType.DataSource = types;
                ddlProductType.DataValueField = "ProductType";
                ddlProductType.DataTextField = "ProductType";
                ddlProductType.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("Select Type", "0"));
                divprotype.Visible = true;
            }
            else
            {
                ddlProductType.Items.Clear();
                divprotype.Visible = false;
            }
            //if (ddlCategory.SelectedValue == "4")
            //{
            //    ddlProductType.Items.Clear();
            //    ddlProductType.Items.Add((new ListItem { Value = "0", Text = "Select Type", Selected = true, Enabled = true }));
            //    ddlProductType.Items.Add((new ListItem { Value = "Back Drop", Text = "Back Drop" }));
            //    ddlProductType.Items.Add((new ListItem { Value = "Balloon", Text = "Balloon" }));
            //    ddlProductType.Items.Add((new ListItem { Value = "Add On", Text = "Add On" }));
            //    divprotype.Visible = true;
            //}
            //else if (ddlCategory.SelectedValue == "6")
            //{
            //    ddlProductType.Items.Clear();
            //    ddlProductType.Items.Add((new ListItem { Value = "0", Text = "Select Type", Selected = true, Enabled = true }));
            //    ddlProductType.Items.Add((new ListItem { Value = "Snacks", Text = "Snacks" }));
            //    ddlProductType.Items.Add((new ListItem { Value = "Appetizer", Text = "Appetizer" }));
            //    ddlProductType.Items.Add((new ListItem { Value = "Main Course", Text = "Main Course" }));
            //    ddlProductType.Items.Add((new ListItem { Value = "Beverages", Text = "Beverages" }));
            //    ddlProductType.Items.Add((new ListItem { Value = "Desert", Text = "Desert" }));
            //    divprotype.Visible = true;
            //}
            //else
            //{
            //    ddlProductType.Items.Clear();
            //    divprotype.Visible = false;
            //}
        }
        catch (Exception ex)
        {

        }
    }
}