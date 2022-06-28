using cualquirCosa.Models;
using Microsoft.AspNetCore.Mvc;
using cualquirCosa.Resultados.ResultadoUsuario;
using cualquirCosa.Comando;
using Microsoft.EntityFrameworkCore;

namespace cualquirCosa.Controllers;

[ApiController]

public class UsuarioController : ControllerBase
{
    

    private readonly Prog31105Context  _context;

    public UsuarioController(Prog31105Context context)
    {
        _context = context;
    }

    [HttpPost]
    [Route("api/Login")]
    public async Task<ActionResult<ResultadoUsuario>>LogIn([FromBody] UsuarioComando comando )
    {
        var resultado = new ResultadoUsuario();
        try
        {
            var usuario = await _context.Usuarios.Where(c=>c.Activo && c.NombreUsuario.Equals(comando.Nombre) && c.Password.Equals(comando.Password)).Include(c=>c.IdRolNavigation).FirstOrDefaultAsync();
            if(usuario.NombreUsuario != null)
            {
                resultado.NombreUsuario = usuario.NombreUsuario;
                resultado.Rol = usuario.IdRolNavigation.NombreRol;
                resultado.StatusCode= 200;
                
            }else
            {
                resultado.StatusCode = 500;
                resultado.SetError("Usuario o contraseña incorrecto");
            }
            return Ok(resultado);

        }catch (Exception ex)
        {
            resultado.StatusCode = 400;
            resultado.SetError("Error");
            return BadRequest(ex.Message);
        }
    }   
}
