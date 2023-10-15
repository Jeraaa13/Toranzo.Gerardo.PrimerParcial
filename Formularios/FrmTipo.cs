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
        private Entidades.Vehiculo vehiculo;
        private string eleccion;

        public string Eleccion
        {
            get { return this.eleccion; }
        }
        public Entidades.Vehiculo Vehiculo
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
            if(this.rdbAuto.Checked)
            { 
                FrmAuto frmauto = new FrmAuto();
                DialogResult resultado = frmauto.ShowDialog();
                if(resultado == DialogResult.OK)
                {
                    eleccion = "Auto";
                    vehiculo = frmauto.Auto;
                    this.DialogResult = DialogResult.OK;
                }
                this.Hide();
            }
            else if(this.rdbCamion.Checked)
            {
                FrmCamion frmcamion = new FrmCamion();
                DialogResult resultado = frmcamion.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    eleccion = "Camion";
                    vehiculo = frmcamion.Camion;
                    this.DialogResult = DialogResult.OK;
                }
                this.Hide();
            }
            else if (this.rdbMoto.Checked)
            {
                FrmMoto frmmoto = new FrmMoto();
                DialogResult resultado = frmmoto.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    eleccion = "Moto";
                    vehiculo = frmmoto.Moto;
                    this.DialogResult = DialogResult.OK;
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
        }
    }
}
