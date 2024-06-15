using System;
using System.Collections.Generic;

namespace WorkWithPostgreSQL.Model.Tables;

public partial class Town
{
    public Town(string twoId, string twoName)
    {
        TwoId = twoId;
        TwoName = twoName;
    }

    public string TwoId { get; set; } = null!;

    public string TwoName { get; set; } = null!;

    public virtual ICollection<Actor> Actors { get; } = new List<Actor>();

    public virtual ICollection<Director> Directors { get; } = new List<Director>();

    public virtual ICollection<Place> Places { get; } = new List<Place>();
}
