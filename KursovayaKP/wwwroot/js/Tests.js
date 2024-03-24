//Сначала уведомление о баллах а потом выделяется красным цветом
/*function checkAnswers() {
    var questions = document.getElementsByClassName('question');
    var score = 0;
    var incorrectQuestions = [];

    for (var i = 0; i < questions.length; i++) {
        var question = questions[i];
        var questionId = question.dataset.questionId;
        var correctAnswer = question.dataset.correctAnswer;
        var selectedAnswer = question.querySelector('input[name="answer"]:checked');
        var answerLabels = question.querySelectorAll('label');

        if (selectedAnswer && selectedAnswer.value === correctAnswer) {
            score++;
        } else {
            // Добавляем класс 'incorrect' к вопросу и его меткам (labels) для стилизации
            question.classList.add('incorrect');
            for (var j = 0; j < answerLabels.length; j++) {
                answerLabels[j].classList.add('incorrect');
            }
            incorrectQuestions.push(question);
        }
    }

    // Показываем уведомление после выделения неправильных вопросов
    alert('Ваш результат: ' + score + ' из ' + questions.length);

    // Выполняем дополнительные действия с неправильными вопросами, если необходимо
    if (incorrectQuestions.length > 0) {
        // Например, прокрутка до первого неправильного вопроса
        incorrectQuestions[0].scrollIntoView();
    }
}*/

//Сначала выделяется красынм а потом уведомление о количестве баллов
async function checkAnswers() {
    var questions = document.getElementsByClassName('question');
    var resultTest = 0;
    var incorrectQuestions = [];

    for (var i = 0; i < questions.length; i++) {
        var question = questions[i];
        var correctAnswer = question.dataset.correctAnswer;
        var selectedAnswer = question.querySelector('input[name="answer"]:checked');
        var answerLabels = question.querySelectorAll('label');

        if (selectedAnswer && selectedAnswer.value === correctAnswer) {
            resultTest++;
        } else {
            // Добавляем класс 'incorrect' к вопросу и его меткам (labels) для стилизации
            question.classList.add('incorrect');
            for (var j = 0; j < answerLabels.length; j++) {
                answerLabels[j].classList.add('incorrect');
            }
            incorrectQuestions.push(question);
        }
    }

    // Выполняем дополнительные действия с неправильными вопросами, если необходимо
    if (incorrectQuestions.length > 0) {
        // Например, прокрутка до первого неправильного вопроса
        incorrectQuestions[0].scrollIntoView();

        // Ждем некоторое время, чтобы выделение красным успело отобразиться
        await new Promise(resolve => setTimeout(resolve, 500));
    }

    // Получаем идентификатор пользователя из куки
    var userId = getCookieValue('ID');
    var testId = document.getElementById("testId").value;

    // Отправляем данные на сервер вместе с идентификатором пользователя и названием теста
    var data = {
        userId: parseInt(userId),
        testId: testId,
        resultTest: resultTest
    };

    console.log(data);

    // Выполняем AJAX-запрос на сервер
    $.ajax({
        url: '/Home/SubmitAnswers',
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

    //Скрыть кнопку "Отправить"
    document.querySelector(".button").style.display = "none";
    //Показать кнопку "Пройти тест еще раз"
    document.querySelector("#restartTestButton").style.display = "block";
    console.log(resultTest)
    // Показываем уведомление после выделения неправильных вопросов
    if (resultTest > 8) {
        alert('Ваш результат: ' + resultTest + ' из ' + questions.length + ' (экзамен сдан)');
    } else {
        alert('Ваш результат: ' + resultTest + ' из ' + questions.length + ' (экзамен не сдан)');
    }
}

// Функция для получения значения куки по имени
function getCookieValue(name) {
    var cookies = document.cookie.split(';');
    for (var i = 0; i < cookies.length; i++) {
        var cookie = cookies[i].trim();
        if (cookie.startsWith(name + '=')) {
            return cookie.substring(name.length + 1);
        }
    }
    return null;
}

// Перезагрузка страницы
function restartTest() {
    location.reload();
}