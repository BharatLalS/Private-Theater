$(document).ready(function () {
    const theater = $(".lblhidden").html();

    if (theater != "") {
        $(".lblhidden").html("");
    }

    BindTiming(theater);

    $(document.body).on("click", ".dates li", function () {
        BindTiming(theater);
    });
    $(document.body).on("click", ".timeslots", function () {
        var timings = "";
        $('.timeslots input[type="checkbox"][name="time"]:checked').each(function () {
            timings += $(this).parent().find('label').html() + ',';
        });
        if (timings != "") {
            $("#submit_btn").addClass("submit_btn");
            $("#submit_btn").removeClass("opacity-50 disable");
        }
        else {
            $("#submit_btn").removeClass("submit_btn");
            $("#submit_btn").addClass("opacity-50 disable");
        }
    });
    $(document.body).on("click", ".submit_btn", function (e) {
        BindNoOfPax(theater);
        $("#BookingModal").modal("show");
    });

    $(document.body).on("change", ".NoofPax", function (e) {
        BindModalDetails(theater)
    });

    $(document.body).on("click", ".booknowbtn", function (e) {
        e.preventDefault();
        var Email = $(".txtEmail").val();
        var Name = $(".txtName").val();
        var Phone = $(".txtPhone").val();
        var Pax = $(".NoofPax option:selected").val();
        var flag = 1;
        var timeids = [];
        $(".spnName").html("");
        $(".spnEmail").html("");
        $(".spnPhone").html("");
        $(".spnPax").html("");


        if (Name == "" || Name == null) {
            flag = 0;
            $(".spnName").html("Field can't be empty");
            $(".spnName").removeClass("d-none");
        }
        else if (/^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,}$/.test(Name) === false) {
            $(".spnName").html("Enter Valid Name");
            $(".spnName").removeClass("d-none");

            flag = 0;
        }
        else {
            $(".spnName").html("");
            $(".spnName").addClass("d-none");
        }

        if (Email == "" || Email == null) {
            $(".spnEmail").html("Field can't be empty");
            flag = 0;
            $(".spnEmail").removeClass("d-none");

        }
        else if (/^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(Email) === false) {
            $(".spnEmail").html("Invalid Email Address");
            $(".spnEmail").removeClass("d-none");

            flag = 0;
        }
        else {
            $(".spnEmail").html("");
            $(".spnEmail").addClass("d-none");

        }

        if (Phone == "" || Phone == null) {
            $(".spnPhone").html("Field can't be empty");
            $(".spnPhone").removeClass("d-none");

            flag = 0;
        }
        else if (!/^(?:\+?91)?[1-9]\d{9}$/.test(Phone)) {
            $(".spnPhone").html("Invalid phone number");
            $(".spnPhone").removeClass("d-none");
            flag = 0;
        }
        else {
            $(".spnPhone").html("");
            $(".spnPhone").addClass("d-none");
        }

        if (Pax == "" || Pax == '0' || Pax == null) {
            $(".spnPax").html("please select no of people.");
            $(".spnPax").removeClass("d-none");
            flag = 0;
        }
        else {
            $(".spnPax ").html("");
            $(".spnPax").addClass("d-none");
        }

        if (flag == 1) {
            var date = $(".dates li.active").html();
            var month = $(".new-flex1 h3").html().split(" ")[0];
            var year = $(".new-flex1 h3").html().split(" ")[1];
            var bookingdate = date + "/" + month + "/" + year;
            $('.timeslots input[type="checkbox"][name="time"]:checked').each(function () {
                var ids = $(this).attr('data-id');
                timeids.push(ids);
            });
            $.ajax({
                type: 'POST',
                url: "/details.aspx/BookNow",
                contentType: 'application/json; charset=utf-8',
                dataType: "json",
                data: JSON.stringify({
                    date: bookingdate,
                    theater: theater,
                    timeslots: timeids,
                    name: Name,
                    Email: Email,
                    Phone: Phone,
                    Pax: Pax
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
                        res = data2.d.toString();
                        window.location.href = "/add-on/"+res.split('|')[1];
                        //$("#slots").html("");
                        //$("#slots").append(res);
                    }
                }
            })
        };
    });
});

