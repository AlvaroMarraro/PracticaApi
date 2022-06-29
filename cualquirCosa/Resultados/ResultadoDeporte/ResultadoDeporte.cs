using System.Runtime.ConstrainedExecution;
namespace cualquirCosa.Resultados.ResultadoDeporte;

public class ResultadoDeporte : ResultadoBase
{
    public List<ResultadoDeporteItem> listaDeportes { get; set; } = new List<ResultadoDeporteItem>();

}

public class ResultadoDeporteItem
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
}