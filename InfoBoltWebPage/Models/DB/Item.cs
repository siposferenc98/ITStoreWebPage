﻿using System.Text.Json.Serialization;

namespace InfoBoltWebPage.Models.DB;

public partial class Item
{
    public int Id { get; set; }
    public int Orderid { get; set; }
    public int Productid { get; set; }
    public int Productcount { get; set; }
    //public virtual Order Order { get; set; } = null!;
}

