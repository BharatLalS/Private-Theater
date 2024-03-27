using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Drawing;

/// <summary>
/// Summary description for TestimonialDetails
/// </summary>
public class TestimonialDetails
{
    #region Testimonial Property
    public int Id { get; set; }
    public string PostedBy { get; set; }
    public string Message { get; set; }
    public string Designation { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedBy { get; set; }
    public string AddedIp { get; set; }
    public string Status { get; set; }
    #endregion

    #region Testimonial region

    /// <summary>
    /// Get all Testimonial from db 
    /// </summary>
    /// <param name="conGV">DB connection</param>
    /// <returns>All list</returns>
    public static List<TestimonialDetails> GetTestimonialDetails(SqlConnection conGV)
    {
        List<TestimonialDetails> zips = new List<TestimonialDetails>();
        try
        {
            string query = "Select *,(Select UserName from CreateUser Where UserGuid=TestimonialDetails.AddedBy) as UpdatedBy from TestimonialDetails where Status !=@Status  Order by Id Desc ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Deleted";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                zips = (from DataRow dr in dt.Rows
                        select new TestimonialDetails()
                        {
                            Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                            PostedBy = Convert.ToString(dr["PostedBy"]),
                            Message = Convert.ToString(dr["Message"]),
                            Designation = Convert.ToString(dr["Designation"]),
                            AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                            AddedBy = Convert.ToString(dr["UpdatedBy"]),
                            AddedIp = Convert.ToString(dr["AddedIp"]),
                            Status = Convert.ToString(dr["Status"])
                        }).ToList();

            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetTestimonialDetails", ex.Message);
        }
        return zips;
    }

    /// <summary>
    /// Get all Testimonial from db by id 
    /// </summary>
    /// <param name="conDT">DB connection</param>
    /// <param name="id">id to identify testimonial</param>
    /// <returns></returns>
    public static TestimonialDetails GetAllTestimonialDetailsWithId(SqlConnection conDT, int id)
    {
        TestimonialDetails categories = new TestimonialDetails();
        try
        {
            string query = "Select * from TestimonialDetails where Status=@Status and Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conDT))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                categories = (from DataRow dr in dt.Rows
                              select new TestimonialDetails()
                              {
                                  Id = Convert.ToInt32(Convert.ToString(dr["Id"])),
                                  PostedBy = Convert.ToString(dr["PostedBy"]),
                                  Message = Convert.ToString(dr["Message"]),
                                  Designation = Convert.ToString(dr["Designation"]),
                                  
                                  AddedOn = Convert.ToDateTime(Convert.ToString(dr["AddedOn"])),
                                  AddedBy = Convert.ToString(dr["AddedBy"]),
                                  AddedIp = Convert.ToString(dr["AddedIP"]),
                                  Status = Convert.ToString(dr["Status"])
                              }).FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "GetAllBlogDetailsWithId", ex.Message);
        }
        return categories;
    }

    /// <summary>
    /// Insert an Testimonial to database
    /// </summary>
    /// <param PostedBy="conGV">DB Connection</param>
    /// <param PostedBy="cat">Testimonial properties</param>
    /// <returns>No of rows excuted</returns>
    public static int InsertTestimonial(SqlConnection conGV, TestimonialDetails con)
    {
        int result = 0;

        try
        {
            string query = "Insert Into TestimonialDetails (PostedBy,Message,Designation,AddedOn,AddedBy, AddedIp,Status) values(@PostedBy,@Message,@Designation,@AddedOn,@AddedBy, @AddedIp,@Status) ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@PostedBy", SqlDbType.NVarChar).Value = con.PostedBy;
                cmd.Parameters.AddWithValue("@Message", SqlDbType.NVarChar).Value = con.Message;
                cmd.Parameters.AddWithValue("@Designation", SqlDbType.NVarChar).Value = con.Designation;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = con.AddedOn;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = con.AddedIp;
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = con.AddedBy;
                cmd.Parameters.AddWithValue("@Status", SqlDbType.NVarChar).Value = "Active";
                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "InsertTestimonial", ex.Message);
        }
        return result;
    }


    /// <summary>
    /// Update an specific Testimonial Details
    /// </summary>
    /// <param name="conGV">DB Connection</param>
    /// <param name="cat"> Testimonial Details  properties</param>
    /// <returns>No of rows executed</returns>
    public static int UpdateTestimonialDetails(SqlConnection conGV, TestimonialDetails cat)
    {
        int result = 0;
        try
        {
            string query = "Update TestimonialDetails Set PostedBy=@PostedBy,Message=@Message,Designation=@Designation,AddedOn=@AddedOn,AddedIp=@AddedIp,AddedBy=@AddedBy Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Value = cat.Id;
                cmd.Parameters.AddWithValue("@PostedBy", SqlDbType.NVarChar).Value = cat.PostedBy;
                cmd.Parameters.AddWithValue("@Message", SqlDbType.NVarChar).Value = cat.Message;
                cmd.Parameters.AddWithValue("@Designation", SqlDbType.NVarChar).Value = cat.Designation;
                cmd.Parameters.AddWithValue("@AddedOn", SqlDbType.NVarChar).Value = cat.AddedOn;
                cmd.Parameters.AddWithValue("@AddedIp", SqlDbType.NVarChar).Value = cat.AddedIp;
                cmd.Parameters.AddWithValue("@AddedBy", SqlDbType.NVarChar).Value = cat.AddedBy;
                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "UpdateTestimonialDetails", ex.Message);
        }
        return result;
    }
    /// <summary>
    /// Delete a specific Testimonial (Update Testimonial as delete)
    /// </summary>
    /// <param PostedBy="conGV">DB Connection</param>
    /// <param PostedBy="cat">zip properties</param>
    /// <returns>No of rows executed</returns>
    public static int DeleteTestimonial(SqlConnection conGV, TestimonialDetails con)
    {
        int result = 0;

        try
        {
            string query = "Delete from TestimonialDetails Where Id=@Id ";
            using (SqlCommand cmd = new SqlCommand(query, conGV))
            {
                cmd.Parameters.AddWithValue("@Id", SqlDbType.NVarChar).Value = con.Id;
                conGV.Open();
                result = cmd.ExecuteNonQuery();
                conGV.Close();
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "DeleteTestimonial", ex.Message);
        }
        return result;
    }
    #endregion
}