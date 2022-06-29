using cualquirCosa.Models;
using Microsoft.AspNetCore.Mvc;
using cualquirCosa.Resultados.ResultadoUsuario;
using cualquirCosa.Comando;
using Microsoft.EntityFrameworkCore;
using cualquirCosa.Resultados;

namespace cualquirCosa.Controllers;

[ApiController]

public class UsuarioController : ControllerBase
{
    

    private readonly Prog31105Context  _context;

    public UsuarioController(Prog31105Context context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("api/usuario/GetTodos")]
    public async Task<ActionResult<List<ResultadoUsuario>>> GetTodosActivos()
    {        
        var resultado = new ResultadoUsuario();       
        try
        {

            var usuarios = await _context.Usuarios.Where(c=>c.Activo).Include(c=>c.IdRolNavigation).ToListAsync();
            if(usuarios != null)
            {   
                foreach (var usu in usuarios){
                    var resultAux = new ResultadoUsuariosItem
                    {
                        NombreUsuario =  usu.NombreUsuario,
                        Rol = usu.IdRolNavigation.NombreRol
                        

                    };
                    resultado.listaUsuarios.Add(resultAux);
                }
                
                resultado.StatusCode = 200;
                return Ok (resultado);
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
            return BadRequest(ex.Message);
        }
    }



    [HttpPost]
    [Route("api/usuarios/Create")]
    public async Task<ActionResult<ResultadoBase>>CreateUsuario([FromBody] UsuarioComando comando)
    {
        var resultado = new ResultadoBase();
        try
        {
            var usuario = new Usuario()
            {
                Id = Guid.NewGuid(),
                Activo = true,
                NombreUsuario = comando.NombreUsuario,
                Password = comando.Password,
                FechaAlta = DateOnly.Parse("2022-06-28"),
                IdRol = new Guid("6c31ecb6-b59c-40ea-bb20-b1b7f32ce51b"),
            };
            await _context.AddAsync(usuario);
            await _context.SaveChangesAsync();
            resultado.StatusCode = 200;
            return Ok(resultado);

        }
        catch (Exception ex)
        {
            resultado.SetError("Error en la carga");
            return BadRequest(ex.Message);

        }
    }


    [HttpPost]
    [Route("api/usuarios/Login")]
    public async Task<ActionResult<ResultadoUsuarioBase>>LogIn([FromBody] UsuarioComando comando )
    {
        var resultado = new ResultadoUsuarioBase();
        try
        {
            var usuario = await _context.Usuarios.Where(c=>c.Activo && c.NombreUsuario.Equals(comando.NombreUsuario) && c.Password.Equals(comando.Password)).Include(c=>c.IdRolNavigation).FirstOrDefaultAsync();
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
