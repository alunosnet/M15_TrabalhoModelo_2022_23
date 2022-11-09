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
            DataTable dados = Livro.ListarTodos(bd);
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
        }

        //Emprestar
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
