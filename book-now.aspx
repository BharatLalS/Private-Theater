<%@ Page Title="" Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="book-now.aspx.cs" Inherits="book_now" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .default-header-section .header-bottom .menu-item-list ul li:nth-child(2) a {
            color: #f5e860;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section id="breadcrumb-section" class="breadcrumb-section clearfix">
        <div class="jarallax" style="background-image: none; position: relative; z-index: 0; background: url(assets/images/00icons/bgg.png) center;">
            <div class="overlay-black">
                <div class="container">
                    <div class="row justify-content-center">
                        <div class="col-lg-6 col-md-12 col-sm-12">
                            <div class="breadcrumb-title text-center mb-20">
                                <h2 class="big-title">Book <strong>Now</strong></h2>
                            </div>
                            <div class="breadcrumb-list">
                                <ul>
                                    <li class="breadcrumb-item"><a href="/" class="breadcrumb-link">Home</a></li>
                                    <li class="breadcrumb-item active" aria-current="page">Book Now</li>
                                </ul>
                            </div>
                            <!-- breadcrumb-list - end -->

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section id="event-section" class="event-section new-eve bg-gray-light sec-ptb-50 clearfix grey-bg">
        <div class="container">
            <div class="section-title ">
                <h2 class="big-title text-start"><strong>Choose Your Location</strong></h2>
            </div>
            <div class="row">
                <!-- - start -->
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <div class="tab-content">
                        <div id="grid-style" class="tab-pane fade active show">
                            <div class="row">
                                <%=StrArea %>
                                <%--<div class='col-lg-3 col-md-6 col-sm-12'>
                                    <div class='event-grid-item'>
                                        <!-- event-image - start -->
                                        <div class='event-image'>

                                            <img src='assets/images/event/2.event-grid.jpg' alt='Image_not_found'>
                                        </div>
                                        <!-- event-image - end -->

                                        <!-- event-content - start -->
                                        <div class='event-content'>
                                            <div class='event-title mb-20'>
                                                <h3 class='title'>Electronic City
                                                </h3>
                                            </div>
                                            <div class='row'>
                                                <div class='col-lg-6 col-5'>
                                                    <span class='new-start'>Starting From</span>
                                                    <p class='slot_price'>
                                                        ₹ 1999 
                                                                                               
                                                    </p>
                                                </div>
                                                <div class='col-lg-6 col-7 my-auto'>
                                                    <p class='capacity text-dark'>
                                                        <i class='fas fa-users'></i>
                                                        4 people                                   
                                                    </p>
                                                </div>
                                            </div>

                                            <a href='details.aspx' class='tickets-details-btn'>Book Slot <i class='fas fa-angle-right fa-lg'></i>
                                            </a>
                                        </div>
                                        <!-- event-content - end -->
                                    </div>
                                </div>--%>
                                <%--<div class="col-lg-3 col-md-6 col-sm-12">
                                    <div class="event-grid-item">
                                        <!-- event-image - start -->
                                        <div class="event-image">
                                            <img src="assets/images/00icons/book-now/1.png" alt="Image_not_found">
                                        </div>
                                        <!-- event-image - end -->

                                        <!-- event-content - start -->
                                        <div class="event-content">
                                            <div class="event-title mb-20">
                                                <h3 class="title">HSR Layout
                                                </h3>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-6 col-5">
                                                    <span class="new-start">Starting From</span>
                                                    <p class="slot_price">
                                                        ₹ 1999   
                                                    </p>
                                                </div>
                                                <div class="col-lg-6 col-7 my-auto">
                                                    <p class="capacity text-dark">
                                                        <i class="fas fa-users"></i>
                                                        4 people 
                                                    </p>
                                                </div>
                                            </div>

                                            <a href="details.aspx" class="tickets-details-btn">Book Slot <i class="fas fa-angle-right fa-lg"></i>
                                            </a>
                                        </div>
                                        <!-- event-content - end -->
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-6 col-sm-12">
                                    <div class="event-grid-item">
                                        <!-- event-image - start -->
                                        <div class="event-image">

                                            <img src="assets/images/00icons/book-now/2.png" alt="Image_not_found">
                                        </div>
                                        <!-- event-image - end -->

                                        <!-- event-content - start -->
                                        <div class="event-content">
                                            <div class="event-title mb-20">
                                                <h3 class="title">Anathnaagar
                                                </h3>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-6 col-5">
                                                    <span class="new-start">Starting From</span>
                                                    <p class="slot_price">
                                                        ₹ 1999
                                                               
                                                    </p>
                                                </div>
                                                <div class="col-lg-6 col-7 my-auto">
                                                    <p class="capacity text-dark">
                                                        <i class="fas fa-users"></i>4 people
                                                    </p>
                                                </div>
                                            </div>

                                            <a href="details.aspx" class="tickets-details-btn">Book Slot <i class="fas fa-angle-right fa-lg"></i>
                                            </a>
                                        </div>
                                        <!-- event-content - end -->
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-6 col-sm-12">
                                    <div class="event-grid-item">
                                        <!-- event-image - start -->
                                        <div class="event-image">

                                            <img src="assets/images/event/2.event-grid.jpg" alt="Image_not_found">
                                        </div>
                                        <!-- event-image - end -->

                                        <!-- event-content - start -->
                                        <div class="event-content">
                                            <div class="event-title mb-20">
                                                <h3 class="title">Sahkarnagar
                                                </h3>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-6 col-5">
                                                    <span class="new-start">Starting From</span>
                                                    <p class="slot_price">
                                                        ₹ 1999
                               
                                                    </p>
                                                </div>
                                                <div class="col-lg-6 col-7 my-auto">
                                                    <p class="capacity text-dark">
                                                        <i class="fas fa-users"></i>4 people
                                                    </p>
                                                </div>
                                            </div>

                                            <a href="details.aspx" class="tickets-details-btn">Book Slot <i class="fas fa-angle-right fa-lg"></i>
                                            </a>
                                        </div>
                                        <!-- event-content - end -->
                                    </div>
                                </div>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

