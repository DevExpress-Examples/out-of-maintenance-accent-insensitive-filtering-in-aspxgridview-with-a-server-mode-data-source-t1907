// Developer Express Code Central Example:
// How to display and edit XPO in the ASPxGridView
// 
// This is a simple example of how to bind the grid to an XpoDataSource (eXpress
// Persistent Objects) for data displaying and editing. It's implemented according
// to the http://www.devexpress.com/scid=K18061 article.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E320

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DatabaseUpdater {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}