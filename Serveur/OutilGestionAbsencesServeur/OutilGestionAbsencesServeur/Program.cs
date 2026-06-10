DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

var db = OutilGestionAbsencesServeur.Data.DBConnection.Instance();
db.Server = Environment.GetEnvironmentVariable("DB_SERVER");
db.DatabaseName = Environment.GetEnvironmentVariable("DB_NAME");
db.UserName = Environment.GetEnvironmentVariable("DB_USER");
db.Password = Environment.GetEnvironmentVariable("DB_PASSWORD");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton(db);
builder.Services.AddScoped<OutilGestionAbsencesServeur.Data.StudentRepository>();
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
