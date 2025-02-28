using Microsoft.EntityFrameworkCore;
using GorevYoneticisi.Data; // GorevYoneticisiContext'in bulunduðu namespace

var builder = WebApplication.CreateBuilder(args);

// DbContext'i kaydet
builder.Services.AddDbContext<GorevYoneticisiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Diðer servisler
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware'ler
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();