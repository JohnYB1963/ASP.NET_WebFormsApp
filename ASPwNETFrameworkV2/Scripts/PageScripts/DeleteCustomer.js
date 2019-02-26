function DeleteCustomer() {

    if (!(JSON.parse(sessionStorage.getItem("customer")) === null)) {
        //console.log(JSON.parse(sessionStorage.getItem("customer")));
        var info = { id: JSON.parse(sessionStorage.getItem("customer")).CustomerID };

        $.ajax({
            type: "POST",
            url: '/CoreMessaging.asmx/DeleteCustomer',
            data: JSON.stringify(info),
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                console.log(data);
                sessionStorage.setItem("customer", null);
                location.reload();
            },
            failure: function (data) {
                console.log(data);
            }
        });
    }
    else {
        alert("You must select a customer before they can be deleted");
    }
}
$(document).ready(function () {
    if (!(JSON.parse(sessionStorage.getItem("customer")) === null))
    {
        $("#CustId").text(JSON.parse(sessionStorage.getItem("customer")).CustomerID);
        $("#CustName").text(JSON.parse(sessionStorage.getItem("customer")).CustomerName);
        $("#CustPurchase").text(JSON.parse(sessionStorage.getItem("customer")).CustomerPurchase);
        $("#CustLocation").text(JSON.parse(sessionStorage.getItem("customer")).Location);
    }
});

