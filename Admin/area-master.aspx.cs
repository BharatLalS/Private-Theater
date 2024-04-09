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

public partial class Admin_area_master : System.Web.UI.Page
{
    SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);

    public string strArea = "", strThumbImage = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            BindStates();
            BindCity();
            GetAreaList();
            if (Request.QueryString["id"] != null)
            {
                GetAreaDetails();
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
                string aid = Request.Cookies["nt_aid"].Value;
                AreaMaster st = new AreaMaster()
                {
                    AreaTitle = txtName.Text,
                    StateID = ddlState.SelectedValue,
                    CityID = ddlCity.SelectedValue,
                    AreaUrl = txtURl.Text,
                    ImageUrl = UploadThumbImage(),
                    AreaOrder = "0",
                    AddedBy = aid,
                    Status = "Active",
                    Id = Request.QueryString["id"] == null ? 0 : Convert.ToInt32(Request.QueryString["id"]),
                };
                if (btnSave.Text == "Update")
                {
                    int result = AreaMaster.UpdateArea(conSQ, st);
                    if (result > 0)
                    {
                        GetAreaDetails();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Area details Updated successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops! Something went wrong. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    }

                }
                else
                {
                    int result = AreaMaster.AddArea(conSQ, st);
                    if (result > 0)
                    {
                        txtName.Text = txtURl.Text = string.Empty;
                        ddlState.ClearSelection();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Area details added successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops! Something went wrong. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    }
                }
                GetAreaList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "btnSave_Click", ex.Message);
        }
    }
    public void GetAreaDetails()
    {
        try
        {
            var Area = AreaMaster.GetAllAreaDetailsWithId(conSQ, Convert.ToInt32(Request.QueryString["id"]));
            if (Area != null)
            {
                btnSave.Text = "Update";
                ddlState.SelectedValue = Area.StateID;
                BindCity();
                ddlCity.SelectedValue = Area.CityID;
                txtName.Text = Area.AreaTitle;
                txtURl.Text = Area.AreaUrl;
                if (Area.ImageUrl != "")
                {
                    strThumbImage = "<img src='/" + Area.ImageUrl + "' style='max-height:60px;' />";
                    lblThumb.Text = Area.ImageUrl;
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAreaDetails", ex.Message);
        }
    }
    public void GetAreaList()
    {
        try
        {
            var sub = AreaMaster.GetAllAreaMaster(conSQ);
            if (sub != null)
            {
                for (int i = 0; i < sub.Count; i++)
                {
                    strArea += @"<tr>
                                        <td>" + (i + 1) + @"</td>
                                        <td><a href='" + sub[i].ImageUrl + @"' target='_blank'><img src='\" + sub[i].ImageUrl + @"' height='60px'/></a></td>
                                        <td>" + sub[i].StateTitle + @"</td>
                                        <td>" + sub[i].CityTitle + @"</td>
                                        <td>" + sub[i].AreaTitle + @"</td>
                                        <td>" + Convert.ToDateTime(sub[i].AddedOn).ToString("dd MMM yyyy") + @"</td>
                                        <td class='text-center'>
                                            <a href='Area-master.aspx?id=" + sub[i].Id + @"' class='bs-tooltip text-info fs-18' data-id='" + sub[i].Id + @"' data-toggle='tooltip' data-placement='top' title='Edit' data-original-title='Edit'>
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
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAreaList", ex.Message);

        }
    }

    [WebMethod(EnableSession = true)]
    public static string Delete(string id)
    {
        string x = "";
        try
        {
            SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
            AreaMaster BD = new AreaMaster();
            BD.Id = Convert.ToInt32(id);
            BD.AddedOn = DateTime.UtcNow;
            BD.AddedIp = CommonModel.IPAddress();
            int exec = AreaMaster.DeleteArea(conSQ, BD);
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
    private string CheckThumbFormat()
    {
        #region ThumbImage
        string thumbImg = "";
        if (Thumbimage.HasFile)
        {
            try
            {
                string fileExtension = Path.GetExtension(Thumbimage.PostedFile.FileName.ToLower()), ImageGuid1 = Guid.NewGuid().ToString();
                if ((fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png" || fileExtension == ".gif" || fileExtension == ".webp"))
                {
                    System.Drawing.Bitmap bitimg = new System.Drawing.Bitmap(Thumbimage.PostedFile.InputStream);
                    if ((bitimg.PhysicalDimension.Height != 170) || (bitimg.PhysicalDimension.Width != 250))
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
            if (Thumbimage.HasFile)
            {
                string fileExtension = Path.GetExtension(Thumbimage.PostedFile.FileName.ToLower()), ImageGuid1 = Guid.NewGuid().ToString() + "-area".Replace(" ", "-").Replace(".", "");
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
                Thumbimage.SaveAs(iconPath);
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
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindCity();
        GetAreaList();
    }
}