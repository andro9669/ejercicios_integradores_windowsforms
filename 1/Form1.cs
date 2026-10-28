using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1
{
    public partial class Form1 : Form
    {
        public static Conexion conn = new Conexion();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ListarProductos();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Producto prod = new Producto();
            prod.Guardar(textBox1.Text, textBox2.Text, textBox3.Text);
            ListarProductos();

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
        public void ListarProductos()
        {
            dataGridView1.Rows.Clear();
            Producto prod = new Producto();
            ArrayList datosMemoria = prod.Listar();
            float totalInventario = 0f;
            foreach(Producto p in datosMemoria)
            {
                dataGridView1.Rows.Add(p.Nombre, p.Precio, p.Stock);
                totalInventario += p.CalcularValor();
            }
            label4.Text = "Total inventario: " + totalInventario;
        }
    }
}
