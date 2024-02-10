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

    // Показываем уведомление после выделения неправильных вопросов
    alert('Ваш результат: ' + score + ' из ' + questions.length);
}