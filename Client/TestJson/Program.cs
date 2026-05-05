using System.Text.Json;
using OGAMetier.Models;

string json = "[]";
var result = JsonSerializer.Deserialize<List<Student>>(json);
Console.WriteLine($"Result: {result?.Count ?? 0} items");

json = "[]\n";
result = JsonSerializer.Deserialize<List<Student>>(json);
Console.WriteLine($"With newline: {result?.Count ?? 0} items");
