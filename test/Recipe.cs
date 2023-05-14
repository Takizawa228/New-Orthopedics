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
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Globalization;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using MySqlX.XDevAPI.Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Web.UI.WebControls;
using System.Windows.Controls;


namespace test
{
    enum Rowstat
    {
        Existe,
        Ne,
        Modfiel,
        Modfieldne,
        Delete
    }
    public partial class Recipe : Form
    {
        data data = new data();

        int selectedRow;
        
        public Recipe()
        {
            InitializeComponent();
            dateTimePicker1_admission.Format = DateTimePickerFormat.Custom;
            dateTimePicker1_admission.CustomFormat = "dd.MM.yyyy";
            dateTimePicker2_filter1.Format = DateTimePickerFormat.Custom;
            dateTimePicker2_filter1.CustomFormat = "dd.MM.yyyy";
            dateTimePicker3_filter2.Format = DateTimePickerFormat.Custom;
            dateTimePicker3_filter2.CustomFormat = "dd.MM.yyyy";
            //добавил
            dateTimePicker4_term.Format = DateTimePickerFormat.Custom;
            dateTimePicker4_term.CustomFormat = "dd.MM.yyyy";
        }
        //Создание колонок для таблицы
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
        //Метод очистки
        private void ClearFields()
        {
            textBox1_id.Text = "";
            textBox2_name.Text = "";
            textBox3_categorion.Text = "";
            textBox4_count.Text = "";
            textBox5_manufacturer.Text = "";
            textBox6_price.Text = "";
            comboBox2_Categories.Text = "";
            textBox7_search.Text = "";
            textBox8_buy.Text = "";
        }
        private void ReadSingleRow(DataGridView dgw, IDataRecord record)
        {
            //Добавил record.GetDateTime(4)
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetDateTime(3), record.GetDateTime(4), record.GetInt32(5), record.GetString(6), record.GetInt32(7), Rowstat.Modfieldne);
        }
        //private void colorExpiredProducts()
        //{
        //    // получаем текущую дату
        //    DateTime today = DateTime.Today;

        //    foreach (DataGridViewRow row in dataGridView1.Rows)
        //    {
                
        //        // получаем дату поступления товара и срок годности
        //        DateTime dateReceived = Convert.ToDateTime(row.Cells["date_admission"].Value);
        //        DateTime expiryDays = Convert.ToDateTime(row.Cells["date_term"].Value);

        //        // вычисляем дату истечения срока годности
        //        DateTime expiryDate = dateReceived.AddDays(expiryDays);

