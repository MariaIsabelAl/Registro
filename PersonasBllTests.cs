using Microsoft.VisualStudio.TestTools.UnitTesting;
using Registro.BLL;
using Registro.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registro.BLL.Tests
{
    [TestClass()]
    public class PersonasBllTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Personas personas = new Personas();
            personas.PersonaID = 0;
            personas.Nombre = "Prueba Test";
            personas.Telefono = "45127893";
            personas.Direccion = "Tenares";
            personas.Cedula = "541258731";
            personas.Balance = 5000;
            personas.FechaNacimiento = DateTime.Now;
            paso = PersonasBll.Guardar(personas);
            Assert.AreEqual(paso, true);

        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Personas personas = new Personas();
            personas.PersonaID = 1;
            personas.Nombre = "Prueba Test";
            personas.Telefono = "123456";
            personas.Direccion = "Salcedo";
            personas.Cedula = "123456";
            personas.FechaNacimiento = DateTime.Now;
            personas.Balance = 300;
            paso = PersonasBll.Modificar(personas);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            paso = PersonasBll.Eliminar(3);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Personas personas;
            personas = PersonasBll.Buscar(2);
            Assert.AreEqual(personas, personas);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var listado = new List<Personas>();
            listado = PersonasBll.GetList(p => true);
            Assert.AreEqual(listado, listado);
        }
    }
}
