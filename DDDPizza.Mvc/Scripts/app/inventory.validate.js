$(document).ready(function () {


    var hasPrice = false;

    if ($("#Item_Price").length >= 1) {
        // Credit to 
        // http://stackoverflow.com/questions/25526436/jquery-input-mask-decimal-point
        $("#Item_Price").inputmask({ 'mask': "9{0,5}.9{0,2}", greedy: false });
        hasPrice = true;
    }

    if ($('.custom-error').children('span.field-validation-valid').length >= 1) {
        $('.custom-error').hide(); // no errors
    } else {
        $('.custom-error').show(); // errors
    }


    $("#Item_Name, #Item_Price").on("change", function () {
        if ($("#Item_Name").val().length === 0 && !hasPrice) {
            $("#btnSave").removeAttr("enabled");
            $("#btnSave").attr("disabled", "disabled");
        }
        else if ($("#Item_Name").val().length === 0 && hasPrice) {
            $("#btnSave").removeAttr("enabled");
            $("#btnSave").attr("disabled", "disabled");
        }
        else if ($("#Item_Price").val().length === 0 && hasPrice) {
            $("#btnSave").removeAttr("enabled");
            $("#btnSave").attr("disabled", "disabled");
        }
        else {
            $("#btnSave").removeAttr("disabled");
            $("#btnSave").attr("enabled", "enabled");
        }
    });

    $("#Item_Name").trigger("change");



});

