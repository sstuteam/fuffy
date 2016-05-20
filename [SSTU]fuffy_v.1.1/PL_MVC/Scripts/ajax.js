//$(document.body).on("click", "#news", function (e) {
//    e.preventDefault();
//    var url = $(this).attr("href");
//    $.ajax({
//        url: url,
//        data: null,
//        type: 'GET',
//        success: function (result) {
//            $('body').empty().append(result);
//            //...
//        }
//    })
//        // меняется ссылка
//        if (url != window.location) {
//        window.history.pushState(null, null, $(this).attr("href"));
//        }
//        return false;
//    })
//$(document.body).on("click", "#settings", function (e) {
//    e.preventDefault();
//    $.ajax({
//        url: $(this).attr("href"),
//        data: null,
//        type: 'get',
//        success: function (result) {
//            $('body').empty().append(result);
//        }
//    })
//    if (url != window.location) {
//        window.history.pushState(null, null, $(this).attr("href"));
//    }
//    return false;
//})
//$(document.body).on("click", "#add-album", function (e) {
//    e.preventDefault();
//    var url = $(this).attr("href");
//    $.ajax({
//        url: url,
//        data: null,
//        type: 'GET',
//        success: function (result) {
//            $('body').empty().append(result);
//            //...
//        }
//    })
//    if (url != window.location) {
//        window.history.pushState(null, null, $(this).attr("href"));
//    }
//    return false;
//})
//$(document.body).on("click", "#add-photo", function (e) {
//    e.preventDefault();
//    var url = $(this).attr("href");
//    $.ajax({
//        url: url,
//        data: null,
//        type: 'GET',
//        success: function (result) {
//            $('body').empty().append(result);
//            //...
//        }
//    })
//    if (url != window.location) {
//        window.history.pushState(null, null, $(this).attr("href"));
//    }
//    return false;
//})
//$(document.body).on("click", "#people", function (e) {
//    e.preventDefault();
//    var url = $(this).attr("href");
//    $.ajax({
//        url: url,
//        data: null,
//        type: 'GET',
//        success: function (result) {
//            $('body').empty().append(result);
//            //...
//        }
//    })
//    if (url != window.location) {
//        window.history.pushState(null, null, $(this).attr("href"));
//    }
//    return false;
//})
//$(document.body).on("click", "#profile", function (e) {
//    e.preventDefault();
//    var url = $(this).attr("href");
//    $.ajax({
//        url: url,
//        data: null,
//        type: 'GET',
//        success: function (result) {
//            $('body').empty().append(result);
//            //...
//        }
//    })
//    if ($(this).attr("href") != window.location) {
//        window.history.pushState(null, null, $(this).attr("href"));
//    }
//    return false;
//})