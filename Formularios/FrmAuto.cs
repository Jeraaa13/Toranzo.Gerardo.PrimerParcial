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

    public partial class FrmAuto : FrmVehiculo
    {
        private Entidades.Auto auto;
        public Entidades.Auto Auto
        {
            get { return this.auto; }
            set { this.auto = value; }
        }
        public FrmAuto()
        {
            InitializeComponent();
            Array arrayCombustible = Enum.GetValues(typeof(ETipoCombustible));
            foreach (ETipoCombustible tipoCombustible in arrayCombustible)
            {
                this.cbCombustible.Items.Add(tipoCombustible);
            }
            Array arrayTraccion = Enum.GetValues(typeof(ETraccion));
            foreach (ETraccion traccion in arrayTraccion)
            {
                this.cbTraccion.Items.Add(traccion);
            }
        }

        public FrmAuto(Auto auto): this()
        {
            this.auto = auto;

            marca = auto.Marca;
            modelo = auto.Modelo;
            añoFabricacion = auto.AñoFabricacion;
            tipoCombustible = auto.TipoCombustible;

            this.txtMarca.Text = auto.Marca;
            this.txtModelo.Text = auto.Modelo;
            this.txtAñoFabricacion.Text = auto.AñoFabricacion.ToString();
            this.cbCombustible.Text = auto.TipoCombustible.ToString();
            this.txtNumPuertas.Text = auto.NumeroPuertas.ToString();
            this.cbTraccion.Text = auto.Traccion.ToString();
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

            if (!int.TryParse(this.txtNumPuertas.Text, out int numeroPuertas))
            {
                MessageBox.Show("Ingrese un numero de puertas valido por favor.",
                                        "Advertencia",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                return;
            }

            if (this.cbTraccion.SelectedItem is ETraccion traccion)
            {
                marca = txtMarca.Text;
                modelo = txtModelo.Text;
                añoFabricacion = int.Parse(txtAñoFabricacion.Text);
                tipoCombustible = (ETipoCombustible)cbCombustible.SelectedItem;

                auto = new Auto(numeroPuertas, traccion, marca, modelo, añoFabricacion, tipoCombustible);

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
