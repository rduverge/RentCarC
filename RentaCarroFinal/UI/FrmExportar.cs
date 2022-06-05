using RentaCarroFinal.Data;
using RentaCarroFinal.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentaCarroFinal.UI
{
    public partial class ReportesForm : Form
    {
        public ReportesForm()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            clientesCombo.DataSource = (new ClienteRepo()).View();
            tipoVehiculoCombo.DataSource = (new TipoVehiculoRepo()).View();
            marcaCombo.DataSource = (new MarcaRepo()).View();
            modeloCombo.Enabled = false;
            clientesCombo.Enabled = false;
            tipoVehiculoCombo.Enabled = false;
            marcaCombo.Enabled = false;
            clienteCheck.Checked = false;
            tipoVehiculoCheck.Checked = false;
            marcaCheck.Checked = false;
            modeloCheck.Checked = false;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            WriteExcel();
        }
        private void WriteExcel()
        {
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            var query = db.Rentas.Include(x => x.Empleado).Include(x => x.Vehiculo).Include(x => x.Cliente)
                .Where(x => x.FechaRenta >= desdeDate.Value && x.FechaRenta <= hastaDate.Value);
            if (clienteCheck.Checked)
            {
                query = query.Where(x => x.ClienteId == ((Cliente)clientesCombo.SelectedItem).Id);
            }
            if (tipoVehiculoCheck.Checked)
            {
                query = query.Where(x => x.Vehiculo.TipoVehiculoId == ((TipoVehiculo)tipoVehiculoCombo.SelectedItem).Id);
            }
            if (marcaCheck.Checked)
            {
                query = query.Where(x => x.Vehiculo.MarcaId == ((Marca)marcaCombo.SelectedItem).Id);
            }
            if (modeloCheck.Checked)
            {
                query = query.Where(x => x.Vehiculo.ModeloId == ((Modelo)modeloCombo.SelectedItem).Id);

            }
            var rentas = query.ToList();
            DataTable table = (DataTable)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(rentas), (typeof(DataTable)));
            var memoryStream = new MemoryStream();

            using (var fs = new FileStream("Result.xlsx", FileMode.Create, FileAccess.Write))
            {
                IWorkbook workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet("Sheet1");

                List<String> columns = new List<string>();
                IRow row = excelSheet.CreateRow(0);
                int columnIndex = 0;

                foreach (System.Data.DataColumn column in table.Columns)
                {
                    columns.Add(column.ColumnName);
                    row.CreateCell(columnIndex).SetCellValue(column.ColumnName);
                    columnIndex++;
                }

                int rowIndex = 1;
                foreach (DataRow dsrow in table.Rows)
                {
                    row = excelSheet.CreateRow(rowIndex);
                    int cellIndex = 0;
                    foreach (String col in columns)
                    {
                        row.CreateCell(cellIndex).SetCellValue(dsrow[col].ToString());
                        cellIndex++;
                    }

                    rowIndex++;
                }
                workbook.Write(fs);
                FileInfo fi = new FileInfo("Result.xlsx");
                if (fi.Exists)
                {
                    using Process fileopener = new Process();

                    fileopener.StartInfo.FileName = @"C:\Program Files (x86)\Microsoft Office\root\Office16\excel.exe";
                    fileopener.StartInfo.Arguments = "\"" + "Result.xlsx" + "\"";
                    fileopener.Start();

                }
                else
                {
                    //file doesn't exist
                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

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
        private Button button1;

        private void InitializeComponent()
        {
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
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(22, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "Cliente";
            // 
            // clienteCheck
            // 
            this.clienteCheck.AutoSize = true;
            this.clienteCheck.Location = new System.Drawing.Point(22, 26);
            this.clienteCheck.Name = "clienteCheck";
            this.clienteCheck.Size = new System.Drawing.Size(60, 19);
            this.clienteCheck.TabIndex = 23;
            this.clienteCheck.Text = "Activo";
            this.clienteCheck.UseVisualStyleBackColor = true;
            this.clienteCheck.CheckedChanged += new System.EventHandler(this.clienteCheck_CheckedChanged);
            // 
            // clientesCombo
            // 
            this.clientesCombo.FormattingEnabled = true;
            this.clientesCombo.Location = new System.Drawing.Point(22, 51);
            this.clientesCombo.Name = "clientesCombo";
            this.clientesCombo.Size = new System.Drawing.Size(121, 23);
            this.clientesCombo.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(149, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 15);
            this.label4.TabIndex = 24;
            this.label4.Text = "Tipo Vehiculo";
            // 
            // tipoVehiculoCheck
            // 
            this.tipoVehiculoCheck.AutoSize = true;
            this.tipoVehiculoCheck.Location = new System.Drawing.Point(149, 26);
            this.tipoVehiculoCheck.Name = "tipoVehiculoCheck";
            this.tipoVehiculoCheck.Size = new System.Drawing.Size(60, 19);
            this.tipoVehiculoCheck.TabIndex = 30;
            this.tipoVehiculoCheck.Text = "Activo";
            this.tipoVehiculoCheck.UseVisualStyleBackColor = true;
            this.tipoVehiculoCheck.CheckedChanged += new System.EventHandler(this.tipoVehiculoCheck_CheckedChanged_1);
            // 
            // tipoVehiculoCombo
            // 
            this.tipoVehiculoCombo.FormattingEnabled = true;
            this.tipoVehiculoCombo.Location = new System.Drawing.Point(149, 51);
            this.tipoVehiculoCombo.Name = "tipoVehiculoCombo";
            this.tipoVehiculoCombo.Size = new System.Drawing.Size(121, 23);
            this.tipoVehiculoCombo.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(22, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 15);
            this.label5.TabIndex = 26;
            this.label5.Text = "Marca";
            // 
            // marcaCheck
            // 
            this.marcaCheck.AutoSize = true;
            this.marcaCheck.Location = new System.Drawing.Point(22, 98);
            this.marcaCheck.Name = "marcaCheck";
            this.marcaCheck.Size = new System.Drawing.Size(60, 19);
            this.marcaCheck.TabIndex = 31;
            this.marcaCheck.Text = "Activo";
            this.marcaCheck.UseVisualStyleBackColor = true;
            this.marcaCheck.CheckedChanged += new System.EventHandler(this.marcaCheck_CheckedChanged_1);
            // 
            // marcaCombo
            // 
            this.marcaCombo.FormattingEnabled = true;
            this.marcaCombo.Location = new System.Drawing.Point(22, 123);
            this.marcaCombo.Name = "marcaCombo";
            this.marcaCombo.Size = new System.Drawing.Size(121, 23);
            this.marcaCombo.TabIndex = 28;
            this.marcaCombo.SelectionChangeCommitted += new System.EventHandler(this.marcaCombo_SelectionChangeCommitted_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(149, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 15);
            this.label6.TabIndex = 27;
            this.label6.Text = "Modelo";
            // 
            // modeloCheck
            // 
            this.modeloCheck.AutoSize = true;
            this.modeloCheck.Location = new System.Drawing.Point(149, 98);
            this.modeloCheck.Name = "modeloCheck";
            this.modeloCheck.Size = new System.Drawing.Size(60, 19);
            this.modeloCheck.TabIndex = 32;
            this.modeloCheck.Text = "Activo";
            this.modeloCheck.UseVisualStyleBackColor = true;
            this.modeloCheck.CheckedChanged += new System.EventHandler(this.modeloCheck_CheckedChanged);
            // 
            // modeloCombo
            // 
            this.modeloCombo.FormattingEnabled = true;
            this.modeloCombo.Location = new System.Drawing.Point(149, 123);
            this.modeloCombo.Name = "modeloCombo";
            this.modeloCombo.Size = new System.Drawing.Size(121, 23);
            this.modeloCombo.TabIndex = 29;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(22, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "Desde";
            // 
            // desdeDate
            // 
            this.desdeDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.desdeDate.Location = new System.Drawing.Point(22, 172);
            this.desdeDate.Name = "desdeDate";
            this.desdeDate.Size = new System.Drawing.Size(248, 23);
            this.desdeDate.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(22, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "Hasta";
            // 
            // hastaDate
            // 
            this.hastaDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.hastaDate.Location = new System.Drawing.Point(22, 216);
            this.hastaDate.Name = "hastaDate";
            this.hastaDate.Size = new System.Drawing.Size(248, 23);
            this.hastaDate.TabIndex = 22;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(103, 245);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 33;
            this.button1.Text = "Exportar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // ReportesForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(296, 273);
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
            this.Name = "ReportesForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void marcaCombo_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            var m = (Marca)marcaCombo.SelectedItem;
            modeloCombo.DataSource = (new ModeloRepo()).View(m);
            if (modeloCheck.Checked)
            {
                modeloCombo.Enabled = true;
            }
        }

        private void clienteCheck_CheckedChanged(object sender, EventArgs e)
        {
            clientesCombo.Enabled = clienteCheck.Checked;
        }

        private void tipoVehiculoCheck_CheckedChanged_1(object sender, EventArgs e)
        {
            tipoVehiculoCombo.Enabled = tipoVehiculoCheck.Checked;
        }

        private void marcaCheck_CheckedChanged_1(object sender, EventArgs e)
        {
            marcaCombo.Enabled = marcaCheck.Checked;
        }

        private void modeloCheck_CheckedChanged(object sender, EventArgs e)
        {
            
                modeloCombo.Enabled = modeloCheck.Checked;
            }
    }
}
