using WorkWithPostgreSQL.Context;
using WorkWithPostgreSQL.DML;
using WorkWithPostgreSQL.Model.Tables;
using WorkWithPostgreSQL.AppliedTasks;

namespace WorkWithPostgreSQL
{
    public partial class Form1 : Form
    {
        TheaterContext context;
        SelectTables select;
        InsertTables insert;

        Task1 task1;
        Task2 task2;
        Task3 task3;

        public Form1()
        {
            context = new TheaterContext();
            select = new SelectTables(context);
            insert = new InsertTables(context);

            task1 = new Task1(context);
            task2 = new Task2(context);
            task3 = new Task3(context);

            InitializeComponent();

            comboBox1.SelectedValueChanged += ComboBox1_SelectedValueChanged;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Актёры":
                    select.GetActor(ref listView1);
                    break;
                case "Режиссёры":
                    select.GetDirector(ref listView1);
                    break;
                case "Спектакли":
                    select.GetShows(ref listView1);
                    break;
                case "Города":
                    select.GetTown(ref listView1);
                    break;
                case "Площадки":
                    select.GetPlace(ref listView1);
                    break;

            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Выбор таблицы
        private void ComboBox1_SelectedValueChanged(object? sender, EventArgs e)
        {
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";

            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            dateTimePicker1.Enabled = false;

            switch (comboBox1.Text)
            {
                case "Актёры":
                    label2.Text = "Фамилия";
                    label3.Text = "Имя";
                    label4.Text = "Отчество";
                    label6.Text = "Дата рождения";
                    label5.Text = "id города";

                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                    textBox4.Enabled = true;
                    textBox5.Enabled = true;
                    dateTimePicker1.Enabled = true;
                    break;

                case "Режиссёры":
                    label2.Text = "Фамилия";
                    label3.Text = "Имя";
                    label4.Text = "Отчество";
                    label6.Text = "Дата рождения";
                    label5.Text = "Пол(0-жен., 1-муж.)";
                    label7.Text = "id города";

                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                    textBox4.Enabled = true;
                    textBox5.Enabled = true;
                    textBox6.Enabled = true;
                    dateTimePicker1.Enabled = true;
                    break;

                case "Спектакли":
                    label2.Text = "Название";
                    label3.Text = "Длительность (в минутах)";
                    label4.Text = "id площадки";
                    label6.Text = "Дата спектакля";

                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                    textBox4.Enabled = true;
                    dateTimePicker1.Enabled = true;
                    break;

                case "Города":

                    label2.Text = "Название города";
                    textBox2.Enabled = true;
                    break;

                case "Площадки":
                    label2.Text = "ИНН";
                    label3.Text = "Название";
                    label4.Text = "id города";

                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                    textBox4.Enabled = true;
                    break;
            }
        }

        // Добавление в таблицу
        private void button1_Click_1(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Актёры":
                    insert.AddActor(
                        new Actor(
                            "",
                            textBox2.Text,
                            textBox3.Text,
                            textBox4.Text,
                            new DateOnly(
                                dateTimePicker1.Value.Year,
                                dateTimePicker1.Value.Month,
                                dateTimePicker1.Value.Day
                            ),
                            textBox5.Text
                        ));
                    break;
                case "Режиссёры":
                    insert.AddDirector(
                        new Director(
                            "",
                            textBox2.Text,
                            textBox3.Text,
                            textBox4.Text,
                            new DateOnly(
                                dateTimePicker1.Value.Year,
                                dateTimePicker1.Value.Month,
                                dateTimePicker1.Value.Day
                            ),
                            StringGenderToBool(textBox5.Text),
                            textBox6.Text
                        ));
                    break;
                case "Спектакли":
                    insert.AddShows(
                        new Show(
                            "",
                            textBox2.Text,
                            new DateOnly(
                                dateTimePicker1.Value.Year,
                                dateTimePicker1.Value.Month,
                                dateTimePicker1.Value.Day
                            ),
                            textBox3.Text,
                            textBox4.Text
                        ));
                    break;
                case "Города":
                    insert.AddTown(new Town(
                        "",
                        textBox2.Text
                        ));
                    break;
                case "Площадки":
                    insert.AddPlaces(new Place(
                        "",
                        textBox2.Text,
                        textBox3.Text,
                        textBox4.Text
                        ));
                    break;
            }
        }
        // Приведение строки к бинарному типу
        private bool StringGenderToBool(string data)
        {
            if (data == "0") return false; else return true;
        }

