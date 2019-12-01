namespace PI3
{
    partial class ScreenHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenHome));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.btnCartoesRFID = new System.Windows.Forms.Button();
            this.btnInformacoes = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnSuporte = new System.Windows.Forms.Button();
            this.btnRelatorios = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.panelHeader.SuspendLayout();
            this.panelSideMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.Goldenrod;
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(893, 39);
            this.panelHeader.TabIndex = 0;
            this.panelHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelHeader_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SaddleBrown;
            this.label1.Location = new System.Drawing.Point(19, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(289, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Smart - Home Automation";
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.BackColor = System.Drawing.Color.MidnightBlue;
            this.panelSideMenu.Controls.Add(this.btnCartoesRFID);
            this.panelSideMenu.Controls.Add(this.btnInformacoes);
            this.panelSideMenu.Controls.Add(this.btnSair);
            this.panelSideMenu.Controls.Add(this.btnSuporte);
            this.panelSideMenu.Controls.Add(this.btnRelatorios);
            this.panelSideMenu.Controls.Add(this.btnInicio);
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 39);
            this.panelSideMenu.Margin = new System.Windows.Forms.Padding(4);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(267, 504);
            this.panelSideMenu.TabIndex = 1;
            // 
            // btnCartoesRFID
            // 
            this.btnCartoesRFID.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCartoesRFID.FlatAppearance.BorderSize = 0;
            this.btnCartoesRFID.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnCartoesRFID.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Goldenrod;
            this.btnCartoesRFID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCartoesRFID.ForeColor = System.Drawing.Color.White;
            this.btnCartoesRFID.Image = ((System.Drawing.Image)(resources.GetObject("btnCartoesRFID.Image")));
            this.btnCartoesRFID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCartoesRFID.Location = new System.Drawing.Point(0, 59);
            this.btnCartoesRFID.Margin = new System.Windows.Forms.Padding(4);
            this.btnCartoesRFID.Name = "btnCartoesRFID";
            this.btnCartoesRFID.Size = new System.Drawing.Size(267, 44);
            this.btnCartoesRFID.TabIndex = 5;
            this.btnCartoesRFID.UseVisualStyleBackColor = true;
            this.btnCartoesRFID.Click += new System.EventHandler(this.btnCartoesRFID_Click);
            // 
            // btnInformacoes
            // 
            this.btnInformacoes.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnInformacoes.FlatAppearance.BorderSize = 0;
            this.btnInformacoes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnInformacoes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Goldenrod;
            this.btnInformacoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInformacoes.ForeColor = System.Drawing.Color.White;
            this.btnInformacoes.Image = ((System.Drawing.Image)(resources.GetObject("btnInformacoes.Image")));
            this.btnInformacoes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInformacoes.Location = new System.Drawing.Point(0, 111);
            this.btnInformacoes.Margin = new System.Windows.Forms.Padding(4);
            this.btnInformacoes.Name = "btnInformacoes";
            this.btnInformacoes.Size = new System.Drawing.Size(267, 44);
            this.btnInformacoes.TabIndex = 4;
            this.btnInformacoes.UseVisualStyleBackColor = true;
            this.btnInformacoes.Click += new System.EventHandler(this.btnInformacoes_Click);
            // 
            // btnSair
            // 
            this.btnSair.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSair.FlatAppearance.BorderSize = 0;
            this.btnSair.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSair.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Goldenrod;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.ForeColor = System.Drawing.Color.White;
            this.btnSair.Image = ((System.Drawing.Image)(resources.GetObject("btnSair.Image")));
            this.btnSair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSair.Location = new System.Drawing.Point(0, 266);
            this.btnSair.Margin = new System.Windows.Forms.Padding(4);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(267, 44);
            this.btnSair.TabIndex = 3;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnSuporte
            // 
            this.btnSuporte.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSuporte.FlatAppearance.BorderSize = 0;
            this.btnSuporte.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnSuporte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Goldenrod;
            this.btnSuporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuporte.ForeColor = System.Drawing.Color.White;
            this.btnSuporte.Image = ((System.Drawing.Image)(resources.GetObject("btnSuporte.Image")));
            this.btnSuporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuporte.Location = new System.Drawing.Point(0, 214);
            this.btnSuporte.Margin = new System.Windows.Forms.Padding(4);
            this.btnSuporte.Name = "btnSuporte";
            this.btnSuporte.Size = new System.Drawing.Size(267, 44);
            this.btnSuporte.TabIndex = 2;
            this.btnSuporte.UseVisualStyleBackColor = true;
            this.btnSuporte.Click += new System.EventHandler(this.btnSuporte_Click);
            // 
            // btnRelatorios
            // 
            this.btnRelatorios.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRelatorios.FlatAppearance.BorderSize = 0;
            this.btnRelatorios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnRelatorios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Goldenrod;
            this.btnRelatorios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelatorios.ForeColor = System.Drawing.Color.White;
            this.btnRelatorios.Image = ((System.Drawing.Image)(resources.GetObject("btnRelatorios.Image")));
            this.btnRelatorios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRelatorios.Location = new System.Drawing.Point(0, 162);
            this.btnRelatorios.Margin = new System.Windows.Forms.Padding(4);
            this.btnRelatorios.Name = "btnRelatorios";
            this.btnRelatorios.Size = new System.Drawing.Size(267, 44);
            this.btnRelatorios.TabIndex = 1;
            this.btnRelatorios.UseVisualStyleBackColor = true;
            this.btnRelatorios.Click += new System.EventHandler(this.btnRelatorios_Click);
            // 
            // btnInicio
            // 
            this.btnInicio.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnInicio.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnInicio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Goldenrod;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.ForeColor = System.Drawing.Color.White;
            this.btnInicio.Image = ((System.Drawing.Image)(resources.GetObject("btnInicio.Image")));
            this.btnInicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInicio.Location = new System.Drawing.Point(0, 7);
            this.btnInicio.Margin = new System.Windows.Forms.Padding(4);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(267, 44);
            this.btnInicio.TabIndex = 0;
            this.btnInicio.UseVisualStyleBackColor = false;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // panelContent
            // 
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(267, 39);
            this.panelContent.Margin = new System.Windows.Forms.Padding(4);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(626, 504);
            this.panelContent.TabIndex = 2;
            // 
            // ScreenHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 543);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelSideMenu);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ScreenHome";
            this.Text = "ScreenHome";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelSideMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCartoesRFID;
        private System.Windows.Forms.Button btnInformacoes;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Button btnSuporte;
        private System.Windows.Forms.Button btnRelatorios;
    }
}