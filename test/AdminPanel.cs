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
using System.Web.UI.WebControls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace test
{
    public partial class AdminPanel : Form
    {
        data data = new data();
        int selectedRow;
        public AdminPanel()
        {
            StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();

        }
        private void ClearFields()
        {
            textBox1.Text = "";
        }
        private void CreateColums()
        {
            dataGridView1.Columns.Add("id_user", "ID");
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns.Add("login", "Логин");
            dataGridView1.Columns.Add("password", "Пароль");
            var checkcolum = new DataGridViewCheckBoxColumn();
            checkcolum.HeaderText = "IsAdmin";
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns.Add(checkcolum);
        }
        private void ReadSingleRow(IDataRecord record)
        {
            dataGridView1.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetBoolean(3));
        }

        private void RefreshDataGrid()
        {
            dataGridView1.Rows.Clear();

            string query = $"select * from register";

            SqlCommand command = new SqlCommand(query, data.GetConnection());

            data.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(reader);
            }
            reader.Close();

            data.closeConnection();
        }
        private void AdminPanel_Load(object sender, EventArgs e)
        {
            CreateColums();
            RefreshDataGrid();
        }

        private void button1_save_Click(object sender, EventArgs e)
        {
            data.openConnection();

            for(int index =0; index < dataGridView1.Rows.Count; index++)
            {
                var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                var isadmin = dataGridView1.Rows[index].Cells[3].Value.ToString();

                var change = $"UPDATE register SET is_admin = '{isadmin}' WHERE id_user = '{id}'";

                var command = new SqlCommand(change, data.GetConnection());
                command.ExecuteNonQuery();
            }
            data.closeConnection();
            RefreshDataGrid();
        }

        private void button2_delete_Click(object sender, EventArgs e)
        {
            data.openConnection();

            var selected = dataGridView1.CurrentCell.RowIndex;

            var id = Convert.ToInt32(dataGridView1.Rows[selected].Cells[0].Value);
            var delete = $"DELETE FROM register WHERE id_user = {id}";

            var command = new SqlCommand(delete, data.GetConnection());
            command.ExecuteNonQuery();

            data.closeConnection();
            RefreshDataGrid();
        }
        private void button1_Click(object sender, EventArgs e)
        {   
            var password = textBox1.Text;

            if (textBox1.Text == "")
                MessageBox.Show("Введите пароль!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (password.Length > 8)
            {
                MessageBox.Show("Максимальная длина пароля 8 символов!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (password.Length < 4)
            {
                MessageBox.Show("Минимальная длина пароля 4 символов!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                data.openConnection();

                var index = dataGridView1.SelectedCells[0].RowIndex;
                var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                //var passwordUser = dataGridView1.Rows[index].Cells[2].Value.ToString();
            
                var change = $"UPDATE register SET password_user = '{md5.hashPassword(password)}' WHERE id_user = '{id}'";
            
                var command = new SqlCommand(change, data.GetConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Пароль изменен!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
                data.closeConnection();

                RefreshDataGrid();
                ClearFields();
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //selectedRow = e.RowIndex;
            //if (e.RowIndex >= 0)
            //{
            //    DataGridViewRow row = dataGridView1.Rows[selectedRow];
            //    textBox1.Text = row.Cells[2].Value.ToString();
            //}

        }
    }
}
