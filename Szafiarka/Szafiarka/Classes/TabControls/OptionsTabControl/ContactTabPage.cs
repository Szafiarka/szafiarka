using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szafiarka.Classes
{
    class ContactTabPage : OptionsTabPages
    {
        List<ErrorProvider> errorProviders;
        bool[] errors;
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
                    comboBoxCategories.Location = new Point(300, 95 + i * 65);
                    comboBoxCategories.Size = new Size(400, 30);
                    comboBoxCategories.Name = LABELNAMES[i, 0].ToString();
                    comboBoxCategories.Font = new Font("Arial", 12);
                    comboBoxCategories.Items.Add("Pytanie");
                    comboBoxCategories.Items.Add("Problem");
                    comboBoxCategories.Items.Add("Sugestia");
                    comboBoxCategories.Items.Add("Błąd");
                    comboBoxCategories.Items.Add("Inne");
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
                    textBox.Size = new Size(290, 30);
                    textBox.ReadOnly = true;
                }

                textBoxList.Add(textBox);
                Controls.Add(textBox);
                textBox.BringToFront();
                textBox.TextChanged += textBoxOut_Leave;
            }
            initializeErrorProviders((LABELNAMES.Length / 2)-2);
        }

        private void initializeErrorProviders(int n)
        {
            errorProviders = new List<ErrorProvider>(n);
            errors = new bool[n];
            ErrorProvider tmp;
            for (int i=0; i<n; i++)
            {
                errors[i] = false;
                tmp = new ErrorProvider();
                tmp.BlinkStyle = ErrorBlinkStyle.NeverBlink;
                errorProviders.Add(tmp);
            }
        }

       private void textBoxOut_Leave(object sender, EventArgs e)
        {
            TextBox something = (TextBox)sender;
            switch (something.Name)
            {
                case "name":
                    if (something.TextLength < 4)
                    {
                        errorProviders[0].Icon = Properties.Resources.ERR;
                        errorProviders[0].SetError(textBoxList[0], "Podpis musi mieć więcej niż 4 znaki!");
                        errors[0] = false;
                    }
                    else
                    {
                        errorProviders[0].Icon = Properties.Resources.OK;
                        errorProviders[0].SetError(textBoxList[0], "OK");
                        errors[0] = true;
                    }
                    break;
                case "email":
                    if (!(isValidEmail(something.Text)))
                    {
                        errorProviders[1].Icon = Properties.Resources.ERR;
                        errorProviders[1].SetError(textBoxList[1], "Wpisana fraza nie jest adresem mailowym!");
                        errors[1] = false;
                    }
                    else
                    {
                        errorProviders[1].Icon = Properties.Resources.OK;
                        errorProviders[1].SetError(textBoxList[1], "OK");
                        errors[1] = true;
                    }
                    break;
                case "topic":
                    if (something.TextLength < 10)
                    {
                        errorProviders[2].Icon = Properties.Resources.ERR;
                        errorProviders[2].SetError(textBoxList[2], "Temat wiadomości nie może być krótszy niż 10 znaków.");
                        errors[2] = false;
                    }
                    else
                    {
                        errorProviders[2].Icon = Properties.Resources.OK;
                        errorProviders[2].SetError(textBoxList[2], "OK");
                        errors[2] = true;
                    }
                    break;
                case "message":
                    if (something.TextLength < 50)
                    {
                        errorProviders[3].Icon = Properties.Resources.ERR;
                        errorProviders[3].SetError(textBoxList[3], "Treść wiadomości musi zawierać co najmniej 50 znaków");
                        errors[3] = false;
                    }
                    else
                    {
                        errorProviders[3].Icon = Properties.Resources.OK;
                        errorProviders[3].SetError(textBoxList[3], "OK");
                        errors[3] = true;
                    }
                    break;
            }
        }
        bool isValidEmail(string email)
        {
            Regex regex = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", RegexOptions.Compiled);
            Match match = regex.Match(email);
            if (match.Success)
                return true;
            else
                return false;
        }

        private void initializeButtons()
        {
            sendButton = new FlatButton
            {
                Size = new Size(140, 60),
                Location = new Point(750, 570 - 60),
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
            if (validationOfFields())
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
                SmtpServer.Credentials = new NetworkCredential(DBconnection.DBCONNECTION.Email_settings.FirstOrDefault().user, DBconnection.DBCONNECTION.Email_settings.FirstOrDefault().pwd);   //potrzeba ukrycia tych danych
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("Wiadomość została wysłana", "Potwierdzenie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearFields();
            }
            else
            {
                MessageBox.Show("Wiadomośc nie mogła zostać wysłana. Sprawdź ponownie dane w formularzu", "Potwierdzenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool validationOfFields()
        {

            foreach (bool x in errors)
            {
                if (x == false)
                    return false;
            }
            return true;
        }

        private void clearFields()
        {
            foreach (var x in textBoxList)
            {
                x.Text = "";
            }
            comboBoxCategories.SelectedIndex = 0;
        }
    }
}