<%@ Page Title="" Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="details.aspx.cs" Inherits="details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link href="/assets/css/booking-theater.css" rel="stylesheet" />
    <link href="/assets/css/frontendStyle.css" rel="stylesheet" />
    <style>
        .default-header-section .header-bottom .menu-item-list ul li:nth-child(2) a {
            color: #f5e860;
        }

        .reason-box input[type="checkbox"]:checked + label::after {
            font-family: "";
            content: url('/assets/images/00icons/check.png');
            font-weight: 500;
            position: absolute;
            top: -15px;
            font-size: 14px;
            color: #000;
            right: 11px;
        }

        .SelectedColor {
            color: #5a2d9d;
        }

        .input-group > :not(:first-child):not(.dropdown-menu):not(.valid-tooltip):not(.valid-feedback):not(.invalid-tooltip):not(.invalid-feedback) {
            margin-left: calc(var(--bs-border-width)* -1);
            border-top-left-radius: 50px;
            border-bottom-left-radius: 50px;
        }

        .reason-box input[type="checkbox"]:checked + label {
            background: #f5e860;
            color: #000;
            border-color: #ff8b00;
            cursor: pointer;
        }

        .reason-box label {
            border: 1.5px solid #ff8b00;
        }

        #sync1 .owl-prev {
            position: absolute;
            top: 42%;
            left: 0;
            height: 30px;
            width: 30px;
            background: #5a2d9d;
            color: #fff;
            border-radius: 50%;
            font-size: 16px;
        }

        #sync1 .owl-next {
            position: absolute;
            top: 42%;
            right: 0;
            height: 30px;
            width: 30px;
            background: #5a2d9d;
            color: #fff;
            border-radius: 50%;
            font-size: 16px;
        }

        .custom-btn {
            z-index: 1;
            font-weight: 600;
            overflow: hidden;
            padding: 15px 35px;
            text-align: center;
            position: relative;
            border-radius: 50px;
            display: -webkit-inline-box;
            display: -ms-inline-flexbox;
            display: inline-flex;
            font-size: 14px;
            text-transform: capitalize;
            background: #f5e860;
            color: #ffffff !important;
            -webkit-box-shadow: unset !important;
            box-shadow: unset !important;
        }

        .side-right a {
            color: #000;
        }

        .reason-box input[type="checkbox"]:checked + label::before {
            content: "";
            height: 26px;
            width: 26px;
            background: #fff;
            border-radius: 50%;
            font-family: "Font Awesome 5 pro";
            font-weight: 600;
            position: absolute;
            top: -10px;
            right: 6px;
        }

        .pl-2 {
            padding-left: 50px;
        }

        .event-content .event-info-list ul li .icon {
            width: 20px;
            height: 20px;
            line-height: 20px;
            text-align: center;
            margin-right: 10px;
            color: #ffffff;
            border-radius: 100%;
            font-size: 12px;
            background-color: transparent !important;
        }

        .event-content .event-info-list ul li {
            margin-bottom: 5px;
            margin-left: 5px;
        }

        .ul-li-block ul li {
            margin-bottom: 10px;
            ;
            padding: 0;
            display: flex;
            gap: 0.5rem;
            list-style: none;
        }

        label {
            position: relative;
        }

        .reason-card {
            position: relative;
            border-top: none !important;
            text-align: center;
            cursor: pointer;
            border-radius: 12px;
            box-shadow: rgba(0, 0, 0, 0.15) 1.95px 1.95px 2.6px;
            background: #fff;
            padding: 20px 20px;
        }

            .reason-card h4 {
                text-transform: none;
            }

        .reason-box label {
            border: 1.5px solid #5a2d9d;
            border-radius: 30px !important;
            font-size: 14px;
            font-weight: 500;
            color: #000;
            width: 200px;
            height: 45px;
            line-height: 45px;
            text-align: center;
            margin-bottom: 0px;
            cursor: pointer;
        }

        .reason-box {
            padding: 10px 15px;
            width: unset;
            width: 100% !important;
            justify-content: space-between;
            border-bottom: 1px solid #ddd;
            align-items: center;
            display: flex;
            position: relative;
        }

        .col-lg-7.Decoration-tab-package {
            background: #fff;
            padding: 20px 20px;
            border-radius: 12px;
        }

        .reason-box p {
            margin-bottom: 0px;
            font-weight: 600;
            font-size: 18px;
        }

        .pl-correction {
            padding-left: 0px !important;
        }

        nav .disable {
            pointer-events: none;
            cursor: default;
        }

        .custom-btn.disable {
            pointer-events: none;
            cursor: default;
        }

        .dates li.inactive {
            pointer-events: none;
            cursor: default;
        }

        .NoofPax {
            border-radius: 50px;
        }

        .maxcap {
            font-size: 12px;
        }
    </style>
    <!-- carousel css include -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section id="breadcrumb-section" class="breadcrumb-section clearfix">
        <div class="jarallax" style="background-image: none; position: relative; z-index: 0; background: url(/assets/images/00icons/bgg.png) center;">
            <div class="overlay-black">
                <div class="container">
                    <div class="row justify-content-center">
                        <div class="col-lg-6 col-md-12 col-sm-12">

                            <!-- breadcrumb-title - start -->
                            <div class="breadcrumb-title text-center mb-20">
                                <h2 class="big-title"><%=StrTheaterTitle %></h2>
                            </div>
                            <!-- breadcrumb-title - end -->

                            <!-- breadcrumb-list - start -->
                            <div class="breadcrumb-list">
                                <ul>
                                    <li class="breadcrumb-item"><a href="/" class="breadcrumb-link">Home</a></li>
                                    <li class="breadcrumb-item active" aria-current="page"><%=StrTheaterTitle %> </li>
                                </ul>
                            </div>
                            <!-- breadcrumb-list - end -->

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section id="event-details-section" class="event-details-section sec-ptb-50 clearfix grey-bg">
        <div class="container">
            <div class="row">
                <div class="col-lg-7 Decoration-tab-package">
                    <div class="custom-owl mb-4">
                        <div id="sync1" class="owl-carousel owl-theme owl-loaded owl-drag">
                            <div class="owl-stage-outer">
                                <div class="owl-stage">
                                    <%=StrTheaterGallery %>
                                </div>
                            </div>
                        </div>
                        <div id="sync2" class="owl-carousel owl-theme owl-loaded owl-drag">
                            <div class="owl-stage-outer">
                                <div class="owl-stage">
                                    <%=StrTheaterGallery %>
                                </div>
                            </div>
                        </div>
                    </div>
                    <h2><%=StrTheaterTitle %></h2>
                    <div><%=StrTheaterDesc %></div>


                    <div class="map">
                        <h3>Get Direction</h3>
                        <div style="width: 100%">
                            <iframe src="<%=StrTheaterLocation %>" width="100%" height="450" style="border: 0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
                        </div>
                    </div>
                </div>
                <div class="col-lg-5  mb-4 mt-4 mt-lg-0 pl-2">

                    <div class="row mb-4 custum-call">
                        <div class="callender">
                            <div class="row justify-content-center position-relative">
                                <div class="col-lg-12 mb-2">
                                    <div class="calendar">
                                        <div class="new-flex1">
                                            <h3></h3>
                                            <nav>
                                                <a href="javascript:void(0);" class="disable" id="prev"><i class="fas fa-angle-left"></i></a>
                                                <a href="javascript:void(0);" id="next"><i class="fas fa-angle-right"></i></a>
                                            </nav>
                                        </div>
                                        <section>
                                            <ul class="days">
                                                <li>Sun</li>
                                                <li>Mon</li>
                                                <li>Tue</li>
                                                <li>Wed</li>
                                                <li>Thu</li>
                                                <li>Fri</li>
                                                <li>Sat</li>
                                            </ul>
                                            <ul class="dates"></ul>
                                        </section>
                                    </div>

                                    <span id="date_error" style="color: red;"></span>
                                    <div class="reason-card mb-3 mt-3">
                                        <h3 class="text-start text-black">Pick a slot
                                        </h3>
                                        <div class="row" id="slots">
                                            <%--<div class='reason-box col-lg-12 col-md-12 col-6 text-center  '>
                                                <input type='checkbox' class='timeSlot-btn time-selected' id='473' data-id='473' data-amount='1999' data-additional='300' data-slot='10:30 AM - 01:00 PM' name='time' value='Hidden Wall Bed'>
                                                <label for='473'>10:30 AM - 01:00 PM </label>
                                                <p>₹1999</p>
                                            </div>
                                            <div class='reason-box col-lg-12 col-md-12 col-6 text-center  '>
                                                <input type='checkbox' class='timeSlot-btn time-selected' id='474' data-id='473' data-amount='1999' data-additional='300' data-slot='10:30 AM - 01:00 PM' name='time' value='Hidden Wall Bed'>
                                                <label for='474'>10:30 AM - 01:00 PM </label>
                                                <p>₹1999</p>
                                            </div>
                                            <div class='reason-box col-lg-12 col-md-12 col-6 text-center  '>
                                                <input type='checkbox' class='timeSlot-btn time-selected' id='475' data-id='473' data-amount='1999' data-additional='300' data-slot='10:30 AM - 01:00 PM' name='time' value='Hidden Wall Bed'>
                                                <label for='475'>10:30 AM - 01:00 PM </label>
                                                <p>₹1999</p>
                                            </div>--%>
                                        </div>
                                    </div>
                                    <a href="javascript:void(0);" id="submit_btn" class="custom-btn mx-auto opacity-50 disable">Book Now
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="BookingModal" tabindex="-1" role="dialog" aria-labelledby="BookingModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Add Booking Details</h5>
                        <a class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </a>
                    </div>


                    <div class="row">

                        <div class="col-lg-12 mx-auto">
                            <div class="book-now">
                                <div class="row">

                                    <div class="col-lg-12 bg-light">
                                        <div class="row">
                                            <div class="col-lg-12 text-center py-3">
                                                <p class="cal_date mb-0">
                                                    <span class="pe-3">
                                                        <i class="far fa-calendar-alt "></i>
                                                        <span class="bookeddate">30/Mar/2024</span>

                                                    </span>
                                                    <br />
                                                    <span class="ps-3 mt-2">
                                                        <i class="far fa-clock"></i>
                                                        <span class="bookedtime">01:15 PM - 03:45 PM, 06:45 PM - 09:15 PM</span>
                                                    </span>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row px-3 py-4 ">
                                    <div class="col-lg-12">
                                        <div class="input-group mb-0">
                                            <i class="fas fa-user"></i>
                                            <input type="text" placeholder="Name" name="name" maxlength="100" class="txtName onlyAlpha">
                                        </div>
                                        <span class="spnName text-danger d-none"></span>
                                    </div>
                                    <div class="col-lg-12 ">
                                        <div class="input-group mb-0">
                                            <i class="fas fa-envelope"></i>
                                            <input type="Email" placeholder="Email" maxlength="100" class="txtEmail" name="name">
                                        </div>
                                        <span class="spnEmail text-danger d-none"></span>
                                    </div>
                                    <div class="col-lg-12">
                                        <div class="input-group mb-0">
                                            <i class="fas fa-phone fa-flip-horizontal"></i>
                                            <input type="text" placeholder="Phone" maxlength="20" class="txtPhone onlyNum" name="name">
                                        </div>
                                        <span class="spnPhone text-danger d-none"></span>
                                    </div>
                                    <div class="col-lg-12">
                                        <div class="select-group input-group mb-0">
                                            <select id="NoofPax" class="NoofPax form-select" name="NoofPax"></select>

                                        </div>
                                        <span class="spnPax text-danger d-none"></span>
                                    </div>

                                </div>
                                <div class="row new-mb align-items-center">
                                    <div class="col-lg-6 col-8 px-4 py-2">
                                        <h3>Total</h3>
                                        <p>( Excluding of all tax ) </p>
                                    </div>
                                    <div class="col-lg-6 col-4 text-end px-4 py-2">
                                        <span id="total_amount">₹ <span class="totalprice"></span></span>
                                    </div>
                                </div>
                                <div class="row mt-3">
                                    <div class="col-lg-12 text-center">
                                        <a href="javascript:void(0);" class="custom-btn booknowbtn" tabindex="-1">Book now</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


            </div>
        </div>
        <asp:Label ID="lblhidden" runat="server" class="d-none lblhidden"></asp:Label>
    </section>
    <script src="/assets/js/jquery-3.3.1.min.js"></script>
    <script src="/assets/js/calander.js"></script>
    <script src="/assets/js/pages/theater-detail.js"></script>
</asp:Content>

