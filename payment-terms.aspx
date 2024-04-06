<%@ Page Title="" Language="C#" MasterPageFile="./MasterPage.master" AutoEventWireup="true" CodeFile="payment-terms.aspx.cs" Inherits="payment_terms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
               .default-header-section .header-bottom .menu-item-list ul li:nth-child(2) a {
    color: #f5e860;
}
        .custom-btn {
            z-index: 1;
            font-weight: 600;
            overflow: hidden;
            padding: 15px 35px;
            text-align: center;
            position: relative;
            border-radius: 50px;
            display: -webkit-inline-box;
            display: -ms-inline-flexbox;
            display: inline-flex;
            font-size: 14px;
            text-transform: uppercase;
            background: #f5e860;
            color: #ffffff !important;
            -webkit-box-shadow: unset !important;
            box-shadow: unset !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <section id="event-section" class="event-section new-eve bg-gray-light sec-ptb-100 clearfix grey-bg">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-lg-10">
                    <div class="terms-sec">
                        <h4>Guidelines to Follow
                        </h4>
                        <ol>
                            <li>Smoking and alcohol consumption are strictly prohibited on the premises.
                        </li>
                            <li>Kindly adhere to the booking timings, as changes are not feasible once confirmed.
                        </li>
                            <li>Prevent any loss or damage to theatre property to avoid corresponding charges.
                        </li>
                            <li>Please also ensure not to litter the premises. An extra charge shall be levied .
                        </li>
                            <li>Do not carry snack items such as chips and drinks. Customers can purchase the same from the snack bar at the location.
                        </li>
                            <li>While casting content, please be aware that we are not liable for technical issues with OTT apps or your mobile device.
                        </li>
                            <li>Please do not take any decor item placed in the theatre.
                        </li>
                            <li>Candles are not permitted on the premises due to fire safety rules.
                        </li>
                        </ol>

                        <h5>Health and Safety Guidelines</h5>
                        <ol>
                            <li>Our theatre undergoes thorough disinfection before each booking to ensure a safe environment.
                        </li>
                            <li>We strictly adhere to legal guidelines by maintaining CCTV surveillance throughout our premises.
                        </li>
                        </ol>
                        <h5>Additional Charges
                        </h5>
                        <ol>
                            <li>A flat cleaning charge of Rs. 100/- will be applied if outside food is consumed within the premises.
                        </li>
                            <li>Please note that food and beverages are chargeable, unless explicitly stated in the package.
                        </li>
                            <li>In the event of last-minute additions to the group, booking charges will apply accordingly.
                        </li>
                            <li>In case of equipment damage (screenig system, lights, seating, etc) an extra charge will be levied.
                        </li>
                        </ol>
                        <h5>Prompt Reporting and Support
                        </h5>
                        <ol>
                            <li>If you encounter any dip in audio-visual performance, kindly notify us immediately. We are committed to providing the best network and audio-visual experience.
                        </li>
                        </ol>

                        <a href="" class="custom-btn" tabindex="-1">Next <i class=" ms-2 mt-1 fas fa-chevron-right"></i></a>

                    </div>

                </div>
            </div>
        </div>
    </section>
</asp:Content>

