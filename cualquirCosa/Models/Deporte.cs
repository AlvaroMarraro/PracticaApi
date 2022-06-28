using System;
using System.Collections.Generic;

namespace cualquirCosa.Models
{
    public partial class Deporte
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public Guid IdTipoDeporte { get; set; }

        public virtual TipoDeporte IdTipoDeporteNavigation { get; set; } = null!;
    }
}
