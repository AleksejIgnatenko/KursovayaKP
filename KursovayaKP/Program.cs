using KursovayaKP.Tables;
using KursovayaKP.Tables.TablesQuestionsDB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Get the connection string from the configuration file
string connection = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

// Add the ApplicationContext as a service in the application
builder.Services.AddDbContext<DBUser>(options => options.UseSqlServer(connection));
builder.Services.AddDbContext<TableQuestionTrafficRegulations>(options => options.UseSqlServer(connection));
builder.Services.AddDbContext<TableQuestionRoadSigns>(options => options.UseSqlServer(connection));
builder.Services.AddDbContext<TableQuestionMedicalCare>(options => options.UseSqlServer(connection));
builder.Services.AddDbContext<TableQuestionCarDevice>(options => options.UseSqlServer(connection));
//builder.Services.AddDbContext<TableAnswerUserTestTrafficRegulations>(options => options.UseSqlServer(connection));
builder.Services.AddDbContext<TableAnswerUserTest>(options => options.UseSqlServer(connection));

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

// �������� ���� ������������ � ��������� �������� "/Admin/".
app.Use(async (context, next) =>
{
    // ��������� ���� ������������
    var userRole = context.Request.Cookies["Role"];

    // �������� ���� ������������ � ��������
    if (userRole != "Admin" && context.Request.Path.StartsWithSegments("/Admin"))
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
