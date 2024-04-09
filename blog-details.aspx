<%@ Page Title="" Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="blog-details.aspx.cs" Inherits="blog_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <section id="event-details-section" class="event-details-section sec-ptb-100 clearfix">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-lg-10 col-md-12 col-sm-12">
                    <div class="event-details mb-80">
                        <div class="event-title mb-30">
                            <h2 class="event-title"><%=StrBlogTitle %></h2>
                        </div>

                        <div class="item mb-4">
                            <%=StrBlogImage %>
                        </div>



                        <div class="event-info-list ul-li clearfix mb-50">
                            <ul>
                                <li>
                                    <span class="icon">
                                        <i class="far fa-calendar"></i>
                                    </span>
                                    <div class="event-content">
                                        <small class="event-title">Date</small>
                                        <h3 class="event-date"><%=StrPostedOn %></h3>
                                    </div>
                                </li>

                                <li>
                                    <span class="icon">
                                        <i class="fas fa-tags"></i>
                                    </span>
                                    <div class="event-content">
                                        <small class="event-title">Category</small>
                                        <h3 class="event-date"><%=StrCategory %>
                                        </h3>
                                    </div>
                                </li>
                            </ul>
                        </div>

                        <div class="blog-content">
                            <%=StrBlogDesc %>
                        </div>

                    </div>

                </div>
            </div>

        </div>
    </section>
</asp:Content>

