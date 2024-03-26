<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="theater-timing.aspx.cs" Inherits="Admin_theater_timing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                        <h4 class="mb-sm-0">Manage Theater</h4>
                        <div class="page-title-right">
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item"><a href="/Admin/">Dashboard</a></li>
                                <li class="breadcrumb-item"><a href="javascript: void(0);">Theater</a></li>
                                <li class="breadcrumb-item active">Manage Theater Timing</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="card">
                <div class="card-header">
                    <h4 class="mb-sm-0 card-title"><%=Request.QueryString["id"] ==null?"Add":"Update"%> Theater Timing - <%=StrTheaterName %></h4>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-5 mb-2">
                            <label class="form-label" for="project-title-input">Start Time<sup style="color: red;">*</sup></label>
                            <asp:TextBox runat="server" ID="txtStart" CssClass="form-control txtStart timepicker" placeholder="Start Time"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtStart" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-5 mb-2">
                            <label class="form-label" for="project-title-input">End Time<sup style="color: red;">*</sup></label>
                            <asp:TextBox runat="server" ID="txtEnd" CssClass="form-control txtEnd timepicker" placeholder="End Time"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEnd" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>

                        </div>
                        <div class="col-lg-2 mb-2">
                            <asp:Button runat="server" ID="BtnSave" OnClick="BtnSave_Click" ValidationGroup="Save" Text="Save" Style="margin-top: 28px;" CssClass="btn btn-secondary" OnClientClick="tinyMCE.triggerSave(false,true);" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="card">
                <div class="card-header">
                    <h4 class="mb-sm-0 card-title">View Theater Timing</h4>
                </div>
                <div class="card-body table-responsive">
                    <table id="alternative-pagination" class="table nowrap align-middle dt-responsive table-hover" style="width: 100%">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Theater Name</th>
                                <th>Start Time</th>
                                <th>End Time</th>
                                <th>Last Updated On</th>
                                <th class="text-center">Action</th>
                            </tr>
                        </thead>
                        <tbody>
                              <%=strTheaterList %>
                        </tbody>
                        <tfoot>
                            <tr>
                                <th>#</th>
                                <th>Theater Name</th>
                                <th>Start Time</th>
                                <th>End Time</th>
                                <th>Last Updated On</th>
                                <th class="text-center">Action</th>
                            </tr>
                        </tfoot>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

