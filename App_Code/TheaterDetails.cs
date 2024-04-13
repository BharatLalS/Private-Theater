using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Security.Policy;

/// <summary>
/// Summary description for TheaterDetails
/// </summary>
public class TheaterDetails
{
    public TheaterDetails()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int Id { get; set; }
    public string AreaID { get; set; }
    public string CityID { get; set; }
    public string StateID { get; set; }
    public string TheaterGuid { get; set; }
    public string TheaterTitle { get; set; }
    public string TheaterUrl { get; set; }
    public string Pincode { get; set; }
    public string Address { get; set; }
    public string FullDesc { get; set; }
    public string ShortDesc { get; set; }
    public string PageTitle { get; set; }
    public string MetaKeys { get; set; }
    public string MetaDesc { get; set; }
    public string MaxAllowed { get; set; }
    public string MaxCapacity { get; set; }
    public string Price { get; set; }
    public string ExtraPrice { get; set; }
    public string ThumbImage { get; set; }
    public string LocationLink { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedIp { get; set; }
    public string AddedBy { get; set; }
    public string Status { get; set; }

    //Extra
    public string AreaTitle { get; set; }
    public string CityTitle { get; set; }
    public string StateTitle { get; set; }
    public string TimingCount { get; set; }
    public string GalleryCount { get; set; }



    /// <summary>
    /// Retrieves details of all TheaterDetails from the database.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <returns>A list of TheaterDetails objects containing details of all TheaterDetails in the database.</returns>

    public static List<TheaterDetails> GetAllTheaterDetails(SqlConnection conSQ)
    {
        var ListOfBolgs = new List<TheaterDetails>();
        try
        {
            string query = "Select *,(Select StateTitle from StateMaster where stateID=StateMaster.ID) as StateTitle,(Select AreaTitle from AreaMaster where AreaID=AreaMaster.ID) as AreaTitle ,(Select CityTitle from CityMaster where CityID=CityMaster.ID) as CityTitle,(Select Count(ID) from TheaterTiming Where TheaterID=TheaterGuid and TheaterTiming.Status !='Deleted') as TimingCount,(Select Count(ID) from TheaterImages Where TheaterID=TheaterGuid and TheaterImages.Status !='Deleted') as GalleryCount from TheaterDetails where Status=@Status Order by Id";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ListOfBolgs = (from DataRow dr in dt.Rows
                               select new TheaterDetails()
                               {
                                   Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                   AreaTitle = Convert.ToString(dr["AreaTitle"]),
                                   StateTitle = Convert.ToString(dr["StateTitle"]),
                                   CityTitle = Convert.ToString(dr["CityTitle"]),
                                   TheaterTitle = Convert.ToString(dr["TheaterTitle"]),
                                   GalleryCount = Convert.ToString(dr["GalleryCount"]),
                                   TimingCount = Convert.ToString(dr["TimingCount"]),
                                   TheaterGuid = Convert.ToString(dr["TheaterGuid"]),
                                   TheaterUrl = Convert.ToString(dr["TheaterUrl"]),
                                   StateID = Convert.ToString(dr["StateID"]),
                                   CityID = Convert.ToString(dr["CityID"]),
                                   AreaID = Convert.ToString(dr["AreaID"]),
                                   Pincode = Convert.ToString(dr["Pincode"]),
                                   Address = Convert.ToString(dr["Address"]),
                                   FullDesc = Convert.ToString(dr["FullDesc"]),
                                   ShortDesc = Convert.ToString(dr["ShortDesc"]),
                                   PageTitle = Convert.ToString(dr["PageTitle"]),
                                   MetaKeys = Convert.ToString(dr["MetaKeys"]),
                                   MetaDesc = Convert.ToString(dr["MetaDesc"]),
                                   MaxAllowed = Convert.ToString(dr["MaxAllowed"]),
                                   MaxCapacity = Convert.ToString(dr["MaxCapacity"]),
                                   ExtraPrice = Convert.ToString(dr["ExtraPrice"]),
                                   Price = Convert.ToString(dr["Price"]),
                                   LocationLink = Convert.ToString(dr["LocationLink"]),
                                   ThumbImage = Convert.ToString(dr["ThumbImage"]),
                                   AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                   AddedIp = Convert.ToString(dr["AddedIP"]),
                                   AddedBy = Convert.ToString(dr["AddedBy"]),
                                   Status = Convert.ToString(dr["Status"])
                               }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllTheaterDetails", ex.Message);
        }
        return ListOfBolgs;
    }

    /// <summary>
    /// Retrieves all details of a Theater from the database based on the Theater's identifier.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="id">The identifier of the Theater.</param>
    /// <returns>A TheaterDetails object containing details of the specified Theater.</returns>

    public static TheaterDetails GetAllTheaterDetailsWithId(SqlConnection conSQ, int id)
    {
        var categories = new TheaterDetails();
        try
        {
            string query = "Select *,(Select StateTitle from StateMaster where stateID=StateMaster.ID) as StateTitle,(Select AreaTitle from AreaMaster where AreaID=AreaMaster.ID) as AreaTitle,(Select CityTitle from CityMaster where CityID=CityMaster.ID) as CityTitle from TheaterDetails where Status='Active' and Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new TheaterDetails()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  AreaTitle = Convert.ToString(dr["AreaTitle"]),
                                  StateTitle = Convert.ToString(dr["StateTitle"]),
                                  CityTitle = Convert.ToString(dr["CityTitle"]),
                                  TheaterTitle = Convert.ToString(dr["TheaterTitle"]),
                                  TheaterGuid = Convert.ToString(dr["TheaterGuid"]),
                                  TheaterUrl = Convert.ToString(dr["TheaterUrl"]),
                                  StateID = Convert.ToString(dr["StateID"]),
                                  CityID = Convert.ToString(dr["CityID"]),
                                  AreaID = Convert.ToString(dr["AreaID"]),
                                  Pincode = Convert.ToString(dr["Pincode"]),
                                  Address = Convert.ToString(dr["Address"]),
                                  FullDesc = Convert.ToString(dr["FullDesc"]),
                                  ShortDesc = Convert.ToString(dr["ShortDesc"]),
                                  PageTitle = Convert.ToString(dr["PageTitle"]),
                                  MetaKeys = Convert.ToString(dr["MetaKeys"]),
                                  MetaDesc = Convert.ToString(dr["MetaDesc"]),
                                  MaxAllowed = Convert.ToString(dr["MaxAllowed"]),
                                  MaxCapacity = Convert.ToString(dr["MaxCapacity"]),
                                  ExtraPrice = Convert.ToString(dr["ExtraPrice"]),
                                  Price = Convert.ToString(dr["Price"]),
                                  LocationLink = Convert.ToString(dr["LocationLink"]),
                                  ThumbImage = Convert.ToString(dr["ThumbImage"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedIp = Convert.ToString(dr["AddedIP"]),
                                  AddedBy = Convert.ToString(dr["AddedBy"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAlTheaterDetailsWithId", ex.Message);
        }
        return categories;
    }

    /// <summary>
    /// Retrieves all details of a Theater from the database based on the Theater's Guid.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="id">The identifier of the Theater.</param>
    /// <returns>A TheaterDetails object containing details of the specified Theater.</returns>

    public static TheaterDetails GetAllTheaterDetailsWithGuid(SqlConnection conSQ, string guid)
    {
        var categories = new TheaterDetails();
        try
        {
            string query = "Select *,(Select StateTitle from StateMaster where stateID=StateMaster.ID) as StateTitle,(Select AreaTitle from AreaMaster where AreaID=AreaMaster.ID) as AreaTitle,(Select CityTitle from CityMaster where CityID=CityMaster.ID) as CityTitle from TheaterDetails where Status='Active' and TheaterGuid=@TheaterGuid ";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@TheaterGuid", SqlDbType.NVarChar).Value = guid;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new TheaterDetails()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  AreaTitle = Convert.ToString(dr["AreaTitle"]),
                                  StateTitle = Convert.ToString(dr["StateTitle"]),
                                  CityTitle = Convert.ToString(dr["CityTitle"]),
                                  TheaterTitle = Convert.ToString(dr["TheaterTitle"]),
                                  TheaterGuid = Convert.ToString(dr["TheaterGuid"]),
                                  TheaterUrl = Convert.ToString(dr["TheaterUrl"]),
                                  StateID = Convert.ToString(dr["StateID"]),
                                  CityID = Convert.ToString(dr["CityID"]),
                                  AreaID = Convert.ToString(dr["AreaID"]),
                                  Pincode = Convert.ToString(dr["Pincode"]),
                                  Address = Convert.ToString(dr["Address"]),
                                  FullDesc = Convert.ToString(dr["FullDesc"]),
                                  ShortDesc = Convert.ToString(dr["ShortDesc"]),
                                  PageTitle = Convert.ToString(dr["PageTitle"]),
                                  MetaKeys = Convert.ToString(dr["MetaKeys"]),
                                  MetaDesc = Convert.ToString(dr["MetaDesc"]),
                                  MaxAllowed = Convert.ToString(dr["MaxAllowed"]),
                                  MaxCapacity = Convert.ToString(dr["MaxCapacity"]),
                                  ExtraPrice = Convert.ToString(dr["ExtraPrice"]),
                                  Price = Convert.ToString(dr["Price"]),
                                  LocationLink = Convert.ToString(dr["LocationLink"]),
                                  ThumbImage = Convert.ToString(dr["ThumbImage"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedIp = Convert.ToString(dr["AddedIP"]),
                                  AddedBy = Convert.ToString(dr["AddedBy"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllTheaterDetailsWithGuid", ex.Message);
        }
        return categories;
    }

    /// <summary>
    /// Retrieves all details of a Theater from the database based on the Theater's identifier.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="id">The identifier of the Theater.</param>
    /// <returns>A TheaterDetails object containing details of the specified Theater.</returns>

    public static TheaterDetails GetAllTheaterDetailsWithUrl(SqlConnection conSQ, string url)
    {
        var categories = new TheaterDetails();
        try
        {
            string query = "Select *,(Select AreaTitle from AreaMaster where AreaID=AreaMaster.ID) as AreaTitle,(Select StateTitle from StateMaster where stateID=StateMaster.ID) as StateTitle,(Select CityTitle from CityMaster where CityID=CityMaster.ID) as CityTitle from TheaterDetails where Status=@Status and TheaterUrl=@TheaterUrl";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                cmd.Parameters.AddWithValue("@TheaterUrl", SqlDbType.NVarChar).Value = url;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new TheaterDetails()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  AreaTitle = Convert.ToString(dr["AreaTitle"]),
                                  StateTitle = Convert.ToString(dr["StateTitle"]),
                                  CityTitle = Convert.ToString(dr["CityTitle"]),
                                  TheaterTitle = Convert.ToString(dr["TheaterTitle"]),
                                  TheaterGuid = Convert.ToString(dr["TheaterGuid"]),
                                  TheaterUrl = Convert.ToString(dr["TheaterUrl"]),
                                  StateID = Convert.ToString(dr["StateID"]),
                                  CityID = Convert.ToString(dr["CityID"]),
                                  AreaID = Convert.ToString(dr["AreaID"]),
                                  Pincode = Convert.ToString(dr["Pincode"]),
                                  Address = Convert.ToString(dr["Address"]),
                                  FullDesc = Convert.ToString(dr["FullDesc"]),
                                  ShortDesc = Convert.ToString(dr["ShortDesc"]),
                                  PageTitle = Convert.ToString(dr["PageTitle"]),
                                  MetaKeys = Convert.ToString(dr["MetaKeys"]),
                                  MetaDesc = Convert.ToString(dr["MetaDesc"]),
                                  MaxAllowed = Convert.ToString(dr["MaxAllowed"]),
                                  MaxCapacity = Convert.ToString(dr["MaxCapacity"]),
                                  ExtraPrice = Convert.ToString(dr["ExtraPrice"]),
                                  Price = Convert.ToString(dr["Price"]),
                                  LocationLink = Convert.ToString(dr["LocationLink"]),
                                  ThumbImage = Convert.ToString(dr["ThumbImage"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedIp = Convert.ToString(dr["AddedIP"]),
                                  AddedBy = Convert.ToString(dr["AddedBy"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAlTheaterDetailsWithId", ex.Message);
        }
        return categories;
    }
    public static TheaterDetails GetAllTheaterDetailsWithUrlAndAreaUrl(SqlConnection conSQ, string Turl,string Aurl)
    {
        var categories = new TheaterDetails();
        try
        {
            string query = "Select *,(Select AreaTitle from AreaMaster where AreaID=AreaMaster.ID) as AreaTitle,(Select StateTitle from StateMaster where stateID=StateMaster.ID) as StateTitle,(Select CityTitle from CityMaster where CityID=CityMaster.ID) as CityTitle from TheaterDetails where Status=@Status and TheaterUrl=@TheaterUrl and AreaID=(Select Top 1 Id from AreaMaster Where AreaUrl=@AreaUrl)";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                cmd.Parameters.AddWithValue("@TheaterUrl", SqlDbType.NVarChar).Value = Turl;
                cmd.Parameters.AddWithValue("@AreaUrl", SqlDbType.NVarChar).Value = Aurl;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new TheaterDetails()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  AreaTitle = Convert.ToString(dr["AreaTitle"]),
                                  StateTitle = Convert.ToString(dr["StateTitle"]),
                                  CityTitle = Convert.ToString(dr["CityTitle"]),
                                  TheaterTitle = Convert.ToString(dr["TheaterTitle"]),
                                  TheaterGuid = Convert.ToString(dr["TheaterGuid"]),
                                  TheaterUrl = Convert.ToString(dr["TheaterUrl"]),
                                  StateID = Convert.ToString(dr["StateID"]),
                                  CityID = Convert.ToString(dr["CityID"]),
                                  AreaID = Convert.ToString(dr["AreaID"]),
                                  Pincode = Convert.ToString(dr["Pincode"]),
                                  Address = Convert.ToString(dr["Address"]),
                                  FullDesc = Convert.ToString(dr["FullDesc"]),
                                  ShortDesc = Convert.ToString(dr["ShortDesc"]),
                                  PageTitle = Convert.ToString(dr["PageTitle"]),
                                  MetaKeys = Convert.ToString(dr["MetaKeys"]),
                                  MetaDesc = Convert.ToString(dr["MetaDesc"]),
                                  MaxAllowed = Convert.ToString(dr["MaxAllowed"]),
                                  MaxCapacity = Convert.ToString(dr["MaxCapacity"]),
                                  ExtraPrice = Convert.ToString(dr["ExtraPrice"]),
                                  Price = Convert.ToString(dr["Price"]),
                                  LocationLink = Convert.ToString(dr["LocationLink"]),
                                  ThumbImage = Convert.ToString(dr["ThumbImage"]),
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedIp = Convert.ToString(dr["AddedIP"]),
                                  AddedBy = Convert.ToString(dr["AddedBy"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAlTheaterDetailsWithId", ex.Message);
        }
        return categories;
    }

    public static DataTable GetTheaterDetailsWithAreaId(SqlConnection conSQ, string areaId)
    {
        var dt = new DataTable();
        try
        {
            string query = "Select (Select Top 1 TheaterUrl from TheaterDetails Where AreaID=@AreaID) as TheaterUrl,MIN(TRy_Convert(int,Price)) as minprice,MAX(TRY_CONVERT(int,MaxCapacity)) maxcap,Count(ID) as cnt from TheaterDetails Where AreaID=@AreaID";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@AreaID", SqlDbType.NVarChar).Value = areaId;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                return dt;
            }

        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetTheaterDetailsWithAreaId", ex.Message);

        }
        return dt;
    }


    public static List<TheaterDetails> GetAllTheaterDetailsWithAreaID(SqlConnection conSQ, string areaId)
    {
        var List = new List<TheaterDetails>();
        try
        {
            string query = "Select *,(Select StateTitle from StateMaster where stateID=StateMaster.ID) as StateTitle,(Select AreaTitle from AreaMaster where AreaID=AreaMaster.ID) as AreaTitle ,(Select CityTitle from CityMaster where CityID=CityMaster.ID) as CityTitle,(Select Count(ID) from TheaterTiming Where TheaterID=TheaterGuid and TheaterTiming.Status !='Deleted') as TimingCount,(Select Count(ID) from TheaterImages Where TheaterID=TheaterGuid and TheaterImages.Status !='Deleted') as GalleryCount from TheaterDetails where Status=@Status and AreaID=@AreaID Order by Id";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                cmd.Parameters.AddWithValue("@AreaID", SqlDbType.NVarChar).Value = areaId;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                List = (from DataRow dr in dt.Rows
                        select new TheaterDetails()
                        {
                            Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                            AreaTitle = Convert.ToString(dr["AreaTitle"]),
                            StateTitle = Convert.ToString(dr["StateTitle"]),
                            CityTitle = Convert.ToString(dr["CityTitle"]),
                            TheaterTitle = Convert.ToString(dr["TheaterTitle"]),
                            GalleryCount = Convert.ToString(dr["GalleryCount"]),
                            TimingCount = Convert.ToString(dr["TimingCount"]),
                            TheaterGuid = Convert.ToString(dr["TheaterGuid"]),
                            TheaterUrl = Convert.ToString(dr["TheaterUrl"]),
                            StateID = Convert.ToString(dr["StateID"]),
                            CityID = Convert.ToString(dr["CityID"]),
                            AreaID = Convert.ToString(dr["AreaID"]),
                            Pincode = Convert.ToString(dr["Pincode"]),
                            Address = Convert.ToString(dr["Address"]),
                            FullDesc = Convert.ToString(dr["FullDesc"]),
                            ShortDesc = Convert.ToString(dr["ShortDesc"]),
                            PageTitle = Convert.ToString(dr["PageTitle"]),
                            MetaKeys = Convert.ToString(dr["MetaKeys"]),
                            MetaDesc = Convert.ToString(dr["MetaDesc"]),
                            MaxAllowed = Convert.ToString(dr["MaxAllowed"]),
                            MaxCapacity = Convert.ToString(dr["MaxCapacity"]),
                            ExtraPrice = Convert.ToString(dr["ExtraPrice"]),
                            Price = Convert.ToString(dr["Price"]),
                            LocationLink = Convert.ToString(dr["LocationLink"]),
                            ThumbImage = Convert.ToString(dr["ThumbImage"]),
                            AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                            AddedIp = Convert.ToString(dr["AddedIP"]),
                            AddedBy = Convert.ToString(dr["AddedBy"]),
                            Status = Convert.ToString(dr["Status"])
                        }).ToList();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAlTheaterDetailsWithId", ex.Message);

        }
        return List;
    }
    /// <summary>
    /// Deletes a Theater from the database.
    /// </summary>
    /// <param name="conGV">The SQL connection object.</param>
    /// <param name="TheaterDetails">A TheaterDetails object containing details of the Area to be deleted.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>

    public static int DeleteTheater(SqlConnection conGV, TheaterDetails Theater)
    {
        int result = 0;
        try
        {
            string query = "Update TheaterDetails Set Status=@Status, AddedOn=@AddedOn, AddedIp=@AddedIp Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = Theater.Id;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = Theater.AddedOn;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = Theater.AddedIp;
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
    /// Updates the details of a Area in the database.
    /// </summary>
    /// <param name="conGV">The SQL connection object.</param>
    /// <param name="Area">A TheaterDetails object containing updated details of the Area.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>

    public static int UpdateTheater(SqlConnection conGV, TheaterDetails Theater)
    {
        int result = 0;
        try
        {
            string query = @"UPDATE TheaterDetails SET 
                            AreaID = @AreaID,
                            CityID = @CityID,
                            StateID = @StateID,
                            TheaterTitle = @TheaterTitle,
                            TheaterUrl = @TheaterUrl,
                            Pincode = @Pincode,
                            Address = @Address,
                            FullDesc = @FullDesc,
                            ShortDesc = @ShortDesc,
                            PageTitle = @PageTitle,
                            MetaKeys = @MetaKeys,
                            MetaDesc = @MetaDesc,
                            MaxAllowed = @MaxAllowed,
                            MaxCapacity = @MaxCapacity,
                            Price = @Price,
                            ExtraPrice = @ExtraPrice,
                            ThumbImage = @ThumbImage,
                            LocationLink = @LocationLink,
                            AddedOn = @AddedOn,
                            AddedIp = @AddedIp,
                            AddedBy = @AddedBy,
                            Status = @Status
                        WHERE Id = @Id";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Id", Theater.Id);
                cmd.Parameters.AddWithValue("@AreaID", Theater.AreaID);
                cmd.Parameters.AddWithValue("@CityID", Theater.CityID);
                cmd.Parameters.AddWithValue("@StateID", Theater.StateID);
                cmd.Parameters.AddWithValue("@TheaterTitle", Theater.TheaterTitle);
                cmd.Parameters.AddWithValue("@TheaterUrl", Theater.TheaterUrl);
                cmd.Parameters.AddWithValue("@Pincode", Theater.Pincode);
                cmd.Parameters.AddWithValue("@Address", Theater.Address);
                cmd.Parameters.AddWithValue("@FullDesc", Theater.FullDesc);
                cmd.Parameters.AddWithValue("@ShortDesc", Theater.ShortDesc);
                cmd.Parameters.AddWithValue("@PageTitle", Theater.PageTitle);
                cmd.Parameters.AddWithValue("@MetaKeys", Theater.MetaKeys);
                cmd.Parameters.AddWithValue("@MetaDesc", Theater.MetaDesc);
                cmd.Parameters.AddWithValue("@MaxAllowed", Theater.MaxAllowed);
                cmd.Parameters.AddWithValue("@MaxCapacity", Theater.MaxCapacity);
                cmd.Parameters.AddWithValue("@Price", Theater.Price);
                cmd.Parameters.AddWithValue("@ExtraPrice", Theater.ExtraPrice);
                cmd.Parameters.AddWithValue("@ThumbImage", Theater.ThumbImage);
                cmd.Parameters.AddWithValue("@LocationLink", Theater.LocationLink);
                cmd.Parameters.AddWithValue("@AddedOn", Theater.AddedOn);
                cmd.Parameters.AddWithValue("@AddedIp", Theater.AddedIp);
                cmd.Parameters.AddWithValue("@AddedBy", Theater.AddedBy);
                cmd.Parameters.AddWithValue("@Status", Theater.Status);

                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateTheater", ex.Message);
        }
        return result;
    }
    /// <summary>
    /// Adds a new Theater to the database.
    /// </summary>
    /// <param name="conSQ">The SQL connection object.</param>
    /// <param name="Theater">A TheaterDetails object containing details of the Theater to be added.</param>
    /// <returns>An integer representing the number of rows affected in the database.</returns>
    public static int AddTheater(SqlConnection conSQ, TheaterDetails Theater)
    {
        int result = 0;
        try
        {
            string query = @"INSERT INTO TheaterDetails (
                            AreaID, CityID, StateID, TheaterTitle,TheaterGuid, TheaterUrl, Pincode,Address, FullDesc, ShortDesc, PageTitle, MetaKeys, MetaDesc, 
                            MaxAllowed, MaxCapacity, Price, ExtraPrice, ThumbImage, LocationLink, AddedOn, AddedIp, AddedBy, Status) 
                        VALUES (
                            @AreaID, @CityID, @StateID, @TheaterTitle,@TheaterGuid, @TheaterUrl, @Pincode, @Address, @FullDesc, @ShortDesc, @PageTitle, @MetaKeys, @MetaDesc, 
                            @MaxAllowed, @MaxCapacity, @Price, @ExtraPrice, @ThumbImage, @LocationLink, @AddedOn, @AddedIp, @AddedBy, @Status)";
            using (SqlCommand cmd = new SqlCommand(query, conSQ))
            {
                cmd.Parameters.AddWithValue("@Id", Theater.Id);
                cmd.Parameters.AddWithValue("@AreaID", Theater.AreaID);
                cmd.Parameters.AddWithValue("@CityID", Theater.CityID);
                cmd.Parameters.AddWithValue("@StateID", Theater.StateID);
                cmd.Parameters.AddWithValue("@TheaterTitle", Theater.TheaterTitle);
                cmd.Parameters.AddWithValue("@TheaterGuid", Theater.TheaterGuid);
                cmd.Parameters.AddWithValue("@TheaterUrl", Theater.TheaterUrl);
                cmd.Parameters.AddWithValue("@Pincode", Theater.Pincode);
                cmd.Parameters.AddWithValue("@Address", Theater.Address);
                cmd.Parameters.AddWithValue("@FullDesc", Theater.FullDesc);
                cmd.Parameters.AddWithValue("@ShortDesc", Theater.ShortDesc);
                cmd.Parameters.AddWithValue("@PageTitle", Theater.PageTitle);
                cmd.Parameters.AddWithValue("@MetaKeys", Theater.MetaKeys);
                cmd.Parameters.AddWithValue("@MetaDesc", Theater.MetaDesc);
                cmd.Parameters.AddWithValue("@MaxAllowed", Theater.MaxAllowed);
                cmd.Parameters.AddWithValue("@MaxCapacity", Theater.MaxCapacity);
                cmd.Parameters.AddWithValue("@Price", Theater.Price);
                cmd.Parameters.AddWithValue("@ExtraPrice", Theater.ExtraPrice);
                cmd.Parameters.AddWithValue("@ThumbImage", Theater.ThumbImage);
                cmd.Parameters.AddWithValue("@LocationLink", Theater.LocationLink);
                cmd.Parameters.AddWithValue("@AddedOn", Theater.AddedOn);
                cmd.Parameters.AddWithValue("@AddedIp", Theater.AddedIp);
                cmd.Parameters.AddWithValue("@AddedBy", Theater.AddedBy);
                cmd.Parameters.AddWithValue("@Status", Theater.Status);
                conSQ.Open();
                result = Convert.ToInt32(cmd.ExecuteNonQuery());
                conSQ.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "AddTheater", ex.Message);
        }
        return result;
    }
}