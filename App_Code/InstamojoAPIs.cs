using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;

/// <summary>
/// Summary description for InstamojoAPIs
/// </summary>

public class InstamojoAPIs
{
    public InstamojoAPIs()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static string GetInstamojoToken()
    {
        string token = "";
        try
        {

            string Insta_client_id = ConfigurationManager.AppSettings["InstaClient"],
                  Insta_client_secret = ConfigurationManager.AppSettings["InstaSecret"],
                  Insta_Auth_Endpoint = ConfigurationManager.AppSettings["InstaType"] == "sandbox" ? "https://test.instamojo.com" : "https://www.instamojo.com";

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var client = new RestClient(Insta_Auth_Endpoint);
            var request = new RestRequest("/oauth2/token/", Method.Post);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("grant_type", "client_credentials");
            //request.AddParameter("client_id", "t30u1egdEyLYYfU3tTDXXsyy0zn9bJgUOEB6IOew");
            request.AddParameter("client_id", Insta_client_id);
            //request.AddParameter("client_secret", "UlwqhQSrFqalq5NQjAJeGUPFtrYKnOxR9BGtlSSvr6DTXklpwRIn0cmjEmBt6GCNAsPbMKqDsTTBycxZoftozTXO5x52k821nryZspTSLs6MzeDCi15LYvbptxFtjwTs");
            request.AddParameter("client_secret", Insta_client_secret);
            var response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                token_reposnse myDeserializedClass = JsonConvert.DeserializeObject<token_reposnse>(response.Content);
                if (myDeserializedClass != null)
                {
                    token = myDeserializedClass.access_token;
                }
            }

        }
        catch (Exception ex)
        {

        }
        return token;
    }

    public static InstamojoPaymentRequestResponse CreatePaymentRequest(InstamojoPaymentRequestRequest pRequest, string token)
    {
        InstamojoPaymentRequestResponse r_response = new InstamojoPaymentRequestResponse();
        try
        {
            string Insta_Endpoint = ConfigurationManager.AppSettings["InstaType"] == "sandbox" ? "https://test.instamojo.com" : "https://www.instamojo.com";

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var client = new RestClient(Insta_Endpoint);
            var request = new RestRequest("/api/1.1/payment_requests/", Method.Post);
            request.AddHeader("Authorization", "Bearer " + token);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("allow_repeated_payments", "false");
            request.AddParameter("send_email", "false");
            request.AddParameter("amount", pRequest.amount);
            request.AddParameter("purpose", pRequest.purpose);
            request.AddParameter("buyer_name", pRequest.buyer_name);
            request.AddParameter("email", pRequest.email);
            request.AddParameter("phone", pRequest.phone);
            request.AddParameter("redirect_url", pRequest.redirect_url);
            var response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                r_response = JsonConvert.DeserializeObject<InstamojoPaymentRequestResponse>(response.Content);
            }
        }
        catch (Exception ex)
        {

        }
        return r_response;
    }
    public static InstamojoPaymentRequestResponse GetPaymentRequestDetails(string request_id, string token)
    {
        InstamojoPaymentRequestResponse r_response = new InstamojoPaymentRequestResponse();
        try
        {

            string Insta_Endpoint = ConfigurationManager.AppSettings["InstaType"] == "sandbox" ? "https://test.instamojo.com" : "https://www.instamojo.com";
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var client = new RestClient(Insta_Endpoint);
            var request = new RestRequest("/v2/payment_requests/" + request_id, Method.Get);
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", "Bearer " + token);
            var response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                r_response = JsonConvert.DeserializeObject<InstamojoPaymentRequestResponse>(response.Content);
            }
        }
        catch (Exception ex)
        {

        }
        return r_response;
    }

    public static InstamojoPaymentRequestResponse CreatePaymentRequest1_1(InstamojoPaymentRequestRequest pRequest)
    {
        InstamojoPaymentRequestResponse r_response = new InstamojoPaymentRequestResponse();

        try
        {
            string Insta_Endpoint = ConfigurationManager.AppSettings["InstaType"] == "sandbox" ? "https://test.instamojo.com" : "https://www.instamojo.com";
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var client = new RestClient(Insta_Endpoint);
            var request = new RestRequest("/api/1.1/payment-requests/", Method.Post);
            request.AddHeader("X-Api-Key", ConfigurationManager.AppSettings["InstaAPIKey"]);
            request.AddHeader("X-Auth-Token", ConfigurationManager.AppSettings["InstaAuth"]);
            request.AlwaysMultipartFormData = true;
            request.AddParameter("amount", pRequest.amount);
            request.AddParameter("purpose", pRequest.purpose);
            request.AddParameter("buyer_name", pRequest.buyer_name);
            request.AddParameter("email", pRequest.email);
            request.AddParameter("phone", pRequest.phone);
            request.AddParameter("redirect_url", pRequest.redirect_url);
            //request.AddParameter("webhook", pRequest.webhook_url);
            request.AddParameter("allow_repeated_payments", "false");
            request.AddParameter("send_email", pRequest.send_email);
            request.AddParameter("send_sms", pRequest.send_sms);
            var response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                r_response = JsonConvert.DeserializeObject<InstamojoPaymentRequestResponse>(response.Content);
            }
            else
            {
                ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CreatePaymentRequest1_1", response.Content + "_____" + response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CreatePaymentRequest1_1", ex.Message);
        }
        return r_response;

    }

    public static InstamojoPaymentRequestResponse GetPaymentRequesDetailst1_1(string payment_request_id)
    {
        InstamojoPaymentRequestResponse r_response = new InstamojoPaymentRequestResponse();

        try
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string Insta_Endpoint = ConfigurationManager.AppSettings["InstaType"] == "sandbox" ? "https://test.instamojo.com" : "https://www.instamojo.com";

            var client = new RestClient(Insta_Endpoint);
            var request = new RestRequest("/api/1.1/payment-requests/" + payment_request_id, Method.Get);
            request.AddHeader("X-Api-Key", ConfigurationManager.AppSettings["InstaAPIKey"]);
            request.AddHeader("X-Auth-Token", ConfigurationManager.AppSettings["InstaAuth"]);
            var response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                r_response = JsonConvert.DeserializeObject<InstamojoPaymentRequestResponse>(response.Content);
            }
            else
            {
                ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CreatePaymentRequest1_1", response.Content + "_____" + response.StatusCode);
            }
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "CreatePaymentRequest1_1", ex.Message);
        }
        return r_response;

    }

}


