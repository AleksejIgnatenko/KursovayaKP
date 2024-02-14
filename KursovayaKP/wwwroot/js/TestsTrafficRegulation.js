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

    // Выполняем дополнительные действия с неправильными вопросами, если необходимо
    if (incorrectQuestions.length > 0) {
        // Например, прокрутка до первого неправильного вопроса
        incorrectQuestions[0].scrollIntoView();

        // Ждем некоторое время, чтобы выделение красным успело отобразиться
        await new Promise(resolve => setTimeout(resolve, 500));
    }

    // Получаем идентификатор пользователя из куки
    var userId = getCookieValue('ID');

    // Отправляем данные на сервер вместе с идентификатором пользователя
    var data = {
        userId: userId,
        score: score,
    };

    console.log(data);

    // Выполняем AJAX-запрос на сервер
    $.ajax({
        url: '/Home/SubmitAnswers',
        type: 'POST',
        contentType: 'application/x-www-form-urlencoded',
        data: { userId: userId, score: score },
        success: function (result) {
            // Обрабатываем успешный ответ
        },
        error: function (error) {
            // Обрабатываем ошибку
        }
    });
    // Показываем уведомление после выделения неправильных вопросов
    alert('Ваш результат: ' + score + ' из ' + questions.length);
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