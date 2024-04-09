<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="add-testimonial.aspx.cs" Inherits="Admin_add_testimonial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                        <h4 class="mb-sm-0"><%=Request.QueryString["id"] !=null?"Update":"Add" %> Testimonial</h4>

                        <div class="page-title-right">
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item"><a href="javascript: void(0);">Dashboards</a></li>
                                <li class="breadcrumb-item active"><%=Request.QueryString["id"] !=null?"Update":"Add" %> Testimonial</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-9">
                    <div class="card">
                        <div class="card-header">
                            <h5 class="card-title"><%=Request.QueryString["id"] !=null?"Update":"Add" %> Testimonial</h5>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-6 mb-2">
                                    <label class="text-muted">Posted By<sup class="text-danger">*</sup></label>
                                    <asp:TextBox runat="server" MaxLength="100" class="form-control mb-2 mr-sm-2" ID="txtPosted" placeholder="Posted By" />
                                    <asp:RequiredFieldValidator ID="req1" runat="server" ControlToValidate="txtPosted" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>

                                </div>
                              <%--  <div class="col-lg-6 mb-2">
                                    <label class="text-muted">Designation<sup class="text-danger">*</sup></label>
                                    <asp:TextBox runat="server" MaxLength="100" class="form-control mb-2 mr-sm-2" ID="txtDesignation" placeholder="Designation" />
                                    <asp:RequiredFieldValidator ID="req2" runat="server" ControlToValidate="txtPosted" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>--%>
                                <div class="col-lg-12 mb-2">
                                    <label class="text-muted">Message<sup class="text-danger">*</sup></label>
                                    <asp:TextBox runat="server" TextMode="MultiLine" class="form-control mb-2 mr-sm-2 summernote" ID="txtMessage" Placeholder="Full Description ....." />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtMessage" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>

                                </div>
                                <div class="row mb-2">
                                    <div class="col-lg-5">
                                        <asp:Button runat="server" ID="btnSave" CssClass="btn btn-secondary" Text="Save" OnClick="btnSave_Click" OnClientClick="tinyMCE.triggerSave(false,true);" ValidationGroup="Save" Style="margin-top: 10px;" />
                                        <asp:Button runat="server" ID="btnNew" CssClass="btn btn-info" Visible="false" Text="Add New Product" OnClick="btnNew_Click" Style="margin-top: 10px;" />
                                        <asp:Label ID="lblThumb" runat="server" Visible="false"></asp:Label>
                                    </div>
                                </div>
                            </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>

