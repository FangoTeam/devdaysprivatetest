using SoporteIT.Core.Dominio;
using SoporteIT.Core.Servicios;

namespace SoporteIT.Tests;

// Pruebas "del cliente": se copian a tests/SoporteIT.Tests a las 15:00 de la demo.
public class SlaAceptacionTests
{
    private static DateTimeOffset Madrid(int año, int mes, int dia, int hora, int minuto)
    {
        var zona = TimeZoneInfo.FindSystemTimeZoneById("Europe/Madrid");
        var local = new DateTime(año, mes, dia, hora, minuto, 0, DateTimeKind.Unspecified);
        return new DateTimeOffset(local, zona.GetUtcOffset(local));
    }

    private static Incidencia Nueva(Prioridad prioridad, DateTimeOffset creada) => new()
    {
        Titulo = "t", Aula = "a", Prioridad = prioridad, Estado = EstadoIncidencia.Abierta, CreadaEn = creada
    };

    [Fact]
    public void Dentro_del_mismo_dia_lectivo_suma_las_horas_sin_mas()
    {
        var vence = PoliticaSla.Vencimiento(Nueva(Prioridad.Alta, Madrid(2026, 11, 9, 9, 0)));
        Assert.Equal(Madrid(2026, 11, 9, 13, 0), vence);
    }

    [Fact]
    public void Viernes_a_ultima_hora_el_plazo_sigue_el_lunes()
    {
        var vence = PoliticaSla.Vencimiento(Nueva(Prioridad.Alta, Madrid(2026, 11, 6, 14, 30)));
        Assert.Equal(Madrid(2026, 11, 9, 11, 30), vence);
    }

    [Fact]
    public void Creada_en_fin_de_semana_cuenta_desde_el_lunes_a_las_ocho()
    {
        var vence = PoliticaSla.Vencimiento(Nueva(Prioridad.Critica, Madrid(2026, 11, 7, 10, 0)));
        Assert.Equal(Madrid(2026, 11, 9, 10, 0), vence);
    }

    [Fact]
    public void Creada_antes_de_abrir_cuenta_desde_las_ocho()
    {
        var vence = PoliticaSla.Vencimiento(Nueva(Prioridad.Critica, Madrid(2026, 11, 9, 6, 0)));
        Assert.Equal(Madrid(2026, 11, 9, 10, 0), vence);
    }

    [Fact]
    public void Creada_justo_al_cierre_cuenta_desde_la_siguiente_apertura()
    {
        var vence = PoliticaSla.Vencimiento(Nueva(Prioridad.Critica, Madrid(2026, 11, 6, 15, 0)));
        Assert.Equal(Madrid(2026, 11, 9, 10, 0), vence);
    }

    [Fact]
    public void El_cambio_de_hora_de_octubre_no_altera_las_horas_lectivas()
    {
        // Viernes 23/10 (UTC+2). El domingo 25/10 se atrasa el reloj y el lunes ya es UTC+1.
        var vence = PoliticaSla.Vencimiento(Nueva(Prioridad.Media, Madrid(2026, 10, 23, 14, 0)));
        Assert.Equal(Madrid(2026, 10, 26, 15, 0), vence);
    }
}
