using System;
using System.Collections.Generic;
using System.Linq;
using Szafiarka.Classes;

namespace Szafiarka.Forms.ItemForm
{
    partial class ItemForm
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
            InitializeLabels();
            InitializeComboboxes();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flatButton1 = new Szafiarka.Classes.FlatButton();
            this.flatButton2 = new Szafiarka.Classes.FlatButton();
            this.flatButton3 = new Szafiarka.Classes.FlatButton();
            this.flatButton4 = new Szafiarka.Classes.FlatButton();
            this.flatButton5 = new Szafiarka.Classes.FlatButton();

            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(759, 160);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // flatButton1
            // 
            this.flatButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(168)))), ((int)(((byte)(204)))));
            this.flatButton1.FlatAppearance.BorderSize = 0;
            this.flatButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flatButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.flatButton1.Location = new System.Drawing.Point(696, 149);
            this.flatButton1.Name = "flatButton1";
            this.flatButton1.Size = new System.Drawing.Size(75, 23);
            this.flatButton1.TabIndex = 1;
            this.flatButton1.Text = "flatButton1";
            this.flatButton1.UseVisualStyleBackColor = false;
            this.flatButton1.Click += new System.EventHandler(flatButton2_Click);
            // 
            // flatButton2
            // 
            this.flatButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(168)))), ((int)(((byte)(204)))));
            this.flatButton2.FlatAppearance.BorderSize = 0;
            this.flatButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flatButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.flatButton2.Location = new System.Drawing.Point(697, 527);
            this.flatButton2.Name = "flatButton2";
            this.flatButton2.Size = new System.Drawing.Size(75, 23);
            this.flatButton2.TabIndex = 2;
            this.flatButton2.Text = "flatButton2";
            this.flatButton2.UseVisualStyleBackColor = false;
            // 
            // flatButton3
            // 
            this.flatButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(168)))), ((int)(((byte)(204)))));
            this.flatButton3.FlatAppearance.BorderSize = 0;
            this.flatButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flatButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.flatButton3.Location = new System.Drawing.Point(616, 527);
            this.flatButton3.Name = "flatButton3";
            this.flatButton3.Size = new System.Drawing.Size(75, 23);
            this.flatButton3.TabIndex = 3;
            this.flatButton3.Text = "flatButton3";
            this.flatButton3.UseVisualStyleBackColor = false;
            // 
            // flatButton4
            // 
            this.flatButton4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(168)))), ((int)(((byte)(204)))));
            this.flatButton4.FlatAppearance.BorderSize = 0;
            this.flatButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flatButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.flatButton4.Location = new System.Drawing.Point(535, 527);
            this.flatButton4.Name = "flatButton4";
            this.flatButton4.Size = new System.Drawing.Size(75, 23);
            this.flatButton4.TabIndex = 4;
            this.flatButton4.Text = "flatButton4";
            this.flatButton4.UseVisualStyleBackColor = false;
            // 
            // flatButton5
            // 
            this.flatButton5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(168)))), ((int)(((byte)(204)))));
            this.flatButton5.FlatAppearance.BorderSize = 0;
            this.flatButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.flatButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.flatButton5.Location = new System.Drawing.Point(454, 527);
            this.flatButton5.Name = "flatButton5";
            this.flatButton5.Size = new System.Drawing.Size(75, 23);
            this.flatButton5.TabIndex = 5;
            this.flatButton5.Text = "flatButton5";
            this.flatButton5.UseVisualStyleBackColor = false;
            
            // 
            // ItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.flatButton5);
            this.Controls.Add(this.flatButton4);
            this.Controls.Add(this.flatButton3);
            this.Controls.Add(this.flatButton2);
            this.Controls.Add(this.flatButton1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ItemForm";
            this.Text = "ItemForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Classes.FlatButton flatButton1;
        private Classes.FlatButton flatButton2;
        private Classes.FlatButton flatButton3;
        private Classes.FlatButton flatButton4;
        private Classes.FlatButton flatButton5;

        private void InitializeComboboxes()
        {
            for (int i = 0; i < 5; i++)
            {
                var combobox = new ComboboxesNames()
                {
                    Location = new System.Drawing.Point(250, 225 + 60 * i)
                };


                Controls.Add(combobox);
            }
        }

        private void InitializeLabels()
        {
            var labelIndex = 0;
            int coulmsCount = 2;
            int rowCounts = 4;
            var labels = LabelsNames.getLabelsArray();
            for (int i = 1; i <= coulmsCount; i++)
            {
                var k = 0;
                for (int j = 1; j <= rowCounts + (i-1); j++)
                {
                    var label = new LabelsNames()
                    {
                        Location = new System.Drawing.Point(13 + 237 * (i - 1), 200 + 60  * (j - 1) + k),
                        Text = Utils.GetEnumDescription(labels[labelIndex] as Enum)
                    };
                    Controls.Add(label);

                    if (labels[labelIndex] is LabelsNames.names.description)
                        k = 60;

                    labelIndex++;
                }
                k = 0;
            }
        }
    }
}