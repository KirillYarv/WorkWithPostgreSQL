using System;
using System.Collections.Generic;

namespace WorkWithPostgreSQL.Model.Tables;

public partial class Month
{
    public Month(int monId, string monName)
    {
        MonId = monId;
        MonName = monName;
    }

    public int MonId { get; set; }

    public string MonName { get; set; } = null!;
}
