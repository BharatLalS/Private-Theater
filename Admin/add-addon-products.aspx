<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="add-addon-products.aspx.cs" Inherits="Admin_add_addon_products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                        <h4 class="mb-sm-0">Add Product</h4>
                        <div class="page-title-right">
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item"><a href="/Admin/">Dashboard</a></li>
                                <li class="breadcrumb-item"><a href="javascript: void(0);">Add-Ons</a></li>
                                <li class="breadcrumb-item active">Add Product</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="card">
                <div class="card-header">
                    <h4 class="mb-sm-0 card-title"><%=Request.QueryString["id"] ==null?"Add":"Update"%> Product Details</h4>
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
                            <label class="form-label" for="project-title-input">Product Name<sup style="color: red;">*</sup></label>
                            <asp:TextBox runat="server" ID="txtProduct" CssClass="form-control txtName" placeholder="Product Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtProduct" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-4 mb-2">
                            <label class="form-label" for="project-title-input">Product Url<sup style="color: red;">*</sup></label>
                            <asp:TextBox runat="server" ID="txtUrl" CssClass="form-control txtUrl" placeholder="Product Url"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtUrl" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>

                        </div>
                        <div class="col-lg-4 mb-2">
                            <label class="form-label" for="project-title-input">Price<sup style="color: red;">*</sup></label>
                            <asp:TextBox runat="server" ID="txtPrice" CssClass="form-control" placeholder="Price"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPrice" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>

                        </div>
                        <div class="col-lg-4 mb-2">
                            <label class="form-label" for="project-title-input">Upload Image <sup>*</sup></label>
                            <asp:FileUpload runat="server" ID="FileUpload1" CssClass="form-control" />
                            <small class="text-danger">.png, .jpeg, .jpg, .gif formats are required, Image Size 225 × 225 px is recommended.</small><br />
                            <%=StrThumbImage %>
                        </div>
                        <div class="col-lg-2 mb-2 d-none" id="divprotype">
                            <label>Select Type <sup>*</sup></label>
                            <asp:DropDownList runat="server" ID="ddlProductType" CssClass="form-control form-select ddlProductType ">
                                <asp:ListItem Value="0" Selected="True" disabled hidden>Select Type</asp:ListItem>
                                <asp:ListItem Value="Beverages">Beverages</asp:ListItem>
                                <asp:ListItem Value="Appetizer">Appetizer</asp:ListItem>
                                <asp:ListItem Value="Main Course">Main Course</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-lg-2 mb-2">
                            <div class="" style="margin-top: 36px;">
                                <asp:CheckBox runat="server" ID="ChkMultiple" />
                                <label runat="server" id="lblmultiple" for="<%=ChkMultiple.ClientID %>">Allow Multiple</label>
                            </div>
                        </div>
                        <div class="col-lg-12 mb-2">
                            <label class="form-label" for="project-title-input">Description</label>
                            <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDesc" CssClass="form-control summernote" placeholder="Description"></asp:TextBox>
                        </div>
                        <div class="col-lg-12 mb-2">
                            <asp:Button runat="server" ID="BtnSubmit" CssClass="btn btn-secondary" Text="Save" OnClick="BtnSubmit_Click" ValidationGroup="Save" OnClientClick="tinyMCE.triggerSave(false,true);" />
                            <asp:Button runat="server" ID="btnNew" CssClass="btn btn-info" Visible="false" Text="Add New Theater" OnClick="btnNew_Click" />
                            <asp:Label ID="lblThumb" runat="server" Visible="false"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            $(document.body).on("change", ".ddlCategory", function (e) {
                e.preventDefault();
                if ($(".ddlCategory option:selected").text() == "Eatery") {
                    $("#divprotype").removeClass("d-none");
                } else {
                    $("#divprotype").addClass("d-none");
                    $(".ddlProductType").val('0');
                }
            });
            $(document.body).on("change", '.txtName', function () {
                $(".txtUrl").val($(".txtName").val().toLowerCase().replace(/\./g, '').replace(/\//g, '').replace(/\\/g, '').replace(/\*/g, '').replace(/\?/g, '').replace(/\~/g, '').replace(/\ /g, '-'));
            });

        })
    </script>
</asp:Content>

