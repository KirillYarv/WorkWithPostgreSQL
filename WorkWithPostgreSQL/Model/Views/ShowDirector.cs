using System;
using System.Collections.Generic;
using WorkWithPostgreSQL.Model.Tables;

namespace WorkWithPostgreSQL.Model.Views;

public partial class ShowDirector
{
    public string ShodirId { get; set; } = null!;

    public string ShodirSho { get; set; } = null!;

    public string ShodirDir { get; set; } = null!;

    public virtual Director ShodirDirNavigation { get; set; } = null!;

    public virtual Show ShodirShoNavigation { get; set; } = null!;
}
