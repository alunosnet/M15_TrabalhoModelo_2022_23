using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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
        int NrRegistosPorPagina = 5;
        int nrlinhas, nrpagina;
        public f_livro(BaseDados bd)
        {
            this.bd = bd;
            InitializeComponent();
            AtualizaNrPaginas();
            AtualizaGrelha();
        }
        void AtualizaGrelha()
        {
            dgLivros.AllowUserToAddRows = false;
            dgLivros.AllowUserToDeleteRows = false;
            dgLivros.ReadOnly = true;

            if(cbPagina.SelectedIndex==-1)
                dgLivros.DataSource = Livro.ListarTodos(bd);
            else
            {
                //Paginação
                int nrpagina = cbPagina.SelectedIndex + 1;
                int primeiroregisto = (nrpagina - 1) * NrRegistosPorPagina + 1;
                int ultimoregisto = primeiroregisto + NrRegistosPorPagina - 1;
                dgLivros.DataSource = Livro.ListarTodos(bd, primeiroregisto, ultimoregisto);
            }
            
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
            AtualizaNrPaginas();
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
        /// <summary>
        /// Atualizar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
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
            if (string.IsNullOrEmpty(capa) == false && capa.Contains("M15_TrabalhoModelo")==false)
            {
                if (System.IO.File.Exists(capa) == false)
                {
                    MessageBox.Show("O ficheiro indicado para a capa não existe.");
                    button1.Focus();
                    return;
                }
                //apagar a capa antiga
                Livro antigo = new Livro();
                antigo.Procurar(nlivro_escolhido,bd);
                System.IO.File.Delete(antigo.Capa);
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
            livro.Nlivro = nlivro_escolhido;
            //Guardar na BD
            livro.Atualizar(bd);
            //Limpar o form
            LimparForm();
            AtualizaGrelha();
            //TODO: manter selecionada a linha do último livro editado
        }

        private void dgLivros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
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
                //pbCapa.Image = Image.FromFile(escolhido.Capa);
                //Solução para o bug que não permitia apagar a capa quando se eliminava um livro
                Image img;
                using (var bitmap=new Bitmap(escolhido.Capa))
                {
                    img=new Bitmap(bitmap);
                    pbCapa.Image = img;
                }
                capa = escolhido.Capa;
            }
            else
            {
                pbCapa.Image = null;
                capa = String.Empty;
            }
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
            button5.Visible = false;
            //Atualizar a grelha
            AtualizaGrelha();

            AtualizaNrPaginas();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LimparForm();
            button3.Visible = false;
            button4.Visible = false;
            button2.Visible = true;
            button5.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //pesquisar na bd o livro com nome like textBox1.text
            //atualizar grelha com resultado da pesquisa
            dgLivros.DataSource = Livro.PesquisaPorNome(bd, textBox1.Text);
        }
        /// <summary>
        /// Mudar de página
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizaGrelha();
        }

        void AtualizaNrPaginas()
        {
            cbPagina.Items.Clear();
            int nrlivros = Livro.NrRegistos(bd);
            int nrPaginas =(int) Math.Ceiling(nrlivros / (float)NrRegistosPorPagina);
            for (int i = 1; i <= nrPaginas; i++)
                cbPagina.Items.Add(i);
            /*para o caso de não existirem livros*/
            if (cbPagina.Items.Count == 0)
                cbPagina.Items.Add(1);
            cbPagina.SelectedIndex = 0;
        }

        /// <summary>
        /// Imprimir a grelha
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.Landscape = true;
            printPreviewDialog1.ShowDialog();
        }
        private void imprimeGrelha(System.Drawing.Printing.PrintPageEventArgs e, DataGridView grelha)
        {
            Graphics impressora = e.Graphics;
            Font tipoLetra = new Font("Arial", 10);
            Font tipoLetraMaior = new Font("Arial", 12, FontStyle.Bold);
            Brush cor = Brushes.Black;
            float mesquerda, mdireita, msuperior, minferior, linha, largura;
            Pen caneta = new Pen(cor, 2);

            //margens
            mesquerda = printDocument1.DefaultPageSettings.Margins.Left;
            mdireita = printDocument1.DefaultPageSettings.Bounds.Right - mesquerda;
            msuperior = printDocument1.DefaultPageSettings.Margins.Top;
            minferior = printDocument1.DefaultPageSettings.Bounds.Height - msuperior;
            largura = mdireita - mesquerda;
            //calcular as colunas da grelha
            float[] colunas = new float[grelha.Columns.Count];
            float lgrelha = 0;
            for (int i = 0; i < grelha.Columns.Count; i++)
                lgrelha += grelha.Columns[i].Width;
            colunas[0] = mesquerda;
            float total = mesquerda, larguraColuna;
            for (int i = 0; i < grelha.Columns.Count - 1; i++)
            {
                larguraColuna = grelha.Columns[i].Width / lgrelha;
                colunas[i + 1] = larguraColuna * largura + total;
                total = colunas[i + 1];
            }
            //cabeçalhos
            for (int i = 0; i < grelha.Columns.Count; i++)
            {
                impressora.DrawString(grelha.Columns[i].HeaderText, tipoLetraMaior, cor, colunas[i], msuperior);
            }
            linha = msuperior + tipoLetraMaior.Height;
            //ciclo para percorrer a grelha
            int l;
            for (l = nrlinhas; l < grelha.Rows.Count; l++)
            {
                //desenhar linha
                impressora.DrawLine(caneta, mesquerda, linha, mdireita, linha);
                //escrever uma linha
                for (int c = 0; c < grelha.Columns.Count; c++)
                {
                    impressora.DrawString(grelha.Rows[l].Cells[c].Value.ToString(),
                        tipoLetra, cor, colunas[c], linha);
                }
                //avançar para linha seguinte
                linha = linha + tipoLetra.Height;
                //verificar se o papel acabou
                if (linha + tipoLetra.Height > minferior)
                    break;
            }
            //tem mais páginas?
            if (l < grelha.Rows.Count)
            {
                nrlinhas = l + 1;
                e.HasMorePages = true;
            }
            //rodapé
            impressora.DrawString("12ºH - Página " + nrpagina.ToString(), tipoLetra, cor, mesquerda, minferior);
            //nr página
            nrpagina++;
            //linhas
            //linha superior
            impressora.DrawLine(caneta, mesquerda, msuperior, mdireita, msuperior);
            //linha inferior
            impressora.DrawLine(caneta, mesquerda, linha, mdireita, linha);
            //colunas
            for (int c = 0; c < colunas.Length; c++)
            {
                impressora.DrawLine(caneta, colunas[c], msuperior, colunas[c], linha);
            }
            //linha lado direito
            impressora.DrawLine(caneta, mdireita, msuperior, mdireita, linha);
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            imprimeGrelha(e, dgLivros);
        }
    }
}
