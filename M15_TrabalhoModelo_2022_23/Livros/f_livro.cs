using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M15_TrabalhoModelo_2022_23.Livros
{
    public partial class f_livro : Form
    {
        string capa;
        public f_livro()
        {
            InitializeComponent();
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
            
            //Criar um objeto livro
            
            //Preencher as propriedades
            
            //Guardar na BD
            
            //Limpar o form

        }
    }
}
