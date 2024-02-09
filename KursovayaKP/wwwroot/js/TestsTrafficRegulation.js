var questionIndex = 0;
var questions = document.getElementsByClassName("question");
var questionContainer = document.getElementById("question-container");

function showNextQuestion() {
    if (questionIndex < questions.length - 1) {
        questions[questionIndex].style.display = "none";
        questionIndex++;
        questions[questionIndex].style.display = "block";
    }

    // Показать первый вопрос при загрузке страницы
    if (questionIndex === 0) {
        questions[questionIndex].style.display = "block";
    }
}

// Call showNextQuestion() when the page finishes loading
document.addEventListener("DOMContentLoaded", function () {
    showNextQuestion();
});