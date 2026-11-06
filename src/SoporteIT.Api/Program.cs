using System.Text.Json.Serialization;
using SoporteIT.Api;
using SoporteIT.Core.Dominio;
using SoporteIT.Core.Servicios;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureHttpJsonOptions(o => o.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));

// En la demo se simula la hora (ver appsettings.Development.json) para que el resultado sea siempre el mismo.
var ahoraFijo = builder.Configuration["Demo:AhoraFijo"];
builder.Services.AddSingleton<TimeProvider>(ahoraFijo is null ? TimeProvider.System : new RelojFijo(DateTimeOffset.Parse(ahoraFijo)));
builder.Services.AddSingleton<IRepositorioIncidencias, RepositorioEnMemoria>();
builder.Services.AddSingleton<ServicioIncidencias>();

var app = builder.Build();

if (ahoraFijo is not null)
{
    DatosDemo.Cargar(app.Services.GetRequiredService<IRepositorioIncidencias>());
}

app.MapGet("/", () => Results.Redirect("/panel"));
app.MapGet("/panel", (ServicioIncidencias servicio) => Results.Content(Panel.Renderizar(servicio), "text/html; charset=utf-8"));

var incidencias = app.MapGroup("/incidencias");

incidencias.MapGet("/", (ServicioIncidencias servicio) => servicio.Listar());

incidencias.MapGet("/vencidas", (ServicioIncidencias servicio) => servicio.Vencidas());

incidencias.MapGet("/{id:int}", (int id, ServicioIncidencias servicio) =>
    servicio.Obtener(id) is { } incidencia
        ? Results.Ok(incidencia)
        : Results.NotFound(new { error = "Incidencia no encontrada" }));

incidencias.MapPost("/", (CrearIncidencia datos, ServicioIncidencias servicio) =>
{
    if (string.IsNullOrWhiteSpace(datos.Titulo) || string.IsNullOrWhiteSpace(datos.Aula))
        return Results.BadRequest(new { error = "El título y el aula son obligatorios" });

    var creada = servicio.Crear(datos.Titulo.Trim(), datos.Aula.Trim(), datos.Prioridad);
    return Results.Created($"/incidencias/{creada.Id}", creada);
});

incidencias.MapPost("/{id:int}/resolver", (int id, ServicioIncidencias servicio) =>
    servicio.Resolver(id)
        ? Results.NoContent()
        : Results.NotFound(new { error = "Incidencia no encontrada" }));

var claveAdmin = app.Configuration["Admin:ClaveApi"];
app.MapGet("/admin/exportar", (HttpRequest peticion, ServicioIncidencias servicio) =>
    !string.IsNullOrEmpty(claveAdmin) && peticion.Headers["X-Api-Key"] == claveAdmin
        ? Results.Ok(servicio.Listar())
        : Results.Unauthorized());

app.Run();
