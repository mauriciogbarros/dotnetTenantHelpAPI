// var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddOpenApi();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }

// app.UseHttpsRedirection();


// app.Run();

using Domain.Entities;
using Domain.Enums;

Property testProperty = new Property("Test address");

testProperty.AddUnit(new Unit(101, "Apartment 101"));
testProperty.AddUnit(new Unit(102, "Apartment 102"));
testProperty.AddUnit(new Unit(201, "Apartment 201"));
testProperty.AddUnit(new Unit(202, "Apartment 202"));

Console.WriteLine(testProperty.Address);
var units = testProperty.Units;
foreach (var unit in units)
{
	Console.WriteLine($"{unit.Id} - {unit.Number}: {unit.Description}");
}

var testManager = new Manager("Steve Man", "steve.man@email.com", "Password123", testProperty);

testManager.CreateTenant("John Ten", "john.ten@email.com", "Password123");
testManager.CreateTenant("Jenny Ten", "jenny.ten@email.com", "Password123");
testManager.CreateTechnician("Harry Tech", "harry.tech@email.com", "Password123");


