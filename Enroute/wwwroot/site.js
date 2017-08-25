(function () {

    var $sidebarAndWrapper = $("#sidebar,#wrapper");
    var $icon = $("#sidebarToggle i.glyphicon");
    $("#sidebarToggle").on("click", function () {
        $sidebarAndWrapper.toggleClass("hide-sidebar");
        if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
            $icon.removeClass("glyphicon-chevron-left");
            $icon.addClass("glyphicon-chevron-right");
        }
        else {
            
            $icon.removeClass("glyphicon-chevron-right");
            $icon.addClass("glyphicon-chevron-left");
        }
    }
    )



})();