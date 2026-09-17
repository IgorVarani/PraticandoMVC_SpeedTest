using Microsoft.EntityFrameworkCore;
using MVC_Mercado.Data;

var builder = WebApplication.CreateBuilder(args);

// Configura os serviços da aplicação
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Configuração do DbContext
builder.Services.AddDbContext<MVC_MercadoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Login/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Middleware tradicional de arquivos estáticos (CSS, JS, imagens)
app.UseStaticFiles();

app.UseRouting();

// 3. Ativa o uso da Session no pipeline (entre UseRouting e UseAuthorization)
app.UseSession();

app.UseAuthorization();

// Mapeamento padrão de rotas para o LoginController
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();