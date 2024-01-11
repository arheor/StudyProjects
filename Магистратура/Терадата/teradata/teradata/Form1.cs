using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace teradata
{
    public partial class Form1 : Form
    {
        List<string> l = new List<string>();
        List<Control> dateApp;
        public Form1()
        {
            InitializeComponent();
            l.Add("Name");
            l.Add("Phone");
            l.Add("Login");
            l.Add("Password");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int loc = 0;
            this.Size = new Size(702, 306);
            dateApp = new List<Control>();
            foreach (string item in l)
            {
                Label l1 = new Label()
                {
                    Location = new Point(355, 42 + loc),
                    Text = item,
                    AutoSize = true,
                    Font = new Font("Monotype Corsiva", 12)
                };
                TextBox l2 = new TextBox()
                {
                    Location = new Point(450, 42 + loc),
                    Size = new Size(170, 25),
                    AutoSize = true,
                    Font = new Font("Monotype Corsiva", 12)
                };
                loc += 45;
                this.Controls.Add(l1);
                this.Controls.Add(l2);
                dateApp.Add(l2);
            }
            Button l3 = new Button()
            {
                Location = new Point(400, 42 + loc),
                Size = new Size(170, 25),
                Text = "Create",
                AutoSize = true,
                Font = new Font("Monotype Corsiva", 12),
                BackColor = Color.White
            };
            this.Controls.Add(l3);
            l3.Click += button_Click;
        }
        private void button_Click(object sender, EventArgs e)
        {
            using (Entities db = new Entities())
            {
                var emp = db.employee12345;
                emp.Add(new employee12345
                {
                    first_name = dateApp[0].Text,
                    phone_number = dateApp[1].Text,
                    login = dateApp[2].Text,
                    emp_password = dateApp[3].Text
                }
                );
                db.SaveChanges();
            }
            this.Size = new Size(302, 306);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (Entities db = new Entities())
            {
                var emp = db.employee12345.FirstOrDefault(p => (p.login.Trim() == textBox1.Text) && (p.emp_password.Trim() == textBox2.Text));
                if (emp == null)
                {
                    MessageBox.Show("Вы не зарегистрированы. Пожалуйста, создайте аккаунт");
                }
                else
                {
                    db.enter.Add(new enter
                    {
                        id = emp.id,
                        date_enter = DateTime.Now.ToString()
                    }
                    );
                    db.SaveChanges();
                    var entered = db.employee12345.Join(db.enter,
                        p => p.id,
                        c => c.id,
                        (p, c) => new
                        {
                            id = p.id,
                            date = c.date_enter
                        }
                        ).Where(p => p.id == emp.id);
                    string entered1 = "";
                    foreach (var en in entered)
                    {
                        entered1 += " " + en.date + Environment.NewLine;
                    }
                    MessageBox.Show(entered1, "Посещение приложения");
                }

            }
        }
    }
}
