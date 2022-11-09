using M15_TrabalhoModelo_2022_23.Leitores;
using M15_TrabalhoModelo_2022_23.Livros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M15_TrabalhoModelo_2022_23.Emprestimos
{
    public partial class f_emprestimo : Form
    {
        BaseDados bd;
        public f_emprestimo(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;
            AtualizaCBLeitores();
            AtualizaCBLivros();
        }

        private void AtualizaCBLivros()
        {
            cbLivros.Items.Clear();
            DataTable dados = Livro.ListarDisponiveis(bd);
            foreach(DataRow dr in dados.Rows)
            {
                Livro livro = new Livro();
                livro.Nlivro = int.Parse(dr["nlivro"].ToString());
                livro.Nome = dr["nome"].ToString();
                cbLivros.Items.Add(livro);
            }
        }

        private void AtualizaCBLeitores()
        {
            cbLeitores.Items.Clear();
            DataTable dados = Leitor.ListarTodos(bd);
            foreach(DataRow dr in dados.Rows)
            {
                Leitor leitor = new Leitor();
                leitor.Nleitor = int.Parse(dr["nleitor"].ToString());
                leitor.Nome = dr["nome"].ToString();
                cbLeitores.Items.Add(leitor);
            }
        }

        //Emprestar
        private void button1_Click(object sender, EventArgs e)
        {
            //validar o form
            if (cbLeitores.SelectedIndex == -1)
            {
                MessageBox.Show("Escolha um leitor");
                return;
            }
            if(cbLivros.SelectedIndex==-1)
            {
                MessageBox.Show("Escolha um livro");
                return;
            }
            Leitor leitor = cbLeitores.SelectedItem as Leitor;
            Livro livro = cbLivros.SelectedItem as Livro;
            Emprestimo emprestimo = new Emprestimo(leitor.Nleitor, livro.Nlivro, dtDataDevolve.Value);
            emprestimo.Adicionar(bd);

            AtualizaCBLivros();
        }
    }
}
