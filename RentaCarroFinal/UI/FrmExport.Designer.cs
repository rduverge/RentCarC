﻿namespace RentaCarroFinal.UI
{
    partial class FrmExport
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.clienteCheck = new System.Windows.Forms.CheckBox();
            this.clientesCombo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tipoVehiculoCheck = new System.Windows.Forms.CheckBox();
            this.tipoVehiculoCombo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.marcaCheck = new System.Windows.Forms.CheckBox();
            this.marcaCombo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.modeloCheck = new System.Windows.Forms.CheckBox();
            this.modeloCombo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.desdeDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.hastaDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(94, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 50;
            this.button1.Text = "Exportar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 35;
            this.label1.Text = "Cliente";
            // 
            // clienteCheck
            // 
            this.clienteCheck.AutoSize = true;
            this.clienteCheck.Location = new System.Drawing.Point(13, 31);
            this.clienteCheck.Name = "clienteCheck";
            this.clienteCheck.Size = new System.Drawing.Size(60, 19);
            this.clienteCheck.TabIndex = 40;
            this.clienteCheck.Text = "Activo";
            this.clienteCheck.UseVisualStyleBackColor = true;
            this.clienteCheck.CheckedChanged += new System.EventHandler(this.clienteCheck_CheckedChanged);
            // 
            // clientesCombo
            // 
            this.clientesCombo.FormattingEnabled = true;
            this.clientesCombo.Location = new System.Drawing.Point(13, 56);
            this.clientesCombo.Name = "clientesCombo";
            this.clientesCombo.Size = new System.Drawing.Size(121, 23);
            this.clientesCombo.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(140, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 15);
            this.label4.TabIndex = 41;
            this.label4.Text = "Tipo Vehiculo";
            // 
            // tipoVehiculoCheck
            // 
            this.tipoVehiculoCheck.AutoSize = true;
            this.tipoVehiculoCheck.Location = new System.Drawing.Point(140, 31);
            this.tipoVehiculoCheck.Name = "tipoVehiculoCheck";
            this.tipoVehiculoCheck.Size = new System.Drawing.Size(60, 19);
            this.tipoVehiculoCheck.TabIndex = 47;
            this.tipoVehiculoCheck.Text = "Activo";
            this.tipoVehiculoCheck.UseVisualStyleBackColor = true;
            this.tipoVehiculoCheck.CheckedChanged += new System.EventHandler(this.tipoVehiculoCheck_CheckedChanged);
            // 
            // tipoVehiculoCombo
            // 
            this.tipoVehiculoCombo.FormattingEnabled = true;
            this.tipoVehiculoCombo.Location = new System.Drawing.Point(140, 56);
            this.tipoVehiculoCombo.Name = "tipoVehiculoCombo";
            this.tipoVehiculoCombo.Size = new System.Drawing.Size(121, 23);
            this.tipoVehiculoCombo.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(13, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 15);
            this.label5.TabIndex = 43;
            this.label5.Text = "Marca";
            // 
            // marcaCheck
            // 
            this.marcaCheck.AutoSize = true;
            this.marcaCheck.Location = new System.Drawing.Point(13, 103);
            this.marcaCheck.Name = "marcaCheck";
            this.marcaCheck.Size = new System.Drawing.Size(60, 19);
            this.marcaCheck.TabIndex = 48;
            this.marcaCheck.Text = "Activo";
            this.marcaCheck.UseVisualStyleBackColor = true;
            this.marcaCheck.CheckedChanged += new System.EventHandler(this.marcaCheck_CheckedChanged);
            // 
            // marcaCombo
            // 
            this.marcaCombo.FormattingEnabled = true;
            this.marcaCombo.Location = new System.Drawing.Point(13, 128);
            this.marcaCombo.Name = "marcaCombo";
            this.marcaCombo.Size = new System.Drawing.Size(121, 23);
            this.marcaCombo.TabIndex = 45;
            this.marcaCombo.SelectionChangeCommitted += new System.EventHandler(this.marcaCombo_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(140, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 15);
            this.label6.TabIndex = 44;
            this.label6.Text = "Modelo";
            // 
            // modeloCheck
            // 
            this.modeloCheck.AutoSize = true;
            this.modeloCheck.Location = new System.Drawing.Point(140, 103);
            this.modeloCheck.Name = "modeloCheck";
            this.modeloCheck.Size = new System.Drawing.Size(60, 19);
            this.modeloCheck.TabIndex = 49;
            this.modeloCheck.Text = "Activo";
            this.modeloCheck.UseVisualStyleBackColor = true;
            this.modeloCheck.CheckedChanged += new System.EventHandler(this.modeloCheck_CheckedChanged);
            // 
            // modeloCombo
            // 
            this.modeloCombo.FormattingEnabled = true;
            this.modeloCombo.Location = new System.Drawing.Point(140, 128);
            this.modeloCombo.Name = "modeloCombo";
            this.modeloCombo.Size = new System.Drawing.Size(121, 23);
            this.modeloCombo.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(13, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 36;
            this.label2.Text = "Desde";
            // 
            // desdeDate
            // 
            this.desdeDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.desdeDate.Location = new System.Drawing.Point(13, 177);
            this.desdeDate.Name = "desdeDate";
            this.desdeDate.Size = new System.Drawing.Size(248, 23);
            this.desdeDate.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(13, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 37;
            this.label3.Text = "Hasta";
            // 
            // hastaDate
            // 
            this.hastaDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.hastaDate.Location = new System.Drawing.Point(13, 221);
            this.hastaDate.Name = "hastaDate";
            this.hastaDate.Size = new System.Drawing.Size(248, 23);
            this.hastaDate.TabIndex = 39;
            // 
            // FrmExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(276, 286);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clienteCheck);
            this.Controls.Add(this.clientesCombo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tipoVehiculoCheck);
            this.Controls.Add(this.tipoVehiculoCombo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.marcaCheck);
            this.Controls.Add(this.marcaCombo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.modeloCheck);
            this.Controls.Add(this.modeloCombo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.desdeDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hastaDate);
            this.Name = "FrmExport";
            this.Text = "FrmExport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private Label label1;
        private CheckBox clienteCheck;
        private ComboBox clientesCombo;
        private Label label4;
        private CheckBox tipoVehiculoCheck;
        private ComboBox tipoVehiculoCombo;
        private Label label5;
        private CheckBox marcaCheck;
        private ComboBox marcaCombo;
        private Label label6;
        private CheckBox modeloCheck;
        private ComboBox modeloCombo;
        private Label label2;
        private DateTimePicker desdeDate;
        private Label label3;
        private DateTimePicker hastaDate;
    }
}