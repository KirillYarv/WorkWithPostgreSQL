using System;
using System.Collections.Generic;

namespace WorkWithPostgreSQL.Model.Tables;

public partial class CategoryShow
{
    public CategoryShow(string catShoId, string catShoName)
    {
        CatShoId = catShoId;
        CatShoName = catShoName;
    }

    public string CatShoId { get; set; } = null!;

    public string CatShoName { get; set; } = null!;

    public virtual ICollection<CategoryOnShow> CategoryOnShows { get; } = new List<CategoryOnShow>();
}
