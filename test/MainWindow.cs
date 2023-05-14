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
using System.Data.Common;
using System.Threading;
namespace test
{
    enum Rowstate
    {
        Existed,
        New,
        Modfield,
        Modfieldnew,
        Deleted
    }

    public partial class MainWindow : Form
    {
        private readonly administration _administration;

        data data = new data();

        int selectedRow;

        private SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
        public MainWindow(administration administration1)
        {
            InitializeComponent();
            _administration = administration1;

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd.MM.yyyy";
            dateTimePicker1_ADM.Format = DateTimePickerFormat.Custom;
            dateTimePicker1_ADM.CustomFormat = "dd.MM.yyyy";
            //добавил
            dateTimePicker4_TERM.Format = DateTimePickerFormat.Custom;
            dateTimePicker4_TERM.CustomFormat = "dd.MM.yyyy";
            
        }

        public MainWindow()
        {
            
        }

        private void isAdmin()
        {
            button_Administration.Enabled = _administration.IsAdmin;
        }
        private void CreateColums()
        {
            dataGridView1.Columns.Add("id", "id");
            //добавил скрытие колонки
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns.Add("name_of", "Название");
            dataGridView1.Columns.Add("type_of", "Категория");
            dataGridView1.Columns.Add("date_admission", "Дата");
            //Добавил
            dataGridView1.Columns.Add("date_term", "Срок годности");
            dataGridView1.Columns.Add("count_of", "Количество");
            dataGridView1.Columns.Add("postavka", "Производитель");
            dataGridView1.Columns.Add("price", "Цена");

            dataGridView1.Columns.Add("Isnew", string.Empty);
            //добавил скрытие колонки
            dataGridView1.Columns[8].Visible = false;
        }

