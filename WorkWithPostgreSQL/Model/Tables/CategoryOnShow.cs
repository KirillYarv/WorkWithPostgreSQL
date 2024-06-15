using System;
using System.Collections.Generic;

namespace WorkWithPostgreSQL.Model.Tables;

public partial class CategoryOnShow
{
    public CategoryOnShow(string catToShoId, string catToShoShoId, string catToShoCatShoId)
    {
        CatToShoId = catToShoId;
        CatToShoShoId = catToShoShoId;
        CatToShoCatShoId = catToShoCatShoId;
    }

    public string CatToShoId { get; set; } = null!;

    public string CatToShoShoId { get; set; } = null!;

    public string CatToShoCatShoId { get; set; } = null!;

    public virtual CategoryShow CatToShoCatSho { get; set; } = null!;

    public virtual Show CatToShoSho { get; set; } = null!;
}
