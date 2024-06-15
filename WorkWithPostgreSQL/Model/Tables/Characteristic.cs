using System;
using System.Collections.Generic;

namespace WorkWithPostgreSQL.Model.Tables;

public partial class Characteristic
{
    public Characteristic(string chaId, bool chaGen, string chaBod, string chaRac, string? chaNat, string chaIdAct)
    {
        ChaId = chaId;
        ChaGen = chaGen;
        ChaBod = chaBod;
        ChaRac = chaRac;
        ChaNat = chaNat;
        ChaIdAct = chaIdAct;
    }

    public string ChaId { get; set; } = null!;

    public bool ChaGen { get; set; }

    public string ChaBod { get; set; } = null!;

    public string ChaRac { get; set; } = null!;

    public string? ChaNat { get; set; }

    public string ChaIdAct { get; set; } = null!;

    public virtual Actor ChaIdActNavigation { get; set; } = null!;
}
