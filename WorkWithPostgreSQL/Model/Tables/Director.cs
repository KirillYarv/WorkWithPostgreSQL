using System;
using System.Collections.Generic;
using WorkWithPostgreSQL.Model.Views;

namespace WorkWithPostgreSQL.Model.Tables;

public partial class Director
{
    public Director(string dirId, string dirF, string dirI, string dirO, DateOnly dirDateBirth, bool dirGen, string dirIdTown)
    {
        DirId = dirId;
        DirF = dirF;
        DirI = dirI;
        DirO = dirO;
        DirDateBirth = dirDateBirth;
        DirGen = dirGen;
        DirIdTown = dirIdTown;
    }

    public string DirId { get; set; } = null!;

    public string DirF { get; set; } = null!;

    public string DirI { get; set; } = null!;

    public string DirO { get; set; } = null!;

    public DateOnly DirDateBirth { get; set; }

    public bool DirGen { get; set; }

    public string DirIdTown { get; set; } = null!;

    public virtual Town DirIdTownNavigation { get; set; } = null!;

    public virtual ICollection<EduDirector> EduDirectors { get; } = new List<EduDirector>();

    public virtual ICollection<ExpDirector> ExpDirectors { get; } = new List<ExpDirector>();

    public virtual ICollection<ShowDirector> ShowDirectors { get; } = new List<ShowDirector>();
}
