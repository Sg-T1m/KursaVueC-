using System;
using System.Collections.Generic;

namespace KursaVue.Model;

public partial class User
{
    public int Id { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? TypeUsers { get; set; }

    public int? PersonalDataId { get; set; }

    public virtual List<PersonalDatum> PersonalData { get; set; } = new List<PersonalDatum>();
  
    public virtual List<Product> Products { get; set; } = new List<Product>();

    public static implicit operator List<object>(User v)
    {
        throw new NotImplementedException();
    }
}
