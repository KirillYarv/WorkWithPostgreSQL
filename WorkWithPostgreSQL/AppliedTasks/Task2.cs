using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot;
using WorkWithPostgreSQL.Context;
using WorkWithPostgreSQL.Model.Tables;

namespace WorkWithPostgreSQL.AppliedTasks
{
    internal class Task2
    {
        TheaterContext context { get; set; }
        public Task2(TheaterContext context)
        {
            this.context = context;
        }

        private string GetArrayShowOfActor(List<Show> shows, List<ShowActor> showActors, int id) 
        {
            var result = (from s in shows
                    join sa in showActors on s.ShoId equals sa.ShoactSho
                    where int.Parse(sa.ShoactAct) == id
                    orderby s.ShoDate descending
                    select s.ShoDate).ToList();

            var resultString = "";
            for (int i = 0; i < result.Count(); i++)
            {
                if ((i + 1) != result.Count())
                    resultString += $"{result[i]}, ";
                else
                    resultString += $"{result[i]}";
            }

            return resultString;
        }

        private decimal AvgCom(List<Show> shows, int sum, int count) 
        {
            return sum / count/ shows.Average(c => decimal.Parse(c.ShoLen));
        }

        public void GetActorsWithKoef(ref ListView listView1, ref PlotView plot1, string year)
        {
            // Чтение данных
            var show = context.Shows.ToList();
            var shoact = context.ShowActors.ToList();
            var actor = context.Actors.ToList();


            var actorColumnName = new List<string> { "Имя", "Отчество", "Длительность", "Количество", "Даты", "Коэффициент"};

            // Очистка listBox
            listView1.View = View.Details;
            listView1.Columns.Clear();
            listView1.Items.Clear();

            // Добавление столбцов в listBox
            foreach (var i in actorColumnName)
                listView1.Columns.Add(i, 130, System.Windows.Forms.HorizontalAlignment.Center);

            // Выборка данных
            var result = from r in (from a in actor
                         join sa in shoact on a.ActId equals sa.ShoactAct
                         join s in show on sa.ShoactSho equals s.ShoId
                         group new {a,sa, s } by new { a.ActI, a.ActO,a.ActId} into g
                         select new 
                         { 
                             g.Key.ActI, 
                             g.Key.ActO, 
                             sum = g.Sum(c => int.Parse(c.s.ShoLen)), 
                             count = g.Count(c=> c.sa.ShoactAct == c.a.ActId),
                             shoDate = GetArrayShowOfActor(show,shoact, int.Parse(g.Key.ActId)),
                             avgCom = AvgCom(show, g.Sum(c => int.Parse(c.s.ShoLen)), g.Count(c => c.sa.ShoactAct == c.a.ActId))
                         })
                         orderby r.sum descending
                         select r;

            // Добавление данных в listBox
            foreach (var item in result)
            {
                listView1.Items.Add(new ListViewItem(new string[]
                {
                    item.ActI,
                    item.ActO,
                    item.sum.ToString(),
                    item.count.ToString(),
                    item.shoDate.ToString(),
                    item.avgCom.ToString()

                }));
            }

            // Отрисовка графика
            var myModel = new PlotModel { Title = "Работа сотрудников по коэфициенту" };
            var fs = new FunctionSeries();
            var resultList = result.ToList();
            for (var i = 0; i < result.Count(); i++)
            {
                fs.Points.Add(new DataPoint(i, (double)resultList[i].avgCom));
            }

            myModel.Series.Add(fs);

            plot1.Model = myModel;
        }
    }
}
