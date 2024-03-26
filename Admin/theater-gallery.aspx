﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="theater-gallery.aspx.cs" Inherits="Admin_theater_galllery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .ImagesLoaded {
            min-height: 440px;
        }

        .maindiv div {
            position: absolute;
            top: 2px;
            right: 20px;
            z-index: 999;
        }

        .maindiv img {
            position: relative;
            border-radius: 15px;
            padding: 10px;
            margin: 5px;
        }

        #left-defaults {
            padding-left: 0px !important;
            margin-left: 0px !important;
        }

        .deleteGalleryItem {
            border-radius: 50px;
        }
        /* #left-defaults {
            padding-left: 0px;
        }

            #left-defaults .maindiv {
                border: 1px solid #ddd;
                border-radius: 5px;
                margin: 15px;
                padding: 15px;
            }


        #GalleryModal .card {
            box-shadow: unset;
        }

        .ImageUploadBox {
            border: 1px solid #ddd;
            border-radius: 10px;
            padding: 15px;
            position: sticky;
            top: 30px;
        }

        .stickyGalleryOrder {
            display: flex;
            align-items: center;
            justify-content: space-between;
            position: sticky;
            top: 0px;
            background: #ffffff;
            z-index: 999;
        }

        #GalleryModal .modal-body {
            padding-top: 0px;
        }*/
    </style>

    <link rel="stylesheet" href="assets/libs/dropzone/dropzone.css" type="text/css" />
    <link href="assets/libs/dragula/dragula.min.css" rel="stylesheet" />
    <link href="assets/libs/dragula/example.css" rel="stylesheet" />
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
                                <li class="breadcrumb-item active">Manage Theater Gallery</li>
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
                        <div class="card-header d-flex justify-content-between">
                            <h4 class="card-title mb-0">Gallery Images - <%=StrTheater %></h4>
                            <a href='javascript:void(0);' id="UpdateImgOrder" class="btn btn-primary btn-sm">Update Image Order</a>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-12 col-md-12">
                                    <ul id='left-defaults' class='row dragula sortablev ImagesLoaded'>
                                    </ul>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="col-lg-4">
                    <div class="card">
                        <div class="card-header m-3">
                            <h4 class="card-title mb-0">Add Images</h4>
                        </div>
                        <!-- end card header -->
                        <div class="card-body">
                            <p class="text-muted">You can add preview images for the package here</p>

                            <div class="dropzone">
                                <div class="fallback">
                                    <input name="file" type="file" multiple="multiple">
                                </div>
                                <div class="dz-message needsclick">
                                    <div class="mb-3">
                                        <i class="display-4 text-muted ri-upload-cloud-2-fill"></i>
                                    </div>

                                    <h4>Drop files here or click to upload.</h4>
                                </div>
                            </div>

                            <ul class="list-unstyled mb-0" id="dropzone-preview">
                                <li class="mt-2" id="dropzone-preview-list">
                                    <!-- This is used as the file preview template -->
                                    <div class="border rounded">
                                        <div class="d-flex p-2">
                                            <div class="flex-shrink-0 me-3">
                                                <div class="avatar-sm bg-light rounded">
                                                    <img data-dz-thumbnail class="img-fluid rounded d-block" src="#" alt="Dropzone-Image" />
                                                </div>
                                            </div>
                                            <div class="flex-grow-1">
                                                <div class="pt-1">
                                                    <h5 class="fs-14 mb-1" data-dz-name>&nbsp;</h5>
                                                    <p class="fs-13 text-muted mb-0" data-dz-size></p>
                                                    <strong class="error text-danger" data-dz-errormessage></strong>
                                                </div>
                                            </div>
                                            <div class="flex-shrink-0 ms-3">
                                                <button data-dz-remove class="btn btn-sm btn-danger">Delete</button>
                                            </div>
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </div>
                        <div class="card-footer">
                            <div class="text-end">
                                <button type="button" id="AddToGallery" data-pid="" class="btn btn-lg btn-primary">Upload</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <label id="lblTid" hidden="hidden"><%=Request.QueryString["tid"] == null?"":Request.QueryString["tid"].ToString() %></label>
    </div>
    <script src="assets/libs/dropzone/dropzone-min.js"></script>
    <script src="assets/js/pages/theater-gallery.js"></script>
    <script src="assets/libs/dragula/dragula.min.js"></script>
    <script src="assets/libs/dragula/custom-dragula.js"></script>
</asp:Content>

