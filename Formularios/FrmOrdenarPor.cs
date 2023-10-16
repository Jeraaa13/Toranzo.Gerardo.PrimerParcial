using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FrmOrdenarPor : Form
    {
        private bool ascendente;
        private Garaje garaje;

        public Garaje Garaje
        {
            get { return garaje; }
            set { this.garaje = value; }
        }

        public bool Ascendente
        {
            get { return ascendente; }
        }
        public FrmOrdenarPor(Garaje garaje)
        {
            InitializeComponent();

            this.garaje = garaje;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.rbAñoDeFabrica.Checked)
            {
                if (cbAscDesc.SelectedIndex != -1)
                {
                    ascendente = (cbAscDesc.SelectedIndex == 0) ? true : false;
                    garaje.OrdenarPorAñoDeFabricacion(ascendente);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Por favor seleccione una forma de ordenar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (this.rbMarca.Checked)
            {
                if (cbAscDesc.SelectedIndex != -1)
                {
                    ascendente = (cbAscDesc.SelectedIndex == 0) ? true : false;
                    garaje.OrdenarPorMarcaAlfabeticamente(ascendente);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Por favor seleccione una forma de ordenar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione una forma de ordenar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
