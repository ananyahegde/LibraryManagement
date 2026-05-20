using LibraryManagement.Contexts;
using LibraryManagement.Repositories;
using LibraryManagement.Models;
using LibraryManagement.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Contexts
builder.Services.AddDbContext<LibraryDbContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
        });
#endregion

#region Repositories
builder.Services.AddScoped<IRepository<Book, int>, BookRepository>();
builder.Services.AddScoped<IRepository<Member, int>, MemberRepository>();
#endregion

#region Services
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IMemberService, MemberService>();
#endregion


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
