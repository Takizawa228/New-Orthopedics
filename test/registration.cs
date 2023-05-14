using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace test
{
    public partial class registration : Form
    {
        data data = new data();
        
        public registration()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            
        }
        private void registration_Load(object sender, EventArgs e)
        {
            textBox2_pass.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {   var login = textBox1_log.Text;
            var password = textBox2_pass.Text;

            if ((textBox1_log.Text == "") || (textBox2_pass.Text == ""))
            {
                MessageBox.Show("Заполните все строчки!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(password.Length > 8)
            {
                MessageBox.Show("Максимальная длина пароля 8 символов!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (password.Length < 4)
            {
                MessageBox.Show("Минимальная длина пароля 4 символов!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (checkUser())
            {
                return;
            }
            
            string querystring = $"insert into register (login_user, password_user, is_admin) values ('{login}','{md5.hashPassword(password)}', 0)";

            SqlCommand command = new SqlCommand(querystring, data.GetConnection());

            data.openConnection();
            
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт успешно создан!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 form1 = new Form1();
                this.Hide();
                form1.ShowDialog();

            }
            else
                MessageBox.Show("Аккаунт не создан!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            data.closeConnection();
            
        }
        private Boolean checkUser()
        {
            var loginUser = textBox1_log.Text;
            
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select id_user, login_user, password_user, is_admin from register where login_user = '{loginUser}'";

            SqlCommand command = new SqlCommand(querystring, data.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count > 0) 
            {
                MessageBox.Show("Аккаунт существует!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            else { return false; }
        }
        private void checkpass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkpass.Checked)
            {
                textBox2_pass.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2_pass.UseSystemPasswordChar = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
