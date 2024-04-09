<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="area-master.aspx.cs" Inherits="Admin_area_master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                        <h4 class="mb-sm-0">Manage Area</h4>
                        <div class="page-title-right">
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item"><a href="/Admin/">Dashboard</a></li>
                                <li class="breadcrumb-item"><a href="javascript: void(0);">Settings</a></li>
                                <li class="breadcrumb-item active">Manage Area</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="mb-sm-0 card-title"><%=Request.QueryString["id"] ==null?"Add New":"Update"%> Area</h4>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-4">
                                    <label class="form-label" for="project-title-input">Select State<sup style="color: red;">*</sup></label>
                                    <asp:DropDownList runat="server" ID="ddlState" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true" CssClass="form-select mb-2">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlState" InitialValue="0" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>

                                </div>
                                <div class="col-lg-4">
                                    <label class="form-label" for="project-title-input">Select City<sup style="color: red;">*</sup></label>
                                    <asp:DropDownList runat="server" ID="ddlCity" CssClass="form-select mb-2">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlCity" InitialValue="0" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>

                                </div>
                                <div class="col-lg-4 mb-3">
                                    <label class="form-label" for="project-title-input">Area Name<sup style="color: red;">*</sup></label>
                                    <asp:TextBox runat="server" MaxLength="100" class="form-control mb-2 mr-sm-2 alphaonly txtName" ID="txtName" placeholder="Enter Area Name" />
                                    <asp:RequiredFieldValidator ID="req1" runat="server" ControlToValidate="txtName" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-4 mb-3">
                                    <label class="form-label" for="project-title-input">Area Url<sup style="color: red;">*</sup></label>
                                    <asp:TextBox runat="server" MaxLength="100" class="form-control mb-2 mr-sm-2 txtURl" ID="txtURl" placeholder="Enter Area Url" />
                                    <asp:RequiredFieldValidator ID="req2" runat="server" ControlToValidate="txtURl" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-4 mb-3">
                                    <label class="text-muted">Thumb Image<sup class="text-danger">*</sup></label>
                                    <asp:FileUpload ID="Thumbimage" runat="server" ToolTip="Maxmimum 1 MB file size" CssClass="form-control"></asp:FileUpload>
                                    <small class="text-danger">.png, .jpeg, .jpg, .gif formats are required, Image Size Should be 250 × 170 px</small><br />
                                    <%=strThumbImage %>
                                </div>
                                <div class="col-lg-4 mb-3">
                                    <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="Save" CssClass="btn btn-danger waves-effect waves-light" style="margin-top: 28px;" OnClick="btnSave_Click" />
                                    <asp:Label ID="lblThumb" runat="server" Visible="false"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card">
                        <div class="card-header">
                            <h4 class="mb-sm-0 card-title">View Area</h4>
                        </div>
                        <div class="card-body table-responsive">
                            <table id="alternative-pagination" class="table nowrap align-middle dt-responsive table-hover" style="width: 100%">
                                <thead>
                                    <tr>
                                        <th>#</th>
                                        <th>Thumb Image</th>
                                        <th>State Name</th>
                                        <th>City Name</th>
                                        <th>Area Name</th>
                                        <th>Last Updated On</th>
                                        <th class="text-center">Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%=strArea %>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th>#</th>
                                        <th>Thumb Image</th>
                                        <th>City Name</th>
                                        <th>Area Name</th>
                                        <th>Last Updated On</th>
                                        <th class="text-center">Action</th>
                                    </tr>
                                </tfoot>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="assets/js/pages/area-master.js"></script>
    <script>
        $(document.body).on("change", '.txtName', function () {
            $(".txtURl").val($(".txtName").val().toLowerCase().replace(/\./g, '').replace(/\//g, '').replace(/\\/g, '').replace(/\*/g, '').replace(/\?/g, '').replace(/\~/g, '').replace(/\ /g, '-'));
        });
    </script>
</asp:Content>

