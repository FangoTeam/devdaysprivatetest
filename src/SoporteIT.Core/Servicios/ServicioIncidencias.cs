using SoporteIT.Core.Dominio;

namespace SoporteIT.Core.Servicios;

public class ServicioIncidencias(IRepositorioIncidencias repositorio, TimeProvider reloj)
{
    public IReadOnlyList<Incidencia> Listar() => repositorio.Listar();

    public Incidencia? Obtener(int id) => repositorio.Obtener(id);

    public DateTimeOffset Ahora() => reloj.GetUtcNow();

    public IReadOnlyList<Incidencia> Vencidas()
    {
        var ahora = reloj.GetUtcNow();
        return repositorio.Listar()
            .Where(i => i.Estado != EstadoIncidencia.Resuelta && PoliticaSla.Vencimiento(i) < ahora)
            .ToList();
    }

    public Incidencia Crear(string titulo, string aula, Prioridad prioridad)
    {
        var incidencia = new Incidencia
        {
            Titulo = titulo,
            Aula = aula,
            Prioridad = prioridad,
            Estado = EstadoIncidencia.Abierta,
            CreadaEn = reloj.GetUtcNow()
        };
        return repositorio.Agregar(incidencia);
    }

    public bool Resolver(int id)
    {
        var incidencia = repositorio.Obtener(id);
        if (incidencia is null) return false;

        incidencia.Estado = EstadoIncidencia.Resuelta;
        incidencia.ResueltaEn = reloj.GetUtcNow();
        return true;
    }
}
