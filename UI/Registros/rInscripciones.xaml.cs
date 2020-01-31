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
using Registro.BLL;
using Registro.Entidades;
using Registro.UI.Registros;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;

namespace Registro.UI.Registros
{
    public partial class rInscripciones : Window
    {
        public rInscripciones()
        {
            InitializeComponent();
        }

        private void LimpiarInscripcion()
        {
            InscripcionIdTextBox.Text = string.Empty;
            PersonaIdTextBox.Text = string.Empty;
            ComentariosTextBox.Text = string.Empty;
            MontoTextBox.Text = string.Empty;
            DepositoTextBox.Text = string.Empty;
            BalanceTextBox.Text = string.Empty;
            FechaInsDatePicker.Text = Convert.ToString(DateTime.Now);
        }

        private Inscripciones LlenaClaseInscripcion()
        {
            decimal monto, deposito, balance;
            deposito = Convert.ToDecimal(DepositoTextBox.Text);
            monto = Convert.ToDecimal(MontoTextBox.Text);
            balance = monto - deposito;

            Inscripciones inscripciones = new Inscripciones();
            if (string.IsNullOrWhiteSpace(InscripcionIdTextBox.Text))
            {
                InscripcionIdTextBox.Text = "0";
            }
            else inscripciones.InscripcionId = Convert.ToInt32(InscripcionIdTextBox.Text);
            inscripciones.Fecha = Convert.ToDateTime(FechaInsDatePicker.SelectedDate);
            if (string.IsNullOrWhiteSpace(PersonaIdTextBox.Text))
            {
                PersonaIdTextBox.Text = "0";
            }
            else inscripciones.PersonaId= Convert.ToInt32(PersonaIdTextBox.Text);
            inscripciones.Comentarios = ComentariosTextBox.Text;
            inscripciones.Deposito = Convert.ToDecimal(DepositoTextBox.Text);
            inscripciones.Monto = balance;
            inscripciones.Balance = balance;
            return inscripciones;
        }

        private void LlenarCamposInscripcion(Inscripciones inscripciones)
        {
            InscripcionIdTextBox.Text = Convert.ToString(inscripciones.InscripcionId);
            FechaInsDatePicker.SelectedDate = inscripciones.Fecha;
            PersonaIdTextBox.Text = Convert.ToString(inscripciones.PersonaId);
            ComentariosTextBox.Text = inscripciones.Comentarios;
            DepositoTextBox.Text = Convert.ToString(inscripciones.Deposito);
            MontoTextBox.Text = Convert.ToString(inscripciones.Monto);
            BalanceTextBox.Text = Convert.ToString(inscripciones.Balance);
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            LimpiarInscripcion();
        }

        private bool ValidarInscripcion()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(ComentariosTextBox.Text))
            {
                System.Windows.MessageBox.Show(ComentariosTextBox.Text, "No puede estar vacio");
                ComentariosTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(DepositoTextBox.Text))
            {
                System.Windows.MessageBox.Show(DepositoTextBox.Text, "No puede estar vacio");
                DepositoTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(MontoTextBox.Text))
            {
                System.Windows.MessageBox.Show(MontoTextBox.Text, "No puede estar vacio");
                MontoTextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private bool ExisteBDPersona()
        {
            Personas persona = PersonasBll.Buscar(Convert.ToInt32(PersonaIdTextBox.Text));

            return (persona != null);
        }

        private bool ExisteBDInscripcion()
        {
            Inscripciones inscripciones = InscripcionesBll.Buscar(Convert.ToInt32(InscripcionIdTextBox.Text));
            return (inscripciones != null);
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Inscripciones inscripciones;
            bool paso = false;

            if (!ValidarInscripcion())
                return;

            inscripciones = LlenaClaseInscripcion();


            if (InscripcionIdTextBox.Text == "0" && ExisteBDPersona() == true)

            {
                paso = InscripcionesBll.GuardarInscripcion(inscripciones);
            }
            else
            {

                if (!ExisteBDInscripcion())
                {
                    System.Windows.MessageBox.Show("No se puede modificar porque no existe en la base de datos Inscripción o Estudiante",
                          "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                paso = InscripcionesBll.ModificarInscripcion(inscripciones);
            }

            if (paso)
            {
                LimpiarInscripcion();
                System.Windows.MessageBox.Show("Guardado!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                System.Windows.MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Inscripciones inscripciones = new Inscripciones();
            int.TryParse(InscripcionIdTextBox.Text, out id);

            LimpiarInscripcion();

            inscripciones = InscripcionesBll.Buscar(id);

            if (inscripciones != null)
            {
                System.Windows.MessageBox.Show("Inscripción Encontrada");
                LlenarCamposInscripcion(inscripciones);
            }
            else
            {
                System.Windows.MessageBox.Show("Inscripción no Encontrada");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            id = Convert.ToInt32(InscripcionIdTextBox.Text);
            int personaId = Convert.ToInt32(PersonaIdTextBox.Text);

            LimpiarInscripcion();

            if (InscripcionesBll.EliminarInscripcion(id, personaId))
                System.Windows.MessageBox.Show("Balance de Inscripción Eliminado", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                System.Windows.MessageBox.Show("No se puede eliminar, porque no existe.");
        }
    }
}
