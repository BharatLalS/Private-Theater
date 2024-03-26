using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TheaterTiming
/// </summary>
public class TheaterTiming
{
    public int Id { get; set; }
    public string TheaterID { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedIp { get; set; }
    public string AddedBy { get; set; }
    public string Status { get; set; }

    //Extra 
    public string TheaterTitle { get; set; }

    #region Timing method


    /// <summary>
    /// Deletes a Timing from the database.
    /// </summary>
    /// <param name="conGV">The SQL connection object.</param>
    /// <param name="TheaterTiming">A TheaterTiming object containing details of the Timing to be deleted.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>
    public static int DeleteTiming(SqlConnection conGV, TheaterTiming TheaterTiming)
    {
        int result = 0;
        try
        {
            string query = "Update TheaterTiming Set Status=@Status, AddedOn=@AddedOn, AddedIp=@AddedIp Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = TheaterTiming.Id;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = TheaterTiming.AddedOn;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = TheaterTiming.AddedIp;
                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteTiming", ex.Message);
        }
        return result;
    }


    /// <summary>
    /// Retrieves all details of a Timing from the database based on the Timing's identifier.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="id">The identifier of the Timing.</param>
    /// <returns>A TheaterTiming object containing details of the specified Timing.</returns>
    public static TheaterTiming GetAllTheaterTimingsWithId(SqlConnection conSQ, int id)
    {
        var categories = new TheaterTiming();
        try
        {
            string query = "Select *,(Select TheaterTitle from TheaterDetails where TheaterID=TheaterDetails.TheaterGuid) as TheaterTitle from TheaterTiming where Status='Active' and Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new TheaterTiming()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  StartTime = Convert.ToString(dr["StartTime"]),
                                  EndTime = Convert.ToString(dr["EndTime"]),
                                  TheaterID = Convert.ToString(dr["TheaterID"]),
                                  TheaterTitle = Convert.ToString(dr["TheaterTitle"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedIp = Convert.ToString(dr["AddedIP"]),
                                  AddedBy = Convert.ToString(dr["AddedBy"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAlTheaterTimingsWithId", ex.Message);
        }
        return categories;
    }


    /// <summary>
    /// Retrieves details of all TheaterTiming from the database.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <returns>A list of TheaterTiming objects containing details of all TheaterTiming in the database.</returns>
    public static List<TheaterTiming> GetAllTheaterTimingWithTheaterID(SqlConnection conSQ, string TheaterID)
    {
        var ListOfBolgs = new List<TheaterTiming>();
        try
        {
            string query = "Select *,(Select TheaterTitle from TheaterDetails where TheaterID=TheaterDetails.TheaterGuid) as TheaterTitle from TheaterTiming where Status=@Status and TheaterID=@TheaterID Order by Id";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                cmd.Parameters.AddWithValue("@TheaterID", SqlDbType.NVarChar).Value = TheaterID;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ListOfBolgs = (from DataRow dr in dt.Rows
                               select new TheaterTiming()
                               {
                                   Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                   StartTime = Convert.ToString(dr["StartTime"]),
                                   EndTime = Convert.ToString(dr["EndTime"]),
                                   TheaterTitle = Convert.ToString(dr["TheaterTitle"]),
                                   TheaterID = Convert.ToString(dr["TheaterID"]),
                                   AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                   AddedIp = Convert.ToString(dr["AddedIP"]),
                                   AddedBy = Convert.ToString(dr["AddedBy"]),
                                   Status = Convert.ToString(dr["Status"])
                               }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllTheaterTimingWithTheaterID", ex.Message);
        }
        return ListOfBolgs;
    }


    /// <summary>
    /// Updates the details of a Timing in the database.
    /// </summary>
    /// <param name="conGV">The SQL connection object.</param>
    /// <param name="Timing">A TheaterTiming object containing updated details of the Timing.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>
    public static int UpdateTiming(SqlConnection conGV, TheaterTiming Timing)
    {
        int result = 0;
        try
        {
            string query = "Update TheaterTiming Set StartTime=@StartTime,EndTime=@EndTime,AddedOn=@AddedOn,AddedIp=@AddedIp, AddedBy=@AddedBy Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = Timing.Id;
                cmd.Parameters.AddWithValue("@StartTime", SqlDbType.NVarChar).Value = Timing.StartTime;
                cmd.Parameters.AddWithValue("@EndTime", SqlDbType.NVarChar).Value = Timing.EndTime;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = DateTime.UtcNow;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = Timing.AddedBy;

                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateTiming", ex.Message);
        }
        return result;
    }


    /// <summary>
    /// Adds a new Timing to the database.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="Timing">A TheaterTiming object containing details of the Timing to be added.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>
    public static int AddTiming(SqlConnection conSQ, TheaterTiming Timing)
    {
        int result = 0;
        try
        {
            string query = "Insert Into TheaterTiming (StartTime,EndTime,TheaterID,AddedOn,AddedIP,Status,AddedBy) values (@StartTime,@EndTime,@TheaterID,@AddedOn,@AddedIP,@Status,@AddedBy) select SCOPE_IDENTITY()";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@StartTime", SqlDbType.NVarChar).Value = Timing.StartTime;
                cmd.Parameters.AddWithValue("@EndTime", SqlDbType.NVarChar).Value = Timing.EndTime;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = Timing.AddedBy;
                cmd.Parameters.AddWithValue("@TheaterID", SqlDbType.NVarChar).Value = Timing.TheaterID;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value =TimeStamps.UTCTime();
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = Timing.Status;
                conSQ.Open();
                result = Convert.ToInt32(cmd.ExecuteNonQuery());
                conSQ.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "AddTiming", ex.Message);
        }
        return result;
    }

    #endregion
}