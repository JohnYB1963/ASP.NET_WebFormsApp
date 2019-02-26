$(document).ready(function () {
    if (!(JSON.parse(sessionStorage.getItem("customer")) === null)) {
        $("#CustId").text(JSON.parse(sessionStorage.getItem("customer")).CustomerID);
        $("#CustName").text(JSON.parse(sessionStorage.getItem("customer")).CustomerName);
        $("#CustPurchase").text(JSON.parse(sessionStorage.getItem("customer")).CustomerPurchase);
        $("#CustLocation").text(JSON.parse(sessionStorage.getItem("customer")).Location);
    }
});

function updateCustomer() {

    var info = {
        id: JSON.parse(sessionStorage.getItem("customer")).CustomerID,
        name: $("#updateName").val(),
        purchase: $("#updatePurchase").val(), location: $("#updateLocation").val()
    };

    $.ajax({
        type: "POST",
        url: '/CoreMessaging.asmx/UpdateCustomer',
        data: JSON.stringify(info),
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d) {
                alert("Customer successfully updated.")
                sessionStorage.setItem("customer", JSON.stringify(data.d));
                location.reload();
            }
            else {
                alert("Something went wrong when trying to save customer data.")
            }
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}