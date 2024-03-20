using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Userlogins
/// </summary>
public class Userlogins
{
    public Userlogins()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string UserGuid { get; set; }
    public string LastName { get; set; }
    public string EmailId { get; set; }
    public string Status { get; set; }
    public string Password { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedIp { get; set; }
    public string ContactNo { get; set; }
    public static Userlogins CheckUserByEmail(SqlConnection conGV, string eMail)
    {
        Userlogins details = new Userlogins();
        try
        {
            DataTable dt = new DataTable();
            using (SqlCommand cmd = new SqlCommand("select FirstName,UserGuid,Status,EmailId from Customers where EmailId=@EmailId  and Status!='Deleted'", conGV))
            {
                cmd.Parameters.AddWithValue("@EmailId", SqlDbType.NVarChar).Value = eMail;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    details.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                    details.EmailId = Convert.ToString(dt.Rows[0]["EmailId"]);
                    details.UserGuid = Convert.ToString(dt.Rows[0]["UserGuid"]);
                    details.Status = Convert.ToString(dt.Rows[0]["Status"]);
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CheckUserByEmail", ex.Message);
        }
        return details;
    }
    public static int CreateUser(SqlConnection conGV, Userlogins Userlogins)
    {
        int x = 0;
        try
        {
            SqlCommand cmd = new SqlCommand("insert into Customers (UserGuid,Gender,FirstName,LastName,EmailId,ContactNo,Pwd,DOB,Status,Subscribed,ForgotId,AddedOn,AddedIp) values(@UserGuid,@Gender,@FirstName,@LastName,@EmailId,@ContactNo,@Pwd,@DOB,@Status,@Subscribed,@ForgotId,@AddedOn,@AddedIp)", conGV);
            cmd.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = Userlogins.UserGuid;
            cmd.Parameters.AddWithValue("@FirstName", SqlDbType.NVarChar).Value = Userlogins.FirstName;
            cmd.Parameters.AddWithValue("@LastName", SqlDbType.NVarChar).Value = Userlogins.LastName;
            cmd.Parameters.AddWithValue("@EmailId", SqlDbType.NVarChar).Value = Userlogins.EmailId;
            cmd.Parameters.AddWithValue("@ContactNo", SqlDbType.NVarChar).Value = Userlogins.ContactNo;
            cmd.Parameters.AddWithValue("@Pwd", SqlDbType.NVarChar).Value = Userlogins.Password;
            cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = Userlogins.Status;
            cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = Userlogins.AddedOn;
            cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = Userlogins.AddedIp;
            conGV.Open();
            x = cmd.ExecuteNonQuery();
            conGV.Close();
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "RegisterUser", ex.Message);
        }
        return x;
    }
    public static Userlogins UserLoginWithEmail(SqlConnection conGV, string uid, string pwd)
    {
        Userlogins result = new Userlogins();
        try
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select Pwd,UserGuid,Status,FirstName from Customers where EmailId=@EmailId and Pwd=@Pwd and Status != 'Deleted'", conGV);
            cmd.Parameters.AddWithValue("@EmailId", SqlDbType.NVarChar).Value = uid;
            cmd.Parameters.AddWithValue("@Pwd", SqlDbType.NVarChar).Value = pwd;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                result.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                result.Status = Convert.ToString(dt.Rows[0]["Status"]);
                result.UserGuid = Convert.ToString(dt.Rows[0]["UserGuid"]);
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UserLogin", ex.Message);
        }
        return result;
    }

    public static Userlogins UserLogin(SqlConnection conGV, string uid, string pwd)
    {
        Userlogins result = new Userlogins();
        try
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select Pwd,UserGuid,Status,FirstName from Customers where EmailId=@EmailId and Pwd=@Pwd and Status != 'Deleted'", conGV);
            cmd.Parameters.AddWithValue("@EmailId", SqlDbType.NVarChar).Value = uid;
            cmd.Parameters.AddWithValue("@Pwd", SqlDbType.NVarChar).Value = pwd;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                result.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                result.Status = Convert.ToString(dt.Rows[0]["Status"]);
                result.UserGuid = Convert.ToString(dt.Rows[0]["UserGuid"]);
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UserLogin", ex.Message);
        }
        return result;
    }

    public static int UpdateAsVerifed(SqlConnection conGV, string uGuid)
    {
        int x = 0;
        try
        {
            SqlCommand cmd1 = new SqlCommand("Update Customers Set Status='Verified' Where UserGuid=@UserGuid", conGV);
            cmd1.Parameters.AddWithValue("@UserGuid", SqlDbType.NVarChar).Value = uGuid;
            conGV.Open();
            x = cmd1.ExecuteNonQuery();
            conGV.Close();
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "RegisterUser", ex.Message);
        }
        return x;
    }



}