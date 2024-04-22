using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Net;
using System.IO;
using System.Threading.Tasks;

public class Emails
{
    public static async Task<int> SendPasswordRestLink(string name, string emails, string link)
    {
        try
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(emails);
            mail.From = new MailAddress(ConfigurationManager.AppSettings["from"], ConfigurationManager.AppSettings["fromName"]);
            mail.Subject = "Binge Party Admin  Reset Password";
            mail.Body = @"<!DOCTYPE HTML PUBLIC '-//W3C//DTD XHTML 1.0 Strict//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd'>
<html xmlns='http://www.w3.org/1999/xhtml'>
<head>
    <meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />
    <meta name='viewport' content='width=device-width, initial-scale=1.0' />
    <meta http-equiv='X-UA-Compatible' content='IE=edge,chrome=1' />
    <meta name='format-detection' content='telephone=no' />
    <title>Binge Party </title>
    <link rel='shortcut icon' href='https://www.Bingeparty/images/logo.png' />
    <link href='https://fonts.googleapis.com/css?family=Lato:100,100i,300,300i,400,400i,700,700i,900,900i&display=swap' rel='stylesheet' />
    <style type='text/css'>
        html {
            background-color: #FFF;
            margin: 0;
            font-family: 'Lato', sans-serif;
            padding: 0;
        }

        /*@import url('https://fonts.googleapis.com/css?family=Roboto');*/

        body, #bodyTable, #bodyCell, #bodyCell {
            height: 100% !important;
            margin: 0;
            padding: 0;
            width: 100% !important;
        }

        table {
            border-collapse: collapse;
        }

            table[id=bodyTable] {
                width: 100% !important;
                margin: auto;
                max-width: 500px !important;
                color: #212121;
                font-weight: normal;
            }

        img, a img {
            border: 0;
            outline: none;
            text-decoration: none;
            height: auto;
            line-height: 100%;
        }

        /*a {
            text-decoration: none !important;
            border-bottom: 1px solid;
        }*/

        h1, h2, h3, h4, h5, h6 {
            color: #5F5F5F;
            font-weight: normal;
            font-size: 20px;
            line-height: 125%;
            text-align: Left;
            letter-spacing: normal;
            margin-top: 0;
            margin-right: 0;
            margin-bottom: 10px;
            margin-left: 0;
            padding-top: 0;
            padding-bottom: 0;
            padding-left: 0;
            padding-right: 0;
        }

        .ReadMsgBody {
            width: 100%;
        }

        .ExternalClass {
            width: 100%;
        }

            .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div {
                line-height: 100%;
            }

        table, td {
            mso-table-lspace: 0pt;
            mso-table-rspace: 0pt;
        }

