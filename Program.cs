using Aircraft_Crud.Components;
using Microsoft.EntityFrameworkCore;
using Aircraft_Crud.DAL;
using Aircraft_Crud.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(); 

var conStr = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContext<Context>(c => c.UseSqlite(conStr));

// Inyecciones del Service
builder.Services.AddScoped<AeronaveService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();

// Habilita endpoints interactivos
app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();
