using cualquirCosa.Models;
using cualquirCosa.Resultados.ResultadoDeporte;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cualquirCosa.Controllers;

[ApiController]

public class DeporteController : ControllerBase
{

    private readonly Prog31105Context _context;
    public DeporteController(Prog31105Context context)
    {
        _context = context;
    }
    [HttpGet]
    [Route("api/listaDeportes")]
    public async Task<ActionResult<List<ResultadoDeporte>>> GetListaSexos()
    {
        var resultado = new ResultadoDeporte();
        try
        {

            var deportes = await _context.Deportes.ToListAsync();          
            if (deportes != null)
            {
                foreach (var dep in deportes)
                {
                    var varResAux = new ResultadoDeporteItem
                    {
                        
                        Nombre = dep.Nombre
                        
                    };
                    resultado.listaDeportes.Add(varResAux);

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
}
