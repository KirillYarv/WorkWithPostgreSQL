using System;
using System.Collections.Generic;

namespace WorkWithPostgreSQL.Model.Tables;

public partial class EduActor
{
    public EduActor(string eduActId, string eduActName, DateOnly eduActDateStart, DateOnly? eduActDateEnd, string eduActIdAct)
    {
        EduActId = eduActId;
        EduActName = eduActName;
        EduActDateStart = eduActDateStart;
        EduActDateEnd = eduActDateEnd;
        EduActIdAct = eduActIdAct;
    }

    public string EduActId { get; set; } = null!;

    public string EduActName { get; set; } = null!;

    public DateOnly EduActDateStart { get; set; }

    public DateOnly? EduActDateEnd { get; set; }

    public string EduActIdAct { get; set; } = null!;

    public virtual Actor EduActIdActNavigation { get; set; } = null!;
}
