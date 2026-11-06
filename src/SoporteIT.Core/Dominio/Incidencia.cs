namespace SoporteIT.Core.Dominio;

public class Incidencia
{
    public int Id { get; set; }
    public string Titulo { get; set; } = "";
    public string Aula { get; set; } = "";
    public Prioridad Prioridad { get; set; }
    public EstadoIncidencia Estado { get; set; }
    public DateTimeOffset CreadaEn { get; set; }
    public DateTimeOffset? ResueltaEn { get; set; }
}
