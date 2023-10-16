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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Formularios
{
    public partial class FrmMoto : FrmVehiculo
    {
        private Moto moto;
        public Moto Moto
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

            marca = moto.Marca;
            modelo = moto.Modelo;
            añoFabricacion = moto.AñoFabricacion;
            tipoCombustible = moto.TipoCombustible;

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
            if(!ValidarDatos())
            {
                return;
            }

            if (!int.TryParse(this.txtCilindrada.Text, out int cilindrada))
            {
                MessageBox.Show("Ingrese una cilindrada válida por favor.",
                                        "Advertencia",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                return;
            }

            if (this.cbRuedas.SelectedItem is ETipoRuedas ruedas)
            {
                marca = txtMarca.Text;
                modelo = txtModelo.Text;
                añoFabricacion = int.Parse(txtAñoFabricacion.Text);
                tipoCombustible = (ETipoCombustible)cbCombustible.SelectedItem;


                moto = new Moto(cilindrada, ruedas, marca, modelo, añoFabricacion, tipoCombustible);

                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Seleccione una tracción por favor.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }
    }

}
