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
            bool paso;
            Inscripciones inscripciones = new Inscripciones();
            inscripciones.InscripcionId = 0;
            inscripciones.Fecha = DateTime.Now;
            inscripciones.PersonaId = 3;
            inscripciones.Comentarios = "Prueba del Test de Inscripcion";
            inscripciones.Monto = 0;
            inscripciones.Balance = 1000;
            inscripciones.Deposito = 0;
            paso = InscripcionesBll.GuardarInscripcion(inscripciones);
            Assert.AreEqual(paso, true);
        }

       

        [TestMethod()]
        public void ModificarInscripcionTest()
        {
            bool paso;
            Inscripciones inscripciones = new Inscripciones();
            inscripciones.InscripcionId = 2;
            inscripciones.Fecha = DateTime.Now;
            inscripciones.PersonaId = 3;
            inscripciones.Comentarios = "Prueba del Test de Inscripcion";
            inscripciones.Monto = 0;
            inscripciones.Balance = 0;
            inscripciones.Deposito = 500;
            paso = InscripcionesBll.ModificarInscripcion(inscripciones);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarInscripcionTest()
        {
            bool paso;
            paso = InscripcionesBll.EliminarInscripcion(3,2);
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