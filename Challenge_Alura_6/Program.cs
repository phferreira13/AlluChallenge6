using Allu.Challenge6.Business.UseCases.Tutores.Add;
using Allu.Challenge6.Entity.Ioc;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();//.addf.AddFluentValidation(f => f.RegisterValidatorsFromAssembly(typeof(TutorAddCommandValidator).Assembly));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFluentValidation(f => f.RegisterValidatorsFromAssemblyContaining<TutorAddCommandValidator>());
builder.Services.AddSwaggerGen();
builder.Services.AddEntityConfiguration(builder.Configuration);
builder.Services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(TutorAddHandler).Assembly));

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
