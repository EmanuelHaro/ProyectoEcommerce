using Ecommerce.Repositorio.DBContext;
using Microsoft.EntityFrameworkCore;

using Ecommerce.Utilidades;
using Ecommerce.Repositorio.Contrato; //Interfaces
using Ecommerce.Repositorio.Implementacion;

using Ecommerce.Servicio.Contrato; //Interfaces
using Ecommerce.Servicio.Implementacion;

//En las librerias de clase esta implementada la logica no las contrucciones,
//La API implementa todo, por eso acá se inyectan todas las dependencias

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<DbecommerceContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL"));
});


builder.Services.AddTransient(typeof(IGenericoRepositorio<>), typeof(GenericoRepositorio<>)); //no sabemos con que modelo va a trabajar
builder.Services.AddScoped<IVentaRepositorio, VentaRepositorio>(); //sabemos con que modelo va a trabajar


builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

/*Inyeccion de dependencia
Al servicio en momento de ejecucion le digo que clase va a implementar

La libreria que inyecta es ...

 
 */

builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();
builder.Services.AddScoped<ICategoriaServicio, CategoriaServicio>();
builder.Services.AddScoped<IVentaServicio, VentaServicio>();
builder.Services.AddScoped<IProductoServicio, ProductoServicio>();
builder.Services.AddScoped<IDashboardServicio, DashboardServicio>();


builder.Services.AddCors(options => 
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); //vamos a permitir cualq origen,header o metodo para evitar problema de cors
    }
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("NuevaPolitica"); //usr la politica

app.UseAuthorization();

app.MapControllers();

app.Run();
