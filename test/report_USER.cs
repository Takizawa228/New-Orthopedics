using CrystalDecisions.CrystalReports.Engine;
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
using CrystalDecisions.Shared;

namespace test
{
    public partial class report_USER : Form
    {
        data data = new data();
        public report_USER()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd.MM.yyyy";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Пустое поле!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (textBox2.Text == "")
            {
                textBox2.BackColor = Color.Red;
                MessageBox.Show("Напишите свое имя в строку!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlDataAdapter dr;

                data.openConnection();

                SqlCommand cmd = new SqlCommand("select * from productsUser_db where name_of = '" + textBox1.Text + "'", data.GetConnection());

                DataTable dt = new DataTable();
                dr = new SqlDataAdapter(cmd);
                dr.Fill(dt);

                CrystalReport_USER c = new CrystalReport_USER();
                c.Database.Tables["productsUser_db"].SetDataSource(dt);

                this.crystalReportViewer1.ReportSource = c;
                //Вывод сотрудника 2 строчки
                TextObject TextName = (TextObject)c.ReportDefinition.Sections["Section1"].ReportObjects["Text13"];
                TextName.Text = textBox2.Text;

                data.closeConnection();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
                MessageBox.Show("Не правильно выбран диапазон дат!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (textBox2.Text == "")
            {
                textBox2.BackColor = Color.Red;
                MessageBox.Show("Напишите свое имя в строку!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlDataAdapter dr;

                data.openConnection();
                SqlCommand cmd = new SqlCommand($"select * from productsUser_db where date_admission BETWEEN @d1 AND @d2", data.GetConnection());

                cmd.Parameters.Add("@d1", SqlDbType.Date).Value = dateTimePicker1.Value;
                cmd.Parameters.Add("@d2", SqlDbType.Date).Value = dateTimePicker2.Value;
                DataTable dt = new DataTable();
                dr = new SqlDataAdapter(cmd);
                dr.Fill(dt);

                CrystalReport_USER c = new CrystalReport_USER();
                c.Database.Tables["productsUser_db"].SetDataSource(dt);

                this.crystalReportViewer1.ReportSource = c;
                //Вывод сотрудника 2 строчки
                TextObject TextName = (TextObject)c.ReportDefinition.Sections["Section1"].ReportObjects["Text13"];
                TextName.Text = textBox2.Text;

                data.closeConnection();
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.White;
        }
    }
}
