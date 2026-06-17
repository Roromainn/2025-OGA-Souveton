DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

var db = OutilGestionAbsencesServeur.Data.DBConnection.Instance();
db.Server = Environment.GetEnvironmentVariable("DB_SERVER") ?? string.Empty;
db.DatabaseName = Environment.GetEnvironmentVariable("DB_NAME") ?? string.Empty;
db.UserName = Environment.GetEnvironmentVariable("DB_USER") ?? string.Empty;
db.Password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? string.Empty;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton(db);
builder.Services.AddScoped<OutilGestionAbsencesServeur.Data.IStudentRepository, OutilGestionAbsencesServeur.Data.StudentRepository>();
builder.Services.AddScoped<OutilGestionAbsencesServeur.Data.IAbsenceRepository, OutilGestionAbsencesServeur.Data.AbsenceRepository>();
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
