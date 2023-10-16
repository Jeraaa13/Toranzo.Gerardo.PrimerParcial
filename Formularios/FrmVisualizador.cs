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
    public partial class FrmVisualizador : Form
    {
        public FrmVisualizador(string logPath)
        {
            InitializeComponent();

            if (File.Exists(logPath))
            {
                string[] archivo = File.ReadAllLines(logPath);
                this.lbVisualizador.Items.AddRange(archivo);
            }
            else
            {
                lbVisualizador.Items.Add("El archivo de registo no existe.");
            }
        }
    }
}
