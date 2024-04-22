<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="receipt.aspx.cs" Inherits="receipt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Receipt - <%=strReceiptNo %></title>
    <style type="text/css">
        body {
            background: #FFFFFF;
        }

        body, td, th, input, select, textarea, option, optgroup {
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 12px;
            color: #000000;
        }

        h1 {
            text-transform: uppercase;
            color: #CCCCCC;
            text-align: left;
            font-size: 24px;
            font-weight: normal;
            padding-bottom: 5px;
            margin-top: 0px;
            margin-bottom: 15px;
            border-bottom: 1px solid #CDDDDD;
            background-color: #f3f3f3;
        }

            h1 span {
                color: #333;
                float: right;
                padding: 25px 15px;
            }

        .store {
            width: 100%;
            margin-bottom: 20px;
        }

        .div2 {
            float: left;
            display: inline-block;
        }

        .div3 {
            float: right;
            display: inline-block;
            padding: 5px;
        }

        .heading td {
            background: #f3f3f3;
        }

        .address, .product {
            border-collapse: collapse;
        }

        .address {
            width: 100%;
            margin-bottom: 20px;
            border-top: 1px solid #CDDDDD;
            border-right: 1px solid #CDDDDD;
        }

            .address th, .address td {
                border-left: 1px solid #CDDDDD;
                border-bottom: 1px solid #CDDDDD;
                padding: 5px;
                vertical-align: text-bottom;
            }

            .address td {
                width: 50%;
            }

        .product {
            width: 100%;
            margin-bottom: 20px;
            border-top: 1px solid #CDDDDD;
            border-right: 1px solid #CDDDDD;
        }

            .product td {
                border-left: 1px solid #CDDDDD;
                border-bottom: 1px solid #CDDDDD;
                padding: 5px;
            }

        tr.second-row td {
            border-top: 0px !important;
        }

        tr.first-row td {
            border-bottom: 0px !important;
        }

        td.rate-sec {
            border-top: 0px solid #CDDDDD !important;
        }

        .mainsty {
            border-right: 1px solid #CDDDDD !important;
        }
    </style>
    <script src="/assets/js/jquery-3.5.1.min.js"></script>
    <script>
        $(document).ready(function () {
            $("#Button1").click(function () {
                $("#Button1").css("display", "none");
                window.print();
                $("#Button1").css("display", "block");
            });
        });
    </script>
    <link rel="canonical" href="<%=Request.Url.AbsoluteUri.ToLower() %>" />

</head>
<body>
    <form id="form1" runat="server">
        <div style="page-break-after: always;">
            <h1>
                <img src="Img/websiteLogos/logo.png" style="height: 50px; padding: 10px 5px 1px;" />
                <span>Booking Details - Binge Party</span></h1>
            <table class="store">
                <tr>
                    <td><b>Binge Party</b><br />
                        Website: https://www.bingeparty.com<br />
                        E-Mail : booking@bingeparty.com<br />
                    </td>
                </tr>
            </table>
            <table class="address">
                <tr class="heading">
                    <td width="50%"><b>Theater Details </b></td>
                    <td width="50%"><b>Booking Details </b></td>
                </tr>
                <tr>
                    <td><%=strTheater %></td>
                    <td>Booking No : <%=strBookingId %><br />
                        Booking On : <%=Bookingon %><br />
                        Booking Status : <%=strssts %><br />
                        Payment Mode : <%=payMode %></br>
                        <hr />
                        <%=strBookingDetail %>


                    </td>
                </tr>
            </table>
            <table class="product">
                <tr class="heading">
                    <td><b>SI.NO</b></td>
                    <td><b>Items</b></td>
                    <td align="right"><b>Quantity</b></td>
                    <td align="right"><b>Price</b></td>
                    <td align="right" colspan='2'><b>Total</b></td>
                </tr>
                <%=productDetails %>

                <tr id="trwithoutTax" runat="server">
                    <td align="right" colspan="5"><b>Subtotal Without Tax</b></td>
                    <td align="right" class="mainsty">₹  <%=subTotalWithoutTax %></td>
                </tr>

                <%-- <tr id="trigst" runat="server" visible="false">
                    <td align="right" colspan="5"><b>IGST</b></td>
                    <td align="right" class="mainsty">₹  <%=strTax %></td>
                </tr>--%>
                <tr id="traddontotal" runat="server" visible="false">
                    <td align="right" colspan="5"><b>Add On Total</b></td>
                    <td align="right" class="mainsty">₹  <%=AddOnFinalPrice %></td>
                </tr>
                <tr id="trTimetotal" runat="server" visible="false">
                    <td align="right" colspan="5"><b>Time Slots Amount</b></td>
                    <td align="right" class="mainsty">₹  <%=TimeFinalPrice %></td>
                </tr>
                <tr id="trExtpaxtotal" runat="server" visible="false">
                    <td align="right" colspan="5"><b>Extra Pax Amount (<%=StrNoofPAx %>)</b></td>
                    <td align="right" class="mainsty">₹  <%=PaxFinalPrice %></td>
                </tr>
                <tr id='trcgst' runat='server' visible='false'>
                    <td align='right' colspan='5'><b>CGST</b></td>
                    <td align='right' class='mainsty'>₹  <%=strTax %></td>
                </tr>
                <tr id="trsgst" runat="server" visible="false">
                    <td align="right" colspan="5"><b>SGST</b></td>
                    <td align="right" class="mainsty">₹  <%=strTax %></td>
                </tr>
                <tr id="trsub" runat="server" visible="false">
                    <td align="right" colspan="5"><b>Subtotal</b></td>
                    <td align="right" class="mainsty">₹  <%=subTotal %></td>
                </tr>
                <tr id="trdis" runat="server" visible="false">
                    <td align="right" colspan="5"><b>Discount <%=StrCoupon %></b></td>
                    <td align="right" class="mainsty">- ₹  <%=strDiscount %></td>
                </tr>
                <tr id="trcpdis" runat="server" visible="false">
                    <td align="right" colspan="5"><b>Coupon Discount</b></td>
                    <td align="right" class="mainsty">- ₹  <%=strAddDiscount %></td>
                </tr>
                <tr id="trship" runat="server" visible="false">
                    <td align="right" colspan="5"><b>Shipping charge</b></td>
                    <td align="right" class="mainsty">₹  <%=delCharge %></td>
                </tr>
                <tr id="trcod" runat="server" visible="false">
                    <td align="right" colspan="5"><b>COD charge</b></td>
                    <td align="right" class="mainsty">₹  <%=strCODCharge %></td>
                </tr>



                <tr id="trtotal" runat="server" visible="false">
                    <td align="right" colspan="5"><b>Total amount</b></td>
                    <td align="right" class="mainsty">₹  <%=FinalPrice %></td>
                </tr>
            </table>
            <%=strDeliveryNote %>
            <table>
                <tr>
                    <td><b>For, Binge Party</b><br />
                        <br />
                        Authorized Signatory
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <br />
                        THIS IS A COMPUTER GENERATED INVOICE & DOESN’T REQUIRE SIGNATURE</td>
                </tr>
            </table>
            <table style="width: 100%">
                <tr style="border: none">
                    <td colspan="5" align="center">
                        <asp:Button ID="Button1" runat="server" Text="Print" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
<script src="assets/js/jquery-3.6.0.min.js"></script>
<script>
    $(document).ready(function () {
        $("#Button1").click(function () {
            $("#Button1").css("display", "none");
            window.print();
            $("#Button1").css("display", "block");
        });
    });
</script>
</html>

