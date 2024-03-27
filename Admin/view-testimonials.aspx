<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="view-testimonials.aspx.cs" Inherits="Admin_view_testimonials" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        td p {
            margin: unset !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <div class="page-title-box d-sm-flex align-items-center justify-content-between">
                        <h4 class="mb-sm-0">View Testimonials</h4>

                        <div class="page-title-right">
                            <ol class="breadcrumb m-0">
                                <li class="breadcrumb-item"><a href="javascript: void(0);">Dashboards</a></li>
                                <li class="breadcrumb-item active">View Testimonials</li>
                            </ol>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="container-fluid">
            <div class="card">
                <div class="card-header">
                    <h5 class="card-title">View Testimonials</h5>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <table id="alternative-pagination" class="table nowrap align-middle table-striped table-bordered myTable" style="width: 100%">
                                <thead>
                                    <tr>
                                        <th>#</th>
                                        <th>Posted By</th>
                                        <th>Designation</th>
                                        <th>Message</th>
                                        <th>Added By</th>
                                        <th>Added On</th>
                                        <th class="text-center">Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <%=strTestimonials%>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th>#</th>
                                        <th>Posted By</th>
                                        <th>Designation</th>
                                        <th>Message</th>
                                        <th>Added By</th>
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

    <script>

        //Delete Function
        $(document.body).on("click", ".deleteItem", function () {
            var elem = $(this);
            var id = $(this).attr('data-id');
            swal.fire({
                html:
                    '<div class="mt-3"><lord-icon src="https://cdn.lordicon.com/gsqxdxog.json" trigger="loop" colors="primary:#f7b84b,secondary:#f06548" style="width:100px;height:100px"></lord-icon><div class="mt-4 pt-2 fs-15 mx-5"><h4>Are You Sure You Want To Delete ?</h4><p class="text-muted mx-4 mb-0">You won`t be able to revert this !</p></div></div>',
                showCancelButton: !0,
                confirmButtonClass: "btn btn-primary w-xs me-2 mb-1",
                confirmButtonText: "Yes, Delete It!",
                cancelButtonClass: "btn btn-danger w-xs mb-1",
                buttonsStyling: !1,
                showCloseButton: !0,
            }).then(function (result) {
                if (result.value) {
                    $.ajax({
                        type: 'POST',
                        url: "view-testimonials.aspx/Delete",
                        contentType: 'application/json; charset=utf-8',
                        dataType: "json",
                        data: "{id: '" + id + "'}",
                        success: function (data2) {
                            if (data2.d.toString() == "Success") {
                                Swal.fire({
                                    html:
                                        '<div class="mt-3"><lord-icon src="https://cdn.lordicon.com/kfzfxczd.json" trigger="loop" colors="primary:#0ab39c,secondary:#405189" style="width:120px;height:120px"></lord-icon><div class="mt-4 pt-2 fs-15"><h4 style="color:red">Deleted!</h4><p class="text-muted mx-4 mb-0">Deleted Successfully</p></div></div>',
                                    showCancelButton: !0,
                                    showConfirmButton: !1,
                                    cancelButtonClass: "btn btn-primary w-xs mb-1 back",
                                    cancelButtonText: "Back",
                                    buttonsStyling: !1,
                                    showCloseButton: !0,
                                });
                                $(".back").on("click", () => window.location.href = "view-testimonials.aspx");
                                elem.parent().parent().remove();
                            }
                            else if (data2.d.toString() == "Permission") {
                                Swal.fire({
                                    html:
                                        '<div class="mt-3"><lord-icon src="https://cdn.lordicon.com/tdrtiskw.json" trigger="loop" colors="primary:#f06548,secondary:#f7b84b" style="width:120px;height:120px"></lord-icon><div class="mt-4 pt-2 fs-15"><h4>Oops...! Something went Wrong !</h4><p class="text-muted mx-4 mb-0">Permission denied. Please contact to your administrator</p></div></div>',
                                    showCancelButton: !0,
                                    showConfirmButton: !1,
                                    cancelButtonClass: "btn btn-primary w-xs mb-1",
                                    cancelButtonText: "Dismiss",
                                    buttonsStyling: !1,
                                    showCloseButton: !0,
                                });
                            }
                            else {
                                Swal.fire({
                                    html:
                                        '<div class="mt-3"><lord-icon src="https://cdn.lordicon.com/tdrtiskw.json" trigger="loop" colors="primary:#f06548,secondary:#f7b84b" style="width:120px;height:120px"></lord-icon><div class="mt-4 pt-2 fs-15"><h4>Oops...! There is some problem now !</h4><p class="text-muted mx-4 mb-0">Please try again later</p></div></div>',
                                    showCancelButton: !0,
                                    showConfirmButton: !1,
                                    cancelButtonClass: "btn btn-primary w-xs mb-1",
                                    cancelButtonText: "Dismiss",
                                    buttonsStyling: !1,
                                    showCloseButton: !0,
                                });
                            }
                        }
                    });
                }
            })
        });

    </script>
</asp:Content>

