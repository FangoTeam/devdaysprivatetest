using System.Globalization;
using System.Net;
using System.Text;
using SoporteIT.Core.Dominio;
using SoporteIT.Core.Servicios;

namespace SoporteIT.Api;

public static class Panel
{
    private static readonly TimeZoneInfo Madrid = TimeZoneInfo.FindSystemTimeZoneById("Europe/Madrid");
    private static readonly CultureInfo Es = new("es-ES");

    private static string Local(DateTimeOffset fecha) =>
        TimeZoneInfo.ConvertTime(fecha, Madrid).ToString("ddd dd/MM HH:mm", Es);

    public static string Renderizar(ServicioIncidencias servicio)
    {
        var ahora = servicio.Ahora();
        var filas = new StringBuilder();
        var vencidas = 0;

        foreach (var i in servicio.Listar().OrderBy(x => x.CreadaEn))
        {
            var vence = PoliticaSla.Vencimiento(i);
            var resuelta = i.Estado == EstadoIncidencia.Resuelta;
            var vencida = !resuelta && vence < ahora;
            if (vencida) vencidas++;

            var clase = vencida ? "vencida" : resuelta ? "resuelta" : "ok";
            var etiqueta = vencida ? "SLA VENCIDO" : resuelta ? "Resuelta" : "En plazo";

            filas.Append($"""
                <tr class="{clase}">
                  <td>{i.Id}</td><td>{WebUtility.HtmlEncode(i.Titulo)}</td><td>{WebUtility.HtmlEncode(i.Aula)}</td>
                  <td>{i.Prioridad}</td><td>{Local(i.CreadaEn)}</td><td>{Local(vence)}</td><td><span class="etiqueta">{etiqueta}</span></td>
                </tr>
                """);
        }

        var cabecera = $"Ahora: {Local(ahora)} · {vencidas} con SLA vencido";

        return $$"""
            <!doctype html>
            <html lang="es"><head><meta charset="utf-8"><title>SoporteIT · Panel</title>
            <style>
              body{font-family:system-ui,sans-serif;background:#0f1117;color:#f4f1ea;margin:0;padding:32px}
              h1{margin:0 0 4px}
              .sub{color:#8b90a0;margin-bottom:24px;font-size:18px}
              table{border-collapse:collapse;width:100%}
              th,td{padding:12px 14px;text-align:left;border-bottom:1px solid #262b38}
              tr.vencida td{background:#3a1519}
              tr.resuelta td{color:#8b90a0}
              .etiqueta{padding:4px 10px;border-radius:999px;font-size:13px;background:#1f3b2a;color:#4ade80}
              tr.vencida .etiqueta{background:#7f1d1d;color:#fecaca}
              tr.resuelta .etiqueta{background:#262b38;color:#c9ccd6}
            </style></head><body>
            <h1>SoporteIT · Panel de incidencias</h1>
            <p class="sub">{{cabecera}}</p>
            <table><thead><tr><th>#</th><th>Incidencia</th><th>Aula</th><th>Prioridad</th><th>Creada</th><th>Vence</th><th>Estado SLA</th></tr></thead>
            <tbody>{{filas}}</tbody></table>
            </body></html>
            """;
    }
}
