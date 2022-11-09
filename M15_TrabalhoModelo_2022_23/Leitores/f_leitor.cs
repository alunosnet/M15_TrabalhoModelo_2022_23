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
        int nleitor_escolhido;
        public f_leitor(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;
            AtualizarGrelha();
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button2.Visible = true;
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
            if ( String.IsNullOrEmpty(fotografia))
            {
                MessageBox.Show("Tem de selecionar uma fotografia!");
                return;
            }
            //Criar um objeto
            Leitor leitor = new Leitor(0, tbNome.Text, dtDataNasc.Value, 
                                        Utils.ImagemParaVetor(fotografia), true);
            //Guardar na bd
            leitor.Guardar(bd);
            //limpar form
            LimparForm();
            //atualizar grid
            AtualizarGrelha();
        }

        private void AtualizarGrelha()
        {
            dgLeitores.DataSource = Leitor.ListarTodos(bd);
        }

        private void dgLeitores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //selecionar e mostrar os dados do leitor
            int linha = dgLeitores.CurrentCell.RowIndex;
            if (linha == -1)
            {
                return;
            }
            int nleitor = int.Parse(dgLeitores.Rows[linha].Cells[0].Value.ToString());
            Leitor leitor = new Leitor();
            leitor.ProcurarPorNrLeitor(bd,nleitor);
            tbNome.Text = leitor.Nome;
            dtDataNasc.Value = leitor.DataNascimento;
            string ficheiro = System.IO.Path.GetTempPath() + @"\imagem.jpg";
            Utils.VetorParaImagem(leitor.Fotografia, ficheiro);
            Image img;
            using (var bitmap = new Bitmap(ficheiro))
            {
                img = new Bitmap(bitmap);
                pbFotografia.Image = img;
            }
            //Guardar o nleitor
            nleitor_escolhido = nleitor;
            //mostrar os botões para editar, apagar e cancelar
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button2.Visible = false;
        }
        //Apagar
        private void button3_Click(object sender, EventArgs e)
        {
            //confirmar que pretende apagar

            Leitor.Apagar(bd, nleitor_escolhido);
            AtualizarGrelha();
            button5_Click(sender, e);
        }
        //Atualizar
        private void button4_Click(object sender, EventArgs e)
        {
            //validar o form

            Leitor leitor = new Leitor();
            leitor.Nleitor = nleitor_escolhido;
            leitor.Nome = tbNome.Text;
            leitor.DataNascimento = dtDataNasc.Value;
            if (fotografia!=null && fotografia!="")
            {
                //verificar se o ficheiro existe
                leitor.Fotografia = Utils.ImagemParaVetor(fotografia);
            }
            leitor.Atualizar(bd);
            button5_Click(sender, e);
            AtualizarGrelha();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button2.Visible = true;
            LimparForm();
        }

        private void LimparForm()
        {
            tbNome.Text = "";
            pbFotografia.Image = null;
            fotografia = "";
            dtDataNasc.Value = DateTime.Now;    
        }
    }
}
