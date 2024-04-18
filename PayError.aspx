<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PayError.aspx.cs" Inherits="PayError" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div id="columns" class="columns-container section-padding-md">
        <!-- container -->
        <div class="container">
            <div class="row">
                <div class="col-xs-12 col-sm-12  col-md-12 text-center ">
                    <br />
                    <br />
                    <img style="max-height: 100px" src="images/Transaction-Failed.png" />
                    <h3 class='main-heading text-danger'>Error!
                        <br />
                        There's a problem.<br />Please try it after some time.</h3>
                    <br />
                    <br />
                    <!--end form -->
                </div>
            </div>
        </div>
        <!-- end container -->
    </div>
</asp:Content>