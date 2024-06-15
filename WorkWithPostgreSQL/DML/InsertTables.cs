using WorkWithPostgreSQL.Context;
using WorkWithPostgreSQL.Model.Tables;

namespace WorkWithPostgreSQL.DML
{
    internal class InsertTables
    {
        TheaterContext context { get; set; }

        public InsertTables(TheaterContext context)
        {
            this.context = context;
        }

        public void AddTown(Town townData)
        {
            List<Town> towns = context.Towns.ToList();
            int idMax = int.MinValue;

            foreach (var town in towns)
            {
                var id = int.Parse(town.TwoId);
                if (idMax <= id)
                    idMax = id+1;
            }

            townData.TwoId = idMax.ToString();

            context.Towns.Add(townData);
            context.SaveChanges();
            context.ChangeTracker.Clear();
        }
        public void AddActor(Actor actorData)
        {
            List<Actor> actors = context.Actors.ToList();
            int idMax = int.MinValue;

            foreach (var actor in actors)
            {
                var id = int.Parse(actor.ActId);
                if (idMax <= id)
                    idMax = id + 1;
            }

            actorData.ActId = idMax.ToString();

            context.Actors.Add(actorData);
            context.SaveChanges();
            context.ChangeTracker.Clear();
        }
        public void AddDirector(Director directorData)
        {
            List<Director> directors = context.Directors.ToList();
            int idMax = int.MinValue;

            foreach (var director in directors)
            {
                var id = int.Parse(director.DirId);
                if (idMax <= id)
                    idMax = id + 1;
            }

            directorData.DirId = idMax.ToString();

            context.Directors.Add(directorData);
            context.SaveChanges();
            context.ChangeTracker.Clear();
        }
        public void AddShows(Show showData)
        {
            List<Show> shows = context.Shows.ToList();
            int idMax = int.MinValue;

            foreach (var show in shows)
            {
                var id = int.Parse(show.ShoId);
                if (idMax <= id)
                    idMax = id + 1;
            }

            showData.ShoId = idMax.ToString();

            context.Shows.Add(showData);
            context.SaveChanges();
            context.ChangeTracker.Clear();
        }
        public void AddPlaces(Place placeData)
        {
            List<Place> places = context.Places.ToList();
            int idMax = int.MinValue;

            foreach (var place in places)
            {
                var id = int.Parse(place.PlaId);
                if (idMax <= id)
                    idMax = id + 1;
            }

            placeData.PlaId = idMax.ToString();

            context.Places.Add(placeData);
            context.SaveChanges();
            context.ChangeTracker.Clear();
        }
    }
}
