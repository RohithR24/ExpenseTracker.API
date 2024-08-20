using Controllers;
using Data;
using Data.Repository;
using Mappings;
using Service;
using Service.Impl;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserMappings, UserMappings>();

builder.Services.AddControllers();

//Connection to SQLiteServer
var connString = "Data Source = ./DataBase/ExpenseTracker.db";
builder.Services.AddSqlite<ExpenseTrackerContext>(connString); 


// Add services to the container.
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

// app.AllUserAPIs();
// app.AllCategoryAPIs();


app.MapControllers();


app.Run();
