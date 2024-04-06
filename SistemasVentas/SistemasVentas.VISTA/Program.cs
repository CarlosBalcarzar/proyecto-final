

using SistemasVentas.VISTA.InicioVistas;

namespace SistemasVentas.VISTA
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new DetalleIngVistas.DetalleIngListarVista());
            //Application.Run(new UsuarioVistas.UsuarioListarVista());
            Application.Run(new IniciarSeccionVistas.IniciarSeccionVistas());
            //Application.Run(new GerenteVistas.GerenteVistastabla());
           
        }
    }
}