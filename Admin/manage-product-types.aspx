<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="manage-product-types.aspx.cs" Inherits="Admin_add_product_type" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                        <h4 class="mb-sm-0">Manage Product Types</h4>
                        <div class="page-title-right">
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item"><a href="/Admin/">Dashboard</a></li>
                                <li class="breadcrumb-item"><a href="javascript: void(0);">Add-Ons</a></li>
                                <li class="breadcrumb-item active">Manage Product Types</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="card">
                <div class="card-header">
                    <h4 class="mb-sm-0 card-title"><%=Request.QueryString["id"] ==null?"Add":"Update"%> Product Type</h4>

                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-4 mb-2">
                            <label>Select Category <sup>*</sup></label>
                            <asp:DropDownList runat="server" ID="ddlCategory" CssClass="form-control ddlCategory form-select">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCategory" InitialValue="0" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-4 mb-2">
                            <label class="form-label" for="project-title-input">Product Type<sup style="color: red;">*</sup></label>
                            <asp:TextBox runat="server" ID="txtProduct" CssClass="form-control txtName" placeholder="Product Type"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtProduct" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-4 mb-2">
                            <label class="form-label" for="project-title-input">Product Order<sup style="color: red;">*</sup></label>
                            <asp:TextBox runat="server" ID="txtProductOrder" CssClass="form-control" placeholder="Product Order"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtProductOrder" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-4 mb-2">
                            <asp:Button runat="server" ID="BtnSubmit" CssClass="btn btn-secondary" Text="Save" OnClick="BtnSubmit_Click" ValidationGroup="Save" OnClientClick="tinyMCE.triggerSave(false,true);" />
                            <asp:Button runat="server" ID="btnNew" CssClass="btn btn-info" Visible="false" Text="Add New Product Type" OnClick="btnNew_Click" />
                            <asp:Label ID="lblThumb" runat="server" Visible="false"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="card">
                <div class="card-header">
                    <h4 class="mb-sm-0 card-title">View Product Types</h4>
                </div>
                <div class="card-body table-responsive">
                    <table id="alternative-pagination" class="table nowrap align-middle dt-responsive table-hover" style="width: 100%">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Category</th>
                                <th>Product Type</th>
                                <th>Product Order</th>
                                <th>Last Updated On</th>
                                <th class="text-center">Action</th>
                            </tr>
                        </thead>
                        <tbody>
                             <%=StrProducts %>
                        </tbody>
                        <tfoot>
                            <tr>
                                <th>#</th>
                                <th>Category</th>
                                <th>Product Type</th>
                                <th>Product Order</th>
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

