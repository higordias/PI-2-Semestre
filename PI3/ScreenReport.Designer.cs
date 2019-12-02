namespace PI3
{
    partial class ScreenReport
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
            this.dgvAcessos = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAtualizarTabela = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcessos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAcessos
            // 
            this.dgvAcessos.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvAcessos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAcessos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAcessos.Location = new System.Drawing.Point(24, 24);
            this.dgvAcessos.Name = "dgvAcessos";
            this.dgvAcessos.RowHeadersWidth = 51;
            this.dgvAcessos.RowTemplate.Height = 24;
            this.dgvAcessos.Size = new System.Drawing.Size(492, 336);
            this.dgvAcessos.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 415);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(334, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "entrar em contato com a SMART Home Automation.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 375);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(385, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Relatório com informações de acessos realizados enquanto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 395);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(354, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "o aplicativo estava ativo. Para relatório completo, favor";
            // 
            // btnAtualizarTabela
            // 
            this.btnAtualizarTabela.Location = new System.Drawing.Point(416, 375);
            this.btnAtualizarTabela.Name = "btnAtualizarTabela";
            this.btnAtualizarTabela.Size = new System.Drawing.Size(100, 57);
            this.btnAtualizarTabela.TabIndex = 7;
            this.btnAtualizarTabela.Text = "Atualizar Dados";
            this.btnAtualizarTabela.UseVisualStyleBackColor = true;
            this.btnAtualizarTabela.Click += new System.EventHandler(this.btnAtualizarTabela_Click);
            // 
            // ScreenReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(553, 466);
            this.Controls.Add(this.btnAtualizarTabela);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvAcessos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScreenReport";
            this.Text = "ScreenReport";
            this.Load += new System.EventHandler(this.ScreenReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAcessos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAcessos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAtualizarTabela;
    }
}