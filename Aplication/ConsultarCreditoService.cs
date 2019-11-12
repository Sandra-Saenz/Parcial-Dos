using Domain.Contracts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication
{
    public class ConsultarCreditoService
    {
        readonly IUnitOfWork _unitOfWork;

        public ConsultarCreditoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ConsultarCreditoResponse Ejecutar(ConsultarCreditoRequest request)
        {
            Credito credito = _unitOfWork.CreditoRepository.FindFirstOrDefault(t => t.CreditoId == request.Numero);
            if (credito != null)
            {
                return new ConsultarCreditoResponse() { Mensaje = $"la cedula {credito.CreditoId} tiene un credito desde el {credito.Fecha} de {credito.ValorPrestamo} pesos, con un plazo de {credito.Plazo} meses" };
            }
            else
            {
                return new ConsultarCreditoResponse() { Mensaje = $"No exite un credito con esa cedula" };
            }
        }
    }

    public class ConsultarCreditoRequest
    {
        public string Numero { get; set; }

    }

    public class ConsultarCreditoResponse
    {
        public string Mensaje { get; set; }
    }
}
