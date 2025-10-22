using CrudParking.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// ✅ CORS — permite tanto el frontend local como el backend en Render
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        policy.WithOrigins(
                "http://localhost:5173",                    // Vue local (Vite)
                "https://crudpark-csharp-back.onrender.com" // Backend desplegado
            )
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

// ✅ Configuración de base de datos (usa variable si existe o conexión local)
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

    if (!string.IsNullOrEmpty(databaseUrl))
    {
        var uri = new Uri(databaseUrl);
        var userInfo = uri.UserInfo.Split(':');
        var connectionString =
            $"Host={uri.Host};Port={uri.Port};Database={uri.AbsolutePath.TrimStart('/')};Username={userInfo[0]};Password={userInfo[1]};SSL Mode=Require;Trust Server Certificate=true";

        options.UseNpgsql(connectionString);
    }
    else
    {
        // 👇 asegúrate de tener "DefaultConnection" en tu appsettings.json
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
});

// ✅ Configurar controladores y JSON
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.WriteIndented = true;
    });

var app = builder.Build();

// ✅ Importante: habilita CORS *antes* de los controladores
app.UseCors(MyAllowSpecificOrigins);

// ✅ HTTPS opcional mientras estás en local
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHttpsRedirection();
}

app.UseRouting();
app.UseAuthorization();

// ✅ Mapea tus controladores
app.MapControllers();

// ✅ Ruta raíz de prueba
app.MapGet("/", () => Results.Json(new
{
    message = "🚀 CRUDPark API is running successfully!",
    environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"
}));

// ✅ Asegura que el backend escuche en el puerto 8080
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Urls.Add($"http://*:{port}");

app.Run();
