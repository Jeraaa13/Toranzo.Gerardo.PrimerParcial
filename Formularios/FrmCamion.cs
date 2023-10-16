using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Formularios
{
    public partial class FrmCamion : FrmVehiculo
    {
        private Camion camion;
        public Camion Camion
        {
            get { return this.camion; }
            set { this.camion = value; }
        }
        public FrmCamion()
        {
            InitializeComponent();

            camion = new Camion();
        }

        public FrmCamion(Camion camion) : this()
        {
            this.txtMarca.Text = camion.Marca;
            this.txtModelo.Text = camion.Modelo;
            this.txtAñoFabricacion.Text = camion.AñoFabricacion.ToString();
            this.cbCombustible.Text = camion.TipoCombustible.ToString();
            this.txtCargaMaxima.Text = camion.CargaMaxima.ToString();
            this.txtNumEjes.Text = camion.NumeroEjes.ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                return;
            }

            if (!double.TryParse(this.txtCargaMaxima.Text, out double cargaMaxima))
            {
                MessageBox.Show("Ingrese una carga maxima valida por favor.",
                                        "Advertencia",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(this.txtNumEjes.Text, out int numeroEjes))
            {
                MessageBox.Show("Ingrese un numero de ejes valido por favor.",
                                        "Advertencia",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                return;
            }

            marca = txtMarca.Text;
            modelo = txtModelo.Text;
            añoFabricacion = int.Parse(txtAñoFabricacion.Text);
            tipoCombustible = (ETipoCombustible)cbCombustible.SelectedItem;


            camion = new Camion(cargaMaxima, numeroEjes, marca, modelo, añoFabricacion, tipoCombustible);

            DialogResult = DialogResult.OK;
        }
    }
}
