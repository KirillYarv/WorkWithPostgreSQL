using System;
using System.Collections.Generic;

namespace WorkWithPostgreSQL.Model.Tables;

public partial class ShowActor
{
    public ShowActor(string shoactId, string shoactSho, string shoactAct)
    {
        ShoactId = shoactId;
        ShoactSho = shoactSho;
        ShoactAct = shoactAct;
    }

    public string ShoactId { get; set; } = null!;

    public string ShoactSho { get; set; } = null!;

    public string ShoactAct { get; set; } = null!;

    public virtual Actor ShoactActNavigation { get; set; } = null!;

    public virtual Show ShoactShoNavigation { get; set; } = null!;
}
