using System;
using System.Collections.Generic;

namespace WorkWithPostgreSQL.Model.Tables;

public partial class EduDirector
{
    public EduDirector(string eduDirId, string eduDirName, DateOnly eduDirDateStart, DateOnly? eduDirDateEnd, string eduDirIdDir)
    {
        EduDirId = eduDirId;
        EduDirName = eduDirName;
        EduDirDateStart = eduDirDateStart;
        EduDirDateEnd = eduDirDateEnd;
        EduDirIdDir = eduDirIdDir;
    }

    public string EduDirId { get; set; } = null!;

    public string EduDirName { get; set; } = null!;

    public DateOnly EduDirDateStart { get; set; }

    public DateOnly? EduDirDateEnd { get; set; }

    public string EduDirIdDir { get; set; } = null!;

    public virtual Director EduDirIdDirNavigation { get; set; } = null!;
}
