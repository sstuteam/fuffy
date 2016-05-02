/// <reference path="jquery.validate.js" />
/// <reference path="jquery.validate.unobtrusive.min.js" />
var like = 0;
var yhl = 0;

//$('.like').click(function () {
//    if (yhl == 0) {
//        like = like + 1;
//        $('.like').text(like);
//    }
//    yhl = 1;
//})

$(document.body).on("click", "#like", function (e) {
    var element = (this);
    e.preventDefault();
    $.ajax({
        url: $(element).attr("data-href"),
        data: null,
        type: 'Post',
        success: function (data) {
            $('#CountLike').text(data);
        }
    })
})


    //$('.sendcomment').click(function () {
    //    $.ajax({
    //        url: '/Comment/GetComment',
    //        contentType: 'application/json; charset=utf-8',
    //        type: 'GET',
    //        dataType: 'json',
    //        data: { text: $('textarea').val() },
    //        success: function (result) {
    //            $('.place-for-comments').html(result);
    //        }
    //    })
    //})

