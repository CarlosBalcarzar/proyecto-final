using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemasVentas.VISTA.VendedorVistas
{
    public partial class VendedorVistas : Form
    {
        private string nombreUsuario;
        public VendedorVistas(string nombreUsuario)
        {
            InitializeComponent();

            RoundPictureBoxAsCircle(pictureBox1);
            RoundButtonCorners(button1, 30, Corners.LeftTop | Corners.LeftBottom);
            RoundButtonCorners(button3, 30, Corners.RightTop | Corners.RightBottom);
            button1.FlatStyle = FlatStyle.Flat;
            button2.FlatStyle = FlatStyle.Flat;

            button1.FlatAppearance.BorderColor = button1.BackColor;
            button2.FlatAppearance.BorderColor = button2.BackColor;
            this.nombreUsuario = nombreUsuario;
        }
        // Enumeración para identificar las esquinas
        [Flags]
        public enum Corners
        {
            None = 0,
            LeftTop = 1,
            RightTop = 2,
            LeftBottom = 4,
            RightBottom = 8
        }
        private void RoundPictureBoxAsCircle(PictureBox pictureBox)
        {
            int diameter = Math.Min(pictureBox.Width, pictureBox.Height);
            pictureBox.Width = pictureBox.Height = diameter;

            GraphicsPath pictureBoxPath = new GraphicsPath();

            pictureBoxPath.AddEllipse(0, 0, diameter, diameter);

            pictureBox.Region = new Region(pictureBoxPath);
        }

        private void RoundButtonCorners(Button button, int radius, Corners corners)
        {
            GraphicsPath buttonPath = new GraphicsPath();
            Rectangle newRectangle = button.ClientRectangle;

            if ((corners & Corners.LeftTop) == Corners.LeftTop)
                buttonPath.AddArc(newRectangle.X, newRectangle.Y, radius * 2, radius * 2, 180, 90);
            else
                buttonPath.AddLine(newRectangle.Location, new Point(newRectangle.X, newRectangle.Y));

            if ((corners & Corners.RightTop) == Corners.RightTop)
                buttonPath.AddArc(newRectangle.X + newRectangle.Width - radius * 2, newRectangle.Y, radius * 2, radius * 2, 270, 90);
            else
                buttonPath.AddLine(new Point(newRectangle.X + newRectangle.Width, newRectangle.Y), new Point(newRectangle.X + newRectangle.Width, newRectangle.Y));

            if ((corners & Corners.RightBottom) == Corners.RightBottom)
                buttonPath.AddArc(newRectangle.X + newRectangle.Width - radius * 2, newRectangle.Y + newRectangle.Height - radius * 2, radius * 2, radius * 2, 0, 90);
            else
                buttonPath.AddLine(new Point(newRectangle.X + newRectangle.Width, newRectangle.Y + newRectangle.Height), new Point(newRectangle.X + newRectangle.Width, newRectangle.Y + newRectangle.Height));

            if ((corners & Corners.LeftBottom) == Corners.LeftBottom)
                buttonPath.AddArc(newRectangle.X, newRectangle.Y + newRectangle.Height - radius * 2, radius * 2, radius * 2, 90, 90);
            else
                buttonPath.AddLine(new Point(newRectangle.X, newRectangle.Y + newRectangle.Height), new Point(newRectangle.X, newRectangle.Y + newRectangle.Height));

            buttonPath.CloseFigure();

            button.Region = new Region(buttonPath);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            VendedorVistasVender vendedorVistasVender = new VendedorVistasVender();
            vendedorVistasVender.Show();
        }

        private void VendedorVistas_Load(object sender, EventArgs e)
        {
            button1.Text = this.nombreUsuario.ToString();
        }
    }
}
