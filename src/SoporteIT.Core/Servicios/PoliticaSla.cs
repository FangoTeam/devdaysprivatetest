using SoporteIT.Core.Dominio;

namespace SoporteIT.Core.Servicios;

/// <summary>Plazos de respuesta (SLA) por prioridad.</summary>
public static class PoliticaSla
{
    public static TimeSpan Objetivo(Prioridad prioridad) => prioridad switch
    {
        Prioridad.Critica => TimeSpan.FromHours(2),
        Prioridad.Alta => TimeSpan.FromHours(4),
        Prioridad.Media => TimeSpan.FromHours(8),
        _ => TimeSpan.FromHours(24)
    };

    /// <summary>El plazo solo cuenta el horario lectivo (L-V, 08:00-15:00, hora de Madrid).</summary>
    public static DateTimeOffset Vencimiento(Incidencia incidencia) =>
        HorarioLectivo.SumarHorasLectivas(incidencia.CreadaEn, Objetivo(incidencia.Prioridad));
}
