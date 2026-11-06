using SoporteIT.Core.Dominio;

namespace SoporteIT.Core.Servicios;

/// <summary>Datos de ejemplo para la demo. Se cargan solo con el reloj simulado (lunes 9/11/2026, 12:30 Madrid).</summary>
public static class DatosDemo
{
    // En noviembre Madrid está en horario de invierno (UTC+1).
    private static DateTimeOffset Madrid(int dia, int hora, int minuto) =>
        new(2026, 11, dia, hora, minuto, 0, TimeSpan.FromHours(1));

    public static void Cargar(IRepositorioIncidencias repositorio)
    {
        Agregar(repositorio, "Proyector del aula 12 no enciende", "Aula 12", Prioridad.Alta, EstadoIncidencia.Abierta, Madrid(9, 8, 15));
        Agregar(repositorio, "WiFi caída en la planta 2", "Planta 2", Prioridad.Media, EstadoIncidencia.EnCurso, Madrid(6, 14, 0));
        Agregar(repositorio, "Cambiar el ratón del aula 3", "Aula 3", Prioridad.Baja, EstadoIncidencia.Abierta, Madrid(4, 10, 0));
        Agregar(repositorio, "Servidor de notas inaccesible", "Sala de servidores", Prioridad.Critica, EstadoIncidencia.Abierta, Madrid(6, 13, 0));
        Agregar(repositorio, "Instalar Visual Studio en el aula 7", "Aula 7", Prioridad.Media, EstadoIncidencia.Abierta, Madrid(9, 7, 0));
        Agregar(repositorio, "Impresora de secretaría atascada", "Secretaría", Prioridad.Alta, EstadoIncidencia.Resuelta, Madrid(5, 11, 0), Madrid(5, 12, 30));
        Agregar(repositorio, "Red del aula de informática caída", "Aula 1", Prioridad.Critica, EstadoIncidencia.EnCurso, Madrid(9, 12, 0));
        Agregar(repositorio, "Pizarra digital sin calibrar", "Aula 9", Prioridad.Alta, EstadoIncidencia.Abierta, Madrid(5, 9, 0));
    }

    private static void Agregar(IRepositorioIncidencias repositorio, string titulo, string aula, Prioridad prioridad,
        EstadoIncidencia estado, DateTimeOffset creada, DateTimeOffset? resuelta = null) =>
        repositorio.Agregar(new Incidencia
        {
            Titulo = titulo, Aula = aula, Prioridad = prioridad, Estado = estado, CreadaEn = creada, ResueltaEn = resuelta
        });
}
