using API_Clever.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlServer<DbLocalContext>("Data Source = PC071996\\SQLEXPRESS; Initial Catalog = CleverDB; user id = sa; password = andres ");
builder.Services.AddScoped<IRegisterService, RegisterService>();
builder.Services.AddScoped<ISearchService, SearchService>();



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


app.MapGet("/DBconection", async([FromServices]DbLocalContext dbContext)=>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("base de datos en memoria " + dbContext.Database.IsInMemory());
});

app.Run();
