

$(document).ready(function () {

    //DropDown Initializing with preview

    var previewTemplate, dropzone, dropzonePreviewNode = document.querySelector("#dropzone-preview-list");
    if (dropzonePreviewNode) {
        dropzonePreviewNode.id = "";
        previewTemplate = dropzonePreviewNode.parentNode.innerHTML;
        dropzonePreviewNode.parentNode.removeChild(dropzonePreviewNode);
        dropzone = new Dropzone(".dropzone", {
            url: "https://httpbin.org/post",
            method: "post",
            previewTemplate: previewTemplate,
            previewsContainer: "#dropzone-preview"
        });
    }

    BindGalleryImages();


    $(document.body).on("click", "#AddToGallery", function () {
        var elem = $(this);
        elem.empty();
        elem.append("Please wait...");
        var tid = $('#lblTid').html();
        var files = dropzone.getAcceptedFiles();
        var data = new FormData();
        for (var i = 0; i < files.length; i++) {
            data.append(files[i].name, files[i]);
        }
        data.append("tid", tid);
        if (files.length == 0) {
            elem.empty();
            elem.append("Upload");

            Snackbar.show({ pos: 'top-right', text: 'Please select atleast one file to upload', actionTextColor: '#fff', backgroundColor: '#ea1c1c' });

            return false;
        }
        $.ajax({
            url: "/admin/gallery-images.ashx",
            type: "POST",
            data: data,
            contentType: false,
            processData: false,
            success: function (result) {
                if (result.split('|')[0] == "Success") {
                    elem.empty();
                    elem.append("Upload");
                    Snackbar.show({ pos: 'top-right', text: 'Images added successfully.', actionTextColor: '#fff', backgroundColor: '#008a3d' });
                    dropzone.removeAllFiles();
                    BindGalleryImages();

                }
                else if (result.split('|')[0] == "Permission") {
                    elem.empty();
                    elem.append("Upload");
                    Snackbar.show({ pos: 'top-right', text: 'Oops! Access denied. Contact to your administrator', actionTextColor: '#fff', backgroundColor: '#ea1c1c' });

                }
                else {
                    elem.empty();
                    elem.append("Upload");
                    Snackbar.show({ pos: 'top-right', text: 'Oops! Something went wrong. Please try after some time.', actionTextColor: '#fff', backgroundColor: '#ea1c1c' });
                }
            },
            error: function (err) {
                elem.empty();
                elem.append("Upload");
                Snackbar.show({ pos: 'top-right', text: 'Oops! Something went wrong. Please try after some time.', actionTextColor: '#fff', backgroundColor: '#ea1c1c' });

            }
        });

    });

    $(document.body).on('click', '.deleteGalleryItem', function () {
        var elem = $(this);
        var id = elem.attr('data-id');
        Swal.fire({
            title: "Are you sure?",
            text: "You won't be able to revert this!",
            icon: "warning",
            showCancelButton: !0,
            confirmButtonClass: "btn btn-primary w-xs me-2 mt-2",
            cancelButtonClass: "btn btn-danger w-xs mt-2",
            confirmButtonText: "Yes, delete it!",
            buttonsStyling: !1,
            showCloseButton: !0,
        }).then(function (result) {
            if (result.value) {
                $.ajax({
                    type: 'POST',
                    url: "theater-gallery.aspx/DeleteImage",
                    data: "{id: '" + id + "'}",
                    contentType: 'application/json; charset=utf-8',
                    dataType: "json",
                    async: false,
                    success: function (data2) {
                        if (data2.d.toString() == "Success") {
                            Swal.fire({ title: "Deleted!", text: "Image has been deleted.", icon: "success", confirmButtonClass: "btn btn-primary w-xs mt-2", buttonsStyling: false })
                            BindGalleryImages();

                        }
                        else if (data2.d.toString() == "Permission") {
                            Swal.fire({ title: "Oops...", text: "Permission denied! Please contact to your administrator.", icon: "error", confirmButtonClass: "btn btn-primary w-xs mt-2", buttonsStyling: !1, footer: '', showCloseButton: !0 });

                        }
                        else {
                            Swal.fire({ title: "Oops...", text: "Something went wrong!", icon: "error", confirmButtonClass: "btn btn-primary w-xs mt-2", buttonsStyling: !1, footer: '', showCloseButton: !0 });

                        }
                    },
                    error: function (err) {
                        Swal.fire({ title: "Oops...", text: "Something went wrong!", icon: "error", confirmButtonClass: "btn btn-primary w-xs mt-2", buttonsStyling: !1, footer: '', showCloseButton: !0 });
                    }
                });
            }
        })
    });

    $(document.body).on('click', "#UpdateImgOrder", function (e) {
        var product = "";
        var elem = $(this);
        elem.empty();
        elem.append("Please wait...")
        e.preventDefault();
        $.each($('#left-defaults').find('li'), function () {
            if (product == "") {
                product = product + $(this).attr("data-id");
            }
            else {
                product = product + "|" + $(this).attr("data-id");
            }
        });
        if (product != "") {
            ArrengeCategory(product);
        }
        else {
            elem.empty();
            elem.append("Update Image Order")
        }
    });
});

