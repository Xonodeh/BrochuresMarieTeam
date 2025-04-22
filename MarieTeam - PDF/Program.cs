using System;
using System.Windows.Forms;

namespace MarieTeam___PDF
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()); // Ton formulaire principal
        }
    }
}

