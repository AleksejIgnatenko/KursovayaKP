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
    var toolsMenu = document.getElementById("detailedInformation");
    if (toolsMenu.style.display === "none") {
        // Отправляем данные на сервер вместе с идентификатором пользователя и названием теста
        var data = {
            userId: userId
        };

        /*    console.log(data);*/

        $.ajax({
            url: '/Admin/GetDetailedUserInformation',
            type: 'POST',
            contentType: 'application/x-www-form-urlencoded',
            data: data,
            success: function (result) {
                console.log(result); // Выводим результат в консоль
                if (result !== null) {
                    // Обрабатываем успешный ответ

                    // Находим все элементы списка подробной информации
                    var $listItems = $("#detailedInformation ul li"); // Get the list items

                    $listItems.eq(0).text('Результаты теста "ПДД" - ' + result[1]);
                    $listItems.eq(1).text('Средний балл "Дорожные светофоры" - ' + result[2]);
                    $listItems.eq(2).text('Средний балл "Дорожные знаки" - ' + result[3]);
                    $listItems.eq(3).text('Средний балл "Дорожная разметка" - ' + result[4]);
                    $listItems.eq(4).text('Средний балл "Неисправности" - ' + result[5]);
                    $listItems.eq(5).text('Средний балл "Опознавательные знаки" - ' + result[6]);
                    $listItems.eq(6).text('Средний балл "Медицинская помощь" - ' + result[7]);


                    // Отображаем список
                    $('#detailedInformation').show();

                    // Далее можно выполнить другие необходимые действия с массивом result
                } else {
                    // Обработка случая, когда возвращено null
                    console.log('Ошибка при получении подробной информации');
                }
            },
            error: function (error) {
                // Обрабатываем ошибку
            }
        });
    } else {
        toolsMenu.style.display = "none";
    }
}