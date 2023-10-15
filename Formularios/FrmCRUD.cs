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
    public partial class FrmCRUD : Form
    {
        private FrmLogin login;
        public FrmCRUD(FrmLogin login)
        {
            InitializeComponent();

            this.login = login;
        }

        private void FrmCRUD_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.login.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmTipo frmtipo = new FrmTipo();

            DialogResult resultado = frmtipo.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                this.lstbRead.Items.Add(frmtipo.Auto.ToString());
                this.Text = frmtipo.Auto.Modelo;
            }
        }

        private void FrmCRUD_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Esta seguro que desea cerrar?",
                                    "Advertencia",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning
                                    );

            if (resultado == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
