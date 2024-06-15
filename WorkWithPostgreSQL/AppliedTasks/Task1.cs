using OxyPlot.Series;
using OxyPlot;
using OxyPlot.WindowsForms;
using WorkWithPostgreSQL.Context;

namespace WorkWithPostgreSQL.AppliedTasks
{
    internal class Task1
    {
        TheaterContext context { get; set; }
        public Task1(TheaterContext context)
        {
            this.context = context;
        }
        
        public void GetShoLenByMonths(ref ListView listView1, ref PlotView plot1, string year) 
        {
            // Чтение данных
            var show = context.Shows.ToList();
            var month = context.Months.ToList();

            var actorColumnName = new List<string> { "Месяц", "Количество" };

            // Очистка listBox
            listView1.View = View.Details;
            listView1.Columns.Clear();
            listView1.Items.Clear();

            // Добавление столбцов в listBox
            foreach (var i in actorColumnName)
                listView1.Columns.Add(i, 130, System.Windows.Forms.HorizontalAlignment.Center);

            // Выборка данных
            var result = from s in show
                         join m in month on s.ShoDate.Month equals m.MonId

                         where s.ShoDate.Year.ToString() == (year != "" ? year : "2024")
                         orderby m.MonId
                         group new { m, s } by m.MonName into g
                         
                         select new { g.Key, sum = g.Count(c => c.s.ShoId == c.s.ShoId)
                         };
            
            // Добавление данных в listBox
            foreach ( var item in result ) 
            {
                listView1.Items.Add(new ListViewItem(new string[]
                {
                    item.Key,
                    item.sum.ToString(),
                }));
            }

            // Отрисовка графика
            var myModel = new PlotModel { Title = $"Количество спектаклей по месяцам в {(year != "" ? year : "2024")}" };
            var fs = new FunctionSeries();
            var resultList = result.ToList();
            for (var i = 0; i < result.Count(); i++)
            {
                fs.Points.Add(new DataPoint(i+1, (double)resultList[i].sum));
            }
            
            myModel.Series.Add(fs);

            plot1.Model = myModel;
        }
    }
}
