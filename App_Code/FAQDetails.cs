using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FAQDetails
/// </summary>
public class FAQDetails
{
    public FAQDetails()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int Id { get; set; }
    public string FAQQuestion { get; set; }
    public string FAQDesc { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedBy { get; set; }
    public string AddedIp { get; set; }
    public string Status { get; set; }

    #region FAQ method
    /// <summary>
    /// Deletes a paper format from the database.
    /// </summary>
    /// <param name="conGV">The SQL connection object.</param>
    /// <param name="FAQ">A FAQDetails object containing details of the paper format to be deleted.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>

    public static int DeleteFAQ(SqlConnection conGV, FAQDetails FAQ)
    {
        int result = 0;
        try
        {
            string query = "Update FAQDetails Set Status=@Status, AddedOn=@AddedOn, AddedIp=@AddedIp Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = FAQ.Id;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = FAQ.AddedOn;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = FAQ.AddedIp;
                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteFAQ", ex.Message);
        }
        return result;
    }
    /// <summary>
    /// Retrieves all details of a paper format from the database based on the format's identifier.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="id">The identifier of the paper format.</param>
    /// <returns>A FAQDetails object containing details of the specified paper format.</returns>

    public static FAQDetails GetAllFAQDetailsWithId(SqlConnection conSQ, int id)
    {
        var FAQDetails = new FAQDetails();
        try
        {
            string query = "Select * from FAQDetails where Status='Active' and Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                FAQDetails = (from DataRow dr in dt.Rows
                                 select new FAQDetails()
                                 {
                                     Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                     FAQDesc = Convert.ToString(dr["FAQDesc"]),
                                     FAQQuestion = Convert.ToString(dr["FAQQuestion"]),
                                     AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                     AddedIp = Convert.ToString(dr["AddedIP"]),
                                     AddedBy = Convert.ToString(dr["AddedBy"]),
                                     Status = Convert.ToString(dr["Status"])
                                 }).FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAlFAQDetailsWithId", ex.Message);
        }
        return FAQDetails;
    }
    /// <summary>
    /// Retrieves all details of a paper format from the database based on the format's identifier.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="id">The identifier of the paper format.</param>
    /// <returns>A FAQDetails object containing details of the specified paper format.</returns>

    public static FAQDetails GetAllFAQDetailsDetailsWithUrl(SqlConnection conSQ, string url)
    {
        var FAQDetails = new FAQDetails();
        try
        {
            string query = "Select * from FAQDetails where Status='Active' and FAQUrl=@url ";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@url", SqlDbType.Int).Value = url;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                FAQDetails = (from DataRow dr in dt.Rows
                                 select new FAQDetails()
                                 {
                                     Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                     FAQDesc = Convert.ToString(dr["FAQDesc"]),
                                     FAQQuestion = Convert.ToString(dr["FAQQuestion"]),
                                     AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                     AddedIp = Convert.ToString(dr["AddedIP"]),
                                     AddedBy = Convert.ToString(dr["AddedBy"]),
                                     Status = Convert.ToString(dr["Status"])
                                 }).FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllFAQDetailsDetailsWithUrl", ex.Message);
        }
        return FAQDetails;
    }
    /// <summary>
    /// Retrieves details of all paper formats from the database.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <returns>A list of FAQDetails objects containing details of all paper formats in the database.</returns>

    public static List<FAQDetails> GetAllFAQDetails(SqlConnection conSQ)
    {
        var ListOfBolgs = new List<FAQDetails>();
        try
        {
            string query = "Select * from FAQDetails where Status=@Status Order by Id ";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ListOfBolgs = (from DataRow dr in dt.Rows
                               select new FAQDetails()
                               {
                                   Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                   FAQDesc = Convert.ToString(dr["FAQDesc"]),
                                   FAQQuestion = Convert.ToString(dr["FAQQuestion"]),
                                   AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                   AddedIp = Convert.ToString(dr["AddedIP"]),
                                   AddedBy = Convert.ToString(dr["AddedBy"]),
                                   Status = Convert.ToString(dr["Status"])
                               }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllFAQDetails", ex.Message);
        }
        return ListOfBolgs;
    }
    public static int UpdateFAQ(SqlConnection conGV, FAQDetails FAQ)
    {
        int result = 0;
        try
        {
            string query = "Update FAQDetails Set FAQDesc=@FAQDesc,FAQQuestion=@FAQQuestion,AddedOn=@AddedOn,AddedIp=@AddedIp,AddedBy=@AddedBy Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = FAQ.Id;
                cmd.Parameters.AddWithValue("@FAQDesc", SqlDbType.NVarChar).Value = FAQ.FAQDesc;
                cmd.Parameters.AddWithValue("@FAQQuestion", SqlDbType.NVarChar).Value = FAQ.FAQQuestion;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = TimeStamps.UTCTime();
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = FAQ.AddedBy;

                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateFAQ", ex.Message);
        }
        return result;
    }
    /// <summary>
    /// Adds a new paper format to the database.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="FAQ">A FAQDetails object containing details of the paper format to be added.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>
    public static int AddFAQ(SqlConnection conSQ, FAQDetails FAQ)
    {
        int result = 0;
        try
        {
            string query = "Insert Into FAQDetails (FAQQuestion,FAQDesc,AddedOn,AddedIP,Status,AddedBy) values (@FAQQuestion,@FAQDesc,@AddedOn,@AddedIP,@Status,@AddedBy) select SCOPE_IDENTITY()";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@FAQQuestion", SqlDbType.NVarChar).Value = FAQ.FAQQuestion;
                cmd.Parameters.AddWithValue("@FAQDesc", SqlDbType.NVarChar).Value = FAQ.FAQDesc;
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = FAQ.AddedBy;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = TimeStamps.UTCTime();
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = FAQ.Status;
                conSQ.Open();
                result = Convert.ToInt32(cmd.ExecuteScalar());
                conSQ.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "AddFAQ", ex.Message);
        }
        return result;
    }
    #endregion

}