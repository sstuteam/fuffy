$(document.body).on("click", "#status", function (e) {
    var element = (this);
    e.preventDefault();
    $.ajax({
        url: $(element).attr("data-href"),
        data: { Name: $(".Name").val() },
        type: 'Get',
        dataType: 'json',
        success: function (result) {
            $(result).each(function (index, item) {
                $("#Relaod").empty();
                $("#Reload").append(item.Name);
            });
            
        }
    })
})