function BindTiming(Tid) {
    var date = $(".dates li.active").html();
    var month = $(".new-flex1 h3").html().split(" ")[0];
    var year = $(".new-flex1 h3").html().split(" ")[1];
    if (date.toString() != "" && month.toString() != "" && year.toString() != "" && Tid.toString() != "") {
        $.ajax({
            type: 'POST',
            url: "/details.aspx/BindTiming",
            contentType: 'application/json; charset=utf-8',
            dataType: "json",
            data: "{date: '" + date + "',month : '" + month + "',year : '" + year + "',theater : '" + Tid + "' }",
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
                    $("#slots").html("");
                    $("#slots").append("<center>No slots are open. please try again later.<center>");
                    $("#submit_btn").removeClass("submit_btn");
                    $("#submit_btn").addClass("opacity-50 disable");

                }
                else {
                    res = data2.d.toString();
                    $("#slots").html("");
                    $("#slots").append(res);
                }
            }
        })
    }
    else {
        //Error Message
        Snackbar.show({
            pos: 'top-right',
            text: 'there is some problem right now.please try again later.',
            actionTextColor: '#fff',
            backgroundColor: '#ea1c1c'
        });
    }
}

function BindModalDetails(Tid) {
    var timings = "";
    var cnt = 0;
    var date = $(".dates li.active").html();
    var month = $(".new-flex1 h3").html().split(" ")[0];
    var year = $(".new-flex1 h3").html().split(" ")[1];
    var pax = $(".NoofPax option:selected").val();
    $('.timeslots input[type="checkbox"][name="time"]:checked').each(function () {
        timings += $(this).parent().find('label').html() + ' ,';
        cnt++;
    });
    timings = timings.trim().replace(/,+$/, '');
    $(".bookeddate").html(date + "/" + month + "/" + year);
    $(".bookedtime").html(timings);
    $.ajax({
        type: 'POST',
        url: "/details.aspx/BindPayDetails",
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        data: "{theater : '" + Tid + "' }",
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
                Snackbar.show({
                    pos: 'top-right',
                    text: 'there is some problem right now.please try again later.',
                    actionTextColor: '#fff',
                    backgroundColor: '#ea1c1c'
                });

            }
            else {
                res = $.parseJSON(data2.d);

                GetTotalPrice(pax, cnt, res.price, res.extprice, res.allowedlimit);
            }
        }
    })

}

function GetTotalPrice(pax, cnt, price, extprice, allowedlimit) {
    var pax1 = parseInt(pax);
    var cnt1 = parseInt(cnt);
    var allowedlimit1 = parseInt(allowedlimit);
    var price1 = parseFloat(price);
    var extprice1 = parseFloat(extprice);
    var extra1 = (pax1 - allowedlimit1) > 0 ? pax1 - allowedlimit1 : 0
    var price1 = (cnt1 * price1) + (extra1 * extprice1);
    $(".totalprice").html(price1);
}

function BindNoOfPax(Tid) {
    $.ajax({
        type: 'POST',
        url: "/details.aspx/BindPax",
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        data: "{theater : '" + Tid + "' }",
        success: function (data2) {
            if (data2.d.toString() == "Error") {
                Snackbar.show({
                    pos: 'top-right',
                    text: 'there is some problem right now.please try again later.',
                    actionTextColor: '#fff',
                    backgroundColor: '#ea1c1c'
                });

            }
            else if (data2.d.toString() == "Empty") {
                Snackbar.show({
                    pos: 'top-right',
                    text: 'there is some problem right now.please try again later.',
                    actionTextColor: '#fff',
                    backgroundColor: '#ea1c1c'
                });


            }
            else {
                res = data2.d.toString();
                $(".NoofPax").html("<option selected value='0'>No of People</option>" + res)
                BindModalDetails(Tid);
            }
        }
    })
}