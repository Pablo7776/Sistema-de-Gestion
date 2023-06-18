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
            string modelo = comboBox1.Text;
            int year = Convert.ToInt32(textBox1.Text);
            int mileage = Convert.ToInt32(textBox2.Text);
            string color = textBox3.Text;
            string dueño = textBox4.Text;

            Tesla tesla = new Tesla(modelo, year, mileage, color, dueño);
            teslas.Add(tesla);

            // Actualizar el contenido del DataGridView
            ActualizarDataGridView();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

            MessageBox.Show("Tesla agregado correctamente.");


        }

        private void ActualizarDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = teslas;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            //// Configurar las columnas del DataGridView
            //dataGridView1.AutoGenerateColumns = false;
            //dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            //{
            //    DataPropertyName = "Modelo",
            //    HeaderText = "Modelo"
            //});
            //dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            //{
            //    DataPropertyName = "Year",
            //    HeaderText = "Year"
            //});
            //dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            //{
            //    DataPropertyName = "Mileage",
            //    HeaderText = "Mileage"
            //});
        }
    }

    public class Tesla
    {
        public string Modelo { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string Color { get; set; }
        public string Dueño { get; set; }

        public Tesla(string modelo, int year, int mileage, string color,string dueño )
        {
            Modelo = modelo;
            Year = year;
            Mileage = mileage;
            Color = color;
            Dueño = dueño;
        }
    }
}