using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using RentalCar.Models;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<RentalCarContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("RentalCarDB"))
    );

//Compila a aplica��o
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

//Habilita a leitura da pasta www
app.UseStaticFiles();

//Habilita o mecanismo de roteamento de p�ginas
app.UseRouting();

//Habilitar a autoriza��o baseada em usu�rio e senha ou cookies
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Bloco de c�digo utilizado para configurar o padr�o de dados de acordo com o pa�s
var defaultCulture = new CultureInfo("pt-BR");
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(defaultCulture),
    SupportedCultures = new List<CultureInfo> { defaultCulture },
    SupportedUICultures = new List<CultureInfo> { defaultCulture }
};
app.UseRequestLocalization(localizationOptions);

//Executa a aplica��o
app.Run();
