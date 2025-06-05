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
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
            CreatePanel();
        }
        public void CreatePanel()
        {
            DB.sqlcon.Open();
            SqlCommand sqlCommand = new SqlCommand("select * from Sales_import$", DB.sqlcon);
            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Panel panel = new Panel()
                {
                    Height = 100,
                    Width = 600,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(5),
                    BackColor = Color.Black
                };

                Label label = new Label()
                {
                    Text = reader["Наименование продукции"].ToString(),
                    Font = new Font("Sitka Heading", 12, FontStyle.Bold),
                    ForeColor = Color.White,
                    Top = 25,
                    Left = 5,
                    AutoSize = true
                };

                Label label1 = new Label()
                {
                    Text = reader["отч_клиента"].ToString() +" "+ reader["имя_клиента"].ToString() + " "+ reader["фам_клиента"],
                    Font = new Font("Sitka Heading", 12, FontStyle.Regular),
                    ForeColor = Color.White,
                    Top = 45,
                    Left = 5,
                    AutoSize = true
                };

                Label label2 = new Label()
                {
                    Text = "Количество: " + reader["Колличество"].ToString(),
                    Font = new Font("Sitka Heading", 12, FontStyle.Regular),
                    ForeColor = Color.White,
                    Top = 65,
                    Left = 5,
                    AutoSize = true
                };
                Label label3 = new Label()
                {
                    Text = "Дата продажи: " + reader["Дата продажи"].ToString(),
                    Font = new Font("Sitka Heading", 12, FontStyle.Regular),
                    ForeColor = Color.White,
                    Top = 1,
                    Left = 5,
                    AutoSize = true
                };
                panel.Controls.Add(label);
                panel.Controls.Add(label1);
                panel.Controls.Add(label2);
                panel.Controls.Add(label3);
                flowLayoutPanel1.Controls.Add(panel);
            }
            reader.Close();
            DB.sqlcon.Close();
        }
        private void History_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Show();
        }
    }
}