        #outlook a {
            padding: 0;
        }

        img {
            -ms-interpolation-mode: bicubic;
            display: block;
            outline: none;
            text-decoration: none;
        }

        body, table, td, p, a, li, blockquote {
            -ms-text-size-adjust: 100%;
            -webkit-text-size-adjust: 100%;
            font-weight: 500 !important;
        }

        .ExternalClass td[class='ecxflexibleContainerBox'] h3 {
            padding-top: 10px !important;
        }

        h1 {
            display: block;
            font-size: 26px;
            font-style: normal;
            font-weight: normal;
            line-height: 100%;
        }

        h2 {
            display: block;
            font-size: 20px;
            font-style: normal;
            font-weight: normal;
            line-height: 120%;
        }

        h3 {
            display: block;
            font-size: 17px;
            font-style: normal;
            font-weight: normal;
            line-height: 110%;
        }

        h4 {
            display: block;
            font-size: 18px;
            font-style: italic;
            font-weight: normal;
            line-height: 100%;
        }

        .flexibleImage {
            height: auto;
        }

        .linkRemoveBorder {
            border-bottom: 0 !important;
        }

        table[class=flexibleContainerCellDivider] {
            padding-bottom: 0 !important;
            padding-top: 0 !important;
        }

        body, #bodyTable {
            background-color: #E1E1E1;
        }

        #emailHeader {
            background-color: #fff;
        }

        #emailBody {
            background-color: #FFFFFF;
        }

        #emailFooter {
            background-color: #E1E1E1;
        }

        .nestedContainer {
            background-color: #F8F8F8;
            border: 1px solid #CCCCCC;
        }

        .emailButton {
            background-color: #205478;
            border-collapse: separate;
        }

        .buttonContent {
            color: #FFFFFF;
            font-family: Helvetica;
            font-size: 18px;
            font-weight: bold;
            line-height: 100%;
            padding: 15px;
            text-align: center;
        }

            .buttonContent a {
                color: #FFFFFF;
                display: block;
                text-decoration: none !important;
                border: 0 !important;
            }

        .emailCalendar {
            background-color: #FFFFFF;
            border: 1px solid #CCCCCC;
        }

        .emailCalendarMonth {
            background-color: #205478;
            color: #FFFFFF;
            font-size: 16px;
            font-weight: bold;
            padding-top: 10px;
            padding-bottom: 10px;
            text-align: center;
        }

        .emailCalendarDay {
            color: #205478;
            font-size: 60px;
            font-weight: bold;
            line-height: 100%;
            padding-top: 20px;
            padding-bottom: 20px;
            text-align: center;
        }

        .imageContentText {
            margin-top: 10px;
            line-height: 0;
        }

            .imageContentText a {
                line-height: 0;
            }

        #invisibleIntroduction {
            display: none !important;
        }

        span[class=ios-color-hack] a {
            color: #275100 !important;
            text-decoration: none !important;
        }

        span[class=ios-color-hack2] a {
            color: #205478 !important;
            text-decoration: none !important;
        }

        span[class=ios-color-hack3] a {
            color: #8B8B8B !important;
            text-decoration: none !important;
        }

        .a[href^='tel'], a[href^='sms'] {
            text-decoration: none !important;
            color: #606060 !important;
            pointer-events: none !important;
            cursor: default !important;
        }

        .mobile_link a[href^='tel'], .mobile_link a[href^='sms'] {
            text-decoration: none !important;
            color: #606060 !important;
            pointer-events: auto !important;
            cursor: default !important;
        }

        @media only screen and (max-width: 480px) {
            body {
                width: 100% !important;
                min-width: 100% !important;
            }

            table[id='emailHeader'],
            table[id='emailBody'],
            table[id='emailFooter'],
            table[class='flexibleContainer'],
            td[class='flexibleContainerCell'] {
                width: 100% !important;
            }

            td[class='flexibleContainerBox'], td[class='flexibleContainerBox'] table {
                display: block;
                width: 100%;
                text-align: left;
            }

            td[class='imageContent'] img {
                height: auto !important;
                width: 100% !important;
                max-width: 100% !important;
            }

            img[class='flexibleImage'] {
                height: auto !important;
                width: 100% !important;
                max-width: 100% !important;
            }

            img[class='flexibleImageSmall'] {
                height: auto !important;
                width: auto !important;
            }

            table[class='flexibleContainerBoxNext'] {
                padding-top: 10px !important;
            }

            table[class='emailButton'] {
                width: 100% !important;
            }

            td[class='buttonContent'] {
                padding: 0 !important;
            }

                td[class='buttonContent'] a {
                    padding: 15px !important;
                }
        }

        @media only screen and (-webkit-device-pixel-ratio:.75) {
        }

        @media only screen and (-webkit-device-pixel-ratio:1) {
        }

        @media only screen and (-webkit-device-pixel-ratio:1.5) {
        }

        @media only screen and (min-device-width : 320px) and (max-device-width:568px) {
        }

        .blink_text {
            -webkit-animation-name: blinker;
            -webkit-animation-duration: 2s;
            -webkit-animation-timing-function: linear;
            -webkit-animation-iteration-count: infinite;
            -moz-animation-name: blinker;
            -moz-animation-duration: 2s;
            -moz-animation-timing-function: linear;
            -moz-animation-iteration-count: infinite;
            animation-name: blinker;
            animation-duration: 2s;
            animation-timing-function: linear;
            animation-iteration-count: infinite;
            color: white;
        }

        @-moz-keyframes blinker {
            0% {
                opacity: 1.0;
            }

            50% {
                opacity: 0.0;
            }

            100% {
                opacity: 1.0;
            }
        }

        @-webkit-keyframes blinker {
            0% {
                opacity: 1.0;
            }

            50% {
                opacity: 0.0;
            }

            100% {
                opacity: 1.0;
            }
        }

        @keyframes blinker {
            0% {
                opacity: 1.0;
            }

            50% {
                opacity: 0.0;
            }

            100% {
                opacity: 1.0;
            }
        }
    </style>
</head>
<body bgcolor='#E1E1E1' leftmargin='0' marginwidth='0' topmargin='0' marginheight='0' offset='0'>
    <center style='background-color:#E1E1E1;'>
        <table border='0' cellpadding='0' cellspacing='0' height='100%' width='100%' id='bodyTable' style=' table-layout: fixed; max-width:100% !important;width: 100% !important;min-width: 100% !important;'>
            <tr>
                <td align='center' valign='top' id='bodyCell'>

                    <table bgcolor='#FFFFFF' border='0' cellpadding='0' cellspacing='0' width='700' id='emailBody' style='margin-top:20px;margin-bottom:20px;'>
                        <tr>
                            <td align='center' valign='top' style=''>
                                <table border='0' cellpadding='0' cellspacing='0' width='100%' bgcolor='#fff'>
                                    <tr>
                                        <td align='center' valign='top'>
                                            <table border='0' cellpadding='0' cellspacing='0' width='700' class='flexibleContainer'>
                                                <tr>
                                                    <td align='center' valign='top' width='700' class='flexibleContainerCell'>
                                                        <table border='0' cellpadding='30' cellspacing='0' width='100%'>
                                                            <tr>
                                                                <td align='left' valign='top' style='padding:20px;background:#fff'>
                                                                    <table border='0' cellpadding='0' cellspacing='0' style='float:left;width: 100%;margin-right:5%'>
                                                                        <tr>
                                                                            <td align='left' valign='top' width='100%' style='vertical-align: middle;' class='flexibleContainerCell'>
                                                                                <center>
                                                                                    <img style='width:250px;margin-bottom:0px;' src='" + ConfigurationManager.AppSettings["domain"] + @"/Img/websiteLogos/logo.png' />
                                                                                </center>
                                                                            </td>
                                                                        </tr>
                                                                    </table>

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align='left' valign='top' style='padding:0px;background:#5c2d9d40'>
                                                                    <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                                                        <tr>
                                                                            <td align='left' valign='top' width='100%' class='flexibleContainerCell'>
                                                                                <p style='font-size:22px;line-height:32px!important;text-align:center;color:white;margin-top:0px;background:#5c2d9d;padding:10px;'>PASSWORD RESET</p>
                                                                                <p style='font-size:20px;line-height:28px!important;text-align:center;color:#000;font-weight:bold!important'>Request for password reset</p>
                                                                                <p style='font-size:15px;color:#000;line-height:22px!important;margin-bottom:5px;text-align:center;padding:0px 20px !important'>Hello " + name + @". We have just received a request to reset your password for the Binge Party account.<br><br></p>


                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align='left' valign='top' style='padding:20px 60px;background:#fff;text-align: center;'>
                                                                    <p style='font-size: 14px;line-height:22px!important;text-align:center;margin-top:0px;color:#573e40;margin-bottom:30px;'>If you have made this request, please click on the following link to reset your password</p>
                                                                    <a href='" + link + @"' style='padding: 10px 30px;background: #5c2d9d;text-decoration: none;color: #fff;font-size: 20px;'>Reset Password</a>
                                                                    <p style='font-size: 14px;line-height:22px!important;text-align:center;margin-top: 20px;color:#573e40;margin-bottom:30px;'>
                                                                        If clicking the button does not work, copy the URL below and paste it into your browser:<br> <a href='" + link + @"' target='_blank'>" + link + @"</a>
                                                                        <br><br>If you have not requested a password reset, please ignore this email.<br>
                                                                        Your password remains unchanged.
                                                                    </p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align='left' valign='top' style='padding:20px 20px;background:#5c2d9d40'>
                                                                    <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                                                        <tr>
                                                                            <td align='center' valign='top' width='100%' class='flexibleContainerCell'>
                                                                                <ul style='list-style:none;width:400px;margin:0px auto;'>
                                                                                    <li style='display:inline-block;margin-right:10px;border-right:2px solid #ccc;padding-right:14px;'>
                                                                                        <a href='https://www.facebook.com/pages/category/Brand/BingeParty-1404212866358535/' target='_blank'><img width='30' src='" + ConfigurationManager.AppSettings["domain"] + @"/Img/facebook.png' /></a>
                                                                                    </li>
                                                                                   
                                                                                    <li style='display:inline-block;margin-right:10px;border-right:2px solid #ccc;padding-right:14px;'>
                                                                                        <a href='https://www.instagram.com/Binge Party lifestyles/?hl=en' target='_blank'><img width='30' src='" + ConfigurationManager.AppSettings["domain"] + @"/Img/instagram.png' /></a>
                                                                                    </li>
                                                                                   
                                                                                </ul>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </center>
