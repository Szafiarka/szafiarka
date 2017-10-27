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
            this.SplashscreenPrograssBar = new System.Windows.Forms.ProgressBar();
            this.splashTimer = new System.Windows.Forms.Timer(this.components);
            this.SplashLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SplashscreenPrograssBar
            // 
            this.SplashscreenPrograssBar.Location = new System.Drawing.Point(12, 219);
            this.SplashscreenPrograssBar.Name = "SplashscreenPrograssBar";
            this.SplashscreenPrograssBar.Size = new System.Drawing.Size(625, 23);
            this.SplashscreenPrograssBar.TabIndex = 0;
            // 
            // splashTimer
            // 
            this.splashTimer.Enabled = true;
            this.splashTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SplashLabel
            // 
            this.SplashLabel.AutoSize = true;
            this.SplashLabel.Font = new System.Drawing.Font("Comic Sans MS", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SplashLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SplashLabel.Location = new System.Drawing.Point(12, 104);
            this.SplashLabel.Name = "SplashLabel";
            this.SplashLabel.Size = new System.Drawing.Size(412, 112);
            this.SplashLabel.TabIndex = 1;
            this.SplashLabel.Text = "Szafiarka";
            // 
            // Splashscreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(649, 271);
            this.Controls.Add(this.SplashLabel);
            this.Controls.Add(this.SplashscreenPrograssBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Splashscreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar SplashscreenPrograssBar;
        private System.Windows.Forms.Timer splashTimer;
        private System.Windows.Forms.Label SplashLabel;

    }
}