using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDesktop
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private Usuarios usuarios = null;
        public Form1()
        {
            InitializeComponent();
        }

        public Form1(Usuarios users)
        {
            InitializeComponent();

            this.usuarios = users;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTimer.Text = DateTime.Now.ToString("HH:mm:ss");
        }


        private void Form1_Load_1(object sender, EventArgs e)
        {


            timer1.Start();

            foreach (Control c in this.Controls)
            {
                TextBox tbx = c as TextBox;
                if (tbx != null)
                {
                    tbx.Text = "Digite " + tbx.AccessibleName;
                }
            }

        }

        private void lblTimer_Click(object sender, EventArgs e)
        {

        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

            txtSenha.PasswordChar = '*';

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            new frmCadastro().ShowDialog();

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Usuarios txt = new Usuarios();
            txt.Usuario = txtUsuario.Text;
            txt.Senha = txtSenha.Text;

            UserRepository repo = new UserRepository();
            List<Usuarios> users = repo.Listar();
            Usuarios filtred = users.Find(u => u.Usuario == txt.Usuario && u.Senha == txt.Senha);

            // bug 
            if (filtred.Admin != null)
            {
                if (filtred.Admin)
                {
                    new TelaPrincipalAdmin().ShowDialog();
                }
                else
                {
                    new TelaPrincipal().ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Usuário não cadastrado!", "Desculpe");

            }
        }

        private void lblSenha_Click(object sender, EventArgs e)
        {

        }

        private void cmbIdioma_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
