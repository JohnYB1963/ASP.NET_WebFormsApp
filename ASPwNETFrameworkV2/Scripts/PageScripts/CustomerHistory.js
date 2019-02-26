function getHistory() {

    if ((JSON.parse(sessionStorage.getItem("customer")) === null)) {
        alert("no customer selected");
    }

    var info = {
        id: JSON.parse(sessionStorage.getItem("customer")).CustomerID,
        name: JSON.parse(sessionStorage.getItem("customer")).CustomerName
    };

    $.ajax({
        type: "POST",
        url: '/CoreMessaging.asmx/GetCustomerHistory',
        data: JSON.stringify(info),
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            if (data.d) {
                console.log(data.d);
                //$.each(data.d, function (index, value) {
                //    console.log(value.CustomerName + "hi");});
                createTable(data.d);
            }
            else {
                alert("Something went wrong when trying to retrieve customer purchase history.")
            }
        },
        failure: function (response) {
            alert(response.d);
        }
    });
}
function createTable(data) {

    $.each(data, function (index, value) {

        var row = "<tr>";

        row += "<td>" + value.PurchaseID + "</td>";
        row += "<td>" + value.PurchaseAmmount + "</td>";
        row += "<td>" + value.DateofPurchase + "</td>";
        row += "<td>" + value.PurchaseDesc + "</td>";
        
        row += "</tr>";

        $("#purchaseHistory tbody").append(row);

    });
}

//stolen from stack overflow
function ToJavaScriptDate(value) {
    var pattern = /Date\(([^)]+)\)/;
    var results = pattern.exec(value);
    var dt = new Date(parseFloat(results[1]));
    return (dt.getMonth() + 1) + "/" + dt.getDate() + "/" + dt.getFullYear();
}