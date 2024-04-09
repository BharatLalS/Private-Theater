using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AreaMaster
/// </summary>
public class AreaMaster
{
    public AreaMaster()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region Area properties
    public int Id { get; set; }
    public string AreaTitle { get; set; }
    public string StateID { get; set; }
    public string CityID { get; set; }
    public string AreaUrl { get; set; }
    public string AreaOrder { get; set; }
    public string ImageUrl { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedIp { get; set; }
    public string AddedBy { get; set; }
    public string Status { get; set; }

    //Extra 
    public string StateTitle { get; set; }
    public string CityTitle { get; set; }
    #endregion
    #region Area method
    /// <summary>
    /// Deletes a Area from the database.
    /// </summary>
    /// <param name="conGV">The SQL connection object.</param>
    /// <param name="AreaMaster">A AreaMaster object containing details of the Area to be deleted.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>

    public static int DeleteArea(SqlConnection conGV, AreaMaster AreaMaster)
    {
        int result = 0;
        try
        {
            string query = "Update AreaMaster Set Status=@Status, AddedOn=@AddedOn, AddedIp=@AddedIp Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = AreaMaster.Id;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = AreaMaster.AddedOn;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = AreaMaster.AddedIp;
                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteArea", ex.Message);
        }
        return result;
    }
    /// <summary>
    /// Retrieves all details of a Area from the database based on the Area's identifier.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="id">The identifier of the Area.</param>
    /// <returns>A AreaMaster object containing details of the specified Area.</returns>

    public static AreaMaster GetAllAreaDetailsWithId(SqlConnection conSQ, int id)
    {
        var categories = new AreaMaster();
        try
        {
            string query = "Select *,(Select StateTitle from StateMaster where stateID=StateMaster.ID) as StateTitle,(Select CityTitle from CityMaster where CityID=CityMaster.ID) as CityTitle from AreaMaster where Status='Active' and Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new AreaMaster()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  AreaTitle = Convert.ToString(dr["AreaTitle"]),
                                  StateTitle = Convert.ToString(dr["StateTitle"]),
                                  CityTitle = Convert.ToString(dr["CityTitle"]),
                                  StateID = Convert.ToString(dr["StateID"]),
                                  CityID = Convert.ToString(dr["CityID"]),
                                  AreaUrl = Convert.ToString(dr["AreaUrl"]),
                                  ImageUrl = Convert.ToString(dr["ImageUrl"]),
                                  AreaOrder = Convert.ToString(dr["AreaOrder"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedIp = Convert.ToString(dr["AddedIP"]),
                                  AddedBy = Convert.ToString(dr["AddedBy"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAlAreaDetailsWithId", ex.Message);
        }
        return categories;
    }

    /// <summary>
    /// Retrieves all details of a Area from the database based on the Area's identifier.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="id">The identifier of the Area.</param>
    /// <returns>A AreaMaster object containing details of the specified Area.</returns>

    public static AreaMaster GetAllAreaDetailsWithUrl(SqlConnection conSQ, string url)
    {
        var categories = new AreaMaster();
        try
        {
            string query = "Select *,(Select StateTitle from StateMaster where stateID=StateMaster.ID) as StateTitle,(Select CityTitle from CityMaster where CityID=CityMaster.ID) as CityTitle from AreaMaster where Status=@Status and AreaUrl=@AreaUrl";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                cmd.Parameters.AddWithValue("@AreaUrl", SqlDbType.NVarChar).Value = url;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new AreaMaster()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  AreaTitle = Convert.ToString(dr["AreaTitle"]),
                                  StateTitle = Convert.ToString(dr["StateTitle"]),
                                  CityTitle = Convert.ToString(dr["CityTitle"]),
                                  StateID = Convert.ToString(dr["StateID"]),
                                  CityID = Convert.ToString(dr["CityID"]),
                                  AreaUrl = Convert.ToString(dr["AreaUrl"]),
                                  ImageUrl = Convert.ToString(dr["ImageUrl"]),
                                  AreaOrder = Convert.ToString(dr["AreaOrder"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedIp = Convert.ToString(dr["AddedIP"]),
                                  AddedBy = Convert.ToString(dr["AddedBy"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAlAreaDetailsWithId", ex.Message);
        }
        return categories;
    }


    /// <summary>
    /// Retrieves details of all AreaMaster from the database.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <returns>A list of AreaMaster objects containing details of all AreaMaster in the database.</returns>

    public static List<AreaMaster> GetAllAreaMasterWithCityId(SqlConnection conSQ, string StateID)
    {
        var ListOfBolgs = new List<AreaMaster>();
        try
        {
            string query = "Select *,(Select StateTitle from StateMaster where stateID=StateMaster.ID) as StateTitle,(Select CityTitle from CityMaster where CityID=CityMaster.ID) as CityTitle from AreaMaster where Status=@Status and StateID=@StateID Order by Id";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                cmd.Parameters.AddWithValue("@StateID", SqlDbType.NVarChar).Value = StateID;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ListOfBolgs = (from DataRow dr in dt.Rows
                               select new AreaMaster()
                               {
                                   Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                   AreaTitle = Convert.ToString(dr["AreaTitle"]),
                                   StateTitle = Convert.ToString(dr["StateTitle"]),
                                   CityTitle = Convert.ToString(dr["CityTitle"]),
                                   StateID = Convert.ToString(dr["StateID"]),
                                   CityID = Convert.ToString(dr["CityID"]),
                                   AreaUrl = Convert.ToString(dr["AreaUrl"]),
                                   ImageUrl = Convert.ToString(dr["ImageUrl"]),
                                   AreaOrder = Convert.ToString(dr["AreaOrder"]),
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
    /// Retrieves details of all AreaMaster from the database.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <returns>A list of AreaMaster objects containing details of all AreaMaster in the database.</returns>

    public static List<AreaMaster> GetAllAreaMaster(SqlConnection conSQ)
    {
        var ListOfBolgs = new List<AreaMaster>();
        try
        {
            string query = "Select *,(Select StateTitle from StateMaster where stateID=StateMaster.ID) as StateTitle ,(Select CityTitle from CityMaster where CityID=CityMaster.ID) as CityTitle from AreaMaster where Status=@Status Order by Id";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ListOfBolgs = (from DataRow dr in dt.Rows
                               select new AreaMaster()
                               {
                                   Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                   AreaTitle = Convert.ToString(dr["AreaTitle"]),
                                   StateTitle = Convert.ToString(dr["StateTitle"]),
                                   CityTitle = Convert.ToString(dr["CityTitle"]),
                                   AreaUrl = Convert.ToString(dr["AreaUrl"]),
                                   ImageUrl = Convert.ToString(dr["ImageUrl"]),
                                   AreaOrder = Convert.ToString(dr["AreaOrder"]),
                                   StateID = Convert.ToString(dr["StateID"]),
                                   CityID = Convert.ToString(dr["CityID"]),
                                   AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                   AddedIp = Convert.ToString(dr["AddedIP"]),
                                   AddedBy = Convert.ToString(dr["AddedBy"]),
                                   Status = Convert.ToString(dr["Status"])
                               }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllAreaMaster", ex.Message);
        }
        return ListOfBolgs;
    }
    /// <summary>
    /// Updates the details of a Area in the database.
    /// </summary>
    /// <param name="conGV">The SQL connection object.</param>
    /// <param name="Area">A AreaMaster object containing updated details of the Area.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>

    public static int UpdateArea(SqlConnection conGV, AreaMaster Area)
    {
        int result = 0;
        try
        {
            string query = "Update AreaMaster Set AreaTitle=@AreaTitle,AreaUrl=@AreaUrl,ImageUrl=@ImageUrl,StateID=@StateID,CityID=@CityID,AddedOn=@AddedOn,AddedIp=@AddedIp, AddedBy=@AddedBy Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = Area.Id;
                cmd.Parameters.AddWithValue("@AreaTitle", SqlDbType.NVarChar).Value = Area.AreaTitle;
                cmd.Parameters.AddWithValue("@AreaUrl", SqlDbType.NVarChar).Value = Area.AreaUrl;
                cmd.Parameters.AddWithValue("@ImageUrl", SqlDbType.NVarChar).Value = Area.ImageUrl;
                cmd.Parameters.AddWithValue("@StateID", SqlDbType.NVarChar).Value = Area.StateID;
                cmd.Parameters.AddWithValue("@CityID", SqlDbType.NVarChar).Value = Area.CityID;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = DateTime.UtcNow;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = Area.AddedBy;

                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateArea", ex.Message);
        }
        return result;
    }
    /// <summary>
    /// Adds a new Area to the database.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="Area">A AreaMaster object containing details of the Area to be added.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>
    public static int AddArea(SqlConnection conSQ, AreaMaster Area)
    {
        int result = 0;
        try
        {
            string query = "Insert Into AreaMaster (AreaTitle,AreaUrl,ImageUrl,StateID,CityID,AddedOn,AddedIP,Status,AddedBy) values (@AreaTitle,@AreaUrl,@ImageUrl,@StateID,@CityID,@AddedOn,@AddedIP,@Status,@AddedBy) select SCOPE_IDENTITY()";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@AreaTitle", SqlDbType.NVarChar).Value = Area.AreaTitle;
                cmd.Parameters.AddWithValue("@AreaUrl", SqlDbType.NVarChar).Value = Area.AreaUrl;
                cmd.Parameters.AddWithValue("@ImageUrl", SqlDbType.NVarChar).Value = Area.ImageUrl;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = Area.AddedBy;
                cmd.Parameters.AddWithValue("@AreaOrder", SqlDbType.NVarChar).Value = Area.AreaOrder;
                cmd.Parameters.AddWithValue("@StateID", SqlDbType.NVarChar).Value = Area.StateID;
                cmd.Parameters.AddWithValue("@CityID", SqlDbType.NVarChar).Value = Area.CityID;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = DateTime.UtcNow;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = Area.Status;
                conSQ.Open();
                result = Convert.ToInt32(cmd.ExecuteNonQuery());
                conSQ.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "AddArea", ex.Message);
        }
        return result;
    }

    public static int UpdateAreaOrder(SqlConnection conGV, AreaMaster cat)
    {
        int result = 0;
        try
        {
            string query = "Update AreaMaster Set AddedOn=@AddedOn,AddedIp=@AddedIp,AreaOrder=@AreaOrder Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = cat.Id;
                cmd.Parameters.AddWithValue("@AreaOrder", SqlDbType.NVarChar).Value = cat.AreaOrder;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = TimeStamps.UTCTime();
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = CommonModel.IPAddress();
                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateAreaOrder", ex.Message);
        }
        return result;
    }
    #endregion

}