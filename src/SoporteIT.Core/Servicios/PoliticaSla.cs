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

    // TODO: ¿de verdad contamos las noches y los fines de semana?
    public static DateTimeOffset Vencimiento(Incidencia incidencia) =>
        incidencia.CreadaEn + Objetivo(incidencia.Prioridad);
}
