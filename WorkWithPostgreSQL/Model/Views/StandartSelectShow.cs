using System;
using System.Collections.Generic;

namespace WorkWithPostgreSQL.Model.Views;

public partial class StandartSelectShow
{
    public string? НазваниеСпектакля { get; set; }

    public DateOnly? ДатаСпектакля { get; set; }

    public string? ДлительностьСпектакля { get; set; }

    public string? Площадка { get; set; }

    public string? Город { get; set; }
}
