using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StateMaster
/// </summary>
public class StateMaster
{
    public StateMaster()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region State properties
    public int Id { get; set; }
    public string StateTitle { get; set; }
    public string StateUrl { get; set; }
    public string StateOrder { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedIp { get; set; }
    public string AddedBy { get; set; }
    public string Status { get; set; }
    #endregion
    #region State method
    /// <summary>
    /// Deletes a State from the database.
    /// </summary>
    /// <param name="conGV">The SQL connection object.</param>
    /// <param name="StateMaster">A StateMaster object containing details of the State to be deleted.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>

    public static int DeleteState(SqlConnection conGV, StateMaster StateMaster)
    {
        int result = 0;
        try
        {
            string query = "Update StateMaster Set Status=@Status, AddedOn=@AddedOn, AddedIp=@AddedIp Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = StateMaster.Id;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = StateMaster.AddedOn;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = StateMaster.AddedIp;
                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteState", ex.Message);
        }
        return result;
    }
    /// <summary>
    /// Retrieves all details of a State from the database based on the State's identifier.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="id">The identifier of the State.</param>
    /// <returns>A StateMaster object containing details of the specified State.</returns>

    public static StateMaster GetAllStateDetailsWithId(SqlConnection conSQ, int id)
    {
        var categories = new StateMaster();
        try
        {
            string query = "Select * from StateMaster where Status='Active' and Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new StateMaster()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  StateTitle = Convert.ToString(dr["StateTitle"]),
                                  StateUrl = Convert.ToString(dr["StateUrl"]),
                                  StateOrder = Convert.ToString(dr["StateOrder"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedIp = Convert.ToString(dr["AddedIP"]),
                                  AddedBy = Convert.ToString(dr["AddedBy"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAlStateDetailsWithId", ex.Message);
        }
        return categories;
    }

    /// <summary>
    /// Retrieves all details of a State from the database based on the State's identifier.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="id">The identifier of the State.</param>
    /// <returns>A StateMaster object containing details of the specified State.</returns>

    public static StateMaster GetAllStateDetailsWithUrl(SqlConnection conSQ, string url)
    {
        var categories = new StateMaster();
        try
        {
            string query = "Select * from StateMaster where Status=@Status and StateUrl=@StateUrl";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                cmd.Parameters.AddWithValue("@StateUrl", SqlDbType.NVarChar).Value = url;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new StateMaster()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  StateTitle = Convert.ToString(dr["StateTitle"]),
                                  StateUrl = Convert.ToString(dr["StateUrl"]),
                                  StateOrder = Convert.ToString(dr["StateOrder"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedIp = Convert.ToString(dr["AddedIP"]),
                                  AddedBy = Convert.ToString(dr["AddedBy"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAlStateDetailsWithId", ex.Message);
        }
        return categories;
    }
    /// <summary>
    /// Retrieves details of all StateMaster from the database.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <returns>A list of StateMaster objects containing details of all StateMaster in the database.</returns>

    public static List<StateMaster> GetAllStateMaster(SqlConnection conSQ)
    {
        var ListOfBolgs = new List<StateMaster>();
        try
        {
            string query = "Select * from StateMaster where Status=@Status Order by Id";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ListOfBolgs = (from DataRow dr in dt.Rows
                               select new StateMaster()
                               {
                                   Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                   StateTitle = Convert.ToString(dr["StateTitle"]),
                                   StateUrl = Convert.ToString(dr["StateUrl"]),
                                   StateOrder = Convert.ToString(dr["StateOrder"]),
                                   AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                   AddedIp = Convert.ToString(dr["AddedIP"]),
                                   AddedBy = Convert.ToString(dr["AddedBy"]),
                                   Status = Convert.ToString(dr["Status"])
                               }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllStateMaster", ex.Message);
        }
        return ListOfBolgs;
    }
    /// <summary>
    /// Updates the details of a State in the database.
    /// </summary>
    /// <param name="conGV">The SQL connection object.</param>
    /// <param name="State">A StateMaster object containing updated details of the State.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>

    public static int UpdateState(SqlConnection conGV, StateMaster State)
    {
        int result = 0;
        try
        {
            string query = "Update StateMaster Set StateTitle=@StateTitle,StateUrl=@StateUrl,AddedOn=@AddedOn,AddedIp=@AddedIp, AddedBy=@AddedBy Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = State.Id;
                cmd.Parameters.AddWithValue("@StateTitle", SqlDbType.NVarChar).Value = State.StateTitle;
                cmd.Parameters.AddWithValue("@StateUrl", SqlDbType.NVarChar).Value = State.StateUrl;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = DateTime.UtcNow;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = State.AddedBy;

                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateState", ex.Message);
        }
        return result;
    }
    /// <summary>
    /// Adds a new State to the database.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="State">A StateMaster object containing details of the State to be added.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>
    public static int AddState(SqlConnection conSQ, StateMaster State)
    {
        int result = 0;
        try
        {
            string query = "Insert Into StateMaster (StateTitle,StateUrl,AddedOn,AddedIP,Status,AddedBy) values (@StateTitle,@StateUrl,@AddedOn,@AddedIP,@Status,@AddedBy) select SCOPE_IDENTITY()";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@StateTitle", SqlDbType.NVarChar).Value = State.StateTitle;
                cmd.Parameters.AddWithValue("@StateUrl", SqlDbType.NVarChar).Value = State.StateUrl;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = State.AddedBy;
                cmd.Parameters.AddWithValue("@StateOrder", SqlDbType.NVarChar).Value = State.StateOrder;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = DateTime.UtcNow;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = State.Status;
                conSQ.Open();
                result = Convert.ToInt32(cmd.ExecuteNonQuery());
                conSQ.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "AddState", ex.Message);
        }
        return result;
    }

    public static int UpdateStateOrder(SqlConnection conGV, StateMaster cat)
    {
        int result = 0;
        try
        {
            string query = "Update StateMaster Set AddedOn=@AddedOn,AddedIp=@AddedIp,StateOrder=@StateOrder Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = cat.Id;
                cmd.Parameters.AddWithValue("@StateOrder", SqlDbType.NVarChar).Value = cat.StateOrder;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = TimeStamps.UTCTime();
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateStateOrder", ex.Message);
        }
        return result;
    }

    #endregion
}