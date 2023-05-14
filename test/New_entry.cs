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
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace test
{
    public partial class New_entry : Form
    {
        data data = new data();
        public New_entry()
        {
            InitializeComponent();
            //добавил 
            dateTimePicker1_postavka.Format = DateTimePickerFormat.Custom;
            dateTimePicker1_postavka.CustomFormat = "dd.MM.yyyy";
            dateTimePicker2_crok.Format = DateTimePickerFormat.Custom;
            dateTimePicker2_crok.CustomFormat = "dd.MM.yyyy";
        }
        private void ClearFields()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            dateTimePicker1_postavka.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Огранечения ввода максимального числа Количество продукции и Цены.
            var a = 5000;
            var b = textBox4.Text.ToString();
            var price_max = 1000000;
            var price_textbox = textBox6.Text.ToString();
            int value;
            data.openConnection();

            //работает
            var query = "select name_of from proAD_db where name_of=@parm1";
            SqlCommand command1 = new SqlCommand(query, data.GetConnection());
            command1.Parameters.AddWithValue("parm1", textBox1.Text);
            SqlDataReader reader = command1.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("Такая запись есть!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox4.Text == "") || (textBox5.Text == "") || (textBox6.Text == ""))
            MessageBox.Show("Заполните пустые поля!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (!System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "^[0-9]*$") || !System.Text.RegularExpressions.Regex.IsMatch(textBox6.Text, "^[0-9]*$"))
            MessageBox.Show("Вводите в поля цифры!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (dateTimePicker1_postavka.Value.Date >= dateTimePicker2_crok.Value.Date)
                MessageBox.Show("Срок годности должен быть больше дня поставки!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (Convert.ToInt32(b) > Convert.ToInt32(a))
                MessageBox.Show("Максимальный запас на единицу продукции равно 5000!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (Convert.ToInt32(price_textbox) > Convert.ToInt32(price_max))
                MessageBox.Show("Максимальная цена за единицу продукции равно 1000000!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if ((int.TryParse(textBox4.Text, out value) && value == 0) || int.TryParse(textBox6.Text, out value) && value == 0)
                MessageBox.Show("Введен ноль!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                data.closeConnection();
                SqlCommand cmd = new SqlCommand("insert into proAD_db(name_of, type_of, date_admission, date_term, count_of, postavka, price) values(@name_of,@type_of,@date_admission,@date_term,@count_of,@postavka,@price)", data.GetConnection());
                cmd.Parameters.AddWithValue("name_of", textBox1.Text);
                cmd.Parameters.AddWithValue("type_of", textBox2.Text);
                cmd.Parameters.AddWithValue("date_admission", dateTimePicker1_postavka.Text);
                cmd.Parameters.AddWithValue("date_term", dateTimePicker2_crok.Text);
                cmd.Parameters.AddWithValue("count_of", textBox4.Text);
                cmd.Parameters.AddWithValue("postavka", textBox5.Text);
                cmd.Parameters.AddWithValue("price", textBox6.Text);
                data.openConnection();
                cmd.ExecuteNonQuery();
                data.closeConnection();
                MessageBox.Show("Запись успешно создана!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            data.closeConnection();

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void New_entry_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
