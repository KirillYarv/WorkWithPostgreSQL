using System;
using System.Collections.Generic;

namespace WorkWithPostgreSQL.Model.Tables;

public partial class Actor
{
    public Actor(string actId, string actF, string actI, string actO, DateOnly actDateBirth, string actIdTown)
    {
        ActId = actId;
        ActF = actF;
        ActI = actI;
        ActO = actO;
        ActDateBirth = actDateBirth;
        ActIdTown = actIdTown;
    }

    public string ActId { get; set; } = null!;

    public string ActF { get; set; } = null!;

    public string ActI { get; set; } = null!;

    public string ActO { get; set; } = null!;

    public DateOnly ActDateBirth { get; set; }

    public string ActIdTown { get; set; } = null!;

    public virtual Town ActIdTownNavigation { get; set; } = null!;

    public virtual ICollection<Characteristic> Characteristics { get; } = new List<Characteristic>();

    public virtual ICollection<EduActor> EduActors { get; } = new List<EduActor>();

    public virtual ICollection<ExpActor> ExpActors { get; } = new List<ExpActor>();

    public virtual ICollection<ShowActor> ShowActors { get; } = new List<ShowActor>();
}
