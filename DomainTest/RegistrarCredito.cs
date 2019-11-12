using Domain.Entities;
using NUnit.Framework;
using System;

namespace DomainTest
{
    public class RegistrarCredito
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void HU001P01registrarcredito()
        {
            var credito = new Credito();
            credito.Plazo = 9;
            credito.ValorPrestamo = 100000;
            credito.CreditoId = "1047";
            credito.Fecha = DateTime.Now;
            Assert.AreEqual(credito.ValidarPlazo(credito.Plazo), "Ok");
        }

        [Test]
        public void HU001P02registrarcreditoCalculoCuotas()
        {
            var credito = new Credito();
            credito.Plazo = 2;
            credito.ValorPrestamo = 100000;
            credito.CreditoId = "1085";
            credito.Fecha = DateTime.Now;
            Assert.AreEqual(credito.Registrar(), "Credito realizado exitosamente");
        }

        [Test]
        public void HU001P03registrarcreditoIncorrectoPlazo()
        {
            var credito = new Credito();
            credito.Plazo = 13;
            credito.ValorPrestamo = 100000;
            credito.CreditoId = "1047";
            credito.Fecha = DateTime.Now;
            Assert.AreEqual(credito.Registrar(), "El plazo máximo de pago del crédito debe ser 12 meses");
        }
    }
}