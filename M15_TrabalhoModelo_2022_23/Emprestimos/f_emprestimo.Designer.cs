namespace M15_TrabalhoModelo_2022_23.Emprestimos
{
    partial class f_emprestimo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbLeitores = new System.Windows.Forms.ComboBox();
            this.cbLivros = new System.Windows.Forms.ComboBox();
            this.dtDataDevolve = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(134, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Leitor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Livro";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Data devolução";
            // 
            // cbLeitores
            // 
            this.cbLeitores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLeitores.FormattingEnabled = true;
            this.cbLeitores.Location = new System.Drawing.Point(201, 32);
            this.cbLeitores.Name = "cbLeitores";
            this.cbLeitores.Size = new System.Drawing.Size(148, 21);
            this.cbLeitores.TabIndex = 1;
            // 
            // cbLivros
            // 
            this.cbLivros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLivros.FormattingEnabled = true;
            this.cbLivros.Location = new System.Drawing.Point(201, 71);
            this.cbLivros.Name = "cbLivros";
            this.cbLivros.Size = new System.Drawing.Size(148, 21);
            this.cbLivros.TabIndex = 1;
            // 
            // dtDataDevolve
            // 
            this.dtDataDevolve.Location = new System.Drawing.Point(201, 111);
            this.dtDataDevolve.Name = "dtDataDevolve";
            this.dtDataDevolve.Size = new System.Drawing.Size(147, 20);
            this.dtDataDevolve.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(201, 170);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 45);
            this.button1.TabIndex = 3;
            this.button1.Text = "Emprestar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // f_emprestimo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 265);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtDataDevolve);
            this.Controls.Add(this.cbLivros);
            this.Controls.Add(this.cbLeitores);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "f_emprestimo";
            this.Text = "f_emprestimo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbLeitores;
        private System.Windows.Forms.ComboBox cbLivros;
        private System.Windows.Forms.DateTimePicker dtDataDevolve;
        private System.Windows.Forms.Button button1;
    }
}