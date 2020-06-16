using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaDesktop
{
    public partial class frmCadastro : System.Windows.Forms.Form
    {
     
        public frmCadastro()
        {
            InitializeComponent();
        }

        public frmCadastro(DataGridView dgvUsuarios)
        {
            InitializeComponent();
        }
        private void frmCadastro_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        bool isValidPassword;
        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            lblSenha.Visible = true;
            string pattern = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$";
            isValidPassword = Regex.IsMatch(txtSenha.Text, pattern);
            if (isValidPassword)
            {
                lblSenha.Visible = false;
            }

            if (txtSenha.Text == txtConfirmarSenha.Text)
            {
                lblSenhaCorresponde.Visible = false;
            }
            else
            {
                lblSenhaCorresponde.Visible = true;
            }
        }

        private void txtConfirmarSenha_TextChanged(object sender, EventArgs e)
        {

            if(txtSenha.Text == txtConfirmarSenha.Text)
            {
                lblSenhaCorresponde.Visible = false;
            }
            else
            {
                lblSenhaCorresponde.Visible = true;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if(txtConfirmarSenha.Text == "" || txtSenha.Text == "" || txtUsuario.Text == "" || txtSobrenome.Text == "" || txtNome.Text == "")
            {
                MessageBox.Show("Preencha os campos obrigatórios!");
            }
            else { 

            UserRepository repository = new UserRepository();

            Usuarios usuario = new Usuarios
            {
                Nome = txtNome.Text,
                Sobrenome = txtSobrenome.Text,
                Endereco = txtEndereco.Text,
                Numero = txtNumero.Text,
                Usuario = txtUsuario.Text,
                Nascimento = dtNascimento.Value,
                Senha = txtSenha.Text,
                ConfirmarSenha = txtConfirmarSenha.Text,
                Admin = checkAdmin.Checked
            };


                repository.Adicionar(usuario);
                
                MessageBox.Show("Usuário Cadastrado!");
                
            }
        }

        private void dtNascimento_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void bntSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