</body>
</html>";
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["host"];
            smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            smtp.Credentials = new System.Net.NetworkCredential
                           (ConfigurationManager.AppSettings["userName"], ConfigurationManager.AppSettings["password"]);

            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["enableSsl"]);
            await Task.Run(() => smtp.Send(mail));
            return 1;
        }
        catch (Exception ex)
        {
            ExceptionCapture.CaptureException(HttpContext.Current.Request.Url.PathAndQuery, "SendPasswordRestLink", ex.Message);
            return 0;
        }
    }


    public static int BookingConfirmed(string oid, string productTable, string name, string email, string phone, string paidAmount, string pType, string address1, string address2)
    {
        try
        {
            string mailBody = @"<!DOCTYPE HTML PUBLIC '-//W3C//DTD XHTML 1.0 Strict//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd'>
<html xmlns='http://www.w3.org/1999/xhtml'>
<head>
    <meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />
    <meta name='viewport' content='width=device-width, initial-scale=1.0' />
    <meta http-equiv='X-UA-Compatible' content='IE=edge,chrome=1' />
    <meta name='format-detection' content='telephone=no' />
    <title>Binge Party</title>
    <link rel='shortcut icon' href='" + ConfigurationManager.AppSettings["domain"] + @"/img/websiteLogos/favicon.png' />
    <link href='https://fonts.googleapis.com/css?family=Lato:100,100i,300,300i,400,400i,700,700i,900,900i&display=swap' rel='stylesheet' />
    <style type='text/css'>
        html {
            background-color: #FFF;
            margin: 0;
            font-family: 'Lato', sans-serif;
            padding: 0;
        }
        /*@import url('https://fonts.googleapis.com/css?family=Roboto');*/

        body, #bodyTable, #bodyCell, #bodyCell {
            height: 100% !important;
            margin: 0;
            padding: 0;
            width: 100% !important;
        }

        table {
            border-collapse: collapse;
        }

            table[id=bodyTable] {
                width: 100% !important;
                margin: auto;
                max-width: 500px !important;
                color: #212121;
                font-weight: normal;
            }

        img, a img {
            border: 0;
            outline: none;
            text-decoration: none;
            height: auto;
            line-height: 100%;
        }

        /*a {         text-decoration: none !important;         border-bottom: 1px solid;     }*/ h1, h2, h3, h4, h5, h6 {
            color: #5F5F5F;
            font-weight: normal;
            font-size: 20px;
            line-height: 125%;
            text-align: Left;
            letter-spacing: normal;
            margin-top: 0;
            margin-right: 0;
            margin-bottom: 10px;
            margin-left: 0;
            padding-top: 0;
            padding-bottom: 0;
            padding-left: 0;
            padding-right: 0;
        }

        .ReadMsgBody {
            width: 100%;
        }

        .ExternalClass {
            width: 100%;
        }

            .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div {
                line-height: 100%;
            }

        table, td {
            mso-table-lspace: 0pt;
            mso-table-rspace: 0pt;
        }

        #outlook a {
            padding: 0;
        }

        img {
            -ms-interpolation-mode: bicubic;
            display: block;
            outline: none;
            text-decoration: none;
        }

        body, table, td, p, a, li, blockquote {
            -ms-text-size-adjust: 100%;
            -webkit-text-size-adjust: 100%;
            font-weight: 500 !important;
        }

        .ExternalClass td[class='ecxflexibleContainerBox'] h3 {
            padding-top: 10px !important;
        }

        h1 {
            display: block;
            font-size: 26px;
            font-style: normal;
            font-weight: normal;
            line-height: 100%;
        }

        h2 {
            display: block;
            font-size: 20px;
            font-style: normal;
            font-weight: normal;
            line-height: 120%;
        }

        h3 {
            display: block;
            font-size: 17px;
            font-style: normal;
            font-weight: normal;
            line-height: 110%;
        }

        h4 {
            display: block;
            font-size: 18px;
            font-style: italic;
            font-weight: normal;
            line-height: 100%;
        }

        .flexibleImage {
            height: auto;
        }

        .linkRemoveBorder {
            border-bottom: 0 !important;
        }

        table[class=flexibleContainerCellDivider] {
            padding-bottom: 0 !important;
            padding-top: 0 !important;
        }

        body, #bodyTable {
            background-color: #E1E1E1;
        }

        #emailHeader {
            background-color: #fff;
        }

        #emailBody {
            background-color: #FFFFFF;
        }

        #emailFooter {
            background-color: #E1E1E1;
        }

        .nestedContainer {
            background-color: #F8F8F8;
            border: 1px solid #CCCCCC;
        }

        .emailButton {
            background-color: #205478;
            border-collapse: separate;
        }

        .buttonContent {
            color: #FFFFFF;
            font-family: Helvetica;
            font-size: 18px;
            font-weight: bold;
            line-height: 100%;
            padding: 15px;
            text-align: center;
        }

            .buttonContent a {
                color: #FFFFFF;
                display: block;
                text-decoration: none !important;
                border: 0 !important;
            }

        .emailCalendar {
            background-color: #FFFFFF;
            border: 1px solid #CCCCCC;
        }

        .emailCalendarMonth {
            background-color: #205478;
            color: #FFFFFF;
            font-size: 16px;
            font-weight: bold;
            padding-top: 10px;
            padding-bottom: 10px;
            text-align: center;
        }

        .emailCalendarDay {
            color: #205478;
            font-size: 60px;
            font-weight: bold;
            line-height: 100%;
            padding-top: 20px;
            padding-bottom: 20px;
            text-align: center;
        }

        .imageContentText {
            margin-top: 10px;
            line-height: 0;
        }

            .imageContentText a {
                line-height: 0;
            }

        #invisibleIntroduction {
            display: none !important;
        }

        span[class=ios-color-hack] a {
            color: #275100 !important;
            text-decoration: none !important;
        }

        span[class=ios-color-hack2] a {
            color: #205478 !important;
            text-decoration: none !important;
        }

        span[class=ios-color-hack3] a {
            color: #8B8B8B !important;
            text-decoration: none !important;
        }

        .a[href^='tel'], a[href^='sms'] {
            text-decoration: none !important;
            color: #606060 !important;
            pointer-events: none !important;
            cursor: default !important;
        }

        .mobile_link a[href^='tel'], .mobile_link a[href^='sms'] {
            text-decoration: none !important;
            color: #606060 !important;
            pointer-events: auto !important;
            cursor: default !important;
        }

        @media only screen and (max-width: 480px) {
            body {
                width: 100% !important;
                min-width: 100% !important;
            }

            table[id='emailHeader'], table[id='emailBody'], table[id='emailFooter'], table[class='flexibleContainer'], td[class='flexibleContainerCell'] {
                width: 100% !important;
            }

            td[class='flexibleContainerBox'], td[class='flexibleContainerBox'] table {
                display: block;
                width: 100%;
                text-align: left;
            }

            td[class='imageContent'] img {
                height: auto !important;
                width: 100% !important;
                max-width: 100% !important;
            }

            img[class='flexibleImage'] {
                height: auto !important;
                width: 100% !important;
                max-width: 100% !important;
            }

            img[class='flexibleImageSmall'] {
                height: auto !important;
                width: auto !important;
            }

            table[class='flexibleContainerBoxNext'] {
                padding-top: 10px !important;
            }

            table[class='emailButton'] {
                width: 100% !important;
            }

            td[class='buttonContent'] {
                padding: 0 !important;
            }

                td[class='buttonContent'] a {
                    padding: 15px !important;
                }
        }

        @media only screen and (-webkit-device-pixel-ratio:.75) {
        }

        @media only screen and (-webkit-device-pixel-ratio:1) {
        }

        @media only screen and (-webkit-device-pixel-ratio:1.5) {
        }

        @media only screen and (min-device-width : 320px) and (max-device-width:568px) {
        }

        .blink_text {
            -webkit-animation-name: blinker;
            -webkit-animation-duration: 2s;
            -webkit-animation-timing-function: linear;
            -webkit-animation-iteration-count: infinite;
            -moz-animation-name: blinker;
            -moz-animation-duration: 2s;
            -moz-animation-timing-function: linear;
            -moz-animation-iteration-count: infinite;
            animation-name: blinker;
            animation-duration: 2s;
            animation-timing-function: linear;
            animation-iteration-count: infinite;
            color: white;
        }

        @-moz-keyframes blinker {
            0% {
                opacity: 1.0;
            }

            50% {
                opacity: 0.0;
            }

            100% {
                opacity: 1.0;
            }
        }

        @-webkit-keyframes blinker {
            0% {
                opacity: 1.0;
            }

            50% {
                opacity: 0.0;
            }

            100% {
                opacity: 1.0;
            }
        }

        @keyframes blinker {
            0% {
                opacity: 1.0;
            }

            50% {
                opacity: 0.0;
            }

            100% {
                opacity: 1.0;
            }
        }
    </style>
