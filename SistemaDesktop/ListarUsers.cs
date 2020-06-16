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
    public partial class ListarUsers : Form
    {
        private Usuarios usuario = null;
        private int id;
        public ListarUsers()
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        //enviando o usuário para o form (funciona para forms != tbm)
        public ListarUsers(Usuarios usuario)
        {
            InitializeComponent();

            this.usuario = usuario;
            
        }

        private void ListarUsers_Load(object sender, EventArgs e)
        {

            UserRepository repository = new UserRepository();

            List<Usuarios> usuarios = repository.Listar();

            dgvUsuarios.DataSource = usuarios;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserRepository repository = new UserRepository();

            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = repository.Listar();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtEndereco_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UserRepository repository = new UserRepository();
            DataGridViewRow line = dgvUsuarios.Rows[e.RowIndex];
            //line.Cells[0].Value
            Usuarios usuario = new Usuarios
            {
                id = Convert.ToInt32(line.Cells[0].Value.ToString()),
                Nome = line.Cells[1].Value.ToString(),
                Sobrenome = line.Cells[2].Value.ToString(),
                Endereco = line.Cells[3].Value.ToString(),
                Numero = line.Cells[4].Value.ToString(),
                Nascimento = Convert.ToDateTime(line.Cells[5].Value.ToString()),
                Usuario = line.Cells[6].Value.ToString(),
                Senha = line.Cells[7].Value.ToString(),
                ConfirmarSenha = line.Cells[8].Value.ToString(),
            };

            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = repository.Listar();
            
            id = usuario.id;
            txtNome.Text = usuario.Nome;
            txtSobrenome.Text = usuario.Sobrenome;
            txtEndereco.Text = usuario.Endereco;
            txtNumero.Text = usuario.Numero;
            dtNascimento.Value = usuario.Nascimento;
            txtUsuario.Text = usuario.Usuario;
            txtSenha.Text = usuario.Senha;
            txtConfirmarSenha.Text = usuario.ConfirmarSenha;
            
           }

        private void bntEditar_Click(object sender, EventArgs e)
        {
            //--
            UserRepository repository = new UserRepository();

            Usuarios usuario = new Usuarios();
            usuario.id = id;
            usuario.Nome = txtNome.Text;
            usuario.Sobrenome = txtSobrenome.Text;
            usuario.Endereco = txtEndereco.Text;
            usuario.Numero = txtNumero.Text;
            usuario.Nascimento = dtNascimento.Value;
            usuario.Senha = txtSenha.Text;
            usuario.ConfirmarSenha = txtConfirmarSenha.Text;
            usuario.Usuario = txtUsuario.Text;
            
            repository.editar(usuario);

            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = repository.Listar();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            UserRepository repository = new UserRepository();

            new frmCadastro().ShowDialog();

            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = repository.Listar();

        }

        private void btnDeletarUser_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Tem certeza que tu quer excluir este usuário?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(dialog == DialogResult.Yes)
            {
                UserRepository repository = new UserRepository();

                Usuarios usuario = new Usuarios();
                usuario.id = id;
                repository.deletar(usuario.id);
                dgvUsuarios.DataSource = null;
                dgvUsuarios.DataSource = repository.Listar();
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UserRepository repository = new UserRepository();
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = repository.Listar().FindAll( x => x.Nome.ToUpper().Contains(txtFiltro.Text.ToUpper()));
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
