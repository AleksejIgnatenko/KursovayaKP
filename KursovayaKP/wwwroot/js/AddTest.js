document.addEventListener('DOMContentLoaded', function () {
    GetAllTests();
});
function GetAllTests() {
    // Выполняем AJAX-запрос на сервер
    $.ajax({
        url: '/Admin/GetAllCategory',
        type: 'POST',
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        success: function (result) {
            // Очищаем список перед добавлением элементов
            $('#category').empty();
            console.log(result);

            // Преобразуем полученный массив в объекты TestModel
            var categoryModel = result.map(function (category) {
                return {
                    idCategory: parseInt(category.idCategory, 10),
                    nameCategory: String(category.nameCategory)
                };
            });

            // Добавляем элементы списка на основе преобразованных объектов TestModel
            categoryModel.forEach(function (category) {
                $('#category').append('<option value="' + category.idCategory + '">' + category.nameCategory + '</option>');
            });

/*            // Обновляем скрытое поле при изменении выбора в select
            $('#category').change(function () {
                $('#selectedTest').val($(this).val());
            });*/
        },
        error: function (error) {
            // Обрабатываем ошибку
        }
    });
}