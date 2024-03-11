document.addEventListener('DOMContentLoaded', function () {
    GetAllTests();
});
function GetAllTests() {
    // Выполняем AJAX-запрос на сервер
    $.ajax({
        url: '/Admin/GetAllTests',
        type: 'GET',
        contentType: 'application/json',
        success: function (result) {
            // Очищаем список перед добавлением элементов
            $('#topic').empty();

            // Преобразуем полученный массив в объекты TestModel
            var testModels = result.map(function (test) {
                return {
                    IdTest: parseInt(test.IdTest),
                    NameTest: String(test.NameTest)
                };
            });

            // Добавляем элементы списка на основе преобразованных объектов TestModel
            testModels.forEach(function (test) {
                $('#topic').append('<option value="' + test.IdTest + '">' + test.NameTest + '</option>');
            });
        },
        error: function (error) {
            // Обрабатываем ошибку
        }
    });
}