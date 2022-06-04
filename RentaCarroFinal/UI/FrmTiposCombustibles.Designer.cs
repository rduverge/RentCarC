namespace RentaCarroFinal.UI
{
    partial class FrmTiposCombustibles
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "FrmTiposCombustibles";
        }

        #endregion
        private DataGridView CombustiblesGrid;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox descripcionText;
        private CheckBox estadoCheck;
        private TableLayoutPanel tableLayoutPanel3;
        private Button guardarBtn;
        private Button actualizarBtn;
        private Button otroBtn;
        private Button borrarBtn;
        private PictureBox pictureBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
    }
}