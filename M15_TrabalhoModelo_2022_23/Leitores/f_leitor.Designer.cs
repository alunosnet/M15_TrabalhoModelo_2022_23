namespace M15_TrabalhoModelo_2022_23.Leitores
{
    partial class f_leitor
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
            this.tbNome = new System.Windows.Forms.TextBox();
            this.dtDataNasc = new System.Windows.Forms.DateTimePicker();
            this.pbFotografia = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dgLeitores = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pbFotografia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgLeitores)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Data Nascimento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Fotografia";
            // 
            // tbNome
            // 
            this.tbNome.Location = new System.Drawing.Point(159, 50);
            this.tbNome.Name = "tbNome";
            this.tbNome.Size = new System.Drawing.Size(203, 20);
            this.tbNome.TabIndex = 1;
            // 
            // dtDataNasc
            // 
            this.dtDataNasc.Location = new System.Drawing.Point(159, 76);
            this.dtDataNasc.Name = "dtDataNasc";
            this.dtDataNasc.Size = new System.Drawing.Size(204, 20);
            this.dtDataNasc.TabIndex = 2;
            // 
            // pbFotografia
            // 
            this.pbFotografia.Location = new System.Drawing.Point(159, 114);
            this.pbFotografia.Name = "pbFotografia";
            this.pbFotografia.Size = new System.Drawing.Size(165, 146);
            this.pbFotografia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFotografia.TabIndex = 3;
            this.pbFotografia.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(159, 277);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 25);
            this.button1.TabIndex = 4;
            this.button1.Text = "Procurar...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(161, 329);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(163, 67);
            this.button2.TabIndex = 5;
            this.button2.Text = "Adicionar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dgLeitores
            // 
            this.dgLeitores.AllowUserToAddRows = false;
            this.dgLeitores.AllowUserToDeleteRows = false;
            this.dgLeitores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLeitores.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgLeitores.Location = new System.Drawing.Point(411, 76);
            this.dgLeitores.Name = "dgLeitores";
            this.dgLeitores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgLeitores.ShowEditingIcon = false;
            this.dgLeitores.Size = new System.Drawing.Size(296, 225);
            this.dgLeitores.TabIndex = 6;
            // 
            // f_leitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 450);
            this.Controls.Add(this.dgLeitores);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pbFotografia);
            this.Controls.Add(this.dtDataNasc);
            this.Controls.Add(this.tbNome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "f_leitor";
            this.Text = "f_leitor";
            ((System.ComponentModel.ISupportInitialize)(this.pbFotografia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgLeitores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNome;
        private System.Windows.Forms.DateTimePicker dtDataNasc;
        private System.Windows.Forms.PictureBox pbFotografia;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgLeitores;
    }
}