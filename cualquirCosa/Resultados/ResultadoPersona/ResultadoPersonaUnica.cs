using System.Security;
namespace cualquirCosa.Resultados.ResultadoPersona;

public class ResultadoPersonaUnica : ResultadoBase
{

        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Dni { get; set; } = null!;
        public Guid IdSexo { get; set; }

}