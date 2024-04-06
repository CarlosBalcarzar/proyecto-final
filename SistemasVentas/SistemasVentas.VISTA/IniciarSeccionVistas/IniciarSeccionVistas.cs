using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemasVentas.VISTA.IniciarSeccionVistas
{
    public partial class IniciarSeccionVistas : Form
    {
        private string connectionString = "Data Source=LAPTOP-4KUDAUHD\\SQLEXPRESS;Initial Catalog=TIENDA_VENTAS_BD;Integrated Security=True; TrustServerCertificate=true;";

        public IniciarSeccionVistas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombreUser = textBox1.Text;
            string contraseña = textBox2.Text;

            string rol = ObtenerRol(nombreUser, contraseña);

            if (rol != null)
            {
                if (rol == "Gerente") 
                {
                    GerenteVistas.GerenteVistas GerenteVistas = new GerenteVistas.GerenteVistas(nombreUser);
                    GerenteVistas.Show();
                }
                if (rol == "Vendedor")
                {
                    VendedorVistas.VendedorVistas vendedorVistas = new VendedorVistas.VendedorVistas(nombreUser);
                    vendedorVistas.Show();
                }
                if (rol == "Guia")
                {
                    AlmacenistaVistas.AlmacenistasVistas almacenistasVistas = new AlmacenistaVistas.AlmacenistasVistas(nombreUser);
                    almacenistasVistas.Show();
                }
            }
            else
            {
                MessageBox.Show("Nombre de usuario o contraseña incorrectos.");
            }
        }

        private string ObtenerRol(string nombreUser, string contraseña)
        {
            string rol = null;

            string query = "SELECT r.Nombre FROM usuario u " +
                           "INNER JOIN usuariorol ur ON u.IdUsuario = ur.IdUsuario " +
                           "INNER JOIN rol r ON ur.IdRol = r.IdRol " +
                           "WHERE u.NombreUser = @NombreUser AND u.Contraseña = @Contraseña";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NombreUser", nombreUser);
                command.Parameters.AddWithValue("@Contraseña", contraseña);

                try
                {
                    connection.Open();
                    rol = (string)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al intentar conectar a la base de datos: " + ex.Message);
                }
            }

            return rol;
        }
    }

}

