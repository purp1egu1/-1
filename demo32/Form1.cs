using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demo32
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreatePanel();

        }

        public void CreatePanel()
        {
            DB.sqlcon.Open();
            SqlCommand sqlCommand = new SqlCommand("select * from Clients_import$", DB.sqlcon);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Panel panel = new Panel()
                {
                    Height = 70,
                    Width = 600,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(5),
                    BackColor = Color.Black
                };

                Label label = new Label()
                {
                    Text = reader["фамилия_клиента"].ToString() + " " + reader["имя_клиента"].ToString() + " " +
                    reader["отчество_клиента"].ToString(),
                    Font = new Font("Sitka Heading", 12, FontStyle.Bold),
                    ForeColor = Color.White,
                    Top = 1,
                    Left = 5,
                    AutoSize = true
                };

                Label label1 = new Label()
                {
                    Text = reader["телефон_клиента"].ToString() + "|" + reader["элпочта_клиента"].ToString(),
                    Font = new Font("Sitka Heading", 12, FontStyle.Regular),
                    ForeColor = Color.White,
                    Top = 25,
                    Left = 5,
                    AutoSize = true
                };

                Label label2 = new Label()
                {
                    Text = reader["Тип клиента"].ToString(),
                    Font = new Font("Sitka Heading", 12, FontStyle.Regular),
                    ForeColor = Color.White,
                    Top = 1,
                    Left = 345,
                    AutoSize = true
                };

                panel.Controls.Add(label);
                panel.Controls.Add(label1);
                panel.Controls.Add(label2);
                flowLayoutPanel1.Controls.Add(panel);
            }
            reader.Close();
            DB.sqlcon.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddClient addClient = new AddClient();
            this.Hide();
            addClient.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            redClient redClient = new redClient();
            this.Hide();
            redClient.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            History history = new History();
            this.Hide();
            history.Show();
        }
    }
}
