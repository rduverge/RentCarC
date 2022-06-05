using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RentaCarroFinal.Data;
using RentaCarroFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace RentaCarroFinal.UI
{
    public partial class FrmBuscar : Form
    {
        public FrmBuscar()
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

        private void button1_Click(object sender, EventArgs e)
        {
            using RentaCarroFinalContext db = new RentaCarroFinalContext();
            var query = db.Rentas.Include(x => x.Empleado).Include(x => x.Vehiculo).Include(x => x.Cliente)
                .Where(x => x.FechaRenta >= desdeDate.Value.Date && x.FechaRenta <= hastaDate.Value.Date);
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
            dataGridView1.DataSource = rentas;
        }

        private void clienteCheck_CheckedChanged(object sender, EventArgs e)
        {
            clientesCombo.Enabled = clienteCheck.Checked;
        }

        private void tipoVehiculoCheck_CheckedChanged(object sender, EventArgs e)
        {
            clientesCombo.Enabled = clienteCheck.Checked;
        }

        private void marcaCheck_CheckedChanged(object sender, EventArgs e)
        {
            marcaCombo.Enabled = marcaCheck.Checked;
        }

        private void modeloCheck_CheckedChanged(object sender, EventArgs e)
        {
            modeloCombo.Enabled = modeloCheck.Checked;
        }

        private void marcaCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var m = (Marca)marcaCombo.SelectedItem;
            modeloCombo.DataSource = (new ModeloRepo()).View(m);
            if (modeloCheck.Checked)
            {
                modeloCombo.Enabled = true;
            }
        }
    }

}
