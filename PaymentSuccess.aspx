<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PaymentSuccess.aspx.cs" Inherits="PaymentSuccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .pt-200 {
            padding-top: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section id="error-section" class="error-section sec-ptb-100  clearfix pt-200">

        <div id="columns" class="columns-container section-padding-md">
            <!-- container -->
            <div class="container">
                <div class="row justify-content-center">

                    <!-- error-content - start -->
                    <div class="col-lg-3 col-md-6 col-sm-6">
                        <img src="assets/images/success.gif">
                    </div>
                    <!-- error-content - end -->

                    <!-- error-content - start -->
                    <div class="col-lg-6 col-md-6 col-sm-12">
                        <div class="error-content">
                            <h2>Thank you</h2>
                            <p class="mb-30">
                                Your Booking Was Successfully Completed.<br>
                                Your Booking Id Is - <strong> <%=StrOrderID %></strong>
                            </p>
                            <a href="/" class="custom-btn">go back to home</a>
                        </div>
                    </div>
                    <!-- error-content - end -->

                </div>
            </div>
            <!-- end container -->
        </div>
    </section>
</asp:Content>
