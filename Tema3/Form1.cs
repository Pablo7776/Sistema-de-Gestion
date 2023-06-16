using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tema3
{
    public partial class Form1 : Form
    {
        private List<Tesla> teslas;

        public Form1()
        {
            InitializeComponent();
            teslas = new List<Tesla>();
        }

        private void button1(object sender, EventArgs e)
        {
            int year = Convert.ToInt32(textBox1.Text);
            int mileage = Convert.ToInt32(textBox2.Text);

            Tesla tesla = new Tesla(year, mileage);
            teslas.Add(tesla);

            MessageBox.Show("Tesla agregado correctamente.");
        }

        //private void btnEliminarTesla_Click(object sender, EventArgs e)
        //{
        //    if (listBox1.SelectedItem != null)
        //    {
        //        Tesla selectedTesla = (Tesla)listBox1.SelectedItem;
        //        teslas.Remove(selectedTesla);
        //        MessageBox.Show("Tesla eliminado correctamente.");
        //    }
        //    else
        //    {
        //        MessageBox.Show("Selecciona un Tesla para eliminar.");
        //    }
        //}

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if (teslas.Count > 0)
            {
                string infoVehiculos = "";
                foreach (Tesla tesla in teslas)
                {
                    infoVehiculos += $"Año: {tesla.Year} - Kilometraje: {tesla.Mileage}\n";
                }
                MessageBox.Show(infoVehiculos);
            }
            else
            {
                MessageBox.Show("No hay Teslas registrados.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //ESTO ES LO QUE NO FUNCIONA!!!!!!!!!!!!!!!!!!!!

            //if (teslas.Count > 0)
            //{
                
                


            //    foreach (Tesla tesla in teslas)
            //    {
            //        tesla.Year = dataGridView1.Rows[e.RowIndex].Cells["Year"].FormattedValue.ToString();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("No hay Teslas registrados.");
            //}
        }
    }

    public class Tesla
    {
        public int Year { get; set; }
        public int Mileage { get; set; }

        public Tesla(int year, int mileage)
        {
            Year = year;
            Mileage = mileage;
        }
    }
}