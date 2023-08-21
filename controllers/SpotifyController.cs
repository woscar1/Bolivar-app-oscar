using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.conectionsSpotify;
using API.connectionsBD;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpotifyController : Controller
    {
        /// <summary>
        /// servio get para traer el token
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult <string> GenToken()
        {
            return Conection.Token();
        }  

        /// <summary>
        /// servicio por get para buscar por artista cancion o album
        /// </summary>
        /// <param name="id">parametro para buscar</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult <IEnumerable<SpotifyList>> GetUser(string id)
        {
            return Conection.TxtSearch_SpotifyList(id);
        }     
    }
}