        // Обновление в таблице
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                switch (comboBox1.Text)
                {
                    case "Актёры":
                        label1.Text = "id";

                        textBox1.Enabled = true;

                        context.Actors.Update(
                            new Actor(
                                textBox1.Text,
                                textBox2.Text,
                                textBox3.Text,
                                textBox4.Text,
                                new DateOnly(
                                    dateTimePicker1.Value.Year,
                                    dateTimePicker1.Value.Month,
                                    dateTimePicker1.Value.Day
                                ),
                                textBox5.Text
                            ));
                        context.SaveChanges();
                        context.ChangeTracker.Clear();

                        break;
                    case "Режиссёры":
                        context.Directors.Update(
                            new Director(
                                textBox1.Text,
                                textBox2.Text,
                                textBox3.Text,
                                textBox4.Text,
                                new DateOnly(
                                    dateTimePicker1.Value.Year,
                                    dateTimePicker1.Value.Month,
                                    dateTimePicker1.Value.Day
                                ),
                                StringGenderToBool(textBox5.Text),
                                textBox6.Text
                            ));
                        context.SaveChanges();
                        context.ChangeTracker.Clear();
                        break;
                    case "Спектакли":
                        context.Shows.Update(
                            new Show(
                                textBox1.Text,
                                textBox2.Text,
                                new DateOnly(
                                    dateTimePicker1.Value.Year,
                                    dateTimePicker1.Value.Month,
                                    dateTimePicker1.Value.Day
                                ),
                                textBox3.Text,
                                textBox4.Text
                            ));
                        context.SaveChanges();
                        context.ChangeTracker.Clear();
                        break;
                    case "Города":
                        context.Towns.Update(new Town(
                            textBox1.Text,
                            textBox2.Text
                            ));
                        context.SaveChanges();
                        context.ChangeTracker.Clear();
                        break;
                    case "Площадки":
                        context.Places.Update(new Place(
                            textBox1.Text,
                            textBox2.Text,
                            textBox3.Text,
                            textBox4.Text
                            ));
                        context.SaveChanges();
                        context.ChangeTracker.Clear();
                        break;
                }
            }
        }

        // Удаление из таблицы
        private void button3_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Актёры":
                    label1.Text = "id";

                    textBox1.Enabled = true;

                    context.Actors.Remove(new Actor(textBox1.Text, "", "", "", new DateOnly(), ""));
                    context.SaveChanges();
                    context.ChangeTracker.Clear();
                    break;
                case "Режиссёры":
                    label1.Text = "id";

                    textBox1.Enabled = true;

                    context.Directors.Remove(new Director(textBox1.Text, "", "", "", new DateOnly(), false, ""));
                    context.SaveChanges();
                    context.ChangeTracker.Clear();
                    break;
                case "Спектакли":
                    label1.Text = "id";

                    textBox1.Enabled = true;

                    context.Shows.Remove(new Show(textBox1.Text, "", new DateOnly(), "", ""));
                    context.SaveChanges();
                    context.ChangeTracker.Clear();
                    break;
                case "Города":
                    label1.Text = "id";

                    textBox1.Enabled = true;

                    context.Towns.Remove(new Town(textBox1.Text, ""));
                    context.SaveChanges();
                    context.ChangeTracker.Clear();
                    break;
                case "Площадки":
                    label1.Text = "id";

                    textBox1.Enabled = true;

                    context.Places.Remove(new Place(textBox1.Text, "", "", ""));
                    context.SaveChanges();
                    context.ChangeTracker.Clear();
                    break;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // Найти по id
        private void button1_Click_2(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Актёры":
                    var actor1 = context.Actors.Find(textBox1.Text);
                    textBox2.Text = actor1?.ActF;
                    textBox3.Text = actor1?.ActI;
                    textBox4.Text = actor1?.ActO;
                    textBox5.Text = actor1?.ActIdTown;
                    dateTimePicker1.Text = actor1?.ActDateBirth.ToString();
                    break;

                case "Режиссёры":
                    var director1 = context.Directors.Find(textBox1.Text);

                    textBox2.Text = director1?.DirF;
                    textBox3.Text = director1?.DirI;
                    textBox4.Text = director1?.DirO;
                    textBox5.Text = director1?.DirGen.ToString();
                    textBox6.Text = director1?.DirIdTown;
                    dateTimePicker1.Text = director1?.DirDateBirth.ToString();
                    break;

                case "Спектакли":
                    var show1 = context.Shows.Find(textBox1.Text);

                    textBox2.Text = show1?.ShoName;
                    textBox3.Text = show1?.ShoLen;
                    textBox4.Text = show1?.ShoIdPla;
                    dateTimePicker1.Text = show1?.ShoDate.ToString();
                    break;

                case "Города":
                    var town1 = context.Towns.Find(textBox1.Text);

                    textBox2.Text = town1?.TwoName;
                    break;

                case "Площадки":
                    var place1 = context.Places.Find(textBox1.Text);

                    textBox2.Text = place1?.PlaInn;
                    textBox3.Text = place1?.PlaName;
                    textBox4.Text = place1?.PlaIdTow;
                    break;
            }
        }

        // Прикладная задача 1
        private void button2_Click_1(object sender, EventArgs e)
        {
            task1.GetShoLenByMonths(ref listView1, ref plotView1, textBox7.Text);
        }

        // Прикладная задача 2
        private void button3_Click_1(object sender, EventArgs e)
        {
            task2.GetActorsWithKoef(ref listView1, ref plotView1, textBox7.Text);
        }

        // Прикладная задача 3
        private void button4_Click(object sender, EventArgs e)
        {
            task3.GetActorsSalary(ref listView1, ref plotView1);
        }
    }
}