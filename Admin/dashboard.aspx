<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="dashboard.aspx.cs" Inherits="Admin_dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        span.clsord {
            text-align: center !important;
        }

        .filterRev.selected {
            background: #3577f1 !important;
            color: #fff !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <div class="container-fluid">

            <!-- start page title -->
            <div class="row">
                <div class="col-12">
                    <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                        <h4 class="mb-sm-0">Dashboard</h4>

                        <div class="page-title-right">
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item"><a href="javascript: void(0);">Dashboards</a></li>
                                <li class="breadcrumb-item active">Dashboard</li>
                            </ol>
                        </div>

                    </div>
                </div>
            </div>
            <!-- end page title -->

            <div class="row">
                <div class="col">

                    <div class="h-100">
                        <div class="row mb-3 pb-1">
                            <div class="col-12">
                                <div class="d-flex align-items-lg-center flex-lg-row flex-column">
                                    <div class="flex-grow-1">
                                        <h4 class="fs-16 mb-1"><%=StrWish %>, <%=Strusername %>!</h4>
                                        <p class="text-muted mb-0">Here's what's happening with your store today.</p>
                                    </div>
                                    <div class="mt-3 mt-lg-0">
                                        <form action="javascript:void(0);">
                                            <div class="row g-3 mb-0 align-items-center">
                                                <%--<div class="col-sm-auto">
                                                    <div class="input-group">
                                                        <input type="text" class="form-control border-0 dash-filter-picker shadow" data-provider="flatpickr" data-range-date="true" data-date-format="d M, Y" data-deafult-date="<%=StrPresentdate %>">
                                                        <div class="input-group-text bg-primary border-primary text-white">
                                                            <i class="ri-calendar-2-line"></i>
                                                        </div>
                                                    </div>
                                                </div>--%>
                                                <!--end col-->

                                                <div class="col-auto">
                                                    <a href="view-all.aspx" class="btn btn-soft-danger shadow-none"><i class="ri-message-2-line align-middle me-1"></i>View Architects</a>
                                                </div>

                                                <!--end col-->
                                            </div>
                                            <!--end row-->
                                        </form>
                                    </div>
                                </div>
                                <!-- end card header -->
                            </div>
                            <!--end col-->
                        </div>
                        <!--end row-->

                        <div class="row">
                            <div class="col-xl-3 col-md-6">
                                <!-- card -->
                                <div class="card card-animate">
                                    <div class="card-body">
                                        <div class="d-flex align-items-center">
                                            <div class="flex-grow-1 overflow-hidden">
                                                <p class="text-uppercase fw-medium text-muted text-truncate mb-0">Total Customers</p>
                                            </div>
                                            <%--<div class="flex-shrink-0">
                                                <h5 class="text-success fs-14 mb-0">
                                                    <i class="ri-arrow-right-up-line fs-13 align-middle"></i>+16.24 %
                                                        </h5>
                                            </div>--%>
                                        </div>
                                        <div class="d-flex align-items-end justify-content-between mt-4">
                                            <div>
                                                <h4 class="fs-22 fw-semibold ff-secondary mb-4"><span class="counter-value" data-target="<%=StrCustomerCnt %>"><%=StrCustomerCnt %></span> </h4>
                                                <a href="view-all-customers.aspx" class="text-decoration-underline">View All Customers</a>
                                            </div>
                                            <div class="avatar-sm flex-shrink-0">
                                                <span class="avatar-title bg-warning rounded fs-3">
                                                    <i class="bx bx-user-circle"></i>
                                                </span>
                                            </div>

                                        </div>
                                    </div>
                                    <!-- end card body -->
                                </div>
                                <!-- end card -->
                            </div>
                            <!-- end col -->
                            <div class="col-xl-3 col-md-6">
                                <!-- card -->
                                <div class="card card-animate">
                                    <div class="card-body">
                                        <div class="d-flex align-items-center">
                                            <div class="flex-grow-1 overflow-hidden">
                                                <p class="text-uppercase fw-medium text-muted text-truncate mb-0">Total Architects</p>
                                            </div>

                                        </div>
                                        <div class="d-flex align-items-end justify-content-between mt-4">
                                            <div>
                                                <h4 class="fs-22 fw-semibold ff-secondary mb-4"><span class="counter-value" data-target="<%=strTotalArct %>"><%=strTotalArct %></span> </h4>
                                                <a href="/Admin/view-all.aspx" class="text-decoration-underline">View Architects</a>
                                            </div>
                                            <div class="avatar-sm flex-shrink-0">
                                                <span class="avatar-title bg-success rounded fs-3">
                                                    <i class="bx bx-package"></i>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- end card body -->
                                </div>
                                <!-- end card -->
                            </div>
                            <!-- end col -->

                            <div class="col-xl-3 col-md-6">
                                <!-- card -->
                                <div class="card card-animate">
                                    <div class="card-body">
                                        <div class="d-flex align-items-center">
                                            <div class="flex-grow-1 overflow-hidden">
                                                <p class="text-uppercase fw-medium text-muted text-truncate mb-0">Orders</p>
                                            </div>

                                        </div>
                                        <div class="d-flex align-items-end justify-content-between mt-4">
                                            <div>
                                                <h4 class="fs-22 fw-semibold ff-secondary mb-4"><span class="counter-value" data-target="<%=StrTotalOrders %>"><%=StrTotalOrders %></span></h4>
                                                <a href="/Admin/order-reports.aspx" class="text-decoration-underline">View Orders</a>
                                            </div>
                                            <div class="avatar-sm flex-shrink-0">
                                                <span class="avatar-title bg-info rounded fs-3">
                                                    <i class="bx bx-shopping-bag"></i>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- end card body -->
                                </div>
                                <!-- end card -->
                            </div>
                            <!-- end col -->

                            <!-- end col -->

                            <div class="col-xl-3 col-md-6">
                                <!-- card -->
                                <div class="card card-animate">
                                    <div class="card-body">
                                        <div class="d-flex align-items-center">
                                            <div class="flex-grow-1 overflow-hidden">
                                                <p class="text-uppercase fw-medium text-muted text-truncate mb-0">Today's Orders</p>
                                            </div>

                                        </div>
                                        <div class="d-flex align-items-end justify-content-between mt-4">
                                            <div>
                                                <h4 class="fs-22 fw-semibold ff-secondary mb-4"><span class="counter-value" data-target="<%=StrTdyOrd %>"><%=StrTdyOrd %></span></h4>
                                                <a href="/Admin/order-reports.aspx?id=tdy" class="text-decoration-underline">Today's Orders</a>
                                            </div>
                                            <div class="avatar-sm flex-shrink-0">
                                                <span class="avatar-title bg-success rounded fs-3">
                                                    <i class="bx bx-rupee"></i>
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- end card body -->
                                </div>
                                <!-- end card -->
                            </div>
                            <!-- end col -->
                        </div>
                        <!-- end row-->
            <div class="row">
                            <div class="col-xl-8">
                                <div class="card">
                                    <div class="card-header border-0 align-items-center d-flex">
                                        <h4 class="card-title mb-0 flex-grow-1">Revenue</h4>
                                        <div>
                                            <button type="button" class="btn btn-soft-secondary btn-sm shadow-none filterRev" data-val="All">
                                                ALL
                                                   
                                            </button>
                                            <button type="button" class="btn btn-soft-secondary btn-sm shadow-none filterRev" data-val="1M">
                                                1M
                                                   
                                            </button>
                                            <button type="button" class="btn btn-soft-secondary btn-sm shadow-none filterRev" data-val="6M">
                                                6M
                                                   
                                            </button>
                                            <button type="button" class="btn btn-soft-primary btn-sm shadow-none filterRev selected" data-val="1Y">
                                                1Y 
                                            </button>
                                        </div>
                                    </div>
                                    <!-- end card header -->

                                    <div class="card-header p-0 border-0 bg-soft-light">
                                        <div class="row g-0 text-center">
                                            <div class="col-6 col-sm-3">
                                                <div class="p-3 border border-dashed border-start-0">
                                                    <h5 class="mb-1"><span class="counter-value totalSales" data-target="0">0</span></h5>
                                                    <p class="text-muted mb-0">Total Sales</p>
                                                </div>
                                            </div>
                                            <!--end col-->
                                            <div class="col-6 col-sm-3">
                                                <div class="p-3 border border-dashed border-start-0">
                                                    <h5 class="mb-1">₹<span class="counter-value confirmedSale" data-target="0">0</span></h5>
                                                    <p class="text-muted mb-0">Confirmed Sales</p>
                                                </div>
                                            </div>
                                            <!--end col-->
                                            <div class="col-6 col-sm-3">
                                                <div class="p-3 border border-dashed border-start-0">
                                                    <h5 class="mb-1"> ₹<span class="counter-value initiatedSale" data-target="0">0</span></h5>
                                                    <p class="text-muted mb-0">Initiated Sales</p>
                                                </div>
                                            </div>
                                            <!--end col-->
                                            <div class="col-6 col-sm-3">
                                                <div class="p-3 border border-dashed border-start-0 border-end-0">
                                                    <h5 class="mb-1 text-success"><span class="counter-value convRatio" data-target="0">0</span>%</h5>
                                                    <p class="text-muted mb-0">Conversation Ratio</p>
                                                </div>
                                            </div>
                                            <!--end col-->
                                        </div>
                                    </div>
                                    <!-- end card header -->

                                    <div class="card-body p-0 pb-2">
                                        <div class="w-100">
                                            <div id="customer_impression_charts" data-colors='["--vz-success", "--vz-primary", "--vz-danger"]' class="apex-charts" dir="ltr"></div>
                                        </div>
                                    </div>
                                    <!-- end card body -->
                                </div>
                                <!-- end card -->
                            </div>
                            <div class="col-xl-4">
                                <div class="card card-height-100">
                                    <div class="card-header align-items-center d-flex">
                                        <h4 class="card-title mb-0 flex-grow-1">Payment Status</h4>
                                        <%--<div class="flex-shrink-0">
                                            <div class="dropdown card-header-dropdown">
                                                <a class="text-reset dropdown-btn" href="#" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                                    <span class="text-muted">Report<i class="mdi mdi-chevron-down ms-1"></i></span>
                                                </a>
                                                <div class="dropdown-menu dropdown-menu-end">
                                                    <a class="dropdown-item" href="#">Download Report</a>
                                                    <a class="dropdown-item" href="#">Export</a>
                                                    <a class="dropdown-item" href="#">Import</a>
                                                </div>
                                            </div>
                                        </div>--%>
                                    </div>
                                    <!-- end card header -->

                                    <div class="card-body">
                                        <div id="store-visits-source" class="apex-charts" dir="ltr"></div>
                                    </div>
                                </div>
                                <!-- .card-->
                            </div>
                        </div>


                        <!-- end row-->

                        <div class="row">

                            <!-- .col-->

                            <div class="col-xl-12">
                                <div class="card">
                                    <div class="card-header align-items-center d-flex">
                                        <h4 class="card-title mb-0 flex-grow-1">Recent Orders</h4>
                                        <div class="flex-shrink-0">
                                            <button type="button" class="btn btn-soft-info btn-sm shadow-none">
                                                <i class="ri-file-list-3-line align-middle"></i><a href="/admin/order-reports.aspx"> View Reports</a>

                                            </button>
                                        </div>
                                    </div>
                                    <!-- end card header -->

                                    <div class="card-body">
                                        <div class="table-responsive table-card">
                                            <table class="table table-borderless table-centered align-middle table-nowrap mb-0">
                                                <thead class="text-muted table-light">
                                                    <tr>
                                                        <th>#</th>
                                                        <th>Architect Name</th>
                                                        <th>Mobile No</th>
                                                        <th>Total Amount</th>
                                                        <th>Commision Percentage</th>
                                                        <th>Commision Earned</th>
                                                        <th>Total Customers</th>
                                                        <th>Total Orders </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                       <%=strOrders %>
                                                   <%-- <tr>
                                                        <td>
                                                            <a href='apps-ecommerce-order-details.html' class='fw-medium link-primary'>#VZ2112</a>
                                                        </td>

                                                        <td>Madeena
                                                        </td>

                                                        <td>Madeena@nextwebi.in
                                                        </td>

                                                        <td>9505840311
                                                        </td>
                                                        <td>Nextwebi
                                                        </td>
                                                        <td>
                                                            <h5 class="fs-14 fw-medium mb-0">10</h5>
                                                        </td>
                                                        <td>
                                                            <h5 class="fs-14 fw-medium mb-0">10</h5>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <a href='apps-ecommerce-order-details.html' class='fw-medium link-primary'>#VZ2112</a>
                                                        </td>
                                                        <td>Nikita
                                                        </td>

                                                        <td>nikta@nextwebi.in
                                                        </td>

                                                        <td>950584311
                                                        </td>
                                                        <td>Nextwebi
                                                        </td>
                                                        <td>
                                                            <h5 class="fs-14 fw-medium mb-0">10</h5>
                                                        </td>
                                                        <td>
                                                            <h5 class="fs-14 fw-medium mb-0">10</h5>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <a href='apps-ecommerce-order-details.html' class='fw-medium link-primary'>#VZ2113</a>
                                                        </td>
                                                        <td>Sam
                                                        </td>

                                                        <td>sam@nextwebi.in
                                                        </td>

                                                        <td>950584311
                                                        </td>
                                                        <td>Nextwebi
                                                        </td>
                                                        <td>
                                                            <h5 class="fs-14 fw-medium mb-0">10</h5>
                                                        </td>
                                                        <td>
                                                            <h5 class="fs-14 fw-medium mb-0">10</h5>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <a href='apps-ecommerce-order-details.html' class='fw-medium link-primary'>#VZ2114</a>
                                                        </td>
                                                        <td>Priyanka
                                                        </td>

                                                        <td>Priyanka@nextwebi.in
                                                        </td>

                                                        <td>950584311
                                                        </td>
                                                        <td>Nextwebi
                                                        </td>
                                                        <td>
                                                            <h5 class="fs-14 fw-medium mb-0">10</h5>
                                                        </td>
                                                        <td>
                                                            <h5 class="fs-14 fw-medium mb-0">10</h5>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <a href='apps-ecommerce-order-details.html' class='fw-medium link-primary'>#VZ2115</a>
                                                        </td>
                                                        <td>Nandhini
                                                        </td>

                                                        <td>Nandhini@nextwebi.in
                                                        </td>

                                                        <td>950584311
                                                        </td>
                                                        <td>Nextwebi
                                                        </td>
                                                        <td>
                                                            <h5 class="fs-14 fw-medium mb-0">10</h5>
                                                        </td>
                                                        <td>
                                                            <h5 class="fs-14 fw-medium mb-0">10</h5>
                                                        </td>
                                                    </tr>--%>
                                                </tbody>
                                                <!-- end tbody -->
                                            </table>
                                            <!-- end table -->
                                        </div>
                                    </div>
                                </div>
                                <!-- .card-->
                            </div>
                            <!-- .col-->
                        </div>
                        <!-- end row-->

                    </div>
                    <!-- end .h-100-->

                </div>
                <!-- end col -->


                <!-- end col -->
            </div>

        </div>
        <!-- container-fluid -->
    </div>
    <script src="assets/js/jquery-3.6.0.min.js"></script>
          <script src="assets/libs/apexcharts/apexcharts.min.js"></script>
    <script src="assets/js/pages/dashboard-ecommerce.init.js"></script>
</asp:Content>

