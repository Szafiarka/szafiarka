using System;
using System.Reflection;
namespace Szafiarka.Splashscreen
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
        private void InitializeComponent(RetrievingAssemblyData retrivingAssemblyData)
        {
            this.SuspendLayout();
            // 
            // Splashscreen
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "Splashscreen";
            this.ResumeLayout(false);

        }

        #endregion

    }
}