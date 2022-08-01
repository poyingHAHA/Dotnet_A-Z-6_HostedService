using HostedService1;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MyDbContext>(opt =>
{
    opt.UseSqlServer("Server=localhost; Database=idTest; User Id=sa; Password=PaSSword12!; Trusted_Connection=False; MultipleActiveResultSets=true");
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<TestService>();
builder.Services.AddHostedService<HostedServiceDemo1>();
builder.Services.AddHostedService<ScheduledService>();

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
