var like = 0;
var yhl = 0;
$('.item').html('<img src = "/Content/Photo/forProfile.jpg" />');
$('#myModalLabel').text('Title');
$('#modal-body-photos').html('<img src = "/Content/Photo/forProfile.jpg" /><br/><button type="submit" class="like" id="like">0</button><br/><form><textarea class="comment"></textarea><br /><br /><button type="button" class="btn btn-primary">Send</button></form>');
$('#albums-list').html('Albums:<ol><li><div class="album-cover row"><section class="col-md-12 demo-1"><div class="grid"><div class="box"><svg xmlns="http://www.w3.org/2000/svg" width="100%" height="100%"><line class="top" x1="0" y1="0" x2="900" y2="0" /><line class="left" x1="0" y1="460" x2="0" y2="-920" /><line class="bottom" x1="300" y1="460" x2="-600" y2="460" /><line class="right" x1="300" y1="0" x2="300" y2="1380" /></svg><img class="size" src="/Content/Photo/forProfile.jpg" /></div></div></section></div>       <div class="album-name row"> <a>Album s Name</a></div> </li></ol>');


$('#albums-modal').text('Albums');
$('#modal-body-albums').html('<div class="row"><div class="col-sm-3 col-xs-3"> <img class="row album-name size albums-sm-in-modal" src="/Content/Photo/forProfile.jpg"/><a>Album s Name</a></div></div>' + '<br /><div class="row"><div class="col-sm-6 album-name"><a>Add a new album</a></div></div>');

$('#like').click(function () {
    if (yhl == 0) {
        like = like + 1;
        $('.like').text(like);
    }
    yhl = 1;
})
$('#albums').click(function () {
    $('.content-cell-flank-right').show();
    if (left == 1 && right == 1) {
        $('.col-md-12').removeClass('col-md-12').addClass('col-md-9');
    }
    if (left == 0 && right == 1) {
        $('.col-md-9').removeClass('col-md-9').addClass('col-md-6');
    }
    right = 0;
})


