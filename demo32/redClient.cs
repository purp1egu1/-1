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
    public partial class redClient : Form
    {
        public redClient()
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
                    Top = 25,
                    Left = 5,
                    AutoSize = true
                };

                Label label1 = new Label()
                {
                    Text = reader["телефон_клиента"].ToString() + "|" + reader["элпочта_клиента"].ToString(),
                    Font = new Font("Sitka Heading", 12, FontStyle.Regular),
                    ForeColor = Color.White,
                    Top = 45,
                    Left = 5,
                    AutoSize = true
                };

                Label label2 = new Label()
                {
                    Text = reader["Тип клиента"].ToString(),
                    Font = new Font("Sitka Heading", 12, FontStyle.Regular),
                    ForeColor = Color.White,
                    Top = 25,
                    Left = 345,
                    AutoSize = true
                };
                Label label3 = new Label()
                {
                    Text = "ID клиента: " + reader["id_client"].ToString(),
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
        private void redClient_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("UPDATE Clients_import$ set [Тип клиента] = @type, [фамилия_клиента] = @fam, [имя_клиента] = @name, " +
                "[отчество_клиента] = @otch, [телефон_клиента] = @tel, [элпочта_клиента] = @el where [id_client] = @id", DB.sqlcon);

            sqlCommand.Parameters.AddWithValue("type", textBox4.Text);
            sqlCommand.Parameters.AddWithValue("fam", textBox1.Text);
            sqlCommand.Parameters.AddWithValue("name", textBox2.Text);
            sqlCommand.Parameters.AddWithValue("otch", textBox3.Text);
            sqlCommand.Parameters.AddWithValue("tel", textBox5.Text);
            sqlCommand.Parameters.AddWithValue("el", textBox6.Text);
            sqlCommand.Parameters.AddWithValue("id", textBox7.Text);

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            MessageBox.Show("Успешно!");
            
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }
    }
}
