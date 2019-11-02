namespace PI3
{
    partial class ScreenInicio
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
            this.btnLigarLampada = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLigarLampada
            // 
            this.btnLigarLampada.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnLigarLampada.FlatAppearance.BorderSize = 0;
            this.btnLigarLampada.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnLigarLampada.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Goldenrod;
            this.btnLigarLampada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLigarLampada.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnLigarLampada.Location = new System.Drawing.Point(100, 62);
            this.btnLigarLampada.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLigarLampada.Name = "btnLigarLampada";
            this.btnLigarLampada.Size = new System.Drawing.Size(147, 135);
            this.btnLigarLampada.TabIndex = 0;
            this.btnLigarLampada.UseVisualStyleBackColor = true;
            this.btnLigarLampada.Click += new System.EventHandler(this.BtnLigarLampada_Click);
            // 
            // ScreenInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(533, 476);
            this.Controls.Add(this.btnLigarLampada);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ScreenInicio";
            this.Text = "ScreenInicio";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLigarLampada;
    }
}