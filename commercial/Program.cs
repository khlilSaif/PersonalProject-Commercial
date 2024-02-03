using commercial;
using commercial.RepositoryPattern;
using commercial.Secyrity;
using commercial.Services;
using dbProject.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("dblocal.json", optional: false, reloadOnChange: true);
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IRepositoryPattern<User>, UserRepository>();
builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<IRegistrationService,RegistrationService>();
builder.Services.AddScoped<IRepositoryPattern<AuthenticationToken>, AuthRepository>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IRepositoryPattern<Product>, ProductRepository>();
builder.Services.AddScoped<IRepositoryPattern<Panel>, PanelRepository>();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton(builder.Configuration);
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
