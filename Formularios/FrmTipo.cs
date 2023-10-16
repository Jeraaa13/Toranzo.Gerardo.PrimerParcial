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
    public partial class FrmTipo : Form
    {
        private Vehiculo? vehiculo;

        public Vehiculo? Vehiculo
        {
            get { return this.vehiculo; }
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
            DialogResult resultado;
            if(this.rdbAuto.Checked)
            { 
                FrmAuto frmauto = new FrmAuto();
                resultado = frmauto.ShowDialog();
                if(resultado == DialogResult.OK)
                {
                    vehiculo = frmauto.Auto;
                }
                this.Hide();
            }
            else if(this.rdbCamion.Checked)
            {
                FrmCamion frmcamion = new FrmCamion();
                resultado = frmcamion.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    vehiculo = frmcamion.Camion;
                }
                this.Hide();
            }
            else if (this.rdbMoto.Checked)
            {
                FrmMoto frmmoto = new FrmMoto();
                resultado = frmmoto.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    vehiculo = frmmoto.Moto;
                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("Por favor seleccione un vehiculo",
                                        "Advertencia",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning
                                        );
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
