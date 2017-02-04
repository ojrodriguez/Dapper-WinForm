using System;
using System.Windows.Forms;
using DapperRepoWinForm.Utilities;
using DapperRepoWinForm.Forms;
namespace DapperRepoWinForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            showForm();
        }


        public static void showForm()
        {
            try
            {
                //Remenber you must have this file--> c:\conn.xml
                string path = Utilities.Globals.path;
                Utilities.Globals.stringConn = ConnectionDB.xml_conn(path);
                string conn = Utilities.Globals.stringConn;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Form1 frm = new Form1();
                frm.Show();
                Application.Run();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }


            // Do some more work here
        }

    }
}
