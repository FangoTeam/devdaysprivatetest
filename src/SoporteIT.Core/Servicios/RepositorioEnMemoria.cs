using SoporteIT.Core.Dominio;

namespace SoporteIT.Core.Servicios;

public class RepositorioEnMemoria : IRepositorioIncidencias
{
    private readonly List<Incidencia> _incidencias = [];
    private int _siguienteId = 1;

    public IReadOnlyList<Incidencia> Listar() => _incidencias;

    public Incidencia? Obtener(int id) => _incidencias.FirstOrDefault(i => i.Id == id);

    public Incidencia Agregar(Incidencia incidencia)
    {
        incidencia.Id = _siguienteId++;
        _incidencias.Add(incidencia);
        return incidencia;
    }
}
