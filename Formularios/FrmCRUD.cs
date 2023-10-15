using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FrmCRUD : Form
    {
        private FrmLogin login;
        Garaje garaje = new Garaje();
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
                this.lstbRead.Items.Add(frmtipo.Vehiculo.ToString());
                garaje += frmtipo.Vehiculo;
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.lstbRead.SelectedIndex != -1)
            {
                object elementoSeleccionado = lstbRead.SelectedItem;
                lstbRead.Items.Remove(elementoSeleccionado);

                if (elementoSeleccionado is Auto)
                {
                    Auto autoseleccionado = (Auto)elementoSeleccionado;
                    garaje -= autoseleccionado;
                }
                else if (elementoSeleccionado is Moto)
                {
                    Moto motoSeleccionada = (Moto)elementoSeleccionado;
                    garaje -= motoSeleccionada;
                }
                else if (elementoSeleccionado is Camion)
                {
                    Camion camionSeleccionado = (Camion)elementoSeleccionado;
                    garaje -= camionSeleccionado;
                }
                else
                {

                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.lstbRead.SelectedIndex != -1)
            {
                int index = lstbRead.SelectedIndex;

                object objeto = garaje.Vehiculos[index];

                if (objeto is Auto)
                {
                    FrmAuto frmAuto = new FrmAuto((Auto)objeto);

                    DialogResult resultado = frmAuto.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        garaje.Vehiculos[index] = frmAuto.Auto;
                    }
                }
                else if(objeto is Moto)
                {
                    FrmMoto frmmoto = new FrmMoto((Moto)objeto);

                    DialogResult resultado = frmmoto.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        garaje.Vehiculos[index] = frmmoto.Moto;
                    }
                }
                else if(objeto is Camion)
                {
                    FrmCamion frmcamion = new FrmCamion((Camion)objeto);

                    DialogResult resultado = frmcamion.ShowDialog();
                    if(resultado == DialogResult.OK)
                    {
                        garaje.Vehiculos[index] = frmcamion.Camion;
                    }
                }
                ActualizarLstb();
            }
        }

        private void ActualizarLstb()
        {
            this.lstbRead.Items.Clear();

            foreach (Vehiculo v in garaje.Vehiculos)
            {
                this.lstbRead.Items.Add(v.ToString());
            }
        }
    }
}
