using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodStoneGUI {

    //Regarding the choice of executable, it appears the Steam version launches Bond.exe directly, bypassing BizLauncher.
    //A cleaner solution would be some kind of dll hooking, but I have no experience in that area.
    //
    public partial class Form1 : Form {
        //we need a global variable that specifies whether the game has been found. Default to false.
        private static bool gameFound = false;
        //Store the current path as a string to simplify stuff. 
        //It is important that the path always be stored as "Folder\Subfolder\" and not "Folder\Subfolder" so we can append the filename.
        private static string gamePath = "";

        private static String defaultMessage = "Please select the location of BizLauncher.exe";

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            gameLocationGUI.Text = GetGameLocation();
            if(gameFound) {
                buttonInstall.Enabled = true;
            }
            else {
                buttonInstall.Enabled = false;
            }

        }

        //For sanity's sake, we need the path with the final slash.
        static String GetCorrectedPath(String path) {
            return Path.GetDirectoryName(path) + @"\";
        }

        //Check the registry/possible game locations. If found, return path. If not, return error message.
        static String GetGameLocation() {
            string keyName = @"HKEY_LOCAL_MACHINE\SOFTWARE\Activision\BloodStone";
            //New
            try {
                Object gameLocation = Registry.GetValue(keyName, "EXEString", null);
                if (gameLocation == null) {
                    //We should attempt to parse the most likely install location(s).
                    string possibleSteamLocation = @"C:\Program Files (x86)\Steam\steamapps\common\007 Blood Stone\Bond.exe";
                    if (File.Exists(possibleSteamLocation)) {
                        gameFound = true;
                        gamePath = GetCorrectedPath(possibleSteamLocation);
                        return possibleSteamLocation;
                    }
                    gameFound = false;
                    //Spawn a dialog box explaining something went wrong.
                    MessageBox.Show("Unable to automatically locate 007 Blood Stone installation.", "Something went wrong", MessageBoxButtons.OK);
                    return defaultMessage;
                }
                else {
                    gameFound = true;
                    gamePath = GetCorrectedPath(gameLocation.ToString());
                    return gameLocation.ToString();
                }
            } catch (Exception e)
              {
                //Spawn a dialog box explaining something went wrong.
                MessageBox.Show(e.ToString(), "Something went wrong", MessageBoxButtons.OK);
            }
            return defaultMessage;
        }

        public static int ShowDialog(string text, string caption) {
            Form prompt = new Form {
                Width = 500,
                Height = 100,
                Text = caption
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            NumericUpDown inputBox = new NumericUpDown() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70 };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(inputBox);
            prompt.ShowDialog();
            return (int)inputBox.Value;
        }

        static void PatchGame() {
            if (File.Exists(gamePath + "Bond_backup.exe")) {
                //If a backup exe exists, we assume that the program has been run before.

                //
                //Spawn a dialog box.
                if (MessageBox.Show("Would you like to revert game to original state?", "Game already patched!", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    Revert();
                }
            }
            else {
                if (MessageBox.Show("Are you sure?", "Select Yes to proceed. The patching process can be reverted by repeating this process.", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    ReplaceExecutables();
                }
            }
        }
        static void Revert() {
            try {
                RemoveReadOnly();
            }
            catch {
                //This is wonky code. Improve the error handling.
            }
            try {
                File.Delete(gamePath + "Bond.exe");
                File.Delete(gamePath + "Bond_executable.exe");
                File.Copy(gamePath + "Bond_backup.exe", gamePath + "Bond.exe");
            } catch (Exception e) {
                //Spawn a dialog box explaining something went wrong.
                MessageBox.Show(e.ToString(), "Something went wrong", MessageBoxButtons.OK);
            }
            //Spawn a success dialog box. Terminate when they click OK.
            if (MessageBox.Show("Process completed succesfully. Click OK to exit.", "Patch removal complete", MessageBoxButtons.OK) == DialogResult.OK) {
                Application.Exit();
            }
        }

        //If the game's executable is read-only, remove that.
        static bool RemoveReadOnly() {
            try {
                string file = "Bond.exe";
                FileAttributes attrs = File.GetAttributes(gamePath + file);
                if (attrs.HasFlag(FileAttributes.ReadOnly)) {
                    File.SetAttributes(gamePath + file, attrs & ~FileAttributes.ReadOnly);
                }
                return true;
            } catch(Exception e) {
                MessageBox.Show(e.ToString(), "Something went wrong", MessageBoxButtons.OK);
                return false;
            }
        }

        //Replace the original Bond.exe with our new launcher.
        static void ReplaceExecutables() {
            File.Copy(gamePath + "Bond.exe", gamePath + "Bond_executable.exe");
            File.Copy(gamePath + "Bond.exe", gamePath + "Bond_backup.exe");
            if (RemoveReadOnly()) {
                File.Delete(gamePath + "Bond.exe");
                string exePath = Application.ExecutablePath;
                //Obtain the name of the current executable and copy it. This could go wrong, so use a try-catch.
                try {
                    File.Copy(Assembly.GetEntryAssembly().Location + System.AppDomain.CurrentDomain.FriendlyName, gamePath + "Bond.exe");
                }
                catch (Exception e) {
                    //Spawn a dialog box explaining something went wrong.
                    MessageBox.Show(e.ToString(), "Something went wrong", MessageBoxButtons.OK);
                }
            } else {
                //Show a message box saying that read only protection couldn't be removed. Maybe not necessary now?
            }
            if (MessageBox.Show("Process completed succesfully. Click OK to exit.", "Patch process completed", MessageBoxButtons.OK) == DialogResult.OK) {
                Application.Exit();
            }
        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e) {

        }

        //When the user clicks on the button to manually select install location.
        private void ButtonSpecifyLocation_Click(object sender, EventArgs e) {
            if(!gameLocationGUI.Text.Equals(defaultMessage)) {
                openFileDialog1.InitialDirectory = Path.GetDirectoryName(gameLocationGUI.Text);
            }
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) {
                gameLocationGUI.Text = openFileDialog1.FileName;
                if(openFileDialog1.SafeFileName.Equals("BizLauncher.exe") && File.Exists(Path.GetDirectoryName(gameLocationGUI.Text) + "Bond.exe")) {
                    //We have established that BizLauncher.exe was selected and folder also contains Bond.exe.
                    gameFound = true;
                    gamePath = GetCorrectedPath(gameLocationGUI.Text);
                    buttonInstall.Enabled = true;
                }
                else {
                    gameFound = false;
                    buttonInstall.Enabled = false;
                }
            }
        }

        private void BackgroundImage_Click(object sender, EventArgs e) {

        }

        private void ModDescription_TextChanged(object sender, EventArgs e) {

        }

        private void ButtonInstall_Click(object sender, EventArgs e) {
            PatchGame();
        }
    }
}
