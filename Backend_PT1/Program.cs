using Microsoft.EntityFrameworkCore;
using Backend_PT1.Data;     
using Backend_PT1.Services; 

var builder = WebApplication.CreateBuilder(args);

// BD Connection (¡Pon tu contraseña de MySQL aquí!)
var connString = "Server=localhost;Database=RickMortyDB;User=root;Password=root;";
builder.Services.AddDbContext<AppDbContext>(o => o.UseMySql(connString, ServerVersion.AutoDetect(connString)));

// Services
builder.Services.AddHttpClient<IRickMortyService, RickMortyService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS: Permitir Angular (puerto 4200)
builder.Services.AddCors(opt => opt.AddPolicy("AngularApp", 
    p => p.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader()));

var app = builder.Build();

if (app.Environment.IsDevelopment()) { app.UseSwagger(); app.UseSwaggerUI(); }
app.UseCors("AngularApp");
app.MapControllers();
app.Run();