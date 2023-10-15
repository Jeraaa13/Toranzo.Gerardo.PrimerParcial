using System;
using System.Security.Policy;
using System.Text.Json;
using Entidades;

namespace Formularios
{
    public partial class FrmLogin : Form
    {
        private Usuario[]? usuarios;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;

            path = Path.Combine(path, "MOCK_DATA.json");

            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string json = reader.ReadToEnd();

                    usuarios = JsonSerializer.Deserialize<Usuario[]>(json);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR:" + ex.Message);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool credencialesValidas = false;

            foreach (Usuario usuario in usuarios)
            {
                if (txtCorreo.Text == usuario.correo && txtContraseña.Text == usuario.clave)
                {
                    credencialesValidas = true;

                    FrmCRUD crud = new FrmCRUD(this);
                    crud.Show();
                    this.Hide();

                    break;
                }
            }

            if (!credencialesValidas)
            {
                MessageBox.Show(
                    "Credenciales invalidas",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                                );
                txtContraseña.Clear();
                txtCorreo.Clear();
            }
        }
    }
}