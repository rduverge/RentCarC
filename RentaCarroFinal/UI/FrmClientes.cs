using System;
using RentaCarroFinal.Models;
using RentaCarroFinal.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using RJCodeAdvance.RJControls;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentaCarroFinal.UI
{
    public partial class FrmClientes : Form
    {
        readonly Cliente cliente = new Cliente();
        readonly ClienteRepo clienteRepository = new ClienteRepo();
        List<string> errores = new List<string>();

        public FrmTiposCombustibles FrmTiposCombustibles;
            public FrmMarca FrmMarca;
            public FrmModelo FrmModelo;

        //Constructor
        public FrmClientes()
            {
                InitializeComponent();
                CollapseMenu();
                this.Padding = new Padding(borderSize);//Border size
                this.BackColor = Color.FromArgb(98, 102, 244);//Border color
            }

            //Fields
            private int borderSize = 2;
        private Size formSize;


        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //Overridden methods
        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;//Standar Title Bar - Snap Window
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MINIMIZE = 0xF020; //Minimize form (Before)
            const int SC_RESTORE = 0xF120; //Restore form (Before)
            const int WM_NCHITTEST = 0x0084;//Win32, Mouse Input Notification: Determine what part of the window corresponds to a point, allows to resize the form.
            const int resizeAreaSize = 10;
            #region Form Resize
            // Resize/WM_NCHITTEST values
            const int HTCLIENT = 1; //Represents the client area of the window
            const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
            const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
            const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
            const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
            const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
            const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
            const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
            const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right
            ///<Doc> More Information: https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest </Doc>
            if (m.Msg == WM_NCHITTEST)
            { //If the windows m is WM_NCHITTEST
                base.WndProc(ref m);
                if (this.WindowState == FormWindowState.Normal)//Resize the form if it is in normal state
                {
                    if ((int)m.Result == HTCLIENT)//If the result of the m (mouse pointer) is in the client area of the window
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
                        Point clientPoint = this.PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          
                        if (clientPoint.Y <= resizeAreaSize)//If the pointer is at the top of the form (within the resize area- X coordinate)
                        {
                            if (clientPoint.X <= resizeAreaSize) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
                                m.Result = (IntPtr)HTTOPLEFT; //Resize diagonally to the left
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
                                m.Result = (IntPtr)HTTOP; //Resize vertically up
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize horizontally to the left
                                m.Result = (IntPtr)HTLEFT;
                            else if (clientPoint.X > (this.Width - resizeAreaSize))//Resize horizontally to the right
                                m.Result = (IntPtr)HTRIGHT;
                        }
                        else
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize diagonally to the left
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) //Resize vertically down
                                m.Result = (IntPtr)HTBOTTOM;
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                    }
                }
                return;
            }
            #endregion
            //Remove border and keep snap window
            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }
            //Keep form size when it is minimized and restored. Since the form is resized because it takes into account the size of the title bar and borders.
            if (m.Msg == WM_SYSCOMMAND)
            {
                /// <see cref="https://docs.microsoft.com/en-us/windows/win32/menurc/wm-syscommand"/>
                /// Quote:
                /// In WM_SYSCOMMAND messages, the four low - order bits of the wParam parameter 
                /// are used internally by the system.To obtain the correct result when testing 
                /// the value of wParam, an application must combine the value 0xFFF0 with the 
                /// wParam value by using the bitwise AND operator.
                int wParam = (m.WParam.ToInt32() & 0xFFF0);
                if (wParam == SC_MINIMIZE)  //Before
                    formSize = this.ClientSize;
                if (wParam == SC_RESTORE)// Restored form(Before)
                    this.Size = formSize;
            }
            base.WndProc(ref m);
        }
        //Private methods
        private void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized: //Maximized form (After)
                    this.Padding = new Padding(8, 8, 8, 0);
                    break;
                case FormWindowState.Normal: //Restored form (After)
                    if (this.Padding.Top != borderSize)
                        this.Padding = new Padding(borderSize);
                    break;
            }
        }
        private void CollapseMenu()
        {
            if (this.panelMenu.Width > 200) //Collapse menu
            {
                panelMenu.Width = 100;
                pictureBox1.Visible = false;
                btnMenu.Dock = DockStyle.Top;
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "";
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(0);
                }
            }
            else
            { //Expand menu
                panelMenu.Width = 230;
                pictureBox1.Visible = true;
                btnMenu.Dock = DockStyle.None;
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "   " + menuButton.Tag.ToString();
                    menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                    menuButton.Padding = new Padding(10, 0, 0, 0);
                }
            }
        }
        //Event methods
        private void FrmMenuModern_Resize(object sender, EventArgs e)
        {
            AdjustForm();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                formSize = this.ClientSize;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.Size = formSize;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void rjDropdownMenu2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void Open_DropdownMenu (RJDropdownMenu dropdownMenu, object sender)
        {
            Control control = (Control)sender;
            dropdownMenu.VisibleChanged += new EventHandler((sender2, ev)
              => DropdownMenu_VisibleChanged(sender2, ev, control));
            dropdownMenu.Show(control, control.Width, 0);
        }
        
        private void DropdownMenu_VisibleChanged(object sender, EventArgs e, Control ctrl)
        {
            RJDropdownMenu dropdownMenu2 = (RJDropdownMenu)sender;
            if (!DesignMode)
            {
                if (dropdownMenu2.Visible)
                    ctrl.BackColor = Color.FromArgb(159, 161, 224);
                else ctrl.BackColor = Color.FromArgb(98, 102, 244);
            }
        }
            

        private void iconButton2_Click(object sender, EventArgs e)
        {
            Open_DropdownMenu(rjDropdownMenu2, sender);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            Open_DropdownMenu(rjDropdownMenu1, sender);
        }

        private void iconButton10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tiposDeCombustibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FrmTiposCombustibles == null || FrmTiposCombustibles.IsDisposed)
            {
                FrmTiposCombustibles = new FrmTiposCombustibles();
                FrmTiposCombustibles.Show();
            }
            else
            {
                FrmTiposCombustibles.Show();
                FrmTiposCombustibles.Focus();
            }
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FrmMarca == null || FrmMarca.IsDisposed)
            {
                FrmMarca = new FrmMarca();
                FrmMarca.Show();
            }
            else
            {
                FrmMarca.Show();
                FrmMarca.Focus();
            }
        }

        private void modelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FrmModelo == null || FrmModelo.IsDisposed)
            {
                FrmModelo = new FrmModelo();
                FrmModelo.LoadData();
                FrmModelo.Show();
            }
            else
            {
                FrmModelo.LoadData();
                FrmModelo.Show();
                FrmModelo.Focus();
            }
        }

        private Cliente GetCliente()
        {

            cliente.Nombre = nombreText.Text.Trim();
            cliente.Cedula = cedulaText.Text.Replace("-", "").Trim();
            cliente.NumeroTarjetaCredito = tarjetaText.Text.Trim();
            cliente.LimiteCredito = Convert.ToDouble(limiteCreditoText.Value);

            cliente.TipoPersona = tipoPersonaCombo.Text;
            cliente.Estado = estadoCheck.Checked;
            return cliente;
        }
        private void Clear()
        {
            nombreText.Text = "";
            cedulaText.Text = "";
            tarjetaText.Text = "";
            limiteCreditoText.Value = 0;

            estadoCheck.Checked = false;
        }

        public void LoadData()
        {
            dataGridView1.DataSource = clienteRepository.View();


            dataGridView1.ClearSelection();
        }


        private void guardarBtn_Click(object sender, EventArgs e)
        {
            cliente.Id = null;
            clienteRepository.Create(GetCliente());
            LoadData();
            Clear();
        }

            private void actualizarBtn_Click(object sender, EventArgs e)
        {
            clienteRepository.Update(GetCliente());
            LoadData();
            Clear();
        }

        private void borrarBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var m = GetCliente();
                if (m != null)
                {
                    clienteRepository.Delete(m);
                    LoadData();
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            

        }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cliente.Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            cliente.Nombre = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            cliente.Cedula = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            cliente.NumeroTarjetaCredito = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            cliente.LimiteCredito = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());



            // cbbTipoPersona.Text=cliente.TipoPersona;

            cliente.Estado = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[6].Value.ToString());
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            borrarBtn.Enabled = dataGridView1.SelectedRows.Count > 0;
        }
        public Cliente FillCliente()
        {
            cliente.Nombre = nombreText.Text.Trim();
            cliente.Cedula = cedulaText.Text.Replace("-", "").Trim();
            cliente.NumeroTarjetaCredito = tarjetaText.Text.Trim();
            cliente.LimiteCredito = Convert.ToDouble(limiteCreditoText.Value);
            cliente.TipoPersona = tipoPersonaCombo.Text;
            cliente.Estado = estadoCheck.Checked;
            return cliente;
        }

        public void FillForm()
        {
            nombreText.Text = cliente.Nombre;
            cedulaText.Text = cliente.Cedula;
            tarjetaText.Text = cliente.NumeroTarjetaCredito;
            limiteCreditoText.Value = Convert.ToDecimal(cliente.LimiteCredito);
            tipoPersonaCombo.Text = cliente.TipoPersona;
            estadoCheck.Checked = cliente.Estado;
        }


        public bool Validar()
        {
            errores.Clear();
            if (string.IsNullOrWhiteSpace(nombreText.Text))
            {
                errores.Add("Nombre no puede estar en blanco");
            }
            if (string.IsNullOrWhiteSpace(cedulaText.Text))
            {
                errores.Add("Cedula no puede estar en blanco");
            }
            if (string.IsNullOrWhiteSpace(tarjetaText.Text))
            {
                errores.Add("Tarjet de credito no puede estar en blanco");
            }
            if (limiteCreditoText.Value < 0)
            {
                errores.Add("Limite de credito no puede ser menor a 0");
            }
            if (string.IsNullOrWhiteSpace(tipoPersonaCombo.Text))
            {
                errores.Add("Tipo de persona no puede estar en blanco");
            }
            if (tipoPersonaCombo.Text == "Fisica")
            {
                if (!validaCedula(cedulaText.Text.Replace("-", "").Trim()))
                {
                    errores.Add("Cedula no valida");
                }

            }
            else if (tipoPersonaCombo.Text == "Juridica")
            {
                if (!esUnRNCValido(cedulaText.Text.Trim()))
                {
                    errores.Add("RNC no valido");
                }
            }
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            if (db.Empleados.Where(x => x.Nombre == nombreText.Text.Trim()).Any())
            {
                errores.Add("Ya existe un cliente con este nombre");
            }
            if (db.Empleados.Where(x => x.Cedula == cedulaText.Text.Replace("-", "").Trim()).Any())
            {
                errores.Add("Ya existe un cliente con esta cedula.");
            }
            if (errores.Count > 0)
            {
                var message = "";
                foreach (var e in errores)
                {
                    message += e + "\n";
                }
                MessageBox.Show(message);
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool validaCedula(string pCedula)

        {
            int vnTotal = 0;
            string vcCedula = pCedula.Replace("-", "");
            int pLongCed = vcCedula.Trim().Length;
            int[] digitoMult = new int[11] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 };

            if (pLongCed < 11 || pLongCed > 11)
                return false;

            for (int vDig = 1; vDig <= pLongCed; vDig++)
            {
                int vCalculo = Int32.Parse(vcCedula.Substring(vDig - 1, 1)) * digitoMult[vDig - 1];
                if (vCalculo < 10)
                    vnTotal += vCalculo;
                else
                    vnTotal += Int32.Parse(vCalculo.ToString().Substring(0, 1)) + Int32.Parse(vCalculo.ToString().Substring(1, 1));
            }

            if (vnTotal % 10 == 0)
                return true;
            else
                return false;
        }
        private bool esUnRNCValido(string pRNC)

        {

            int vnTotal = 0;

            int[] digitoMult = new int[8] { 7, 9, 8, 6, 5, 4, 3, 2 };

            string vcRNC = pRNC.Replace("-", "").Replace(" ", "");

            string vDigito = vcRNC.Substring(8, 1);

            if (vcRNC.Length.Equals(9))

                if (!"145".Contains(vcRNC.Substring(0, 1)))

                    return false;

            for (int vDig = 1; vDig <= 8; vDig++)

            {

                int vCalculo = Int32.Parse(vcRNC.Substring(vDig - 1, 1)) * digitoMult[vDig - 1];

                vnTotal += vCalculo;

            }

            if (vnTotal % 11 == 0 && vDigito == "1" || vnTotal % 11 == 1 && vDigito == "1" ||

                (11 - (vnTotal % 11)).Equals(vDigito))

                return true;

            else

                return false;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cliente.Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            cliente.Nombre = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            cliente.Cedula = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            cliente.NumeroTarjetaCredito = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            cliente.LimiteCredito = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());
            // cbbTipoPersona.Text=cliente.TipoPersona;

            cliente.Estado = Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[6].Value.ToString());

        }
    }
}