public class token_reposnse
{
    public string access_token { get; set; }
    public int expires_in { get; set; }
    public string scope { get; set; }
    public string token_type { get; set; }
    public string error { get; set; }

}


// 
public class InstamojoPaymentRequestResponse
{
    public bool success { get; set; }
    public MojoPaymentRequest payment_request { get; set; }
}

public class MojoPaymentRequest
{
    public string id { get; set; }
    public string phone { get; set; }
    public string email { get; set; }
    public string buyer_name { get; set; }
    public string amount { get; set; }
    public string purpose { get; set; }
    public object expires_at { get; set; }
    public string status { get; set; }
    public bool send_sms { get; set; }
    public bool send_email { get; set; }
    public string sms_status { get; set; }
    public string email_status { get; set; }
    public object shorturl { get; set; }
    public string longurl { get; set; }
    public string redirect_url { get; set; }
    public string webhook { get; set; }
    public List<MojoPayment> payments { get; set; }
    public bool allow_repeated_payments { get; set; }
    public DateTime created_at { get; set; }
    public DateTime modified_at { get; set; }
}

public class MojoPayment
{
    public string payment_id { get; set; }
    public string status { get; set; }
    public string currency { get; set; }
    public string amount { get; set; }
    public string buyer_name { get; set; }
    public string buyer_phone { get; set; }
    public string buyer_email { get; set; }
    public object shipping_address { get; set; }
    public object shipping_city { get; set; }
    public object shipping_state { get; set; }
    public object shipping_zip { get; set; }
    public object shipping_country { get; set; }
    public int quantity { get; set; }
    public string unit_price { get; set; }
    public string fees { get; set; }
    public List<object> variants { get; set; }
    public dynamic custom_fields { get; set; }
    public string affiliate_commission { get; set; }
    public string payment_request { get; set; }
    public string instrument_type { get; set; }
    public string billing_instrument { get; set; }
    public string tax_invoice_id { get; set; }
    public object failure { get; set; }
    public object payout { get; set; }
    public DateTime created_at { get; set; }
}



public class InstamojoPaymentRequestRequest
{
    public string allow_repeated_payments { get; set; }
    public string send_email { get; set; }
    public string send_sms { get; set; }
    public string amount { get; set; }
    public string purpose { get; set; }
    public string buyer_name { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
    public string redirect_url { get; set; }
    public string webhook_url { get; set; }

}
