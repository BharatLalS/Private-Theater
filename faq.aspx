<%@ Page Title="" Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="faq.aspx.cs" Inherits="faq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .default-header-section .header-bottom .menu-item-list ul li:nth-child(5) a {
            color: #f5e860;
        }

        .faq-section .faq-content-wrapper .faq-accordion .card {
            border: none;
            position: relative;
            margin-bottom: 20px;
            background: #f1f1f1;
            border-radius: 0px;
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
                                <h2 class="big-title">Faq</h2>
                            </div>
                            <!-- breadcrumb-title - end -->

                            <!-- breadcrumb-list - start -->
                            <div class="breadcrumb-list">
                                <ul>
                                    <li class="breadcrumb-item"><a href="index-1.html" class="breadcrumb-link">Home</a></li>
                                    <li class="breadcrumb-item active" aria-current="page">Faq</li>
                                </ul>
                            </div>
                            <!-- breadcrumb-list - end -->

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <section id="faq-section" class="faq-section sec-ptb-100 clearfix grey-bg">
        <div class="container">
            <div class="faq-content-wrapper mb-80">
                <div class="row justify-content-center">
                    <div class="col-lg-8 col-md-12 col-sm-12">
                        <div id="faq-accordion" class="faq-accordion">
                            <%=StrFAQ %>
                           <%-- <div class="card">
                                <div class="card-header" id="headingone">
                                    <button type="button" class="btn collapsed" data-toggle="collapse" data-target="#collapseone" aria-expanded="true" aria-controls="collapseone">
                                        <span>01.</span>
                                        Do you provide the screening content for the private screenings?
                                
										
                                    </button>
                                </div>

                                <div id="collapseone" class="collapse show" aria-labelledby="headingone" data-parent="#faq-accordion">
                                    <div class="card-body">
                                        Bring people together, or turn your passion into a business. Harmoni gives you everything you need to host your best event yet. lorem ipsum diamet.
										
                                    </div>
                                </div>
                            </div>

                            <div class="card">
                                <div class="card-header" id="headingtwo">
                                    <button type="button" class="btn collapsed" data-toggle="collapse" data-target="#collapsetwo" aria-expanded="false" aria-controls="collapsetwo">
                                        <span>02.</span>
                                        Is alcohol served at Binge Party, and can guests smoke<br>
                                        on the premises?
                                
										
                                    </button>
                                </div>
                                <div id="collapsetwo" class="collapse " aria-labelledby="headingtwo" data-parent="#faq-accordion">
                                    <div class="card-body">
                                        Bring people together, or turn your passion into a business. Harmoni gives you everything you need to host your best event yet. lorem ipsum diamet.
										
                                    </div>
                                </div>
                            </div>

                            <div class="card">
                                <div class="card-header" id="headingthree">
                                    <button type="button" class="btn collapsed" data-toggle="collapse" data-target="#collapsethree" aria-expanded="false" aria-controls="collapsethree">
                                        <span>03.</span>
                                        Are there age restrictions for booking at Binge party?
                                
										
                                    </button>
                                </div>
                                <div id="collapsethree" class="collapse" aria-labelledby="headingthree" data-parent="#faq-accordion">
                                    <div class="card-body">
                                        Bring people together, or turn your passion into a business. Harmoni gives you everything you need to host your best event yet. lorem ipsum diamet.
										
                                    </div>
                                </div>
                            </div>

                            <div class="card">
                                <div class="card-header" id="headingfour">
                                    <button type="button" class="btn collapsed" data-toggle="collapse" data-target="#collapsefour" aria-expanded="false" aria-controls="collapsefour">
                                        <span>04.</span>
                                        Can I bring my pet with me to Binge party?
                                
										
                                    </button>
                                </div>
                                <div id="collapsefour" class="collapse" aria-labelledby="headingfour" data-parent="#faq-accordion">
                                    <div class="card-body">
                                        Bring people together, or turn your passion into a business. Harmoni gives you everything you need to host your best event yet. lorem ipsum diamet.
										
                                    </div>
                                </div>
                            </div>--%>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

