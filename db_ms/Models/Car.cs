using System;
using System.Collections.Generic;

namespace db_ms.Models;

public partial class Car
{
    public int Id { get; set; }

    public string? Model { get; set; }

    public int? PeopleId { get; set; }

    public virtual Person? People { get; set; }
}
