function getClass(event) {
    var icons = document.querySelectorAll(".icon_contain svg");
    for (var i = 0; i < icons.length; i++) {
        icons[i].style.color = "black";
    }
    var class_name = event.getAttribute("class").split("--");
    event.style.color = "green";
    document.querySelector(".icon_name").value = class_name[1];
}