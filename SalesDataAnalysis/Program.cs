using System;
using System.Windows.Forms;

namespace SalesDataAnalysis
{
    public abstract class Program
    {
        // Ich hätte gerne für die Aufgabe hier dependency injection verwendet.
        // Das Problem ist aber, dass ich Rider von JetBrains verwende und dieses den Designer für Windows Forms Apps nur bei .net framework unterstützt.
        // Es wäre möglich, dieses mit einem nuget package nach zu installieren, aber ich sollte ja keine extra packages verwenden (Außer zum unit testen)
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        { 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}