using SoporteIT.Core.Dominio;
using SoporteIT.Core.Servicios;

namespace SoporteIT.Tests;

public class PoliticaSlaTests
{
    [Fact]
    public void Una_incidencia_alta_creada_el_lunes_por_la_manana_vence_cuatro_horas_despues()
    {
        var incidencia = new Incidencia
        {
            Titulo = "t", Aula = "a", Prioridad = Prioridad.Alta, Estado = EstadoIncidencia.Abierta,
            CreadaEn = new DateTimeOffset(2026, 11, 9, 9, 0, 0, TimeSpan.FromHours(1))
        };

        var vence = PoliticaSla.Vencimiento(incidencia);

        Assert.Equal(new DateTimeOffset(2026, 11, 9, 13, 0, 0, TimeSpan.FromHours(1)), vence);
    }
}
