using HelloShop.Business.Abstract;
using HelloShop.Business.Dtos.Clientes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteBusiness _clienteBusiness;

        public ClientesController(IClienteBusiness clienteBusiness)
        {
            _clienteBusiness = clienteBusiness;
        }
        [HttpGet]
        public async Task<IEnumerable<ClienteDetalleGestionarDto>> ObtenerClientes()
        {
            try
            {
                var clientes = await _clienteBusiness.ObtenerClientes();
                return clientes;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
