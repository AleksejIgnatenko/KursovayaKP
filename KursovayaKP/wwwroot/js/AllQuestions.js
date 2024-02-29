document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("settingsButton").addEventListener("click", function () {
        var toolsMenu = document.getElementById("toolsMenu");
        if (toolsMenu.style.display === "none") {
            toolsMenu.style.display = "block";
        } else {
            toolsMenu.style.display = "none";
        }
    });
});