<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="test.aspx.cs" Inherits="test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/assets/css/addon.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section id="breadcrumb-section" class="breadcrumb-section clearfix">
        <div class="jarallax" style="background-image: none; position: relative; z-index: 0; background: url(assets/images/00icons/bgg.png) center;">
            <div class="overlay-black">
                <div class="container">
                    <div class="row justify-content-center">
                        <div class="col-lg-6 col-md-12 col-sm-12">

                            <!-- breadcrumb-title - start -->
                            <div class="breadcrumb-title text-center mb-20">
                                <h2 class="big-title">Add  <strong>on</strong></h2>
                            </div>
                            <!-- breadcrumb-title - end -->

                            <!-- breadcrumb-list - start -->
                            <div class="breadcrumb-list">
                                <ul>
                                    <li class="breadcrumb-item"><a href="index-1.html" class="breadcrumb-link">Home</a></li>
                                    <li class="breadcrumb-item active" aria-current="page">Add on</li>
                                </ul>
                            </div>
                            <!-- breadcrumb-list - end -->

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
                            <!-- <h3 class="float-left">change layout</h3> -->
                            <ul class="nav blog-layout-menubar float-right">
                                <li>
                                    <a class="active" data-toggle="tab" href="#Occation">Occation</a>
                                </li>
                                <li>
                                    <a data-toggle="tab" href="#Cakes">Cakes</a>
                                </li>
                                <li>
                                    <a data-toggle="tab" href="#Cake">Bouquet</a>
                                </li>
                                <li>
                                    <a data-toggle="tab" href="#Decorations">Decorations</a>
                                </li>
                                <li>
                                    <a data-toggle="tab" href="#foodparty">Food party</a>
                                </li>

                            </ul>
                        </div>
                    </div>

                    <div class="tab-content">
                        <!-- grid-layout - start -->
                        <div id="Occation" class="tab-pane fade in active show">
                            <div class="row mt-0 gy-4">
                                <div class="col-lg-4 col-md-6 col-6">
                                    <div class="newAddOnWrap">
                                        <div class=" position-relative">
                                            <img src="assets/images/00icons/addon/1.png" class="w-100" />
                                            <div class="position-absolute inputWrap">
                                                <input type="checkbox" name="party" class="addOnInput " />
                                            </div>
                                        </div>

                                        <div class="content">
                                            <p>Birthday</p>
                                            <p>₹0</p>
                                            <a class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">know more
                                            </a>
                                        </div>
                                    </div>




                                </div>

                                <div class='col-lg-4 col-md-6 col-6'>
                                    <div class='newAddOnWrap'>
                                        <div class=' position-relative'>
                                            <img src='assets/images/00icons/addon/1.png' class='w-100' />
                                            <div class='position-absolute inputWrap'>
                                                <input type='checkbox' name='party' class='addOnInput ' />
                                            </div>
                                        </div>

                                        <div class='content'>
                                            <p>Birthday</p>
                                            <p>₹0</p>
                                            <div class='add'>
                                                <a class='qtyminus' aria-hidden='true'>&minus;</a>
                                                <input type='text' name='qty' id='qty' min='1' max='10' step='1' value='1'>
                                                <a class='qtyplus' aria-hidden='true'>&plus;</a>

                                            </div>
                                        </div>
                                    </div>




                                </div>
                                <div class="col-lg-4 col-md-6 col-6">
                                    <div class="newAddOnWrap">
                                        <div class=" position-relative">
                                            <img src="assets/images/00icons/addon/1.png" class="w-100" />
                                            <div class="position-absolute inputWrap">
                                                <input type="checkbox" name="party" class="addOnInput " />
                                            </div>
                                        </div>

                                        <div class="content">
                                            <p>Birthday</p>
                                            <p>₹0</p>
                                            <div class="add">
                                                <a class="qtyminus" aria-hidden="true">&minus;</a>
                                                <input type="text" name="qty" id="qty" min="1" max="10" step="1" value="1">
                                                <a class="qtyplus" aria-hidden="true">&plus;</a>

                                            </div>
                                        </div>
                                    </div>




                                </div>

                                <%--                         <div class="col-lg-4 col-md-6 col-6">
                                    <div class="tile new-hei">
                                        <input type="checkbox" name="party" id="c1" />
                                        <label for="c1" class="theme-sec">
                                            <img src="assets/images/00icons/addon/cake/1.png" />
                                            <div class="content">
                                                <p class="cake">
                                                    Chocolate Truffle

                                                </p>
                                                <p>₹0</p>
                                                <div class="add">
                                                    <a class="qtyminus" aria-hidden="true">&minus;</a>
                                                    <input type="text" name="qty" id="qty" min="1" max="10" step="1" value="1">
                                                    <a class="qtyplus" aria-hidden="true">&plus;</a>

                                                </div>
                                            </div>



                                        </label>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-6 col-6">
                                    <div class="tile new-hei">
                                        <input type="checkbox" name="party" id="c2" />
                                        <label for="c" class="theme-sec">
                                            <img src="assets/images/00icons/addon/cake/1.png" />
                                            <div class="content">
                                                <p class="cake">
                                                    Chocolate Truffle

                                                </p>
                                                <p>₹0</p>
                                                <div class="add">
                                                    <a class="qtyminus" aria-hidden="true">&minus;</a>
                                                    <input type="text" name="qty" id="qty" min="1" max="10" step="1" value="1">
                                                    <a class="qtyplus" aria-hidden="true">&plus;</a>

                                                </div>
                                            </div>



                                        </label>
                                    </div>
                                </div>--%>
                            </div>

                        </div>

                    </div>
                </div>

            </div>
        </div>
    </section>
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel1">Birthday :-
                    </h5>
                    <a type="a" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </a>
                </div>
                <div class="modal-body">
                    <ul>
                        <li>a cheerful "Happy Birthday" banner</li>
                        <li>a vibrant HBD floral message
                        </li>
                        <li>bright HBD LED lights on the floor
                        </li>
                        <li>Happy Birthday neon sign
                        </li>
                    </ul>

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
    <script src="/assets/js/jquery-3.3.1.min.js"></script>
    <script src="/assets/js/pages/add-ons.js"></script>
</asp:Content>

