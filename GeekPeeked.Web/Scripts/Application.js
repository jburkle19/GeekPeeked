$(document).ready(function () {
    $(".navbar-toggle").on('click', function (event) {
        event.preventDefault();
        if ($("#outer-wrapper").hasClass("toggled")) {
            $("#outer-wrapper").removeClass("toggled");
            $(".navbar-brand").removeClass("toggled");
        } else {
            $("#outer-wrapper").addClass("toggled");
            $(".navbar-brand").addClass("toggled");
        }
    });
    $(".confirm").on('click', function (e) {
        if (!confirm($(this).data("confirm"))) {
            e.preventDefault();
        }
    });
});