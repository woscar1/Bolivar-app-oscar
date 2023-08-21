using API.Entities;
using Microsoft.AspNetCore.Mvc;
using API.conectionsSpotify;
using API.connectionsBD;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {   
        /// <summary>
        /// servicio para traer los usuarios 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult <IEnumerable<Users>> GetUser()
        {
            var cliente= Conection.GetTokenAsync();
            string query = "select * from Usuarios";
            var informacion = ConnectionBD.conexionBD(query);
            var Clientes = from e in informacion
                           select e;

            return Clientes.ToList();
        }                   
    }
}