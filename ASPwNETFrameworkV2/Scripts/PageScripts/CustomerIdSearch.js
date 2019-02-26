function getCustomer() {

    $("#custId").empty();
    $("#custName").empty();
    $("#custPurchase").empty();
    $("#custLocation").empty();

    var info = { id: $("#txtarea").val() };

    $.ajax({
        type: "POST",
        url: '/CoreMessaging.asmx/GetCustomer',
        data: JSON.stringify(info),
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d == null) {
                console.log("Invalid Customer Id");
                alert("Invalid Customer Id");
            }
            else {
                $("#custId").html(data.d.CustomerID.toString());
                $("#custName").html(data.d.CustomerName.toString());
                $("#custPurchase").html(data.d.CustomerPurchase.toString());
                $("#custLocation").html(data.d.Location.toString());

                sessionStorage.setItem("customer", JSON.stringify(data.d));

                //console.log(JSON.parse(sessionStorage.getItem("customer")));

                alert("Customer selected");
            }
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}
