using SoporteIT.Core.Dominio;

namespace SoporteIT.Core.Servicios;

public interface IRepositorioIncidencias
{
    IReadOnlyList<Incidencia> Listar();
    Incidencia? Obtener(int id);
    Incidencia Agregar(Incidencia incidencia);
}
