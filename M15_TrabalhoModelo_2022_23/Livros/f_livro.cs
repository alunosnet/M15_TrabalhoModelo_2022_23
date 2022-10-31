using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
// Copyright (c) 2022 Paulo Ferreira. All rights reserved.
//
namespace M15_TrabalhoModelo_2022_23.Livros
{
    public partial class f_livro : Form
    {
        string capa="";
        BaseDados bd;
        int nlivro_escolhido;
        public f_livro(BaseDados bd)
        {
            this.bd = bd;
            InitializeComponent();
            AtualizaGrelha();
        }
        void AtualizaGrelha()
        {
            dgLivros.AllowUserToAddRows = false;
            dgLivros.AllowUserToDeleteRows = false;
            dgLivros.ReadOnly = true;
            dgLivros.DataSource = Livro.ListarTodos(bd);
        }
        /// <summary>
        /// Escolher um ficheiro para servir de capa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ficheiro = new OpenFileDialog();
            ficheiro.InitialDirectory = "c:\\";
            ficheiro.Filter= "Imagens |*.jpg;*.png | Todos os ficheiros |*.*";
            ficheiro.Multiselect = false;
            if(ficheiro.ShowDialog()==DialogResult.OK)
            {
                string temp = ficheiro.FileName;
                if (System.IO.File.Exists(temp))
                {
                    pbCapa.Image = Image.FromFile(temp);
                    capa = temp;
                }
            }
        }
        /// <summary>
        /// Guardar na bd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //Validar os dados
            string nome = tbNome.Text;
            if (nome == "" || nome.Length < 3)
            {
                MessageBox.Show("Nome tem de ter pelo menos 3 letras.");
                tbNome.Focus();
                return;
            }
            int ano = 0;
            if (int.TryParse(tbAno.Text, out ano) == false)
            {
                MessageBox.Show("O ano tem de ser preenchido com valores entre 1000 e o ano atual.");
                tbAno.Focus();
                return;
            }
            if (ano < 1000 || ano > DateTime.Now.Year)
            {
                MessageBox.Show("O ano tem de ser preenchido com valores entre 1000 e o ano atual.");
                tbAno.Focus();
                return;
            }
            DateTime data_aquisicao = dtDataAquisicao.Value;
            if (data_aquisicao > DateTime.Now)
            {
                MessageBox.Show("A data de aquisição tem de ser inferior ou igual à data atual.");
                dtDataAquisicao.Focus();
                return;
            }
            decimal preco;
            if (decimal.TryParse(tbPreco.Text, out preco) == false)
            {
                MessageBox.Show("O preço tem de ser superior ou igual a zero.");
                tbPreco.Focus();
                return;
            }
            if (preco < 0 || preco >= 100)
            {
                MessageBox.Show("O preço tem de ser superior ou igual a zero.");
                tbPreco.Focus();
                return;
            }
            /*A capa é opcional*/
            if (string.IsNullOrEmpty(capa) == false)
            {
                if (System.IO.File.Exists(capa) == false)
                {
                    MessageBox.Show("O ficheiro indicado para a capa não existe.");
                    button1.Focus();
                    return;
                }
                //guardar imagem
                Guid guid = Guid.NewGuid();
                string caminhoBD = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                caminhoBD += "\\M15_TrabalhoModelo\\";
                caminhoBD += guid.ToString();
                //copiar o ficheiro
                System.IO.File.Copy(capa, caminhoBD);
                capa = caminhoBD;
            }
            //Criar um objeto livro
            Livro livro = new Livro();
            //Preencher as propriedades
            livro.Nome = nome;
            livro.Ano = ano;
            livro.Capa = capa;
            livro.Data_Aquisicao = data_aquisicao;
            livro.Preco = preco;
            //Guardar na BD
            livro.Guardar(bd);
            //Limpar o form
            LimparForm();
            AtualizaGrelha();
        }

        private void LimparForm()
        {
            tbNome.Text = "";
            tbAno.Text = "";
            tbPreco.Text = "";
            capa = "";
            pbCapa.Image = null;
            dtDataAquisicao.Value = DateTime.Now;
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void apagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApagarRegisto();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ApagarRegisto();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void dgLivros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button3.Visible = true;
            button4.Visible = true;
            button2.Visible = false;

            int linha = dgLivros.CurrentCell.RowIndex;
            if (linha == -1)
            {
                return;
            }
            int nlivro = int.Parse(dgLivros.Rows[linha].Cells[0].Value.ToString());
            Livro escolhido = new Livro();
            escolhido.Procurar(nlivro,bd);
            tbNome.Text = escolhido.Nome;
            tbAno.Text = escolhido.Ano.ToString();
            tbPreco.Text = escolhido.Preco.ToString();
            dtDataAquisicao.Value = escolhido.Data_Aquisicao;
            if (System.IO.File.Exists(escolhido.Capa))
            {
                pbCapa.Image = Image.FromFile(escolhido.Capa);
                capa = escolhido.Capa;
            }
            else
                pbCapa.Image = null;
            nlivro_escolhido = escolhido.Nlivro;
        }
    
        void ApagarRegisto()
        {
            if (nlivro_escolhido < 1)
            {
                MessageBox.Show("Tem de selecionar um livro primeiro. Clique com o botão esquerdo.");
                return;
            }
            //confirmar
            if (MessageBox.Show(
                "Tem a certeza que pretende eliminar o livro selecionado?",
                "Confirmar",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //apagar da bd
                Livro.ApagarLivro(nlivro_escolhido, bd);
                //apagar o ficheiro da capa
                if (System.IO.File.Exists(capa))
                {
                    pbCapa.Image = null;
                    pbCapa.ImageLocation = "";
                    GC.Collect();
                    try
                    {
                        System.IO.File.Delete(capa);
                    }
                    catch { }
                }
            }
            //limpar form
            LimparForm();
            //trocar botões
            button2.Visible = true;
            button3.Visible = false;
            button4.Visible = false;
            //Atualizar a grelha
            AtualizaGrelha();
        }
    }
}
