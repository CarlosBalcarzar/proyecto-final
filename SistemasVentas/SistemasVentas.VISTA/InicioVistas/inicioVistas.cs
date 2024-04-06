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

namespace SistemasVentas.VISTA.InicioVistas
{
    public partial class inicioVistas : Form
    {
        public inicioVistas()
        {
            InitializeComponent();
            // Llama al método para redondear el PictureBox como un círculo
            RoundPictureBoxAsCircle(pictureBox1);
            // Llama al método para redondear las esquinas del button1
            RoundButtonCorners(button1, 30, Corners.LeftTop | Corners.LeftBottom);
            // Llama al método para redondear las esquinas del button2
            RoundButtonCorners(button2, 30, Corners.RightTop | Corners.RightBottom);
            // Establecer la apariencia de los botones
            button1.FlatStyle = FlatStyle.Flat;
            button2.FlatStyle = FlatStyle.Flat;

            // Establecer el color del borde al mismo que el color de fondo de los botones
            button1.FlatAppearance.BorderColor = button1.BackColor;
            button2.FlatAppearance.BorderColor = button2.BackColor;
        }
        private void RoundPictureBoxAsCircle(PictureBox pictureBox)
        {
            // Establece la misma altura y anchura para el PictureBox para formar un círculo
            int diameter = Math.Min(pictureBox.Width, pictureBox.Height);
            pictureBox.Width = pictureBox.Height = diameter;

            // Crea un gráfico para el PictureBox
            GraphicsPath pictureBoxPath = new GraphicsPath();

            // Crea un círculo que ocupe todo el PictureBox
            pictureBoxPath.AddEllipse(0, 0, diameter, diameter);

            // Aplica la forma de círculo al PictureBox
            pictureBox.Region = new Region(pictureBoxPath);
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

        // Método para redondear las esquinas de un botón
        private void RoundButtonCorners(Button button, int radius, Corners corners)
        {
            // Crea un gráfico para el botón
            GraphicsPath buttonPath = new GraphicsPath();
            Rectangle newRectangle = button.ClientRectangle;

            // Redondea las esquinas especificadas del botón
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

            // Aplica la forma redondeada al botón
            button.Region = new Region(buttonPath);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Crear una instancia del formulario de inicio de sesión
            IniciarSeccionVistas.IniciarSeccionVistas formInicioSesion = new IniciarSeccionVistas.IniciarSeccionVistas();

            // Mostrar el formulario de inicio de sesión
            formInicioSesion.Show();
        }
    }
}
