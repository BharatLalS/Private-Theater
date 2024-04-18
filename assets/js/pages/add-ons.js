$(document).ready(function () {
    const booking = $(".lblhidden").html();
    const total = $(".lbltotal").html();
    const tax = $(".lbltax").html();
    if (booking != "") {
        $(".lblhidden").html("");
    } if (total != "") {
        $(".lbltotal").html("");
    } if (tax != "") {
        $(".lbltax").html("");
    }
    BindCart(booking, total, tax);
    //Know More
    $(document.body).on("click", ".btnknowmoremodal", function () {
        var PGuid = $(this).attr("data-id");
        var PTitle = $(this).attr("data-title");
        $.ajax({
            type: 'POST',
            url: "/add-on.aspx/KnowMoreModalDetails",
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            data: JSON.stringify({
                PGuid: PGuid
            }),
            success: function (data2) {
                if (data2.d.toString() == "Error") {
                    //Error Message
                    Snackbar.show({
                        pos: 'top-right',
                        text: 'there is some problem right now.please try again later.',
                        actionTextColor: '#fff',
                        backgroundColor: '#ea1c1c'
                    });
                }
                else if (data2.d.toString() == "Empty") {
                    //Empty Message
                    Snackbar.show({
                        pos: 'top-right',
                        text: 'there is some problem right now.please try again later.',
                        actionTextColor: '#fff',
                        backgroundColor: '#ea1c1c'
                    });

                }
                else {
                    $("#KnowMoreModalTitle").html(PTitle);
                    $(".knowmorebody").html(data2.d.toString());
                    $("#KnowMoreModal").modal("show");
                }
            }
        })


    });

    //Quantity Minus
    $(document.body).on("click", ".qtyminus", function () {
        $this = $(this);
        var input = $this.parent().find("#qty");
        var qty = parseInt(input.val());
        var min = parseInt(input.attr("min"));
        if (qty > min) {
            input.val(qty - 1);
        }
    });

    //Quantity Plus
    $(document.body).on("click", ".qtyplus", function () {
        $this = $(this);
        var input = $this.parent().find("#qty");
        var qty = parseInt(input.val());
        var max = parseInt(input.attr("max"));
        if (qty < max) {
            input.val(qty + 1);
        }
    });

    //Previous Tab
    $(document.body).on("click", ".btn-prev", function () {
        currTab = $(".blog-layout-menubar li .active");
        var prevTab = currTab.parent().prev("li");
        currContent = $(".tab-content .tab-pane.active");
        var prevContent = currContent.prev(".tab-pane");
        currTab.removeClass("active");
        prevTab.find("a").addClass("active");
        currContent.removeClass("active");
        prevContent.addClass("show active");
    });

    //Next  Tab
    $(document.body).on("click", ".btn-next", function () {
        currTab = $(".blog-layout-menubar li .active");
        var nextTab = currTab.parent().next("li");
        currContent = $(".tab-content .tab-pane.active");
        var nextContent = currContent.next(".tab-pane");
        currTab.removeClass("active");
        nextTab.find("a").addClass("active");
        currContent.removeClass("active");
        nextContent.addClass("show active");

    });

    //Adding Addons
    $(document.body).on("change", ".product-box", function () {
        $this = $(this);
        var PId = $this.attr("data-id");
        var BId = booking;
        var qty = $this.find("#qty").length === 0 ? "1" : $this.find("#qty").val();
        if (!$this.find("input[type ='checkbox']").is(":checked")) {
            qty = 0;
        }
        $.ajax({
            type: 'POST',
            url: "/add-on.aspx/UpdateAddon",
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            data: JSON.stringify({
                PGuid: PId,
                Qty: qty,
                BGuid: BId
            }),
            success: function (data2) {
                if (data2.d.toString() == "Error") {
                    //Error Message
                    Snackbar.show({
                        pos: 'top-right',
                        text: 'there is some problem right now.please try again later.',
                        actionTextColor: '#fff',
                        backgroundColor: '#ea1c1c'
                    });
                }
                else if (data2.d.toString() == "Empty") {
                    //Empty Message
                    Snackbar.show({
                        pos: 'top-right',
                        text: 'there is some problem right now.please try again later.',
                        actionTextColor: '#fff',
                        backgroundColor: '#ea1c1c'
                    });

                }
                BindCart(booking, total, tax);
            }
        })

    })



});
function BindCart(Bid, total, tax) {
    $.ajax({
        type: 'POST',
        url: "/add-on.aspx/BindCart",
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        data: JSON.stringify({
            BGuid: Bid
        }),
        success: function (data2) {
            if (data2.d != null) {
                res = data2.d;
                var products = "";
                var addonprice = 0;
                var addontax = 0;
                if (res != "") {
                    for (var i = 0; i < res.length; i++) {
                        products += "<tr>";
                        products += "<td scope='row'>" + res[i].Category + "</td>";
                        products += "<td>" + res[i].ProductName + "</td>";
                        products += "<td>" + res[i].Quantity + "</td>";
                        products += "<td> ₹ " + res[i].ItemPrice + "</td>";
                        products += "<td> ₹ " + res[i].ItemTotal + "</td>";
                        products += "</tr>";

                        addonprice += parseFloat(res[i].ItemTotal.replace(/,/g, ''));
                        addontax += parseFloat(res[i].TaxAmount.replace(/,/g, ''));
                        CheckSelectedProducts(res[i].ProductGuid, res[i].Quantity);
                    }
                    if (addonprice > 0) {
                        $(".lblAddonPrice").html("₹ " + addonprice.toFixed(2).toLocaleString());
                        var oTotal = total;
                        var oTax = tax;
                        $(".grand-total").html("₹ " + (addonprice + + addontax + parseFloat(oTotal.replace(/,/g, ''))).toFixed(2).toLocaleString());
                        $(".lblTaxPrice").html("₹ " + (addontax + parseFloat(oTax.replace(/,/g, ''))).toFixed(2).toLocaleString());
                    }

                    $(".cartTable").html(products);
                }
                else {
                    $(".grand-total").html("₹ " + (parseFloat(total.replace(/,/g, ''))).toFixed(2).toLocaleString());
                    $(".lblTaxPrice").html("₹ " + (parseFloat(tax.replace(/,/g, ''))).toFixed(2).toLocaleString());

                    $(".cartTable").html("<tr><td colspan='5' class='text-center'> No items to show </td></tr>");
                }
                //$("#KnowMoreModalTitle").html(PTitle);
                //$(".knowmorebody").html(data2.d.toString());
                //$("#KnowMoreModal").modal("show");
            }
            else {
                $(".grand-total").html("₹ " + (parseFloat(total.replace(/,/g, ''))).toFixed(2).toLocaleString());
                $(".lblTaxPrice").html("₹ " + (parseFloat(tax.replace(/,/g, ''))).toFixed(2).toLocaleString());
                $(".lblAddonPrice").html("₹ 0");
                $(".cartTable").html("<tr><td colspan='5' class='text-center'> No items to show </td></tr>");
            }
        }
    })

}
function CheckSelectedProducts(PGuid, Qty) {
    var product = $('div.product-box[data-id="' + PGuid + '"]');
    var hasqty = product.find("#qty").length === 0;
    product.find('input[type="checkbox"]').prop('checked', true);
    if (!hasqty) {
        product.find("#qty").val(Qty);
    }

}