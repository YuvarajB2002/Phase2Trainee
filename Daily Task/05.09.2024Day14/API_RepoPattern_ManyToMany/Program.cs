using API_ManyToMany.Interface;
using API_ManyToMany.Model;
using API_ManyToMany.Repository;
using API_ManyToMany.Service;
using Microsoft.EntityFrameworkCore;

using System.Windows.Input;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BookDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ManytoMany")));
builder.Services.AddScoped<IBook, BookRepository>();
builder.Services.AddScoped<IAuthor, AuthorRepository>();
//builder.Services.AddScoped<IBookAuthor, BookAuthorRepository>();
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<AuthorService>();
//builder.Services.AddScoped<BookAuthorService>();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
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
