using FinancePlay.API.Data;
using FinancePlay.API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 1. Serviços do app
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Conexão com banco MySQL
builder.Services.AddDbContext<FinancePlayDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. Injeção de dependências
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITransacaoService, TransacaoService>();
builder.Services.AddScoped<IExtratoService, ExtratoService>();

// 4. Autenticação e Autorização JWT
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = "FinancePlay",
            ValidAudience = "FinancePlay",
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("financeplay_super_seguro_123"))
        };
    });

builder.Services.AddAuthorization();

// Agora sim!
var app = builder.Build();

// Middleware do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
