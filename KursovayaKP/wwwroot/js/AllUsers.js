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

    $.ajax({
        url: '/Admin/GetDetailedUserInformation',
        type: 'POST',
        contentType: 'application/x-www-form-urlencoded',
        data: data,
        success: function (result) {
            if (result !== null) {
                // Обрабатываем успешный ответ
                console.log(result); // Выводим результат в консоль

                // Находим все элементы списка подробной информации
                var $listItems = $('#detailedInformation ul li');

                // Устанавливаем значения из массива в каждый элемент списка
                if (result[0] !== -1) {
                    $listItems.eq(0).text('Средний балл "ПДД" - ' + result[0]);
                }
                else {
                    $listItems.eq(0).text('Средний балл ПДД - Отсутствует');
                }

                if (result[1] !== -1) {
                    $listItems.eq(1).text('Средний балл "Дорожные знаки" - ' + result[1]);
                }
                else {
                    $listItems.eq(1).text('Средний балл "Дорожные знаки" - Отсутствует');
                }

                if (result[2] !== -1) {
                    $listItems.eq(2).text('Средний балл "Медицинская помощь" - ' + result[2]);
                }
                else {
                    $listItems.eq(2).text('Средний балл "Медицинская помощь" - Отсутствует');
                }

                if (result[3] !== -1) {
                    $listItems.eq(3).text('Средний балл "Устройство авто" - ' + result[3]);
                }
                else {
                    $listItems.eq(3).text('Средний балл "Устройство авто" - Отсутствует');
                }

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

    var toolsMenu = document.getElementById("detailedInformation");
    if (toolsMenu.style.display === "none") {
        toolsMenu.style.display = "block";
    } else {
        toolsMenu.style.display = "none";
    }
}