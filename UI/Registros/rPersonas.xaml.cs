using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;
using Registro.BLL;
using Registro.Entidades;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Registro.UI.Registros
{

    public partial class rPersonas : Window
    {
        public rPersonas()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IDTextBox.Text = string.Empty;
            NombreTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            CedulaTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            FechaDataPicker.Text = Convert.ToString(DateTime.Now);
            BalanceTextBox.Text = string.Empty;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private Personas LlenaClases()
        {
            Personas persona = new Personas();
            if (string.IsNullOrWhiteSpace(IDTextBox.Text))
            {
                IDTextBox.Text = "0";
            }else persona.PersonaID=Convert.ToInt32(IDTextBox.Text);
            persona.Nombre=NombreTextBox.Text;
            persona.Telefono=TelefonoTextBox.Text;
            persona.Cedula=CedulaTextBox.Text;
            persona.Direccion=DireccionTextBox.Text;
            persona.FechaNacimiento=Convert.ToDateTime(FechaDataPicker.SelectedDate);
            if (string.IsNullOrWhiteSpace(BalanceTextBox.Text))
            {
                BalanceTextBox.Text = "0";
            }
            else persona.Balance = Convert.ToInt32(BalanceTextBox.Text);
            return persona;
        }

        private void LlenaCampos(Personas persona)
        {
            IDTextBox.Text = Convert.ToString(persona.PersonaID);
            NombreTextBox.Text = persona.Nombre;
            TelefonoTextBox.Text = persona.Telefono;
            CedulaTextBox.Text = persona.Cedula;
            DireccionTextBox.Text = persona.Direccion;
            FechaDataPicker.SelectedDate = persona.FechaNacimiento;
            BalanceTextBox.Text = Convert.ToString(persona.Balance);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {

            int id;
            id = Convert.ToInt32(IDTextBox.Text); 

            Limpiar();

            if (PersonasBll.Eliminar(id))
                System.Windows.MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                System.Windows.MessageBox.Show(IDTextBox.Text, "No se puede eliminar una persona que no existe");

        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Personas persona;
            bool paso = false;

            if (!Validar())
                return;

            persona = LlenaClases();

            if (string.IsNullOrWhiteSpace(IDTextBox.Text) || IDTextBox.Text=="0")
                paso = PersonasBll.Guardar(persona);
            else
            {
                if (!ExisteBD())
                {
                    System.Windows.MessageBox.Show("No Se puede Modificar porque no existe", "Fallo",MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = PersonasBll.Modificar(persona);
            }

            if (paso)
            {
                Limpiar();
                System.Windows.MessageBox.Show("Guardado!!", "Exito", MessageBoxButton.OK,MessageBoxImage.Information);
            }
            else
            {
                System.Windows.MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Personas persona = new Personas();
            int.TryParse(IDTextBox.Text, out id);

            Limpiar();

            persona = PersonasBll.Buscar(id);

            if (persona != null)
            {
                System.Windows.MessageBox.Show("Persona Encontrada");
                LlenaCampos(persona);
            }
            else
            {
                System.Windows.MessageBox.Show("Persona no Encontrada");
            }

        }

    

       private bool ExisteBD()
       {
            Personas persona = PersonasBll.Buscar(Convert.ToInt32(IDTextBox.Text));

           return (persona != null);
       }

       private bool Validar()
       {
           bool paso = true;
            

           if (NombreTextBox.Text == string.Empty)
           {
               System.Windows.MessageBox.Show(NombreTextBox.Text, "No puede estar vacio");
               NombreTextBox.Focus();
               paso = false;
           }

           if (string.IsNullOrWhiteSpace(DireccionTextBox.Text))
           {
               System.Windows.MessageBox.Show(DireccionTextBox.Text, "No puede estar vacio");
               DireccionTextBox.Focus();
               paso = false;
           }

           if (string.IsNullOrWhiteSpace(CedulaTextBox.Text))
           {
               System.Windows.MessageBox.Show(CedulaTextBox.Text, "No puede estar vacio");
               CedulaTextBox.Focus();
               paso = false;
           }

           return paso;
       }

       
    }
}
