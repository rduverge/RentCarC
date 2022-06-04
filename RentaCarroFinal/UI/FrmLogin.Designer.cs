namespace RentCar_UI
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.UserBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.PasswordBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.LoginBtn = new MaterialSkin.Controls.MaterialRaisedButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // UserBox
            // 
            this.UserBox.Depth = 0;
            this.UserBox.Hint = "Username";
            this.UserBox.Location = new System.Drawing.Point(362, 136);
            this.UserBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.UserBox.Name = "UserBox";
            this.UserBox.PasswordChar = '\0';
            this.UserBox.SelectedText = "";
            this.UserBox.SelectionLength = 0;
            this.UserBox.SelectionStart = 0;
            this.UserBox.Size = new System.Drawing.Size(185, 23);
            this.UserBox.TabIndex = 4;
            this.UserBox.UseSystemPasswordChar = false;
            // 
            // PasswordBox
            // 
            this.PasswordBox.Depth = 0;
            this.PasswordBox.Hint = "Password";
            this.PasswordBox.Location = new System.Drawing.Point(362, 176);
            this.PasswordBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '\0';
            this.PasswordBox.SelectedText = "";
            this.PasswordBox.SelectionLength = 0;
            this.PasswordBox.SelectionStart = 0;
            this.PasswordBox.Size = new System.Drawing.Size(185, 23);
            this.PasswordBox.TabIndex = 5;
            this.PasswordBox.UseSystemPasswordChar = true;
            // 
            // LoginBtn
            // 
            this.LoginBtn.Depth = 0;
            this.LoginBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LoginBtn.Location = new System.Drawing.Point(0, 271);
            this.LoginBtn.MouseState = MaterialSkin.MouseState.HOVER;
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Primary = true;
            this.LoginBtn.Size = new System.Drawing.Size(591, 33);
            this.LoginBtn.TabIndex = 6;
            this.LoginBtn.Text = "LOGIN";
            this.LoginBtn.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 73);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(309, 176);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 304);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LoginBtn);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.UserBox);
            this.Name = "FrmLogin";
            this.Text = "Login RentCar";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialSingleLineTextField UserBox;
        private MaterialSkin.Controls.MaterialSingleLineTextField PasswordBox;
        private MaterialSkin.Controls.MaterialRaisedButton LoginBtn;
        private PictureBox pictureBox1;
    }
}