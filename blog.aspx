<%@ Page Title="" Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="blog.aspx.cs" Inherits="blog" %>

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
            text-transform: capitalize;
            background: #f5e860;
            color: #ffffff !important;
            -webkit-box-shadow: unset !important;
            box-shadow: unset !important;
        }
        .blog-section .blog-layout-menubar li a:hover, .blog-section .blog-layout-menubar li .active {
    color: #fff !important;
}
        .blog-section .layout-btn-group {
    width: 100%;
    display: table;
    margin-bottom: 30px;
    padding-bottom: 15px;
    border-bottom: 2px solid #f0f0f0;
}
        .blog-section .blog-grid-item:hover{
            border:none !important;
        }
          
       .default-header-section .header-bottom .menu-item-list ul li:nth-child(4) a {
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
                                <h2 class="big-title">Blog</h2>
                            </div>
                            <!-- breadcrumb-title - end -->

                            <!-- breadcrumb-list - start -->
                            <div class="breadcrumb-list">
                                <ul>
                                    <li class="breadcrumb-item"><a href="index-1.html" class="breadcrumb-link">Home</a></li>
                                    <li class="breadcrumb-item active" aria-current="page">Blog</li>
                                </ul>
                            </div>
                            <!-- breadcrumb-list - end -->

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section id="blog-section" class="blog-section sec-ptb-100 clearfix">
        <div class="container">
            
                    <div class="row">

                        <!-- blog-grid-item - start -->
                        <div class="col-lg-4 col-md-6 col-sm-12">
                            <div class="blog-grid-item">

                              

                                <div class="blog-image">
                                    <img src="assets/images/00icons/blog/1.png" alt="Image_not_found">
                                    <a href="blog-details.aspx"></a>
                                </div>

                                <div class="blog-content">

                                    <h4 class="blog-title">A Movie Close To My Heart – Yeh Jawani Hai Diwani			</h4>
                                    <p href="#!" class="">
                                        26 may 2018 - 4.00 PM
                                    </p>
                                   
                                    <a href="blog-details.aspx" class="custom-btn">Read More
                                    </a>
                                </div>

                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6 col-sm-12">
    <div class="blog-grid-item">

      

        <div class="blog-image">
            <img src="assets/images/00icons/blog/1.png" alt="Image_not_found">
            <a href="blog-details.aspx"></a>
        </div>

        <div class="blog-content">

            <h4 class="blog-title">A Movie Close To My Heart – Yeh Jawani Hai Diwani			</h4>
            <p href="#!" class="">
                26 may 2018 - 4.00 PM
            </p>
           
            <a href="blog-details.aspx" class="custom-btn">Read More
            </a>
        </div>

    </div>
</div><div class="col-lg-4 col-md-6 col-sm-12">
    <div class="blog-grid-item">

      

        <div class="blog-image">
            <img src="assets/images/00icons/blog/1.png" alt="Image_not_found">
            <a href="blog-details.aspx"></a>
        </div>

        <div class="blog-content">

            <h4 class="blog-title">A Movie Close To My Heart – Yeh Jawani Hai Diwani			</h4>
            <p href="#!" class="">
                26 may 2018 - 4.00 PM
            </p>
           
            <a href="blog-details.aspx" class="custom-btn">Read More
            </a>
        </div>

    </div>
</div>

                        <!-- pagination - start -->
                        <div class="col-lg-12 col-md-12 col-sm-12">
                            <div class="pagination ul-li clearfix">
                                <ul>
                                    <li class="page-item prev-item">
                                        <a class="page-link" href="#!">Prev</a>
                                    </li>
                                    <li class="page-item"><a class="page-link" href="#!">01</a></li>
                                    <li class="page-item active"><a class="page-link" href="#!">02</a></li>
                                    <li class="page-item"><a class="page-link" href="#!">03</a></li>
                                    <li class="page-item"><a class="page-link" href="#!">04</a></li>
                                    <li class="page-item"><a class="page-link" href="#!">05</a></li>
                                    <li class="page-item next-item">
                                        <a class="page-link" href="#!">Next</a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <!-- pagination - end -->

                    </div>
                </div>
             
             
    </section>
</asp:Content>

