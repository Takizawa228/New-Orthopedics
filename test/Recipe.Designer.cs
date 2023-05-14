namespace test
{
    partial class Recipe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox1_id = new System.Windows.Forms.TextBox();
            this.textBox2_name = new System.Windows.Forms.TextBox();
            this.textBox3_categorion = new System.Windows.Forms.TextBox();
            this.textBox4_count = new System.Windows.Forms.TextBox();
            this.textBox5_manufacturer = new System.Windows.Forms.TextBox();
            this.textBox6_price = new System.Windows.Forms.TextBox();
            this.button1_newEntry = new System.Windows.Forms.Button();
            this.button2_delete = new System.Windows.Forms.Button();
            this.button3_save = new System.Windows.Forms.Button();
            this.button4_change = new System.Windows.Forms.Button();
            this.textBox7_search = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3_Name = new System.Windows.Forms.Label();
            this.label4_Categiron = new System.Windows.Forms.Label();
            this.label5_Count = new System.Windows.Forms.Label();
            this.label6_manufacturer = new System.Windows.Forms.Label();
            this.label7_price = new System.Windows.Forms.Label();
            this.pictureBox1_resh = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dateTimePicker2_filter1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker3_filter2 = new System.Windows.Forms.DateTimePicker();
            this.button5_search = new System.Windows.Forms.Button();
            this.comboBox2_Categories = new System.Windows.Forms.ComboBox();
            this.button6_print = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button7_buy = new System.Windows.Forms.Button();
            this.textBox8_buy = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox2_search = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePicker1_admission = new System.Windows.Forms.DateTimePicker();
            this.label10_admission = new System.Windows.Forms.Label();
            this.label13_term = new System.Windows.Forms.Label();
            this.dateTimePicker4_term = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1_resh)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2_search)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(826, 225);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // textBox1_id
            // 
            this.textBox1_id.Location = new System.Drawing.Point(61, 44);
            this.textBox1_id.Name = "textBox1_id";
            this.textBox1_id.Size = new System.Drawing.Size(16, 20);
            this.textBox1_id.TabIndex = 1;
            // 
            // textBox2_name
            // 
            this.textBox2_name.Location = new System.Drawing.Point(96, 86);
            this.textBox2_name.MaxLength = 50;
            this.textBox2_name.Name = "textBox2_name";
            this.textBox2_name.Size = new System.Drawing.Size(150, 20);
            this.textBox2_name.TabIndex = 2;
            // 
            // textBox3_categorion
            // 
            this.textBox3_categorion.Location = new System.Drawing.Point(96, 117);
            this.textBox3_categorion.MaxLength = 50;
            this.textBox3_categorion.Name = "textBox3_categorion";
            this.textBox3_categorion.Size = new System.Drawing.Size(150, 20);
            this.textBox3_categorion.TabIndex = 3;
            // 
            // textBox4_count
            // 
            this.textBox4_count.Location = new System.Drawing.Point(405, 86);
            this.textBox4_count.MaxLength = 8;
            this.textBox4_count.Name = "textBox4_count";
            this.textBox4_count.Size = new System.Drawing.Size(150, 20);
            this.textBox4_count.TabIndex = 4;
            this.textBox4_count.TextChanged += new System.EventHandler(this.textBox4_count_TextChanged);
            // 
            // textBox5_manufacturer
            // 
            this.textBox5_manufacturer.Location = new System.Drawing.Point(405, 117);
            this.textBox5_manufacturer.MaxLength = 50;
            this.textBox5_manufacturer.Name = "textBox5_manufacturer";
            this.textBox5_manufacturer.Size = new System.Drawing.Size(150, 20);
            this.textBox5_manufacturer.TabIndex = 5;
            // 
            // textBox6_price
            // 
            this.textBox6_price.Location = new System.Drawing.Point(405, 148);
            this.textBox6_price.MaxLength = 8;
            this.textBox6_price.Name = "textBox6_price";
            this.textBox6_price.Size = new System.Drawing.Size(150, 20);
            this.textBox6_price.TabIndex = 6;
            // 
            // button1_newEntry
            // 
            this.button1_newEntry.BackColor = System.Drawing.Color.White;
            this.button1_newEntry.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.button1_newEntry.Location = new System.Drawing.Point(18, 120);
            this.button1_newEntry.Name = "button1_newEntry";
            this.button1_newEntry.Size = new System.Drawing.Size(120, 25);
            this.button1_newEntry.TabIndex = 7;
            this.button1_newEntry.Text = "Новая запись";
            this.button1_newEntry.UseVisualStyleBackColor = false;
            this.button1_newEntry.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2_delete
            // 
            this.button2_delete.BackColor = System.Drawing.Color.White;
            this.button2_delete.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.button2_delete.Location = new System.Drawing.Point(143, 89);
            this.button2_delete.Name = "button2_delete";
            this.button2_delete.Size = new System.Drawing.Size(120, 25);
            this.button2_delete.TabIndex = 8;
            this.button2_delete.Text = "Удалить";
            this.button2_delete.UseVisualStyleBackColor = false;
            this.button2_delete.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3_save
            // 
            this.button3_save.BackColor = System.Drawing.Color.White;
            this.button3_save.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.button3_save.Location = new System.Drawing.Point(143, 56);
            this.button3_save.Name = "button3_save";
            this.button3_save.Size = new System.Drawing.Size(120, 25);
            this.button3_save.TabIndex = 9;
            this.button3_save.Text = "Сохранить";
            this.button3_save.UseVisualStyleBackColor = false;
            this.button3_save.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4_change
            // 
            this.button4_change.BackColor = System.Drawing.Color.White;
            this.button4_change.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.button4_change.Location = new System.Drawing.Point(18, 89);
            this.button4_change.Name = "button4_change";
            this.button4_change.Size = new System.Drawing.Size(120, 25);
            this.button4_change.TabIndex = 10;
            this.button4_change.Text = "Изменить";
            this.button4_change.UseVisualStyleBackColor = false;
            this.button4_change.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox7_search
            // 
            this.textBox7_search.Location = new System.Drawing.Point(849, 32);
            this.textBox7_search.MaxLength = 50;
            this.textBox7_search.Name = "textBox7_search";
            this.textBox7_search.Size = new System.Drawing.Size(150, 20);
            this.textBox7_search.TabIndex = 19;
            this.textBox7_search.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Запись";
            // 
            // label3_Name
            // 
            this.label3_Name.AutoSize = true;
            this.label3_Name.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label3_Name.Location = new System.Drawing.Point(8, 89);
            this.label3_Name.Name = "label3_Name";
            this.label3_Name.Size = new System.Drawing.Size(76, 19);
            this.label3_Name.TabIndex = 22;
            this.label3_Name.Text = "Название:";
            // 
            // label4_Categiron
            // 
            this.label4_Categiron.AutoSize = true;
            this.label4_Categiron.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label4_Categiron.Location = new System.Drawing.Point(8, 118);
            this.label4_Categiron.Name = "label4_Categiron";
            this.label4_Categiron.Size = new System.Drawing.Size(82, 19);
            this.label4_Categiron.TabIndex = 23;
            this.label4_Categiron.Text = "Категория:";
            // 
            // label5_Count
            // 
            this.label5_Count.AutoSize = true;
            this.label5_Count.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label5_Count.Location = new System.Drawing.Point(283, 89);
            this.label5_Count.Name = "label5_Count";
            this.label5_Count.Size = new System.Drawing.Size(92, 19);
            this.label5_Count.TabIndex = 24;
            this.label5_Count.Text = "Количество:";
            // 
            // label6_manufacturer
            // 
            this.label6_manufacturer.AutoSize = true;
            this.label6_manufacturer.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label6_manufacturer.Location = new System.Drawing.Point(283, 118);
            this.label6_manufacturer.Name = "label6_manufacturer";
            this.label6_manufacturer.Size = new System.Drawing.Size(116, 19);
            this.label6_manufacturer.TabIndex = 25;
            this.label6_manufacturer.Text = "Производитель:";
            // 
            // label7_price
            // 
            this.label7_price.AutoSize = true;
            this.label7_price.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label7_price.Location = new System.Drawing.Point(283, 147);
            this.label7_price.Name = "label7_price";
            this.label7_price.Size = new System.Drawing.Size(46, 19);
            this.label7_price.TabIndex = 26;
            this.label7_price.Text = "Цена:";
            // 
            // pictureBox1_resh
            // 
            this.pictureBox1_resh.Image = global::test.Properties.Resources.reh;
            this.pictureBox1_resh.Location = new System.Drawing.Point(777, 25);
            this.pictureBox1_resh.Name = "pictureBox1_resh";
            this.pictureBox1_resh.Size = new System.Drawing.Size(30, 25);
            this.pictureBox1_resh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1_resh.TabIndex = 27;
            this.pictureBox1_resh.TabStop = false;
            this.pictureBox1_resh.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label9.Location = new System.Drawing.Point(282, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 19);
            this.label9.TabIndex = 28;
            this.label9.Text = "От";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label11.Location = new System.Drawing.Point(447, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 19);
            this.label11.TabIndex = 31;
            this.label11.Text = "До";
            // 
            // dateTimePicker2_filter1
            // 
            this.dateTimePicker2_filter1.Location = new System.Drawing.Point(321, 31);
            this.dateTimePicker2_filter1.MinDate = new System.DateTime(2023, 5, 1, 0, 0, 0, 0);
            this.dateTimePicker2_filter1.Name = "dateTimePicker2_filter1";
            this.dateTimePicker2_filter1.Size = new System.Drawing.Size(120, 20);
            this.dateTimePicker2_filter1.TabIndex = 32;
            // 
            // dateTimePicker3_filter2
            // 
            this.dateTimePicker3_filter2.Location = new System.Drawing.Point(484, 31);
            this.dateTimePicker3_filter2.MinDate = new System.DateTime(2023, 5, 1, 0, 0, 0, 0);
            this.dateTimePicker3_filter2.Name = "dateTimePicker3_filter2";
            this.dateTimePicker3_filter2.Size = new System.Drawing.Size(120, 20);
            this.dateTimePicker3_filter2.TabIndex = 33;
            this.dateTimePicker3_filter2.ValueChanged += new System.EventHandler(this.dateTimePicker3_ValueChanged);
            // 
            // button5_search
            // 
            this.button5_search.BackColor = System.Drawing.Color.White;
            this.button5_search.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.button5_search.Location = new System.Drawing.Point(610, 31);
            this.button5_search.Name = "button5_search";
            this.button5_search.Size = new System.Drawing.Size(75, 23);
            this.button5_search.TabIndex = 34;
            this.button5_search.Text = "Поиск";
            this.button5_search.UseVisualStyleBackColor = false;
            this.button5_search.Click += new System.EventHandler(this.button5_Click);
            // 
            // comboBox2_Categories
            // 
            this.comboBox2_Categories.FormattingEnabled = true;
            this.comboBox2_Categories.Location = new System.Drawing.Point(111, 31);
            this.comboBox2_Categories.Name = "comboBox2_Categories";
            this.comboBox2_Categories.Size = new System.Drawing.Size(150, 21);
            this.comboBox2_Categories.TabIndex = 36;
            this.comboBox2_Categories.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            this.comboBox2_Categories.Click += new System.EventHandler(this.comboBox2_Click);
            // 
            // button6_print
            // 
            this.button6_print.BackColor = System.Drawing.Color.White;
            this.button6_print.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.button6_print.Location = new System.Drawing.Point(18, 58);
            this.button6_print.Name = "button6_print";
            this.button6_print.Size = new System.Drawing.Size(120, 25);
            this.button6_print.TabIndex = 37;
            this.button6_print.Text = "Печать";
            this.button6_print.UseVisualStyleBackColor = false;
            this.button6_print.Click += new System.EventHandler(this.button6_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(197)))), ((int)(((byte)(114)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button1_newEntry);
            this.panel1.Controls.Add(this.button6_print);
            this.panel1.Controls.Add(this.button2_delete);
            this.panel1.Controls.Add(this.button3_save);
            this.panel1.Controls.Add(this.button7_buy);
            this.panel1.Controls.Add(this.textBox8_buy);
            this.panel1.Controls.Add(this.button4_change);
            this.panel1.Location = new System.Drawing.Point(649, 309);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 240);
            this.panel1.TabIndex = 38;
            // 
            // button7_buy
            // 
            this.button7_buy.BackColor = System.Drawing.Color.White;
            this.button7_buy.Font = new System.Drawing.Font("Times New Roman", 11.25F);
            this.button7_buy.Location = new System.Drawing.Point(83, 194);
            this.button7_buy.Name = "button7_buy";
            this.button7_buy.Size = new System.Drawing.Size(120, 25);
            this.button7_buy.TabIndex = 44;
            this.button7_buy.Text = "Продать";
            this.button7_buy.UseVisualStyleBackColor = false;
            this.button7_buy.Click += new System.EventHandler(this.button7_Click);
            // 
            // textBox8_buy
            // 
            this.textBox8_buy.Location = new System.Drawing.Point(68, 168);
            this.textBox8_buy.MaxLength = 8;
            this.textBox8_buy.Name = "textBox8_buy";
            this.textBox8_buy.Size = new System.Drawing.Size(150, 20);
            this.textBox8_buy.TabIndex = 45;
            this.textBox8_buy.TextChanged += new System.EventHandler(this.textBox8_buy_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(8, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 22);
            this.label8.TabIndex = 40;
            this.label8.Text = "Фильтры";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label12.Location = new System.Drawing.Point(16, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 19);
            this.label12.TabIndex = 41;
            this.label12.Text = "Категория";
            // 
            // pictureBox2_search
            // 
            this.pictureBox2_search.Image = global::test.Properties.Resources.photo;
            this.pictureBox2_search.Location = new System.Drawing.Point(813, 25);
            this.pictureBox2_search.Name = "pictureBox2_search";
            this.pictureBox2_search.Size = new System.Drawing.Size(30, 25);
            this.pictureBox2_search.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2_search.TabIndex = 42;
            this.pictureBox2_search.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(103, 78);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(826, 225);
            this.panel2.TabIndex = 43;
            // 
            // dateTimePicker1_admission
            // 
            this.dateTimePicker1_admission.CustomFormat = "";
            this.dateTimePicker1_admission.Location = new System.Drawing.Point(149, 148);
            this.dateTimePicker1_admission.MinDate = new System.DateTime(2023, 5, 1, 0, 0, 0, 0);
            this.dateTimePicker1_admission.Name = "dateTimePicker1_admission";
            this.dateTimePicker1_admission.Size = new System.Drawing.Size(120, 20);
            this.dateTimePicker1_admission.TabIndex = 29;
            this.dateTimePicker1_admission.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label10_admission
            // 
            this.label10_admission.AutoSize = true;
            this.label10_admission.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label10_admission.Location = new System.Drawing.Point(8, 147);
            this.label10_admission.Name = "label10_admission";
            this.label10_admission.Size = new System.Drawing.Size(135, 19);
            this.label10_admission.TabIndex = 46;
            this.label10_admission.Text = "Дата поступления:";
            // 
            // label13_term
            // 
            this.label13_term.AutoSize = true;
            this.label13_term.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.label13_term.Location = new System.Drawing.Point(8, 184);
            this.label13_term.Name = "label13_term";
            this.label13_term.Size = new System.Drawing.Size(112, 19);
            this.label13_term.TabIndex = 47;
            this.label13_term.Text = "Срок годности:";
            // 
            // dateTimePicker4_term
            // 
            this.dateTimePicker4_term.Location = new System.Drawing.Point(149, 184);
            this.dateTimePicker4_term.MinDate = new System.DateTime(2023, 5, 1, 0, 0, 0, 0);
            this.dateTimePicker4_term.Name = "dateTimePicker4_term";
            this.dateTimePicker4_term.Size = new System.Drawing.Size(120, 20);
            this.dateTimePicker4_term.TabIndex = 48;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(197)))), ((int)(((byte)(114)))));
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.button5_search);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.comboBox2_Categories);
            this.panel3.Controls.Add(this.dateTimePicker3_filter2);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.pictureBox2_search);
            this.panel3.Controls.Add(this.dateTimePicker2_filter1);
            this.panel3.Controls.Add(this.textBox7_search);
            this.panel3.Controls.Add(this.pictureBox1_resh);
            this.panel3.Location = new System.Drawing.Point(0, -1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1026, 67);
            this.panel3.TabIndex = 49;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(197)))), ((int)(((byte)(114)))));
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.textBox2_name);
            this.panel4.Controls.Add(this.dateTimePicker4_term);
            this.panel4.Controls.Add(this.textBox1_id);
            this.panel4.Controls.Add(this.label13_term);
            this.panel4.Controls.Add(this.textBox3_categorion);
            this.panel4.Controls.Add(this.label10_admission);
            this.panel4.Controls.Add(this.textBox4_count);
            this.panel4.Controls.Add(this.textBox5_manufacturer);
            this.panel4.Controls.Add(this.textBox6_price);
            this.panel4.Controls.Add(this.dateTimePicker1_admission);
            this.panel4.Controls.Add(this.label7_price);
            this.panel4.Controls.Add(this.label3_Name);
            this.panel4.Controls.Add(this.label6_manufacturer);
            this.panel4.Controls.Add(this.label4_Categiron);
            this.panel4.Controls.Add(this.label5_Count);
            this.panel4.Location = new System.Drawing.Point(36, 309);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(574, 240);
            this.panel4.TabIndex = 50;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::test.Properties.Resources.bloknot1;
            this.pictureBox1.Location = new System.Drawing.Point(5, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 50;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(56, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 26);
            this.label2.TabIndex = 49;
            this.label2.Text = "Запись:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(29, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(234, 26);
            this.label3.TabIndex = 51;
            this.label3.Text = "Панель управления ";
            // 
            // Recipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1025, 608);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "Recipe";
            this.Text = "Новая ортопедия";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Recipe_FormClosed);
            this.Load += new System.EventHandler(this.Recipe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1_resh)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2_search)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1_id;
        private System.Windows.Forms.TextBox textBox2_name;
        private System.Windows.Forms.TextBox textBox3_categorion;
        private System.Windows.Forms.TextBox textBox4_count;
        private System.Windows.Forms.TextBox textBox5_manufacturer;
        private System.Windows.Forms.TextBox textBox6_price;
        private System.Windows.Forms.Button button1_newEntry;
        private System.Windows.Forms.Button button2_delete;
        private System.Windows.Forms.Button button3_save;
        private System.Windows.Forms.Button button4_change;
        private System.Windows.Forms.TextBox textBox7_search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3_Name;
        private System.Windows.Forms.Label label4_Categiron;
        private System.Windows.Forms.Label label5_Count;
        private System.Windows.Forms.Label label6_manufacturer;
        private System.Windows.Forms.Label label7_price;
        private System.Windows.Forms.PictureBox pictureBox1_resh;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dateTimePicker2_filter1;
        private System.Windows.Forms.DateTimePicker dateTimePicker3_filter2;
        private System.Windows.Forms.Button button5_search;
        private System.Windows.Forms.ComboBox comboBox2_Categories;
        private System.Windows.Forms.Button button6_print;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.PictureBox pictureBox2_search;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1_admission;
        private System.Windows.Forms.Button button7_buy;
        private System.Windows.Forms.TextBox textBox8_buy;
        private System.Windows.Forms.Label label10_admission;
        private System.Windows.Forms.Label label13_term;
        private System.Windows.Forms.DateTimePicker dateTimePicker4_term;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
    }
}