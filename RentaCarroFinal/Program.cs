using RentaCarroFinal.Data;
using RentaCarroFinal.UI;

namespace RentaCarroFinal
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
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            var u = db.Usuarios.Where(x => x.Nombre == "admin").FirstOrDefault();
            if (u == null)
            {
                u = new Models.Usuario();
                u.Nombre = "admin";
                u.Password = "admin";
                var repo = new UsuarioRepo();
                repo.Create(u);
            }

            ApplicationConfiguration.Initialize();
                Application.Run(new FrmLogin());
        }
    }
}




