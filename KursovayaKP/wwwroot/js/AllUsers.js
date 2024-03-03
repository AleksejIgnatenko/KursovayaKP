/*document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("moreDetailedButton").addEventListener("click", function (event) {
        event.preventDefault(); // Предотвращаем перезагрузку страницы

        var toolsMenu = document.getElementById("detailedInformation");
        if (toolsMenu.style.display === "none") {
            toolsMenu.style.display = "block";
        } else {
            toolsMenu.style.display = "none";
        }
    });
});*/

function initializePage() {
    event.preventDefault();
    var toolsMenu = document.getElementById("detailedInformation");
    if (toolsMenu.style.display === "none") {
        toolsMenu.style.display = "block";
    } else {
        toolsMenu.style.display = "none";
    }
}

function initializePage(userId) {
    event.preventDefault();

    // Отправляем данные на сервер вместе с идентификатором пользователя и названием теста
    var data = {
        userId: userId
    };

    console.log(data);

    // Выполняем AJAX-запрос на сервер
    $.ajax({
        url: '/Admin/GetDetailedUserInformation',
        type: 'POST',
        contentType: 'application/x-www-form-urlencoded',
        data: data,
        success: function (result) {
            // Обрабатываем успешный ответ
        },
        error: function (error) {
            // Обрабатываем ошибку
        }
    });

    var toolsMenu = document.getElementById("detailedInformation");
    if (toolsMenu.style.display === "none") {
        toolsMenu.style.display = "block";
    } else {
        toolsMenu.style.display = "none";
    }
}