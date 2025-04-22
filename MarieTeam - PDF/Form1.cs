using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MarieTeam___PDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string password = txtPassword.Text;

            if (login == "admin" && password == "admin123") // Remplace par tes identifiants réels
            {
                FormGestionBateaux formGestion = new FormGestionBateaux();
                formGestion.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Identifiants incorrects !");
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

       

        
    }
}

