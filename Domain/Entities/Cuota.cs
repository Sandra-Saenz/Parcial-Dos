using Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Cuota : Entity<int>
    {
        public DateTime FechaCuota { get; set; }
        public double ValorCuota { get; set; }
        public string CreditoId { get; set; }

    }
}
