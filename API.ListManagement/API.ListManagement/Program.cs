using Library.ListManagement.Standard.utilities;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
MvcNewtonsoftJsonOptions fix = new MvcNewtonsoftJsonOptions();
fix.SerializerSettings.Converters.Add(new ItemDTOJsonConverter());
fix.SerializerSettings.Converters.Add(new ItemJsonConverter());

builder.Services.AddControllers()
   .AddNewtonsoftJson(opt => opt = fix);
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
