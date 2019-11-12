using Aplication;
using Infraestructure;
using Infraestructure.Base;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace AplicationTest
{
    public class CreditoService
    {
        CreditoContext _context;
        CreditoContext __context;

        [SetUp]
        public void Setup()
        {
            var optionsSqlServer = new DbContextOptionsBuilder<CreditoContext>()
            .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Credito;Trusted_Connection=True;MultipleActiveResultSets=true")
            .Options;
            __context = new CreditoContext(optionsSqlServer);

            var optionsInMemory = new DbContextOptionsBuilder<CreditoContext>().UseInMemoryDatabase("Credito").Options;

            _context = new CreditoContext(optionsInMemory);
        }

        [Test]
        public void CreditoCorrectoMemory()
        {
            var Fecha = new DateTime(2019, 11, 07, 0, 0, 0);
            var request = new CrearCreditoRequest { Cedula = "1001", ValorPrestamo = 900000, Plazo = 9, Fecha = Fecha };
            CrearCreditoService _service = new CrearCreditoService(new UnitOfWork(_context));
            var response = _service.Ejecutar(request);
            Assert.AreEqual("Se creo con exito el credito para la cedula 1001", response.Mensaje);
            Assert.Pass();
        }

        [Test]
        public void CreditoIncorrectoMemory()
        {
            var request = new CrearCreditoRequest { Cedula = "1096", ValorPrestamo = 900000, Plazo = 13, Fecha = DateTime.Now };
            CrearCreditoService _service = new CrearCreditoService(new UnitOfWork(_context));
            var response = _service.Ejecutar(request);
            Assert.AreEqual("Numero de plazos invalido", response.Mensaje);
            Assert.Pass();
        }

        [Test]
        public void CreditoCorrectoSql()
        {
            var Fecha = new DateTime(2019, 11, 10, 0, 0, 0);
            var request = new CrearCreditoRequest { Cedula = "10", ValorPrestamo = 1000000, Plazo = 5, Fecha = Fecha };
            CrearCreditoService _service = new CrearCreditoService(new UnitOfWork(__context));
            var response = _service.Ejecutar(request);
            Assert.AreEqual("Se creo con exito el credito para la cedula 10", response.Mensaje);
            Assert.Pass();
        }

        [Test]
        public void CreditoIncorrectoSql()
        {
            var Fecha = new DateTime(2019, 11, 10, 0, 0, 0);
            var request = new CrearCreditoRequest { Cedula = "1065", ValorPrestamo = 1000000, Plazo = 5, Fecha = Fecha };
            CrearCreditoService _service = new CrearCreditoService(new UnitOfWork(__context));
            var response = _service.Ejecutar(request);
            Assert.AreEqual("ya exite un credito", response.Mensaje);
            Assert.Pass();
        }
    }
}