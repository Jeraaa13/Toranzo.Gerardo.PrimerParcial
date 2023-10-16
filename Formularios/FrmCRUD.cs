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
        private Usuario usuario;
        private FrmLogin login;
        Garaje garaje = new Garaje();
        public FrmCRUD(FrmLogin login, Usuario usuario)
        {
            InitializeComponent();

            this.login = login;
            this.usuario = usuario;
        }

        private void FrmCRUD_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.login.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmTipo frmtipo = new FrmTipo();

            DialogResult resultado = frmtipo.ShowDialog();
            if (resultado == DialogResult.OK && frmtipo.Vehiculo != null)
            {
                garaje += frmtipo.Vehiculo;
            }
            ActualizarLstb();
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
                int index = lstbRead.SelectedIndex;
                garaje -= garaje.Vehiculos[index];
            }
            ActualizarLstb();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.lstbRead.SelectedIndex != -1)
            {
                int index = lstbRead.SelectedIndex;
                object objeto = garaje.Vehiculos[index];

                DialogResult resultado;
                if (objeto is Auto)
                {
                    FrmAuto frmAuto = new FrmAuto((Auto)objeto);

                    resultado = frmAuto.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        garaje.Vehiculos[index] = frmAuto.Auto;
                    }
                }
                else if (objeto is Moto)
                {
                    FrmMoto frmMoto = new FrmMoto((Moto)objeto);

                    resultado = frmMoto.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        garaje.Vehiculos[index] = frmMoto.Moto;

                    }
                }
                else if (objeto is Camion)
                {
                    FrmCamion frmCamion = new FrmCamion((Camion)objeto);

                    resultado = frmCamion.ShowDialog();
                    if (resultado == DialogResult.OK)
                    {
                        garaje.Vehiculos[index] = frmCamion.Camion;
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

        private void FrmCRUD_Load(object sender, EventArgs e)
        {
            this.lblUsuario.Text = "Logueado como: " + usuario.nombre + " " + usuario.apellido;
            this.lblFecha.Text = "Hoy es: " + DateTime.Now.ToShortDateString();
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            FrmOrdenarPor frmOrdenar = new FrmOrdenarPor(garaje);

            DialogResult resultado = frmOrdenar.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                this.garaje = frmOrdenar.Garaje;
                ActualizarLstb();
            }
            
        }

        private void ArchivarDatos()
        {

        }


    }
}
