using System.Windows.Forms;

namespace Szafiarka.Forms.AddAttribiutes
{
    partial class AddCategory
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
            this.nameT = new System.Windows.Forms.TextBox();
            this.descriptionT = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
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
            this.label1.Text = "Nazwa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(37, 110);
            this.label2.Name = "label1";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Opis";
            // 
            // textBox1
            // 
            this.nameT.Location = new System.Drawing.Point(40, 67);
            this.nameT.Name = "textBox1";
            this.nameT.Size = new System.Drawing.Size(400, 20);
            this.nameT.TabIndex = 3;
            this.nameT.TextChanged += textbox_ValueChanged;
            // 
            // textBox2
            // 
            this.descriptionT.Location = new System.Drawing.Point(40, 127);
            this.descriptionT.Name = "capacityT";
            this.descriptionT.Size = new System.Drawing.Size(400, 50);
            this.descriptionT.TabIndex = 3;
            this.descriptionT.TextChanged += textbox_ValueChanged;
            this.descriptionT.Multiline = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            // 
            // AddByName
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.nameT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.descriptionT);
            this.Controls.Add(this.label2);
            this.Name = "AddByName";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 1);

            this.Controls.SetChildIndex(this.nameT, 0);
            this.Controls.SetChildIndex(this.descriptionT, 1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameT;
        private System.Windows.Forms.TextBox descriptionT;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
