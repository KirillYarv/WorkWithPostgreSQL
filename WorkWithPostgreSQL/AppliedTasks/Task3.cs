using OxyPlot.Series;
using OxyPlot;
using OxyPlot.WindowsForms;
using WorkWithPostgreSQL.Context;

namespace WorkWithPostgreSQL.AppliedTasks
{
    internal class Task3
    {
        TheaterContext context { get; set; }
        public Task3(TheaterContext context)
        {
            this.context = context;
        }

        private double GetSalary(int sumLen) => sumLen / 60.0 * 10000;

        private double GetBonus(int sumLen)
        {
            if (sumLen > 70)
                return 15000;
            else
                return 0;
        }

        public void GetActorsSalary(ref ListView listView1, ref PlotView plot1)
        {
            // Очистка listBox
            var show = context.Shows.ToList();
            var shoact = context.ShowActors.ToList();
            var actor = context.Actors.ToList();

            var actorColumnName = new List<string> { "Имя", "Отчество", "Зарплата", "Зарплата с премией"};

            // Добавление столбцов в listBox
            listView1.View = View.Details;
            listView1.Columns.Clear();
            listView1.Items.Clear();

            foreach (var i in actorColumnName)
                listView1.Columns.Add(i, 130, System.Windows.Forms.HorizontalAlignment.Center);

            // Выборка данных
            var result = from a in actor
                         join sa in shoact on a.ActId equals sa.ShoactAct
                         join s in show on sa.ShoactSho equals s.ShoId

                         where s.ShoDate.Month == DateTime.Now.Month

                         group new { a, sa, s } by new { a.ActI, a.ActO, a.ActId } into g
                         select new
                         {
                             g.Key.ActI,
                             g.Key.ActO,
                             salary = double.Round(GetSalary(g.Sum(c => int.Parse(c.s.ShoLen))),2),
                             salaryBonus = double.Round(GetSalary(g.Sum(c => int.Parse(c.s.ShoLen))) +
                                            GetBonus(g.Sum(c => int.Parse(c.s.ShoLen))),2),
                         };

            // Добавление данных в listBox
            foreach (var item in result)
            {
                listView1.Items.Add(new ListViewItem(new string[]
                {
                    item.ActI,
                    item.ActO,
                    item.salary.ToString(),
                    item.salaryBonus.ToString()
                }));
            }

            // Отрисовка графика
            var myModel = new PlotModel { Title = "Зарплата сотрудников (с бонусом)" };
            var fs = new FunctionSeries();
            var resultList = result.ToList();
            for (var i = 0; i < result.Count(); i++)
            {
                fs.Points.Add(new DataPoint(i, (double)resultList[i].salaryBonus));
            }

            myModel.Series.Add(fs);

            plot1.Model = myModel;
        }
        
    }
}
