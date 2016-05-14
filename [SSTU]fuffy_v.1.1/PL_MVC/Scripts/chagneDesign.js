/// <reference path="jquery.validate.js" />
/// <reference path="jquery.validate.unobtrusive.min.js" />
var prf = $('.preference').html();
if (prf == "sport                                             ")
{
    document.body.style.backgroundImage = 'url(../Content/Photo/sport.png)';
    $('.navbar').css("backgroundColor", "rgb(70, 54, 111)");
    $('.navbar').css("border-color", "rgb(70, 54, 111)");
}
if (prf == "culture                                           ") {
    document.body.style.backgroundImage = 'url(../Content/Photo/culture.jpg)';
    $('.navbar').css("backgroundColor", "rgb(40, 113, 146)");
    $('.navbar').css("border-color", "rgb(40, 113, 146)");
}
if (prf == "science                                           ") {
    document.body.style.backgroundImage = 'url(../Content/Photo/science.jpg)';
    $('.navbar').css("backgroundColor", "rgb(31, 31, 31)");
    $('.navbar').css("border-color", "rgb(31, 31, 31)");
}
if (prf == "policy                                            ") {
    document.body.style.backgroundImage = 'url(../Content/Photo/policy.jpg)';
    $('.navbar').css("backgroundColor", "#288470");
    $('.navbar').css("border-color", "#288470");
}