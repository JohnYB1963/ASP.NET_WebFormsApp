$(document).ready(function () {

    console.log(JSON.parse(sessionStorage.getItem("customer")));

    if (!(sessionStorage.getItem("customer") === null)) {

        var mycustomer = JSON.parse(sessionStorage.getItem("customer"));

        console.log(mycustomer.CustomerID);
        $("#CustomerId").text(mycustomer.CustomerID);
        $("#CustomerName").text(mycustomer.CustomerName);
        $("#CustomerPurchase").text(mycustomer.CustomerPurchase);
        $("#CustomerLocation").text(mycustomer.Location);
    }
});