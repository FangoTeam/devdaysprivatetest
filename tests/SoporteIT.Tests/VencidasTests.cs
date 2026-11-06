using SoporteIT.Core.Servicios;

namespace SoporteIT.Tests;

public class VencidasTests
{
    [Fact]
    public void Vencidas_solo_devuelve_las_que_han_superado_el_sla_en_horario_lectivo()
    {
        var repositorio = new RepositorioEnMemoria();
        DatosDemo.Cargar(repositorio);
        var lunesAlMediodia = new DateTimeOffset(2026, 11, 9, 12, 30, 0, TimeSpan.FromHours(1));
        var servicio = new ServicioIncidencias(repositorio, new RelojFalso(lunesAlMediodia));

        var ids = servicio.Vencidas().Select(i => i.Id).OrderBy(id => id).ToArray();

        Assert.Equal([1, 4, 8], ids);
    }
}
