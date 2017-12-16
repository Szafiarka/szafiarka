using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szafiarka.Classes
{
    class ContactTabPage : OptionsTabPages
    {
        List<TextBox> textBoxList;
        ComboBox comboBoxCategories;
        FlatButton sendButton, browseButton;
        public ContactTabPage()
        {
            Name = "contact";
            Text = "Kontakt";
            initializeLabels();
            initializeFields();
            initializeButtons();
        }

        private enum labelNames
        {
            name,
            email,
            category,
            topic,
            message,
            attachment
        }

        private static string[,] LABELNAMES = {
            { labelNames.name.ToString(), "Imię i nazwisko" },
            { labelNames.email.ToString(), "Adres email"},
            { labelNames.category.ToString(), "Kategoria"},
            { labelNames.topic.ToString(), "Temat"},
            { labelNames.message.ToString(), "Treść wiadomości"},
            { labelNames.attachment.ToString(), "Załącznik"}
        };

        private void initializeLabels()
        {
            var mainLabel = new HeaderLabel1
            {
                Location = new Point(70, 10),
                Text = "Potrzebujesz pomocy, chcesz zgłosić problem lub o coś zapytać? Napisz do nas!"
            };
            Controls.Add(mainLabel);

            for (int i = 0; i < LABELNAMES.Length / 2; i++)
            {
                var label = new FieldTitleLabel()
                {
                    Location = new Point(300, 70 + i * 65),
                    Name = LABELNAMES[i, 0].ToString(),
                    Text = LABELNAMES[i, 1]
                };

                if (LABELNAMES[i, 0] == "attachment")
                {
                    label.Location = new Point(300, 520);
                }
                Controls.Add(label);
            }

        }

        private void initializeFields()
        {
            textBoxList = new List<TextBox>((LABELNAMES.Length - 1) / 2);
            for (int i = 0; i < LABELNAMES.Length / 2; i++)
            {
                if (LABELNAMES[i, 0] == "category")    //comboBox
                {   //Przerobic collection na enum
                    comboBoxCategories = new ComboBox();
                    comboBoxCategories.Location = new Point(300, 95 + i * 65); //new Point(300, 100 + i * 80);
                    comboBoxCategories.Size = new Size(400, 30);
                    comboBoxCategories.Name = LABELNAMES[i, 0].ToString();
                    comboBoxCategories.Font = new Font("Arial", 12);
                    comboBoxCategories.Items.Add("Pytanie");
                    comboBoxCategories.Items.Add("Problem");
                    comboBoxCategories.Items.Add("Sugestia");
                    comboBoxCategories.Items.Add("Błąd");
                    comboBoxCategories.SelectedIndex = 0;
                    Controls.Add(comboBoxCategories);
                    comboBoxCategories.BringToFront();
                    continue;
                }

                var textBox = new TextBox()
                {
                    Location = new Point(300, 95 + i * 65),
                    Size = new Size(400, 30),
                    Name = LABELNAMES[i, 0].ToString(),
                    Font = new Font("Arial", 12)
                };

                if (LABELNAMES[i, 0] == "message")
                {
                    textBox.Multiline = true;
                    textBox.Size = new Size(400, 150);
                }

                if (LABELNAMES[i, 0] == "attachment")
                {
                    textBox.Location = new Point(300, 540);
                    textBox.Size = new Size(290, 30);    //miejsce na button obok: 400-10(luz)-100(szerokosc buttona)
                    textBox.ReadOnly = true;
                }

                textBoxList.Add(textBox);
                Controls.Add(textBox);
                textBox.BringToFront();
            }

        }

        private void initializeButtons()
        {
            sendButton = new FlatButton
            {
                Size = new Size(140, 60),
                Location = new Point(750, 570 - 60),  // zautomatyzowac liczenie
                Name = "sendButton",
                Text = "Wyślij"
            };

            browseButton = new FlatButton
            {
                Size = new Size(100, 30),
                Location = new Point(600, 540),
                Name = "browseButton",
                Text = "Wyszukaj"
            };

            this.Controls.Add(sendButton);
            this.Controls.Add(browseButton);
            sendButton.BringToFront();
            browseButton.BringToFront();

            browseButton.Click += browseclick_button;
            sendButton.Click += sendclick_button;
        }

        private void browseclick_button(object sender, EventArgs e)
        {
            OpenFileDialog dg = new OpenFileDialog();
            if (dg.ShowDialog() == DialogResult.OK)
            {
                string path = dg.FileName.ToString();
                textBoxList.Last().Text = path;
            }
        }

        private void sendclick_button(object sender, EventArgs e)   //zrobić na try catch
        {
            bool condition = validationOfFields();
            if (condition == true)
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("projektszafiarka@gmail.com");
                mail.ReplyToList.Add(textBoxList[1].Text);
                mail.To.Add("projektszafiarka@gmail.com");

                mail.Subject = "[" + comboBoxCategories.SelectedItem.ToString() + "] - " + textBoxList[2].Text;
                mail.Body = textBoxList[3].Text + "\n\n----------------\n" + textBoxList[0].Text;
                if (textBoxList.Last().Text != "")
                {
                    mail.Attachments.Add(new Attachment(textBoxList.Last().Text));
                }


                SmtpServer.Port = 587;
                SmtpServer.Credentials = new NetworkCredential("smtp_username", "smtp_password");   //potrzeba ukrycia tych danych
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("Wiadomość została wysłana", "Potwierdzenie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearFields();
            }
            else
            {
                MessageBox.Show("Wszystkie pola są wymagane. Sprawdź ponownie dane w formularzu.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private bool validationOfFields()
        {
            foreach (var x in textBoxList)
            {
                if(x.Text == "")
                {
                    return false;
                }
            }
            return true;
        }

        private void clearFields()
        {
            foreach(var x in textBoxList)
            {
                x.Text = "";
            }

        }

    }
}

