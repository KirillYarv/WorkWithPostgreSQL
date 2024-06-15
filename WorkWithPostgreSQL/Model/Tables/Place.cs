using System;
using System.Collections.Generic;

namespace WorkWithPostgreSQL.Model.Tables;

public partial class Place
{
    public Place(string plaId, string plaInn, string plaName, string plaIdTow)
    {
        PlaId = plaId;
        PlaInn = plaInn;
        PlaName = plaName;
        PlaIdTow = plaIdTow;
    }

    public string PlaId { get; set; } = null!;

    public string PlaInn { get; set; } = null!;

    public string PlaName { get; set; } = null!;

    public string PlaIdTow { get; set; } = null!;

    public virtual Town PlaIdTowNavigation { get; set; } = null!;

    public virtual ICollection<Show> Shows { get; } = new List<Show>();
}
