using AspNetCoreWebApiTask1.DBContext;
using AspNetCoreWebApiTask1.Services;
using Microsoft.EntityFrameworkCore;
using AutoMapper;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BookstoreContext>(dbContextOptions => dbContextOptions.UseSqlite("Data Source = Bookstores.db"));
builder.Services.AddScoped<IBookstoreRepository, BookstoreRepository>();
builder.Services.AddScoped<IBookstoreServices, BookstoreServices>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<BookstoreContext>(dbContextOptions => dbContextOptions.UseSqlite("Data Source = Bookstores.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

