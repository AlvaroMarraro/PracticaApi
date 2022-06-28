using System;
using System.Collections.Generic;

namespace cualquirCosa.Models
{
    public partial class Persona
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Dni { get; set; } = null!;
        public Guid IdSexo { get; set; }
        public string Calle { get; set; } = null!;
        public string Numbre { get; set; } = null!;

        public virtual Sexo IdSexoNavigation { get; set; } = null!;
    }
}
