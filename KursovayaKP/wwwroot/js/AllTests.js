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

// Ожидаем, что документ будет полностью загружен
document.addEventListener("DOMContentLoaded", function () {
	// Получаем все элементы с классом "category-label"
	var categoryLabels = document.getElementsByClassName("category-label");

	// Проходимся по каждому элементу и заменяем его содержимое
	for (var i = 0; i < categoryLabels.length; i++) {
		var categoryLabel = categoryLabels[i];
		var categoryId = categoryLabel.textContent; // Получаем исходное значение категории

		// Вызываем функцию для получения нового значения категории
		getCategoryValue(categoryId, categoryLabel); // Замените "getCategoryValue" на вашу функцию или логику
	}
});

// Функция, которая получает новое значение категории
function getCategoryValue(categoryId, categoryLabel) {
	console.log(categoryId);

	// Выполняем AJAX-запрос на сервер
	$.ajax({
		url: '/Admin/GetCategory',
		type: 'POST',
		data: { categoryId: categoryId }, // Передаем categoryId как данные запроса
		contentType: 'application/x-www-form-urlencoded',
		dataType: 'json',
		success: function (result) {
			console.log(result);

			// Используем значения из result (уже является объектом)
			var idCategory = result.idCategory;
			var nameCategory = result.nameCategory;

			// Заменяем значение внутри элемента
			categoryLabel.textContent = nameCategory;
		},
		error: function (error) {
			// Обрабатываем ошибку
		}
	});
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

// Сортировка по возрастанию и убыванию номера теста
document.addEventListener("DOMContentLoaded", function () {
	document.getElementById("sortByNumberButton").addEventListener("click", function () {
		var questionContainer = document.getElementById("question-container");
		var questions = Array.from(questionContainer.getElementsByClassName("question"));

		// Проверяем, отсортирован ли список по возрастанию номера теста
		var sortedAscending = questions.every(function (question, index) {
			var currentTestId = parseInt(question.getAttribute("data-question-id"));
			var nextTestId = index < questions.length - 1 ? parseInt(questions[index + 1].getAttribute("data-question-id")) : null;
			return nextTestId === null || currentTestId <= nextTestId;
		});

		// Сортируем список по возрастанию или убыванию номера теста
		if (sortedAscending) {
			questions.sort(function (a, b) {
				var testIdA = parseInt(a.getAttribute("data-question-id"));
				var testIdB = parseInt(b.getAttribute("data-question-id"));
				return testIdB - testIdA; // Сортировка по убыванию
			});
		} else {
			questions.sort(function (a, b) {
				var testIdA = parseInt(a.getAttribute("data-question-id"));
				var testIdB = parseInt(b.getAttribute("data-question-id"));
				return testIdA - testIdB; // Сортировка по возрастанию
			});
		}

		// Обновляем порядок элементов в контейнере
		questions.forEach(function (question) {
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