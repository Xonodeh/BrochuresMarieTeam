namespace MarieTeam___PDF
{
    partial class FormGestionBateaux
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
            this.lstBateaux = new System.Windows.Forms.ListBox();
            this.txtNomBateau = new System.Windows.Forms.TextBox();
            this.txtLongueur = new System.Windows.Forms.TextBox();
            this.txtLargeur = new System.Windows.Forms.TextBox();
            this.txtVitesse = new System.Windows.Forms.TextBox();
            this.txtImageUrl = new System.Windows.Forms.TextBox();
            this.rtbEquipements = new System.Windows.Forms.RichTextBox();
            this.picBateau = new System.Windows.Forms.PictureBox();
            this.btnGenererPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBateau)).BeginInit();
            this.SuspendLayout();
            // 
            // lstBateaux
            // 
            this.lstBateaux.FormattingEnabled = true;
            this.lstBateaux.Location = new System.Drawing.Point(12, 12);
            this.lstBateaux.Name = "lstBateaux";
            this.lstBateaux.Size = new System.Drawing.Size(213, 381);
            this.lstBateaux.TabIndex = 0;
            this.lstBateaux.SelectedIndexChanged += new System.EventHandler(this.lstBateaux_SelectedIndexChanged);
            // 
            // txtNomBateau
            // 
            this.txtNomBateau.Location = new System.Drawing.Point(372, 45);
            this.txtNomBateau.Name = "txtNomBateau";
            this.txtNomBateau.Size = new System.Drawing.Size(149, 20);
            this.txtNomBateau.TabIndex = 1;
            // 
            // txtLongueur
            // 
            this.txtLongueur.Location = new System.Drawing.Point(372, 71);
            this.txtLongueur.Name = "txtLongueur";
            this.txtLongueur.Size = new System.Drawing.Size(149, 20);
            this.txtLongueur.TabIndex = 2;
            // 
            // txtLargeur
            // 
            this.txtLargeur.Location = new System.Drawing.Point(372, 97);
            this.txtLargeur.Name = "txtLargeur";
            this.txtLargeur.Size = new System.Drawing.Size(149, 20);
            this.txtLargeur.TabIndex = 3;
            // 
            // txtVitesse
            // 
            this.txtVitesse.Location = new System.Drawing.Point(372, 123);
            this.txtVitesse.Name = "txtVitesse";
            this.txtVitesse.Size = new System.Drawing.Size(149, 20);
            this.txtVitesse.TabIndex = 4;
            // 
            // txtImageUrl
            // 
            this.txtImageUrl.Location = new System.Drawing.Point(372, 149);
            this.txtImageUrl.Name = "txtImageUrl";
            this.txtImageUrl.Size = new System.Drawing.Size(149, 20);
            this.txtImageUrl.TabIndex = 5;
            // 
            // rtbEquipements
            // 
            this.rtbEquipements.Location = new System.Drawing.Point(372, 199);
            this.rtbEquipements.Name = "rtbEquipements";
            this.rtbEquipements.Size = new System.Drawing.Size(148, 92);
            this.rtbEquipements.TabIndex = 6;
            this.rtbEquipements.Text = "";
            // 
            // picBateau
            // 
            this.picBateau.Location = new System.Drawing.Point(573, 89);
            this.picBateau.Name = "picBateau";
            this.picBateau.Size = new System.Drawing.Size(146, 54);
            this.picBateau.TabIndex = 7;
            this.picBateau.TabStop = false;
            // 
            // btnGenererPDF
            // 
            this.btnGenererPDF.Location = new System.Drawing.Point(372, 323);
            this.btnGenererPDF.Name = "btnGenererPDF";
            this.btnGenererPDF.Size = new System.Drawing.Size(144, 70);
            this.btnGenererPDF.TabIndex = 8;
            this.btnGenererPDF.Text = "Generer PDF";
            this.btnGenererPDF.UseVisualStyleBackColor = true;
            // 
            // FormGestionBateaux
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGenererPDF);
            this.Controls.Add(this.picBateau);
            this.Controls.Add(this.rtbEquipements);
            this.Controls.Add(this.txtImageUrl);
            this.Controls.Add(this.txtVitesse);
            this.Controls.Add(this.txtLargeur);
            this.Controls.Add(this.txtLongueur);
            this.Controls.Add(this.txtNomBateau);
            this.Controls.Add(this.lstBateaux);
            this.Name = "FormGestionBateaux";
            this.Text = "FormGestionBateaux";
            this.Load += new System.EventHandler(this.FormGestionBateaux_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBateau)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstBateaux;
        private System.Windows.Forms.TextBox txtNomBateau;
        private System.Windows.Forms.TextBox txtLongueur;
        private System.Windows.Forms.TextBox txtLargeur;
        private System.Windows.Forms.TextBox txtVitesse;
        private System.Windows.Forms.TextBox txtImageUrl;
        private System.Windows.Forms.RichTextBox rtbEquipements;
        private System.Windows.Forms.PictureBox picBateau;
        private System.Windows.Forms.Button btnGenererPDF;
    }
}