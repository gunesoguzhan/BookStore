using System.Reflection;
using Webapi.Data;
using Webapi.MiddleWares;
using Webapi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add db context.
builder.Services.AddDbContext<IBookStoreDbContext, BookStoreDbContext>(options =>
    options.UseInMemoryDatabase(databaseName: "BookStoreDB"));

// builder.Services.AddDbContext<BookStoreDbContext>(options =>
//     options.UseInMemoryDatabase(databaseName: "BookStoreDB"));
// builder.Services.AddScoped<IBookStoreDbContext>(provider =>
//     provider.GetService<BookStoreDbContext>());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adding AutoMapper.
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Adding logger service.
builder.Services.AddSingleton<ILoggerService, DBLogger>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ValidAudience = builder.Configuration["Tokens:Jwt:Audience"],
            ValidIssuer = builder.Configuration["Tokens:Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Tokens:Jwt:SecurityKey"])),
            ClockSkew = TimeSpan.Zero
        };
    });

var app = builder.Build();

// Generate data.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DataGenerator.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseCustomExceptionMiddleware();

app.Run();
