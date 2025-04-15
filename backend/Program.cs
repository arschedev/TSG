using backend.Classes;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
Console.WriteLine("http://localhost:5000/swagger/index.html");

// Add services to the container.
const string connectionString = "Server=db;Database=AppDb;User Id=sa;Password=Mssql_sa_password;";
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.Urls.Add("http://0.0.0.0:5000");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Endpoints
app.MapPost("/api/forms", async (StudentForm form, AppDbContext db) =>
{
    form.DataSubmisiei = DateTime.Now;

    Pdf.Generate(form, "./output.pdf");

    db.Forms.Add(form);
    await db.SaveChangesAsync();

    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");
    return Results.File(filePath, "application/pdf", "StudentForm.pdf");
});

app.MapGet("/api/forms/{id:int}", async (int id, AppDbContext db) =>
{
    var form = await db.Forms.FindAsync(id);
    return form == null ? Results.NotFound() : Results.Ok(form);
});

app.MapGet("/api/test", () => Results.Ok("Hello World!"));

app.Run();