
using System.Text;
using financePlay.API.Data;
using financePlay.API.Helpers;
using financePlay.API.Services;
using financePlay.API.Patterns.Factory;
using financePlay.API.Patterns.Observer;
using financePlay.API.Patterns.Strategy;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Controllers + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext (MySQL via Pomelo)
var connStr = builder.Configuration.GetConnectionString("DefaultConnection") ??
              "server=localhost;port=3306;database=financeplay_teste;user=root;password=123456;";
builder.Services.AddDbContext<FinancePlayDbContext>(options =>
    options.UseMySql(connStr, ServerVersion.AutoDetect(connStr)));

// JWT
var jwtKey = builder.Configuration["Jwt:Key"] ?? "financeplay_super_seguro_123";
var keyBytes = Encoding.UTF8.GetBytes(jwtKey);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"] ?? "FinancePlay",
            ValidAudience = builder.Configuration["Jwt:Audience"] ?? "FinancePlay",
            IssuerSigningKey = new SymmetricSecurityKey(keyBytes)
        };
    });
builder.Services.AddAuthorization();

// Repositories + UnitOfWork
builder.Services.AddScoped<financePlay.API.Repositories.Interfaces.IUsuarioRepository, financePlay.API.Repositories.Implementations.UsuarioRepository>();
builder.Services.AddScoped<financePlay.API.Repositories.Interfaces.IExtratoRepository, financePlay.API.Repositories.Implementations.ExtratoRepository>();
builder.Services.AddScoped<financePlay.API.Repositories.Interfaces.ITransacaoRepository, financePlay.API.Repositories.Implementations.TransacaoRepository>();
// Services and Patterns
builder.Services.AddScoped<ITransacaoFactory, TransacaoFactory>();
builder.Services.AddScoped<ICategorizacaoStrategy, CategoriaPadraoStrategy>();
builder.Services.AddScoped<ICategorizacaoStrategy, CategoriaCnpjStrategy>();
builder.Services.AddScoped<CategorizacaoContext>();
builder.Services.AddSingleton<TransacaoSubject>();
builder.Services.AddScoped<ITransacaoObserver, GamificacaoObserver>();
builder.Services.AddScoped<ITransacaoObserver, ConquistasObserver>();
builder.Services.AddScoped<IExtratoService, ExtratoService>();
builder.Services.AddScoped<IAnaliseService, AnaliseService>();
builder.Services.AddScoped<financePlay.API.Repositories.Interfaces.IUnitOfWork, financePlay.API.Repositories.Implementations.UnitOfWork>();

var app = builder.Build();

// Configurar Observers no Subject
using (var scope = app.Services.CreateScope())
{
    var subject = scope.ServiceProvider.GetRequiredService<TransacaoSubject>();
    var observers = scope.ServiceProvider.GetServices<ITransacaoObserver>();
    foreach (var observer in observers)
    {
        subject.Attach(observer);
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
