using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Tema3
{
    public partial class Form1 : Form
    {
        private List<Producto> teslas;

        public Form1()
        {
            InitializeComponent();
            teslas = new List<Producto>();
        }



        private void button1(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Modelo X")
            {

                TeslaModelX tesla = new TeslaModelX { Modelo = comboBox1.Text, Año = Convert.ToInt32(textBox1.Text), UnidadDeUso = Convert.ToInt32(textBox2.Text), Color=textBox3.Text,Dueño=textBox4.Text, CargaRestante = 0 };
                tesla.ObtenerValor(); // muestra la carga restante (no solo del teslaX, tambien del tesla S y del cybertruck)
                _=tesla.Autonomia;    // muestra la autonomia (no solo del teslaX, tambien del tesla S y del cybertruck)
                teslas.Add(tesla);    // agrega el tesla a la lista "teslas"
            }
            else if(comboBox1.Text == "Modelo S")
            {
                TeslaModelS tesla = new TeslaModelS { Modelo = comboBox1.Text, Año = Convert.ToInt32(textBox1.Text), UnidadDeUso = Convert.ToInt32(textBox2.Text), Color = textBox3.Text, Dueño = textBox4.Text, CargaRestante = 0 };
                teslas.Add(tesla);
            }

            else
            {
                Cybertruck tesla = new Cybertruck { Modelo = comboBox1.Text, Año = Convert.ToInt32(textBox1.Text), UnidadDeUso = Convert.ToInt32(textBox2.Text), Color = textBox3.Text, Dueño = textBox4.Text, CargaRestante = 0 };
                teslas.Add(tesla);

            }
            

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

        private void btnEliminarTesla_Click(object sender, EventArgs e)
        {
            if (teslas.Count > 0)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int rowIndex = dataGridView1.SelectedRows[0].Index;
                    if (rowIndex != -1)
                    {
                        teslas.RemoveAt(rowIndex);
                        ActualizarDataGridView();
                        MessageBox.Show("Tesla eliminado correctamente.");
                    }
                }
                else
                {
                    MessageBox.Show("Selecciona un Tesla para eliminar.");
                }
            }
            else
            {
                MessageBox.Show("ahun no hay sestlas.");
            }
        }



        private void btnMostrar_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.SelectedRows[0].Index;
            {
                MessageBox.Show($"un tesla {teslas[rowIndex].Color} con una autonomia de {teslas[rowIndex].Autonomia}");
            }
        }

        private void btnMayorKms(object sender, EventArgs e)
        {

            {
                MessageBox.Show($"Funcionalidad en construcción");
            }
        }


        //private void btnMostrar_Click(object sender, EventArgs e)
        //{
        //    if (teslas.Count > 0)
        //    {
        //        string infoVehiculos = "";
        //        foreach (Tesla tesla in teslas)
        //        {
        //            infoVehiculos += $"Año: {tesla.Year} - Kilometraje: {tesla.Mileage}\n";


        //        }


        //        MessageBox.Show(infoVehiculos);

        //    }
        //    else
        //    {
        //        MessageBox.Show("No hay Teslas registrados.");
        //    }
        //}

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

    public abstract class Producto
    {
        public string Modelo { get; set; }
        public int Año { get; set; }
        public int UnidadDeUso { get; set; }
        public string Color { get; set; }
        public string Dueño { get; set; }
        public int Autonomia { get; set; }
        public int Service { get; set; }


        public  double CargaRestante
        {
            get
            {
                int modulo = UnidadDeUso % Autonomia;
                if (modulo == 0)
                    return 100;
                return Math.Round((double)modulo / Autonomia * 100, 2);

            }
            set
            {

            }
        }

    }
    /// <summary>
    /// //////////////////////////////////////////////////////////////////////////////
    /// </summary>
    public class TeslaModelX : Producto
    {
        public  TeslaModelX()
        {
            Autonomia = 560;
            //Service = 1000;
        }
        //public int Asientos { get; set; } = 7;

        public double ObtenerValor()
        {
            return CargaRestante;
        }

    }

    public class TeslaModelS : Producto
    {
        public TeslaModelS()
        {
            Autonomia = 650;
            //Service = 2000;
        }

        //public int Asientos { get; set; } = 5;

        public double ObtenerValor()
        {
            return CargaRestante;
        }

    }

    public class Cybertruck : Producto
    {
        public Cybertruck()
        {
            Autonomia = 800;
            //Service = 3000;
        }

        //public int Asientos { get; set; } = 6;

        public double ObtenerValor()
        {
            return CargaRestante;
        }

    }

}


