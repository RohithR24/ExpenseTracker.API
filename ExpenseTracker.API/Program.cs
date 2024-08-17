using Controllers;
using Data;

var builder = WebApplication.CreateBuilder(args);

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

app.AllUserAPIs();

// app.MapGet("/", () => "This is ExpenseTracker 1.0");

app.Run();
