using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
        data data = new data();
        public Form1()
        {
            
            InitializeComponent();
        }
        private void ClearFields()
        {
            login.Text = "";
            password.Text = "";
        }
        private void button_authorization_Click(object sender, EventArgs e)
        {
            var loginUser = login.Text;
            var passwordUser = md5.hashPassword(password.Text);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select id_user, login_user, password_user, is_admin from register where login_user = '{loginUser}' and password_user = '{passwordUser}'";

            SqlCommand command = new SqlCommand(querystring, data.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count == 1)
            {
                var user = new administration(table.Rows[0].ItemArray[1].ToString(), Convert.ToBoolean(table.Rows[0].ItemArray[3]));

                MessageBox.Show("Вы успешно вошли!","Успешно!", MessageBoxButtons.OK,MessageBoxIcon.Information);
                
                MainWindow mainWindow = new MainWindow(user);
                mainWindow.Show();
                Hide();
                ClearFields();
            }
            else if (login.Text=="" || password.Text=="")
                MessageBox.Show("Заполните все поля!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            else
                MessageBox.Show("Не верный логин или пароль!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
        }

        private void login_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            password.UseSystemPasswordChar = true;
        }

        private void checkpass_CheckedChanged(object sender, EventArgs e)
        {
            if(checkpass.Checked)
            {
                password.UseSystemPasswordChar = false;
            }
            else
            {
                password.UseSystemPasswordChar = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            registration reg = new registration();
            reg.ShowDialog();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
