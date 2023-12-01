using System;
using System.Collections.Generic;

namespace KursaVue.Model;

public partial class PersonalDatum
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public string? Sname { get; set; }

    public string? MidellName { get; set; }

    public DateTime? Date { get; set; }

    public int Id { get; set; }

    public virtual User User { get; set; } = null!;

  
}
