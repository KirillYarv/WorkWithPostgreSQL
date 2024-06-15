using System;
using System.Collections.Generic;
using WorkWithPostgreSQL.Model.Views;

namespace WorkWithPostgreSQL.Model.Tables;

public partial class Show
{
    public Show(string shoId, string shoName, DateOnly shoDate, string shoLen, string shoIdPla)
    {
        ShoId = shoId;
        ShoName = shoName;
        ShoDate = shoDate;
        ShoLen = shoLen;
        ShoIdPla = shoIdPla;
    }

    public string ShoId { get; set; } = null!;

    public string ShoName { get; set; } = null!;

    public DateOnly ShoDate { get; set; }

    public string ShoLen { get; set; } = null!;

    public string ShoIdPla { get; set; } = null!;

    public virtual ICollection<CategoryOnShow> CategoryOnShows { get; } = new List<CategoryOnShow>();

    public virtual Place ShoIdPlaNavigation { get; set; } = null!;

    public virtual ICollection<ShowActor> ShowActors { get; } = new List<ShowActor>();

    public virtual ICollection<ShowDirector> ShowDirectors { get; } = new List<ShowDirector>();
}
