document.addEventListener('DOMContentLoaded', function () {
    GetAllTests();
});
function GetAllTests() {
    // Выполняем AJAX-запрос на сервер
    $.ajax({
        url: '/Admin/GetAllTests',
        type: 'POST',
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        success: function (result) {
            // Очищаем список перед добавлением элементов
            $('#test').empty();

            // Преобразуем полученный массив в объекты TestModel
            var testModels = result.map(function (test) {
                return {
                    IdTest: parseInt(test.idTest, 10),
                    NameTest: String(test.nameTest)
                };
            });

            // Добавляем элементы списка на основе преобразованных объектов TestModel
            testModels.forEach(function (test) {
                $('#test').append('<option value="' + test.IdTest + '">' + test.NameTest + '</option>');
            });

            // Обновляем скрытое поле при изменении выбора в select
            $('#test').change(function () {
                $('#selectedTest').val($(this).val());
            });
        },
        error: function (error) {
            // Обрабатываем ошибку
        }
    });
}