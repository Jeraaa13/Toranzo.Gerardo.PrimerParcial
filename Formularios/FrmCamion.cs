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
        private Entidades.Camion camion;
        public Entidades.Camion Camion
        {
            get { return this.camion; }
            set { this.camion = value; }
        }
        public FrmCamion()
        {
            InitializeComponent();
            Array arrayCombustible = Enum.GetValues(typeof(ETipoCombustible));
            foreach (ETipoCombustible tipoCombustible in arrayCombustible)
            {
                this.cbCombustible.Items.Add(tipoCombustible);
            }
        }

        public FrmCamion(Camion camion) : this()
        {
            this.camion = camion;

            this.txtMarca.Text = camion.Marca;
            this.txtModelo.Text = camion.Modelo;
            this.txtAñoFabricacion.Text = camion.AñoFabricacion.ToString();
            this.cbCombustible.Text = camion.TipoCombustible.ToString();
            this.txtCargaMaxima.Text = camion.CargaMaxima.ToString();
            this.txtNumEjes.Text = camion.NumeroEjes.ToString();
        }

        private new void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string marca = this.txtMarca.Text;
            string modelo = this.txtModelo.Text;

            if (string.IsNullOrWhiteSpace(marca))
            {
                MessageBox.Show("Ingrese una marca valida por favor.");
                return;
            }

            if (string.IsNullOrWhiteSpace(modelo))
            {
                MessageBox.Show("Ingrese un modelo valido por favor.");
                return;
            }

            if (!int.TryParse(this.txtAñoFabricacion.Text, out int añoFabricacion))
            {
                MessageBox.Show("Ingrese un año de fabricacion valido por favor.");
                return;
            }

            ETipoCombustible? tipoCombustible = this.cbCombustible.SelectedItem as ETipoCombustible?;
            if (tipoCombustible == null)
            {
                MessageBox.Show("Seleccione un tipo de combustible por favor.");
                return;
            }

            if (!double.TryParse(this.txtCargaMaxima.Text, out double cargaMaxima))
            {
                MessageBox.Show("Ingrese una carga maxima valida por favor.");
            }

            if (!int.TryParse(this.txtCargaMaxima.Text, out int numeroEjes))
            {
                MessageBox.Show("Ingrese un numero de ejes valido por favor.");
            }

            camion = new Camion(cargaMaxima, numeroEjes, marca, modelo, añoFabricacion, tipoCombustible.Value);
            DialogResult = DialogResult.OK;
        }
    }
}
