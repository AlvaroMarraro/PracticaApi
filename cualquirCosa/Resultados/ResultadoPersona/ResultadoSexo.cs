namespace cualquirCosa.Resultados.ResultadoPersona;

public class ResultadoSexo : ResultadoBase
{
    public List<ResultadoSexoItem> listaSexos { get; set; } = new List<ResultadoSexoItem>();
}

public class ResultadoSexoItem
{
    public string Nombre { get; set; }
}