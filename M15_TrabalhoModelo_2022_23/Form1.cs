using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M15_TrabalhoModelo_2022_23
{
    public partial class Form1 : Form
    {
        BaseDados bd = new BaseDados("M15_BD");
        public Form1()
        {
            InitializeComponent();

        }
    }
}
