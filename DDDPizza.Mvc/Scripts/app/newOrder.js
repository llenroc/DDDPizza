


$(document).ready(function() {

    var countToppings = 1;

    function toppingButton(count) {

        var remaining = 5 - count;
        console.log(count);

        if (count === 1) {
            $('#removeTopping').attr('disabled', 'disabled');
        } else {
            $('#removeTopping').removeAttr('disabled');
        }

        if (count > 4) {
            $('#addTopping').text("No more toppings!");
            $('#addTopping').attr('disabled', 'disabled');
        } else {
            $('#addTopping').text("Add " + remaining + " more toppings");
            $('#addTopping').removeAttr('disabled');
        }

        if (count > 1) {
            $('#toppingsRow').find('#removeTopping').hide();
        }

    }

    toppingButton(countToppings);

   

    $(document).on('click', '#addTopping', function () {
        var copyRow = $('#toppingsRow', document).clone();
        $('.form-horizontal').append(copyRow);

        countToppings++;
        toppingButton(countToppings);
    });


    $(document).on('click', '#removeTopping', function() {
        $('.form-horizontal>div').last().remove();
        countToppings--;   
        toppingButton(countToppings);
    });


    $(".custom-error>span").each(function (index, element) {

        if ($(this).text().length === 0) {
            $(this).parent().hide();
        } else {
            $(this).parent().show();
        }
    });

});