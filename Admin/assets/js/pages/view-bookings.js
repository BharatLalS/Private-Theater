$(document).ready(function () {
    //date filter 
    var f1 = flatpickr(document.getElementsByClassName('datepicker1'), {
        dateFormat: "Y-m-d",
    });

    if ($(".txtFrom").val() != "") {
        var cDate = $(".txtFrom").val();
        var date1 = new Date(cDate);
        var f1 = flatpickr(document.getElementsByClassName('nextdatepicker'), {
            minDate: date1,
            dateFormat: "Y-m-d",
        });
    }
    $(".txtFrom").change(function () {
        var cDate = $(this).val();
        $(".nextdatepicker").val("");
        var date1 = new Date(cDate);
        var f1 = flatpickr(document.getElementsByClassName('nextdatepicker'), {
            minDate: date1,
            dateFormat: "Y-m-d",
        });

        $(".ddlDay").val("0");
        $('.ddlDay').fSelect('reload');
    });
    
    $(document.body).on('change', '.ddlDay', function () {
        $(".txtFrom").val("");
        $(".nextdatepicker").val("");
        var f1 = flatpickr(document.getElementsByClassName('datepicker1'), {
            dateFormat: "Y-m-d",
        });
    });
    BindBookings();
    //Search Button
    $(document.body).on('click', ".BtnSearch", function () {
        $(".mppagination").empty();

        $('.loaderclass').removeClass("d-none")
        $('.mytablewrap').addClass("d-none")


        BindBookings();
    });
    $(document.body).on('change', ".pageLenght", function () {
        $(".mppagination").empty();

        $('.loaderclass').removeClass("d-none")
        $('.mytablewrap').addClass("d-none")


        BindBookings();
    });
    //Current Page
    $(document.body).on('click', ".pVClick", function () {
        var ele = $(this);
        $(".mppagination a").removeClass("active");
        ele.addClass("active");

        $('.loaderclass').removeClass("d-none")
        $('.mytablewrap').addClass("d-none")
        BindBookings();

    });

    //Previous Page
    $(document.body).on('click', ".prVClick", function () {
        var ele = $(this);
        $(".mppagination a").removeClass("active");
        ele.addClass("active");

        $('.loaderclass').removeClass("d-none")
        $('.mytablewrap').addClass("d-none")
        BindBookings();
    });

    //Next Page
    $(document.body).on('click', ".nxVClick", function () {
        var ele = $(this);
        $(".mppagination a").removeClass("active");
        ele.addClass("active");

        $('.loaderclass').removeClass("d-none")
        $('.mytablewrap').addClass("d-none")
        BindBookings();

    });




});

//Booking Table
function BindBookings() {


    // $('.loaderclass').removeClass("d-none")
    $('.mytablewrap').addClass("d-none")


    var PLenght = $(".pageLenght option:selected").val();
    var Sorting = $(".Sorting option:selected").val();
    var PageNo = "1";
    if ($(".mppagination li a").hasClass("active")) {
        PageNo = $(".mppagination li .active").attr('id').split('_')[1];
    }
    var Days = $('.ddlDay option:selected').val();
    var startDate = $('.txtFrom').val();
    var endDate = $('.txtTo').val();
    var searchkey = $(".txtSearch").val();
    var Orderstatus = $(".ddlStatus option:selected").val();
    var writer = $(".ddlwriter option:selected").val();
    var client = $(".ddlclient option:selected").val();
    //  var table = new DataTable('.myTable2');

    $.ajax({
        type: 'POST',
        url: "view-bookings.aspx/GetBookings",
        data: "{Days: '" + Days + "',startDate:'" + startDate + "',EndDate:'" + endDate + "',Key:'" + searchkey + "',PageNo:'" + PageNo + "',PageLenght:'" + PLenght + "',Ostatus :'" + Orderstatus + "'}",
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        async: false,
        success: function (data2) {
            if (data2.d == "Error") {
                $(".strTable").html("<tr><td colspan='12' class='text-center'>no data available in the table</td></tr>");
                $('.loaderclass').addClass("d-none");
                $('.mytablewrap').removeClass("d-none");
            }
            if (data2.d == "Empty") {
                $(".strTable").html("<tr><td colspan='12' class='text-center'>no data available in the table</td></tr>");
                $('.loaderclass').addClass("d-none")
                $('.mytablewrap').removeClass("d-none")
            }
            else {
                data = $.parseJSON(data2.d);
                $(".strTable").html(data.table);
                $('.loaderclass').addClass("d-none");
                $('.mytablewrap').removeClass("d-none");
                BindLPage(PageNo, PLenght, data.count);
            }
        }
    });

}

