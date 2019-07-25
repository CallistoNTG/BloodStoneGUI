using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Reflection;

namespace BloodStoneGUI {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {

            //If the application is named Bond.exe, it should silently run in the background, execute fix, then terminate, instead of opening GUI.
            if (System.AppDomain.CurrentDomain.FriendlyName.Equals("Bond.exe")) {
                //Check for the presence of Bond_executable.exe in the same folder as Bond.exe before attempting anything.
                if(File.Exists(Assembly.GetEntryAssembly().Location + "Bond_backup.exe")) {
                    StutterFix();
                }
                //Otherwise do nothing and let program terminate naturally.
            }
            else {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }

        static void StutterFix() {
            Process[] bonds = Process.GetProcessesByName("Bond_executable");
            if (bonds.Length == 0) {
                Process.Start("Bond_executable");
            } else {
                Console.WriteLine("Blood Stone is already running.");
            }
            try {
                //Wait 15 seconds.
                System.Threading.Thread.Sleep(15000);
                bonds = Process.GetProcessesByName("Bond_executable");
                //Set to only use 2nd core.
                bonds[0].ProcessorAffinity = (IntPtr)2;
                System.Threading.Thread.Sleep(1000);
                bonds = Process.GetProcessesByName("Bond_executable");
                //Use Core 1 & 2
                bonds[0].ProcessorAffinity = (IntPtr)3;
            } catch {
                //Error handling code here.
            }
        }
    }
}
