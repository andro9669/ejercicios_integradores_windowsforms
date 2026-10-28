using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1
{
    internal class Producto
    {
        public string Nombre { get; set; }
        public float Precio { get; set; }
        public int Stock { get; set; }

        public float CalcularValor()
        {
            return Precio * (float)Stock;
        }

        public void Guardar(string _nombre, string _precio, string _stock)
        {
            if (string.IsNullOrWhiteSpace(_nombre))
            {
                MessageBox.Show("El nombre no puede ser un campo vacio.");
                return;
            }
            if (!float.TryParse(_precio, out float precio) || precio <= 0)
            {
                MessageBox.Show("El precio debe ser un numero mayor a cero.");
                return;
            }
            if (!int.TryParse(_stock, out int stock) || stock < 0)
            {
                MessageBox.Show("El stock debe ser un numero entero mayor o igual a cero.");
                return;
            }

            string sql = $"INSERT INTO Productos (nombre, precio, stock) VALUES ('{_nombre}', {precio}, {stock})";

            int filasAfectadas = Form1.conn.EjecutarInsert(sql);

            if (filasAfectadas == 0)
                MessageBox.Show("No se ha podido guardar el producto", "Error interno", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
            else
                MessageBox.Show("Producto guardado exitosamente!");
        }

        public ArrayList Listar()
        {
            string sql = "SELECT nombre, precio, stock FROM Productos";
            return Form1.conn.EjecutarSelect(sql);
        }
    }
}