</head>
<body bgcolor='#E1E1E1' leftmargin='0' marginwidth='0' topmargin='0' marginheight='0' offset='0'>
    <center style='background-color:#E1E1E1;'>
        <table border='0' cellpadding='0' cellspacing='0' height='100%' width='100%' id='bodyTable' style=' table-layout: fixed; max-width:100% !important;width: 100% !important;min-width: 100% !important;'>
            <tr>
                <td align='center' valign='top' id='bodyCell'>
                    <table bgcolor='#FFFFFF' border='0' cellpadding='0' cellspacing='0' width='700' id='emailBody' style='margin-top:20px;margin-bottom:20px;'>
                        <tr>
                            <td align='center' valign='top' style=''>
                                <table border='0' cellpadding='0' cellspacing='0' width='100%' bgcolor='#fff'>

                                    <tr>
                                        <td align='center' valign='top'>
                                            <table border='0' cellpadding='0' cellspacing='0' width='700' class='flexibleContainer'>
                                                <tr>
                                                    <td align='center' valign='top' width='700' class='flexibleContainerCell'>
                                                        <table border='0' cellpadding='30' cellspacing='0' width='100%'>
                                                            <tr>
                                                                <td align='left' valign='top' style='padding:10px;background:#fcfcfc'>
                                                                    <table border='0' cellpadding='0' cellspacing='0' style='float:left;float: left; margin-right: 0; width: 100%;'>
                                                                        <tr>
                                                                            <td align='left' valign='top' width='100%' class='flexibleContainerCell'>
                                                                                <center><img style='height:50px;margin-bottom:0px;' src='" + ConfigurationManager.AppSettings["domain"] + @"/Img/websiteLogos/logo.png' /></center>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align='left' valign='top' style='padding:0px;background:#fff'>
                                                        <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                                            <tr>
                                                                <td align='left' valign='top' width='100%' class='flexibleContainerCell'>
                                                                    <p style='font-size:22px;line-height:28px!important;text-align:center;color:#573e40;font-weight:bold!important'>
                                                                        Thank You for your booking!
                                                                    </p>
                                                                    <p style='font-size:18px;color:#573e40;line-height:22px!important;margin-bottom:30px;text-align:left;padding:0px 50px;'>
                                                                        Hey " + name + @"
                                                                    </p>
                                                                    <p style='font-size:13px;line-height:25px!important;text-align:left;margin-top:0px;color:#573e40;margin-bottom:30px;padding:0px 50px;'>
                                                                        You’re awesome! Thank you so much for choosing to book from " + ConfigurationManager.AppSettings["domain"] + @"
                                                                        . If you have any queries about your booking contact us at orders@bingeparty.com or by visiting our contact us page
                                                                    </p>
                                                                    <p style='font-size:26px;line-height:32px!important;text-align:center;color:white;margin-top:0px;background:#5a2d9d;padding:10px;width:50%;margin:0px auto;margin-bottom:0px'>Booking ID: " + oid + @"</p>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align='left' valign='top' style='padding:20px 60px 20px 60px;background:#fff'>
                                                        <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                                            <tr>
                                                                <td align='left' valign='top' style='min-height:180px;float:left;width:46%;margin-bottom:10px;margin-top:20px;color:#fff;padding:10px; font-size:18px;margin-right:0.5%' bgcolor='#5a2d9d' class='flexibleContainerCell'>
                                                                    Theater Details
                                                                    <p style='color:#fff;text-align:left;line-height:20px;'>
                                                                        " + address1 + @"
                                                                    </p>
                                                                </td>
                                                                <td align='left' valign='top' style='min-height:180px;float:left;width:46%;margin-bottom:10px;margin-top:20px;text-align:left;padding:10px;color:#fff;font-size:18px;margin-left:0.5%;' bgcolor='#5a2d9d' class='flexibleContainerCell'>
                                                                   Booking Details
                                                                        <p style='color:#fff;text-align:left;line-height:20px;'>
                                                                        " + name + @",<br>
                                                                        " + email + @",<br>
                                                                        " + phone + @",<br>
                                                                        " + address2 + @"
                                                                    </p>
                                                                </td>
                                                                <td align='left' valign='top' style='float:left;width:100%' class='flexibleContainerCell'>
                                                                    <p style='text-align:left;font-weight:600!important;margin-bottom:20px !important;font-size:16px;'>Stuff You Picked:</p>
                                                                </td>
                                                            </tr>
                                                                    " + productTable + @"
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align='left' valign='top' style='padding:10px 20px;background:#f2f2f2'>
                                            <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                                <tr>
                                                    <td align='center' valign='middle' width='100%' class='flexibleContainerCell'>
                                                        <ul style='list-style:none;width:390px;margin:0px auto;'>
                                                            <li style='display:inline-block;margin-right:5px;padding-right:5px;'>
                                                                <a href='https://www.facebook.com/' target='_blank'><img width='25' src='" + ConfigurationManager.AppSettings["domain"] + @"/Img/facebook.png' /></a>
                                                            </li>
                                                            <li style='display:inline-block;margin-right:5px;padding-right:5px;'>
                                                                <a href='https://www.instagram.com/' target='_blank'><img width='25' src='" + ConfigurationManager.AppSettings["domain"] + @"/Img/instagram.png' /></a>
                                                            </li>
                                                            <li style='display:inline-block;margin-right:5px;padding-right:5px;'>
                                                                <a href='https://twitter.com/' target='_blank'><img width='25' src='" + ConfigurationManager.AppSettings["domain"] + @"/Img/twitter.png' /></a>
                                                            </li>
                                                            <li style='display:inline-block;margin-right:5px;padding-right:5px;'>
                                                                <a href='https://www.youtube.com/' target='_blank'><img width='25' src='" + ConfigurationManager.AppSettings["domain"] + @"/Img/youtube.png' /></a>
                                                            </li>
                                                            <li style='display:inline-block;margin-right:0px;padding-right:5px;'>
                                                                <a href='mailto:hello@bingeparty.com/' target='_blank'><img width='25' src='" + ConfigurationManager.AppSettings["domain"] + @"/Img/mail.png' /></a>
                                                            </li>
                                                        </ul>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </center>
