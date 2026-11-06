using SoporteIT.Core.Dominio;
using SoporteIT.Core.Servicios;

namespace SoporteIT.Tests;

public class ServicioIncidenciasTests
{
    private static readonly DateTimeOffset Lunes = new(2026, 11, 9, 11, 0, 0, TimeSpan.Zero);

    [Fact]
    public void Crear_deja_la_incidencia_abierta_con_la_hora_del_reloj()
    {
        var servicio = new ServicioIncidencias(new RepositorioEnMemoria(), new RelojFalso(Lunes));

        var incidencia = servicio.Crear("Proyector roto", "Aula 4", Prioridad.Alta);

        Assert.Equal(EstadoIncidencia.Abierta, incidencia.Estado);
        Assert.Equal(Lunes, incidencia.CreadaEn);
        Assert.Equal(1, incidencia.Id);
    }

    [Fact]
    public void Resolver_marca_la_incidencia_como_resuelta()
    {
        var reloj = new RelojFalso(Lunes);
        var servicio = new ServicioIncidencias(new RepositorioEnMemoria(), reloj);
        var incidencia = servicio.Crear("Proyector roto", "Aula 4", Prioridad.Alta);
        reloj.Avanzar(TimeSpan.FromHours(1));

        var resuelta = servicio.Resolver(incidencia.Id);

        Assert.True(resuelta);
        Assert.Equal(EstadoIncidencia.Resuelta, incidencia.Estado);
        Assert.Equal(Lunes.AddHours(1), incidencia.ResueltaEn);
    }

    [Fact]
    public void Resolver_devuelve_false_si_no_existe()
    {
        var servicio = new ServicioIncidencias(new RepositorioEnMemoria(), new RelojFalso(Lunes));

        Assert.False(servicio.Resolver(99));
    }
}