function BindGalleryImages() {
    var Tid = $("#lblTid").html();
    if (Tid != "") {
        $.ajax({
            type: 'POST',
            url: "theater-gallery.aspx/GetGalleryImage",
            data: "{Tid: '" + Tid + "'}",
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            async: false,
            success: function (data2) {
                var lnt = data2.d;
                var strL = "";
                var str = "";
                if (lnt != null && lnt.length > 0) {
                    for (var i = 0; i < lnt.length; i++) {
                        var del = "";
                        var strtype = "";
                        strtype = "<img src='/" + lnt[i].ImageUrl + "' class='img-responsive' style='max-width:100%;' />";
                        del += "<a href='javascript:void(0);' class='bs-tooltip waves-effect waves-light btn btn-sm btn-danger fs-12 deleteGalleryItem mt-3' data-id='" + lnt[i].Id + "' data-tid='" + lnt[i].TheaterID + "' data-toggle='tooltip' data-placement='top' title='' data-original-title='Delete'>";
                        del += "<i class='mdi mdi-delete-forever'></i></a>";
                        str = str + "<li data-id='" + lnt[i].Id + "' class='ui-state-default media d-md-flex d-block text-sm-left text-end col-md-3 col-lg-3'><div class='maindiv'><div><span>" + del + "</span></div>" + strtype + "</div></li>";
                    }
                    $("#left-defaults").html(str);
                }
                else {
                    str = "<div class='justify-content-center d-flex align-items-center'><h3>No Data To Show</h3></div>";
                    $("#left-defaults").html(str);
                }

            }
        });
    }
}

function ArrengeCategory(product) {
    var parameter = { "id": product };

    $.ajax({
        type: 'POST',
        url: "theater-gallery.aspx/ImageOrderUpdate",
        data: JSON.stringify(parameter),
        contentType: 'application/json; charset=utf-8',
        dataType: "json",


        success: function (data2) {
            if (data2.d.toString() == "Success") {
                $("#UpdateImgOrder").empty();
                $("#UpdateImgOrder").append("Update Image Order");
                Snackbar.show({ pos: 'top-right', text: 'Images arranged successfully.', actionTextColor: '#fff', backgroundColor: '#008a3d' });
                BindGalleryImages($('#<%=idPid.ClientID %>').val());


            }
            else if (data2.d.toString() == "Permission") {
                Swal.fire({ title: "Oops...", text: "Permission denied! Please contact to your administrator.", icon: "error", confirmButtonClass: "btn btn-primary w-xs mt-2", buttonsStyling: !1, footer: '', showCloseButton: !0 });

            }
            else {
                Swal.fire({ title: "Oops...", text: "Something went wrong!", icon: "error", confirmButtonClass: "btn btn-primary w-xs mt-2", buttonsStyling: !1, footer: '', showCloseButton: !0 });
            }
        },
        error: function (err) {
            Swal.fire({ title: "Oops...", text: "Something went wrong!", icon: "error", confirmButtonClass: "btn btn-primary w-xs mt-2", buttonsStyling: !1, footer: '', showCloseButton: !0 });
        }

    });
}