<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="manage-faq.aspx.cs" Inherits="Admin_manage_faq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                        <h4 class="mb-sm-0">Manage FAQs</h4>
                        <div class="page-title-right">
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item"><a href="/Admin/">Dashboard</a></li>
                                <li class="breadcrumb-item"><a href="javascript: void(0);">FAQ</a></li>
                                <li class="breadcrumb-item active">Manage FAQs</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6">
                    <div class="card">
                        <div class="card-header">
                            <h5 class="card-title"><%=Request.QueryString["id"] ==null?"Add ":"Update"%>  FAQ</h5>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-12">
                                    <label>Question<sup>*</sup></label>
                                    <asp:TextBox runat="server" MaxLength="100" class="form-control mb-2 mr-sm-2" ID="txtPosted" />
                                    <asp:RequiredFieldValidator ID="req1" runat="server" ControlToValidate="txtPosted" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-12">
                                    <label>FAQ Desc<sup>*</sup></label>
                                    <asp:TextBox runat="server" CssClass="form-control mb-2 mr-sm-2 summernote" TextMode="MultiLine" ID="txtDesc"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDesc" Display="Dynamic" ForeColor="Red" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-12">
                                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-secondary" Text="Save" ValidationGroup="Save" OnClick="btnSave_Click" Style="margin-top: 15px;" />
                                    <asp:Button runat="server" ID="addFAQ" CssClass="btn btn-outline-secondary" Text="Add FAQ" Visible="false" OnClick="addFAQ_Click" Style="margin-top: 15px;" />
                                </div>
                                <div class="col-lg-12 mt-2">
                                    <p style="color: red; font-weight: bold;">Note : <sup>*</sup> are required fields</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            
                <div class="col-lg-6">
                    <div class="card">
                        <div class="card-header">
                            <h5 class="card-title">Manage FAQs</h5>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="table-responsive">
                                        <table class="table nowrap align-middle dt-responsive table-hover" style="width: 100%">
                                            <thead>
                                                <tr>
                                                    <th>#</th>
                                                    <th>Question</th>
                                                    <th>Added On</th>
                                                    <th class="text-center">Action</th>
                                                </tr>
                                            </thead>
                                            <tbody id="tbdy">
                                                <%=strFAQs %>
                                            </tbody>
                                            <tfoot>
                                                <tr>
                                                    <th>#</th>
                                                    <th>Question</th>
                                                    <th>Added On</th>
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
            </div>
        </div>
    </div>
    <script src="assets/js/pages/manage-FAQs.js"></script>

</asp:Content>

