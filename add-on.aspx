<%@ Page Title="" Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="add-on.aspx.cs" Inherits="add_on" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/assets/css/addon.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section id="breadcrumb-section" class="breadcrumb-section clearfix">
        <div class="jarallax" style="background-image: none; position: relative; z-index: 0; background: url(/assets/images/00icons/bgg.png) center;">
            <div class="overlay-black">
                <div class="container">
                    <div class="row justify-content-center">
                        <div class="col-lg-6 col-md-12 col-sm-12">
                            <div class="breadcrumb-title text-center mb-20">
                                <h2 class="big-title">Add  <strong>on</strong></h2>
                            </div>
                            <div class="breadcrumb-list">
                                <ul>
                                    <li class="breadcrumb-item"><a href="/" class="breadcrumb-link">Home</a></li>
                                    <li class="breadcrumb-item active" aria-current="page">Add on</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section id="blog-section" class="blog-section sec-ptb-100 clearfix grey-bg">
        <div class="container">
            <div class="row">
                <div class="col-lg-8">
                    <div class="blog-wrapper">
                        <div class="layout-btn-group">
                            <ul class="nav blog-layout-menubar float-right">
                                <%= StrAddOnCategory%>
                            </ul>
                        </div>
                    </div>

                    <div class="tab-content">
                        <%=StrAddOnProducts %>
                        <div class='col-lg-5 mt-4 mx-auto' id="divcake" runat="server" visible="false">
                            <div class='input-group_1'>
                                <i class='far fa-user'></i>
                                <asp:TextBox runat="server" placeholder='Message on cake' ID='TxtCakeMsg' class='cake_message'></asp:TextBox>
                            </div>
                        </div>

                        <div class="row mt-4">

                            <div class="order-summary-table table-responsive">
                                <h4 class="fw-semibold">Selected items</h4>
                                <table class="table text-center table-striped">
                                    <thead>
                                        <tr>
                                            <th scope="col">Item Type</th>
                                            <th scope="col">Items Name</th>
                                            <th scope="col">Quantity</th>
                                            <th scope="col">Price</th>
                                            <th scope="col">Total</th>
                                        </tr>
                                    </thead>
                                    <tbody class="cartTable">
                                    
                                    </tbody>
                                </table>

                            </div>
                        </div>
                        <div class="row mt-4">
                            <asp:TextBox runat="server" ID="txtNotes" TextMode="MultiLine" placeholder="Add Note Here"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="pl-50">
                        <div class="order-summery">
                            <h3>Order Summary
                            </h3>
                            <div class="row">
                                <div class="col-lg-8 text-start">
                                    <p>Slot Price</p>
                                </div>
                                <div class="col-lg-4 text-end">
                                    <p class="fw-semibold lblslotprice">₹ <%=StrSlotPrice %></p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-8 text-start">
                                    <p>
                                        Additional People Price

                                    </p>
                                </div>
                                <div class="col-lg-4 text-end">
                                    <p class="fw-semibold lblPaxPrice">
                                        ₹ <%=StrExtPaxCost %>
                                    </p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-8 text-start">
                                    <p>
                                        Add On Price
                                    </p>
                                </div>
                                <div class="col-lg-4 text-end">
                                    <p class="fw-semibold lblAddonPrice">
                                        ₹ 0
                                    </p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-8 text-start">
                                    <p>
                                        Tax
                                    </p>
                                </div>
                                <div class="col-lg-4 text-end">
                                    <p class="fw-semibold lblTaxPrice">
                                        ₹ <%=StrTax %>
                                    </p>
                                </div>
                            </div>
                            <div class="total">
                                <div class="row align-items-center">
                                    <div class="col-lg-6 text-start gtotal">
                                        <p class="fw-semibold">Total</p>
                                    </div>
                                    <div class="col-lg-6 text-end">
                                        <p class="grand-total">₹ <%= StrTotal %></p>
                                    </div>
                                </div>
                            </div>
                            <div class="row justify-content-center align-items-center">
                                <div class="col-lg-12">
                                    <a href="javascript:void(0);" class="new-term" data-toggle="modal" data-target="#exampleModal1">payment terms  </a>
                                </div>
                                <div class="col-lg-12">
                                    <asp:Label runat="server" Visible="false" ID="lblError" CssClass="alert alert-danger"></asp:Label>
                                    <%--<a href="javascript:void(0);" class="custom-btn btnpay" tabindex="-1">Pay</a>--%>
                                    <asp:LinkButton runat="server" ID="BtnPay" CssClass="custom-btn btnpay" TabIndex="-1" OnClick="BtnPay_Click">Pay</asp:LinkButton>
                                </div>
                            </div>

                        </div>
                    </div>

                </div>
            </div>
        </div>
    </section>
    <div class="modal fade" id="KnowMoreModal" tabindex="-1" role="dialog" aria-labelledby="KnowMoreModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="KnowMoreModalTitle"></h5>
                    <a class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </a>
                </div>
                <div class="modal-body knowmorebody">
                    <%--<ul>
                        <li>a cheerful "Happy Birthday" banner</li>
                        <li>a vibrant HBD floral message
                        </li>
                        <li>bright HBD LED lights on the floor
                        </li>
                        <li>Happy Birthday neon sign
                        </li>
                    </ul>--%>
                </div>

            </div>
        </div>
    </div>
    <div class="modal fade" id="exampleModal1" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog  modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel2">Guidelines to Follow</h5>
                    <a type="a" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </a>
                </div>
                <div class="modal-body">
                    <div class="row justify-content-center">
                        <div class="col-lg-12">
                            <div class="terms-sec">
                                <h4></h4>
                                <ol>
                                    <li>Smoking and alcohol consumption are strictly prohibited on the premises.
                                    </li>
                                    <li>Kindly adhere to the booking timings, as changes are not feasible once confirmed.
                                    </li>
                                    <li>Prevent any loss or damage to theatre property to avoid corresponding charges.
                                    </li>
                                    <li>Please also ensure not to litter the premises. An extra charge shall be levied .
                                    </li>
                                    <li>Do not carry snack items such as chips and drinks. Customers can purchase the same from the snack bar at the location.
                                    </li>
                                    <li>While casting content, please be aware that we are not liable for technical issues with OTT apps or your mobile device.
                                    </li>
                                    <li>Please do not take any decor item placed in the theatre.
                                    </li>
                                    <li>Candles are not permitted on the premises due to fire safety rules.
                                    </li>
                                </ol>

                                <h5>Health and Safety Guidelines</h5>
                                <ol>
                                    <li>Our theatre undergoes thorough disinfection before each booking to ensure a safe environment.
                                    </li>
                                    <li>We strictly adhere to legal guidelines by maintaining CCTV surveillance throughout our premises.
                                    </li>
                                </ol>
                                <h5>Additional Charges
                                </h5>
                                <ol>
                                    <li>A flat cleaning charge of Rs. 100/- will be applied if outside food is consumed within the premises.
                                    </li>
                                    <li>Please note that food and beverages are chargeable, unless explicitly stated in the package.
                                    </li>
                                    <li>In the event of last-minute additions to the group, booking charges will apply accordingly.
                                    </li>
                                    <li>In case of equipment damage (screenig system, lights, seating, etc) an extra charge will be levied.
                                    </li>
                                </ol>
                                <h5>Prompt Reporting and Support
                                </h5>
                                <ol>
                                    <li>If you encounter any dip in audio-visual performance, kindly notify us immediately. We are committed to providing the best network and audio-visual experience.
                                    </li>
                                </ol>


                            </div>

                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <label id="lblhidden" class="d-none lblhidden"><%=RouteData.Values["BUrl"] %></label>
    <label id="lbltotal" class="d-none lbltotal"><%=StrTotal%></label>
    <label id="lbltax" class="d-none lbltax"><%=StrTax%></label>
    <script src="/assets/js/jquery-3.3.1.min.js"></script>
    <script src="/assets/js/pages/add-ons.js"></script>
</asp:Content>

