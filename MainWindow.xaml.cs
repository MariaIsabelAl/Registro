using System.Windows;
using System.Windows.Controls;
using System;
using Registro.UI.Registros;
using Registro.UI.Consultas;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Registro
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegistroButton_Click(object sender, RoutedEventArgs e)
        {
            rPersonas rp = new rPersonas();
            
            rp.Show();
        }

        private void ConsultaButton_Click(object sender, RoutedEventArgs e)
        {
            Consulta_de_Persona c = new Consulta_de_Persona();
            c.Show();
        }
    }
}
