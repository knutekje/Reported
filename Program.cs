using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
      policy =>
      {
          policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
      });
});

builder.Services.AddDbContext<ReportedContext>(options =>
    options.UseNpgsql("Host=35.228.204.122;Database=ryvo;Username=knutekje;Password=hore23"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(builder => builder
       .AllowAnyHeader()
       .AllowAnyMethod()
       .AllowAnyOrigin()
    );
app.UseRouting(); 

app.UseAuthorization();

app.MapControllers();

app.Run();
