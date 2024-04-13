<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="404-error.aspx.cs" Inherits="_404_error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style>
	.pt-200{
		padding-top:200px;
	}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    	<section id="error-section" class="error-section sec-ptb-100 bg-gray-light clearfix pt-200">
			<div class="container">
				<div class="row justify-content-center">

					<!-- error-content - start -->
					<div class="col-lg-4 col-md-6 col-sm-12">
						<div class="icon">
							<i class="far fa-frown"></i>
						</div>
					</div>
					<!-- error-content - end -->

					<!-- error-content - start -->
					<div class="col-lg-4 col-md-6 col-sm-12">
						<div class="error-content">
							<h2>404</h2>
							<h3>error - page not found</h3>
							<p class="mb-30">The page you are looking for could not be found.The link to this
                            address may be outdated or we may have moved the since you last bookmarked it.</p>
							<a href="/" class="custom-btn">go back to home</a>
						</div>
					</div>
					<!-- error-content - end -->
					
				</div>
			</div>
		</section>
</asp:Content>

