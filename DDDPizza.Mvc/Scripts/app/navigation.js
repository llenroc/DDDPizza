
$(document).on('ready', function() {

    if (location.pathname == "/") {
        $("#home").addClass("active");
    } else {
        var words = location.pathname.split('/');

        words.forEach(function (word) {
            $("#" + word.toLowerCase()).addClass("active");
        });
    }
   
});


