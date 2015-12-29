function changeBackground1() {
    document.body.style.backgroundImage = "url('Styles/Images/symphony.png')";
}

function changeBackground2() {
    document.body.style.backgroundImage = "url('Styles/Images/skulls.png')";
}

function changeBackground3() {
    document.body.style.backgroundImage = "url('Styles/Images/pink_rice.png')";
}

function changeBackground4() {
    document.body.style.backgroundImage = "url('Styles/Images/restaurant_icons.png')";
}
function changeBackground5() {
    document.body.style.backgroundImage = "url('Styles/Images/congruent_pentagon.png')";
}

function goToPage(str) {
    var url = document.getElementById(str);
    document.location.href = url.value;
}
