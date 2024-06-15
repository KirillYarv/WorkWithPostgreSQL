using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWithPostgreSQL.Context;
using WorkWithPostgreSQL.Model.Tables;
using WorkWithPostgreSQL.Model.Views;

namespace WorkWithPostgreSQL.DML
{
    internal class SelectTables
    {
        TheaterContext context { get; set; }
        
        public SelectTables(TheaterContext context) 
        {
            this.context = context;
        }

        public void GetActor(ref ListView listView1)
        {
            List<Actor> actors = context.Actors.ToList();
            List<Town> towns = context.Towns.ToList();

            var actorColumnName = new List<string> { "id", "Фамилия", "Имя", "Отчество", "Дата рождения", "Город" };

            listView1.View = View.Details;

            listView1.Columns.Clear();
            listView1.Items.Clear();

            foreach (var i in actorColumnName)
                listView1.Columns.Add(i, 130, HorizontalAlignment.Center);

            var actorQuery = from a in actors
                             join t in towns on a.ActIdTown equals t.TwoId
                             select new { a.ActId, a.ActF, a.ActI, a.ActO, a.ActDateBirth, t.TwoName };

            foreach (var i in actorQuery)
            {
                listView1.Items.Add(new ListViewItem(new string[]
                {
                    i.ActId,
                    i.ActF,
                    i.ActI,
                    i.ActO,
                    i.ActDateBirth.ToString(),
                    i.TwoName
                }));
            }
            context.SaveChanges();
        }

        public void GetDirector(ref ListView listView1)
        {
            List<Director> directors = context.Directors.ToList();
            List<Town> towns = context.Towns.ToList();

            var directorColumnName = new List<string> { "id", "Фамилия", "Имя", "Отчество", "Дата рождения", "Пол", "Город" };

            listView1.View = View.Details;

            listView1.Columns.Clear();
            listView1.Items.Clear();

            foreach (var i in directorColumnName)
                listView1.Columns.Add(i, 130, HorizontalAlignment.Center);

            var directorQuery = from d in directors
                                join t in towns on d.DirIdTown equals t.TwoId
                                select new { d.DirId, d.DirF, d.DirI, d.DirO, d.DirDateBirth, d.DirGen, t.TwoName };

            foreach (var i in directorQuery)
            {
                listView1.Items.Add(new ListViewItem(new string[]
                {
                    i.DirId,
                    i.DirF,
                    i.DirI,
                    i.DirO,
                    i.DirDateBirth.ToString(),
                    i.DirGen.ToString(),
                    i.TwoName
                }));
            }
        }

        public void GetShows(ref ListView listView1)
        {
            List<Show> shows = context.Shows.ToList();
            List<Town> towns = context.Towns.ToList();
            List<Place> places = context.Places.ToList();

            var showsColumnName = new List<string> { "id", "Название", "Дата", "Длительность", "Площадка", "Город" };

            listView1.View = View.Details;

            listView1.Columns.Clear();
            listView1.Items.Clear();

            foreach (var i in showsColumnName)
                listView1.Columns.Add(i, 130, HorizontalAlignment.Center);

            var standartShowsQuery = from s in shows
                                     join p in places on s.ShoIdPla equals p.PlaId
                                     join t in towns on p.PlaIdTow equals t.TwoId

                                     select new { s.ShoId, s.ShoName, s.ShoDate, s.ShoLen, p.PlaName, t.TwoName};

            foreach (var i in standartShowsQuery)
            {
                listView1.Items.Add(new ListViewItem(new string[]
                {
                    i.ShoId, 
                    i.ShoName, 
                    i.ShoDate.ToString(), 
                    i.ShoLen, 
                    i.PlaName, 
                    i.TwoName
                }));
            }
        }
        public void GetTown(ref ListView listView1)
        {
            List<Town> towns = context.Towns.ToList();

            var townColumnName = new List<string> { "id", "Название"};

            listView1.View = View.Details;

            listView1.Columns.Clear();
            listView1.Items.Clear();

            foreach (var i in townColumnName)
                listView1.Columns.Add(i, 130, HorizontalAlignment.Center);

            foreach (var i in towns)
            {
                listView1.Items.Add(new ListViewItem(new string[]
                {
                    i.TwoId, 
                    i.TwoName, 
                }));
            }
        }public void GetPlace(ref ListView listView1)
        {
            List<Place> places = context.Places.ToList();

            var directorColumnName = new List<string> { "id", "ИНН", "Название", "id города"};

            listView1.View = View.Details;

            listView1.Columns.Clear();
            listView1.Items.Clear();

            foreach (var i in directorColumnName)
                listView1.Columns.Add(i, 130, HorizontalAlignment.Center);
                         

            foreach (var i in places)
            {
                listView1.Items.Add(new ListViewItem(new string[]
                {
                    i.PlaId, 
                    i.PlaInn,
                    i.PlaName, 
                    i.PlaIdTow
                }));
            }
        }
    }
}
