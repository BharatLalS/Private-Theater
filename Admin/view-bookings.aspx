<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="view-bookings.aspx.cs" Inherits="Admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .fs-option:hover {
            background-color: #426cb4 !important;
            color: white !important;
        }

        .fs-wrap.multiple .fs-option {
            background: White;
            color: #000;
        }

        .fs-option.selected {
            background-color: #426cb4 !important;
            color: white !important;
        }

        .lblcount {
            visibility: hidden;
        }

        .pageLenght {
            width: 80px;
            padding: 5px;
            margin: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                        <h4 class="mb-sm-0">View Bookings</h4>
                        <div class="page-title-right">
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item"><a href="/Admin/">Dashboard</a></li>
                                <li class="breadcrumb-item"><a href="javascript: void(0);">Reports</a></li>
                                <li class="breadcrumb-item active">View Bookings</li>
                            </ol>
                        </div>

                    </div>
                </div>
            </div>
        </div>
                <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header align-items-center d-flex">
                            <h4 class="card-title d-flex justify-content-between mb-0 flex-grow-1">View Bookings</h4>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-3 mt-2">
                                    <asp:TextBox runat="server" name="txtSearch" type="text" MaxLength="100" ID="txtSearch" CssClass="txtSearch form-control mb-2 mr-sm-2" placeholder="Search by Booking Id/Name/Email"></asp:TextBox>
                                </div>
                                <div class="col-lg-2 mt-2">
                                    <asp:DropDownList runat="server" name="ddlDay" ID="ddlDay" maxlength="100" class="ddlDay form-control mb-2 mr-sm-2 fSelect">
                                        <asp:ListItem Value="0">All Bookings</asp:ListItem>
                                        <asp:ListItem Value="1">Today's Bookings</asp:ListItem>
                                        <asp:ListItem Value="7">Next 7 Day's Bookings</asp:ListItem>
                                        <asp:ListItem Value="30">Next 30 Day's Bookings</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-lg-2 mt-2">
                                    <asp:TextBox runat="server" name="txtFrom" type="text" ID="txtFrom" placeholder="From Date" class="txtFrom form-control mb-2 mr-sm-2 datepicker flatpickr-input"></asp:TextBox>
                                </div>
                                <div class="col-lg-2 mt-2">
                                    <asp:TextBox runat="server" name="txtTo" type="text" ID="txtTo" placeholder="To Date" class="txtTo form-control mb-2 mr-sm-2 datepicker flatpickr-input"></asp:TextBox>
                                </div>
                                <div class="col-lg-3 mt-2">
                                    <asp:DropDownList runat="server" name="ddlStatus" ID="ddlStatus" CssClass="ddlStatus form-control mb-2 mr-sm-2 fSelect">
                                        <asp:ListItem Value="0">Select Booking Status</asp:ListItem>
                                        <asp:ListItem Value="Initiated">Initiated</asp:ListItem>
                                        <asp:ListItem Value="Completed">Completed</asp:ListItem>
                                        <asp:ListItem Value="Failed">Failed</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                            </div>
                            <div class="row mt-2">
                                <div class="col-lg-12">
                                    <asp:Button runat="server" name="btnSearch" Text="Search" ID="btnSearch" class="btnSearch btn btn-secondary" />
                                    <asp:Button runat="server" name="btnExport" Text="Export To Excel" ID="btnExport" class="btnExport btn btn-success" />
                                </div>

                            </div>
                        </div>
                    </div>

                </div>
                <div class="col-lg-12">

                    <div class="card">
                        <div class="card-body">
                            <div class="row mt-2">
                                <div class="col-lg-6 d-flex">
                                    <label style="margin-top: 10px;">Show </label>
                                    <select name="pageLenght" class="form-select form-select-sm pageLenght">
                                        <option value="10">10</option>
                                        <option value="25">25</option>
                                        <option value="50">50</option>
                                        <option value="100">100</option>
                                    </select>
                                    <label style="margin-top: 10px;">entries</label>
                                </div>
                            </div>
                            <div class="table-responsive">

                                <table id="alternative-pagination" class="table align-middle table-nowrap table-striped table-bordered " style="width: 100%">
                                    <thead>
                                        <tr>
                                            <th>#</th>
                                            <th>Booking Id</th>
                                            <th>Booking Date</th>
                                            <th>Name</th>
                                            <th>Email Id</th>
                                            <th>Phone No.</th>
                                            <th>Booking Status</th>
                                            <th>Booking On</th>
                                            <th>Payment Status</th>
                                            <th>Payment Id</th>
                                            <th>Total Price</th>
                                        </tr>
                                    </thead>
                                    <tbody class="strTable">
                                    </tbody>
                                </table>
                            </div>
                            <nav aria-label="Page navigation" class="mt-2">
                                <ul class=" mppagination pagination justify-content-center">
                                </ul>
                            </nav>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
    <script src="assets/js/pages/view-bookings.js"></script>
</asp:Content>

