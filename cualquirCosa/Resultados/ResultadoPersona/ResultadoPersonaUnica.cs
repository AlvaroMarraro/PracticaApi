using System.Security;
namespace cualquirCosa.Resultados.ResultadoPersona;

public class ResultadoPersonaUnica : ResultadoBase
{

        
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Dni { get; set; } = null!;
        public string Sexo { get; set; }

}