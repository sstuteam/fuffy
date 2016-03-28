var like = 0;
var yhl = 0;
//$('.item').html('<img src = "/Content/Photo/forProfile.jpg" />');
$('#myModalLabel').text('Title');
//$('#modal-body-photos').html('<img src = "/Content/Photo/forProfile.jpg" /><br/><button type="submit" class="like" id="like">0</button><br/><form><textarea class="comment"></textarea><br /><br /><button type="button" class="btn btn-primary">Send</button></form>');
$('#albums-modal').text('Albums');

$('#albums-modal').text('Albums');

$('.like').click(function () {
    if (yhl == 0) {
        like = like + 1;
        $('.like').text(like);
    }
    yhl = 1;
})

    $('#sendcomment').click(function () {
        $.ajax({
            url: '/Comment/AddComment',
            contentType: 'application/json; charset=utf-8',
            type: 'GET',
            dataType: 'json',
            data: { text: $('textarea').val() },
            success: function (result) {
                var s = "";
                for (var i = 0; i < result.length; i++) {
                    s = 'text:' + result[i].text;
                }
                $('#placeforcomment').html(result);
                $('textarea').val("");
            }
        })
    })

