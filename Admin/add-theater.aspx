<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="add-theater.aspx.cs" Inherits="Admin_add_thretre" %>

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
                                <li class="breadcrumb-item"><a href="javascript: void(0);">Settings</a></li>
                                <li class="breadcrumb-item active">Manage Theater</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-8">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="mb-sm-0 card-title"><%=Request.QueryString["id"] ==null?"Add New":"Update"%> Theater Details</h4>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-4 mb-2">
                                    <label class="form-label" for="project-title-input">Select State<sup style="color: red;">*</sup></label>
                                    <asp:DropDownList runat="server" ID="ddlState" CssClass="form-select" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlState" InitialValue="0" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-4 mb-2">
                                    <label class="form-label" for="project-title-input">Select City<sup style="color: red;">*</sup></label>
                                    <asp:DropDownList runat="server" ID="ddlCity" CssClass="form-select" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlCity" InitialValue="0" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-4 mb-2">
                                    <label class="form-label" for="project-title-input">Select Area<sup style="color: red;">*</sup></label>
                                    <asp:DropDownList runat="server" ID="ddlArea" CssClass="form-select">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlArea" InitialValue="0" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-4 mb-2">
                                    <label class="form-label" for="project-title-input">Theater Name<sup style="color: red;">*</sup></label>
                                    <asp:TextBox runat="server" ID="txtTheater" CssClass="form-control txtName" placeholder="Theater Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTheater" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-4 mb-2">
                                    <label class="form-label" for="project-title-input">Theater Url<sup style="color: red;">*</sup></label>
                                    <asp:TextBox runat="server" ID="txtUrl" CssClass="form-control txtUrl" placeholder="Theater Url"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtUrl" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-4 mb-2">
                                    <label class="form-label" for="project-title-input">Pincode<sup style="color: red;">*</sup></label>
                                    <asp:TextBox runat="server" ID="txtPinCode" CssClass="form-control" placeholder="Pincode"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPinCode" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 mb-2">
                                    <label class="form-label" for="project-title-input">Complete Address<sup style="color: red;">*</sup></label>
                                    <asp:TextBox runat="server" ID="txtAddress" TextMode="MultiLine" CssClass="form-control" placeholder="Complete Address"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtAddress" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-12 mb-2">
                                    <label class="form-label" for="project-title-input">Full Description<sup style="color: red;">*</sup></label>
                                    <asp:TextBox runat="server" ID="txtFullDesc" TextMode="MultiLine" CssClass="form-control summernote" placeholder="Full Description"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtFullDesc" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <label class="form-label">Thumb Image</label>
                                    <asp:FileUpload runat="server" ID="ImageUpload" CssClass="form-control" />
                                    <small class="text-danger">.png, .jpeg, .jpg, .gif formats are required, Image Size Should be 800 × 600 px</small><br />
                                    <%=StrThumbImage %>
                                </div>
                                <div class="col-lg-6">
                                    <label class="form-label">Map Location Link</label>
                                    <asp:TextBox runat="server" ID="txtLocation" CssClass="form-control" placeholder="Map Location Link"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtLocation" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="card">
                        <div class="card-header">
                            <h5 class="card-title"><%=Request.QueryString["id"] ==null?"Add":"Update"%> Seo Details</h5>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-12 mb-2">
                                    <label class="form-label" for="project-title-input">Page Title</label>
                                    <asp:TextBox runat="server" ID="txtPageTitle" CssClass="form-control" placeholder="Page Title"></asp:TextBox>

                                </div>
                                <div class="col-lg-12 mb-2">
                                    <label class="form-label" for="project-title-input">Meta Keys</label>
                                    <asp:TextBox runat="server" ID="txtMetaKey" CssClass="form-control" placeholder="Meta Keys"></asp:TextBox>
                                </div>
                                <div class="col-lg-12 mb-2">
                                    <label class="form-label" for="project-title-input">Meta Description</label>
                                    <asp:TextBox runat="server" ID="txtMetaDesc" TextMode="MultiLine" CssClass="form-control" placeholder="Meta Description"></asp:TextBox>
                                </div>
                                <div class="col-lg-12 mb-2">
                                    <label class="form-label" for="project-title-input">Short Description<sup style="color: red;">*</sup></label>
                                    <asp:TextBox runat="server" ID="txtShortDesc" TextMode="MultiLine" CssClass="form-control" placeholder="Short Description"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtShortDesc" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card">
                        <div class="card-header">
                            <h5 class="card-title">Other  Details</h5>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-12 mb-2">
                                    <label class="form-label" for="project-title-input">Maximum Allowed Persons(Without Extra Persons)<sup>*</sup></label>
                                    <asp:TextBox runat="server" ID="txtMaxAllCap" CssClass="form-control" placeholder="Maximum Allowed Persons"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtMaxAllCap" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-12 mb-2">
                                    <label class="form-label" for="project-title-input">Price (Without Extra Person)<sup>*</sup></label>
                                    <asp:TextBox runat="server" ID="txtPrice" CssClass="form-control" placeholder="Maximum Capacity"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtPrice" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-12 mb-2">
                                    <label class="form-label" for="project-title-input">Maximum Theatre Capacity (With Extras)<sup>*</sup></label>
                                    <asp:TextBox runat="server" ID="txtMaxAllowed" CssClass="form-control" placeholder="Maximum Theatre Capacity"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtMaxAllowed" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-lg-12 mb-2">
                                    <label class="form-label" for="project-title-input">Price Per Person (For Extra Persons)<sup>*</sup></label>
                                    <asp:TextBox runat="server" ID="txtExtPrice" CssClass="form-control" placeholder="Price Per Person"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtExtPrice" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Save" ErrorMessage="Field can't be empty"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-12 mb-3">
                    <asp:Button runat="server" ID="btnSave" CssClass="btn btn-secondary" Text="Save" OnClick="btnSave_Click" OnClientClick="tinyMCE.triggerSave(false,true);" ValidationGroup="Save" />
                    <asp:Button runat="server" ID="btnNew" CssClass="btn btn-info" Visible="false" Text="Add New Theater" OnClick="btnNew_Click" />
                    <asp:Label ID="lblThumb" runat="server" Visible="false"></asp:Label>
                </div>
            </div>
        </div>
        <script>
            $(document.body).on("change", '.txtName', function () {
                $(".txtUrl").val($(".txtName").val().toLowerCase().replace(/\./g, '').replace(/\//g, '').replace(/\\/g, '').replace(/\*/g, '').replace(/\?/g, '').replace(/\~/g, '').replace(/\ /g, '-'));
            });
        </script>
</asp:Content>

