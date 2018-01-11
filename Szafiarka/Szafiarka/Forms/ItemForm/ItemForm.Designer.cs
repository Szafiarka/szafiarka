using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
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
            this.errorprovider1 = new ErrorProvider();
            InitializeLabels();
            InitializeComboboxes();
            InitializeTextBox();
            InitializeButtons();
            initializeErrorProviders();


            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.historyDataGridView = new DataGridViewNew();
            InitializeHistoryGrid();

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
            pictureBox1.DoubleClick += new EventHandler(image_DoubleClick);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            var checkbox = new CheckboxImproved()
            {
                Location = new System.Drawing.Point(13, 465),
            };

            var _trackbar = new TrackbarImproved();
            var trackbar = TrackbarImproved.getTrackbar();
            trackbar.Location = new System.Drawing.Point(13, 405);
            // 
            // ItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(trackbar);
            
            this.Controls.Add(checkbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ItemForm";
            this.Text = "ItemForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void InitializeHistoryGrid()
        {
            historyDataGridView.Location = new System.Drawing.Point(487, 225);
            historyDataGridView.Size = new Size(287, 250);
            historyDataGridView.ColumnHeadersHeight = 25;
            historyDataGridView.RowTemplate.Height = 25;

            fillHistoryGrid(historyDataGridView);

            this.Controls.Add(historyDataGridView);
        }

        private void fillHistoryGrid(DataGridViewNew datagridview)
        {
            string[,] columns = {
                { "id", "ID" },
                { "action", "Akcja" },
                { "days", "Dni temu" }
            };
            historyDataGridView.AddColumns(columns);
            if (item != null)
            {
                var query = queries.getHistoryByItemId(item.id_item);
                foreach (var item in query.OrderByDescending(x => x.creation_date))
                {
                    var calculatedDays = Utils.compareDateToNowAndGetDaysCount(item.creation_date);
                    historyDataGridView.Rows.Add(item.id, item.action, calculatedDays);
                }
                historyDataGridView.changeIdColumnVisableToFalse();
            }
        }

        #endregion

        private ErrorProvider errorprovider1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DataGridViewNew historyDataGridView;

        private void InitializeComboboxes()
        {
            var k = 0;
            var comboboxes = new ComboboxesImproved();
            foreach (var item in comboboxes.getComboboxImprovedList())
            {
                item.Location = new System.Drawing.Point(250, 225 + 60 * k);
                Controls.Add(item);
                k++;
                item.Leave += new EventHandler(combobox_Leave);
            }
        }

        private void InitializeLabels()
        {
            var labelIndex = 0;
            int coulmsCount = 3;
            int rowCounts = 4;
            new LabelsImproved();
            var labels = LabelsImproved.getList();
            for (int i = 1; i <= coulmsCount; i++)
            {
                var k = 0;
                for (int j = 1; j <= rowCounts + (i-1); j++)
                {
                    if (labelIndex == labels.Count())
                        break;

                    var label = labels[labelIndex];
                    label.Location = new System.Drawing.Point(13 + 237 * (i - 1), 200 + 60 * (j - 1) + k);

                    Controls.Add(label);
                    
                    if (labels[labelIndex].Name == LabelsImproved.names.description.ToString())
                        k = 60;

                    labelIndex++;
                }
                k = 0;
            }
        }

        private void InitializeTextBox()
        {
            var textboxes = new TextboxesNames();
            var k = 0;
            foreach (var item in textboxes.getList())
            {
                item.Location = new System.Drawing.Point(13, 225 + 60 * k);
                item.Width = 200;
                item.Leave += textBoxOut_Leave;
                if (item.Name.ToUpper() == TextboxesNames.names.description.ToString().ToUpper())
                {
                    item.Height = 80;
                }
                k++;
                Controls.Add(item);
            }
        }

        private void InitializeButtons()
        {
            var buttons = new ButtonsImproved();
            var k = 0;

            foreach (var item in ButtonsImproved.getList())
            {
                if (item.Name != ButtonsImproved.names.image.ToString()
                    && item.Name != ButtonsImproved.names.image_delete.ToString())
                {
                    //item.Validating += new System.ComponentModel.CancelEventHandler(textBox1_Validating);
                    item.Location = new Point(13 + item.Width * k, 520);
                    k++;
                    selectAndAddEvent(item);
                    Controls.Add(item);
                }
            }

            var button = ButtonsImproved.getList().Find(x => x.Name == ButtonsImproved.names.image.ToString());
            button.Location = new Point(583, 143);

            selectAndAddEvent(button);
            Controls.Add(button);

            button = ButtonsImproved.getList().Find(x => x.Name == ButtonsImproved.names.image_delete.ToString());
            button.Location = new Point(583, 113);
            button.Enabled = false;

            selectAndAddEvent(button);
            Controls.Add(button);

        }

        private void initializeErrorProviders()
        {
            if (errorProviders != null)
            {
                errorProviders.Clear();
            }
            errorProviders = new List<ErrorProvider> { };
            var n = LabelsImproved.getList().Count - 1;
            errors = new bool[n];
            ErrorProvider errorprovider;
            for (int i = 0; i < n; i++)
            {
                errors[i] = false;
                errorprovider = new ErrorProvider();
                errorprovider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                errorProviders.Add(errorprovider);
            }
        }
    }
}