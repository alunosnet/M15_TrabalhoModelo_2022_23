using M14_15_TrabalhoModelo_1920_WIP;
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
namespace M15_TrabalhoModelo_2022_23.Leitores
{
    public partial class f_leitor : Form
    {
        string fotografia;
        BaseDados bd;
        public f_leitor(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;
            AtualizarGrelha();
        }
        /// <summary>
        /// Procurar fotografia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ficheiro = new OpenFileDialog();
            ficheiro.InitialDirectory = "c:\\";
            ficheiro.Filter = "Imagens |*.jpg;*.png | Todos os ficheiros |*.*";
            ficheiro.Multiselect = false;
            if (ficheiro.ShowDialog() == DialogResult.OK)
            {
                string temp = ficheiro.FileName;
                if (System.IO.File.Exists(temp))
                {
                    pbFotografia.Image = Image.FromFile(temp);
                    fotografia = temp;
                }
            }
        }
        /// <summary>
        /// Adicionar leitor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //validar o formulário

            //Criar um objeto
            Leitor leitor = new Leitor(0, tbNome.Text, dtDataNasc.Value, Utils.ImagemParaVetor(fotografia), true);
            //Guardar na bd
            leitor.Guardar(bd);
            //limpar form
            tbNome.Text = "";
            pbFotografia.Image = null;
            fotografia = "";
            //atualizar grid
            AtualizarGrelha();
        }

        private void AtualizarGrelha()
        {
            dgLeitores.DataSource = Leitor.ListarTodos(bd);
        }
    }
}
