var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Проверка роли пользователя и обработка маршрута "/Admin/".
app.Use(async (context, next) =>
{
    // Получение роли пользователя (здесь нужно использовать ваш механизм аутентификации/авторизации)
    var userRole = context.Request.Cookies["Role"];

    // Проверка роли пользователя и маршрута
    if (userRole != "Admin" && context.Request.Path.StartsWithSegments("/Admin"))
    {
        context.Response.StatusCode = 404; // Установка кода состояния 404
        return;
    }

    await next(); // Продолжение обработки запроса
});

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