</body>
</html>";
            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress(ConfigurationManager.AppSettings["from"], ConfigurationManager.AppSettings["fromName"]);
            mail.Subject = "Binge Party Booking Confirmation";
            mail.Body = mailBody;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["host"];
            smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["userName"], ConfigurationManager.AppSettings["password"]);
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["enableSsl"]);
            smtp.Send(mail);
            return 1;
        }
        catch (Exception)
        {
            return 0;
        }
    }

    public static int BookingConfirmedAdmin(string oid, string name, string email, string phone, string productTable, string address1, string address2)
    {
        try
        {
            #region mailBody
            string mailBody = @"<!DOCTYPE HTML PUBLIC '-//W3C//DTD XHTML 1.0 Strict//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd'>
<html xmlns='http://www.w3.org/1999/xhtml'>
<head>
    <meta http-equiv='Content-Type' content='text/html; charset=UTF-8' />
    <meta name='viewport' content='width=device-width, initial-scale=1.0' />
    <meta http-equiv='X-UA-Compatible' content='IE=edge,chrome=1' />
    <meta name='format-detection' content='telephone=no' />
    <title>Binge Party</title>
    <link rel='shortcut icon' href='" + ConfigurationManager.AppSettings["domain"] + @"/Img/websiteLogos/favicon.png' />
    <link href='https://fonts.googleapis.com/css?family=Lato:100,100i,300,300i,400,400i,700,700i,900,900i&display=swap' rel='stylesheet' />
    <style type='text/css'>
        html {
            background-color: #FFF;
            margin: 0;
            font-family: 'Lato', sans-serif;
            padding: 0;
        }

        /*@import url('https://fonts.googleapis.com/css?family=Roboto');*/

        body, #bodyTable, #bodyCell, #bodyCell {
            height: 100% !important;
            margin: 0;
            padding: 0;
            width: 100% !important;
        }

        table {
            border-collapse: collapse;
        }

            table[id=bodyTable] {
                width: 100% !important;
                margin: auto;
                max-width: 500px !important;
                color: #212121;
                font-weight: normal;
            }

        img, a img {
            border: 0;
            outline: none;
            text-decoration: none;
            height: auto;
            line-height: 100%;
        }

        /*a {
            text-decoration: none !important;
            border-bottom: 1px solid;
        }*/

        h1, h2, h3, h4, h5, h6 {
            color: #5F5F5F;
            font-weight: normal;
            font-size: 20px;
            line-height: 125%;
            text-align: Left;
            letter-spacing: normal;
            margin-top: 0;
            margin-right: 0;
            margin-bottom: 10px;
            margin-left: 0;
            padding-top: 0;
            padding-bottom: 0;
            padding-left: 0;
            padding-right: 0;
        }

        .ReadMsgBody {
            width: 100%;
        }

        .ExternalClass {
            width: 100%;
        }

            .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div {
                line-height: 100%;
            }

        table, td {
            mso-table-lspace: 0pt;
            mso-table-rspace: 0pt;
        }

        #outlook a {
            padding: 0;
        }

        img {
            -ms-interpolation-mode: bicubic;
            display: block;
            outline: none;
            text-decoration: none;
        }

        body, table, td, p, a, li, blockquote {
            -ms-text-size-adjust: 100%;
            -webkit-text-size-adjust: 100%;
            font-weight: 500 !important;
        }

        .ExternalClass td[class='ecxflexibleContainerBox'] h3 {
            padding-top: 10px !important;
        }

        h1 {
            display: block;
            font-size: 26px;
            font-style: normal;
            font-weight: normal;
            line-height: 100%;
        }

        h2 {
            display: block;
            font-size: 20px;
            font-style: normal;
            font-weight: normal;
            line-height: 120%;
        }

        h3 {
            display: block;
            font-size: 17px;
            font-style: normal;
            font-weight: normal;
            line-height: 110%;
        }

        h4 {
            display: block;
            font-size: 18px;
            font-style: italic;
            font-weight: normal;
            line-height: 100%;
        }

        .flexibleImage {
            height: auto;
        }

        .linkRemoveBorder {
            border-bottom: 0 !important;
        }

        table[class=flexibleContainerCellDivider] {
            padding-bottom: 0 !important;
            padding-top: 0 !important;
        }

        body, #bodyTable {
            background-color: #E1E1E1;
        }

        #emailHeader {
            background-color: #fff;
        }

        #emailBody {
            background-color: #FFFFFF;
        }

        #emailFooter {
            background-color: #E1E1E1;
        }

        .nestedContainer {
            background-color: #F8F8F8;
            border: 1px solid #CCCCCC;
        }

        .emailButton {
            background-color: #205478;
            border-collapse: separate;
        }

        .buttonContent {
            color: #FFFFFF;
            font-family: Helvetica;
            font-size: 18px;
            font-weight: bold;
            line-height: 100%;
            padding: 15px;
            text-align: center;
        }

            .buttonContent a {
                color: #FFFFFF;
                display: block;
                text-decoration: none !important;
                border: 0 !important;
            }

        .emailCalendar {
            background-color: #FFFFFF;
            border: 1px solid #CCCCCC;
        }

        .emailCalendarMonth {
            background-color: #205478;
            color: #FFFFFF;
            font-size: 16px;
            font-weight: bold;
            padding-top: 10px;
            padding-bottom: 10px;
            text-align: center;
        }

        .emailCalendarDay {
            color: #205478;
            font-size: 60px;
            font-weight: bold;
            line-height: 100%;
            padding-top: 20px;
            padding-bottom: 20px;
            text-align: center;
        }

        .imageContentText {
            margin-top: 10px;
            line-height: 0;
        }

            .imageContentText a {
                line-height: 0;
            }

        #invisibleIntroduction {
            display: none !important;
        }

        span[class=ios-color-hack] a {
            color: #275100 !important;
            text-decoration: none !important;
        }

        span[class=ios-color-hack2] a {
            color: #205478 !important;
            text-decoration: none !important;
        }

        span[class=ios-color-hack3] a {
            color: #8B8B8B !important;
            text-decoration: none !important;
        }

        .a[href^='tel'], a[href^='sms'] {
            text-decoration: none !important;
            color: #606060 !important;
            pointer-events: none !important;
            cursor: default !important;
        }

        .mobile_link a[href^='tel'], .mobile_link a[href^='sms'] {
            text-decoration: none !important;
            color: #606060 !important;
            pointer-events: auto !important;
            cursor: default !important;
        }

        @media only screen and (max-width: 480px) {
            body {
                width: 100% !important;
                min-width: 100% !important;
            }

            table[id='emailHeader'],
            table[id='emailBody'],
            table[id='emailFooter'],
            table[class='flexibleContainer'],
            td[class='flexibleContainerCell'] {
                width: 100% !important;
            }

            td[class='flexibleContainerBox'], td[class='flexibleContainerBox'] table {
                display: block;
                width: 100%;
                text-align: left;
            }

            td[class='imageContent'] img {
                height: auto !important;
                width: 100% !important;
                max-width: 100% !important;
            }

            img[class='flexibleImage'] {
                height: auto !important;
                width: 100% !important;
                max-width: 100% !important;
            }

            img[class='flexibleImageSmall'] {
                height: auto !important;
                width: auto !important;
            }

            table[class='flexibleContainerBoxNext'] {
                padding-top: 10px !important;
            }

            table[class='emailButton'] {
                width: 100% !important;
            }

            td[class='buttonContent'] {
                padding: 0 !important;
            }

                td[class='buttonContent'] a {
                    padding: 15px !important;
                }
        }

        @media only screen and (-webkit-device-pixel-ratio:.75) {
        }

        @media only screen and (-webkit-device-pixel-ratio:1) {
        }

        @media only screen and (-webkit-device-pixel-ratio:1.5) {
        }

        @media only screen and (min-device-width : 320px) and (max-device-width:568px) {
        }

        .blink_text {
            -webkit-animation-name: blinker;
            -webkit-animation-duration: 2s;
            -webkit-animation-timing-function: linear;
            -webkit-animation-iteration-count: infinite;
            -moz-animation-name: blinker;
            -moz-animation-duration: 2s;
            -moz-animation-timing-function: linear;
            -moz-animation-iteration-count: infinite;
            animation-name: blinker;
            animation-duration: 2s;
            animation-timing-function: linear;
            animation-iteration-count: infinite;
            color: white;
        }

        @-moz-keyframes blinker {
            0% {
                opacity: 1.0;
            }

            50% {
                opacity: 0.0;
            }

            100% {
                opacity: 1.0;
            }
        }

        @-webkit-keyframes blinker {
            0% {
                opacity: 1.0;
            }

            50% {
                opacity: 0.0;
            }

            100% {
                opacity: 1.0;
            }
        }

        @keyframes blinker {
            0% {
                opacity: 1.0;
            }

            50% {
                opacity: 0.0;
            }

            100% {
                opacity: 1.0;
            }
        }
    </style>
