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
using Registro.Entidades;
using Registro.BLL;
using System.Data;
using System.Linq;


namespace Registro.UI.Consultas
{
    
    public partial class Consulta_de_Persona : Window
    {
        public Consulta_de_Persona()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CriterioTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        /*private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Personas>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch(FiltroComboBox.SelectedIndex)
                {
                    case 0://todo
                        listado = PersonasBll.GetList(p => true);
                        break;
                    case 1://ID
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = PersonasBll.GetList(p => p.PersonaID == id);
                        break;
                    case 2://Nombre
                        listado = PersonasBll.GetList(p => p.Nombre.contains(CriterioTextBox.Text));
                        break;
                    case 3://Cedula
                        listado = PersonasBll.GetList(p => p.Cedula.contains(CriterioTextBox.Text));
                        break;
                    case 4://Direccion
                        listado = PersonasBll.GetList(p => p.Direccion.contains(CriterioTextBox.Text));
                        break;


                }
               
            }
            else
            {
                listado = PersonasBll.GetList(p => true);
            }

            ConsultaDataGrip.DataSource = null;
            ConsultaDataGrip.DataSource = listado;

        }*/
    }
}
