using Microsoft.EntityFrameworkCore;
using Pedido.Data;
using Pedido.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PedidoDbContext>(opts => opts.UseLazyLoadingProxies().UseNpgsql(builder.Configuration.GetConnectionString("PedidoConnection")));

builder.Services.AddHttpClient<ItemServiceHttpClient>();
builder.Services.AddScoped<PedidoService>();
builder.Services.AddScoped<ItemPedidoService>();

builder.Services.
AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
