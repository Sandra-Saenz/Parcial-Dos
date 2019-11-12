using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Credito : Entity<int>
    {
        public string CreditoId { get; set; }
        public double ValorPrestamo { get; set; }
        public DateTime Fecha { get; set; }
        public int Plazo { get; set; }
        public List<Cuota> ListaCuotas { get; set; }
        
        public Credito()
        {
        }

        public Credito(string creditoId, double valorPrestamo, DateTime fecha, int plazo)
        {
            CreditoId = creditoId;
            ValorPrestamo = valorPrestamo;
            Fecha = fecha;
            Plazo = plazo;
            Registrar();
        }

        public string ValidarPlazo(int numPlazo)
        {
            if (numPlazo <= 12 && numPlazo > 0)
            {
                return "Ok";
            }
            else
            {
                return "El plazo máximo de pago del crédito debe ser 12 meses";
            }
        }

        public double Calcularcuotas()
        {
            double pago = this.ValorPrestamo / this.Plazo;
            return pago;
        }

        public string Registrar()
        {
            if (ValidarPlazo(this.Plazo).Equals("Ok"))
            {
                ListaCuotas = new List<Cuota>();
                for (int i = 1; i <= this.Plazo; i++)
                {
                    Cuota cuota = new Cuota();
                    cuota.CreditoId = this.CreditoId;
                    cuota.ValorCuota = this.Calcularcuotas();
                    cuota.FechaCuota = this.Fecha.AddMonths(i);
                    ListaCuotas.Add(cuota);
                }

                return "Credito realizado exitosamente";
            }
            else
            {
                return "El plazo máximo de pago del crédito debe ser 12 meses";
            }
        }
    }
}
