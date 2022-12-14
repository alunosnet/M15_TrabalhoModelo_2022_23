
using M15_TrabalhoModelo_2022_23.Emprestimos;
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
//
// Copyright (c) 2022 Paulo Ferreira. All rights reserved.
//
namespace M15_TrabalhoModelo_2022_23
{
    public partial class Form1 : Form
    {
        BaseDados bd = new BaseDados("M15_BD");
        public Form1()
        {
            InitializeComponent();
            TopLeitores();
        }
        public void TopLeitores()
        {
            string sql = @"SELECT Nome,count(*) as [Nr Empréstimos] FROM Leitores 
                            INNER JOIN Emprestimos ON 
                            Leitores.nleitor=Emprestimos.nleitor
                        GROUP By Emprestimos.nleitor, Nome
                        ORDER BY count(*) DESC";
            dataGridView1.DataSource = bd.DevolveSQL(sql);
        }
        /// <summary>
        /// Abre o form dos livros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void livrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_livro f_Livro = new f_livro(bd);
            f_Livro.Show();
        }

        private void leitoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_leitor f_leitor = new f_leitor(bd);
            f_leitor.Show();
        }

        private void empréstimosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_emprestimo emprestimo = new f_emprestimo(bd);
            emprestimo.Show();
        }

        private void devoluçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_devolve devolve = new f_devolve(bd);
            devolve.Show();
        }
    }
}
