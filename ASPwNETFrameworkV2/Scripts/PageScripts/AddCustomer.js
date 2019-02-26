function addCustomer() {

    var info = {
        id: $("#addId").val(),
        name: $("#addName").val(),
        purchase: $("#addPurchase").val(), location: $("#addLocation").val()
    };

    if (checkProperties(info)) {
        console.log("You must complete all text boxes with valid entries");
        return;
    }

    if (isNaN(info.id) || isNaN(info.purchase)) {
        console.log("You must complete all text boxes with valid entries 2");
        return;
    }

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
function checkProperties(obj) {
    //returns false if all properties of the object are not null or an empty string
    return Object.keys(obj).every(function (x) {
        return obj[x] === '' || obj[x] === null;  // or just "return o[x];" for falsy values
    });
}