//New Pagination
function BindLPage(cPage, pageS, pCount) {

    var noOfPagesCreated = ~~(parseFloat(pCount) / parseInt(pageS));
    var isExtra = (parseFloat(pCount) % parseInt(pageS)) === 0 ? 0 : 1;

    noOfPagesCreated = noOfPagesCreated + isExtra;

    $(".mppagination").empty();

    var pagesss = "";

    var np = parseInt(cPage) % 5 === 0 ? (parseInt(cPage) / parseInt(5) - 1) : parseInt(cPage) / parseInt(5);
    var nearestNextP = (~~np + 1) * 5;
    var pLength = noOfPagesCreated < parseInt(nearestNextP) ? noOfPagesCreated : parseInt(nearestNextP);
    var startPage = (parseInt(nearestNextP) - 4);

    if (parseInt(cPage) > 5) {
        pagesss += "<li class='page-item'><a class='page-link pVClick' href='javascript:void(0);' id='pno_1'>1</a></li>";
        pagesss += "<li class='page-item'><a class='page-link pVClick' href='javascript:void(0);' id='pno_1'>...</a></li>";
    }

    for (var i = startPage; i <= pLength; i++) {
        var act = i === parseInt(cPage) ? "active" : "";
        pagesss += "<li class='page-item'><a class='page-link pVClick " + act + "' href='javascript:void(0);' id='pno_" + (i) + "'>" + (i) + "</a></li>";
    }
    if (noOfPagesCreated > pLength) {
        pagesss += "<li class='page-item'><a class='page-link pVClick' href='javascript:void(0);' id='pno_" + (pLength + 1) + "'>...</a></li>";
        pagesss += "<li class='page-item'><a class='page-link pVClick' href='javascript:void(0);' id='pno_" + (noOfPagesCreated) + "'>" + (noOfPagesCreated) + "</a></li>";
    }
    var prvPg = startPage === 1 ? 1 : startPage - 1;
    var nxtPg = noOfPagesCreated > pLength ? (pLength + 1) : pLength;
    if (noOfPagesCreated <= 5) {
        prvPg = parseInt(cPage) === 1 ? 1 : parseInt(cPage) - 1;
        nxtPg = parseInt(cPage) === pLength ? pLength : parseInt(cPage) + 1;
    }

    var pgnPrev = "";
    if (parseInt(cPage) > 1) {
        pgnPrev = "<li class='page-item'><a id='pnon_" + prvPg + "' class='page-link prVClick' href='javascript:void(0);' aria-label='Previous'><i class='mdi mdi-chevron-left'></i> Previous</a></li>";
    }
    else {
        pgnPrev = "<li class='page-item'><a id='pnon_" + prvPg + "' class='page-link disabled' href='javascript:void(0);' aria-label='Previous'><i class='mdi mdi-chevron-left'></i> Previous</a></li>";
    }

    var pgnNext = "";

    if (nxtPg != parseInt(cPage)) {
        pgnNext = "<li class='page-item'><a class='page-link nxVClick' href='javascript:void(0);' id='pnon_" + nxtPg + "' aria-label='Next'>Next <i class='mdi mdi-chevron-right'></i></a></li>";
    }
    else {
        pgnNext = "<li class='page-item'><a class='page-link disabled' href='javascript:void(0);' id='pnon_" + nxtPg + "' aria-label='Next'>Next <i class='mdi mdi-chevron-right'></i></a></li>";
    }

    $(".mppagination").append(pgnPrev + pagesss + pgnNext);
}