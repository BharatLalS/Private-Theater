<%@ Page Title="" Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="add-booking-details.aspx.cs" Inherits="add_booking_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
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
            text-transform: uppercase;
            background: #f5e860;
            color: #ffffff !important;
            -webkit-box-shadow: unset !important;
            box-shadow: unset !important;
        }

        .input-group > :not(:first-child):not(.dropdown-menu):not(.valid-tooltip):not(.valid-feedback):not(.invalid-tooltip):not(.invalid-feedback) {
            margin-left: calc(var(--bs-border-width)* -1);
            border-top-left-radius: 50px;
            border-bottom-left-radius: 50px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section id="event-section" class="event-section new-eve bg-gray-light sec-ptb-100 clearfix grey-bg">
        <div class="container">
          
                <div class="row">

                    <div class="col-lg-7 mx-auto">
                          <div class="book-now">
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="row align-items-center">
                                    <div class="col-lg-6 px-4 py-3 side-left">
                                        <h5 class="mb-0"><a href="book-now.aspx"><i class="fas fa-chevron-left mx-2"></i>Add Booking Details</a></h5>
                                    </div>
                                    <div class="col-lg-6 text-end px-4 py-3">
                                        <h3 class="mb-0">Electronic City</h3>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-12 bg-light">
                                <div class="row">
                                    <div class="col-lg-12 text-center py-3">
                                        <p class="cal_date mb-0">
                                            <span class="pe-3">
                                                <i class="far fa-calendar-alt"></i>
                                                30/Mar/2024
                                            </span>
                                            <span>|</span>
                                            <span class="ps-3">
                                                <i class="far fa-clock"></i>
                                                01:15 PM - 03:45 PM, 06:45 PM - 09:15 PM
                                            </span>
                                        </p>
                                    </div>

                                </div>
                            </div>


                        </div>
                        <div class="row px-3 py-4 ">
                            <div class="col-lg-6 pb-3">
                                <label for="Name" class="ps-3 pb-1">Name <span>*</span></label>
                                <div class="input-group mb-0">
                                    <i class="fas fa-user"></i>
                                    <input type="text" placeholder="Name" name="name" value="">
                                </div>
                            </div>
                            <div class="col-lg-6 pb-3">
                                <label for="Name" class="ps-3 pb-1">Email  <span>*</span></label>
                                <div class="input-group mb-0">
                                    <i class="fas fa-envelope"></i>
                                    <input type="Email" placeholder="Email" name="name" value="">
                                </div>
                            </div>
                            <div class="col-lg-6 pb-3">
                                <label for="Name" class="ps-3 pb-1">Phone Number <span>*</span></label>
                                <div class="input-group mb-0">
                                    <i class="fas fa-phone"></i>
                                    <input type="text" placeholder="Name" name="name" value="">
                                </div>
                            </div>
                            <div class="col-lg-6 pb-3">
                                <label for="Name" class="ps-3 pb-1">No of people * <span>*</span></label>
                                <div class="select-group">
                                    <select id="number" class="number_of_people form-select" name="number_of_people">
                                        <option selected="">2</option>
                                    </select>
                                </div>
                            </div>

                        </div>
                        <div class="row  border-top border-bottom border-black">
                            <div class="col-lg-6 px-4 py-3">
                                <h3>Total</h3>
                                <p>
                                    (inclusive of all taxes)
                               
                                </p>
                            </div>
                            <div class="col-lg-6 text-end px-4 py-3">
                                <h2 id="total_amount">₹ 1999</h2>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-lg-12 my-3 text-center">
                                <a href="book-now.aspx" class="custom-btn" tabindex="-1">Book now</a>
                            </div>
                        </div>
                                </div>
                    </div>
                </div>
            </div>

      
    </section>
</asp:Content>

