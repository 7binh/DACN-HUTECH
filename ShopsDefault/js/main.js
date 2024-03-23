$(function () {
    var pgurl = window.location.href.substr(window.location.href.lastIndexOf("/"));
    $(".hd-nav li a").each(function () {
        if ($(this).attr("href") == pgurl || $(this).attr("href") == '') {
            $(this).closest('li').addClass("active");
        }
            
    })
});