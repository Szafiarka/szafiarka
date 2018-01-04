using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szafiarka.Classes
{
    class AboutProgramTabPage: OptionsTabPages
    {
        PictureBox logo = new PictureBox();
        TextBox information = new TextBox();

        public AboutProgramTabPage()
        {
            Name = "about_program";
            Text = "O programie";

            initializeComponents();
        }

        private void initializeComponents()
        {
            //Logo
            logo.Size = new Size(780, 200);
            logo.Location = new Point(110, 60);
            logo.BackgroundImage = Image.FromFile(@"..\..\images\Logo_white_about_program.png");

            //Info
            information.Size = new Size(780, 300);
            information.Location = new Point(110, 270);
            information.Multiline = true;

            TextReader textReader = new StreamReader(@"..\..\InformationAboutProgram.txt");
            string informationAboutProgram = textReader.ReadToEnd();

            information.Text = informationAboutProgram;
            information.TextAlign = HorizontalAlignment.Center;
            information.Font = new Font("Times New Roman", 16);
            information.BackColor = Color.FromArgb(0, 0, 64);
            information.ForeColor = Color.White;
            information.BorderStyle = BorderStyle.None;

            textReader.Close();
            Controls.Add(logo);
            Controls.Add(information);
        }
    }
}
