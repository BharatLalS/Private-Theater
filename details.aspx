<%@ Page Title="" Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="details.aspx.cs" Inherits="details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <link href="assets/css/booking-theater.css" rel="stylesheet" />
    <link href="assets/css/frontendStyle.css" rel="stylesheet" />
    <style>
        .default-header-section .header-bottom .menu-item-list ul li:nth-child(2) a {
            color: #f5e860;
        }

        .reason-box input[type="checkbox"]:checked + label::after {
            font-family: "";
            content: url('assets/images/00icons/check.png');
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
    </style>
    <!-- carousel css include -->
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
                                <h2 class="big-title">Electronic <strong>City</strong></h2>
                            </div>
                            <!-- breadcrumb-title - end -->

                            <!-- breadcrumb-list - start -->
                            <div class="breadcrumb-list">
                                <ul>
                                    <li class="breadcrumb-item"><a href="index-1.html" class="breadcrumb-link">Home</a></li>
                                    <li class="breadcrumb-item active" aria-current="page">Electronic City</li>
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
                                <div class="owl-stage" style="transform: translate3d(-1749px, 0px, 0px); transition: all 0s ease 0s; width: 6413px;">
                                    <div class="owl-item cloned" style="width: 583px;">
                                        <div class="item">
                                            <img src="https://www.thebingeclub.in/storage/Upload-Image554F7821-98DB-4DCD-A5BE-6DF91F67D2F2_1_201_a.jpeg" class="img-fluid" alt="">
                                        </div>
                                    </div>
                                    <div class="owl-item cloned" style="width: 583px;">
                                        <div class="item">
                                            <img src="https://www.thebingeclub.in/storage/Upload-ImageA36D40A4-9F03-40D1-BDA1-051B5C3D0372_1_201_a.jpeg" class="img-fluid" alt="">
                                        </div>
                                    </div>
                                    <div class="owl-item cloned" style="width: 583px;">
                                        <div class="item video-item">
                                            <video autoplay="" style="height: 100%; width: 100%;" loop="" muted="" playsinline="" preload="yes">
                                                <source src="https://www.thebingeclub.in/storage/screen-videos/Gnwn6wGuGYfAbGry35sXH4hOmWa42R0NALNoRsxt.mov" type="video/mp4">
                                            </video>
                                            <!-- <video class="screen-video" autoplay loop controls src="https://www.thebingeclub.in/storage/screen-videos/Gnwn6wGuGYfAbGry35sXH4hOmWa42R0NALNoRsxt.mov"></video> -->
                                        </div>
                                    </div>
                                    <div class="owl-item active" style="width: 583px;">
                                        <div class="item">
                                            <img src="https://www.thebingeclub.in/storage/Upload-Image8EB5A07C-1FD9-4CA9-B58E-5B66BDC8FC63_1_201_a.jpeg" class="img-fluid" alt="">
                                        </div>
                                    </div>
                                    <div class="owl-item" style="width: 583px;">
                                        <div class="item">
                                            <img src="https://www.thebingeclub.in/storage/Upload-Image37E26DC8-4A08-4F06-BFF0-81894B9A162D_1_201_a.jpeg" class="img-fluid" alt="">
                                        </div>
                                    </div>
                                    <div class="owl-item" style="width: 583px;">
                                        <div class="item">
                                            <img src="https://www.thebingeclub.in/storage/Upload-Image554F7821-98DB-4DCD-A5BE-6DF91F67D2F2_1_201_a.jpeg" class="img-fluid" alt="">
                                        </div>
                                    </div>
                                    <div class="owl-item" style="width: 583px;">
                                        <div class="item">
                                            <img src="https://www.thebingeclub.in/storage/Upload-ImageA36D40A4-9F03-40D1-BDA1-051B5C3D0372_1_201_a.jpeg" class="img-fluid" alt="">
                                        </div>
                                    </div>
                                    <div class="owl-item" style="width: 583px;">
                                        <div class="item video-item">
                                            <video autoplay="" style="height: 100%; width: 100%;" loop="" muted="" playsinline="" preload="yes">
                                                <source src="https://www.thebingeclub.in/storage/screen-videos/Gnwn6wGuGYfAbGry35sXH4hOmWa42R0NALNoRsxt.mov" type="video/mp4">
                                            </video>
                                            <!-- <video class="screen-video" autoplay loop controls src="https://www.thebingeclub.in/storage/screen-videos/Gnwn6wGuGYfAbGry35sXH4hOmWa42R0NALNoRsxt.mov"></video> -->
                                        </div>
                                    </div>
                                    <div class="owl-item cloned" style="width: 583px;">
                                        <div class="item">
                                            <img src="https://www.thebingeclub.in/storage/Upload-Image8EB5A07C-1FD9-4CA9-B58E-5B66BDC8FC63_1_201_a.jpeg" class="img-fluid" alt="">
                                        </div>
                                    </div>
                                    <div class="owl-item cloned" style="width: 583px;">
                                        <div class="item">
                                            <img src="https://www.thebingeclub.in/storage/Upload-Image37E26DC8-4A08-4F06-BFF0-81894B9A162D_1_201_a.jpeg" class="img-fluid" alt="">
                                        </div>
                                    </div>
                                    <div class="owl-item cloned" style="width: 583px;">
                                        <div class="item">
                                            <img src="https://www.thebingeclub.in/storage/Upload-Image554F7821-98DB-4DCD-A5BE-6DF91F67D2F2_1_201_a.jpeg" class="img-fluid" alt="">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="owl-nav">
                                <a role="presentation" class="owl-prev">
                                    <div class="nav-btn prev-slide"><i class="fas fa-chevron-left"></i></div>
                                </a>
                                <a role="presentation" class="owl-next">
                                    <div class="nav-btn next-slide"><i class="fas fa-chevron-right"></i></div>
                                </a>
                            </div>
                            <div class="owl-dots disabled"></div>
                        </div>

                        <div id="sync2" class="owl-carousel owl-theme owl-loaded owl-drag">





                            <div class="owl-stage-outer">
                                <div class="owl-stage" style="transform: translate3d(0px, 0px, 0px); transition: all 0s ease 0s; width: 729px;">
                                    <div class="owl-item active current" style="width: 145.75px;">
                                        <div class="item">
                                            <img src="https://www.thebingeclub.in/storage/Upload-Image8EB5A07C-1FD9-4CA9-B58E-5B66BDC8FC63_1_201_a.jpeg" class="img-fluid" alt="">
                                        </div>
                                    </div>
                                    <div class="owl-item active" style="width: 145.75px;">
                                        <div class="item">
                                            <img src="https://www.thebingeclub.in/storage/Upload-Image37E26DC8-4A08-4F06-BFF0-81894B9A162D_1_201_a.jpeg" class="img-fluid" alt="">
                                        </div>
                                    </div>
                                    <div class="owl-item active" style="width: 145.75px;">
                                        <div class="item">
                                            <img src="https://www.thebingeclub.in/storage/Upload-Image554F7821-98DB-4DCD-A5BE-6DF91F67D2F2_1_201_a.jpeg" class="img-fluid" alt="">
                                        </div>
                                    </div>
                                    <div class="owl-item active" style="width: 145.75px;">
                                        <div class="item">
                                            <img src="https://www.thebingeclub.in/storage/Upload-ImageA36D40A4-9F03-40D1-BDA1-051B5C3D0372_1_201_a.jpeg" class="img-fluid" alt="">
                                        </div>
                                    </div>
                                    <div class="owl-item" style="width: 145.75px;">
                                        <div class="item video-item">
                                            <video autoplay="" style="height: 100%; width: 100%;" loop="" muted="" playsinline="" preload="yes">
                                                <source src="https://www.thebingeclub.in/storage/screen-videos/Gnwn6wGuGYfAbGry35sXH4hOmWa42R0NALNoRsxt.mov" type="video/mp4">
                                            </video>
                                            <!-- <video class="screen-video" autoplay loop controls src="https://www.thebingeclub.in/storage/screen-videos/Gnwn6wGuGYfAbGry35sXH4hOmWa42R0NALNoRsxt.mov"></video> -->
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="owl-nav disabled">
                                <a  role="presentation" class="owl-prev"><span aria-label="Previous">‹</span></a>
                                <a  role="presentation" class="owl-next"><span aria-label="Next">›</span></a>
                            </div>
                            <div class="owl-dots disabled"></div>
                        </div>
                    </div>
                    <h2>Electronic City</h2>
                    <p>At Kaleidoscope, nestled in HSR Layout, our cozy two-seater movie theater awaits you with inviting couches amidst delightful decor, setting the stage for a perfect romantic atmosphere. It's the ultimate spot for you and your sweetheart to immerse yourselves in love's magic. Sink into our plush seats and embark on an unforgettable cinematic journey, where every moment is infused with warmth and enchantment. Here, couples can unwind, share laughter, and forge cherished memories in an intimate and laid-back setting. Don't forget to personalize your experience with our exciting addons!</p>

                    <div class="row facility mt-4">
                        <div class="col-lg-12">
                            <div class="event-info-list ul-li-block mb-30">
                                <ul>

                                    <li class="new-flex">
                                        <span class="icon">
                                            <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 25" fill="none">
                                                <circle cx="12" cy="12.5" r="12" fill="#5a2d9d"></circle>
                                                <path d="M8 12.5L10.8 15.5L16 9.5" stroke="white" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"></path>
                                                <defs>
                                                    <linearGradient id="paint0_linear_1_1901" x1="-0.944391" y1="6.69037" x2="27.3584" y2="7.90485" gradientUnits="userSpaceOnUse">
                                                        <stop offset="0.0027933" stop-color="#FF0059"></stop>
                                                        <stop offset="0.1064" stop-color="#FF144C"></stop>
                                                        <stop offset="0.4024" stop-color="#FF472C"></stop>
                                                        <stop offset="0.6607" stop-color="#FF6C14"></stop>
                                                        <stop offset="0.8686" stop-color="#FF8305"></stop>
                                                        <stop offset="1" stop-color="#FF8B00"></stop>
                                                    </linearGradient>
                                                </defs>
                                            </svg></span>
                                        <span>Delight in the privacy of your own private screen with your beloved.</span>
                                    </li>
                                    <li class="new-flex">
                                        <span class="icon">
                                            <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 25" fill="none">
                                                <circle cx="12" cy="12.5" r="12" fill="#5a2d9d"></circle>
                                                <path d="M8 12.5L10.8 15.5L16 9.5" stroke="white" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"></path>
                                                <defs>
                                                    <linearGradient id="paint0_linear_1_1901" x1="-0.944391" y1="6.69037" x2="27.3584" y2="7.90485" gradientUnits="userSpaceOnUse">
                                                        <stop offset="0.0027933" stop-color="#FF0059"></stop>
                                                        <stop offset="0.1064" stop-color="#FF144C"></stop>
                                                        <stop offset="0.4024" stop-color="#FF472C"></stop>
                                                        <stop offset="0.6607" stop-color="#FF6C14"></stop>
                                                        <stop offset="0.8686" stop-color="#FF8305"></stop>
                                                        <stop offset="1" stop-color="#FF8B00"></stop>
                                                    </linearGradient>
                                                </defs>
                                            </svg></span>
                                        <span>Immerse yourselves in your favorite films amidst dreamy decor.</span>
                                    </li>
                                    <li class="new-flex">
                                        <span class="icon">
                                            <svg xmlns="http://www.w3.org/2000/svg" width="20" height="20" viewBox="0 0 24 25" fill="none">
                                                <circle cx="12" cy="12.5" r="12" fill="#5a2d9d"></circle>
                                                <path d="M8 12.5L10.8 15.5L16 9.5" stroke="white" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"></path>
                                                <defs>
                                                    <linearGradient id="paint0_linear_1_1901" x1="-0.944391" y1="6.69037" x2="27.3584" y2="7.90485" gradientUnits="userSpaceOnUse">
                                                        <stop offset="0.0027933" stop-color="#FF0059"></stop>
                                                        <stop offset="0.1064" stop-color="#FF144C"></stop>
                                                        <stop offset="0.4024" stop-color="#FF472C"></stop>
                                                        <stop offset="0.6607" stop-color="#FF6C14"></stop>
                                                        <stop offset="0.8686" stop-color="#FF8305"></stop>
                                                        <stop offset="1" stop-color="#FF8B00"></stop>
                                                    </linearGradient>
                                                </defs>
                                            </svg>
                                        </span>
                                        <span>Savor our exquisite snacks, adding a touch of indulgence to your romantic celebration.</span>
                                    </li>

                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="map">
                        <h3>Get Direction</h3>
                        <div style="width: 100%">
                            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3806.2721565225893!2d78.3743068785798!3d17.44668324077908!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3bcb93e2663ae9c1%3A0x12aa54009dbee559!2sBinge%20and%20Party%20-%20Private%20Theatre%20%7C%20Party%20Place!5e0!3m2!1sen!2sin!4v1712134312460!5m2!1sen!2sin" width="100%" height="450" style="border: 0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
                        </div>
                    </div>
                </div>
                <div class="col-lg-5  mb-4 mt-4 mt-lg-0 pl-2">

                    <div class="row mb-4 custum-call">
                        <div class="callender">
                            <div class="dropdowns d-none">
                                <select id="yearSelect">

                                    <option value="2024">2024</option>
                                    <option value="2025">2025</option>
                                    <option value="2026">2026</option>
                                    <option value="2027">2027</option>
                                    <option value="2028">2028</option>
                                    <option value="2029">2029</option>
                                    <option value="2030">2030</option>
                                    <option value="2031">2031</option>
                                    <option value="2032">2032</option>
                                    <option value="2033">2033</option>
                                    <option value="2034">2034</option>
                                </select>
                                <select id="monthSelect">
                                    <option value="0">January</option>
                                    <option value="1">February</option>
                                    <option value="2">March</option>
                                    <option value="3">April</option>
                                    <option value="4">May</option>
                                    <option value="5">June</option>
                                    <option value="6">July</option>
                                    <option value="7">August</option>
                                    <option value="8">September</option>
                                    <option value="9">October</option>
                                    <option value="10">November</option>
                                    <option value="11">December</option>
                                </select>
                            </div>
                            <div class="row justify-content-center position-relative">
                                <div class="col-lg-12 mb-2">
                                    <div class="calendar">
                                        <div class="new-flex1">
                                            <h3></h3>
                                            <nav>
                                                <a href="javascript:void(0);" id="prev"><i class="fas fa-angle-left"></i></a>
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
                                            <div class="reason-box col-lg-12 col-md-12 col-6 text-center  ">
                                                <input type="checkbox" class="timeSlot-btn time-selected" id="473" data-id="473" data-amount="1999" data-additional="300" data-slot="10:30 AM - 01:00 PM" name="time" value="Hidden Wall Bed">
                                                <label for="473">10:30 AM - 01:00 PM </label>
                                                <p>₹1999</p>
                                            </div>

                                            <div class="reason-box col-lg-12 col-md-12 col-6 text-center  ">
                                                <input type="checkbox" class="timeSlot-btn" id="474" data-id="474" data-amount="1999" data-additional="300" data-slot="01:15 PM - 03:45 PM" name="time" value="Hidden Wall Bed">
                                                <label for="474">01:15 PM - 03:45 PM</label>
                                                <p>₹1999</p>
                                            </div>

                                            <div class="reason-box col-lg-12 col-md-12 col-6 text-center  ">
                                                <input type="checkbox" class="timeSlot-btn" id="475" data-id="475" data-amount="1999" data-additional="300" data-slot="04:00 PM - 06:30 PM" name="time" value="Hidden Wall Bed">
                                                <label for="475">04:00 PM - 06:30 PM</label>
                                                <p>₹1999</p>
                                            </div>

                                            <div class="reason-box col-lg-12 col-md-12 col-6 text-center  ">
                                                <input type="checkbox" class="timeSlot-btn" id="476" data-id="476" data-amount="1999" data-additional="300" data-slot="06:45 PM - 09:15 PM" name="time" value="Hidden Wall Bed">
                                                <label for="476">06:45 PM - 09:15 PM</label>
                                                <p>₹1999</p>
                                            </div>

                                            <div class="reason-box col-lg-12 col-md-12 col-6 text-center  ">
                                                <input type="checkbox" class="timeSlot-btn time-selected" id="477" data-id="477" data-amount="1999" data-additional="300" data-slot="09:30 PM - 12:15 AM" name="time" value="Hidden Wall Bed">
                                                <label for="477">09:30 PM - 12:15 AM</label>
                                                <p>₹1999</p>
                                            </div>
                                        </div>
                                        <span class="slot_error" style="color: red;"></span>
                                    </div>
                                    <a href="javascript:void(0);" id="submit_btn" class="custom-btn mx-auto" data-toggle="modal" data-target="#exampleModal">Book Now
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Add Booking Details</h5>
                        <a  class="close" data-dismiss="modal" aria-label="Close">
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
                                                        <i class="far fa-calendar-alt"></i>
                                                        30/Mar/2024
                                                    </span>
                                                    <br />
                                                    <span class="ps-3 mt-2">
                                                        <i class="far fa-clock"></i>
                                                        01:15 PM - 03:45 PM, 06:45 PM - 09:15 PM
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
                                            <input type="text" placeholder="Name" name="name" value="">
                                        </div>
                                    </div>
                                    <div class="col-lg-12 ">
                                        <div class="input-group mb-0">
                                            <i class="fas fa-envelope"></i>
                                            <input type="Email" placeholder="Email" name="name" value="">
                                        </div>
                                    </div>
                                    <div class="col-lg-12">
                                        <div class="input-group mb-0">
                                            <i class="fas fa-phone fa-flip-horizontal"></i>
                                            <input type="text" placeholder="Phone" name="name" value="">
                                        </div>
                                    </div>
                                    <div class="col-lg-12">
                                        <div class="select-group">
                                            <select id="number" class="number_of_people form-select" name="number_of_people">
                                                <option selected="">No of People</option>
                                                <option>4</option>
                                                <option>5</option>
                                                <option>6</option>
                                                <option>7</option>

                                                <option>8</option>
                                                <option>9</option>
                                                <option>10</option>
                                                <option>11</option>
                                                <option>12</option>

                                            </select>
                                        </div>
                                    </div>

                                </div>
                                <div class="row new-mb align-items-center">
                                    <div class="col-lg-6 col-8 px-4 py-2">
                                        <h3>Total</h3>
                                        <p>
                                            (inclusive of all taxes)
                       
                                        </p>
                                    </div>
                                    <div class="col-lg-6 col-4 text-end px-4 py-2">
                                        <span id="total_amount">₹ 1999</span>
                                    </div>
                                </div>
                                <div class="row mt-3">
                                    <div class="col-lg-12 text-center">
                                        <a href="add-on.aspx" class="custom-btn" tabindex="-1">Book now</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


            </div>
        </div>
    </section>
    <script src="/assets/js/jquery-3.3.1.min.js"></script>
    <script src="/assets/js/calander.js"></script>
</asp:Content>

