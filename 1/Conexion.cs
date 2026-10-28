using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1
{
    public class Conexion
    {
        SqlConnection conn;
        string connString = "Data Source=DESKTOP-K9SG051\\SQLEXPRESS;Database=Wf_sqlsever_1;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\"";

        public void Conectar()
        {
            try
            {
                if (conn == null)
                    conn = new SqlConnection(connString);

                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                    MessageBox.Show("Conexion exitosa");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mensaje de error: " + ex.Message);
            }
        }

        public int EjecutarInsert(string sql)
        {
            Conectar();
            SqlCommand cmd = new SqlCommand(sql, conn);
            int filasAfectadas = cmd.ExecuteNonQuery();
            conn.Close();
            return filasAfectadas;
        }

        public ArrayList EjecutarSelect(string sql)
        {
            Conectar();
            ArrayList datosMemoria = new ArrayList();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                Producto prod = new Producto();
                prod.Nombre = r["nombre"].ToString();
                prod.Precio = float.Parse(r["precio"].ToString());
                prod.Stock = Convert.ToInt32(r["stock"]);
                datosMemoria.Add(prod);
            }
            return datosMemoria;
        }
    }
}