        private void ClearFields()
        {
            textBox1_ID.Text = "";
            textBox2_NAME.Text = "";
            textBox3_CATEGORION.Text = "";
            textBox4_COUNT.Text = "";
            textBox5_MANU.Text = "";
            textBox6_PRICE.Text = "";
            textBox8_buy.Text = "";
            textBox_Search.Text = "";
            comboBox1.Text = "";
        }

        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            //Добавил record.GetDateTime(4)
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetDateTime(3), record.GetDateTime(4), record.GetInt32(5), record.GetString(6), record.GetInt32(7), Rowstate.Modfieldnew);
        }
        //Обновление таблицы
        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from productsUser_db";

            SqlCommand command = new SqlCommand(queryString, data.GetConnection());

            data.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dgw, reader);
            }
            reader.Close();

            dataGridView1.Columns[3].DefaultCellStyle.Format = "dd.MM.yyyy";
            //Добавил
            dataGridView1.Columns[4].DefaultCellStyle.Format = "dd.MM.yyyy";

            data.closeConnection();
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            label8.Text = $"{_administration.Login}: {_administration.Status}";

            isAdmin();
            CreateColums();
            RefreshDataGrid(dataGridView1);
            textBox1_ID.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //Очистка Записи
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                textBox1_ID.Text = row.Cells[0].Value.ToString();

                textBox2_NAME.Text = row.Cells[1].Value.ToString();
                textBox3_CATEGORION.Text = row.Cells[2].Value.ToString();
                dateTimePicker1_ADM.Text = row.Cells[3].Value.ToString();
                //Добавил 
                dateTimePicker4_TERM.Text = row.Cells[4].Value.ToString();

                textBox4_COUNT.Text = row.Cells[5].Value.ToString();
                textBox5_MANU.Text = row.Cells[6].Value.ToString();
                textBox6_PRICE.Text = row.Cells[7].Value.ToString();

            }

        }
        //Переход на окно "новая запись"
        private void button1_record_Click(object sender, EventArgs e)
        {
            NewEntry newentry = new NewEntry();
            newentry.Show();
          
        }
        private void SearchDate(DataGridView dgw)
        {
            if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
            {
                MessageBox.Show("Не правильно выбран диапазон дат!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                dgw.Rows.Clear();

                data.openConnection();
                SqlCommand cmd = new SqlCommand($"select * from productsUser_db where date_admission BETWEEN @d1 AND @d2", data.GetConnection());

                cmd.Parameters.Add("@d1", SqlDbType.Date).Value = dateTimePicker1.Value;
                cmd.Parameters.Add("@d2", SqlDbType.Date).Value = dateTimePicker2.Value;


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ReadSingleRow(dgw, reader);
                }
                reader.Close();

                data.closeConnection();
            }

        }
        //Фильтр через ComboBox
        private void Filter(DataGridView dgw)
        {
            data.openConnection();

            dgw.Rows.Clear();

            string query = $"select * from productsUser_db where type_of = '" + comboBox1.Text.ToString() + "'";
            SqlCommand com = new SqlCommand(query, data.GetConnection());
            SqlDataReader read = com.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRow(dgw, read);

            }
            read.Close();

            data.closeConnection();
        }
        private void LoadCombobox()
        {
            DataTable dt = new DataTable();
            data.openConnection();
            // создаем команду для выборки данных в БД
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT type_of FROM productsUser_db ORDER BY type_of", data.GetConnection());

            // создаем адаптер для заполнения DataTable с помощью команды SQL
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            // заполняем DataTable
            adapter.Fill(dt);

            // перебираем строки в DataTable и добавляем их в ComboBox, если они уникальны
            foreach (DataRow row in dt.Rows)
            {
                string value = row["type_of"].ToString().Trim();
                if (!comboBox1.Items.Contains(value))
                {
                    comboBox1.Items.Add(value);
                }
            }
            data.closeConnection();
        }
        //Фильтр через Textbox
        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from productsUser_db where concat (id, name_of, postavka) like '%" + textBox_Search.Text + "%'";

            SqlCommand com = new SqlCommand(searchString, data.GetConnection());

            data.openConnection();

            SqlDataReader read = com.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRow(dgw, read);
            }
            read.Close();

            data.closeConnection();
        }
        //Метод удаление строки
        private void deleteRow()
        {
            if (dataGridView1 != null)

                if (dataGridView1.CurrentCell != null)
                { }
                else
                    MessageBox.Show("Выберите строку для удаления!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
            {
                //Этот код находился в не условия if
                int index = dataGridView1.CurrentCell.RowIndex;

                dataGridView1.Rows[index].Visible = false;

                if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
                {
                    //изменил с 7 на 8
                    dataGridView1.Rows[index].Cells[8].Value = Rowstate.Deleted;
                    return;
                }

                dataGridView1.Rows[index].Cells[8].Value = Rowstate.Deleted;
            }
        }
        //Метод обновления строки
        private void Update()
        {
            data.openConnection();

            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                //изменил с 7 на 8
                var rowStat = (Rowstate)dataGridView1.Rows[index].Cells[8].Value;

                if (rowStat == Rowstate.Existed)
                    continue;

                if (rowStat == Rowstate.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var delete = $"delete from productsUser_db where id = {id}";

                    var command = new SqlCommand(delete, data.GetConnection());
                    command.ExecuteNonQuery();
                }
                if (rowStat == Rowstate.Modfield)
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var name = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    var type = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    var date = dataGridView1.Rows[index].Cells[3].Value;
                    //Добавил
                    var dateTerm = dataGridView1.Rows[index].Cells[4].Value;

                    var count = dataGridView1.Rows[index].Cells[5].Value.ToString();
                    var postavka = dataGridView1.Rows[index].Cells[6].Value.ToString();
                    var price = dataGridView1.Rows[index].Cells[7].Value.ToString();
                    var date1 = DateTime.Parse(date.ToString());
                    //Добавил
                    var dateT = DateTime.Parse(dateTerm.ToString());

                    var changeQuery = $"update productsUser_db set name_of = '{name}', type_of = '{type}', date_admission='{date1}', date_term='{dateT}', count_of = '{count}', postavka = '{postavka}', price = '{price}' where id = '{id}'";

                    var command = new SqlCommand(changeQuery, data.GetConnection());
                    command.ExecuteNonQuery();
                }
            }
            data.closeConnection();
        }
        //Метод изменения информации в строки
        private void Change()
        {
            //Добавил условия на нажатие много раз по кнопке
            if (dataGridView1 != null)

                if (dataGridView1.CurrentCell != null)
                { }
                else
                    MessageBox.Show("Выберите строку для изменения!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.Value != null)
            {
                //Этот код находился в не условия if
                var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
                var id = textBox1_ID.Text;
                var name = textBox2_NAME.Text;
                var type = textBox3_CATEGORION.Text;
                var date = dateTimePicker1_ADM.Text;
                //добавил и изменил с 7 на 8
                var date1 = dateTimePicker4_TERM.Text;
                //добавил маску на количество
                int count;
                var postav = textBox5_MANU.Text;
                int price;
                //Максильмальное количество
                int a = 5000;
                var b = textBox4_COUNT.Text.ToString();
                int price_max = 1000000;
                var price_textbox = textBox6_PRICE.Text.ToString();
                int value1;
                //int value2;
                if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
                {
                    //Новое условие на проверку текста
                    if ((textBox1_ID.Text == "") || (textBox2_NAME.Text == "") || (textBox3_CATEGORION.Text == "") || (textBox4_COUNT.Text == "") || (textBox6_PRICE.Text == "") || (textBox5_MANU.Text == ""))
                        MessageBox.Show("Заполните пустые строчки!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (dateTimePicker1_ADM.Value.Date >= dateTimePicker4_TERM.Value.Date)
                        MessageBox.Show("Срок годности должен быть больше дня поставки!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //новые условия на проверку нуля
                    else if ((int.TryParse(textBox4_COUNT.Text, out value1) && value1 == 0) || int.TryParse(textBox6_PRICE.Text, out value1) && value1 == 0)
                        MessageBox.Show("Введен ноль!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        //условие на проверку цифр
                        if (int.TryParse(textBox6_PRICE.Text, out price) && int.TryParse(textBox4_COUNT.Text, out count))
                        {
                            if (Convert.ToInt32(b) > a)
                                MessageBox.Show("Максимальный запас на единицу продукции равно 5000", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            else if (Convert.ToInt32(price_textbox) > price_max)
                                MessageBox.Show("Максимальная цена 1000000!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            else
                            {
                                dataGridView1.Rows[selectedRowIndex].SetValues(id, name, type, date, date1, count, postav, price);
                                dataGridView1.Rows[selectedRowIndex].Cells[8].Value = Rowstate.Modfield;
                            }
                        }
                        else
                            MessageBox.Show("Строка количество и цена должны иметь числовой формат!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }

        }
        //TextBox для поиска товара
        private void textBox6_Search_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }
        //Кнопка удаления строки
        private void button2_delete_Click(object sender, EventArgs e)
        {
            deleteRow();
            ClearFields();
        }
        //Кнопка сохранения строки
        private void button4_save_Click(object sender, EventArgs e)
        {
            Update();
        }
        //Кнопка изменения строки
        private void button3_change_Click(object sender, EventArgs e)
        {
            Change();
            ClearFields();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void user1_TextChanged(object sender, EventArgs e)
        {

        }
        //Переход в окно "управление"
        private void button_administration_Click(object sender, EventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel();
            adminPanel.Show();
        }
        private void label9_Click(object sender, EventArgs e)
        {

        }
        //Выход из системы
        private void label10_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();

        }
        private void label8_Click(object sender, EventArgs e)
        {

        }
        //Окно о программе
        private void button_program_Click(object sender, EventArgs e)
        {
            AboutTheProgram atp = new AboutTheProgram();
            atp.Show();
        }
        //Обновление и очистка строк
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
            ClearFields();
        }
        //Фильтрация по категориям
        private void comboBox1_filter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter(dataGridView1);
        }
        private void comboBox1_filter_TextChanged(object sender, EventArgs e)
        {
            
        }
        //Кнопка для перехода в окно "препараты по рецепту"
        private void button1_prohibited_Click(object sender, EventArgs e)
        {
            Recipe recipe = new Recipe();
            recipe.Show();  
        }
        private void textBox5_ID_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox_Search_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }
        //Кнопка продажи
        private void button_Buy_Click(object sender, EventArgs e)
        {
            
            data.openConnection();

            int value3;
            if (int.TryParse(textBox8_buy.Text, out value3) && value3 == 0)
                MessageBox.Show("Введен ноль!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (!System.Text.RegularExpressions.Regex.IsMatch(textBox8_buy.Text, "^[0-9]*$"))
                MessageBox.Show("Вводите в поля цифры!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (textBox8_buy.Text != "")
                {
                    var index = dataGridView1.SelectedCells[0].RowIndex;
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    var result = textBox8_buy.Text.ToString();
                    var count = dataGridView1.Rows[index].Cells[5].Value.ToString();
                   
                    if (Convert.ToInt32(count) >= Convert.ToInt32(result))
                    {
                        var changeQuery = $"update productsUser_db set count_of = {count}-{result} where id = '{id}'";

                        var command = new SqlCommand(changeQuery, data.GetConnection());
                        command.ExecuteNonQuery();
                        MessageBox.Show("Продано!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshDataGrid(dataGridView1);

                        if (Convert.ToInt32(count) - Convert.ToInt32(result) == 0)
                            MessageBox.Show("Товар закончился,удалите или измените запись!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                        MessageBox.Show("Продаете больше чем есть!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("Количество не введено!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            data.closeConnection();
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            SearchDate(dataGridView1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter(dataGridView1);
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            LoadCombobox();
        }

        private void button_Print_Click(object sender, EventArgs e)
        {
            report_USER report_USER = new report_USER();
            report_USER.Show();
        }

        private void textBox8_buy_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ADM_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
