/// <reference path="jquery.validate.js" />
/// <reference path="jquery.validate.unobtrusive.min.js" />
$(function () {
    'use strict';

    var $countLike = $('#CountLike'),
        $commentTemplate = $('#commentTemplate'),
        $comments = $('#Comments'),
        $container = $('.container'),
        $sendComment = $('.sendcomment'),
        $changeStatus = $('.change-status'),
        $textOfStatus = $('#text-status');

    $container.on("click", "#like", function (e) {
        var element = (this);
        e.preventDefault();
        $.ajax({
            url: $(element).attr("data-href"),
            data: null,
            type: 'Post',
            success: function (data) {
                $countLike.text(data);
            }
        })
    })
    $changeStatus.on("click", "#send-status", function (e) {
        var element = (this);
        e.preventDefault();
        $.ajax({
            url: $(element).attr("data-href"),
            data: {status: $('#status').val()},
            type: 'Post',
            success: function (data) {
                $textOfStatus.text(data);
            }
        })
    })
    $container.on("click", "#add-comment", function (e) {
        var element = (this);
        e.preventDefault();
        $.ajax({
            url: $(element).attr("data-href"),
            data: { text: $(".text-comment").val() },
            type: 'Post',
            dataType: 'json',
            success: function (result) {
                //debugger;
                var compileFn = _.template($commentTemplate.html()),
                    dateInMS;

                dateInMS = parseInt(result.Date.match(/\d/ig).join(''));
                result.Date = moment(dateInMS).format('DD.MM.YYYY HH:mm:ss');
                $comments.append(compileFn(result));
            }
        })
    });

    $container.on("click", "#delete-comment", function (e) {
        var element = (this);
        e.preventDefault();
        $.ajax({
            url: $(element).attr("href"),
            data: { text: $(".text-comment").val() },
            type: 'Post',
            dataType: 'json',
            success: function (result) {
                element.closest('.comment').remove();
            }
        })
    });


    $sendComment.click(function () {
        $.ajax({
            url: '/Comment/GetComment',
            contentType: 'application/json; charset=utf-8',
            type: 'GET',
            dataType: 'json',
            data: { text: $('textarea').val() },
            success: function (result) {
                $('.place-for-comments').html(result);
            }
        })
    })

});
