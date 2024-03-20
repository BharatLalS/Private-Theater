using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TheaterImages
/// </summary>
public class TheaterImages
{
    public int id { get; set; }
    public string TheaterID { get; set; }
    public string ImageUrl { get; set; }
    public DateTime AddedOn { get; set; }
    public string AddedIp { get; set; }
    public string AddedBy { get; set; }
    public string Status { get; set; }

    //Extra 
    public string TheaterTitle { get; set; }
}