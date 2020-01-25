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
            FechaDataPicker.SelectedDate = DateTime.Now;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private Personas LlenaClases()
        {
            Personas p = new Personas();
            p.PersonaID=Convert.ToInt32(Console.ReadLine());
            p.Nombre=NombreTextBox.Text;
            p.Telefono=TelefonoTextBox.Text;
            p.Cedula=CedulaTextBox.Text;
            p.Direccion=DireccionTextBox.Text;
            p.FechaNacimiento=FechaDataPicker.DisplayDate;

            return p;
        }

        private void LlenaCampos(Personas p)
        {
            IDTextBox.Text = p.PersonaID;
            NombreTextBox.Text = p.Nombre;
            TelefonoTextBox.Text = p.Telefono;
            CedulaTextBox.Text = p.Cedula;
            DireccionTextBox.Text = p.Direccion;
            FechaDataPicker.SelectedDate = p.FechaNacimiento;
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            MyErrorProvider.Clear();

            int id;
            int.TryParse(IDTextBox.Text, out id);

            Limpiar();

            if (PersonasBll.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK, MessageBoxIcon.Information);
            else
                MyErrorProvider.SetError(IDTextBox, "No se puede eliminar una persona que no existe");

        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Personas p;
            bool paso = false;

            if (!Validar())
                return;

            p = LlenaClases();

            if (IDTextBox.Text == "0")
                paso = PersonasBll.Guardar(p);
            else
            {
                if (!ExisteBD())
                {
                   MessageBox.Show("No Se puede Modificar poerque no existe", "Fallo",MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                paso = PersonasBll.Modificar(p);
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButton.OK,MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Personas p = new Personas();
            int.TryParse(IDTextbox.text, out id);

            Limpiar();

            p = PersonasBll.Buscar(id);

            if (p != null)
            {
                MessageBox.Show("Persona Encontrada");
                LlenaCampos(p);
            }
            else
            {
                MessageBox.Show("Persona no Encontrada");
            }

        }

    

       private bool ExisteBD()
       {
           Personas p = PersonasBll.Buscar((int)IDTextBox.Text);

           return (p != null);
       }

       private bool Validar()
       {
           bool paso = true;
           MyErrorProvider.Clear();

           if (NombreTextBox.Text == string.Empty)
           {
               MyErrorProvider.SetError(NombreTextBox, "No puede estar vacio");
               NombreTextBox.Focus();
               paso = false;
           }

           if (string.IsNullOrWhiteSpace(DireccionTextBox.Text))
           {
               MyErrorProvider.SetError(DireccionTextBox, "No puede estar vacio");
               DireccionTextBox.Focus();
               paso = false;
           }

           if (string.IsNullOrWhiteSpace(CedulaTextBox.Text))
           {
               MyErrorProvider.SetError(CedulaTextBox, "No puede estar vacio");
               CedulaTextBox.Focus();
               paso = false;
           }

           return paso;
       }

        private void NombreTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TelefonoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DireccionTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void IDTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

    }
}