</head>
<body bgcolor='#E1E1E1' leftmargin='0' marginwidth='0' topmargin='0' marginheight='0' offset='0'>
    <center style='background-color:#E1E1E1;'>
        <table border='0' cellpadding='0' cellspacing='0' height='100%' width='100%' id='bodyTable' style=' table-layout: fixed; max-width:100% !important;width: 100% !important;min-width: 100% !important;'>
            <tr>
                <td align='center' valign='top' id='bodyCell'>
 
                    <table bgcolor='#FFFFFF' border='0' cellpadding='0' cellspacing='0' width='700' id='emailBody' style='margin-top:20px;margin-bottom:20px;'>
                        <tr>
                            <td align='center' valign='top' style=''>
                                <table border='0' cellpadding='0' cellspacing='0' width='100%' bgcolor='#fff'>
                                    <tr>
                                        <td align='center' valign='top'>
                                            <table border='0' cellpadding='0' cellspacing='0' width='700' class='flexibleContainer'>
                                                <tr>
                                                    <td align='center' valign='top' width='700' class='flexibleContainerCell'>
                                                        <table border='0' cellpadding='30' cellspacing='0' width='100%'>
                                                            <tr>
                                                                <td align='left' valign='top' style='padding:10px;background:#fcfcfc'>
                                                                    <table border='0' cellpadding='0' cellspacing='0' style='float:left;float: left; margin-right: 0; width: 100%;'>
                                                                        <tr>
                                                                            <td align='left' valign='top' width='100%' class='flexibleContainerCell'>
                                                                                <center><img style='height:50px;margin-bottom:0px;' src='" + ConfigurationManager.AppSettings["domain"] + @"/Img/websiteLogos/logo.png' /></center>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align='left' valign='top' style='padding:0px;background:#fff'>
                                                        <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                                            <tr>
                                                                <td align='left' valign='top' width='100%' class='flexibleContainerCell'>
                                                                    <p style='font-size:22px;line-height:28px!important;text-align:center;color:#573e40;font-weight:bold!important'>
                                                                        Hi Admin, You have received a booking, Below are the details
                                                                    </p>

                                                                    <p style='font-size:26px;line-height:32px!important;text-align:center;color:white;margin-top:0px;background:#5a2d9d;padding:10px;width:50%;margin:0px auto;margin-bottom:0px'>Booking ID : " + oid + @"</p>

                                                                </td> 
                                                            </tr> 
                                                        </table>
                                                    </td>
                                                </tr>  
                                                <tr>
                                                    <td align='left' valign='top' style='padding:20px 60px 20px 60px;background:#fff'>
                                                        <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                                            <tr>
                                                                <td align='left' valign='top' style='min-height:180px;float:left;width:46%;margin-bottom:10px;margin-top:20px;color:#fff;padding:10px; font-size:18px;margin-right:0.5%' bgcolor='#5a2d9d' class='flexibleContainerCell'>
                                                                    Theater Details
                                                                    <p style='color:#fff;text-align:left;line-height:20px;'>
                                                                        " + address1 + @"
                                                                    </p>
                                                                </td>
                                                                <td align='left' valign='top' style='min-height:180px;float:left;width:46%;margin-bottom:10px;margin-top:20px;text-align:left;padding:10px;color:#fff;font-size:18px;margin-left:0.5%;' bgcolor='#5a2d9d' class='flexibleContainerCell'>
                                                                   Booking Details
                                                                    <p style='color:#fff;text-align:left;line-height:20px;'>
                                                                        " + name + @",<br>
                                                                        " + email + @",<br>
                                                                        " + phone + @",<br>
                                                                        " + address2 + @"
                                                                    </p>
                                                                </td>
                                                                <td align='left' valign='top' style='float:left;width:100%' class='flexibleContainerCell'>
                                                                    <p style='text-align:left;font-weight:600!important;margin-bottom:20px !important;font-size:16px;'>Stuff You Picked:</p>
                                                                </td>
                                                            </tr>
                                                              " + productTable + @"
                                                        </table>
                                                    </td>
                                                </tr> 
                                            </table>
                                        </td>
                                    </tr> 
                                    <tr>
                                        <td align='left' valign='top' style='padding:10px 20px;background:#f2f2f2'>
                                            <table border='0' cellpadding='0' cellspacing='0' width='100%'>
                                                  <tr>
                                                    <td align='center' valign='middle' width='100%' class='flexibleContainerCell'>
                                                                                    <ul style='list-style:none;width:390px;margin:0px auto;'>
                                                                                        <li style='display:inline-block;margin-right:5px;padding-right:5px;'>
                                                                                            <a href='https://www.facebook.com/' target='_blank'><img width='25' src='" + ConfigurationManager.AppSettings["domain"] + @"/Img/facebook.png' /></a>
                                                                                        </li>
                                                                                        <li style='display:inline-block;margin-right:5px;padding-right:5px;'>
                                                                                            <a href='https://www.instagram.com//' target='_blank'><img width='25' src='" + ConfigurationManager.AppSettings["domain"] + @"/Img/instagram.png' /></a>
                                                                                        </li>
                                                                                        <li style='display:inline-block;margin-right:5px;padding-right:5px;'>
                                                                                            <a href='https://twitter.com/' target='_blank'><img width='25' src='" + ConfigurationManager.AppSettings["domain"] + @"/Img/twitter.png' /></a>
                                                                                        </li>
                                                                                        <li style='display:inline-block;margin-right:5px;padding-right:5px;'>
                                                                                            <a href='https://www.youtube.com/c/' target='_blank'><img width='25' src='" + ConfigurationManager.AppSettings["domain"] + @"/Img/youtube.png' /></a>
                                                                                        </li>
                                                                                        <li style='display:inline-block;margin-right:0px;padding-right:5px;'>
                                                                                            <a href='mailto:hello@bingeparty.com' target='_blank'><img width='25' src='" + ConfigurationManager.AppSettings["domain"] + @"/Img/mail.png' /></a>
                                                                                        </li>

                                                                                    </ul>
                                                    </td>
                                                </tr> 
                                            </table>
                                        </td>
                                    </tr> 
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </center>
</body>
</html>";
            #endregion    
            MailMessage mail = new MailMessage();
            mail.To.Add(ConfigurationManager.AppSettings["ToMail"]);
            mail.From = new MailAddress(ConfigurationManager.AppSettings["from"], ConfigurationManager.AppSettings["fromName"]);
            mail.Subject = "Binge Party Booking Confirmation";
            mail.Body = mailBody;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["host"];
            smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["userName"], ConfigurationManager.AppSettings["password"]);
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["enableSsl"]);
            smtp.Send(mail);
            return 1;
        }
        catch (Exception)
        {
            return 0;
        }
    }

}
