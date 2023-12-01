﻿using System;
using System.Collections.Generic;

namespace KursaVue.Model;

public partial class Category
{
    public int Id { get; set; }

    public string NameCategories { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
