function findMatchingCustomers() {

    var info = {
        name: $("#txtName").val(),
        purchase: $("#txtPurchase").val(), location: $("#txtLocation").val()
    };

    $.ajax({
        type: "POST",
        url: '/CoreMessaging.asmx/FindMatchingCustomers',
        data: JSON.stringify(info),
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            $("#outputData").remove();
            $("#DetailSearch").append("<div id='outputData'></div>");
            
            for (var ele of data.d) {
                var text = "<li>" + ele.CustomerID + " " + ele.CustomerName + " " + ele.CustomerPurchase + " " +
                    ele.Location + "<input type='button' value='Select' onclick='selectCustomer(" + ele.CustomerID + ")'/></li>";
                $("#outputData").append(text);
            }

            $("#numCustomers").text("Total customers based on that search criteria are: " + data.d.length.toString());
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}

function selectCustomer(id) {

    info = { id: id };

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

                sessionStorage.setItem("customer", JSON.stringify(data.d));
                alert("Cuustomer selected");
            }
        },
        failure: function (response) {
            alert(response.d);
        }

    });
}