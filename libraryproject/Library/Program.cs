using Library.Core.Interfaces;
using Library.Core.Modals;
using Library.Core.Reposetory;
using Library.Core.Services;
using Library.Data;
using Library.Data.Reposetory;
using Library.Servicrs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookReposetory, BookReposetory>();
builder.Services.AddScoped<ISubscribeService, SubscribeService>();
builder.Services.AddScoped<ISubscribeReposetory, SubacribeReposetory>();
builder.Services.AddScoped<IBorrowService, BorrowService>();
builder.Services.AddScoped<IBorrowReposetory, BorrowReposetory>();
builder.Services.AddDbContext<DataContext>();

//builder.Services.AddSingleton<DataContex>();
//builder.Services.AddScoped<DataContext>();

//builder.Services.AddSingleton<DataContext>(provider =>
//{
//    var context = new DataContext();
//    return context;
//});



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
