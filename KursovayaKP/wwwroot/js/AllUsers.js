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

//Отображение меню
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

/*function initializePage() {
    event.preventDefault();
    var toolsMenu = document.getElementById("detailedInformation");
    if (toolsMenu.style.display === "none") {
        toolsMenu.style.display = "block";
    } else {
        toolsMenu.style.display = "none";
    }
}*/

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

                    $listItems.eq(0).text('Результаты теста по теме "ПДД" - ' + result[1]);
                    $listItems.eq(1).text('Результаты теста по теме "Дорожные светофоры" - ' + result[2]);
                    $listItems.eq(2).text('Результаты теста по теме "Дорожные знаки" - ' + result[3]);
                    $listItems.eq(3).text('Результаты теста по теме "Дорожная разметка" - ' + result[4]);
                    $listItems.eq(4).text('Результаты теста по теме "Неисправности" - ' + result[5]);
                    $listItems.eq(5).text('Результаты теста по теме "Опознавательные знаки" - ' + result[6]);
                    $listItems.eq(6).text('Результаты теста по теме "Медицинская помощь" - ' + result[7]);


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

//Поиск
document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("searchInput").addEventListener("input", function () {
        var input = this.value.toLowerCase();
        var questions = document.getElementsByClassName("question");

        for (var i = 0; i < questions.length; i++) {
            var question = questions[i];
            var questionText = question.innerText.toLowerCase();

            if (questionText.includes(input)) {
                question.style.display = "block";
            } else {
                question.style.display = "none";
            }
        }
    });
});

//Сортировка по возрастанию и убыванию
document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("sortByNumberButton").addEventListener("click", function () {
        var questionContainer = document.getElementById("question-container");
        var questions = Array.from(questionContainer.getElementsByClassName("question"));

        // Проверяем, отсортирован ли список по возрастанию ID
        var sortedAscending = questions.every(function (question, index) {
            var currentId = parseInt(question.getAttribute("data-question-id"));
            var nextId = index < questions.length - 1 ? parseInt(questions[index + 1].getAttribute("data-question-id")) : null;
            return nextId === null || currentId <= nextId;
        });

        // Сортируем список по возрастанию или убыванию ID
        if (sortedAscending) {
            questions.sort(function (a, b) {
                var idA = parseInt(a.getAttribute("data-question-id"));
                var idB = parseInt(b.getAttribute("data-question-id"));
                return idB - idA; // Сортировка по убыванию
            });
        } else {
            questions.sort(function (a, b) {
                var idA = parseInt(a.getAttribute("data-question-id"));
                var idB = parseInt(b.getAttribute("data-question-id"));
                return idA - idB; // Сортировка по возрастанию
            });
        }

        // Обновляем порядок элементов в контейнере
        questions.forEach(function (question) {
            questionContainer.appendChild(question);
        });
    });
});


//Сортировка по алфавиту
document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("sortByNameButton").addEventListener("click", function () {
        var questionContainer = document.getElementById("question-container");
        var questions = Array.from(questionContainer.getElementsByClassName("question"));

        var sortedQuestions = questions.sort(function (a, b) {
            var questionTextA = a.querySelector("label:last-of-type").textContent.toLowerCase();
            var questionTextB = b.querySelector("label:last-of-type").textContent.toLowerCase();

            // Меняем порядок сравнения в зависимости от текущего порядка сортировки
            if (questionContainer.dataset.sortOrder === "ascending") {
                return questionTextA.localeCompare(questionTextB);
            } else {
                return questionTextB.localeCompare(questionTextA);
            }
        });

        // Изменяем порядок сортировки
        if (questionContainer.dataset.sortOrder === "ascending") {
            questionContainer.dataset.sortOrder = "descending";
        } else {
            questionContainer.dataset.sortOrder = "ascending";
        }

        // Удаляем текущие вопросы из контейнера
        questions.forEach(function (question) {
            questionContainer.removeChild(question);
        });

        // Добавляем отсортированные вопросы в контейнер
        sortedQuestions.forEach(function (question) {
            questionContainer.appendChild(question);
        });
    });
});

document.addEventListener("DOMContentLoaded", function () {
    var cancellationButton = document.getElementById("cancellation");
    var questionContainer = document.getElementById("question-container");
    var questions = Array.from(questionContainer.getElementsByClassName("question"));

    cancellationButton.addEventListener("click", function () {
        // Проверяем, отсортирован ли список по возрастанию ID
        var sortedAscending = questions.every(function (question, index) {
            var currentId = parseInt(question.getAttribute("data-question-id"));
            var nextId = index < questions.length - 1 ? parseInt(questions[index + 1].getAttribute("data-question-id")) : null;
            return nextId === null || currentId <= nextId;
        });

        // Сортируем список по возрастанию или убыванию ID
        if (sortedAscending) {
            questions.sort(function (a, b) {
                var idA = parseInt(a.getAttribute("data-question-id"));
                var idB = parseInt(b.getAttribute("data-question-id"));
                return idA - idB; // Сортировка по возрастанию
            });
        } else {
            questions.sort(function (a, b) {
                var idA = parseInt(a.getAttribute("data-question-id"));
                var idB = parseInt(b.getAttribute("data-question-id"));
                return idB - idA; // Сортировка по убыванию
            });
        }

        // Обновляем порядок элементов в контейнере
        questions.forEach(function (question) {
            questionContainer.appendChild(question);
        });
    });
});