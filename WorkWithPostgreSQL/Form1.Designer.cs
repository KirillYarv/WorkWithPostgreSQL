namespace WorkWithPostgreSQL
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SelectButton = new Button();
            listView1 = new ListView();
            comboBox1 = new ComboBox();
            insertButton = new Button();
            UpdateButton = new Button();
            RemoveButton = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            textBox6 = new TextBox();
            button1 = new Button();
            plotView1 = new OxyPlot.WindowsForms.PlotView();
            label8 = new Label();
            label9 = new Label();
            textBox7 = new TextBox();
            label10 = new Label();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // SelectButton
            // 
            SelectButton.Location = new Point(410, 514);
            SelectButton.Name = "SelectButton";
            SelectButton.Size = new Size(125, 58);
            SelectButton.TabIndex = 2;
            SelectButton.Text = "Получить данные";
            SelectButton.UseVisualStyleBackColor = true;
            SelectButton.Click += button1_Click;
            // 
            // listView1
            // 
            listView1.Location = new Point(562, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(682, 560);
            listView1.TabIndex = 3;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Актёры", "Режиссёры", "Спектакли", "Города", "Площадки" });
            comboBox1.Location = new Point(384, 386);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 6;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // insertButton
            // 
            insertButton.Location = new Point(219, 386);
            insertButton.Name = "insertButton";
            insertButton.Size = new Size(125, 58);
            insertButton.TabIndex = 7;
            insertButton.Text = "Добавить данные";
            insertButton.UseVisualStyleBackColor = true;
            insertButton.Click += button1_Click_1;
            // 
            // UpdateButton
            // 
            UpdateButton.Location = new Point(219, 450);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(125, 58);
            UpdateButton.TabIndex = 8;
            UpdateButton.Text = "Обновить данные";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += button2_Click;
            // 
            // RemoveButton
            // 
            RemoveButton.Location = new Point(219, 514);
            RemoveButton.Name = "RemoveButton";
            RemoveButton.Size = new Size(125, 58);
            RemoveButton.TabIndex = 9;
            RemoveButton.Text = "Удалить данные";
            RemoveButton.UseVisualStyleBackColor = true;
            RemoveButton.Click += button3_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(36, 93);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 10;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Enabled = false;
            textBox2.Location = new Point(36, 153);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 11;
            // 
            // textBox3
            // 
            textBox3.Enabled = false;
            textBox3.Location = new Point(36, 204);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 12;
            // 
            // textBox4
            // 
            textBox4.Enabled = false;
            textBox4.Location = new Point(37, 266);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 13;
            // 
            // textBox5
            // 
            textBox5.Enabled = false;
            textBox5.Location = new Point(36, 322);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(125, 27);
            textBox5.TabIndex = 14;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Enabled = false;
            dateTimePicker1.Location = new Point(189, 204);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 27);
            dateTimePicker1.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 72);
            label1.Name = "label1";
            label1.Size = new Size(22, 20);
            label1.TabIndex = 17;
            label1.Text = "id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 132);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 18;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 185);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 19;
            label3.Text = "label3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(37, 243);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 20;
            label4.Text = "label4";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(37, 299);
            label5.Name = "label5";
            label5.Size = new Size(50, 20);
            label5.TabIndex = 21;
            label5.Text = "label5";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(189, 181);
            label6.Name = "label6";
            label6.Size = new Size(50, 20);
            label6.TabIndex = 22;
            label6.Text = "label6";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(37, 364);
            label7.Name = "label7";
            label7.Size = new Size(50, 20);
            label7.TabIndex = 24;
            label7.Text = "label7";
            // 
            // textBox6
            // 
            textBox6.Enabled = false;
            textBox6.Location = new Point(36, 387);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(125, 27);
            textBox6.TabIndex = 23;
            // 
            // button1
            // 
            button1.Location = new Point(180, 91);
            button1.Name = "button1";
            button1.Size = new Size(116, 29);
            button1.TabIndex = 25;
            button1.Text = "Найти по id";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_2;
            // 
            // plotView1
            // 
            plotView1.Location = new Point(562, 578);
            plotView1.Name = "plotView1";
            plotView1.PanCursor = Cursors.Hand;
            plotView1.Size = new Size(682, 248);
            plotView1.TabIndex = 27;
            plotView1.Text = "plotView1";
            plotView1.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView1.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView1.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(148, 12);
            label8.Name = "label8";
            label8.Size = new Size(170, 20);
            label8.TabIndex = 28;
            label8.Text = "Работа с базой данных";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(219, 610);
            label9.Name = "label9";
            label9.Size = new Size(149, 20);
            label9.TabIndex = 29;
            label9.Text = "Прикладные задачи";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(65, 676);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(125, 27);
            textBox7.TabIndex = 30;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(67, 653);
            label10.Name = "label10";
            label10.Size = new Size(33, 20);
            label10.TabIndex = 31;
            label10.Text = "Год";
            // 
            // button2
            // 
            button2.Location = new Point(67, 730);
            button2.Name = "button2";
            button2.Size = new Size(125, 96);
            button2.TabIndex = 32;
            button2.Text = "Количество спектаклей по месяцам";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // button3
            // 
            button3.Location = new Point(219, 730);
            button3.Name = "button3";
            button3.Size = new Size(123, 96);
            button3.TabIndex = 33;
            button3.Text = "Коэффициент работы актёров";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // button4
            // 
            button4.Location = new Point(384, 730);
            button4.Name = "button4";
            button4.Size = new Size(123, 96);
            button4.TabIndex = 34;
            button4.Text = "Зарплата актёров в текущем месяце";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1256, 834);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label10);
            Controls.Add(textBox7);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(plotView1);
            Controls.Add(button1);
            Controls.Add(label7);
            Controls.Add(textBox6);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dateTimePicker1);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(RemoveButton);
            Controls.Add(UpdateButton);
            Controls.Add(insertButton);
            Controls.Add(comboBox1);
            Controls.Add(listView1);
            Controls.Add(SelectButton);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button SelectButton;
        private ListView listView1;
        private ComboBox comboBox1;
        private Button insertButton;
        private Button UpdateButton;
        private Button RemoveButton;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private DateTimePicker dateTimePicker1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textBox6;
        private Button button1;
        private OxyPlot.WindowsForms.PlotView plotView1;
        private Label label8;
        private Label label9;
        private TextBox textBox7;
        private Label label10;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}