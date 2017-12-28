using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szafiarka.Classes
{
    class BackupTabPage : OptionsTabPages
    {
        FlatButton restoreButton, backupButton;

        public BackupTabPage()
        {
            Name = "backup";
            Text = "Kopia zapasowa";

            initializeButtons();
        }

        private void Backup()
        {
            string dbFileName = "database.mdf";
            string CurrentDatabasePath = Path.Combine(Environment.CurrentDirectory, dbFileName);
            string backTimeStamp = Path.GetFileNameWithoutExtension(dbFileName) + "_" + DateTime.Now.Year.ToString("yyyy-MM-dd") + Path.GetExtension(dbFileName);
            string destFileName = backTimeStamp + dbFileName;
            //DBconnection.DBCONNECTION.
            FolderBrowserDialog backup = new FolderBrowserDialog();
            if (backup.ShowDialog() == DialogResult.OK)
            {
                string PathtobackUp = backup.SelectedPath.ToString();
                destFileName = Path.Combine(PathtobackUp, destFileName);
                File.Copy(CurrentDatabasePath, destFileName, true);
                MessageBox.Show("successful Backup! ");
                // Application.Restart();
            }
        }
        /*
        private void Restore()
        {
            string dbFileName = "database.mdf";
            string pathBackup = @"C:\SomeFolder\Backup\gongqin_20120906.mdb";
            string CurrentDatabasePath = Path.Combine(Environment.CurrentDirectory, dbFileName);
            File.Copy(pathBackup, CurrentDatabasePath, true);
            MessageBox.Show("successful Restore! ");
        }
        */
        private void initializeButtons()
        {
            restoreButton = new FlatButton
            {
                Size = new Size(140, 60),
                Location = new Point(750, 570 - 60),
                Name = "restoreButton",
                Text = "Przywróć"
            };

            backupButton = new FlatButton
            {
                Size = new Size(140, 60),
                Location = new Point(600, 540),
                Name = "backupButton",
                Text = "Kopia"
            };

            this.Controls.Add(restoreButton);
            this.Controls.Add(backupButton);
            restoreButton.BringToFront();
            backupButton.BringToFront();

            backupButton.Click += browseclick_button;
            restoreButton.Click += sendclick_button;
        }


        private void browseclick_button(object sender, EventArgs e)
        {
            Backup();
        }

        private void sendclick_button(object sender, EventArgs e)
        {
            //Restore();
        }
    }
}


/*
         private void Restore()
        {
            string dbFileName = "database.mdf";
            string pathBackup = @"C:\SomeFolder\Backup\gongqin_20120906.mdb";
            string CurrentDatabasePath = Path.Combine(Environment.CurrentDirectory, dbFileName);
            File.Copy(pathBackup, CurrentDatabasePath, true);
            MessageBox.Show("successful Restore! ");
        }
        */
