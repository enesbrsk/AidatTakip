namespace AidatTakip
{
    partial class aidatOdeme
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
            this.cbx_bina = new System.Windows.Forms.ComboBox();
            this.cbx_daire = new System.Windows.Forms.ComboBox();
            this.txt_tutar = new System.Windows.Forms.TextBox();
            this.txt_aidat = new System.Windows.Forms.TextBox();
            this.btn_odeme = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_iade = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbx_bina
            // 
            this.cbx_bina.FormattingEnabled = true;
            this.cbx_bina.Location = new System.Drawing.Point(146, 36);
            this.cbx_bina.Name = "cbx_bina";
            this.cbx_bina.Size = new System.Drawing.Size(100, 21);
            this.cbx_bina.TabIndex = 0;
            // 
            // cbx_daire
            // 
            this.cbx_daire.FormattingEnabled = true;
            this.cbx_daire.Location = new System.Drawing.Point(146, 76);
            this.cbx_daire.Name = "cbx_daire";
            this.cbx_daire.Size = new System.Drawing.Size(100, 21);
            this.cbx_daire.TabIndex = 1;
            this.cbx_daire.SelectedIndexChanged += new System.EventHandler(this.cbx_daire_SelectedIndexChanged);
            // 
            // txt_tutar
            // 
            this.txt_tutar.Location = new System.Drawing.Point(146, 158);
            this.txt_tutar.Name = "txt_tutar";
            this.txt_tutar.Size = new System.Drawing.Size(100, 20);
            this.txt_tutar.TabIndex = 2;
            // 
            // txt_aidat
            // 
            this.txt_aidat.Enabled = false;
            this.txt_aidat.Location = new System.Drawing.Point(146, 120);
            this.txt_aidat.Name = "txt_aidat";
            this.txt_aidat.Size = new System.Drawing.Size(100, 20);
            this.txt_aidat.TabIndex = 3;
            // 
            // btn_odeme
            // 
            this.btn_odeme.Location = new System.Drawing.Point(65, 212);
            this.btn_odeme.Name = "btn_odeme";
            this.btn_odeme.Size = new System.Drawing.Size(75, 23);
            this.btn_odeme.TabIndex = 4;
            this.btn_odeme.Text = "Ödeme";
            this.btn_odeme.UseVisualStyleBackColor = true;
            this.btn_odeme.Click += new System.EventHandler(this.btn_odeme_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(53, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Bina İsmi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(53, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Daire No";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(53, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Aidat Tutarı";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(53, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ödenen/İade";
            // 
            // btn_iade
            // 
            this.btn_iade.Location = new System.Drawing.Point(161, 212);
            this.btn_iade.Name = "btn_iade";
            this.btn_iade.Size = new System.Drawing.Size(75, 23);
            this.btn_iade.TabIndex = 9;
            this.btn_iade.Text = "İade";
            this.btn_iade.UseVisualStyleBackColor = true;
            this.btn_iade.Click += new System.EventHandler(this.btn_iade_Click);
            // 
            // aidatOdeme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(310, 285);
            this.Controls.Add(this.btn_iade);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_odeme);
            this.Controls.Add(this.txt_aidat);
            this.Controls.Add(this.txt_tutar);
            this.Controls.Add(this.cbx_daire);
            this.Controls.Add(this.cbx_bina);
            this.Name = "aidatOdeme";
            this.Text = "aidatOdeme";
            this.Load += new System.EventHandler(this.aidatOdeme_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbx_bina;
        private System.Windows.Forms.ComboBox cbx_daire;
        private System.Windows.Forms.TextBox txt_tutar;
        private System.Windows.Forms.TextBox txt_aidat;
        private System.Windows.Forms.Button btn_odeme;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_iade;
    }
}