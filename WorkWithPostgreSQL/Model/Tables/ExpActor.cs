using System;
using System.Collections.Generic;

namespace WorkWithPostgreSQL.Model.Tables;

public partial class ExpActor
{
    public ExpActor(string expActId, string expActWor, DateOnly expActDateStart, DateOnly? expActDateEnd, string expActIdArt)
    {
        ExpActId = expActId;
        ExpActWor = expActWor;
        ExpActDateStart = expActDateStart;
        ExpActDateEnd = expActDateEnd;
        ExpActIdArt = expActIdArt;
    }

    public string ExpActId { get; set; } = null!;

    public string ExpActWor { get; set; } = null!;

    public DateOnly ExpActDateStart { get; set; }

    public DateOnly? ExpActDateEnd { get; set; }

    public string ExpActIdArt { get; set; } = null!;

    public virtual Actor ExpActIdArtNavigation { get; set; } = null!;
}