        //        if (expiryDate <= today.AddDays(5))
        //        {
        //            // закрашиваем ячейку столбца "Срок годности товара"
        //            row.Cells["date_term"].Style.BackColor = Color.Red;
        //        }
        //    }
        //}
        //Фильтр через dateTimePicker
        private void SearchDate(DataGridView dgw)
        {
            if (dateTimePicker2_filter1.Value.Date > dateTimePicker3_filter2.Value.Date)
            {
                MessageBox.Show("Не правильно выбран диапазон дат!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
             dgw.Rows.Clear();

            data.openConnection();
            SqlCommand cmd = new SqlCommand($"select * from proAD_db where date_admission BETWEEN @d1 AND @d2", data.GetConnection());

            cmd.Parameters.Add("@d1", SqlDbType.Date).Value = dateTimePicker2_filter1.Value;
            cmd.Parameters.Add("@d2", SqlDbType.Date).Value = dateTimePicker3_filter2.Value;
            
            
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

            string query = $"select * from proAD_db where type_of = '" + comboBox2_Categories.Text.ToString() + "'";
            SqlCommand com = new SqlCommand(query, data.GetConnection());
            SqlDataReader read = com.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRow(dgw, read);
                
            }
            read.Close();
            
            data.closeConnection();
        }
        //Фильтр через Textbox
        private void Search(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from proAD_db where concat (id, name_of, postavka) like '%" + textBox7_search.Text + "%'";

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
        //Метод загрузки ComboBox
        private void LoadCombobox()
        {
            DataTable dt = new DataTable();
            data.openConnection();
            // создаем команду для выборки данных в БД
            SqlCommand cmd = new SqlCommand("SELECT DISTINCT type_of FROM proAD_db ORDER BY type_of", data.GetConnection());

            // создаем адаптер для заполнения DataTable с помощью команды SQL
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            // заполняем DataTable
            adapter.Fill(dt);

            // перебираем строки в DataTable и добавляем их в ComboBox, если они уникальны
            foreach (DataRow row in dt.Rows)
            {
                string value = row["type_of"].ToString().Trim();
                if (!comboBox2_Categories.Items.Contains(value))
                {
                    comboBox2_Categories.Items.Add(value);
                }
            }
            data.closeConnection();
        }
        //Метод обновления данных в таблице
        private void RefreshDataGrid(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from proAD_db";

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
                    dataGridView1.Rows[index].Cells[8].Value = Rowstat.Delete;
                    return;
                }
            
                dataGridView1.Rows[index].Cells[8].Value = Rowstat.Delete;
            } 
                
        }
        //Метод обновления строки
        private void Update()
        {
            data.openConnection();

            for (int index = 0; index < dataGridView1.Rows.Count; index++) 
            { 
                //изменил с 7 на 8
                var rowStat = (Rowstat)dataGridView1.Rows[index].Cells[8].Value;

                if (rowStat == Rowstat.Existe)
                    continue;

                if(rowStat == Rowstat.Delete)
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var delete = $"delete from proAD_db where id = {id}";

                    var command = new SqlCommand (delete, data.GetConnection());
                    command.ExecuteNonQuery();
                }
                if (rowStat == Rowstat.Modfiel)
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

                    var changeQuery = $"update proAD_db set name_of = '{name}', type_of = '{type}', date_admission='{date1}', date_term='{dateT}', count_of = '{count}', postavka = '{postavka}', price = '{price}' where id = '{id}'";
                    
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
            var id = textBox1_id.Text;
            var name = textBox2_name.Text;
            var type = textBox3_categorion.Text;
            var date = dateTimePicker1_admission.Text;
            //добавил и изменил с 7 на 8
            var date1 = dateTimePicker4_term.Text;
            //добавил маску на количество
            int count;
            var postav = textBox5_manufacturer.Text;
            int price;
            //Максильмальное количество
            int a = 5000;
            var b = textBox4_count.Text.ToString();
            int price_max = 1000000;
            var price_textbox = textBox6_price.Text.ToString();
            int value1;
            int value2;
                if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
                {
                    //Новое условие на проверку текста
                    if ((textBox1_id.Text == "") || (textBox2_name.Text == "") || (textBox3_categorion.Text == "") || (textBox4_count.Text == "") || (textBox6_price.Text == "") || (textBox5_manufacturer.Text == ""))
                        MessageBox.Show("Заполните пустые строчки!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else if (dateTimePicker1_admission.Value.Date >= dateTimePicker4_term.Value.Date)
                        MessageBox.Show("Срок годности должен быть больше дня поставки!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //новые условия на проверку нуля
                    else if ((int.TryParse(textBox4_count.Text, out value1) && value1 == 0) || int.TryParse(textBox6_price.Text, out value2) && value2 == 0)
                        MessageBox.Show("Введен ноль!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        //условие на проверку цифр
                        if (int.TryParse(textBox6_price.Text, out price) && int.TryParse(textBox4_count.Text, out count))
                        {
                            if (Convert.ToInt32(b) > a)
                                MessageBox.Show("Максимальный запас на единицу продукции равно 5000", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            else if (Convert.ToInt32(price_textbox) > price_max)
                                MessageBox.Show("Максимальная цена 1000000!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            else
                            {
                            dataGridView1.Rows[selectedRowIndex].SetValues(id, name, type, date, date1, count, postav, price);
                            dataGridView1.Rows[selectedRowIndex].Cells[8].Value = Rowstat.Modfiel;
                            }
                        }
                        else
                            MessageBox.Show("Строка количество и цена должны иметь числовой формат!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                }
            }
            
        }
        private void Recipe_Load(object sender, EventArgs e)
        {
            CreateColums();
            RefreshDataGrid(dataGridView1);
            //ДОБАВИЛ скрытие элемента
            textBox1_id.Visible = false;

            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;
        }
        //Заполнение таблицы
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];
                textBox1_id.Text = row.Cells[0].Value.ToString();
                
                textBox2_name.Text = row.Cells[1].Value.ToString();
                textBox3_categorion.Text = row.Cells[2].Value.ToString();
                dateTimePicker1_admission.Text = row.Cells[3].Value.ToString();
                //Добавил 
                dateTimePicker4_term.Text = row.Cells[4].Value.ToString();

                textBox4_count.Text = row.Cells[5].Value.ToString();
                textBox5_manufacturer.Text = row.Cells[6].Value.ToString();
                textBox6_price.Text = row.Cells[7].Value.ToString();
                
            }

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            RefreshDataGrid(dataGridView1);
            ClearFields();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            New_entry new_entry = new New_entry();
            new_entry.Show();
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            deleteRow();
            ClearFields();
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Update();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Change();
            ClearFields();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //colorExpiredProducts();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            SearchDate(dataGridView1);
            
        }
        private void comboBox2_Click(object sender, EventArgs e)
        {
            LoadCombobox();
            
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filter(dataGridView1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            report report = new report();
            report.Show();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            
        }
        //Кнопка продажи
        private void button7_Click(object sender, EventArgs e)
        {
            
            data.openConnection();

            int value;
            if (int.TryParse(textBox8_buy.Text, out value) && value == 0)
                MessageBox.Show("Введен ноль!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //if (textBox8_buy.Text == "0")
            //MessageBox.Show("Введен ноль!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        var changeQuery = $"update proAD_db set count_of = {count}-{result} where id = '{id}'";

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

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_count_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 7) // индекс столбца цены
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal price))
                {
                    e.Value = price.ToString("#,## ₽");
                    e.FormattingApplied = true;
                }
            }
            if (e.ColumnIndex == 5) // индекс столбца цены
            {
                if (e.Value != null && decimal.TryParse(e.Value.ToString(), out decimal price1))
                {
                    e.Value = price1.ToString("#,## Шт.");
                    e.FormattingApplied = true;
                }
            }
        }

        private void textBox8_buy_TextChanged(object sender, EventArgs e)
        {

        }

        private void Recipe_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }
    }
}
