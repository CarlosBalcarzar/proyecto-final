using SistemasVentas.BSS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemasVentas.VISTA.GerenteVistas
{
    public partial class GerenteVistastabla : Form
    {
        public GerenteVistastabla()
        {
            InitializeComponent();
        }
        private enum FuenteDatos
        {
            Cliente,
            DetalleIngreso,
            DetalleVenta,
            Ingreso,
            Marca,
            Persona,
            Producto,
            Provee,
            proveedor,
            Rol,
            TipoProd,
            UsuarioRol,
            Usuario,
            Venta,
        }
        ClienteBss clienteBss = new ClienteBss();
        DetalleIngBss DetalleIngBss = new DetalleIngBss();
        DetalleVentaBss DetalleVentaBss = new DetalleVentaBss();
        IngresoBss IngresoBss = new IngresoBss();
        MarcaBss MarcaBss = new MarcaBss();
        PersonaBss PersonaBss = new PersonaBss();
        ProductoBss ProductoBss = new ProductoBss();
        ProveeBss ProveeBss = new ProveeBss();
        ProveedorBss proveedorBss = new ProveedorBss();
        RolBss rolBss = new RolBss();
        TipoProdBss tipoProdBss = new TipoProdBss();
        UsuarioRolBss usuarioRolBss = new UsuarioRolBss();
        UsuarioBss usuarioBss = new UsuarioBss();
        VentaBss VentaBss = new VentaBss();
        private FuenteDatos fuenteActual = FuenteDatos.Cliente;
        private void GerenteVistastabla_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
        private void CargarDatos()
        {
            switch (fuenteActual)
            {
                case FuenteDatos.Cliente:
                    dataGridView1.DataSource = clienteBss.ListarClienteBss();
                    break;
                case FuenteDatos.DetalleIngreso:
                    dataGridView1.DataSource = DetalleIngBss.ListarDetalleIngBss();
                    break;
                case FuenteDatos.DetalleVenta:
                    dataGridView1.DataSource = DetalleVentaBss.ListarDetalleVentaBss();
                    break;
                case FuenteDatos.Ingreso:
                    dataGridView1.DataSource = IngresoBss.ListarIngresoBss();
                    break;
                case FuenteDatos.Marca:
                    dataGridView1.DataSource = MarcaBss.ListarMarcaBss();
                    break;
                case FuenteDatos.Persona:
                    dataGridView1.DataSource = PersonaBss.ListarPersonaBss();
                    break;
                case FuenteDatos.Producto:
                    dataGridView1.DataSource = ProductoBss.ListarProductoBss();
                    break;
                case FuenteDatos.Provee:
                    dataGridView1.DataSource = ProveeBss.ListarProveeBss();
                    break;
                case FuenteDatos.proveedor:
                    dataGridView1.DataSource = proveedorBss.ListarProveedorBss();
                    break;
                case FuenteDatos.Rol:
                    dataGridView1.DataSource = rolBss.ListarRolBss();
                    break;
                case FuenteDatos.TipoProd:
                    dataGridView1.DataSource = tipoProdBss.ListarTipoProdBss();
                    break;
                case FuenteDatos.UsuarioRol:
                    dataGridView1.DataSource = usuarioRolBss.ListarUsuarioRolBss();
                    break;
                case FuenteDatos.Usuario:
                    dataGridView1.DataSource = usuarioBss.ListarUsuarioBss();
                    break;
                case FuenteDatos.Venta:
                    dataGridView1.DataSource = VentaBss.ListarVentaBss();
                    break;
                default:
                    break;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CambiarFuenteDatosSiguiente();
            CargarDatos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CambiarFuenteDatosAnterior();
            CargarDatos();
        }

        private void CambiarFuenteDatosSiguiente()
        {
            // Cambiar a la siguiente fuente de datos
            fuenteActual++;
            if ((int)fuenteActual > Enum.GetValues(typeof(FuenteDatos)).Length - 1)
            {
                fuenteActual = 0;
            }
        }

        private void CambiarFuenteDatosAnterior()
        {
            // Cambiar a la fuente de datos anterior
            fuenteActual--;
            if ((int)fuenteActual < 0)
            {
                fuenteActual = (FuenteDatos)(Enum.GetValues(typeof(FuenteDatos)).Length - 1);
            }
        }
    }
}
