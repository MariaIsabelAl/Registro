using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Registro.Entidades
{
    public class Personas
    {
        

        [Key]
        public int PersonaID { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public decimal Balance { get; set; }

        public Personas()
         {
             PersonaID = 0;
             Nombre = string.Empty;
             Telefono = string.Empty;
             Cedula = string.Empty;
             Direccion = string.Empty;
             FechaNacimiento = DateTime.Now;
             Balance = 0;
        }
        
        

    }


}
