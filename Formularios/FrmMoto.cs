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
    public partial class FrmMoto : FrmVehiculo
    {
        private Entidades.Moto moto;
        public Entidades.Moto Moto
        {
            get { return this.moto; }
            set { this.moto = value; }
        }
        public FrmMoto()
        {
            InitializeComponent();
            Array arrayCombustible = Enum.GetValues(typeof(ETipoCombustible));
            foreach (ETipoCombustible tipoCombustible in arrayCombustible)
            {
                this.cbCombustible.Items.Add(tipoCombustible);
            }
            Array arrayRuedas = Enum.GetValues(typeof(ETipoRuedas));
            foreach (ETipoRuedas ruedas in arrayRuedas)
            {
                this.cbRuedas.Items.Add(ruedas);
            }
        }

        public FrmMoto(Moto moto) : this()
        {
            this.moto = moto;

            this.txtMarca.Text = moto.Marca;
            this.txtModelo.Text = moto.Modelo;
            this.txtAñoFabricacion.Text = moto.AñoFabricacion.ToString();
            this.cbCombustible.Text = moto.TipoCombustible.ToString();
            this.txtCilindrada.Text = moto.Cilindrada.ToString();
            this.cbRuedas.Text = moto.TipoRuedas.ToString();

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

            if (!int.TryParse(this.txtCilindrada.Text, out int cilindrada))
            {
                MessageBox.Show("Ingrese una cilindrada valido por favor.");
                return;
            }

            ETipoRuedas? ruedas = this.cbRuedas.SelectedItem as ETipoRuedas?;
            if (ruedas == null)
            {
                MessageBox.Show("Seleccione un tipo de ruedas por favor.");
                return;
            }

            Moto = new Moto(cilindrada, ruedas.Value, marca, modelo, añoFabricacion, tipoCombustible.Value);
            DialogResult = DialogResult.OK;
        }
    }
}
