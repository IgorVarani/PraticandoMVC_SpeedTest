using CafeteriaMVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// 1. REGISTRO DE SERVIÇOS
builder.Services.AddControllersWithViews();

// Registra o Banco de Dados (DbContext)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=biblioteca.db"));

// Registra a Autenticação por Cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
      options.LoginPath = "/Login/Login";
      options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    });

// 2. CONSTRUÇÃO DA APLICAÇÃO
var app = builder.Build();

// 3. HTTP REQUESTS
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Ativa a Autenticação e Autorização
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

// 4. CRIAÇÃO AUTOMÁTICA DO BANCO DE DADOS E USUÁRIO INICIAL
using (var scope = app.Services.CreateScope())
{
  var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
  db.Database.EnsureCreated();

  // Cria o usuário admin inicial caso o banco esteja vazio
  if (!db.Usuario.Any())
  {
    db.Usuario.Add(new CafeteriaMVC.Models.Usuario
    {
      NomeUsuario = "Igor",
      Email = "igor@email.com",
      Senha = System.Text.Encoding.UTF8.GetBytes("123"),
    });
    db.SaveChanges();
  }
}

app.Run();