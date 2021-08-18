function launch_toast(desc, color, iconCode) {
    $('#desc').html(desc);
    $('#desc').css('color', color);
    $('#msgIcon').attr('class', iconCode);
    var x = document.getElementById("toast");
    x.className = "show";
    setTimeout(function () { x.className = x.className.replace("show", ""); }, 3000);
}
