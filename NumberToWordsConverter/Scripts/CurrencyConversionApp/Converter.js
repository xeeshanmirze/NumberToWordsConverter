$(document).ready(function () {
    $('#currencyconverterform').submit(function () {
        $.ajax({
            url: 'http://localhost:60005/api/CurrencyConverter',
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({
                Name: $('#name').val(),
                Currency: $('#currency').val()
            }),
            beforeSend : function()
            {
                $("#responseName").text("");
                $("#responseCurrency").text("");
                $("#responseErrorMessage").text("");
                $("#responseErrorMessageDetail").text("");
            },
            success: function (result) {
                $("#responseName").text(result.Name);
                $("#responseCurrency").text(result.CurrencyInWords);
            },
            error: function (result) {
                var errMesasgeObject = $.parseJSON(result.responseText);
                $("#responseErrorMessage").text("Failed: " + errMesasgeObject.Message);
                $("#responseErrorMessageDetail").text();
            }
        });
        return false;
    });
});