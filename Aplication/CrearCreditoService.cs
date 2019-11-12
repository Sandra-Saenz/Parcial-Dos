using Domain.Contracts;
using Domain.Entities;
using System;

namespace Aplication
{
    public class CrearCreditoService
    {
        readonly IUnitOfWork _unitOfWork;

        public CrearCreditoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public CrearCreditoResponse Ejecutar(CrearCreditoRequest request)
        {
            var credito = _unitOfWork.CreditoRepository.FindFirstOrDefault(t => t.CreditoId == request.Cedula);
            if (credito == null)
            {
                 credito = new Credito(request.Cedula, request.ValorPrestamo, request.Fecha, request.Plazo);
                if (credito.ValidarPlazo(request.Plazo).Equals("Ok"))
                {
                    _unitOfWork.CreditoRepository.Add(credito);
                    _unitOfWork.Commit();
                    return new CrearCreditoResponse() { Mensaje = $"Se creo con exito el credito para la cedula {credito.CreditoId}" };
                }
                else
                {
                    return new CrearCreditoResponse() { Mensaje = $"Numero de plazos invalido" };
                }
            }
            else
            {
                return new CrearCreditoResponse() { Mensaje = $"ya exite un credito" };
            }
        }
    }

    public class CrearCreditoRequest
    {
        public string Cedula { get; set; }
        public int Plazo { get; set; }
        public double ValorPrestamo { get; set; }
        public DateTime Fecha { get; set; }
    }

    public class CrearCreditoResponse
    {
        public string Mensaje { get; set; }
    }
}
