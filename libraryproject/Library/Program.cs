using Library.Core;
using Library.Core.Interfaces;
using Library.Core.Modals;
using Library.Core.Reposetory;
using Library.Core.Services;
using Library.Data;
using Library.Data.Reposetory;
using Library.Servicrs;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});
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
//builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddCors();

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

app.UseCors(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());


app.MapControllers();

app.Run();
