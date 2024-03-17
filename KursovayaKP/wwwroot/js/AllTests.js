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