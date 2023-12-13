using AutoMapper;
using Core.Repositories;
using Core.Repositories.Interfaces;
using Infrastructure.Data;
using Infrastructure.DTOs;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")),
                    ServiceLifetime.Transient);

//// Add services to the container.
//builder.Services.AddTransient<IOrderDataService, OrderDataService>();

// Add repositories to the container.
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Automapper configuration
var configuration = new MapperConfiguration(cfg =>
{
    //Customer
    cfg.CreateMap<Customer, CustomerDTO>().ReverseMap();

    //Product
    cfg.CreateMap<Product, ProductDTO>().ReverseMap();

    //Order
    cfg.CreateMap<Order, OrderDTO>().ReverseMap();
});

IMapper mapper = configuration.CreateMapper();

builder.Services.AddSingleton(mapper);

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
