
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
    }
}
