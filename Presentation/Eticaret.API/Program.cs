using System.Reflection;
using Eticaret.Application.Validators.Products;
using Eticaret.Persistence;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices();
builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .ConfigureApiBehaviorOptions(
        (options => options.SuppressModelStateInvalidFilter = true));     


builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters().
    AddValidatorsFromAssembly(typeof(ValidateCreateProduct).Assembly);



//builder.Services.AddValidatorsFromAssembly(typeof(ValidateCreateProduct).Assembly);




builder.Services.AddCors(
    options => options.AddDefaultPolicy(
        policy => policy.WithOrigins( 
            "http:\\localhost:4200", 
            "http://localhost:4200").AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{ 
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();