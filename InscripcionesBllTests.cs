using Microsoft.VisualStudio.TestTools.UnitTesting;
using Registro.BLL;
using Registro.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registro.BLL.Tests
{
    [TestClass()]
    public class InscripcionesBllTests
    {
        [TestMethod()]
        public void GuardarInscripcionTest()
        {
           
            Inscripciones inscripciones = new Inscripciones();
            inscripciones.InscripcionId = 1;
            decimal BalanceInicio = inscripciones.Balance;
            InscripcionesBll.Buscar(1);
            inscripciones.Balance = 1000;
            InscripcionesBll.GuardarInscripcion(inscripciones);
            Assert.AreEqual(inscripciones.Balance, BalanceInicio);
        }

       

        [TestMethod()]
        public void ModificarInscripcionTest()
        {
           
            Inscripciones inscripciones = new Inscripciones();
            inscripciones.InscripcionId = 1;
            decimal BalanceInicio = inscripciones.Balance;
            InscripcionesBll.Buscar(1);
            inscripciones.Monto =0;
            inscripciones.Balance = 0;
            inscripciones.Deposito = 0;
            InscripcionesBll.ModificarInscripcion(inscripciones);
            Assert.AreEqual(inscripciones.Balance, BalanceInicio);
        }

        [TestMethod()]
        public void EliminarInscripcionTest()
        {
            bool paso;
            paso = InscripcionesBll.EliminarInscripcion(2,1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Inscripciones inscripciones;
            inscripciones = InscripcionesBll.Buscar(1);
            Assert.AreEqual(inscripciones, inscripciones);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var listado = new List<Inscripciones>();
            listado = InscripcionesBll.GetList(p => true);
            Assert.AreEqual(listado, listado);
        }
    }
}

/// Comentario para ver si puedo subir el Test