using AlfredHospital.API.Data;
using AlfredHospital.API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// added
builder.Services.AddDbContext<AlfredHospitalsDbContext>(options =>

{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AlfredHospitals"));
});

builder.Services.AddScoped<IPatientRepository, PatientRepository>();

builder.Services.AddAutoMapper(typeof(Program).Assembly); //automapper will look for all profiles

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
