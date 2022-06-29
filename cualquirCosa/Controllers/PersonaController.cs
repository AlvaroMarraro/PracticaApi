using System.Reflection.Metadata;
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
    [HttpGet]
    [Route("api/listaSexo")]
    public async Task<ActionResult<List<ResultadoSexo>>> GetListaSexos()
    {
        var resultado = new ResultadoSexo();
        try
        {

            var sexo = await _context.Sexos.ToListAsync();             
            if (sexo != null)
            {
                foreach (var sex in sexo)
                {
                    var varResAux = new ResultadoSexoItem
                    {
                        
                        Nombre = sex.Nombre
                        
                    };
                    resultado.listaSexos.Add(varResAux);

                }


                resultado.StatusCode = 200;
                return Ok(resultado);
            }
            else
            {
                resultado.SetError("No se puede acceder a la lista");
                resultado.StatusCode = 500;
                return Ok(resultado);
            }


        }
        catch (Exception ex)
        {
            resultado.StatusCode = 400;
            resultado.SetError(ex.Message);
            return BadRequest(resultado);
        }

    }

    [HttpPut]
    [Route("api/persona/UpdatePersona")]
    public async Task<ActionResult<ResultadoBase>>EditarPersona([FromBody] PersonaEditarComando comando)
    {
        var resultado = new ResultadoBase();
        try{
            if(comando.Id.Equals(""))
            {
                resultado.SetError("No se puede editar esa persona");
                resultado.StatusCode = 400;
            }
            var persona = await _context.Personas.Where(c=>c.Id.Equals(comando.Id)).FirstOrDefaultAsync();
            if(persona !=null)
            {
                persona.Dni = comando.Dni;
                persona.Apellido = comando.Apellido;
                persona.Nombre = comando.Nombre;
                

                _context.Update(persona);
                await _context.SaveChangesAsync();
                resultado.StatusCode = 200;
            }else 
            {
                resultado.SetError("persona no encontrada");
                resultado.StatusCode = 500;
            }

            return resultado;

        }catch(Exception ex)
        {
            resultado.StatusCode = 400;
            resultado.SetError(ex.Message);
            return BadRequest(resultado);
        }
        
    }


    [HttpGet]
    [Route("api/persona/GetPersona/{idPersona}")]
    public async Task<ActionResult<ResultadoPersonaUnica>> GetPersonasUnica(Guid idPersona)
    {
        var resultado = new ResultadoPersonaUnica();
        try
        {

            var persona = await _context.Personas.Where(c=> c.Id.Equals(idPersona)).Include(c => c.IdSexoNavigation).FirstOrDefaultAsync();
            if (persona != null)
            {
                resultado.Apellido = persona.Apellido;
                resultado.Nombre = persona.Nombre;
                resultado.Dni = persona.Dni;
                resultado.Sexo = persona.IdSexoNavigation.Nombre;


                resultado.StatusCode = 200;
                return Ok(resultado);
            }
            else
            {
                resultado.SetError("No se puede acceder a la lista");
                resultado.StatusCode = 500;
                return Ok(resultado);
            }


        }
        catch (Exception ex)
        {
            resultado.StatusCode = 400;
            resultado.SetError(ex.Message);
            return BadRequest(resultado);
        }

    }



    [HttpGet]
    [Route("api/listaPersonas")]
    public async Task<ActionResult<List<ResultadoPersona>>> GetPersonas()
    {
        var resultado = new ResultadoPersona();
        try
        {

            var personas = await _context.Personas.Include(c => c.IdSexoNavigation).ToListAsync();
            if (personas != null)
            {
                foreach (var per in personas)
                {
                    var varResAux = new ResultadoPersonaItem
                    {
                        Id = per.Id,
                        Nombre = per.Nombre,
                        Apellido = per.Apellido,
                        Dni = per.Dni,
                        Sexo = per.IdSexoNavigation.Nombre,

                    };
                    resultado.listaPersonas.Add(varResAux);

                }


                resultado.StatusCode = 200;
                return Ok(resultado);
            }
            else
            {
                resultado.SetError("No se puede acceder a la lista");
                resultado.StatusCode = 500;
                return Ok(resultado);
            }


        }
        catch (Exception ex)
        {
            resultado.StatusCode = 400;
            resultado.SetError(ex.Message);
            return BadRequest(resultado);
        }

    }

    [HttpPost]
    [Route("api/crearPersona")]
    public async Task<ActionResult<ResultadoBase>> CreatePersona([FromBody] PersonaComando comando)
    {
        var resultado = new ResultadoBase();
        try
        {
            var sexo = await _context.Sexos.Where(c => c.Nombre.Equals(comando.Sexo)).FirstOrDefaultAsync();
            if (sexo != null)
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
            }
            else
            {
                resultado.SetError("Persona no creada");
                resultado.StatusCode = 500;
                return Ok(resultado);
            }


        }
        catch (Exception ex)
        {
            resultado.StatusCode = 400;
            resultado.SetError(ex.Message);
            return BadRequest(resultado);
        }

    }



}
