namespace SoporteIT.Core.Servicios;

/// <summary>Horario lectivo del centro: lunes a viernes, de 08:00 a 15:00 (hora de Madrid).</summary>
public static class HorarioLectivo
{
    private static readonly TimeZoneInfo Madrid = TimeZoneInfo.FindSystemTimeZoneById("Europe/Madrid");
    private static readonly TimeSpan Apertura = TimeSpan.FromHours(8);
    private static readonly TimeSpan Cierre = TimeSpan.FromHours(15);

    public static DateTimeOffset SumarHorasLectivas(DateTimeOffset inicio, TimeSpan duracion)
    {
        // Se calcula con la hora local de Madrid: el horario lectivo queda lejos del cambio de hora (madrugada del domingo).
        var actual = AjustarAApertura(TimeZoneInfo.ConvertTime(inicio, Madrid).DateTime);
        var restante = duracion;

        while (true)
        {
            var disponible = actual.Date + Cierre - actual;
            if (restante <= disponible)
            {
                actual += restante;
                break;
            }

            restante -= disponible;
            actual = SiguienteApertura(actual.Date.AddDays(1));
        }

        return new DateTimeOffset(actual, Madrid.GetUtcOffset(actual));
    }

    private static DateTime AjustarAApertura(DateTime momento)
    {
        if (EsDiaLectivo(momento) && momento.TimeOfDay < Cierre)
            return momento.TimeOfDay < Apertura ? momento.Date + Apertura : momento;

        return SiguienteApertura(momento.Date.AddDays(1));
    }

    private static DateTime SiguienteApertura(DateTime dia)
    {
        while (!EsDiaLectivo(dia)) dia = dia.AddDays(1);
        return dia.Date + Apertura;
    }

    private static bool EsDiaLectivo(DateTime dia) => dia.DayOfWeek is not (DayOfWeek.Saturday or DayOfWeek.Sunday);
}
