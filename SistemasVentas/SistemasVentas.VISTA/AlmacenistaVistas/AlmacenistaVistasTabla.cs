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

namespace SistemasVentas.VISTA.AlmacenistaVistas
{
    public partial class AlmacenistaVistasTabla : Form
    {
        public AlmacenistaVistasTabla()
        {
            InitializeComponent();
        }
        MarcaBss bssM = new MarcaBss();
        ProveeBss pro = new ProveeBss();
        ProductoBss producto = new ProductoBss();
        DetalleIngBss DetalleIngBss = new DetalleIngBss();

        private void AlmacenistaVistasTabla_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bssM.ListarMarcaBss();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = pro.ListarProveeBss();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = producto.ListarProductoBss();    
        }
    }
}
