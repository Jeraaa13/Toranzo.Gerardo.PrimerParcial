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

        private new void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string marca =  this.txtMarca.Text;
            string modelo = this.txtModelo.Text;
            int añoFabricacion = int.Parse(this.txtAñoFabricacion.Text); // exception
            ETipoCombustible tipoCombustible = (ETipoCombustible)cbCombustible.SelectedItem;
            int numeroPuertas = int.Parse(this.txtNumPuertas.Text);
            ETraccion traccion = (ETraccion)this.cbCombustible.SelectedItem;

            auto = new Auto(numeroPuertas, traccion, marca, modelo, añoFabricacion, tipoCombustible);
            DialogResult = DialogResult.OK;
        }
    }
}
