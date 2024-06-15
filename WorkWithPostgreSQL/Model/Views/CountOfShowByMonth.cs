using System;
using System.Collections.Generic;

namespace WorkWithPostgreSQL.Model.Views;

public partial class CountOfShowByMonth
{
    public string? Месяц { get; set; }

    public long? КоличествоПоМесяцам2024ГодаВМи { get; set; }
}
