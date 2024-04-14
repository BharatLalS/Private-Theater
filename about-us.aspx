<%@ Page Title="" Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="about-us.aspx.cs" Inherits="about_us" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
        <style>
       .default-header-section .header-bottom .menu-item-list ul li:nth-child(3) a {
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

                            <!-- breadcrumb-title - start -->
                            <div class="breadcrumb-title text-center mb-20">
                                <h2 class="big-title">About <strong>us</strong></h2>
                            </div>
                            <!-- breadcrumb-title - end -->

                            <!-- breadcrumb-list - start -->
                            <div class="breadcrumb-list">
                                <ul>
                                    <li class="breadcrumb-item"><a href="/" class="breadcrumb-link">Home</a></li>
                                    <li class="breadcrumb-item active" aria-current="page">About us</li>
                                </ul>
                            </div>
                            <!-- breadcrumb-list - end -->

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section id="upcomming-event-section3" class="upcomming-event-section3 sec-ptb-100 clearfix">
        <div class="container">

            <!-- section-title - start -->

            <!-- section-title - end -->

            <div class="comming-event-item">
                <div class="row justify-content-start">



                    <div class="col-lg-6 col-md-12 col-sm-12">
                        <div class="event-content">

                            <!-- event-title - start -->
                            <div class="event-title">

                                <h2 class="title-text"><strong>Bingeparty</strong></h2>
                            </div>
                            <!-- event-title - end -->

                            <p class="black-color mb-30">
                                Welcome to Binge party Bengaluru, where we redefine the essence of celebration through the captivating world of cinema. As the trailblazers in the realm of entertainment, we introduce you to an unparalleled cinematic experience that transcends traditional boundaries.
																<p class="black-color mb-30">
                                                                    Binge party Bengaluru stands as a chain of exclusive movie theaters, meticulously designed to immerse you in the magic of storytelling.
                                                                </p>



                        </div>
                    </div>
                    <div class="col-lg-6 col-md-12 col-sm-12">
                        <div class="event-image">
                            <div class="big-image">
                                <img src="assets/images/00icons/about/1.png" alt="Image_not_found">
                            </div>
                            <div class="small-image">
                                <img src="assets/images/00icons/about/2.png" alt="Image_not_found">
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </section>
</asp:Content>

