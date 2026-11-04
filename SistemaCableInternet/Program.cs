using SistemaCableInternet.BLL.Interfaces;
using SistemaCableInternet.BLL.Services;
using SistemaCableInternet.DAL.Repositories;
using SistemaCableInternet.DAL.Connections;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Obtener cadena de conexión
var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection");

if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException(
        "No se encontró la cadena de conexión DefaultConnection."
    );
}

// Registrar conexión
builder.Services.AddScoped<DatabaseConnection>(_ =>
    new DatabaseConnection(connectionString)
);

// Registrar repositorio
builder.Services.AddScoped<IClienteRepository>(_ =>
    new ClienteRepository(connectionString)
);

// Registrar servicio de negocio
builder.Services.AddScoped<ClienteService>();

// Repositorio y servicio de Servicios
builder.Services.AddScoped<IServicioRepository>(_ =>
    new ServicioRepository(connectionString)
);

builder.Services.AddScoped<ServicioService>();

// Repositorio y servicio de Planes
builder.Services.AddScoped<IPlanRepository>(_ =>
    new PlanRepository(connectionString)
);

builder.Services.AddScoped<PlanService>();

// Repositorio y servicio de Contratos
builder.Services.AddScoped<IContratoRepository>(_ =>
    new ContratoRepository(connectionString)
);
builder.Services.AddScoped<ContratoService>();

// Repositorio y servicio de Zonas
builder.Services.AddScoped<IZonaRepository>(_ =>
    new ZonaRepository(connectionString)
);

builder.Services.AddScoped<ZonaService>();

// Repositorio y servicio de Direcciones
builder.Services.AddScoped<IDireccionRepository>(_ =>
    new DireccionRepository(connectionString)
);

builder.Services.AddScoped<DireccionService>();

// ContratoServicio
builder.Services.AddScoped<IContratoServicioRepository>(_ =>
    new ContratoServicioRepository(connectionString)
);

builder.Services.AddScoped<ContratoServicioService>();

// TARIFAS
builder.Services.AddScoped<ITarifaRepository>(_ =>
    new TarifaRepository(connectionString)
);

builder.Services.AddScoped<TarifaService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Ruta temporal para probar conexión
if (app.Environment.IsDevelopment())
{
    app.MapGet("/diagnostico/conexion", async (
        DatabaseConnection database) =>
    {
        try
        {
            string resultado = await database.ProbarConexionAsync();
            return Results.Ok(resultado);
        }
        catch (Exception ex)
        {
            return Results.Problem(detail: ex.Message);
        }
    });
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

