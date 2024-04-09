<%@ Page Title="" Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="add-on.aspx.cs" Inherits="add_on" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .default-header-section .header-bottom .menu-item-list ul li:nth-child(2) a {
            color: #f5e860;
        }

        .nav-link {
            position: relative;
            display: inline-block;
            background: #fff;
            height: 40px;
            padding: 0 20px;
            margin-bottom: 0px;
            margin-right: 10px;
            cursor: pointer;
            border: transparent;
            font-size: 14px;
            font-weight: 500;
            color: #000;
        }

        .pl-50 {
            padding-left: 30px;
            position: sticky;
            top: 0;
        }

        .blog-section .blog-layout-menubar li a:hover, .blog-section .blog-layout-menubar li .active {
            color: #fff !important;
        }

        .blog-section .blog-layout-menubar li:hover {
            color: #fff !important;
        }

        .nav-tabs .nav-link {
            border: none;
            border-top-left-radius: unset;
            border-top-right-radius: unset;
        }

        .nav-item {
            margin-right: 20px;
        }

        .nav-tabs .nav-item.show .nav-link, .nav-tabs .nav-link.active {
            background: #5a2d9d;
            color: #fff;
        }

        .nav-tabs {
            border: none;
            border-radius: 50px;
        }

        .tile {
            height: 300px;
            width: 100%;
            position: relative;
            margin-bottom: 10px;
        }

        /*  .tile.new-hei {
                height: 250px;
                width: 170px;
                position: relative;
            }*/

        input[type="checkbox"] {
            -webkit-appearance: none;
            position: relative;
            height: 100%;
            width: 100%;
            background-color: #ffffff;
            border-radius: 10px;
            cursor: pointer;
            outline: none;
        }

            input[type="checkbox"]:after {
                position: absolute;
                font-family: "Font Awesome 5 Free";
                font-weight: 400;
                content: "\f111";
                font-size: 22px;
                top: 10px;
                left: 10px;
                color: #e2e6f3;
            }

            input[type="checkbox"]:checked {
                box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;
            }

                input[type="checkbox"]:checked:after {
                    font-weight: 900;
                    content: "\f058";
                    color: #ffffff;
                }

        label {
            display: flex;
            flex-direction: column;
            align-items: start;
            justify-content: center;
            gap: 12px;
            height: 80%;
            width: 100%;
            position: absolute;
            bottom: 0;
            cursor: pointer;
        }

            label .fas {
                font-size: 60px;
                color: #2c2c51;
            }

        input[type="checkbox"]:checked + label .fas {
            animation: grow 0.5s;
        }

        @keyframes grow {
            50% {
                font-size: 80px;
            }
        }

        label h6 {
            font-size: 15px;
            font-weight: 400;
            color: #7b7b93;
        }

        input:focus,
        select:focus,
        textarea:focus,
        .blog-section .blog-grid-item:hover,
        .event-section .event-list-item:hover,
        .event-section .event-grid-item:hover,
        .event-section .tab-content .event-item:hover,
        .event-section .tab-content .event-item2:hover,
        .homepage3 .event-expertise-section .link-btn a,
        .event-expertise-section2 .expertise-item:hover,
        .main-carousel2 .item .slider-content .details-btn,
        .sticky-header-section .header-bottom .user-search-btn-group ul li > a,
        .upcomming-event-section2 .comming-event-item .event-content .details-btn,
        .upcomming-event-section3 .comming-event-item .event-content .details-btn,
        .sticky-header-section .header-bottom .user-search-btn-group ul li > a,
        .slide-section .main-carousel1 .item .slider-item-content .link-groups .start-btn,
        .scrolltop-fixed-header-section .header-bottom .user-search-btn-group ul li > a,
        .scrolltop-fixed-header-section .header-bottom .user-search-btn-group ul li > a,
        .event-details-section .reviewer-comment-wrapper .comment-bar .comment-content .meta-wrapper .btn-group-right ul li a:hover {
            border-color: unset !important;
        }

        .custom-btn {
            z-index: 1;
            font-weight: 700;
            overflow: hidden;
            padding: 8px 30px;
            text-align: center;
            position: relative;
            border-radius: 50px;
            margin-top: 1.5rem !important;
            display: -webkit-inline-box;
            display: -ms-inline-flexbox;
            display: inline-flex;
            font-size: 16px;
            text-transform: capitalize;
            background: #f5e860;
            color: #ffffff !important;
            -webkit-box-shadow: unset !important;
            box-shadow: unset !important;
        }

            .custom-btn:hover {
                background: unset !important;
            }

        .input-group_1 {
            margin-top: 1.5rem;
            height: 45px;
            width: 100%;
            line-height: 45px;
            border-radius: 50px !important;
            border: 1px solid #e9e9e9 !important;
            position: relative;
            outline: none;
            margin-bottom: 16px !important;
        }

            .input-group_1 i {
                position: absolute;
                top: 15px;
                left: 20px;
            }

            .input-group_1 input {
                height: 45px;
                width: 100%;
                padding-left: 50px;
                border: 1px solid #5a2d9d !important;
                outline: none;
                border-radius: 50px !important;
                background-color: transparent;
            }

        textarea {
            background: #fff;
        }

        .order-summary-table {
            margin-top: 30px;
            padding: 30px;
            border-radius: 3px;
            background-color: #ffffff;
        }

            .order-summary-table .table {
                margin: 0px;
            }

                .order-summary-table .table tr {
                    border: none;
                }



                .order-summary-table .table tr {
                    border: none;
                }

                .order-summary-table .table .tfooter {
                    color: #ffffff;
                    text-transform: capitalize;
                    background: -webkit-gradient(linear, left top, right bottom, from(#ff3e00), to(#ffbe30));
                    background: -webkit-linear-gradient(top left, #ff3e00, #ffbe30);
                    background: -o-linear-gradient(top left, #ff3e00, #ffbe30);
                    background: linear-gradient(to bottom right, #ff3e00, #ffbe30);
                }

                .order-summary-table .table tr th, .booking-section .booking-content-wrapper .order-summary-table .table tr td {
                    border: 0px;
                    padding: 5px;
                    text-align: left;
                    background: #ddd;
                    border-bottom: 1px solid #ddd;
                    color: #000;
                }

        td {
            text-align: left;
            border-bottom: 1px solid #ddd !important;
        }

        .booking-section .booking-content-wrapper .order-summary-table .table thead tr th {
            color: #000;
            TEXT-ALIGN: left;
            font-size: 16px;
            text-transform: capitalize;
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
                                    <div class="tile">
                                        <input type="checkbox" name="party" id="Birthday" />
                                        <label for="Birthday" class="theme-sec">
                                            <img src="assets/images/00icons/addon/1.png" />
                                            <div class="content">
                                                <p>Birthday</p>
                                                <p>₹0</p>
                                                <a class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">know more
                                                </a>
                                            </div>




                                        </label>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-6 col-6">
                                    <div class="tile">
                                        <input type="checkbox" name="party" id="Bride" />
                                        <label for="Bride" class="theme-sec">
                                            <img src="assets/images/00icons/addon/2.png" />
                                            <div class="content">
                                                <p>
                                                    Bride to Be

                                                </p>
                                                <p>₹0</p>
                                                <a class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">know more
                                                </a>
                                            </div>



                                        </label>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-6 col-6">
                                    <div class="tile">
                                        <input type="checkbox" name="party" id="Anniversary" />
                                        <label for="Anniversary" class="theme-sec">
                                            <img src="assets/images/00icons/addon/3.png" />
                                            <div class="content">
                                                <p>Anniversary</p>
                                                <p>₹0</p>
                                                <a class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">know more
                                                </a>
                                            </div>



                                        </label>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-6 col-6">
                                    <div class="tile">
                                        <input type="checkbox" name="party" id="Proposal" />
                                        <label for="Proposal" class="theme-sec">
                                            <img src="assets/images/00icons/addon/4.png" />
                                            <div class="content">
                                                <p>Proposal</p>
                                                <p>₹0</p>
                                                <a class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">know more
                                                </a>
                                            </div>



                                        </label>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-6 col-6">
                                    <div class="tile">
                                        <input type="checkbox" name="party" id="Baby" />
                                        <label for="Baby" class="theme-sec">
                                            <img src="assets/images/00icons/addon/5.png" />
                                            <div class="content">
                                                <p>
                                                    Baby Shower

                                                </p>
                                                <p>₹0</p>
                                                <a class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">know more
                                                </a>
                                            </div>



                                        </label>
                                    </div>
                                </div>

                            </div>
                            <div class="row justify-content-center mt-2">
                                <div class="col-lg-4 col-md-6 col-6">
                                    <a href="#Theme" class="custom-btn" tabindex="-1">Next<i class=" ms-2 mt-1 fas fa-angle-right fa-lg"></i></a>
                                </div>
                            </div>
                            <div class="row mt-4">

                                <div class="order-summary-table table-responsive">
                                    <h4 class="fw-semibold">Selected items</h4>
                                    <table class="table text-center">
                                        <thead>
                                            <tr>
                                                <th scope="col">Item Type	</th>
                                                <th scope="col">Items Name	</th>
                                                <th scope="col">Quantity</th>
                                                <th scope="col">Price</th>
                                                <th scope="col">Total</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr class="bg-gray-light">
                                                <td scope="row">Customizations	</td>
                                                <td>Baby Shower	</td>
                                                <td>1</td>
                                                <td>₹150.00</td>
                                                <td>₹150.00</td>
                                            </tr>
                                            <tr>
                                                <td scope="row">Customizations</td>
                                                <td>Anniversary</td>
                                                <td>2</td>
                                                <td>₹5.00</td>
                                                <td>₹5.00</td>
                                            </tr>

                                        </tbody>
                                    </table>

                                </div>
                            </div>
                            <div class="row mt-4">
                                <textarea placeholder="Add Note Here"></textarea>
                            </div>
                        </div>
                        <div id="Cakes" class="tab-pane fade">
                            <div class="row mt-0 gy-4">

                                <div class="col-lg-4 col-md-6 col-6">
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
                                        <label for="c2" class="theme-sec">
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
                                        <input type="checkbox" name="party" id="c3" />
                                        <label for="c3" class="theme-sec">
                                            <img src="assets/images/00icons/addon/cake/1.png" />
                                            <div class="content">
                                                <p class="cake">
                                                    Red Velvet egg


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
                                        <input type="checkbox" name="party" id="c4" />
                                        <label for="c4" class="theme-sec">
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

                            </div>
                            <div class="row">
                                <div class="col-lg-5 mt-4 mx-auto">
                                    <div class="input-group_1">
                                        <i class="far fa-user"></i>
                                        <input type="text" placeholder="Message on cake" id="nick_name">
                                    </div>
                                </div>
                            </div>
                            <div class="row justify-content-center mt-4">
                                <div class="col-lg-6 text-center">
                                    <a href="#" class="custom-btn" tabindex="-1">Skip<i class=" ms-2 mt-1 fas fa-angle-right fa-lg"></i></a>

                                </div>
                                <div class="col-lg-6 text-center">
                                    <a href="#" class="custom-btn" tabindex="-1">Next<i class=" ms-2 mt-1 fas fa-angle-right fa-lg"></i></a>

                                </div>
                            </div>
                            <div class="row mt-4">

                                <div class="order-summary-table table-responsive">
                                    <h3>Selected items</h3>
                                    <table class="table text-center">
                                        <thead>
                                            <tr>
                                                <th scope="col">Item Type	</th>
                                                <th scope="col">Items Name	</th>
                                                <th scope="col">Quantity</th>
                                                <th scope="col">Price</th>
                                                <th scope="col">Total</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr class="bg-gray-light">
                                                <td scope="row">Customizations	</td>
                                                <td>Baby Shower	</td>
                                                <td>1</td>
                                                <td>₹150.00</td>
                                                <td>₹150.00</td>
                                            </tr>
                                            <tr>
                                                <td scope="row">Customizations</td>
                                                <td>Anniversary</td>
                                                <td>2</td>
                                                <td>₹5.00</td>
                                                <td>₹5.00</td>
                                            </tr>

                                        </tbody>
                                    </table>

                                </div>
                            </div>
                            <div class="row mt-4">
                                <textarea placeholder="Add Note Here"></textarea>
                            </div>
                        </div>
                        <div id="Cake" class="tab-pane fade">
                            <div class="row mt-0 gy-4">
                                <div class="col-lg-4 col-md-6 col-6">
                                    <div class="tile">
                                        <input type="checkbox" name="party" id="Black" />
                                        <label for="Black" class="theme-sec">
                                            <img src="assets/images/00icons/addon/theme/4.png" />
                                            <div class="content">
                                                <p>10 Roses</p>
                                                <p>₹0</p>
                                                <a class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">know more</a>

                                            </div>



                                        </label>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-6 col-6">
                                    <div class="tile">
                                        <input type="checkbox" name="party" id="Black" />
                                        <label for="Black" class="theme-sec">
                                            <img src="assets/images/00icons/addon/theme/4.png" />
                                            <div class="content">
                                                <p>15 Roses</p>
                                                <p>₹0</p>
                                                <a class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">know more</a>

                                            </div>



                                        </label>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-6 col-6">
                                    <div class="tile">
                                        <input type="checkbox" name="party" id="Black" />
                                        <label for="Black" class="theme-sec">
                                            <img src="assets/images/00icons/addon/theme/4.png" />
                                            <div class="content">
                                                <p>15 Roses</p>
                                                <p>₹0</p>
                                                <a class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">know more</a>

                                            </div>



                                        </label>
                                    </div>
                                </div>



                            </div>

                            <div class="row justify-content-center mt-4">
                                <div class="col-lg-6 text-center">
                                    <a href="#" class="custom-btn" tabindex="-1">Skip<i class=" ms-2 mt-1 fas fa-angle-right fa-lg"></i></a>

                                </div>
                                <div class="col-lg-6 text-center">
                                    <a href="#" class="custom-btn" tabindex="-1">Next<i class=" ms-2 mt-1 fas fa-angle-right fa-lg"></i></a>

                                </div>
                            </div>
                            <div class="row mt-4">

                                <div class="order-summary-table table-responsive">
                                    <h3>Selected items</h3>
                                    <table class="table text-center">
                                        <thead>
                                            <tr>
                                                <th scope="col">Item Type	</th>
                                                <th scope="col">Items Name	</th>
                                                <th scope="col">Quantity</th>
                                                <th scope="col">Price</th>
                                                <th scope="col">Total</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr class="bg-gray-light">
                                                <td scope="row">Customizations	</td>
                                                <td>Baby Shower	</td>
                                                <td>1</td>
                                                <td>₹150.00</td>
                                                <td>₹150.00</td>
                                            </tr>
                                            <tr>
                                                <td scope="row">Customizations</td>
                                                <td>Anniversary</td>
                                                <td>2</td>
                                                <td>₹5.00</td>
                                                <td>₹5.00</td>
                                            </tr>

                                        </tbody>
                                    </table>

                                </div>
                            </div>
                            <div class="row mt-4">
                                <textarea placeholder="Add Note Here"></textarea>
                            </div>


                        </div>
                        <div id="Decorations" class="tab-pane fade">
                            <div class="row mt-0 gy-4 ">
                                <h4 class="fw-semibold">Back Drop</h4>

                                <div class="col-lg-4 col-md-6 col-6">
                                    <div class="tile">
                                        <input type="checkbox" name="party" id="d1" />
                                        <label for="d1" class="theme-sec">
                                            <img src="assets/images/00icons/addon/dec/9.png" />
                                            <div class="content">
                                                <p>
                                                    Photo Wall

                                                </p>
                                                <p>₹0</p>
                                                <a class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">know more
                                                </a>
                                            </div>



                                        </label>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-6 col-6">
                                    <div class="tile">
                                        <input type="checkbox" name="party" id="d2" />
                                        <label for="d2" class="theme-sec">
                                            <img src="assets/images/00icons/addon/dec/8.png" />
                                            <div class="content">
                                                <p>
                                                    Decorative floral



                                                </p>
                                                <p>₹0</p>
                                                <a class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">know more
                                                </a>
                                            </div>



                                        </label>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-6 col-6">
                                    <div class="tile">
                                        <input type="checkbox" name="party" id="d3" />
                                        <label for="d3" class="theme-sec">
                                            <img src="assets/images/00icons/addon/dec/7.png" />
                                            <div class="content">
                                                <p>
                                                    Fog Entry

                                                </p>
                                                <p>₹0</p>
                                                <a class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">know more
                                                </a>
                                            </div>



                                        </label>
                                    </div>
                                </div>



                            </div>
                            <div class="row mt-0 gy-4 align-items-center">
                                <h4 class="fw-semibold">Balloon</h4>

                                <div class="col-lg-4 col-md-6 col-6">
                                    <div class="tile">
                                        <input type="checkbox" name="party" id="d1" />
                                        <label for="d1" class="theme-sec">
                                            <img src="assets/images/00icons/addon/dec/9.png" />
                                            <div class="content">
                                                <p>
                                                    Photo Wall

                                                </p>
                                                <p>₹0</p>
                                                <a class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">know more
                                                </a>
                                            </div>



                                        </label>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-6 col-6">
                                    <div class="tile">
                                        <input type="checkbox" name="party" id="d2" />
                                        <label for="d2" class="theme-sec">
                                            <img src="assets/images/00icons/addon/dec/8.png" />
                                            <div class="content">
                                                <p>
                                                    Decorative floral



                                                </p>
                                                <p>₹0</p>
                                                <a class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">know more
                                                </a>
                                            </div>



                                        </label>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-6 col-6">
                                    <div class="tile">
                                        <input type="checkbox" name="party" id="d3" />
                                        <label for="d3" class="theme-sec">
                                            <img src="assets/images/00icons/addon/dec/7.png" />
                                            <div class="content">
                                                <p>
                                                    Fog Entry

                                                </p>
                                                <p>₹0</p>
                                                <a class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">know more
                                                </a>
                                            </div>



                                        </label>
                                    </div>
                                </div>



                            </div>
                            <div class="row mt-0 gy-4 align-items-center">
                                <h4 class="fw-semibold">Add on</h4>

                                <div class="col-lg-4 col-md-6 col-6">
                                    <div class="tile">
                                        <input type="checkbox" name="party" id="d1" />
                                        <label for="d1" class="theme-sec">
                                            <img src="assets/images/00icons/addon/dec/9.png" />
                                            <div class="content">
                                                <p>
                                                    Photo Wall

                                                </p>
                                                <p>₹0</p>
                                                <a class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">know more
                                                </a>
                                            </div>



                                        </label>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-6 col-6">
                                    <div class="tile">
                                        <input type="checkbox" name="party" id="d2" />
                                        <label for="d2" class="theme-sec">
                                            <img src="assets/images/00icons/addon/dec/8.png" />
                                            <div class="content">
                                                <p>
                                                    Decorative floral



                                                </p>
                                                <p>₹0</p>
                                                <a class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">know more
                                                </a>
                                            </div>



                                        </label>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-6 col-6">
                                    <div class="tile">
                                        <input type="checkbox" name="party" id="d3" />
                                        <label for="d3" class="theme-sec">
                                            <img src="assets/images/00icons/addon/dec/7.png" />
                                            <div class="content">
                                                <p>
                                                    Fog Entry

                                                </p>
                                                <p>₹0</p>
                                                <a class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">know more
                                                </a>
                                            </div>



                                        </label>
                                    </div>
                                </div>



                            </div>
                            <div class="row justify-content-center mt-4">
                                <div class="col-lg-6 text-center">
                                    <a href="#" class="custom-btn" tabindex="-1">Skip<i class=" ms-2 mt-1 fas fa-angle-right fa-lg"></i></a>

                                </div>
                                <div class="col-lg-6 text-center">
                                    <a href="#" class="custom-btn" tabindex="-1">Next<i class=" ms-2 mt-1 fas fa-angle-right fa-lg"></i></a>

                                </div>
                            </div>
                            <div class="row mt-4">

                                <div class="order-summary-table table-responsive">
                                    <h3>Selected items</h3>
                                    <table class="table text-center">
                                        <thead>
                                            <tr>
                                                <th scope="col">Item Type	</th>
                                                <th scope="col">Items Name	</th>
                                                <th scope="col">Quantity</th>
                                                <th scope="col">Price</th>
                                                <th scope="col">Total</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr class="bg-gray-light">
                                                <td scope="row">Customizations	</td>
                                                <td>Baby Shower	</td>
                                                <td>1</td>
                                                <td>₹150.00</td>
                                                <td>₹150.00</td>
                                            </tr>
                                            <tr>
                                                <td scope="row">Customizations</td>
                                                <td>Anniversary</td>
                                                <td>2</td>
                                                <td>₹5.00</td>
                                                <td>₹5.00</td>
                                            </tr>

                                        </tbody>
                                    </table>

                                </div>
                            </div>
                            <div class="row mt-4">
                                <textarea placeholder="Add Note Here"></textarea>
                            </div>

                        </div>
                        <div id="foodparty" class="tab-pane fade">
                            <div class="row mt-0 gy-4">
                                <h4 class="fw-semibold">Snacks</h4>
                                <div class="col-lg-4 col-md-6 col-6">
                                    <div class="tile new-hei">
                                        <input type="checkbox" name="party" id="s1" />
                                        <label for="s1" class="theme-sec">
                                            <img src="assets/images/00icons/addon/snacks/10.png" />
                                            <div class="content">
                                                <p class="cake">
                                                    Butter Popcorn




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
                                        <input type="checkbox" name="party" id="s2" />
                                        <label for="s2" class="theme-sec">
                                            <img src="assets/images/00icons/addon/snacks/11.png" />
                                            <div class="content">
                                                <p class="cake">
                                                    Caramel Popcorn




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
                                        <input type="checkbox" name="party" id="s3" />
                                        <label for="s3" class="theme-sec">
                                            <img src="assets/images/00icons/addon/snacks/12.png" />
                                            <div class="content">
                                                <p class="cake">
                                                    Nachos  


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
                                        <input type="checkbox" name="party" id="s4" />
                                        <label for="s4" class="theme-sec">
                                            <img src="assets/images/00icons/addon/snacks/13.png" />
                                            <div class="content">
                                                <p class="cake">
                                                    French Fries




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



                            </div>
                            <div class="row mt-0 gy-4">
                                <h4 class="fw-semibold">Appetizer</h4>
                                <div class="col-lg-4 col-md-6 col-6">
                                    <div class="tile new-hei">
                                        <input type="checkbox" name="party" id="s5" />
                                        <label for="s5" class="theme-sec">
                                            <img src="assets/images/00icons/addon/snacks/10.png" />
                                            <div class="content">
                                                <p class="cake">
                                                    Butter Popcorn




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
                                        <input type="checkbox" name="party" id="s6" />
                                        <label for="s6" class="theme-sec">
                                            <img src="assets/images/00icons/addon/snacks/11.png" />
                                            <div class="content">
                                                <p class="cake">
                                                    Caramel Popcorn




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
                                        <input type="checkbox" name="party" id="s7" />
                                        <label for="s7" class="theme-sec">
                                            <img src="assets/images/00icons/addon/snacks/12.png" />
                                            <div class="content">
                                                <p class="cake">
                                                    Nachos  


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
                                        <input type="checkbox" name="party" id="s8" />
                                        <label for="s8" class="theme-sec">
                                            <img src="assets/images/00icons/addon/snacks/13.png" />
                                            <div class="content">
                                                <p class="cake">
                                                    French Fries




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



                            </div>
                            <div class="row mt-0 gy-4">
                                <h4 class="fw-semibold">Main Course</h4>
                                <div class="col-lg-4 col-md-6 col-6">
                                    <div class="tile new-hei">
                                        <input type="checkbox" name="party" id="s9" />
                                        <label for="s9" class="theme-sec">
                                            <img src="assets/images/00icons/addon/snacks/10.png" />
                                            <div class="content">
                                                <p class="cake">
                                                    Butter Popcorn




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
                                        <input type="checkbox" name="party" id="s10" />
                                        <label for="s10" class="theme-sec">
                                            <img src="assets/images/00icons/addon/snacks/11.png" />
                                            <div class="content">
                                                <p class="cake">
                                                    Caramel Popcorn




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
                                        <input type="checkbox" name="party" id="s11" />
                                        <label for="s11" class="theme-sec">
                                            <img src="assets/images/00icons/addon/snacks/12.png" />
                                            <div class="content">
                                                <p class="cake">
                                                    Nachos  


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
                                        <input type="checkbox" name="party" id="s12" />
                                        <label for="s12" class="theme-sec">
                                            <img src="assets/images/00icons/addon/snacks/13.png" />
                                            <div class="content">
                                                <p class="cake">
                                                    French Fries




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



                            </div>
                            <div class="row mt-0 gy-4">
                                <h4 class="fw-semibold">Beverage</h4>
                                <div class="col-lg-4 col-md-6 col-6">
                                    <div class="tile new-hei">
                                        <input type="checkbox" name="party" id="s9" />
                                        <label for="s9" class="theme-sec">
                                            <img src="assets/images/00icons/addon/snacks/10.png" />
                                            <div class="content">
                                                <p class="cake">
                                                    Butter Popcorn




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
                                        <input type="checkbox" name="party" id="s10" />
                                        <label for="s10" class="theme-sec">
                                            <img src="assets/images/00icons/addon/snacks/11.png" />
                                            <div class="content">
                                                <p class="cake">
                                                    Caramel Popcorn




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
                                        <input type="checkbox" name="party" id="s11" />
                                        <label for="s11" class="theme-sec">
                                            <img src="assets/images/00icons/addon/snacks/12.png" />
                                            <div class="content">
                                                <p class="cake">
                                                    Nachos  


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
                                        <input type="checkbox" name="party" id="s12" />
                                        <label for="s12" class="theme-sec">
                                            <img src="assets/images/00icons/addon/snacks/13.png" />
                                            <div class="content">
                                                <p class="cake">
                                                    French Fries




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



                            </div>
                            <div class="row mt-0 gy-4">
                                <h4 class="fw-semibold">Desserts</h4>
                                <div class="col-lg-4 col-md-6 col-6">
                                    <div class="tile new-hei">
                                        <input type="checkbox" name="party" id="s9" />
                                        <label for="s9" class="theme-sec">
                                            <img src="assets/images/00icons/addon/snacks/10.png" />
                                            <div class="content">
                                                <p class="cake">
                                                    Butter Popcorn




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
                                        <input type="checkbox" name="party" id="s10" />
                                        <label for="s10" class="theme-sec">
                                            <img src="assets/images/00icons/addon/snacks/11.png" />
                                            <div class="content">
                                                <p class="cake">
                                                    Caramel Popcorn




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
                                        <input type="checkbox" name="party" id="s11" />
                                        <label for="s11" class="theme-sec">
                                            <img src="assets/images/00icons/addon/snacks/12.png" />
                                            <div class="content">
                                                <p class="cake">
                                                    Nachos  


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
                                        <input type="checkbox" name="party" id="s12" />
                                        <label for="s12" class="theme-sec">
                                            <img src="assets/images/00icons/addon/snacks/13.png" />
                                            <div class="content">
                                                <p class="cake">
                                                    French Fries




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



                            </div>

                            <div class="row justify-content-center mt-4">
                                <div class="col-lg-6 text-center">
                                    <a href="#" class="custom-btn" tabindex="-1">Skip<i class=" ms-2 mt-1 fas fa-angle-right fa-lg"></i></a>

                                </div>
                                <div class="col-lg-6 text-center">
                                    <a href="#" class="custom-btn" tabindex="-1">Next<i class=" ms-2 mt-1 fas fa-angle-right fa-lg"></i></a>

                                </div>
                            </div>
                            <div class="row mt-4">

                                <div class="order-summary-table table-responsive">
                                    <h3>Selected items</h3>
                                    <table class="table text-center">
                                        <thead>
                                            <tr>
                                                <th scope="col">Item Type	</th>
                                                <th scope="col">Items Name	</th>
                                                <th scope="col">Quantity</th>
                                                <th scope="col">Price</th>
                                                <th scope="col">Total</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr class="bg-gray-light">
                                                <td scope="row">Customizations	</td>
                                                <td>Baby Shower	</td>
                                                <td>1</td>
                                                <td>₹150.00</td>
                                                <td>₹150.00</td>
                                            </tr>
                                            <tr>
                                                <td scope="row">Customizations</td>
                                                <td>Anniversary</td>
                                                <td>2</td>
                                                <td>₹5.00</td>
                                                <td>₹5.00</td>
                                            </tr>

                                        </tbody>
                                    </table>

                                </div>
                            </div>
                            <div class="row mt-4">
                                <textarea placeholder="Add Note Here"></textarea>
                            </div>
                        </div>
                        <div id="Ballon" class="tab-pane fade">
                            <div class="row mt-0 gy-4">
                                <div class="col-lg-4 col-md-6 col-6">
                                    <div class="tile">
                                        <input type="checkbox" name="party" id="r1" />
                                        <label for="r1" class="theme-sec">
                                            <img src="assets/images/00icons/addon/baloon/1.png" />
                                            <div class="content">
                                                <p>Round</p>
                                                <p>₹0</p>
                                            </div>



                                        </label>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-6 col-6">
                                    <div class="tile">
                                        <input type="checkbox" name="party" id="r2" />
                                        <label for="r2" class="theme-sec">
                                            <img src="assets/images/00icons/addon/baloon/2.png" />
                                            <div class="content">
                                                <p>
                                                    Heart

                                                </p>
                                                <p>₹0</p>
                                            </div>



                                        </label>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-6 col-6">
                                    <div class="tile">
                                        <input type="checkbox" name="party" id="r3" />
                                        <label for="r3" class="theme-sec">
                                            <img src="assets/images/00icons/addon/baloon/3.png" />
                                            <div class="content">
                                                <p>Square</p>
                                                <p>₹0</p>
                                            </div>



                                        </label>
                                    </div>
                                </div>


                            </div>
                            <div class="row mt-4">

                                <div class="order-summary-table table-responsive">
                                    <h3>Selected items</h3>
                                    <table class="table text-center">
                                        <thead>
                                            <tr>
                                                <th scope="col">Item Type	</th>
                                                <th scope="col">Items Name	</th>
                                                <th scope="col">Quantity</th>
                                                <th scope="col">Price</th>
                                                <th scope="col">Total</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr class="bg-gray-light">
                                                <td scope="row">Customizations	</td>
                                                <td>Baby Shower	</td>
                                                <td>1</td>
                                                <td>₹150.00</td>
                                                <td>₹150.00</td>
                                            </tr>
                                            <tr>
                                                <td scope="row">Customizations</td>
                                                <td>Anniversary</td>
                                                <td>2</td>
                                                <td>₹5.00</td>
                                                <td>₹5.00</td>
                                            </tr>

                                        </tbody>
                                    </table>

                                </div>
                            </div>
                            <div class="row mt-4">
                                <textarea placeholder="Add Note Here"></textarea>
                            </div>
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
                                    <p class="fw-semibold">₹1899</p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-8 text-start">
                                    <p>
                                        Additional People Amount

                                    </p>
                                </div>
                                <div class="col-lg-4 text-end">
                                    <p class="fw-semibold">
                                        ₹0

                                    </p>
                                </div>
                            </div>
                            <div class="total">
                                <div class="row align-items-center">
                                    <div class="col-lg-8 text-start gtotal">
                                        <p class="fw-semibold">Total</p>
                                        <span>(Excluded of Gst)</span>
                                    </div>
                                    <div class="col-lg-4 text-end">
                                        <p class="grand-total">₹1899</p>
                                    </div>
                                </div>
                            </div>
                            <div class="row justify-content-center align-items-center">
                                <div class="col-lg-12">
                                    <a href="#" class="new-term" data-toggle="modal" data-target="#exampleModal1">payment terms  </a>
                                </div>
                                <div class="col-lg-12">
                                    <a href="#" class="custom-btn" tabindex="-1">Pay  </a>
                                </div>
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
</asp:Content>

