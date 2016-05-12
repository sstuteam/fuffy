/// <reference path="jquery.validate.js" />
/// <reference path="jquery.validate.unobtrusive.min.js" />

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

$(document.body).on("click", "#add-comment", function (e) {
    var element = (this);
    e.preventDefault();
    $.ajax({
        url: $(element).attr("data-href"),
        data: { text: $(".text-comment").val() },
        type: 'Post',
        dataType: 'json',
        success: function (result) {
            //var s = '';
            //for (var i = 0; i < result.length; i++) {
            //$("#Comments").html("@foreach (var item in Model){<div class="+"comment"+">"+
            //       +"<div class="+"comment-author"+">"+
            //           +"<b><a href="+"@Url.Action("+"GetOtherUserPage"+","+ "People"+", new { idOtherUser=item.UserId })"+result[i]+".GetUserName()</a></b>@Html.DisplayFor(modelItem => item.Date)"+
            //               +"</div>"+
            //       +"<div class="+"comment-text"+">"+
            //           +"@Html.DisplayFor(modelItem => item.Text)"+result[i].Text+
            //       +"</div>"+
            //       +"@if (ViewBag.UserId == item.UserId)"+
            //               +"{"+
            //           +"<div class="+"comment-edit"+">"+
            //               +"@Html.ActionLink("+"Edit"+","+ "EditComment"+", new { commentId = item.CommentId })"+
            //           +"</div>"+
            //               +"<div class="+"comment-edit"+">"+
            //                   +"@Html.ActionLink("+"DeleteComment"+"," +"DeleteComment"+","+ "new { commentId = item.CommentId })"+
            //               +"</div>}"+
            //   +"</div>"
            //)
  //} 
            $(result).each(function (index, item) {
                $("#Comments").empty();
                $("#Comments").append( item.Text );
            });
            
        }
    })
})
$(document.body).on("click", "#delete-comment", function (e) {
    var element = (this);
    e.preventDefault();
    $.ajax({
        url: $(element).attr("href"),
        data: { text: $(".text-comment").val() },
        type: 'Post',
        dataType: 'json',
        success: function (result) {
            $(result).each(function (index, item) {
                $("#Comments").empty();
                $("#Comments").html(item.Text);
            });
        }
    })
})
$(document.body).on("click", "#delete-photo", function (e) {
    var element = (this);
    e.preventDefault();
    $.ajax({
        url: $(element).attr("href"),
        data: null,
        type: 'Post',
        success: function (result) {
            $('#Comments').val(result)
        }
    })
})
    $('.sendcomment').click(function () {
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

