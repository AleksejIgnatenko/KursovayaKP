document.addEventListener('DOMContentLoaded', function () {
    GetAllTests();
});
function GetAllTests() {
    // Выполняем AJAX-запрос на сервер
    $.ajax({
        url: '/Admin/GetAllTestsByIdQuestion',
        type: 'POST',
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        data: { questionID: $('#IdQuestion').val() },
        success: function (result) {
            // Получаем значения из объекта result
            var allTests = result.tests;  // Исправлено здесь
            var idTestQuestion = result.idTestQuestion;  // Исправлено здесь
            console.log(idTestQuestion);

            // Очищаем список перед добавлением элементов
            $('#test').empty();

            // Преобразуем полученный массив в объекты TestModel
            var testModels = allTests.map(function (test) {
                return {
                    IdTest: parseInt(test.idTest, 10),
                    NameTest: String(test.nameTest)
                };
            });

            // Добавляем элементы списка на основе преобразованных объектов TestModel
            testModels.forEach(function (test) {
                $('#test').append('<option value="' + test.IdTest + '">' + test.NameTest + '</option>');
            });

            $('#test').val(idTestQuestion);

            // Обновляем скрытое поле при изменении выбора в select
            $('#test').change(function () {
                $('#selectedTest').val($(this).val());
            });

            // Используйте значение idTestQuestion по вашему усмотрению
            console.log(idTestQuestion);
        },
        error: function (error) {
            // Обрабатываем ошибку
        }
    });
}