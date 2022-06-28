using System.Data;
using System.IO.Pipes;
using cualquirCosa.Comando;
using cualquirCosa.Models;
using cualquirCosa.Resultados;
using cualquirCosa.Resultados.ResultadoPersona;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cualquirCosa.Controllers;

[ApiController]

public class PersonaController : ControllerBase
{   

    private readonly Prog31105Context _context; 
    public PersonaController(Prog31105Context context)
    {
        _context = context;
    }

    
    [HttpPost]
    [Route("api/crearPersona")]
    public async Task<ActionResult<ResultadoBase>>CreatePersona([FromBody] PersonaComando comando)
    {
        var resultado = new ResultadoBase();
        try
        {
            var sexo = await _context.Sexos.Where(c=>c.Nombre.Equals(comando.Sexo)).FirstOrDefaultAsync();
            if(sexo != null)
            {
                var persona = new Persona
                {
                    Id = Guid.NewGuid(),
                    Apellido = comando.Apellido,
                    Nombre = comando.Nombre,
                    Dni = comando.Dni,
                    IdSexoNavigation = sexo,
                    Calle = comando.Calle,
                    Numbre = comando.Numbre
                };

                await _context.AddAsync(persona);
                await _context.SaveChangesAsync();
                resultado.StatusCode = 200;
                return Ok(resultado);
            }else
            {
                resultado.SetError("Persona no creada");
                resultado.StatusCode = 500;
                return Ok(resultado);
            }
            

        }catch (Exception ex)
        {
           resultado.StatusCode = 400;
           resultado.SetError(ex.Message);
           return BadRequest(resultado);
        }

    }


    
}
