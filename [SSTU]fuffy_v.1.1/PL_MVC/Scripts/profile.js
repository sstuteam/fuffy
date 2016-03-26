var like = 0;
var yhl = 0;
//$('.item').html('<img src = "/Content/Photo/forProfile.jpg" />');
$('#myModalLabel').text('Title');
//$('#modal-body-photos').html('<img src = "/Content/Photo/forProfile.jpg" /><br/><button type="submit" class="like" id="like">0</button><br/><form><textarea class="comment"></textarea><br /><br /><button type="button" class="btn btn-primary">Send</button></form>');
$('#albums-list').html('Albums:<ol><li><div class="album-cover row"><section class="col-md-12 demo-1"><div class="grid"><div class="box"><svg xmlns="http://www.w3.org/2000/svg" width="100%" height="100%"><line class="top" x1="0" y1="0" x2="900" y2="0" /><line class="left" x1="0" y1="460" x2="0" y2="-920" /><line class="bottom" x1="300" y1="460" x2="-600" y2="460" /><line class="right" x1="300" y1="0" x2="300" y2="1380" /></svg><img class="size" src="/Content/Photo/forProfile.jpg" /></div></div></section></div>       <div class="album-name row"> <a>Album s Name</a></div> </li></ol>');


$('#albums-modal').text('Albums');
$('#modal-body-photos').html('<img @Model src = "/Content/Photo/forProfile.jpg" /><br/><button type="submit" class="like" id="like">0</button><br/>' +
    '<div id="placeforcomment">' +

    '</div>' +
    '<form>' +
    '    <textarea id="comment">' + '</textarea>' +

    '    <a id="sendcomment">Send!</a>' +
    '</form>'); $('#modal-body-photos').html('<img src = "/Content/Photo/forProfile.jpg" /><br/><button type="submit" class="like" id="like">0</button><br/>' +
    '<div id="placeforcomment">' +

    '</div>' +
    '<form>' +
    '    <textarea id="comment">' + '</textarea>' +

    '    <a id="sendcomment">Send!</a>' +
    '</form>');
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

