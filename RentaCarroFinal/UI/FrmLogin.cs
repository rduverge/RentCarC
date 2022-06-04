using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RentaCarroFinal.Models;
using RentaCarroFinal.Data;


namespace RentaCarroFinal.UI
{
    public partial class FrmLogin : MaterialSkin.Controls.MaterialForm
    {
        private Usuario? usuario = null;
        readonly UsuarioRepo usuarioRepo = new UsuarioRepo();
        public FrmLogin()
        {
            InitializeComponent();
            MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Blue900, MaterialSkin.Primary.BlueGrey900, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Accent.Orange700, MaterialSkin.TextShade.WHITE);
        }

        private void LoginBtn_Click_1(object sender, EventArgs e)
        {
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            usuario = db.Usuarios.Where(u => u.Nombre == UserBox.Text.Trim() && u.Password == PasswordBox.Text.Trim()).FirstOrDefault();
            if (usuario == null)
            {
                MessageBox.Show("Usuario incorrecto.");
            }
            else
            {
                Close();
            }
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (usuario == null)
            {
                Application.Exit();
            }
        }
    }
}
