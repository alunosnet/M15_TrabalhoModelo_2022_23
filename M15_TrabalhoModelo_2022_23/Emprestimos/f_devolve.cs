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
    public partial class f_devolve : Form
    {
        BaseDados bd;
        public f_devolve(BaseDados bd)
        {
            InitializeComponent();
            this.bd=bd;
            AtualizaLBLivros();
        }

        private void AtualizaLBLivros()
        {
            lbLivros.Items.Clear();
            DataTable dados = Livro.ListarEmprestados(bd);
            foreach (DataRow dr in dados.Rows)
            {
                Livro livro = new Livro();
                livro.Nlivro = int.Parse(dr["nlivro"].ToString());
                livro.Nome = dr["nome"].ToString();
                lbLivros.Items.Add(livro);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(lbLivros.SelectedItem==null)
            {
                MessageBox.Show("Tem de escolher um livro");
                return;
            }
            Livro livro = lbLivros.SelectedItem as Livro;
            Emprestimo.Devolver(bd, livro.Nlivro);
            AtualizaLBLivros();
        }
    }
}
