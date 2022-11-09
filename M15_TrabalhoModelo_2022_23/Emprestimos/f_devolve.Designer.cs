namespace M15_TrabalhoModelo_2022_23.Emprestimos
{
    partial class f_devolve
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
            this.lbLivros = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbLivros
            // 
            this.lbLivros.FormattingEnabled = true;
            this.lbLivros.Location = new System.Drawing.Point(70, 52);
            this.lbLivros.Name = "lbLivros";
            this.lbLivros.Size = new System.Drawing.Size(186, 264);
            this.lbLivros.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(305, 233);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 83);
            this.button1.TabIndex = 1;
            this.button1.Text = "Receber";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // f_devolve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 372);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbLivros);
            this.Name = "f_devolve";
            this.Text = "f_devolve";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbLivros;
        private System.Windows.Forms.Button button1;
    }
}