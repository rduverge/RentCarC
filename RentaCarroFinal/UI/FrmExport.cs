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
    public partial class FrmExport : Form
    {
        public FrmExport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WriteExcel();
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

                    fileopener.StartInfo.FileName = @"C:\Program Files\Microsoft Office\root\Office16\excel.exe";
                    fileopener.StartInfo.Arguments = "\"" + "Result.xlsx" + "\"";
                    fileopener.Start();

                }
                else
                {

                }
            }
        }

        private void marcaCombo_SelectionChangeCommitted(object sender, EventArgs e)
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

        private void tipoVehiculoCheck_CheckedChanged(object sender, EventArgs e)
        {
            tipoVehiculoCombo.Enabled = tipoVehiculoCheck.Checked;
        }

        private void marcaCheck_CheckedChanged(object sender, EventArgs e)
        {
            marcaCombo.Enabled = marcaCheck.Checked;
        }

        private void modeloCheck_CheckedChanged(object sender, EventArgs e)
        {
            modeloCombo.Enabled = modeloCheck.Checked;
        }
    }
}
