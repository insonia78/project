/*Program 9
 * @Author thomas zangari
 * This preogram uses a gui iterface to add and multiply two numbers 
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program9
{
    static class Program9
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new program9_design());
        }
    }
            
}
