using Controllers;
using Data;
using Data.Repository;
using Mappings;
using Service;
using Service.Impl;
using DotNetEnv;
using Helper;

var builder = WebApplication.CreateBuilder(args);

// Load the .env file
Env.Load();

// Retrieve the variables from the environment
var saltSize = int.Parse(Environment.GetEnvironmentVariable("SALT_SIZE"));
var hashSize = int.Parse(Environment.GetEnvironmentVariable("HASH_SIZE"));
var iterations = int.Parse(Environment.GetEnvironmentVariable("ITERATIONS"));

// Register services with DI
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserMappings, UserMappings>();

// Register the PasswordHandler with the loaded settings
builder.Services.AddScoped<IPasswordHandler>(provider => new PasswordHandler(saltSize, hashSize, iterations));

builder.Services.AddControllers();

// Connection to SQLiteServer
var connString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION");
builder.Services.AddSqlite<ExpenseTrackerContext>(connString); 

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
