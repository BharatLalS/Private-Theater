using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_state_master : System.Web.UI.Page
{
    SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);

    public string strState = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetStateList();
            if (Request.QueryString["id"] != null)
            {
                GetStateDetails();
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            try
            {
                string aid = Request.Cookies["nt_aid"].Value;
                StateMaster st = new StateMaster()
                {
                    StateTitle = txtName.Text,
                    StateUrl = txtURl.Text,
                    StateOrder = "0",
                    AddedBy = aid,
                    Status = "Active",
                    Id = Request.QueryString["id"] == null ? 0 : Convert.ToInt32(Request.QueryString["id"]),
                };
                if (btnSave.Text == "Update")
                {
                    int result = StateMaster.UpdateState(conSQ, st);
                    if (result > 0)
                    {
                        GetStateDetails();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'State details Updated successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops! Something went wrong. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    }

                }
                else
                {
                    int result = StateMaster.AddState(conSQ, st);
                    if (result > 0)
                    {
                        txtName.Text = txtURl.Text = string.Empty;
                        //ddlGender.ClearSelection();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'State details added successfully.',actionTextColor: '#fff',backgroundColor: '#008a3d'});", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "Snackbar.show({pos: 'top-right',text: 'Oops! Something went wrong. Please try after some time',actionTextColor: '#fff',backgroundColor: '#ea1c1c'});", true);
                    }
                }
                GetStateList();
            }
            catch (Exception ex)
            {
                ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "btnSave_Click", ex.Message);
            }
        }
    }

    public void GetStateDetails()
    {
        try
        {
            var State = StateMaster.GetAllStateDetailsWithId(conSQ, Convert.ToInt32(Request.QueryString["id"]));
            if (State != null)
            {
                btnSave.Text = "Update";
                txtName.Text = State.StateTitle;
                txtURl.Text = State.StateUrl;
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetStateDetails", ex.Message);
        }
    }
    public void GetStateList()
    {
        try
        {
            var sub = StateMaster.GetAllStateMaster(conSQ);
            if (sub != null)
            {
                for (int i = 0; i < sub.Count; i++)
                {
                    strState += @"<tr>
                                        <td>" + (i + 1) + @"</td>
                                        <td>" + sub[i].StateTitle + @"</td>
                                        <td>" + Convert.ToDateTime(sub[i].AddedOn).ToString("dd MMM yyyy") + @"</td>
                                        <td class='text-center'>
                                            <a href='state-master.aspx?id=" + sub[i].Id + @"' class='bs-tooltip text-info fs-18' data-id='" + sub[i].Id + @"' data-toggle='tooltip' data-placement='top' title='Edit' data-original-title='Edit'>
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
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetStateList", ex.Message);

        }
    }
    [WebMethod(EnableSession = true)]
    public static string Delete(string id)
    {
        string x = "";
        try
        {
            SqlConnection conSQ = new SqlConnection(ConfigurationManager.ConnectionStrings["conSQ"].ConnectionString);
            StateMaster BD = new StateMaster();
            BD.Id = Convert.ToInt32(id);
            BD.AddedOn = DateTime.UtcNow;
            BD.AddedIp = CommonModel.IPAddress();
            int exec = StateMaster.DeleteState(conSQ, BD);
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