using System;
using System.Collections.Generic;

namespace WorkWithPostgreSQL.Model.Tables;

public partial class ExpDirector
{
    public ExpDirector(string expDirId, string expDirWor, DateOnly expDirDateStart, DateOnly? expDirDateEnd, string expDirIdDir)
    {
        ExpDirId = expDirId;
        ExpDirWor = expDirWor;
        ExpDirDateStart = expDirDateStart;
        ExpDirDateEnd = expDirDateEnd;
        ExpDirIdDir = expDirIdDir;
    }

    public string ExpDirId { get; set; } = null!;

    public string ExpDirWor { get; set; } = null!;

    public DateOnly ExpDirDateStart { get; set; }

    public DateOnly? ExpDirDateEnd { get; set; }

    public string ExpDirIdDir { get; set; } = null!;

    public virtual Director ExpDirIdDirNavigation { get; set; } = null!;
}
