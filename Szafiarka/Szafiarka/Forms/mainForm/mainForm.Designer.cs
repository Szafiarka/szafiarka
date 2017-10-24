namespace Szafiarka
{
    partial class MainForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        //private void InitializeComponent(RetrievingAssemblyData assemblyData)
        {
            this.pMenu = new Classes.PanelMenu();
            this.pMain = new System.Windows.Forms.Panel();
            this.button2 = new Szafiarka.Classes.OptionsButton();
            this.pMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // InitializeMenuButtons
            // 
            var menuButton = new Classes.MenuButton();
            menuButton.InitializeMenuButtons(this, this.pMenu);
            //
            // InitializePanels
            //
            var panels = new Classes.Panels();  //B
            panels.initializePanels(this); //B
            // 
            // pMain
            //
            this.pMain.Location = new System.Drawing.Point(107, 68);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(1065, 686);
            this.pMain.TabIndex = 2;
            this.pMain.Visible = false;
            //
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1097, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1184, 766);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pMain);
            this.Controls.Add(this.pMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "mainForm";
            this.pMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private Classes.PanelMenu pMenu;
        private System.Windows.Forms.Panel pMain;
        private Classes.OptionsButton button2;
    }
}

