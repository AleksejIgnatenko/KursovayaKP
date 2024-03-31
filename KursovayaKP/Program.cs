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

// �������� ������� ������������ � ���� ������
/*app.Use(async (context, next) =>
{
	try
	{
		// ��������� ���������� � ������������ �� ���� ������
		var dbContext = context.RequestServices.GetRequiredService<UserTable>();
		var userIdString = context.Request.Cookies["ID"];

		if (int.TryParse(userIdString, out int userId))
		{
			var user = await dbContext.Users.FindAsync(userId);

			if (user == null)
			{
				// ������������ �� ������ � ���� ������, ��������� ����������� ��������, ��������, �������� cookies
				context.Response.Cookies.Delete("ID");
				context.Response.Cookies.Delete("UserName");
				context.Response.Cookies.Delete("Role");

				await next();
				return;
			}
		}

		await next(); // ����������� ��������� �������
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

// �������� ���� ������������ � ��������� �������� "/Admin/".
app.Use(async (context, next) =>
{
	// ��������� ���� ������������
	var userRole = context.Request.Cookies["Role"];

	// �������� ���� ������������ � ��������
	if (userRole != "Admin" && userRole != "Manager" && context.Request.Path.StartsWithSegments("/Admin"))
	{
		context.Response.StatusCode = 404; // ��������� ���� ��������� 404
		return;
	}

	await next(); // ����������� ��������� �������
});

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
