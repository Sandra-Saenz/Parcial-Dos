using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplication;
using Domain.Contracts;
using Infraestructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreditoController : ControllerBase
    {
        readonly CreditoContext _context;
        readonly IUnitOfWork _unitOfWork;

        //Se Recomienda solo dejar la Unidad de Trabajo
        public CreditoController(CreditoContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        [HttpPost]
        public ActionResult<CrearCreditoResponse> Post(CrearCreditoRequest request)
        {
            CrearCreditoService _service = new CrearCreditoService(_unitOfWork);
            CrearCreditoResponse response = _service.Ejecutar(request);
            return Ok(response);
        }

        [HttpGet ("ConsultarCredito/{id}")]
        public ActionResult<ConsultarCreditoResponse> Get(string id)
        {
            ConsultarCreditoService service = new ConsultarCreditoService(_unitOfWork);
            ConsultarCreditoResponse response = service.Ejecutar(new ConsultarCreditoRequest { Numero = id });
            return Ok(response);
        }
    }
}
