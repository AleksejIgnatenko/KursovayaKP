using Azure;
using KursovayaKP.Models.TablesDB;
using KursovayaKP.Models.TablesDBModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

var builder = WebApplication.CreateBuilder(args);

// Get the connection string from the configuration file
string connection = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

// Add the ApplicationContext as a service in the application
builder.Services.AddDbContext<UserTable>(options => options.UseSqlServer(connection));
builder.Services.AddDbContext<QuestionTable>(options => options.UseSqlServer(connection));
builder.Services.AddDbContext<TableAnswerUserTest>(options => options.UseSqlServer(connection));
builder.Services.AddDbContext<TestTable>(options => options.UseSqlServer(connection));
builder.Services.AddDbContext<CategoryTable>(options => options.UseSqlServer(connection));

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

// Проверка наличия пользователя в базе данных
/*app.Use(async (context, next) =>
{
	try
	{
		// Получение информации о пользователе из базы данных
		var dbContext = context.RequestServices.GetRequiredService<UserTable>();
		var userIdString = context.Request.Cookies["ID"];

		if (int.TryParse(userIdString, out int userId))
		{
			var user = await dbContext.Users.FindAsync(userId);

			if (user == null)
			{
				// Пользователь не найден в базе данных, выполните необходимые действия, например, удаление cookies
				context.Response.Cookies.Delete("ID");
				context.Response.Cookies.Delete("UserName");
				context.Response.Cookies.Delete("Role");

				await next();
				return;
			}
		}

		await next(); // Продолжение обработки запроса
	}
	catch (Exception ex)
	{
		await Console.Out.WriteLineAsync($"{ex}");
		context.Response.Cookies.Delete("ID");
		context.Response.Cookies.Delete("UserName");
		context.Response.Cookies.Delete("Role");
		context.Response.Redirect("/Home/Index");
	}
});*/

// Проверка роли пользователя и обработка маршрута "/Admin/".
app.Use(async (context, next) =>
{
	// Получение роли пользователя
	var userRole = context.Request.Cookies["Role"];

	// Проверка роли пользователя и маршрута
	if (userRole != "Admin" && userRole != "Manager" && context.Request.Path.StartsWithSegments("/Admin"))
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
