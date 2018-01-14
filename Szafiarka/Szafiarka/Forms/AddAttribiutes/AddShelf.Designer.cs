using System.Windows.Forms;

namespace Szafiarka.Forms.AddAttribiutes
{
    partial class AddShelf
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

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda obsługi projektanta — nie należy modyfikować 
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.locationT = new System.Windows.Forms.TextBox();
            this.capacityT = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(37, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lokalizacja";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(37, 110);
            this.label2.Name = "label1";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Rozmiar";
            // 
            // textBox1
            // 
            this.locationT.Location = new System.Drawing.Point(40, 67);
            this.locationT.Name = "textBox1";
            this.locationT.Size = new System.Drawing.Size(400, 20);
            this.locationT.TabIndex = 3;
            this.locationT.TextChanged += textbox_ValueChanged;
            this.locationT.KeyPress += textBox_KeyPress;
            // 
            // textBox2
            // 
            this.capacityT.Location = new System.Drawing.Point(40, 127);
            this.capacityT.Name = "capacityT";
            this.capacityT.Size = new System.Drawing.Size(400, 20);
            this.capacityT.TabIndex = 3;
            this.capacityT.TextChanged += textbox_ValueChanged;
            this.capacityT.KeyPress += textBox_KeyPress;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            this.errorProvider2.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            // 
            // AddByName
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.locationT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.capacityT);
            this.Controls.Add(this.label2);
            this.Name = "AddByName";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 1);

            this.Controls.SetChildIndex(this.locationT, 0);
            this.Controls.SetChildIndex(this.capacityT, 1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox locationT;
        private System.Windows.Forms.TextBox capacityT;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
    }
}
