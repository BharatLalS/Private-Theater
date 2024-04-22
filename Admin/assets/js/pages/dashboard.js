var url = 'dashboard.aspx/DashBoardChart';

$.ajax({
    type: 'POST',
    url: url,
    data: "{}",
    contentType: 'application/json; charset=utf-8',
    dataType: "json",
    async: false,
    success: function (data) {
        if (data.d.toString() != "Error") {

            tablevalues = $.parseJSON(data.d);

            // RevenueChart(tablevalues.Total, tablevalues.Complete);
            $(".totalOrder").attr("data-target", tablevalues.Total);
            $(".totalOrder").html(tablevalues.Total);
            $(".totalSale").attr("data-target", tablevalues.Sales);
            $(".totalSale").html(tablevalues.Sales);
            $(".CompletedOrder").attr("data-target", tablevalues.Complete);
            $(".CompletedOrder").html(tablevalues.Complete);
            $(".convRatio").attr("data-target", tablevalues.ConvPercent.toFixed(2));
            $(".convRatio").html(tablevalues.ConvPercent.toFixed(2));
            var orderStatus = [];
            var statuscount = [];
            var statuscolor = []
            if (tablevalues.Created > 0) {
                orderStatus.push("Created");
                statuscount.push(tablevalues.Created)
                statuscolor.push("#4b38b3");

            }
            if (tablevalues.Complete > 0) {
                orderStatus.push("Completed");
                statuscount.push(tablevalues.Complete)
                statuscolor.push("#45cb85");
            } if (tablevalues.Cancle > 0) {
                orderStatus.push("Cancelled");
                statuscount.push(tablevalues.Cancle)
                statuscolor.push("#f06548");
            }
            OrderChart(orderStatus, statuscount, statuscolor);
        }
    }
});

$.ajax({
    type: 'POST',
    url: 'dashboard.aspx/DashBoardRevenue',
    data: "{}",
    contentType: 'application/json; charset=utf-8',
    dataType: "json",
    async: false,
    success: function (data) {
        if (data.d.toString() != "Error") {

            tablevalues = $.parseJSON(data.d);

            RevenueChart(tablevalues.Months.reverse(), tablevalues.TotalPayments.reverse(), tablevalues.CompletedPayments.reverse());
        }

    }
});

function OrderChart(status, count, color) {
    var options = {
        series: count,
        labels: status,
        chart: { height: 333, type: "donut" },
        legend: { position: "bottom" },
        stroke: { show: !1 },
        dataLabels: { dropShadow: { enabled: !1 } },
        colors: color,
    }
    var chart = new ApexCharts(document.querySelector("#OrderStatusChart"), options);
    chart.render();
}

function RevenueChart(Months, Total, Completed) {

    var options = {
        series: [
            { name: "Total Payments", type: "area", data: Total },
            { name: "Completed Payments", type: "area", data: Completed },
        ], chart: {
            height: 370,
            type: "area",
            toolbar: false
        },
        dataLabels: { enabled: !1 },
        stroke: { curve: "smooth", dashArray: [0, 0, 8], width: [2, 0, 2.2] },
        fill: { opacity: [0.1, 0.2/*, 1*/] },
        markers: { size: [0, 0, 0], strokeWidth: 2, hover: { size: 4 } },
        xaxis: {
            categories: Months,
            axisTicks: { show: !1 },
            axisBorder: { show: !1 }
        },
        yaxis: {
            labels: {
                formatter: function (e) {
                    return "$" + e
                }
            },
            grid: {
                show: !0, xaxis:
                {
                    lines: { show: !0 }
                },
                yaxis:
                {
                    lines:
                    {
                        show: !1
                    },
                    padding:
                    {
                        top: 0,
                        right: -2,
                        bottom: 15,
                        left: 10
                    }
                },
                legend: {
                    show: !0,
                    horizontalAlign: "center",
                    offsetX: 0,
                    offsetY: -5,
                    markers: { width: 9, height: 9, radius: 6 },
                    itemMargin: { horizontal: 10, vertical: 0 }
                },
                plotOptions: {
                    bar:
                        { columnWidth: "30%", barHeight: "70%" }
                },
                colors: ['#3577f1', '#45cb85'],
                tooltip: {
                    shared: !0,
                },
            }
        }
    }
    var chart = new ApexCharts(document.querySelector("#orderRevenueChart"), options);
    chart.render();
}
$(document).ready(function () {
    BindBookings();

    $(document.body).on('change', '.ddldays', function () {
        BindBookings();
    });
});


function BindBookings() {


   
    
    var Days = $('.ddldays option:selected').val();
    
    //  var table = new DataTable('.myTable2');

    $.ajax({
        type: 'POST',
        url: "dashboard.aspx/GetBookings",
        data: "{Days: '" + Days + "'}",
        contentType: 'application/json; charset=utf-8',
        dataType: "json",
        async: false,
        success: function (data2) {
            if (data2.d == "Error") {
                $(".strTable").html("<tr><td colspan='12' class='text-center'>no data available in the table</td></tr>");
            }
            if (data2.d == "Empty") {
                $(".strTable").html("<tr><td colspan='12' class='text-center'>no data available in the table</td></tr>");
            }
            else {
                data = $.parseJSON(data2.d);
                $(".strTable").html(data.table);
            }
        }
    });

}
