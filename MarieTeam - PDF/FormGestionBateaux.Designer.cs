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
            this.picBateau = new System.Windows.Forms.PictureBox();
            this.btnGenererPDF = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnModifier = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.addEquipement = new System.Windows.Forms.Button();
            this.supprEquipement = new System.Windows.Forms.Button();
            this.toutLesEquip = new System.Windows.Forms.ListBox();
            this.equipDuBateau = new System.Windows.Forms.ListBox();
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
            this.btnGenererPDF.Location = new System.Drawing.Point(464, 323);
            this.btnGenererPDF.Name = "btnGenererPDF";
            this.btnGenererPDF.Size = new System.Drawing.Size(144, 70);
            this.btnGenererPDF.TabIndex = 8;
            this.btnGenererPDF.Text = "Generer PDF";
            this.btnGenererPDF.UseVisualStyleBackColor = true;
            this.btnGenererPDF.Click += new System.EventHandler(this.btnGenererPDF_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(270, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Nom du bateau";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Longueur";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(270, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Largeur";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Vitesse";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(270, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Image URL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(270, 200);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Tout les équipements";
            // 
            // btnModifier
            // 
            this.btnModifier.Location = new System.Drawing.Point(286, 323);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(135, 69);
            this.btnModifier.TabIndex = 15;
            this.btnModifier.Text = "Modifier ";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(427, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Equipements du bateau";
            // 
            // addEquipement
            // 
            this.addEquipement.Location = new System.Drawing.Point(635, 212);
            this.addEquipement.Name = "addEquipement";
            this.addEquipement.Size = new System.Drawing.Size(164, 26);
            this.addEquipement.TabIndex = 18;
            this.addEquipement.Text = "Ajouter un équipement";
            this.addEquipement.UseVisualStyleBackColor = true;
            this.addEquipement.Click += new System.EventHandler(this.addEquipement_Click);
            // 
            // supprEquipement
            // 
            this.supprEquipement.Location = new System.Drawing.Point(635, 244);
            this.supprEquipement.Name = "supprEquipement";
            this.supprEquipement.Size = new System.Drawing.Size(164, 23);
            this.supprEquipement.TabIndex = 19;
            this.supprEquipement.Text = "Supprimer un équipement";
            this.supprEquipement.UseVisualStyleBackColor = true;
            this.supprEquipement.Click += new System.EventHandler(this.supprEquipement_Click);
            // 
            // toutLesEquip
            // 
            this.toutLesEquip.FormattingEnabled = true;
            this.toutLesEquip.Location = new System.Drawing.Point(273, 216);
            this.toutLesEquip.Name = "toutLesEquip";
            this.toutLesEquip.Size = new System.Drawing.Size(148, 95);
            this.toutLesEquip.TabIndex = 20;
            // 
            // equipDuBateau
            // 
            this.equipDuBateau.FormattingEnabled = true;
            this.equipDuBateau.Location = new System.Drawing.Point(430, 216);
            this.equipDuBateau.Name = "equipDuBateau";
            this.equipDuBateau.Size = new System.Drawing.Size(160, 95);
            this.equipDuBateau.TabIndex = 21;
            // 
            // FormGestionBateaux
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.equipDuBateau);
            this.Controls.Add(this.toutLesEquip);
            this.Controls.Add(this.supprEquipement);
            this.Controls.Add(this.addEquipement);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenererPDF);
            this.Controls.Add(this.picBateau);
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
        private System.Windows.Forms.PictureBox picBateau;
        private System.Windows.Forms.Button btnGenererPDF;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button addEquipement;
        private System.Windows.Forms.Button supprEquipement;
        private System.Windows.Forms.ListBox toutLesEquip;
        private System.Windows.Forms.ListBox equipDuBateau;
    }
}