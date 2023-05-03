using API_Clever.Services;
using API_Clever.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//*****ACA COMPLETAR CON CREDENCIALES PROPIAS*****
builder.Services.AddSqlServer<DbLocalContext>("Data Source =***; Initial Catalog = ***; user id =***; password = ***");

builder.Services.AddScoped<IRegisterService, RegisterService>();
builder.Services.AddScoped<ISearchService, SearchService>();
builder.Services.AddScoped<IAverageService, AverageService>();



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


app.MapGet("/DBconection", ([FromServices]DbLocalContext dbContext)=>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("base de datos creada");
});


app.Run();


