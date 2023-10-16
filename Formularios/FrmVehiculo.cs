using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FrmVehiculo : Form
    {
        protected string? marca;
        protected string? modelo;
        protected int añoFabricacion;
        protected ETipoCombustible tipoCombustible;

        public FrmVehiculo()
        {
            InitializeComponent();
            Array arrayCombustible = Enum.GetValues(typeof(ETipoCombustible));
            foreach (ETipoCombustible tipoCombustible in arrayCombustible)
            {
                this.cbCombustible.Items.Add(tipoCombustible);
            }
        }

        protected bool ValidarDatos()
        {
            marca = txtMarca.Text;
            modelo = txtModelo.Text;


            if (string.IsNullOrWhiteSpace(marca))
            {
                MessageBox.Show("Ingrese una marca válido por favor.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if(string.IsNullOrWhiteSpace(modelo))
            {
                MessageBox.Show("Ingrese una modelo válido por favor.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtAñoFabricacion.Text, out añoFabricacion))
            {
                MessageBox.Show("Ingrese un año de fabricación válido por favor.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }

            if (this.cbCombustible.SelectedItem is not ETipoCombustible tipoCombustible)
            {
                MessageBox.Show("Seleccione un tipo de combustible por favor.",
                                "Advertencia",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
