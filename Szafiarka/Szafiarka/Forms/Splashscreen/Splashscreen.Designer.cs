using System.Drawing;

namespace Szafiarka.Forms.Splashscreen
{
    partial class Splashscreen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Splashscreen));
            this.SplashscreenProgressBar = new Classes.MapDB.ColoredProgressBar(new SolidBrush(Color.FromArgb(127, 195, 28)));
            this.splashTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // SplashscreenProgressBar
            // 
            this.SplashscreenProgressBar.Location = new System.Drawing.Point(12, 219);
            this.SplashscreenProgressBar.Name = "SplashscreenProgressBar";
            this.SplashscreenProgressBar.Size = new System.Drawing.Size(625, 23);
            this.SplashscreenProgressBar.TabIndex = 0;
            // 
            // splashTimer
            // 
            this.splashTimer.Enabled = true;
            this.splashTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Splashscreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.BackgroundImage = System.Drawing.Image.FromFile(@"..\..\images\logo_white.png");
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(649, 271);
            this.Controls.Add(this.SplashscreenProgressBar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Splashscreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private Classes.MapDB.ColoredProgressBar SplashscreenProgressBar;
        private System.Windows.Forms.Timer splashTimer;

    }
}