using Data;
using VendedoresWebMvc.Data;
using Microsoft.EntityFrameworkCore;
using VendedoresWebMvc.Services;
using System.Globalization;


var builder = WebApplication.CreateBuilder(args);

////Criando a injeção de dependências ao banco de dados (Está sendo chamada no VendedoresWebMvcContext)
var connectionStringMysql = builder.Configuration.GetConnectionString("VendedoresWebMvcContext");
builder.Services.AddDbContext<VendedoresWebMvcContext>(options => options.UseMySql(connectionStringMysql, ServerVersion.Parse("8.0-mysql")));

//Registrando os serviçoes/classe no sistema de injeção de dependências 
builder.Services.AddScoped<PopulacaoDeDados>(); 
builder.Services.AddScoped<VendedoresService>();
builder.Services.AddScoped<DepartamentoService>();

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
//Configurando a localização da aplição
var localization = new CultureInfo("pt-BR");
var localizationOption = new RequestLocalizationOptions
{
    DefaultRequestCulture = new(localization),
    SupportedCultures = new List<CultureInfo> { localization },
    SupportedUICultures = new List<CultureInfo> { localization }

};
app.UseRequestLocalization(localizationOption);

//Executando a injeção de dependências declarada a cima (População no banco de dados)
app.Services.CreateScope().ServiceProvider.GetRequiredService<PopulacaoDeDados>().PopulacaoDosDados();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
