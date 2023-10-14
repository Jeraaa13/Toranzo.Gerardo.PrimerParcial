using System;
using System.Text.Json;
using Entidades;

namespace Formularios
{
    public partial class FrmLogin : Form
    {
        private Usuario[] usuarios;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            string path = "C:\\Users\\gerar\\source\\repos\\Toranzo.Gerardo\\Formularios\\MOCK_DATA.json";

            string json;

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    json = reader.ReadToEnd();
                }

                usuarios = JsonSerializer.Deserialize<Usuario[]>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR:" + ex.Message);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            foreach (Usuario usuario in usuarios)
            {
                if (txtCorreo.Text == usuario.correo && txtContraseña.Text == usuario.clave)
                {
                    this.Text = "Bienvenido";
                }
            }
        }
    }
}