using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CityMaster
/// </summary>
public class CityMaster
{
    public CityMaster()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region City properties
    public int Id { get; set; }
    public string CityTitle { get; set; }
    public string StateID { get; set; }
    public string CityUrl { get; set; }
    public string CityOrder { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedIp { get; set; }
    public string AddedBy { get; set; }
    public string Status { get; set; }

    //Extra 
    public string StateTitle { get; set; }
    #endregion
    #region City method
    /// <summary>
    /// Deletes a City from the database.
    /// </summary>
    /// <param name="conGV">The SQL connection object.</param>
    /// <param name="CityMaster">A CityMaster object containing details of the City to be deleted.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>

    public static int DeleteCity(SqlConnection conGV, CityMaster CityMaster)
    {
        int result = 0;
        try
        {
            string query = "Update CityMaster Set Status=@Status, AddedOn=@AddedOn, AddedIp=@AddedIp Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = CityMaster.Id;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = CityMaster.AddedOn;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = CityMaster.AddedIp;
                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteCity", ex.Message);
        }
        return result;
    }
    /// <summary>
    /// Retrieves all details of a City from the database based on the City's identifier.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="id">The identifier of the City.</param>
    /// <returns>A CityMaster object containing details of the specified City.</returns>

    public static CityMaster GetAllCityDetailsWithId(SqlConnection conSQ, int id)
    {
        var categories = new CityMaster();
        try
        {
            string query = "Select *,(Select StateTitle from StateMaster where stateID=StateMaster.ID) as StateTitle from CityMaster where Status='Active' and Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new CityMaster()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  CityTitle = Convert.ToString(dr["CityTitle"]),
                                  StateTitle = Convert.ToString(dr["StateTitle"]),
                                  StateID = Convert.ToString(dr["StateID"]),
                                  CityUrl = Convert.ToString(dr["CityUrl"]),
                                  CityOrder = Convert.ToString(dr["CityOrder"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedIp = Convert.ToString(dr["AddedIP"]),
                                  AddedBy = Convert.ToString(dr["AddedBy"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAlCityDetailsWithId", ex.Message);
        }
        return categories;
    }

    /// <summary>
    /// Retrieves all details of a City from the database based on the City's identifier.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="id">The identifier of the City.</param>
    /// <returns>A CityMaster object containing details of the specified City.</returns>

    public static CityMaster GetAllCityDetailsWithUrl(SqlConnection conSQ, string url)
    {
        var categories = new CityMaster();
        try
        {
            string query = "Select *,(Select StateTitle from StateMaster where stateID=StateMaster.ID) as StateTitle from CityMaster where Status=@Status and CityUrl=@CityUrl";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                cmd.Parameters.AddWithValue("@CityUrl", SqlDbType.NVarChar).Value = url;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new CityMaster()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  CityTitle = Convert.ToString(dr["CityTitle"]),
                                  StateTitle = Convert.ToString(dr["StateTitle"]),
                                  StateID = Convert.ToString(dr["StateID"]),
                                  CityUrl = Convert.ToString(dr["CityUrl"]),
                                  CityOrder = Convert.ToString(dr["CityOrder"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedIp = Convert.ToString(dr["AddedIP"]),
                                  AddedBy = Convert.ToString(dr["AddedBy"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAlCityDetailsWithId", ex.Message);
        }
        return categories;
    }
    /// <summary>
    /// Retrieves details of all CityMaster from the database.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <returns>A list of CityMaster objects containing details of all CityMaster in the database.</returns>

    public static List<CityMaster> GetAllCityMaster(SqlConnection conSQ)
    {
        var ListOfBolgs = new List<CityMaster>();
        try
        {
            string query = "Select *,(Select StateTitle from StateMaster where stateID=StateMaster.ID) as StateTitle from CityMaster where Status=@Status Order by Id";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ListOfBolgs = (from DataRow dr in dt.Rows
                               select new CityMaster()
                               {
                                   Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                   CityTitle = Convert.ToString(dr["CityTitle"]),
                                   StateTitle = Convert.ToString(dr["StateTitle"]),
                                   CityUrl = Convert.ToString(dr["CityUrl"]),
                                   CityOrder = Convert.ToString(dr["CityOrder"]),
                                   StateID = Convert.ToString(dr["StateID"]),
                                   AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                   AddedIp = Convert.ToString(dr["AddedIP"]),
                                   AddedBy = Convert.ToString(dr["AddedBy"]),
                                   Status = Convert.ToString(dr["Status"])
                               }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllCityMaster", ex.Message);
        }
        return ListOfBolgs;
    }
    /// <summary>
    /// Retrieves details of all CityMaster from the database.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <returns>A list of CityMaster objects containing details of all CityMaster in the database.</returns>

    public static List<CityMaster> GetAllCityMasterWithStateId(SqlConnection conSQ, string StateID)
    {
        var ListOfBolgs = new List<CityMaster>();
        try
        {
            string query = "Select *,(Select StateTitle from StateMaster where stateID=StateMaster.ID) as StateTitle from CityMaster where Status=@Status and StateID=@StateID Order by Id";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                cmd.Parameters.AddWithValue("@StateID", SqlDbType.NVarChar).Value = StateID;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ListOfBolgs = (from DataRow dr in dt.Rows
                               select new CityMaster()
                               {
                                   Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                   CityTitle = Convert.ToString(dr["CityTitle"]),
                                   StateTitle = Convert.ToString(dr["StateTitle"]),
                                   CityUrl = Convert.ToString(dr["CityUrl"]),
                                   CityOrder = Convert.ToString(dr["CityOrder"]),
                                   StateID = Convert.ToString(dr["StateID"]),
                                   AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                   AddedIp = Convert.ToString(dr["AddedIP"]),
                                   AddedBy = Convert.ToString(dr["AddedBy"]),
                                   Status = Convert.ToString(dr["Status"])
                               }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllCityMasterWithStateId", ex.Message);
        }
        return ListOfBolgs;
    }
    /// <summary>
    /// Updates the details of a City in the database.
    /// </summary>
    /// <param name="conGV">The SQL connection object.</param>
    /// <param name="City">A CityMaster object containing updated details of the City.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>

    public static int UpdateCity(SqlConnection conGV, CityMaster City)
    {
        int result = 0;
        try
        {
            string query = "Update CityMaster Set CityTitle=@CityTitle,CityUrl=@CityUrl,StateID=@StateID,AddedOn=@AddedOn,AddedIp=@AddedIp, AddedBy=@AddedBy Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = City.Id;
                cmd.Parameters.AddWithValue("@CityTitle", SqlDbType.NVarChar).Value = City.CityTitle;
                cmd.Parameters.AddWithValue("@CityUrl", SqlDbType.NVarChar).Value = City.CityUrl;
                cmd.Parameters.AddWithValue("@StateID", SqlDbType.NVarChar).Value = City.StateID;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = DateTime.UtcNow;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = City.AddedBy;

                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateCity", ex.Message);
        }
        return result;
    }
    /// <summary>
    /// Adds a new City to the database.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="City">A CityMaster object containing details of the City to be added.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>
    public static int AddCity(SqlConnection conSQ, CityMaster City)
    {
        int result = 0;
        try
        {
            string query = "Insert Into CityMaster (CityTitle,CityUrl,StateID,AddedOn,AddedIP,Status,AddedBy) values (@CityTitle,@CityUrl,@StateID,@AddedOn,@AddedIP,@Status,@AddedBy) select SCOPE_IDENTITY()";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@CityTitle", SqlDbType.NVarChar).Value = City.CityTitle;
                cmd.Parameters.AddWithValue("@CityUrl", SqlDbType.NVarChar).Value = City.CityUrl;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = City.AddedBy;
                cmd.Parameters.AddWithValue("@CityOrder", SqlDbType.NVarChar).Value = City.CityOrder;
                cmd.Parameters.AddWithValue("@StateID", SqlDbType.NVarChar).Value = City.StateID;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = DateTime.UtcNow;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = City.Status;
                conSQ.Open();
                result = Convert.ToInt32(cmd.ExecuteNonQuery());
                conSQ.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "AddCity", ex.Message);
        }
        return result;
    }

    public static int UpdateCityOrder(SqlConnection conGV, CityMaster cat)
    {
        int result = 0;
        try
        {
            string query = "Update CityMaster Set AddedOn=@AddedOn,AddedIp=@AddedIp,CityOrder=@CityOrder Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = cat.Id;
                cmd.Parameters.AddWithValue("@CityOrder", SqlDbType.NVarChar).Value = cat.CityOrder;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = TimeStamps.UTCTime();
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateCityOrder", ex.Message);
        }
        return result;
    }
    #endregion
}