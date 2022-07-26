using CrudCarsTokens.Cryptography;
using CrudCarsTokens.Filters;
using CrudCarsTokens.Repositories;
using CrudCarsTokens.Repositories.Interfaces;
using CrudCarsTokens.Services;
using CrudCarsTokens.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(config =>
{
    config.Filters.Add(new TokensFilter(new TokenService(new Cryptography())));
});

//builder.Services.AddControllers();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICarrosService, CarrosService>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddTransient<IDapperContext, DapperContext>();

builder.Services.AddSingleton<ICryptography, Cryptography>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
