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
    public partial class FrmTipo : Form
    {
        private Entidades.Auto auto;
        private string eleccion;

        public string Eleccion
        {
            get { return this.eleccion; }
        }
        public Entidades.Auto Auto
        {
            get { return this.auto; }
        }
        public FrmTipo()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(this.rdbAuto.Checked)
            { 
                FrmAuto frmauto = new FrmAuto();
                DialogResult resultado = frmauto.ShowDialog();
                if(resultado == DialogResult.OK)
                {
                    eleccion = "Auto";
                    auto = frmauto.Auto;
                    this.DialogResult = DialogResult.OK;
                }
                this.Hide();
            }
            else if(this.rdbCamion.Checked)
            {

            }
            else if (this.rdbMoto.Checked)
            {

            }
            else
            {
                MessageBox.Show("Por favor seleccione un vehiculo",
                                        "Advertencia",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning
                                        );
            }
        }
    }
}
