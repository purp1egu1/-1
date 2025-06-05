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
    public partial class AddClient : Form
    {
        public AddClient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("insert into Clients_import$ ([фамилия_клиента], [имя_клиента], [отчество_клиента]," +
                "[телефон_клиента], [элпочта_клиента], [Тип клиента]) values (@fam, @name, @otch, @tel, @el, @type)", DB.sqlcon);

            sqlCommand.Parameters.AddWithValue("fam", textBox1.Text);
            sqlCommand.Parameters.AddWithValue("name", textBox2.Text);
            sqlCommand.Parameters.AddWithValue("otch", textBox3.Text);
            sqlCommand.Parameters.AddWithValue("tel", textBox4.Text);
            sqlCommand.Parameters.AddWithValue("el", textBox5.Text);
            sqlCommand.Parameters.AddWithValue("type", textBox6.Text);

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            MessageBox.Show("Успешно!");
        }
    }
}
