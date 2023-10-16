using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Newtonsoft.Json;

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

            ArchivarDatos();
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            if (lstbRead.Items.Count > 1)
            {
                FrmOrdenarPor frmOrdenar = new FrmOrdenarPor(garaje);

                DialogResult resultado = frmOrdenar.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    this.garaje = frmOrdenar.Garaje;
                    ActualizarLstb();
                }
            }
            else
            {
                MessageBox.Show("Hay menos de dos objetos", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
        }

        private void ArchivarDatos()
        {
            string logPath = "usuarios.log";
            using (StreamWriter sw = File.AppendText(logPath))
            {
                string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - Usuario: {usuario.nombre} {usuario.apellido} accedió a la aplicación";
                sw.WriteLine(logEntry);
            }
        }

        private void btnVisualizador_Click(object sender, EventArgs e)
        {
            string logPath = "usuarios.log";
            FrmVisualizador frmVisualizador = new FrmVisualizador(logPath);

            frmVisualizador.Show();
        }

        private void btnSerializar_Click(object sender, EventArgs e)
        {
            ArchivarColeccion();
        }

        private void btnDeserializar_Click(object sender, EventArgs e)
        {
            CargarColeccion();
        }

        private void ArchivarColeccion()
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Archivos JSON|*.json";
            fileDialog.Title = "Guardar la colección";
            try
            {
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    JsonSerializerSettings settings = new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All,
                        Formatting = Formatting.Indented
                    };

                    string json = JsonConvert.SerializeObject(garaje, settings);

                    string rutaArchivo = fileDialog.FileName;

                    File.WriteAllText(rutaArchivo, json);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error al guardar los datos a JSON", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarColeccion()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Archivos JSON|*.json";
            fileDialog.Title = "Cargar la colección";

            try
            {
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaArchivo = fileDialog.FileName;

                    JsonSerializerSettings settings = new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    };

                    string json = File.ReadAllText(rutaArchivo);
                    garaje = JsonConvert.DeserializeObject<Garaje>(json, settings);

                    ActualizarLstb(); // Asegúrate de actualizar tu lista después de la deserialización
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los datos desde JSON", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}