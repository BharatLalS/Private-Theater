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

public partial class Admin_add_thretre : System.Web.UI.Page
{
    SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
    public string StrThumbImage = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindStates();
            //BindCity();
            // BindArea();
            if (Request.QueryString["id"] != null)
            {
                GetTheaterDetails();
            }
        }
    }

    public void BindStates()
    {
        try
        {
            List<StateMaster> sub = StateMaster.GetAllStateMaster(conSQ);
            ddlState.Items.Clear();
            if (sub.Count > 0)
            {
                ddlState.DataSource = sub;
                ddlState.DataValueField = "Id";
                ddlState.DataTextField = "StateTitle";
                ddlState.DataBind();

            }
            ddlState.Items.Insert(0, new ListItem("Select States", "0"));
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindStates", ex.Message);
        }
    }
    public void BindCity()
    {
        try
        {
            var state = ddlState.SelectedValue;
            List<CityMaster> sub = CityMaster.GetAllCityMasterWithStateId(conSQ, state);
            ddlCity.Items.Clear();
            if (sub.Count > 0)
            {
                ddlCity.DataSource = sub;
                ddlCity.DataValueField = "Id";
                ddlCity.DataTextField = "CityTitle";
                ddlCity.DataBind();

            }

            ddlCity.Items.Insert(0, new ListItem("Select Cities", "0"));
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindCity", ex.Message);
        }
    }
    public void BindArea()
    {
        try
        {
            var city = ddlCity.SelectedValue;
            List<AreaMaster> sub = AreaMaster.GetAllAreaMasterWithCityId(conSQ, city);
            ddlArea.Items.Clear();
            if (sub.Count > 0)
            {
                ddlArea.DataSource = sub;
                ddlArea.DataValueField = "Id";
                ddlArea.DataTextField = "AreaTitle";
                ddlArea.DataBind();

            }

            ddlArea.Items.Insert(0, new ListItem("Select Areas", "0"));
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "BindCity", ex.Message);
        }
    }
    public void GetTheaterDetails()
    {
        try
        {
            var Theater = TheaterDetails.GetAllTheaterDetailsWithId(conSQ, Convert.ToInt32(Request.QueryString["id"]));
            if (Theater != null)
            {
                btnSave.Text = "Update";
                ddlState.SelectedValue = Theater.StateID;
                BindCity();
                ddlCity.SelectedValue = Theater.CityID;
                BindArea();
                ddlArea.SelectedValue = Theater.AreaID;
                txtTheater.Text = Theater.TheaterTitle;
                txtPinCode.Text = Theater.Pincode;
                txtAddress.Text = Theater.Address;
                txtFullDesc.Text = Theater.FullDesc;
                txtLocation.Text = Theater.LocationLink;
                txtPageTitle.Text = Theater.PageTitle;
                txtMetaDesc.Text = Theater.MetaDesc;
                txtMetaKey.Text = Theater.MetaKeys;
                txtShortDesc.Text = Theater.ShortDesc;
                txtMaxAllowed.Text = Theater.MaxAllowed;
                txtMaxAllCap.Text = Theater.MaxCapacity;
                txtExtPrice.Text = Theater.ExtraPrice;
                txtPrice.Text = Theater.Price;
                txtUrl.Text = Theater.TheaterUrl;

                if (Theater.ThumbImage != null)
                {
                    StrThumbImage = "<img src='/" + Theater.ThumbImage + "' style='max-height:60px;' />";
                    lblThumb.Text = Theater.ThumbImage;
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetTheaterDetails", ex.Message);
        }
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindCity();
    }

    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindArea();
    }

    protected void btnSave_Click(object sender, EventArgs e)
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
                TheaterDetails BD = new TheaterDetails();
                BD.TheaterGuid = Guid.NewGuid().ToString();
                BD.AreaID = ddlArea.SelectedValue;
                BD.CityID = ddlCity.SelectedValue;
                BD.StateID = ddlState.SelectedValue;
                BD.TheaterTitle = txtTheater.Text;
                BD.TheaterUrl = txtUrl.Text;
                BD.Pincode = txtPinCode.Text;
                BD.ShortDesc = txtShortDesc.Text;
                BD.Address = txtAddress.Text;
                BD.MaxAllowed = txtMaxAllowed.Text;
                BD.MaxCapacity = txtMaxAllCap.Text;
                BD.ExtraPrice = txtExtPrice.Text;
                BD.Price = txtPrice.Text;
                BD.ThumbImage = UploadThumbImage();
                BD.FullDesc = txtFullDesc.Text;
                BD.MetaDesc = txtMetaDesc.Text;
                BD.MetaKeys = txtMetaKey.Text;
                BD.PageTitle = txtPageTitle.Text;
                BD.LocationLink = txtLocation.Text;

                BD.AddedIp = CommonModel.IPAddress();
                BD.AddedOn = TimeStamps.UTCTime();
                BD.AddedBy = aid;
                BD.Status = "Active";

                if (BD.ThumbImage != "")
                {
                    if (btnSave.Text == "Update")
                    {
                        BD.Id = Convert.ToInt32(Request.QueryString["id"]);
                        int result = TheaterDetails.UpdateTheater(conSQ, BD);
                        if (result > 0)
                        {
                            GetTheaterDetails();
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Theater Updated successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops...! There is some problem right now.please try again after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);

                        }
                    }
                    else
                    {
                        int result = TheaterDetails.AddTheater(conSQ, BD);
                        if (result > 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Theater Added successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                            txtFullDesc.Text = txtMetaDesc.Text = txtPinCode.Text = txtAddress.Text = txtLocation.Text = txtShortDesc.Text = txtMaxAllCap.Text = txtMaxAllowed.Text = txtPrice.Text = txtExtPrice.Text = txtTheater.Text = txtUrl.Text = txtPageTitle.Text = txtMetaKey.Text = "";
                            StrThumbImage = "";
                            ddlState.ClearSelection();
                            ddlCity.ClearSelection();
                            ddlArea.ClearSelection();
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
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "btnSave_Click", ex.Message);

        }
    }


    private string CheckThumbFormat()
    {
        #region ThumbImage
        string thumbImg = "";
        if (ImageUpload.HasFile)
        {
            try
            {
                string fileExtension = Path.GetExtension(ImageUpload.PostedFile.FileName.ToLower()), ImageGuid1 = Guid.NewGuid().ToString();
                if ((fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png" || fileExtension == ".gif" || fileExtension == ".webp"))
                {
                    System.Drawing.Bitmap bitimg = new System.Drawing.Bitmap(ImageUpload.PostedFile.InputStream);
                    if ((bitimg.PhysicalDimension.Height != 600) || (bitimg.PhysicalDimension.Width != 800))
                    {
                        return "Size";
                    }
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
            if (ImageUpload.HasFile)
            {
                string fileExtension = Path.GetExtension(ImageUpload.PostedFile.FileName.ToLower()), ImageGuid1 = Guid.NewGuid().ToString() + "-Theaterthumb".Replace(" ", "-").Replace(".", "");
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
                ImageUpload.SaveAs(iconPath);
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


    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("/admin/add-theater.aspx", false);
    }
}