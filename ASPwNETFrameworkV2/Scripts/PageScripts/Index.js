$(document).ready(function () {
    sessionStorage.setItem('customer', null);
    console.log(sessionStorage.getItem('customer'));
    console.log("the document was ready again");

    if (document.getElementById("test")) {
        console.log("the element exists");
    }
});

function testJS() {
    console.log("working");
    sessionStorage.setItem("test", "5");

    console.log(sessionStorage.getItem("test"));
}

function testAjax() {

    var name = "john";

    var info = { message: name};

    $.ajax({
    type: "POST",
    url: '/CoreMessaging.asmx/TestMethod',
    data: JSON.stringify(info),
    contentType: "application/json; charset=utf-8",
    success: function (data) {
        console.log(data);
    },
    failure: function (response) {
        alert(response.d);
    }});

}

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
                //console.log(data.d);
                //console.log(data.d.CustomerID.toString());
                $("#custId").html(data.d.CustomerID.toString());
                $("#custName").html(data.d.CustomerName.toString());
                $("#custPurchase").html(data.d.CustomerPurchase.toString());
                $("#custLocation").html(data.d.Location.toString());

                sessionStorage.setItem("customer", data.d.CustomerID.toString());

                console.log(sessionStorage.getItem("customer"));

            }
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}

function updateCustomer() {

    var info = {
        id: $("#custId").text(), name: $("#updateName").val(),
        purchase: $("#updatePurchase").val(), location: $("#updateLocation").val()
    };

    $.ajax({
        type: "POST",
        url: '/CoreMessaging.asmx/UpdateCustomer',
        data: JSON.stringify(info),
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            getCustomer();
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}

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
            $("body").append("<div id='outputData'></div>");

            for (var ele of data.d) {
                var text = "<p>" + ele.CustomerID + " " + ele.CustomerName + " " + ele.CustomerPurchase + " " + ele.Location + "</p>";
                $("#outputData").append(text);
            }
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}

function checkProperties(obj) {
    //returns false if all properties of the object are not null or an empty string
    return Object.keys(obj).every(function (x) {
        return obj[x] === '' || obj[x] === null;  // or just "return o[x];" for falsy values
    });
}

function addCustomer() {

    var info = {
        id: $("#addId").val(),
        name: $("#addName").val(),
        purchase: $("#addPurchase").val(), location: $("#addLocation").val()
    };

    if (checkProperties(info)) {
        console.log("You must complete all text boxes with valid entries");
        return;}

    if (isNaN(info.id) || isNaN(info.purchase)) {
        console.log("You must complete all text boxes with valid entries 2");
        return;}
      
    $.ajax({
        type: "POST",
        url: '/CoreMessaging.asmx/AddCustomer',
        data: JSON.stringify(info),
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            alert(data.d);
           
        },
        failure: function (response) {
            alert(response.d);
        }
    });


}