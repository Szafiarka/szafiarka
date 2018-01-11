using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using Szafiarka.Classes;

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

        private void InitializeComponent(RetrievingAssemblyData assemblyData)
        {
            this.pMenu = new PanelMenu();
            this.bTools = new ToolsButton();
            this.pMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // InitializeMenuButtons
            // 
            InitializeMenuButtons();
            //
            // InitializePanels
            //
            InitializePanels();
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1184, 766);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = assemblyData.AssemblyTitle;

            this.Controls.Add(this.bTools);
            this.Controls.Add(this.pMenu);
            this.pMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #region Menu Buttons
        private void InitializeMenuButtons()
        {
            var buttons = MenuButton.getButtonsArray();
            for (int i = 0; i < buttons.Length / 2; i++)
            {
                var button = new Classes.MenuButton()
                {
                    Location = new Point(0, 100 * i),
                    BackColor = pMenu.BackColor,
                    Name = buttons[i, 0].ToString(),
                    Text = Utils.GetEnumDescription(buttons[i, 0] as Enum)
                };
                button.changeBackColor(pMenu.BackColor);
                button.addImage();
                selectAndAddEvent(button);
                pMenu.Controls.Add(button);
                MenuButton.addNewButtonToList(button);
            }
        }
        #endregion
        #region Menu Panels
        private void InitializePanels()
        {
            Panels.addNewPanelToList(new PanelStart());
            Panels.addNewPanelToList(new PanelSearch());
            Panels.addNewPanelToList(new PanelBin());

            foreach (var panel in Panels.getPanelsList())
            {
                Controls.Add(panel);
            };
        }
        #endregion  

        private Classes.PanelMenu pMenu;
        private Classes.ToolsButton bTools;
    }
}

