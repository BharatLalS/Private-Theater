<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="thank-you.aspx.cs" Inherits="thank_you" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<style>
	.pt-200{
		padding-top:200px;
	}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <section id="error-section" class="error-section sec-ptb-100  clearfix pt-200">
	<div class="container">
		<div class="row justify-content-center">

			<!-- error-content - start -->
			<div class="col-lg-3 col-md-6 col-sm-6">
                <img src="assets/images/success.gif" />
			</div>
			<!-- error-content - end -->

			<!-- error-content - start -->
			<div class="col-lg-6 col-md-6 col-sm-12">
				<div class="error-content">
					<h2>Thank you</h2>
					<p class="mb-30">Thank you for contacting us.
						our team will get back to you soon.</p>
					<a href="/" class="custom-btn">go back to home</a>
				</div>
			</div>
			<!-- error-content - end -->
			
		</div>
	</div>
</section>
</asp:Content>

