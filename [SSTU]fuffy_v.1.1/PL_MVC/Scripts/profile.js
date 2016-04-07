var like = 0;
var yhl = 0;

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

